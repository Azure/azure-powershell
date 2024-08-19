using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Xunit;
using Microsoft.Azure.Commands.NetAppFiles.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.UnitTest
{
    public class AccountExtensionTest
    {
        [Fact]
        public void AccountShouldNotError()
        {
            string jsonAccountBody = @"{
  ""id"": ""/subscriptions/xxxxx-xxxx-xxxx-xxxx-xxxxx/resourceGroups/someGroup/providers/Microsoft.NetApp/netAppAccounts/someAccount"",
  ""name"": ""KTBNetAppProduction"",
  ""type"": ""Microsoft.NetApp/netAppAccounts"",
  ""etag"": ""W/\""datetime'2023-05-30T18%3A08%3A22.2706822Z'\"""",
  ""location"": ""eastus2"",
  ""tags"": {
    ""App"": ""Azure NetApp Files"",
    ""Env"": ""PRD"",
    ""FunctionalArea"": ""Datacenter"",
    ""Region"": ""AMER"",
    ""SubWorkstream"": ""OPS"",
    ""Workstream"": ""INF""
  },
  ""properties"": {
    ""provisioningState"": ""Succeeded"",
    ""activeDirectories"": [
      {
        ""backupOperators"": [
          ""svc-ANF""
        ],
        ""activeDirectoryId"": ""*********-****-****-****-************"",
        ""username"": ""svc-ANF"",
        ""password"": ""****************"",
        ""domain"": ""fk.fakebrand.com"",
        ""dns"": ""10.16.0.11,10.16.0.12"",
        ""status"": ""InUse"",
        ""smbServerName"": ""smbServer"",
        ""organizationalUnit"": ""OU=AzureNetAppFiles,OU=Servers,OU=fk""
      }
    ],
    ""encryption"": {
      ""keySource"": ""Microsoft.NetApp""
    }
  }
}";


            Newtonsoft.Json.JsonSerializerSettings DeserializationSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new Microsoft.Rest.Serialization.ReadOnlyJsonContractResolver(),
                Converters = new System.Collections.Generic.List<Newtonsoft.Json.JsonConverter>
                    {
                        new Microsoft.Rest.Serialization.Iso8601TimeSpanConverter()
                    }
            };

            DeserializationSettings.Converters.Add(new Microsoft.Rest.Serialization.TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new Microsoft.Rest.Azure.CloudErrorJsonConverter());

            NetAppAccount netAppAccount = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<NetAppAccount>(jsonAccountBody, DeserializationSettings);
            PSNetAppFilesAccount pSNetAppFilesAccount = netAppAccount.ConvertToPs();                        
            Assert.NotNull(pSNetAppFilesAccount);
        }
    }
}
