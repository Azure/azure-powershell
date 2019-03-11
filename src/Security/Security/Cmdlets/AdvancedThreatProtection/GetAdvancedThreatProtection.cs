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
using System.Management.Automation;
using Microsoft.Azure.Commands.Security.Models.AdvancedThreatProtection;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AdvancedThreatProtection
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAdvancedThreatProtection", SupportsShouldProcess = false, DefaultParameterSetName = ParameterSetNames.ResourceId), OutputType(typeof(PSAdvancedThreatProtection))]
    public class GetAdvancedThreatProtection : SecurityCenterCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        public override void ExecuteCmdlet()
        {
            var result = SecurityCenterClient.AdvancedThreatProtection.GetWithHttpMessagesAsync(ResourceId).GetAwaiter().GetResult().Body;
            WriteObject(result, enumerateCollection: true);
        }
    }
}
