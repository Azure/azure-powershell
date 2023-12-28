if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderHanaDbInstanceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderHanaDbInstanceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderHanaDbInstanceObject' {
    It '__AllParameterSets' {
        $providerSetting = New-AzWorkloadsProviderHanaDbInstanceObject -Name SYSTEMDB -Password ''  -Username SYSTEM -Hostname 10.0.81.4 -InstanceNumber 00 -SapSid X00 -SqlPort 1433 -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "SapHana"

        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.hanaProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting $providerSetting
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
