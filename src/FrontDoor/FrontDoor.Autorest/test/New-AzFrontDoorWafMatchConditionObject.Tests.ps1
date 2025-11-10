if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafMatchConditionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafMatchConditionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafMatchConditionObject' {
    It '__AllParameterSets' -skip {
        $matchCondition1 = New-AzFrontDoorWafMatchConditionObject -MatchVariable "RequestHeader" -OperatorProperty "Contains" -Selector "UserAgent" -MatchValue "WINDOWS" -Transform "Uppercase"
        $matchCondition1.MatchVariable | Should -Be "RequestHeader"
        $matchCondition1.OperatorProperty | Should -Be "Contains"
        $matchCondition1.Selector | Should -Be "UserAgent"
        $matchCondition1.MatchValue | Should -Be "WINDOWS"
        $matchCondition1.Transform | Should -Be "Uppercase"
    }
}
