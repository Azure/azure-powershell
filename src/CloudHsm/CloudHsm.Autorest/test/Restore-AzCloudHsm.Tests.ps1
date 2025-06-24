if(($null -eq $TestName) -or ($TestName -contains 'Restore-AzCloudHsm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzCloudHsm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restore-AzCloudHsm' {
    It 'RestoreExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Restore' -skip {
        #We must skip this test because we need activated resource and this operations can only be executed once per resource. Additional manuall steps must be completed from the dev for this test to run. Run this test locally and then skip. 
        $restore = Restore-AzCloudHsm -ClusterName chsm1 -ResourceGroupName ps-test -BlobContainerUri "https://pstestbackup.blob.core.windows.net/testbackup" -backupId cloudhsm-eb0e0bf9-9d12-4201-b38c-567c8a452dd5-2025061208354444
        $restore.status.Contains("Succeeded") | Should -Be $true
    }

    It 'RestoreViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
