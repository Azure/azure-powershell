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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Remove, "AzureRouteTable"), OutputType(typeof(bool))]
    public class RemoveAzureRouteTable : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the route table to remove.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified route table is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm Route Table deletion")]
        public SwitchParameter Force { get; set; }


        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveRouteTableWarning, Name),
                Resources.RemoveRouteTableWarning,
                Name,
                () =>
                {
                    Client.DeleteRouteTable(Name);

                    WriteVerboseWithTimestamp(Resources.RemoveRouteTableSucceeded, Name);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
