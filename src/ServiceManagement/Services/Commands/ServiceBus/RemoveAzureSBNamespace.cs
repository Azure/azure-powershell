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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Creates new service bus namespace.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSBNamespace", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureSBNamespaceCommand : AzureSMCmdlet
    {
        public ServiceBusClientExtensions Client { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace name")]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 3, HelpMessage = "Do not confirm the removal of the namespace")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Removes a service bus namespace.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveServiceBusNamespaceConfirmation, Name),
                string.Format(Resources.RemovingNamespaceMessage),
                Name,
                () =>
                {
                    Client = Client ?? new ServiceBusClientExtensions(Profile);
                    Client.RemoveNamespace(Name);

                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}