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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Account Types for Cognitive Services Account Type(s)
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountType", DefaultParameterSetName = GetAccountTypesParamSetName), OutputType(typeof(string[]), typeof(string))]
    public class GetAzureCognitiveServicesAccountTypeCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string GetAccountTypeWithNameParamSetName = "GetAccountTypeWithName";
        protected const string GetAccountTypesParamSetName = "GetAccountTypes";


        [Parameter(
            ParameterSetName = GetAccountTypeWithNameParamSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Type Name.")]
        [Alias(CognitiveServicesAccountTypeNameAlias, AccountTypeNameAlias, KindNameAlias)]
        public string TypeName { get; set; }

        [Parameter(
            ParameterSetName = GetAccountTypesParamSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case GetAccountTypeWithNameParamSetName:

                        if (GetAccountKinds(this.CognitiveServicesClient).Contains(TypeName))
                        {
                            WriteObject(TypeName);
                        }
                        else
                        {
                            WriteObject(null);
                        }
                        break;
                    case GetAccountTypesParamSetName:
                        var resourceSkuKinds = GetAccountKinds(this.CognitiveServicesClient, this.Location).OrderBy(x => x).ToArray();
                        WriteObject(resourceSkuKinds, true);
                        break;
                }
            });
        }

        /// <summary>
        /// Get Cognitive Services Account Kinds.
        /// </summary>
        /// <param name="client">The ICognitiveServicesManagementClient instance.</param>
        /// <param name="location">The location as filter, set to null to ignore.</param>
        /// <returns>A set of available Kinds.</returns>
        private static HashSet<string> GetAccountKinds(ICognitiveServicesManagementClient client, string location = null)
        {
            var resourceSkuKindList = client.ResourceSkus.List().Where(resourceSku => (string.IsNullOrWhiteSpace(location) || resourceSku.Locations.Any(x => string.Compare(x, location, StringComparison.OrdinalIgnoreCase) == 0))).Select(x => x.Kind).ToList();
            return new HashSet<string>(resourceSkuKindList);
        }
    }
}
