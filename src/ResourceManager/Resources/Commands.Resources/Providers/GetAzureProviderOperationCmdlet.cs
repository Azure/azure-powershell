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
    using Microsoft.Azure.Commands.Resources.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmProviderOperation"), OutputType(typeof(PSResourceProviderOperation))]
    public class GetAzureProviderOperationCommand : ResourcesBaseCmdlet
    {
        private const string WildCardCharacter = "*";
        private static readonly char Separator = '/';

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false, ValueFromPipeline = true, HelpMessage = "The action string.")]
        [ValidateNotNullOrEmpty]
        public string OperationSearchString { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            // remove leading and trailing whitespaces
            this.OperationSearchString = this.OperationSearchString.Trim();

            ValidateActionSearchString(this.OperationSearchString);

            List<PSResourceProviderOperation> operationsToDisplay;

            if (this.OperationSearchString.Contains(WildCardCharacter))
            {
                operationsToDisplay = this.ProcessProviderOperationsWithWildCard(OperationSearchString);
            }
            else
            {
                operationsToDisplay = this.ProcessProviderOperationsWithoutWildCard(OperationSearchString);
            }

            this.WriteObject(operationsToDisplay, enumerateCollection: true);
        }

        private static void ValidateActionSearchString(string actionSearchString)
        {
            if (actionSearchString.Contains("?"))
            {
                throw new ArgumentException(ProjectResources.ProviderOperationUnsupportedWildcard);
            }

            string[] parts = actionSearchString.Split(Separator);
            if (parts.Any(p => p.Contains(WildCardCharacter) && p.Length != 1))
            {
                throw new ArgumentException(ProjectResources.OperationSearchStringInvalidWildcard);
            }

            if (parts.Length == 1 && parts[0] != WildCardCharacter)
            {
                throw new ArgumentException(string.Format(ProjectResources.OperationSearchStringInvalidProviderName, parts[0]));
            }
        }

        /// <summary>
        /// Get a list of Provider operations in the case that the Actionstring input contains a wildcard
        /// </summary>
        private List<PSResourceProviderOperation> ProcessProviderOperationsWithWildCard(string actionSearchString)
        {
            // Filter the list of all operation names to what matches the wildcard
            WildcardPattern wildcard = new WildcardPattern(actionSearchString, WildcardOptions.IgnoreCase | WildcardOptions.Compiled);

            List<ProviderOperationsMetadata> providers = new List<ProviderOperationsMetadata>();
            string provider = this.OperationSearchString.Split(Separator).First();
            if (provider.Equals(WildCardCharacter))
            {
                // 'Get-AzureRmProviderOperation *' or 'Get-AzureRmProviderOperation */virtualmachines/*'
                // get operations for all providers
                providers.AddRange(this.ResourcesClient.ListProviderOperationsMetadata());
            }
            else
            {
                // 'Get-AzureRmProviderOperation Microsoft.Compute/virtualmachines/*' or 'Get-AzureRmProviderOperation Microsoft.Sql/*'
                providers.Add(this.ResourcesClient.GetProviderOperationsMetadata(provider));
            }

            return providers.SelectMany(p => GetPSOperationsFromProviderOperationsMetadata(p)).Where(operation => wildcard.IsMatch(operation.Operation)).ToList();
        }

        /// <summary>
        /// Gets a list of Provider operations in the case that the Actionstring input does not contain a wildcard
        /// </summary>
        private List<PSResourceProviderOperation> ProcessProviderOperationsWithoutWildCard(string operationString)
        {
            string providerFullName = operationString.Split(Separator).First();

            ProviderOperationsMetadata providerOperations = this.ResourcesClient.GetProviderOperationsMetadata(providerFullName);
            IEnumerable<PSResourceProviderOperation> flattenedProviderOperations = GetAzureProviderOperationCommand.GetPSOperationsFromProviderOperationsMetadata(providerOperations);
            return flattenedProviderOperations.Where(op => string.Equals(op.Operation, operationString, StringComparison.OrdinalIgnoreCase)).ToList();
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
            int index = nonWildCardPrefix.IndexOf(Separator.ToString(), 0);
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