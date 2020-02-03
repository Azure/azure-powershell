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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using System;
using System.Net;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall;

namespace Microsoft.Azure.Commands.Cdn.WebApplicationFirewall
{
    /// <summary>
    /// Defines the Get-AzCdnWafPolicy cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnWafManagedRuleSet"), OutputType(typeof(PSManagedRuleSet))]
    public class GetAzCdnWafManagedRuleSet : AzureCdnCmdletBase
    {
        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure CDN WAF Managed Rule Set name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ManagedRuleSetName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ManagedRuleSetName != null)
            {
                // Get the managed ruleset
                var filtered =
                    CdnManagementClient.ManagedRuleSets.List()
                        .Where(rs => rs.Name.ToLower() == ManagedRuleSetName.ToLower())
                        .Select(rs => rs.ToPsManagedRuleSetDefinition());
                if (filtered.Count() == 0)
                {
                    throw new PSArgumentException(string.Format(
                        Resources.Error_ManagedRuleSetNotFound,
                        ManagedRuleSetName));
                }
                WriteVerbose(Resources.Success);
                WriteObject(filtered.ToArray());
                return;
            }

            // List all managed rule sets.
            var rulesets =
                CdnManagementClient.ManagedRuleSets.List().Select(rs => rs.ToPsManagedRuleSetDefinition());
            WriteVerbose(Resources.Success);
            WriteObject(rulesets.ToArray(), true);
        }
    }
}
