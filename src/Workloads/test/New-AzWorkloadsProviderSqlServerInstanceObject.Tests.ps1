if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsProviderSqlServerInstanceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsProviderSqlServerInstanceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsProviderSqlServerInstanceObject' {
    It '__AllParameterSets' {
        $providerSetting = New-AzWorkloadsProviderSqlServerInstanceObject -Password 'Password@123' -Port 1433 -Username ams -Hostname 10.1.14.5 -SapSid X00 -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "MsSqlServer"
        
        $response = New-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.sqlProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId -ProviderSetting $providerSetting
        $response.ProvisioningState | Should -Be "Succeeded"
    }
}
