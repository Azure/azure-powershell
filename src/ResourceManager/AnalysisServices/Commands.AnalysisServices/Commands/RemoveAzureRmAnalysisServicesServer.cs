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

using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmAnalysisServicesServer", SupportsShouldProcess=true), 
        OutputType(typeof(bool))]
    [Alias("Remove-AzureAs")]
    public class RemoveAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of server to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which the server exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent)
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingAnalsysisServicesServer, Name),
                    string.Format(Resources.RemoveAnalsysisServicesServer, Name),
                    Name,
                    () => AnalysisServicesClient.DeleteServer(ResourceGroupName, Name));
            }
            else
            {
                AnalysisServicesClient.DeleteServer(ResourceGroupName, Name);
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}