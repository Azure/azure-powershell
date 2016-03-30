using System.Collections;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions.Diagnostics
{
    public class DiagnosticsHelperTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetEventHubFromJsonConfig()
        {
            var table = new Hashtable();
            DiagnosticsHelper.AddEventHubPrivateConfig(table, @"Resources\Diagnostics\config.json");

            var eventHubConfig = table["EventHub"] as Hashtable;
            Assert.NotNull(eventHubConfig);
            Assert.Equal(eventHubConfig["Url"], "Url");
            Assert.Equal(eventHubConfig["SharedAccessKeyName"], "sasKeyName");
            Assert.Equal(eventHubConfig["SharedAccessKey"], "sasKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetEventHubFromXmlConfig()
        {
            var table = new Hashtable();
            DiagnosticsHelper.AddEventHubPrivateConfig(table, @"Resources\Diagnostics\diagnostics.wadcfgx");

            var eventHubConfig = table["EventHub"] as Hashtable;
            Assert.NotNull(eventHubConfig);
            Assert.Equal(eventHubConfig["Url"], "Url");
            Assert.Equal(eventHubConfig["SharedAccessKeyName"], "sasKeyName");
            Assert.Equal(eventHubConfig["SharedAccessKey"], "sasKey");
        }
    }
}
