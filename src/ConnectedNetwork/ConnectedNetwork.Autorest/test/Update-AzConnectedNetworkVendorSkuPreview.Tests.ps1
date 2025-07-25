if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConnectedNetworkVendorSkuPreview'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedNetworkVendorSkuPreview.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConnectedNetworkVendorSkuPreview' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityVendorSkuExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityVendorExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
