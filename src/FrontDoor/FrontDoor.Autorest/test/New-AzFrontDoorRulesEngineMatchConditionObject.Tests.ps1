if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorRulesEngineMatchConditionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorRulesEngineMatchConditionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorRulesEngineMatchConditionObject' {
    It '__AllParameterSets' -skip {
        $redirectConditions = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable "RequestHeader" -Operator "Equal" -MatchValue "redirect" -Transform "LowerCase" -Selector "Rules-Engine-Route-Forward" -NegateCondition $false
        $redirectConditions.MatchVariable | Should -Be @("RequestHeader")
        $redirectConditions.Operator | Should -Be "Equal"
        $redirectConditions.MatchValue | Should -Be "redirect"
        $redirectConditions.Transform | Should -Be @("LowerCase")
        $redirectConditions.Selector | Should -Be "Rules-Engine-Route-Forward"
        $redirectConditions.NegateCondition | Should -Be $false
    }
}
