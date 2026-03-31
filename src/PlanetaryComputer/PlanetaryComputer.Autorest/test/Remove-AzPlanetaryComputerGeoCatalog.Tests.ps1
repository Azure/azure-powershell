if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPlanetaryComputerGeoCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..' 'loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPlanetaryComputerGeoCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPlanetaryComputerGeoCatalog' {
    It 'Delete' {
        # Delete the catalog created by the New test using -NoWait to avoid LRO playback issues
        Remove-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName2 -ResourceGroupName $env.NewResourceGroupName -NoWait
        # Poll until catalog is deleted
        $retries = 0
        $maxRetries = 360
        $deleted = $false
        while ($retries -lt $maxRetries) {
            Start-TestSleep -Seconds 10
            $retries++
            try {
                Get-AzPlanetaryComputerGeoCatalog -CatalogName $env.CatalogName2 -ResourceGroupName $env.NewResourceGroupName
            } catch {
                if ($_.Exception.Message -match 'NotFound|not found|404') {
                    $deleted = $true
                    break
                }
                throw
            }
        }
        $deleted | Should -Be $true
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
