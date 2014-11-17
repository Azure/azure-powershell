using System.Collections;
using System.IO;
using System.Management.Automation;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Websites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class PublishAzureWebsiteProjectTests : WebsitesTestBase
    {
        [Fact]
        public void PublishFromPackage()
        {
            var websiteName = "test-site";
            string slot = null;
            var package = "test-package";
            var connectionStrings = new Hashtable();
            connectionStrings["DefaultConnection"] = "test-connection-string";

            var publishProfile = new WebSiteGetPublishProfileResponse.PublishProfile()
            {
                UserName = "test-user-name",
                UserPassword = "test-password",
                PublishUrl = "test-publlish-url"
            };

            var published = false;

            Mock<IWebsitesClient> clientMock = new Mock<IWebsitesClient>();

            clientMock.Setup(c => c.GetWebDeployPublishProfile(websiteName, slot)).Returns(publishProfile);
            clientMock.Setup(c => c.PublishWebProject(websiteName, slot, package, connectionStrings))
                .Callback((string n, string s, string p, Hashtable cs) =>
                {
                    Assert.Equal(websiteName, n);
                    Assert.Equal(slot, s);
                    Assert.Equal(package, p);
                    Assert.Equal(connectionStrings, cs);
                    published = true;
                });

            Mock<ICommandRuntime> powerShellMock = new Mock<ICommandRuntime>();

            var command = new PublishAzureWebsiteProject()
            {
                CommandRuntime = powerShellMock.Object,
                Name = websiteName,
                Package = package,
                ConnectionString = connectionStrings,
                WebsitesClient = clientMock.Object
            };

            command.ExecuteCmdlet();

            powerShellMock.Verify(f => f.WriteVerbose(string.Format("[Complete] Publishing package {0}", package)), Times.Once());
            Assert.True(published);
        }

        [Fact]
        public void PublishFromProjectFile()
        {
            var websiteName = "test-site";
            string slot = null;
            var projectFile = string.Format(@"{0}\Resources\MyWebApplication\WebApplication4.csproj", Directory.GetCurrentDirectory());
            var configuration = "Debug";
            var logFile = string.Format(@"{0}\build.log", Directory.GetCurrentDirectory());
            var connectionStrings = new Hashtable();
            connectionStrings["DefaultConnection"] = "test-connection-string";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string originalDirectory = Directory.GetCurrentDirectory();
            }

            var publishProfile = new WebSiteGetPublishProfileResponse.PublishProfile()
            {
                UserName = "test-user-name",
                UserPassword = "test-password",
                PublishUrl = "test-publlish-url"
            };
            var package = "test-package.zip";

            var published = false;

            Mock<IWebsitesClient> clientMock = new Mock<IWebsitesClient>();

            clientMock.Setup(c => c.GetWebDeployPublishProfile(websiteName, slot)).Returns(publishProfile);
            clientMock.Setup(c => c.BuildWebProject(projectFile, configuration, logFile)).Returns(package);
            clientMock.Setup(c => c.PublishWebProject(websiteName, slot, package, connectionStrings))
                .Callback((string n, string s, string p, Hashtable cs) =>
                {
                    Assert.Equal(websiteName, n);
                    Assert.Equal(slot, s);
                    Assert.Equal(package, p);
                    Assert.Equal(connectionStrings, cs);
                    published = true;
                });

            Mock<ICommandRuntime> powerShellMock = new Mock<ICommandRuntime>();

            var command = new PublishAzureWebsiteProject()
            {
                CommandRuntime = powerShellMock.Object,
                WebsitesClient = clientMock.Object,
                Name = websiteName,
                ProjectFile = projectFile,
                Configuration = configuration,
                ConnectionString = connectionStrings
            };

            command.ExecuteCmdlet();

            powerShellMock.Verify(f => f.WriteVerbose(string.Format("[Complete] Publishing package {0}", package)), Times.Once());
            Assert.True(published);
        }
    }
}
