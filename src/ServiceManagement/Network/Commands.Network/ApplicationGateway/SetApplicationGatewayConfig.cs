using System;
using System.IO;
using System.Text;
//using System.Collections.Generic;
using System.Management.Automation;
//using System.Runtime.Serialization;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using PowerShellAppGwModel = Microsoft.Azure.Commands.Network.ApplicationGateway.Model;

namespace Microsoft.Azure.Commands.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Set, "AzureApplicationGatewayConfig"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class SetApplicationGatewayConfigCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [Parameter(Mandatory = true, ParameterSetName = "configFile")]
        [Parameter(Mandatory = true, ParameterSetName = "configObject")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway configuration", ParameterSetName = "configObject")]
        [ValidateNotNullOrEmpty]
        public PowerShellAppGwModel.ApplicationGatewayConfiguration Config { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway configuration", ParameterSetName = "configFile")]
        [ValidateNotNullOrEmpty]
        public string ConfigFile { get; set; }
        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.SetAzureApplicationGatewayConfigBeginOperation, CommandRuntime.ToString()));
            if (null == Config)
            {
                Config = PowerShellAppGwModel.ApplicationGatewayConfiguration.Deserialize(FileToString(ConfigFile));
            }

            var responseObject = Client.SetApplicationGatewayConfig(Name, Config);
            
            WriteVerboseWithTimestamp(string.Format(Resources.SetAzureApplicationGatewayConfigCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }

        private string FileToString(string fileName)
        {
            String strContents = "";

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    strContents = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

            return strContents;
        }
    }
}
