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

namespace Microsoft.Azure.Commands.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;
    using Microsoft.Azure.Management.Resources.Models;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureProviderOperation"), OutputType(typeof(PSResourceProviderOperation))]
    public class GetAzureProviderOperationCommand : ResourcesBaseCmdlet
    {
        private const string WildCardCharacter = "*";

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false, ValueFromPipeline = true, HelpMessage = "The action string.")]
        [ValidateNotNullOrEmpty]
        public string ActionString { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // remove leading and trailing whitespaces
            this.ActionString = this.ActionString.Trim();

            List<PSResourceProviderOperation> operationsToDisplay;

            if (this.ActionString.Contains(WildCardCharacter))
            {
                operationsToDisplay = this.ProcessProviderOperationsWithWildCard(ActionString);
            }
            else
            {
                operationsToDisplay = this.ProcessProviderOperationsWithoutWildCard(ActionString);
            }

            this.WriteObject(operationsToDisplay, enumerateCollection: true);
        }

        /// <summary>
        /// Get a list of Provider operations in the case that the Actionstring input contains a wildcard
        /// </summary>
        private List<PSResourceProviderOperation> ProcessProviderOperationsWithWildCard(string actionString)
        {
            // Filter the list of all operation names to what matches the wildcard
            WildcardPattern wildcard = new WildcardPattern(actionString, WildcardOptions.IgnoreCase | WildcardOptions.Compiled);

            List<ProviderOperationsMetadata> providers = new List<ProviderOperationsMetadata>();

            string nonWildCardPrefix = GetAzureProviderOperationCommand.GetNonWildcardPrefix(actionString);
            if (string.IsNullOrWhiteSpace(nonWildCardPrefix))
            {
                // 'Get-AzureProviderOperation *' or 'Get-AzureProviderOperation */virtualmachines/*'
                // get operations for all providers
                providers.AddRange(this.ResourcesClient.ListProviderOperationsMetadata());
            }
            else
            {
                // Some string exists before the wild card character - potentially the full name of the provider.
                string providerFullName = GetAzureProviderOperationCommand.GetResourceProviderFullName(nonWildCardPrefix);
                if (!string.IsNullOrWhiteSpace(providerFullName))
                {
                    // we have the full name of the provider. 'Get-AzureProviderOperation Microsoft.Sql/servers/*'
                    // only query for that provider
                    providers.Add(this.ResourcesClient.GetProviderOperationsMetadata(providerFullName));
                }
                else
                {
                    // We have only a partial name of the provider, say Microsoft.*/* or Microsoft.*/*/read.
                    // query for all providers and then do prefix match on the operations
                    providers.AddRange(this.ResourcesClient.ListProviderOperationsMetadata());
                }
            }

            return providers.SelectMany(p => GetPSOperationsFromProviderOperationsMetadata(p)).Where(operation => wildcard.IsMatch(operation.Operation)).ToList();            
        }

        /// <summary>
        /// Gets a list of Provider operations in the case that the Actionstring input does not contain a wildcard
        /// </summary>
        private List<PSResourceProviderOperation> ProcessProviderOperationsWithoutWildCard(string actionString)
        {
            List<PSResourceProviderOperation> operationsToDisplay = new List<PSResourceProviderOperation>();
            string providerFullName = GetAzureProviderOperationCommand.GetResourceProviderFullName(actionString);
            if (!string.IsNullOrWhiteSpace(providerFullName))
            {
                // We have the full name of the provider. get operations metadata for this provider
                ProviderOperationsMetadata providerOperations = this.ResourcesClient.GetProviderOperationsMetadata(providerFullName);
                IEnumerable<PSResourceProviderOperation> flattenedProviderOperations = GetAzureProviderOperationCommand.GetPSOperationsFromProviderOperationsMetadata(providerOperations);
                operationsToDisplay.AddRange(flattenedProviderOperations.Where(op => string.Equals(op.Operation, actionString, StringComparison.OrdinalIgnoreCase)));
            }

            return operationsToDisplay;
        }

        private static IEnumerable<PSResourceProviderOperation> GetPSOperationsFromProviderOperationsMetadata(ProviderOperationsMetadata providerOperationsMetadata)
        {
            IEnumerable<PSResourceProviderOperation> operations = providerOperationsMetadata.Operations.Where(op => GetAzureProviderOperationCommand.IsUserOperation(op))
                        .Select(op => ToPSResourceProviderOperation(op, providerOperationsMetadata.DisplayName));
            if (providerOperationsMetadata.ResourceTypes != null)
            {
                operations = operations.Concat(providerOperationsMetadata.ResourceTypes.SelectMany(rt => rt.Operations.Where(op => GetAzureProviderOperationCommand.IsUserOperation(op))
                    .Select(op => ToPSResourceProviderOperation(op, providerOperationsMetadata.DisplayName, rt.DisplayName))));
            }

            return operations;
        }

        private static bool IsUserOperation(Operation operation)
        {
            return operation.Origin == null || operation.Origin.Contains("user");
        }

        private static PSResourceProviderOperation ToPSResourceProviderOperation(Operation operation, string provider, string resource = null)
        {
            PSResourceProviderOperation psOperation = new PSResourceProviderOperation();
            psOperation.Operation = operation.Name;
            psOperation.OperationName = operation.DisplayName;
            psOperation.Description = operation.Description;
            psOperation.ProviderNamespace = provider;
            psOperation.ResourceName = resource ?? string.Empty;

            return psOperation;
        }

        /// <summary>
        /// Extracts the resource provider's full name - i.e portion of the non-wildcard prefix before the '/'
        /// Returns null if the nonWildCardPrefix does not contain a '/'
        /// </summary>
        private static string GetResourceProviderFullName(string nonWildCardPrefix)
        {
            int index = nonWildCardPrefix.IndexOf("/", 0);
            return index > 0 ? nonWildCardPrefix.Substring(0, index) : string.Empty;
        }

        /// <summary>
        /// Extracts the portion of the actionstring before the first wildcard character (*)
        /// </summary>
        private static string GetNonWildcardPrefix(string actionString)
        {
            int index = actionString.IndexOf(WildCardCharacter);
            return index >= 0 ? actionString.Substring(0, index) : actionString;
        }
    }
}