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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Creates new service bus authorization rule.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSBAuthorizationRule"), OutputType(typeof(ExtendedAuthorizationRule), typeof(List<ExtendedAuthorizationRule>))]
    public class GetAzureSBAuthorizationRuleCommand : AzureSMCmdlet
    {
        public const string EntitySASParameterSet = "EntitySAS";

        public const string NamespaceSASParameterSet = "NamespaceSAS";

        public ServiceBusClientExtensions Client { get; set; }

        [Parameter(Position = 0, Mandatory = false, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The rule name")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = NamespaceSASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The rule name")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The access permission")]
        [Parameter(Position = 1, Mandatory = false, ParameterSetName = NamespaceSASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The access permission")]
        public Microsoft.ServiceBus.Messaging.AccessRights[] Permission { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
        ParameterSetName = EntitySASParameterSet, HelpMessage = "The namespace name")]
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
        ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The namespace name")]
        public string Namespace { get; set; }

        [Parameter(Position = 3, Mandatory = true, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The entity name")]
        public string EntityName { get; set; }

        [Parameter(Position = 4, Mandatory = true, ParameterSetName = EntitySASParameterSet,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The entity type")]
        public ServiceBusEntityType EntityType { get; set; }

        public override void ExecuteCmdlet()
        {
            Client = Client ?? new ServiceBusClientExtensions(Profile);
            List<ExtendedAuthorizationRule> rules = null;
            List<PSObject> output = new List<PSObject>();
            AuthorizationRuleFilterOption options = new AuthorizationRuleFilterOption()
            {
                EntityName = EntityName,
                EntityType = EntityType,
                Name = Name,
                Namespace = Namespace,
                Permission = Permission != null ? Permission.ToList() : null
            };

            switch (ParameterSetName)
            {
                case NamespaceSASParameterSet:
                    rules = Client.GetAuthorizationRule(options);
                    rules.ForEach(r => output.Add(ServiceBusPowerShellUtility.GetNamespacePSObject(r)));
                    break;

                case EntitySASParameterSet:
                    rules = Client.GetAuthorizationRule(options);
                    rules.ForEach(r => output.Add(ServiceBusPowerShellUtility.GetEntityPSObject(r)));
                    break;

                default:
                    throw new ArgumentException(string.Format(Resources.InvalidParameterSetName, ParameterSetName));
            }

            if (output.Count == 1)
            {
                WriteObject(output[0]);
            }
            else
            {
                WriteObject(output, true);
            }
        }
    }
}