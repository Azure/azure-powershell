if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafRuleGroupOverrideObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafRuleGroupOverrideObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafRuleGroupOverrideObject' {
    It '__AllParameterSets' -skip {
        $exclusionRule = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInRule"
        $exclusionGroup = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInGroup"
        $ruleOverride = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942100" -Action "Log" -Exclusion $exclusionRule
        $override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName "SQLI" -ManagedRuleOverride $ruleOverride -Exclusion $exclusionGroup
        $override1.RuleGroupName | Should -Be "SQLI"
    }
}
