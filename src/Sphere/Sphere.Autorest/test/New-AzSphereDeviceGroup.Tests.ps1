if(($null -eq $TestName) -or ($TestName -contains 'New-AzSphereDeviceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSphereDeviceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSphereDeviceGroup' {
    It 'CreateExpanded' {
        {
            New-AzSphereDeviceGroup -CatalogName $env.firstCatalog -Name $env.firstDeviceGroup -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityProductExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityCatalogExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
