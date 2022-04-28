if(($null -eq $TestName) -or ($TestName -contains 'Get-AzManagedServicesMarketplaceDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzManagedServicesMarketplaceDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzManagedServicesMarketplaceDefinition' {
    It 'Get' -skip {
        $marketplaceDefinition = Get-AzManagedServicesMarketplaceDefinition -MarketplaceIdentifier $env.MarketplaceIdentifier | Format-List Id, PlanProduct, PlanPublisher, PlanName, PlanVersion
        $marketplaceDefinition.PlanName | Should -Be "plan1pms"
    }

    It 'GetViaIdentity' -skip {
        $marketplaceDefinition = Get-AzManagedServicesMarketplaceDefinition -MarketplaceIdentifier $env.MarketplaceIdentifier
        $marketplaceDefinition = Get-AzManagedServicesMarketplaceDefinition -InputObject $marketplaceDefinition
        $marketplaceDefinition.PlanName | Should -Be "plan1pms"
    }
}
