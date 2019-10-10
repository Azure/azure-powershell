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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using SdkSku = Microsoft.Azure.Management.Cdn.Models.Sku;
using SdkSkuName = Microsoft.Azure.Management.Cdn.Models.SkuName;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the New-AzCdnWafManagedRuleOverride cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafMatchCondition", SupportsShouldProcess = false), OutputType(typeof(PSMatchCondition))]
    public class NewAzCdnWafMatchCondition : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the custom rule.")]
        [ValidateNotNullOrEmpty]
        public PSMatchVariable MatchVariable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Match a specific key for QueryString, RequestUri, RequestHeaders or RequestBody.")]
        public string Selector { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The comparison operator to use for matching.")]
        [ValidateNotNullOrEmpty]
        public PSOperator Operator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Make the rule match when the condition is false instead of true.")]
        public SwitchParameter NegateCondition { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The value or values to match against.")]
        [ValidateNotNullOrEmpty]
        public string[] MatchValue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The transform to apply before matching.")]
        public PSTransform[] Transform { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new PSMatchCondition
            {
                MatchVariable = MatchVariable,
                Selector = Selector,
                Operator = Operator,
                NegateCondition = NegateCondition.ToBool(),
                MatchValue = MatchValue,
                Transform = Transform,
            });
        }
    }
}
