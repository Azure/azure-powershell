if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminNetworkConnectionHealthDetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminNetworkConnectionHealthDetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminNetworkConnectionHealthDetail' {
    It 'Get' {
        $healthDetail = Get-AzDevCenterAdminNetworkConnectionHealthDetail -NetworkConnectionName $env.networkConnectionName -ResourceGroupName $env.resourceGroup
        $healthDetail.HealthCheck.Count | Should -Be 7
        $healthDetail.HealthCheck[0].DisplayName | Should -Be "Azure tenant readiness"
        $healthDetail.HealthCheck[1].DisplayName | Should -Be "Azure virtual network readiness"
        $healthDetail.HealthCheck[2].DisplayName | Should -Be "Intune enrollment restrictions allow Windows enrollment"
        $healthDetail.HealthCheck[3].DisplayName | Should -Be "Azure subnet IP address usage"
        $healthDetail.HealthCheck[4].DisplayName | Should -Be "Endpoint connectivity"
        $healthDetail.HealthCheck[5].DisplayName | Should -Be "Localization language package readiness"
        $healthDetail.HealthCheck[6].DisplayName | Should -Be "UDP connection check"
    }
}