if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderPrometheusHaClusterInstanceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderPrometheusHaClusterInstanceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderPrometheusHaClusterInstanceObject' {
    It '__AllParameterSets' {
        $providerSetting = New-AzWorkloadsProviderPrometheusHaClusterInstanceObject -ClusterName hacluster -Hostname h20dbvm0 -PrometheusUrl "http://10.0.92.5:964/metrics" -Sid X00 -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "PrometheusHaCluster"
    }
}
