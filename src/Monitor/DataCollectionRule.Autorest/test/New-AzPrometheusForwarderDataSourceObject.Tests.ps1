if(($null -eq $TestName) -or ($TestName -contains 'New-AzPrometheusForwarderDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPrometheusForwarderDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPrometheusForwarderDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzPrometheusForwarderDataSourceObject -LabelIncludeFilter @{"microsoft_metrics_include_label"="MonitoringData"} -Name "myPromDataSource1" -Stream "Microsoft-PrometheusMetrics"
        } | Should -Not -Throw
    }
}
