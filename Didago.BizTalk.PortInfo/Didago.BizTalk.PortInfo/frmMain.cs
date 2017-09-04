using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.BizTalk.ExplorerOM;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Collections;

namespace Didago.BizTalk.PortInfo
{
    public partial class frmBizTalkPortInfo : Form
    {
        // instantiate new instance of Explorer OM
        static BtsCatalogExplorer _btsExp = new BtsCatalogExplorer();

        public frmBizTalkPortInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the ExplorerOM object model component to be able to read BizTalk information
        /// </summary>
        private bool InitializeExplorerOm()
        {
            string sqlServer = tbSQLServer.Text;
            string btsMgmtDb = tbBtsMgmtDb.Text;

            lblConnecting.Visible = true;
            System.Windows.Forms.Application.DoEvents(); // Make sure the changes are immediately visible

            // connection string to the BizTalk management database where the ports will be created
            try
            {
                if (chkIntSecurity.Checked)
                {
                    _btsExp.ConnectionString = string.Format("Server={0};Database={1};Integrated Security=true", sqlServer, btsMgmtDb);
                }
                else
                {
                    string uid = tbUserId.Text;
                    string pwd = tbPwd.Text;
                    _btsExp.ConnectionString = string.Format("Server={0};Database={1};UserId={2};Pwd={3};Integrated Security=false", sqlServer, btsMgmtDb, uid, pwd);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the BizTalk database. Please make sure the connection settings are correct. " + System.Environment.NewLine + "("+ ex.Message +")", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } 
            lblConnecting.Visible = false;
            return true;

        }

        /// <summary>
        /// Select integrated security or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIntSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIntSecurity.Checked)
            {
                tbUserId.Enabled = false;
                tbPwd.Enabled = false;
            }
            else
            {
                tbUserId.Enabled = true;
                tbPwd.Enabled = true;
            }
        }

        /// <summary>
        /// Read all BizTalk applications from the setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetBtsApps_Click(object sender, EventArgs e)
        {
            progressBtsApps.Value = 0;
            progressBtsApps.PerformStep();

            // Initialize the ExplorerOM with the connection string
            if (InitializeExplorerOm())
            {
                progressBtsApps.Step = 90 / (_btsExp.Applications.Count + 1);

                // Clear the checkbox list
                chkBtsAppList.Items.Clear();

                // Add all non-system applications
                foreach (Microsoft.BizTalk.ExplorerOM.Application app in _btsExp.Applications)
                {
                    // Don't display the system apps
                    if (!app.IsSystem)
                    {
                        chkBtsAppList.Items.Add(app.Name, false);
                        progressBtsApps.PerformStep();
                        System.Windows.Forms.Application.DoEvents(); // Make sure the changes are immediately visible
                    }
                }

                progressBtsApps.Value = 100;
            }
        }

        /// <summary>
        /// Retrieve receive port information for checked applications
        /// </summary>
        private void GetReceivePorts()
        {
            // Clear the checkbox list
            tvReceivePorts.Nodes.Clear();

            // Display for checked BizTalk applications
            foreach (var btsAppItem in chkBtsAppList.CheckedItems)
            {
                TreeNode tnRoot = tvReceivePorts.Nodes.Add(btsAppItem.ToString());

                // Get a reference to the BizTalk app
                Microsoft.BizTalk.ExplorerOM.Application app = _btsExp.Applications[btsAppItem.ToString()];
                foreach (ReceivePort rp in app.ReceivePorts)
                {
                    progressBtsAppInfo.PerformStep();

                    TreeNode tn = tnRoot.Nodes.Add(rp.Name);
                    if (rp.InboundTransforms != null)
                    {
                        TreeNode tnMap = tn.Nodes.Add("Transforms");

                        foreach (Transform map in rp.InboundTransforms)
                        {
                            tnMap.Nodes.Add(map.FullName);
                        }
                    }
                    if (rp.ReceiveLocations != null)
                    {
                        TreeNode tnRLs = tn.Nodes.Add("Receive Locations");
                        foreach (ReceiveLocation rl in rp.ReceiveLocations)
                        {
                            TreeNode tnRL = tnRLs.Nodes.Add(rl.Name);
                            tnRL.Nodes.Add(string.Format("{0} ({1})", rl.TransportType.Name, rl.Address));
                            TreeNode tnPL = tnRL.Nodes.Add(rl.ReceivePipeline.FullName);

                            GetPipelineComponentInfo(tnPL, rl.ReceivePipelineData);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get pipeline information for a specific port
        /// </summary>
        /// <param name="node"></param>
        /// <param name="plcInfo"></param>
        private static void GetPipelineComponentInfo(TreeNode node, string plcInfo)
        {
            // Pipeline component info is in XML (binding) format, convert it to readable text
            if (!string.IsNullOrEmpty(plcInfo))
            {
                // Lookup the Stage/Components sections, the components are the Pipeline Components
                XDocument doc = XDocument.Load(new XmlTextReader(new StringReader(plcInfo)));
                if (doc != null)
                {
                    var result = (from plc in doc.Descendants("Component")
                                  select new
                                  {
                                      pcName = plc.Attributes("Name"),
                                      pcProperties = from p in plc.Descendants("Properties").Elements()
                                                     select p
                                  }).ToList();

                    // Now construct a readable text from this pipeline component info
                    foreach (var item in result)
                    {
                        XAttribute[] pcName = item.pcName.ToArray();
                        XElement[] pcProp = item.pcProperties.ToArray();

                        // Add the pipeline component
                        TreeNode tnPLC = node.Nodes.Add(string.Format("{0}", pcName[0].Value));

                        // Add the properties for the component
                        for (int i = 0; i < pcProp.Count(); i++)
                        {
                            tnPLC.Nodes.Add(string.Format("{0} - {1}", pcProp[i].Name, pcProp[i].Value));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retrieve send port information for checked applications
        /// </summary>
        private void GetSendPorts()
        {
            // Clear the checkbox list
            tvSendPorts.Nodes.Clear();

            // Display for checked BizTalk applications
            foreach (var btsAppItem in chkBtsAppList.CheckedItems)
            {
                TreeNode tnRoot = tvSendPorts.Nodes.Add(btsAppItem.ToString());

                // Get a reference to the BizTalk app
                Microsoft.BizTalk.ExplorerOM.Application app = _btsExp.Applications[btsAppItem.ToString()];
                foreach (SendPort sp in app.SendPorts)
                {
                    progressBtsAppInfo.PerformStep();

                    TreeNode tn = tnRoot.Nodes.Add(sp.Name);
                    if(sp.PrimaryTransport != null)
                    {
                        tn.Nodes.Add(string.Format("{0} ({1})", sp.PrimaryTransport.TransportType.Name, sp.PrimaryTransport.Address));
                    }
                    if (sp.SendPipeline != null)
                    {
                        TreeNode tnPLC = tn.Nodes.Add(sp.SendPipeline.FullName);

                        // Add the pipeline component info
                        GetPipelineComponentInfo(tnPLC, sp.SendPipelineData);
                    }

                    if (sp.OutboundTransforms != null)
                    {
                        TreeNode tnMap = tn.Nodes.Add("Transforms");
                        foreach (Transform map in sp.OutboundTransforms)
                        {
                            tnMap.Nodes.Add(map.FullName);
                        }
                    }
                    // Filter is in XML (binding) format, convert it to readable text
                    if (!string.IsNullOrEmpty(sp.Filter))
                    {
                        TreeNode tnSub = tn.Nodes.Add("Subscriptions");
                        tnSub.Nodes.Add(ProcessSubscriptionFilter(sp.Filter, ""));
                    }
                }
            }
        }

        /// <summary>
        /// Convert the filter operator into something human understandable
        /// </summary>
        /// <param name="opId"></param>
        /// <returns></returns>
        private string ConvertOperator(string opId)
        {
            switch (opId)
            {
                case "0": return "==";
                case "1": return "<";
                case "2": return "<=";
                case "3": return ">";
                case "4": return ">=";
                case "5": return "!=";
                case "6": return "Exists";
                default:
                    break;
            }
            return "Unknown operator";
        }

        /// <summary>
        /// Get receive and send port information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAppInfo_Click(object sender, EventArgs e)
        {
            if (chkBtsAppList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select BizTalk applications to retrieve the information from.", "Select applications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            progressBtsAppInfo.Value = 0;

            GetReceivePorts();
            GetSendPorts();

            progressBtsAppInfo.Value = 100;
        }

        /// <summary>
        /// Start searching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Count the nodes to be able to set the progress bar step.
            progressSearch.Value = 0;
            progressSearch.Step = 100 / (tvReceivePorts.Nodes.Count + tvSendPorts.Nodes.Count);

            lbSearchResult.Items.Clear();
            FindNodeInHierarchy(tvReceivePorts.Nodes, tbSearch.Text);
            FindNodeInHierarchy(tvSendPorts.Nodes, tbSearch.Text);

            progressSearch.Value = 100;
        }

        /// <summary>
        /// Find nodes which contain the search terms
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="strSearchValue"></param>
        private void FindNodeInHierarchy(TreeNodeCollection nodes, string strSearchValue)
        {
            for (int iCount = 0; iCount < nodes.Count; iCount++)
            {
                progressSearch.PerformStep();

                if (nodes[iCount].Text.ToUpper().Contains(strSearchValue.ToUpper()))
                {
                    // Get full path without the actual node where the search result is found
                    // If this node is not found, leave it out
                    int nodePathCnt = nodes[iCount].FullPath.LastIndexOf(@"\");
                    if (nodePathCnt < 0)
                    {
                        nodePathCnt = nodes[iCount].FullPath.Length;
                    }
                    lbSearchResult.Items.Add(string.Format("{0} ({1})", nodes[iCount].Text, nodes[iCount].FullPath.Substring(0, nodePathCnt)));
                }
                //Recursively search the text in the child nodes
                FindNodeInHierarchy(nodes[iCount].Nodes, strSearchValue);
            }
        }

        /// <summary>
        /// Check all or uncheck all checkboxes for applications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBtsAppList.Items.Count == 0)
            {
                return;
            }

            bool chkStatus = true;
            if(chkBtsAppList.CheckedItems.Count > 0)
            {
                chkStatus = false;
            }
            for(int i=0;i<chkBtsAppList.Items.Count;i++)
            {
                chkBtsAppList.SetItemChecked(i, chkStatus);
            }
        }

        private void tvReceivePorts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                return;
            }

            // Get the BizTalk application name
            string btsAppName = e.Node.Parent.Text;

            // Try to find the message flow of messages read from this location
            string rpName = e.Node.Text;

            // First read the transforms, the canonical output map is assumingly the format after the transform
            Microsoft.BizTalk.ExplorerOM.Application app = _btsExp.Applications[btsAppName];
            if (app == null)
            {
                return;
            }

            IList rcvMaps = app.ReceivePorts[rpName].InboundTransforms;
            if (rcvMaps != null)
            {
                foreach (Transform map in rcvMaps)
                {
                    string target = string.Format("{0}#{1}", map.TargetSchema.TargetNameSpace, map.TargetSchema.RootName);

                    // Next find the subscribers which have the BTS.ReceivePortName and/or the canonical as input map
                    foreach (var btsAppItem in chkBtsAppList.CheckedItems)
                    {
                        // Get a reference to the BizTalk app
                        Microsoft.BizTalk.ExplorerOM.Application appToSearch = _btsExp.Applications[btsAppItem.ToString()];
                        foreach (SendPort sp in appToSearch.SendPorts)
                        {
                            if (sp.OutboundTransforms != null)
                            {
                                foreach (Transform mapToCheck in sp.OutboundTransforms)
                                {
                                    string source = string.Format("{0}#{1}", mapToCheck.SourceSchema.TargetNameSpace, mapToCheck.SourceSchema.RootName);
                                    if (source == target)
                                    {
                                        // Found a send port with a mapping which has the target schema of the receive port as source schema!
                                        // Potentially this send port will output messages from the receive location!
                                        // Now check the subscription filter, which could exclude the receive location.
                                        string subscriptionFilter = ProcessSubscriptionFilter(sp.Filter, "");

                                        // Check if BTS.ReceivePortName is in there
                                        if(subscriptionFilter.Contains(string.Format("BTS.ReceivePortName == {0}", rpName)))
                                        {
                                            // Hit!
                                            MessageBox.Show("Hit on " + subscriptionFilter);
                                        }

                                        // Check if routing fields are
                                    }
                                }
                            }
                            else
                            {
                                // No outbound maps, just check the filter on the BTS.ReceivePortName
                                string subscriptionFilter = ProcessSubscriptionFilter(sp.Filter, "");
                                // Check if BTS.ReceivePortName is in there
                                if(subscriptionFilter.Contains(string.Format("BTS.ReceivePortName == {0}", rpName)))
                                {
                                    // Hit!
                                    MessageBox.Show("Hit on " + subscriptionFilter);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Read the filter information and convert it to a human readable format
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private string ProcessSubscriptionFilter(string filter, string prefix)
        {
            string resultString = string.Empty;

            // Filter is in XML (binding) format, convert it to readable text
            if (!string.IsNullOrEmpty(filter))
            {
                // Lookup the Group/Statement sections, they are the 'and' filters, 
                // while the individual Group sections are the 'or'
                XDocument doc = XDocument.Load(new XmlTextReader(new StringReader(filter)));
                if (doc != null)
                {
                    var result = (from e in doc.Descendants("Group")
                                  select new
                                  {
                                      filterName = e.Descendants("Statement").Attributes("Property"),
                                      filterOperator = e.Descendants("Statement").Attributes("Operator"),
                                      filterValue = e.Descendants("Statement").Attributes("Value")
                                  }).ToList();

                    // Now construct a readable text from this filter info
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in result)
                    {
                        XAttribute[] fName = item.filterName.ToArray();
                        XAttribute[] fOperator = item.filterOperator.ToArray();
                        XAttribute[] fValue = item.filterValue.ToArray();

                        for (int i = 0; i < fName.Count(); i++)
                        {
                            // Exception for 'Exists', which doesn't have a value
                            if (fName.Length != fValue.Length)
                            {
                                sb.Append(string.Format("{0} {1} {2}", prefix, fName[i].Value, ConvertOperator(fOperator[i].Value)));
                            }
                            else
                            {
                                sb.Append(string.Format("{0} {1} {2} {3}", prefix, fName[i].Value, ConvertOperator(fOperator[i].Value), fValue[i].Value));
                            }

                            // Add the 'and' keyword except for the last entry
                            if(i < (fName.Count()-1))
                            {
                                sb.Append(" And\r\n");
                            }
                        }
                        sb.Append(Environment.NewLine + prefix + "Or\r\n");
                    }
                    resultString = sb.ToString().Remove(sb.ToString().LastIndexOf("Or"), 2);
                }
            }
            return resultString;
        }

        /// <summary>
        /// Read the application information and export it in CSV format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Format will be:
            // <Application Name>
            // <Receive Port Name>
            //                      <Transforms>
            // <Receive Locations>, <Transport Type>, <Address>, <Pipeline Info>
            //
            // <Send Port Name>
            //                      <Transforms>
            //                      <Pipeline Info>

            // Container for the export

            if (chkBtsAppList.CheckedItems.Count == 0)
            {
                MessageBox.Show("No data to export, no BizTalk applications are selected.", "No Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var btsAppItem in chkBtsAppList.CheckedItems)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Export for BizTalk Application {0}", btsAppItem) + Environment.NewLine);

                // Get a reference to the BizTalk app
                Microsoft.BizTalk.ExplorerOM.Application app = _btsExp.Applications[btsAppItem.ToString()];
            
                // First the receive ports
                if (app.ReceivePorts.Count != 0)
                {
                    sb.Append("Receive Ports:" + Environment.NewLine);
                }
                foreach (ReceivePort rp in app.ReceivePorts)
                {
                    sb.Append(string.Format("{0},Map Name:,Source Schema:,Target Schema:", rp.Name) + Environment.NewLine);
                    if (rp.InboundTransforms != null)
                    {
                        foreach (Transform map in rp.InboundTransforms)
                        {
                            sb.Append(string.Format(",{0},{1},{2}", map.FullName, map.SourceSchema.FullName, map.TargetSchema.FullName) + Environment.NewLine);
                        }
                    }
                    if (rp.ReceiveLocations.Count != 0)
                    {
                        sb.Append(string.Format(",Receive Location:,Transport Type:,Address:") + Environment.NewLine);
                        foreach (ReceiveLocation rl in rp.ReceiveLocations)
                        {
                            sb.Append(string.Format(",{0},{1},{2},{3}", rl.Name, rl.TransportType.Name, rl.Address, rl.ReceivePipeline.FullName) + Environment.NewLine);
//                            GetPipelineComponentInfo(tnPL, rl.ReceivePipelineData);
                        }
                    }
                }

                // Now the Send ports
                if (app.SendPorts.Count != 0)
                {
                    sb.Append(Environment.NewLine + "Send Ports:" + Environment.NewLine);
                }
                foreach (SendPort sp in app.SendPorts)
                {
                    sb.Append(sp.Name + Environment.NewLine);

                    if (sp.OutboundTransforms != null)
                    {
                        foreach (Transform map in sp.OutboundTransforms)
                        {
                            sb.Append(string.Format(",{0},{1},{2}", map.FullName, map.SourceSchema.FullName, map.TargetSchema.FullName) + Environment.NewLine);
                        }
                    }
                    sb.Append(ProcessSubscriptionFilter(sp.Filter, ","));
                }
                // Write an export file per application
                // There is deliberately no Excel created to not have a dependency on the Excel library
                string filename = string.Format("BizTalk_Export_{0}_{1}_{2}_{3}.csv", tbSQLServer.Text, btsAppItem, DateTime.Now.ToString("MMddyyyy"), DateTime.Now.ToString("HHmmss"));
                File.WriteAllText(filename, sb.ToString());
            }
            MessageBox.Show("Data is exported to the folder of this executable.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {

                MessageBox.Show(((ListControl)sender).Text, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
