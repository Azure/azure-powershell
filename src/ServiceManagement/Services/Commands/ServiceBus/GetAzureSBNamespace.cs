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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Lists all service bus namespaces associated with a subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSBNamespace"), OutputType(typeof(List<ExtendedServiceBusNamespace>), typeof(ExtendedServiceBusNamespace))]
    public class GetAzureSBNamespaceCommand : AzureSMCmdlet
    {
        internal ServiceBusClientExtensions Client { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace name")]
        public string Name { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Client = Client ?? new ServiceBusClientExtensions(Profile);

            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(Client.GetNamespace(), true);
            }
            else
            {
                WriteObject(Client.GetNamespace(Name));
            }
        }
    }
}