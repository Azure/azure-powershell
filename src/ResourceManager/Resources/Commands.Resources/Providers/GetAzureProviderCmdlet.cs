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

namespace Microsoft.Azure.Commands.Providers
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureProvider", DefaultParameterSetName = GetAzureProviderCmdlet.ListAvailableParameterSet), OutputType(typeof(PSResourceProvider))]
    public class GetAzureProviderCmdlet : ResourcesBaseCmdlet
    {
        /// <summary>
        /// The individual provider parameter set name
        /// </summary>
        public const string IndividualProviderParameterSet = "IndividualProvider";

        /// <summary>
        /// The list parameter set name
        /// </summary>
        public  const string ListAvailableParameterSet = "ListAvailable";

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider namespace.", ParameterSetName = GetAzureProviderCmdlet.IndividualProviderParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if unregistered providers should be included in the listing
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "When specified, lists all the resource providers available, including those not registered with the current subscription.", ParameterSetName = GetAzureProviderCmdlet.ListAvailableParameterSet)]
        public SwitchParameter ListAvailable { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var parameterSetName = this.DetermineParameterSetName();

            switch (parameterSetName)
            {
                case GetAzureProviderCmdlet.IndividualProviderParameterSet:
                    this.WriteObject(this.ResourcesClient.ListPSResourceProviders(providerName: this.ProviderNamespace), enumerateCollection: true);
                    break;

                case GetAzureProviderCmdlet.ListAvailableParameterSet:
                    this.WriteObject(this.ResourcesClient.ListPSResourceProviders(listAvailable: this.ListAvailable), enumerateCollection: true);
                    break;

                default:
                    throw new ApplicationException(string.Format("Unknown parameter set encountered: '{0}'", this.ParameterSetName));
            }
        }
    }
}