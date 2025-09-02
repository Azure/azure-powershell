if(($null -eq $TestName) -or ($TestName -contains 'Test-AzElasticSanVolumeBackup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzElasticSanVolumeBackup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzElasticSanVolumeBackup' {
    # Test case for this command is in New-AzElasticSan.Tests.ps1
    It 'BackupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Backup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityElasticSanExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityElasticSan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
