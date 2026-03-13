if(($null -eq $TestName) -or ($TestName -contains 'Start-AzNetworkCloudStorageApplianceReadCommand'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzNetworkCloudStorageApplianceReadCommand.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzNetworkCloudStorageApplianceReadCommand' {
    It 'RunViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaJsonString1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaJsonFilePath1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
