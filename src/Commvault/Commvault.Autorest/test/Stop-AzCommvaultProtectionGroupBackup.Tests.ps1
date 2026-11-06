if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzCommvaultProtectionGroupBackup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzCommvaultProtectionGroupBackup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzCommvaultProtectionGroupBackup' {
    It 'StopExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Stop' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentityCloudAccountExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentityCloudAccount' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StopViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
