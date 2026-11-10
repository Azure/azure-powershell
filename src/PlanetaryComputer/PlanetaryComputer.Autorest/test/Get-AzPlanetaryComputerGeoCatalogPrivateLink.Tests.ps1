if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPlanetaryComputerGeoCatalogPrivateLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPlanetaryComputerGeoCatalogPrivateLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPlanetaryComputerGeoCatalogPrivateLink' {
    # Existing GeoCatalog CRUD recordings do not exercise private-link discovery or connection reads.
    It 'Discovers private-link resources and reads existing connections' {
        $parameters = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.ResourceGroupName
            CatalogName = $env.CatalogName
        }
        $resources = @(Get-AzPlanetaryComputerGeoCatalogPrivateLink @parameters)
        $group = @($resources | Where-Object GroupId -EQ 'geocatalog')
        $group.Count | Should -Be 1
        $group[0].RequiredMember | Should -Contain 'api'
        $group[0].RequiredZoneName | Should -Contain 'privatelink.geocatalog.spatio.azure.com'

        $connections = @(Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection @parameters)
        $connections.Count | Should -BeGreaterOrEqual 1
        $connection = Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection @parameters -Name $connections[0].Name
        $connection.Id | Should -Be $connections[0].Id
        $connection.PrivateLinkServiceConnectionStateStatus | Should -BeIn @('Pending', 'Approved', 'Rejected')
    }
}
