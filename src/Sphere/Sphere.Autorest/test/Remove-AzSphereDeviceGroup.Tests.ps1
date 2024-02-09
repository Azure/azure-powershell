if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSphereDeviceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSphereDeviceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSphereDeviceGroup' {
    It 'Delete' -skip {
        {
            Remove-AzSphereDeviceGroup -CatalogName $env.firstCatalog -Name $env.firstDeviceGroup -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityProduct' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityCatalog' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            Get-AzSphereDeviceGroup -CatalogName $env.firstCatalog -Name $env.firstDeviceGroup -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup | Remove-AzSphereDeviceGroup
        } | Should -Not -Throw
    }
}
