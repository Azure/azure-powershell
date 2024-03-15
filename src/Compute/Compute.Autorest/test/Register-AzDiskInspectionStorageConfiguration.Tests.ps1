if(($null -eq $TestName) -or ($TestName -contains 'Register-AzDiskInspectionStorageConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Register-AzDiskInspectionStorageConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Register-AzDiskInspectionStorageConfiguration' {
    It 'RegisterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Register' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegisterViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RegisterViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
