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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Set, "AzureRmAnalysisServicesServer", SupportsShouldProcess = true), OutputType(typeof(AnalysisServicesServer))]
    [Alias("Set-AzureAs")]
    public class SetAzureAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the server.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the server.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "Name of the Sku used to create the server"
            )]
        [ValidateNotNullOrEmpty]
        [ValidateSet("S1", "S2", "S4")]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this server")]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A comma separated server names to set as administrators on the server")]
        [ValidateNotNull]
        public string Administrators { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.ResumeAnalysisServicesServer, Name),
                string.Format(Resources.ResumingAnalysisServicesServer, Name),
                Name,
                () =>
                {
                    var currentServer = AnalysisServicesClient.GetServer(ResourceGroupName, Name);
                    var location = currentServer.Location;

                    if (Tags == null && currentServer.Tags != null)
                    {
                        Tags = TagsConversionHelper.CreateTagHashtable(currentServer.Tags);
                    }

                    WriteObject(AnalysisServicesClient.CreateOrUpdateServer(ResourceGroupName, Name, location, Sku, Tags, Administrators));
                });
        }
    }
}