if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafManagedRuleObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafManagedRuleObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafManagedRuleObject' {
    It '__AllParameterSets' -skip {
        $exclusionRule = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInRule"
        $exclusionGroup = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInGroup"
        $exclusionSet = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInSet"
        $ruleOverride = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942100" -Action "Log" -Exclusion $exclusionRule
        $override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName "SQLI" -ManagedRuleOverride $ruleOverride -Exclusion $exclusionGroup
        $managedRule1 = New-AzFrontDoorWafManagedRuleObject -Type "DefaultRuleSet" -Version "1.0" -RuleGroupOverride $override1 -Exclusion $exclusionSet
        $managedRule1.Type | Should -Be "DefaultRuleSet"
        $managedRule1.Version | Should -Be "1.0"
    }
}
