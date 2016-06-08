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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Creates new service bus authorization rule.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSBAuthorizationRule"), OutputType(typeof(ExtendedAuthorizationRule))]
    public class NewAzureSBAuthorizationRuleCommand : AzureSMCmdlet
    {
        public const string EntitySASParameterSet = "EntitySAS";

        public const string NamespaceSASParameterSet = "NamespaceSAS";

        public ServiceBusClientExtensions Client { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = EntitySASParameterSet, HelpMessage = "The rule name")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The rule name")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ParameterSetName = EntitySASParameterSet, HelpMessage = "The access permission")]
        [Parameter(Position = 1, Mandatory = false, ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The access permission")]
        public Microsoft.ServiceBus.Messaging.AccessRights[] Permission { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
        ParameterSetName = EntitySASParameterSet, HelpMessage = "The namespace name")]
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
        ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The namespace name")]
        public string Namespace { get; set; }

        [Parameter(Position = 3, Mandatory = true, ParameterSetName = EntitySASParameterSet, HelpMessage = "The entity name")]
        public string EntityName { get; set; }

        [Parameter(Position = 4, Mandatory = true, ParameterSetName = EntitySASParameterSet, HelpMessage = "The entity type")]
        public ServiceBusEntityType EntityType { get; set; }

        [Parameter(Position = 5, Mandatory = false, ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The primary key")]
        [Parameter(Position = 5, Mandatory = false, ParameterSetName = EntitySASParameterSet, HelpMessage = "The primary key")]
        public string PrimaryKey { get; set; }

        [Parameter(Position = 6, Mandatory = false, ParameterSetName = NamespaceSASParameterSet, HelpMessage = "The secondary key")]
        [Parameter(Position = 6, Mandatory = false, ParameterSetName = EntitySASParameterSet, HelpMessage = "The secondary key")]
        public string SecondaryKey { get; set; }

        public override void ExecuteCmdlet()
        {
            Client = Client ?? new ServiceBusClientExtensions(Profile);
            ExtendedAuthorizationRule rule = null;
            PSObject output = null;

            switch (ParameterSetName)
            {
                case NamespaceSASParameterSet:
                    rule = Client.CreateSharedAccessAuthorization(Namespace, Name, PrimaryKey, SecondaryKey, Permission);
                    output = ServiceBusPowerShellUtility.GetNamespacePSObject(rule);
                    break;

                case EntitySASParameterSet:
                    rule = Client.CreateSharedAccessAuthorization(
                        Namespace,
                        EntityName,
                        EntityType,
                        Name,
                        PrimaryKey,
                        SecondaryKey,
                        Permission);
                    output = ServiceBusPowerShellUtility.GetEntityPSObject(rule);
                    break;

                default:
                    throw new ArgumentException(string.Format(Resources.InvalidParameterSetName, ParameterSetName));
            }

            WriteObject(output);
        }
    }
}