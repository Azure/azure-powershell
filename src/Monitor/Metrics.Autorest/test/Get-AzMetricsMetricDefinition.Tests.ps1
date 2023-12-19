if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMetricsMetricDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMetricsMetricDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMetricsMetricDefinition' {
    It 'List' {
        {
            Get-AzMetricsMetricDefinition -Region $env.Location -Namespace "microsoft.compute/virtualmachines"
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            Get-AzMetricsMetricDefinition -ResourceUri $env.resourceId
        } | Should -Not -Throw
    }
}
