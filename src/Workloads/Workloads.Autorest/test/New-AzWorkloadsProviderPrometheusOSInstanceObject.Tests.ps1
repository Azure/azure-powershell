if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderPrometheusOSInstanceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderPrometheusOSInstanceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderPrometheusOSInstanceObject' {
    It '__AllParameterSets' {
        $providerSetting = New-AzWorkloadsProviderPrometheusOSInstanceObject -PrometheusUrl "http://10.1.0.4:9100/metrics" -SapSid X00 -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "PrometheusOS"

        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.osProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting $providerSetting
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
