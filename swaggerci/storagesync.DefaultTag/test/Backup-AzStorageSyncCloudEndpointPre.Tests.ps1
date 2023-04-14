if(($null -eq $TestName) -or ($TestName -contains 'Backup-AzStorageSyncCloudEndpointPre'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzStorageSyncCloudEndpointPre.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Backup-AzStorageSyncCloudEndpointPre' {
    It 'BackupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Backup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
