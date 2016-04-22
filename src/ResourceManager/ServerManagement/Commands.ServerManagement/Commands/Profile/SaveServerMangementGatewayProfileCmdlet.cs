using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Management.ServerManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    [Cmdlet(VerbsData.Save, "AzureRmServerManagementGatewayProfile"), OutputType(typeof(System.IO.FileInfo))]
    public class SaveServerManagementGatewayProfileCmdlet : ServerManagementGatewayProfileCmdletBase
    {
        // downloads and saves the gateway profile 

        [Parameter(Mandatory = true, HelpMessage = "The filename to save the gateway profile" )]
        [ValidateNotNullOrEmpty]
        public FileInfo OutputFile { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteVerbose($"Downloading profile for {ResourceGroupName}/{GatewayName}");
            var gatewayProfile = Client.Gateway.GetProfile(ResourceGroupName, GatewayName);
            if (gatewayProfile != null)
            {
                WriteVerbose($"Saving plaintext profile to {OutputFile.FullName}");
                var profileText = JsonConvert.SerializeObject(
                    gatewayProfile,
                    Formatting.None,
                    new JsonSerializerSettings
                    {
                        Converters = new JsonConverter[] { new StringEnumConverter() },
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore,
                        ObjectCreationHandling = ObjectCreationHandling.Reuse,
                    });

                File.WriteAllText(OutputFile.FullName,profileText);
                WriteVerbose($"Successfully saved plaintext profile to {OutputFile.FullName}");
                WriteObject(OutputFile);
            }
        }
    }
}