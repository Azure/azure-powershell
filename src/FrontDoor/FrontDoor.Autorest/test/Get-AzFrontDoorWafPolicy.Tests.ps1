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
        
        $retrievedPolicy.CustomRule[0].Name | Should -Be "Rule1"
        $retrievedPolicy.CustomRule[0].Action | Should -Be "Block"
        $retrievedPolicy.CustomRule[0].EnabledState | Should -Be "Enabled"
        $retrievedPolicy.CustomRule[0].Priority | Should -Be 2
        $retrievedPolicy.CustomRule[0].RateLimitDurationInMinutes | Should -Be 1
        $retrievedPolicy.CustomRule[0].RuleType | Should -Be "MatchRule"
        $retrievedPolicy.CustomRule[0].MatchCondition[0].MatchValue | Should -Be @("WINDOWS")
        $retrievedPolicy.CustomRule[0].MatchCondition[0].MatchVariable | Should -Be "RequestHeader"
        $retrievedPolicy.CustomRule[0].MatchCondition[0].NegateCondition | Should -Be $false
        $retrievedPolicy.CustomRule[0].MatchCondition[0].OperatorProperty | Should -Be "Contains"
        $retrievedPolicy.CustomRule[0].MatchCondition[0].Selector | Should -Be "UserAgent"
        $retrievedPolicy.CustomRule[0].MatchCondition[0].Transform | Should -Be @("Uppercase")

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
