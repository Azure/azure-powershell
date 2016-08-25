using System.Collections;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions.Diagnostics
{
    public class DiagnosticsHelperTest
    {
        private static string TrimEndLineSpace(string init) {
            return init.Replace(System.Environment.NewLine, "").Replace(" ", "");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPurePublicConfig()
        {
            // Test the basic case that the storage account info can be correctly set if user only provide a pure public config file.
            var expected = @"{
""storageAccountName"": ""name"",
""storageAccountKey"": ""key"",
""storageAccountEndPoint"": ""https://core.windows.net""
}";
            expected = TrimEndLineSpace(expected);

            // Test json config
            var table = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(@"Resources\Diagnostics\PurePublic.json", "name", "key", "https://core.windows.net");
            var config = JsonConvert.SerializeObject(table);
            Assert.Equal(expected, config);

            // Test xml config
            table = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(@"Resources\Diagnostics\PurePublic.xml", "name", "key", "https://core.windows.net");
            config = JsonConvert.SerializeObject(table);
            Assert.Equal(expected, config);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPlainTextJsonConfig()
        {
            // Test for the json config, we will take the whole private config as plain text and only replace the storage account info.
            var expected = @"{
""EventHub"": {
    ""Url"": ""Url"",
    ""SharedAccessKeyName"": ""sasKeyName"",
    ""SharedAccessKey"": ""sasKey""
},
""storageAccountEndPoint"": ""https://core.windows.net"",
""storageAccountName"": ""name"",
""storageAccountKey"": ""key"",
""PlainTextItem"": {
    ""Item"":  ""Value""
}
}";
            expected = TrimEndLineSpace(expected);

            // Test json config
            var table = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(@"Resources\Diagnostics\PlainText.json", "name", "key", "https://core.windows.net");
            var config = JsonConvert.SerializeObject(table);
            Assert.Equal(expected, config);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPlainTextXmlConfig()
        {
            // Test for the xml config, we only take those elements they are recognized by the schema.
            var expected = @"{
""storageAccountKey"": ""key"",
""storageAccountName"": ""name"",
""storageAccountEndPoint"": ""https://core.windows.net"",
""EventHub"": {
    ""Url"": ""Url"",
    ""SharedAccessKeyName"": ""sasKeyName"",
    ""SharedAccessKey"": ""sasKey""
}
}";
            expected = TrimEndLineSpace(expected);

            // Test json config
            var table = DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(@"Resources\Diagnostics\PlainText.xml", "name", "key", "https://core.windows.net");
            var config = JsonConvert.SerializeObject(table);
            Assert.Equal(expected, config);
        }
    }
}
