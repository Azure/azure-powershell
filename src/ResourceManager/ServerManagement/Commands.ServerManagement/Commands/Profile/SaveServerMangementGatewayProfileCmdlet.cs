// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Profile
{
    using System;
    using System.IO;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    [Cmdlet(VerbsData.Save, "AzureRmServerManagementGatewayProfile"), OutputType(typeof(FileInfo))]
    public class SaveServerManagementGatewayProfileCmdlet : ServerManagementGatewayProfileCmdlet
    {
        // downloads and saves the gateway profile 

        [Parameter(Mandatory = true, HelpMessage = "The filename to save the gateway profile", Position = 2)]
        [ValidateNotNullOrEmpty]
        public FileInfo OutputFile { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteVerbose(string.Format("Downloading profile for {0}/{1}", ResourceGroupName, GatewayName));
            var gatewayProfile = Client.Gateway.GetProfile(ResourceGroupName, GatewayName);
            if (gatewayProfile != null)
            {
                WriteVerbose(string.Format("Saving plaintext profile to {0}", OutputFile.FullName));
                var profileText = JsonConvert.SerializeObject(
                    gatewayProfile,
                    Formatting.None,
                    new JsonSerializerSettings
                    {
                        Converters = new JsonConverter[] {new StringEnumConverter()},
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore,
                        ObjectCreationHandling = ObjectCreationHandling.Reuse
                    });

                File.WriteAllText(OutputFile.FullName, profileText);
                WriteVerbose(string.Format("Successfully saved plaintext profile to {0}", OutputFile.FullName));
                WriteObject(OutputFile);
            }
        }
    }
}