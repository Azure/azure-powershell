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
// ------------------------------------

using Commands.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.SolutionsReferenceData;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.SolutionsReferenceData
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySolutionsReferenceData", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSolutionReferenceData))]
    public class GetSecuritySolutionReferenceData : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var solution = SecurityCenterClient.SecuritySolutionsReferenceData.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.Value;
                    WriteObject(solution.ConvertToPSType(), enumerateCollection: true);
                    break;

                default:
                    throw new PSInvalidOperationException();
            }
        }

        private object ConvertToPSType()
        {
            throw new NotImplementedException();
        }
    }
}