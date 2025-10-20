if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafLogScrubbingRuleObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafLogScrubbingRuleObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafLogScrubbingRuleObject' {
    It '__AllParameterSets' -skip {
        $LogScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
        $LogScrubbingRule.MatchVariable | Should -Be "RequestHeaderNames"
        $LogScrubbingRule.SelectorMatchOperator | Should -Be "EqualsAny"
        $LogScrubbingRule.State | Should -Be "Enabled"
    }
}
