# BizTalk Port Info Query Tool

Every now and then you start at a new customer to maintain or extend their BizTalk applications or you have to take over the BizTalk applications of someone else.It is not very easy to get acquainted with large numbers of applications and their receive and send ports.

You ask yourself questions like:

- Which ports do uses this specific map?
- Where is a certain pipeline used?
- Which ports subscribe to this fields?

For these situations I created this tool, and wrote a blog post about it:
http://jpsmit.bloggingabout.net/2014/05/19/introducing-the-biztalk-port-info-query-tool

The tool is an executable which requires no installation, so you can run it right away on any environment. When the application is launched, it requires a user and password in order to connect to the management database. It retrieves the BizTalk applications and of selected applications you can get the receive and send port info. Through this information you can search.

I tested it with BizTalk Server 2010 and BizTalk Server 2013, but since it uses the common ExplorerOM assembly it might very well work on older versions of BizTalk as well. Keep in mind that it is compiled against the .NET 4 framework. If you need it to work with .NET 2 then you can use the code to recompile it.

If you need assistance, please contact me.
