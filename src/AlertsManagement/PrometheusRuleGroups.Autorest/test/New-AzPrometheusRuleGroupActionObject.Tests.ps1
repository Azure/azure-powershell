if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrometheusRuleGroupActionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrometheusRuleGroupActionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrometheusRuleGroupActionObject' {
    It '__AllParameterSets' {
        {New-AzPrometheusRuleGroupActionObject -ActionGroupId $actiongroup -ActionProperty @{"key1" = "value1"}} | Should -Not -Throw
    }
}
