﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.IotSecuritySolutions
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecuritySolutionUserDefinedResourcesObject", DefaultParameterSetName = ParameterSetNames.GeneralScope), OutputType(typeof(PSUserDefinedResources))]
    public class NewIotSecuritySolutionUserDefinedResourcesObject : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.Query)]
        public string Query { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.QuerySubscriptions)]
        public string[] QuerySubscriptionList { get; set; }

        public override void ExecuteCmdlet()
        {
            PSUserDefinedResources userDefinedRes = new PSUserDefinedResources
            {
                Query = Query,
                QuerySubscriptions = QuerySubscriptionList
            };

            WriteObject(userDefinedRes, enumerateCollection: false);
        }
    }
}
