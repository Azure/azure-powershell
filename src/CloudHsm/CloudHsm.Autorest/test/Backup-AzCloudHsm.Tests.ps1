if(($null -eq $TestName) -or ($TestName -contains 'Backup-AzCloudHsm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzCloudHsm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Backup-AzCloudHsm' {
    It 'BackupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Backup' {
        #We must skip this test because we need activated resource. The resource must be activated manually be the dev, so we cannot run these test as part of the pipeline. Run this test locally and then skip. 
        $backup = Backup-AzCloudHsm -SubscriptionId $env.SubscriptionId -ClusterName $env.cloudHsmName -ResourceGroupName $env.rgName -BlobContainerUri $env.backupContainerUri
        $backup.status.Contains("Succeeded") | Should -Be $true
    }

    It 'BackupViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
