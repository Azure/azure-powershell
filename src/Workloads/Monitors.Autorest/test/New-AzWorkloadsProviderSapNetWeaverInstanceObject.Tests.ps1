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
        $providerSetting = New-AzWorkloadsProviderSapNetWeaverInstanceObject -SapClientId 400 -SapPortNumber 8000 -SapHostFileEntry '["10.8.1.35 chascs00cl1.sap.contoso.com chascs00cl1","10.8.1.36 chaers01cl2.sap.contoso.com chaers01cl2","10.8.1.9 vchaa02l0c.sap.contoso.com vchaa02l0c","10.8.1.38 vchaa01l0c.sap.contoso.com vchaa01l0c"]' -SapHostname 10.8.1.9 -SapInstanceNr 00 -SapPassword '' -SapSid CHA -SapUsername AMS_USER -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "SapNetWeaver"

        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.nwProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting $providerSetting
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
