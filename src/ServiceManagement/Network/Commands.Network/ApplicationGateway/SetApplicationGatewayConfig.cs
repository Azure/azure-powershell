// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
//using System.Collections.Generic;
using System.Management.Automation;
//using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using PowerShellAppGwModel = Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
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
