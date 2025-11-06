if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafCustomRuleObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafCustomRuleObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafCustomRuleObject' {
    It '__AllParameterSets' -skip {
        $matchCondition1 = New-AzFrontDoorWafMatchConditionObject -MatchVariable "RequestHeader" -OperatorProperty "Contains" -Selector "UserAgent" -MatchValue "WINDOWS" -Transform "Uppercase"
        $customRule1 = New-AzFrontDoorWafCustomRuleObject -Name "Rule1" -RuleType "MatchRule" -MatchCondition $matchCondition1 -Action "Block" -Priority 2
        $customRule1.Name | Should -Be "Rule1"
        $customRule1.RuleType | Should -Be "MatchRule"
        $customRule1.Action | Should -Be "Block"
        $customRule1.Priority | Should -Be 2
        $customRule1.EnabledState | Should -Be "Enabled"
        $customRule1.RateLimitDurationInMinutes | Should -Be 1
    }
}
