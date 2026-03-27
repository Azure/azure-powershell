if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafCustomRuleGroupByVariableObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafCustomRuleGroupByVariableObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafCustomRuleGroupByVariableObject' {
    It '__AllParameterSets' -skip {
        $groupBy = New-AzFrontDoorWafCustomRuleGroupByVariableObject -VariableName "SocketAddr"
        $groupBy.VariableName | Should -Be "SocketAddr"
    }
}
