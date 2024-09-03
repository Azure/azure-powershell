if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderDB2InstanceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderDB2InstanceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderDB2InstanceObject' {
    It '__AllParameterSets' {
        $providerSetting = New-AzWorkloadsProviderDB2InstanceObject -Name Sample -Password '' -Port 25000 -Username db2admin -Hostname 10.1.21.4 -SapSid OPA -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "Db2"

        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.db2ProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting $providerSetting
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
