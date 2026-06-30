# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.
.Description
Create an in-memory object for SecurityPolicyWebApplicationFirewallParameters.

Embedded WAF compatibility parameters are accepted to keep the 2025-09 preview help surface visible, but are ignored by this 2026 API version.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.SecurityPolicyWebApplicationFirewallParameters
.Link
https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnsecuritypolicywebapplicationfirewallparametersobject
#>
function New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject {
    [Microsoft.Azure.PowerShell.Cmdlets.Cdn.ModelCmdletAttribute()]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.SecurityPolicyWebApplicationFirewallParameters')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Waf associations.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ISecurityPolicyWebApplicationFirewallAssociation[]]
        $Association,
        [Parameter(HelpMessage="Indicates if this is a profile-level WAF policy.")]
        [bool]
        $IsProfileLevel,
        [Parameter(HelpMessage="Resource ID.")]
        [string]
        $WafPolicyId,
        [Parameter(HelpMessage="The type of the security policy. This compatibility parameter is accepted for 2025-09 embedded WAF help surface and ignored.")]
        [string]
        $Type,
        [Parameter(HelpMessage="Embedded Web Application Firewall policy object. This compatibility parameter is accepted for help surface and ignored.")]
        [object]
        $WafPolicy,
        [Parameter(HelpMessage="Embedded WAF policy SKU name. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafPolicySkuName,
        [Parameter(HelpMessage="Embedded WAF policy settings object. This compatibility parameter is accepted for help surface and ignored.")]
        [object]
        $EmbeddedWafPolicySetting,
        [Parameter(HelpMessage="Embedded WAF policy enabled state. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafPolicySettingEnabledState,
        [Parameter(HelpMessage="Embedded WAF policy mode. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafPolicySettingMode,
        [Parameter(HelpMessage="Embedded WAF policy redirect URL. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafPolicySettingRedirectUrl,
        [Parameter(HelpMessage="Embedded WAF policy custom block response status code. This compatibility parameter is accepted for help surface and ignored.")]
        [int]
        $EmbeddedWafPolicySettingCustomBlockResponseStatusCode,
        [Parameter(HelpMessage="Embedded WAF policy custom block response body. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafPolicySettingCustomBlockResponseBody,
        [Parameter(HelpMessage="Embedded WAF policy request body check setting. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafPolicySettingRequestBodyCheck,
        [Parameter(HelpMessage="Embedded WAF JavaScript challenge expiration in minutes. This compatibility parameter is accepted for help surface and ignored.")]
        [int]
        $EmbeddedWafPolicySettingJavascriptChallengeExpirationInMinutes,
        [Parameter(HelpMessage="Embedded WAF captcha expiration in minutes. This compatibility parameter is accepted for help surface and ignored.")]
        [int]
        $EmbeddedWafPolicySettingCaptchaExpirationInMinutes,
        [Parameter(HelpMessage="Embedded WAF log scrubbing object. This compatibility parameter is accepted for help surface and ignored.")]
        [object]
        $EmbeddedWafLogScrubbing,
        [Parameter(HelpMessage="Embedded WAF log scrubbing state. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafLogScrubbingState,
        [Parameter(HelpMessage="Embedded WAF log scrubbing rules. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafLogScrubbingRule,
        [Parameter(HelpMessage="Embedded WAF custom rules. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafCustomRule,
        [Parameter(HelpMessage="Embedded WAF custom rule name. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafCustomRuleName,
        [Parameter(HelpMessage="Embedded WAF custom rule priority. This compatibility parameter is accepted for help surface and ignored.")]
        [int]
        $EmbeddedWafCustomRulePriority,
        [Parameter(HelpMessage="Embedded WAF custom rule enabled state. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafCustomRuleEnabledState,
        [Parameter(HelpMessage="Embedded WAF custom rule type. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafCustomRuleType,
        [Parameter(HelpMessage="Embedded WAF custom rule rate limit duration in minutes. This compatibility parameter is accepted for help surface and ignored.")]
        [int]
        $EmbeddedWafCustomRuleRateLimitDurationInMinutes,
        [Parameter(HelpMessage="Embedded WAF custom rule rate limit threshold. This compatibility parameter is accepted for help surface and ignored.")]
        [int]
        $EmbeddedWafCustomRuleRateLimitThreshold,
        [Parameter(HelpMessage="Embedded WAF custom rule group-by variables. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafCustomRuleGroupBy,
        [Parameter(HelpMessage="Embedded WAF custom rule match conditions. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafCustomRuleMatchCondition,
        [Parameter(HelpMessage="Embedded WAF custom rule action. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafCustomRuleAction,
        [Parameter(HelpMessage="Embedded WAF match variable. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafMatchVariable,
        [Parameter(HelpMessage="Embedded WAF match selector. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafMatchSelector,
        [Parameter(HelpMessage="Embedded WAF match operator. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafMatchOperator,
        [Parameter(HelpMessage="Embedded WAF negate condition flag. This compatibility parameter is accepted for help surface and ignored.")]
        [bool]
        $EmbeddedWafNegateCondition,
        [Parameter(HelpMessage="Embedded WAF match values. This compatibility parameter is accepted for help surface and ignored.")]
        [string[]]
        $EmbeddedWafMatchValue,
        [Parameter(HelpMessage="Embedded WAF match transforms. This compatibility parameter is accepted for help surface and ignored.")]
        [string[]]
        $EmbeddedWafTransform,
        [Parameter(HelpMessage="Embedded WAF managed rule sets. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafManagedRuleSet,
        [Parameter(HelpMessage="Embedded WAF managed rule set type. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleSetType,
        [Parameter(HelpMessage="Embedded WAF managed rule set version. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleSetVersion,
        [Parameter(HelpMessage="Embedded WAF managed rule set action. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleSetAction,
        [Parameter(HelpMessage="Embedded WAF managed rule exclusions. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafManagedRuleExclusion,
        [Parameter(HelpMessage="Embedded WAF managed rule group overrides. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafManagedRuleGroupOverride,
        [Parameter(HelpMessage="Embedded WAF managed rule group name. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleGroupName,
        [Parameter(HelpMessage="Embedded WAF managed rule overrides. This compatibility parameter is accepted for help surface and ignored.")]
        [object[]]
        $EmbeddedWafManagedRuleOverride,
        [Parameter(HelpMessage="Embedded WAF managed rule ID. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleId,
        [Parameter(HelpMessage="Embedded WAF managed rule enabled state. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleEnabledState,
        [Parameter(HelpMessage="Embedded WAF managed rule action. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafManagedRuleAction,
        [Parameter(HelpMessage="Embedded WAF exclusion selector match operator. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafExclusionSelectorMatchOperator,
        [Parameter(HelpMessage="Embedded WAF exclusion selector. This compatibility parameter is accepted for help surface and ignored.")]
        [string]
        $EmbeddedWafExclusionSelector
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.SecurityPolicyWebApplicationFirewallParameters]::New()

        if ($PSBoundParameters.ContainsKey('Association')) {
            $Object.Association = $Association
        }
        if ($PSBoundParameters.ContainsKey('IsProfileLevel')) {
            $Object.IsProfileLevel = $IsProfileLevel
        }
        if ($PSBoundParameters.ContainsKey('WafPolicyId')) {
            $Object.WafPolicyId = $WafPolicyId
        }
        return $Object
    }
}