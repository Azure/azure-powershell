if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoorWafPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoorWafPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoorWafPolicy' {
    It 'Delete' {
        {
            $wafName = $env.WafPolicyNameForDelete
            $matchCondition1 = New-AzFrontDoorWafMatchConditionObject -MatchVariable "RequestHeader" -OperatorProperty "Contains" -Selector "UserAgent" -MatchValue "WINDOWS" -Transform "Uppercase"
            $customRule1 = New-AzFrontDoorWafCustomRuleObject -Name "Rule1" -RuleType "MatchRule" -MatchCondition $matchCondition1 -Action Block -Priority 2
        
            # Create exclusion objects
            $exclusionRule = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInRule"
            $exclusionGroup = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInGroup"
            $exclusionSet = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInSet"
        
            $ruleOverride = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942100" -Action "Log" -Exclusion $exclusionRule
            $override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName "SQLI" -ManagedRuleOverride $ruleOverride -Exclusion $exclusionGroup
            $managedRule1 = New-AzFrontDoorWafManagedRuleObject -Type "DefaultRuleSet" -Version "1.0" -RuleGroupOverride $override1 -Exclusion $exclusionSet
            $managedRule2 = New-AzFrontDoorWafManagedRuleObject -Type "BotProtection" -Version "preview-0.1"
        
            $logScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
            $logscrubbingSetting = New-AzFrontDoorWafLogScrubbingSettingObject -State "Enabled" -ScrubbingRule @($logScrubbingRule)
        
            New-AzFrontDoorWafPolicy -Name $wafName -ResourceGroupName $env.ResourceGroupName -Sku "Premium_AzureFrontDoor" -Customrule $customRule1 -ManagedRule $managedRule1,$managedRule2 -EnabledState "Enabled" -Mode "Prevention" -RequestBodyCheck "Disabled" -LogScrubbingSetting $logscrubbingSetting -JavascriptChallengeExpirationInMinutes 30  
        
            Remove-AzFrontDoorWafPolicy -Name $wafName -ResourceGroupName $env.ResourceGroupName -PassThru
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
