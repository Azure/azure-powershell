if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPlanetaryComputerGeoCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..' 'loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPlanetaryComputerGeoCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPlanetaryComputerGeoCatalog' {
    It 'List' {
        $result = Get-AzPlanetaryComputerGeoCatalog
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $result = Get-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName -ResourceGroupName $env.ResourceGroupName
        $result.Name | Should -Be $env.CatalogName
        $result.Location | Should -Be $env.Location
        $result.ProvisioningState | Should -BeIn @('Succeeded', 'Accepted', 'Updating')
    }

    It 'List1' {
        $result = Get-AzPlanetaryComputerGeoCatalog -ResourceGroupName $env.ResourceGroupName
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
