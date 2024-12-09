if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorWafPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorWafPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorWafPolicy' {
    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $retrievedPolicy = Get-AzFrontDoorWafPolicy -Name $env.WafPolicyName -ResourceGroupName $env.ResourceGroupName
        $retrievedPolicy.Name | Should -Be $env.WafPolicyName
        
        $retrievedPolicy.CustomRuleRules.Name | Should -Be "Rule1"
        $retrievedPolicy.CustomRuleRules.Action | Should -Be "Block"
        $retrievedPolicy.CustomRuleRules.EnabledState | Should -Be "Enabled"
        $retrievedPolicy.CustomRuleRules.Priority | Should -Be 2
        $retrievedPolicy.CustomRuleRules.RateLimitDurationInMinutes | Should -Be 1
        $retrievedPolicy.CustomRuleRules.RuleType | Should -Be "MatchRule"
        $retrievedPolicy.CustomRuleRules.MatchCondition[0].MatchValue | Should -Be @("WINDOWS")
        $retrievedPolicy.CustomRuleRules.MatchCondition[0].MatchVariable | Should -Be "RequestHeader"
        $retrievedPolicy.CustomRuleRules.MatchCondition[0].NegateCondition | Should -Be $false
        $retrievedPolicy.CustomRuleRules.MatchCondition[0].OperatorProperty | Should -Be "Contains"
        $retrievedPolicy.CustomRuleRules.MatchCondition[0].Selector | Should -Be "UserAgent"
        $retrievedPolicy.CustomRuleRules.MatchCondition[0].Transform | Should -Be @("Uppercase")

        $retrievedPolicy.ManagedRuleSet[0].Version | Should -Be "1.0"
        $retrievedPolicy.ManagedRuleSet[0].Type | Should -Be "DefaultRuleSet"
        $retrievedPolicy.ManagedRuleSet[0].Exclusion[0].Operator | Should -Be "Equals"
        $retrievedPolicy.ManagedRuleSet[0].Exclusion[0].Selector | Should -Be "ExcludeInSet"
        $retrievedPolicy.ManagedRuleSet[0].Exclusion[0].Variable | Should -Be "QueryStringArgNames"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].RuleGroupName | Should -Be "SQLI"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].Exclusion[0].Operator | Should -Be "Equals"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].Exclusion[0].Selector | Should -Be "ExcludeInGroup"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].Exclusion[0].Variable | Should -Be "QueryStringArgNames"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].ManagedRuleOverride[0].Action | Should -Be "Log"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].ManagedRuleOverride[0].EnabledState | Should -Be "Enabled"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].ManagedRuleOverride[0].Exclusion[0].Operator | Should -Be "Equals"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].ManagedRuleOverride[0].Exclusion[0].Selector | Should -Be "ExcludeInRule"
        $retrievedPolicy.ManagedRuleSet[0].RuleGroupOverride[0].ManagedRuleOverride[0].Exclusion[0].Variable | Should -Be "QueryStringArgNames"
        $retrievedPolicy.ManagedRuleSet[1].Type | Should -Be "BotProtection"

        $retrievedPolicy.PolicySetting.EnabledState | Should -Be "Enabled"
        $retrievedPolicy.PolicySetting.Mode | Should -Be "Prevention"
        $retrievedPolicy.PolicySetting.RequestBodyCheck | Should -Be "Disabled"
        $retrievedPolicy.PolicySetting.JavascriptChallengeExpirationInMinutes | Should -Be 30
        $retrievedPolicy.PolicySetting.LogScrubbingSetting[0].State | Should -Be "Enabled"
        $retrievedPolicy.PolicySetting.LogScrubbingSetting[0].ScrubbingRule[0].MatchVariable | Should -Be "RequestHeaderNames" 
        $retrievedPolicy.PolicySetting.LogScrubbingSetting[0].ScrubbingRule[0].SelectorMatchOperator | Should -Be "EqualsAny"
        $retrievedPolicy.PolicySetting.LogScrubbingSetting[0].ScrubbingRule[0].State | Should -Be "Enabled"

    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
