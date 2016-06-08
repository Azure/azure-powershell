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
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Creates new service bus namespace.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSBNamespace"), OutputType(typeof(ServiceBusNamespace))]
    public class NewAzureSBNamespaceCommand : AzureSMCmdlet
    {
        internal ServiceBusClientExtensions Client { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace name")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace location")]
        public string Location { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create assosciated ACS namespace as well.")]
        public bool? CreateACSNamespace { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Namespace Type")]
        public NamespaceType NamespaceType { get; set; }

        /// <summary>
        /// Creates a new service bus namespace.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Client = Client ?? new ServiceBusClientExtensions(Profile);
            if (CreateACSNamespace.HasValue)
            {
                WriteObject(Client.CreateNamespace(Name, Location, NamespaceType, CreateACSNamespace.Value));
            }
            else
            {
                WriteWarning(Resources.SpecifyCreateACSNamespace);
                WriteObject(Client.CreateNamespace(Name, Location, NamespaceType, true));
            }
        }
    }
}