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
    It 'GenerateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GenerateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
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
}
