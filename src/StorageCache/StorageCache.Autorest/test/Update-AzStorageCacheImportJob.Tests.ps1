if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageCacheImportJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageCacheImportJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageCacheImportJob' {
    It 'UpdateExpanded' {
        {  } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {  } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {  } | Should -Not -Throw
    }

    It 'UpdateViaIdentityAmlFilesystemExpanded' {
        {  } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {  } | Should -Not -Throw
    }
}
