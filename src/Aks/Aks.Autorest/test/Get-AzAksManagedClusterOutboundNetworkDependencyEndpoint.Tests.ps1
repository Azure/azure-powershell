if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint' {
    It 'List' {
        $result = Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName
        $result.Count | Should -Be 6
        $result.Category.Contains("azure-resource-management") | Should -Be $true
        $result.Category.Contains("images") | Should -Be $true
        $result.Category.Contains("artifacts") | Should -Be $true
        $result.Category.Contains("time-sync") | Should -Be $true
        $result.Category.Contains("ubuntu-optional") | Should -Be $true
        $result.Category.Contains("apiserver") | Should -Be $true

        ($result | Where Category -eq "azure-resource-management").Endpoint.DomainName.Contains("management.azure.com") | Should -Be $true
        ($result | Where Category -eq "azure-resource-management").Endpoint.DomainName.Contains("login.microsoftonline.com") | Should -Be $true
        (($result | Where Category -eq "azure-resource-management").Endpoint | where DomainName -eq "management.azure.com").EndpointDetail.Protocol | Should -Be 'Https'
        (($result | Where Category -eq "azure-resource-management").Endpoint | where DomainName -eq "management.azure.com").EndpointDetail.Port | Should -Be 443
        ($result | Where Category -eq "apiserver").Endpoint.EndpointDetail.Protocol | Should -Be 'Https'
        ($result | Where Category -eq "apiserver").Endpoint.EndpointDetail.Port | Should -Be 443
    }
}
