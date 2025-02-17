if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNetworkCloudScanClusterRuntime'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNetworkCloudScanClusterRuntime.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNetworkCloudScanClusterRuntime' {
    It 'ScanExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Scan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ScanViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ScanViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
