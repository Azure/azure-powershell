using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Websites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Moq;
using Xunit;
using Microsoft.Web.Deployment;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    public class PublishAzureWebsiteProjectTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PublishFromPackageWithoutSetParameters()
        {
            const string websiteName = "test-site";
            const string package = "test-package";
            string slot = null;
            var connectionStrings = new Hashtable();
            connectionStrings["DefaultConnection"] = "test-connection-string";

            var publishProfile = new WebSiteGetPublishProfileResponse.PublishProfile
            {
                UserName = "test-user-name",
                UserPassword = "test-password",
                PublishUrl = "test-publish-url"
            };

            var published = false;

            var clientMock = new Mock<IWebsitesClient>();

            clientMock.Setup(c => c.GetWebDeployPublishProfile(websiteName, slot)).Returns(publishProfile);
            clientMock.Setup(c => c.PublishWebProject(websiteName, slot, package, null, connectionStrings, false, false))
                .Callback((string n, string s, string p, string spf, Hashtable cs, bool skipAppData, bool doNotDelete) =>
                {
                    Assert.Equal(websiteName, n);
                    Assert.Equal(slot, s);
                    Assert.Equal(package, p);
                    Assert.Equal(connectionStrings, cs);
                    Assert.False(skipAppData);
                    Assert.False(doNotDelete);
                    published = true;
                });

            var powerShellMock = new Mock<ICommandRuntime>();

            var command = new PublishAzureWebsiteProject
            {
                CommandRuntime = powerShellMock.Object,
                Name = websiteName,
                Package = package,
                ConnectionString = connectionStrings,
                WebsitesClient = clientMock.Object,
                SetParametersFile = null
            };

            command.ExecuteCmdlet();

            powerShellMock.Verify(f => f.WriteVerbose(string.Format("[Complete] Publishing package {0}", package)), Times.Once());
            Assert.True(published);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PublishFromPackage()
        {
            var websiteName = "test-site";
            string slot = null;
            var package = "test-package";
            var connectionStrings = new Hashtable();
            connectionStrings["DefaultConnection"] = "test-connection-string";
            string setParametersFile = "testfile.xml";

            var publishProfile = new WebSiteGetPublishProfileResponse.PublishProfile()
            {
                UserName = "test-user-name",
                UserPassword = "test-password",
                PublishUrl = "test-publlish-url"
            };

            var published = false;

            Mock<IWebsitesClient> clientMock = new Mock<IWebsitesClient>();

            clientMock.Setup(c => c.GetWebDeployPublishProfile(websiteName, slot)).Returns(publishProfile);
            clientMock.Setup(c => c.PublishWebProject(websiteName, slot, package, setParametersFile, connectionStrings, false, false))
                .Callback((string n, string s, string p, string spf, Hashtable cs, bool skipAppData, bool doNotDelete) =>
                {
                    Assert.Equal(websiteName, n);
                    Assert.Equal(slot, s);
                    Assert.Equal(package, p);
                    Assert.Equal(setParametersFile, spf);
                    Assert.Equal(connectionStrings, cs);
                    Assert.False(skipAppData);
                    Assert.False(doNotDelete);
                    published = true;
                });

            Mock<ICommandRuntime> powerShellMock = new Mock<ICommandRuntime>();

            var command = new PublishAzureWebsiteProject()
            {
                CommandRuntime = powerShellMock.Object,
                Name = websiteName,
                Package = package,
                ConnectionString = connectionStrings,
                WebsitesClient = clientMock.Object,
                SetParametersFile = setParametersFile
            };

            command.ExecuteCmdlet();

            powerShellMock.Verify(f => f.WriteVerbose(string.Format("[Complete] Publishing package {0}", package)), Times.Once());
            Assert.True(published);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PublishFromProjectFile()
        {
            var websiteName = "test-site";
            string slot = null;
            var projectFile = string.Format(@"{0}\Resources\MyWebApplication\WebApplication4.csproj", AppDomain.CurrentDomain.BaseDirectory);
            var configuration = "Debug";
            var logFile = string.Format(@"{0}\build.log", AppDomain.CurrentDomain.BaseDirectory);
            var connectionStrings = new Hashtable();
            connectionStrings["DefaultConnection"] = "test-connection-string";
            string setParametersFile = "testfile.xml";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string originalDirectory = AppDomain.CurrentDomain.BaseDirectory;
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
            clientMock.Setup(c => c.PublishWebProject(websiteName, slot, package, setParametersFile, connectionStrings, false, false))
                .Callback((string n, string s, string p, string spf, Hashtable cs, bool skipAppData, bool doNotDelete) =>
                {
                    Assert.Equal(websiteName, n);
                    Assert.Equal(slot, s);
                    Assert.Equal(package, p);
                    Assert.Equal(setParametersFile, spf);
                    Assert.Equal(connectionStrings, cs);
                    Assert.False(skipAppData);
                    Assert.False(doNotDelete);
                    published = true;
                });

            Mock<ICommandRuntime> powerShellMock = new Mock<ICommandRuntime>();
            TestMockSupport.TestExecutionFolder = AppDomain.CurrentDomain.BaseDirectory;
            var command = new PublishAzureWebsiteProject()
            {
                CommandRuntime = powerShellMock.Object,
                WebsitesClient = clientMock.Object,
                Name = websiteName,
                ProjectFile = projectFile,
                Configuration = configuration,
                ConnectionString = connectionStrings,
                SetParametersFile = setParametersFile
            };

            command.ExecuteCmdlet();

            powerShellMock.Verify(f => f.WriteVerbose(string.Format("[Complete] Publishing package {0}", package)), Times.Once());
            Assert.True(published);
        }
    }
}
