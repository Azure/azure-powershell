if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderInstance' {
    It 'CreateExpanded' {
        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.osProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting '{"sslPreference":"Disabled","providerType":"PrometheusOS","prometheusUrl":"http://10.1.0.4:9100/metrics","sapSid":"X00"}'
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
