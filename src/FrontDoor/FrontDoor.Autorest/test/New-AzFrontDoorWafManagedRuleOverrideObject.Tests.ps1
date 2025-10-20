if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafManagedRuleOverrideObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafManagedRuleOverrideObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafManagedRuleOverrideObject' {
    It '__AllParameterSets' -skip {
        $exclusionRule = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInRule"
        $ruleOverride = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942100" -Action "Log" -Exclusion $exclusionRule
        $ruleOverride.RuleId | Should -Be "942100"
        $ruleOverride.Action | Should -Be "Log"
    }
}
