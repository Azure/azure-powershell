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
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Removes new service bus authorization rule.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSBAuthorizationRule"), OutputType(typeof(bool))]
    public class RemoveAzureSBAuthorizationRuleCommand : AzureSMCmdlet
    {
        public const string EntitySASParameterSet = "EntitySAS";

        public const string NamespaceSASParameterSet = "NamespaceSAS";

        public ServiceBusClientExtensions Client { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The rule name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = NamespaceSASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The rule name")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
        ParameterSetName = EntitySASParameterSet, HelpMessage = "The namespace name")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
        ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The namespace name")]
        public string Namespace { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The entity name")]
        public string EntityName { get; set; }

        [Parameter(Position = 3, Mandatory = true, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The entity type")]
        public ServiceBusEntityType EntityType { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceSASParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = EntitySASParameterSet)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Client = Client ?? new ServiceBusClientExtensions(Profile);
            AuthorizationRuleFilterOption options = new AuthorizationRuleFilterOption()
            {
                Namespace = Namespace,
                EntityName = EntityName,
                EntityType = EntityType,
                Name = Name
            };

            Client.RemoveAuthorizationRule(options);

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}