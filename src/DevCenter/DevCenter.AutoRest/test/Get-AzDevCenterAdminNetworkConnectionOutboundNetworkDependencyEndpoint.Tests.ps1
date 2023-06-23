if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint' {
    It 'List' {
        $listOfEndpoints = Get-AzDevCenterAdminNetworkConnectionOutboundNetworkDependencyEndpoint -ResourceGroupName $env.resourceGroup -NetworkConnectionName $env.networkConnectionName
        
        $listOfEndpoints.Count | Should -Be 4
        $listOfEndpoints[0].Category | Should -Be "Azure Virtual Desktop Commercial Cloud"
        $listOfEndpoints[1].Category | Should -Be "Azure Virtual Desktop Optional"
        $listOfEndpoints[2].Category | Should -Be "Intune"
        $listOfEndpoints[3].Category | Should -Be "Cloud PC"

    }
}
