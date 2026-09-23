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
using Microsoft.Azure.Management.CognitiveServices.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get or list Cognitive Services Account RaiBlocklistItem(s).
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountRaiBlocklistItem", DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(RaiBlocklistItem))]
    public class GetAzureCognitiveServicesAccountRaiBlocklistItemCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string DefaultParameterSet = "DefaultParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services RaiBlocklist Name.")]
        [ValidateNotNullOrEmpty]
        public string RaiBlocklistName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case ResourceIdParameterSet:
                        if (!CognitiveServices.ResourceId.TryParse(ResourceId, out CognitiveServices.ResourceId resourceId))
                        {
                            WriteError(new ErrorRecord(new Exception("Failed to parse ResourceId"), string.Empty, ErrorCategory.NotSpecified, null));
                        }
                        ResourceGroupName = resourceId.ResourceGroupName;
                        AccountName = resourceId.GetAccountName();
                        RaiBlocklistName = resourceId.GetAccountSubResourceName();
                        break;
                    case DefaultParameterSet:
                        break;
                }

                var getResponse = ListAll(CognitiveServicesClient.RaiBlocklistItems.List, ResourceGroupName, AccountName, RaiBlocklistName, CognitiveServicesClient.RaiBlocklistItems.ListNext);
                WriteObject(getResponse);
            });
        }
    }
}