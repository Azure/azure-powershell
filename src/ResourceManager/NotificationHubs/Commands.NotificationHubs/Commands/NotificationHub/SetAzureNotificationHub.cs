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


namespace Microsoft.Azure.Commands.NotificationHubs.Commands.NotificationHub
{
    using Microsoft.Azure.Commands.NotificationHubs.Models;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Linq;
    using System.IO;
    using Newtonsoft.Json;

    [Cmdlet(VerbsCommon.Set, "AzureNotificationHub"), OutputType(typeof(NotificationHubAttributes))]
    public class SetAzureNotificationHub : AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           Position = 1,
           HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputFileParameterSetName,
            Position = 2,
            HelpMessage = "File name containing a single NotificationHub definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = NotificationHubParameterSetName,
            Position = 2,
            HelpMessage = "NotificationHub definition.")]
        [ValidateNotNullOrEmpty]
        public NotificationHubAttributes NotificationHubObj { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(NamespaceName))
            {
                NotificationHubAttributes hub = null;
                if (!string.IsNullOrEmpty(InputFile))
                {
                    string fileName = this.TryResolvePath(InputFile);
                    if (!(new FileInfo(fileName)).Exists)
                    {
                        throw new PSArgumentException(string.Format("File {0} does not exist", fileName));
                    }

                    try
                    {
                        hub = JsonConvert.DeserializeObject<NotificationHubAttributes>(File.ReadAllText(fileName));
                    }
                    catch (JsonException)
                    {
                        WriteVerbose("Deserializing the input role definition failed.");
                        throw;
                    }
                }
                else
                {
                    hub = NotificationHubObj;
                }

                var hubAttributes = Client.UpdateNotificationHub(ResourceGroupName, NamespaceName, hub);
                WriteObject(hubAttributes);
            }
        }
    }
}
