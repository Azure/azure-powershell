if(($null -eq $TestName) -or ($TestName -contains 'New-AzPlanetaryComputerGeoCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..' 'loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPlanetaryComputerGeoCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPlanetaryComputerGeoCatalog' {
    It 'CreateExpanded' {
        New-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName2 -ResourceGroupName $env.NewResourceGroupName -Location $env.Location -NoWait
        # Poll until catalog is provisioned (can take up to 1 hour)
        $result = $null
        $retries = 0
        $maxRetries = 360
        while ($retries -lt $maxRetries) {
            Start-TestSleep -Seconds 10
            $retries++
            try {
                $result = Get-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName2 -ResourceGroupName $env.NewResourceGroupName
                if ($result.ProvisioningState -eq 'Succeeded') {
                    break
                }
            } catch {
                # Catalog not yet available
            }
        }
        $result | Should -Not -BeNullOrEmpty -Because 'GeoCatalog should be provisioned within the retry budget'
        $result.Name | Should -Be $env.CatalogName2
        $result.Location | Should -Be $env.Location
        $result.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
