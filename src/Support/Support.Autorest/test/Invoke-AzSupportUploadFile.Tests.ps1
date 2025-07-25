if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSupportUploadFile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSupportUploadFile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSupportUploadFile' {
    It 'UploadExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UploadViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UploadViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UploadViaIdentityFileWorkspaceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UploadViaIdentityFileWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Upload' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UploadViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UploadViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
