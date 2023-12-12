if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderSapNetWeaverInstanceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderSapNetWeaverInstanceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderSapNetWeaverInstanceObject' {
    It '__AllParameterSets' {
        $providerSetting = New-AzWorkloadsProviderSapNetWeaverInstanceObject -SapClientId 000 -SapHostFileEntry '["10.0.82.4 l13appvm0.ams.azure.com l13appvm0","10.0.82.5 l13ascsvm.ams.azure.com l13ascsvm"]' -SapHostname 10.0.82.4 -SapInstanceNr 00 -SapPassword Password@1234 -SapSid L13 -SapUsername AMSUSER -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "SapNetWeaver"
        
        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.nwProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting $providerSetting
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
