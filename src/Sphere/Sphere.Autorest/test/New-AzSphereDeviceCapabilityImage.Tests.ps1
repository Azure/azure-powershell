if(($null -eq $TestName) -or ($TestName -contains 'New-AzSphereDeviceCapabilityImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSphereDeviceCapabilityImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSphereDeviceCapabilityImage' {
    It 'GenerateExpanded' {
        {
            New-AzSphereDeviceCapabilityImage -CatalogName $env.firstCatalog -DeviceGroupName $env.firstDeviceGroup -DeviceName $env.deviceID1 -ProductName $env.firstProduct -ResourceGroupName $env.resourceGroup -Capability
        } | Should -Not -Throw
    }

    It 'GenerateViaIdentityProductExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentityCatalogExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentityDeviceGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
