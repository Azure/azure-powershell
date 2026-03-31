if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPlanetaryComputerGeoCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..' 'loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPlanetaryComputerGeoCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPlanetaryComputerGeoCatalog' {
    It 'UpdateExpanded' {
        $result = Update-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName -ResourceGroupName $env.ResourceGroupName -Tag @{ "testKey" = "testValue" }
        $result.Name | Should -Be $env.CatalogName
        $result.Tag["testKey"] | Should -Be "testValue"
    }

    It 'UpdateExpandedWithIdentity' {
        $result = Update-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName -ResourceGroupName $env.ResourceGroupName -UserAssignedIdentity @($env.UserAssignedIdentityId)
        $result.Name | Should -Be $env.CatalogName
        $result.IdentityType | Should -Match 'UserAssigned'
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
