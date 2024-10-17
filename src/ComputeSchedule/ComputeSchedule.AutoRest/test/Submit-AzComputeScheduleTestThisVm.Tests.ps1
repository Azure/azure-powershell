if(($null -eq $TestName) -or ($TestName -contains 'Submit-AzComputeScheduleTestThisVm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Submit-AzComputeScheduleTestThisVm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Submit-AzComputeScheduleTestThisVm' {
    It 'SubmitExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaJsonString2' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaJsonString1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaJsonFilePath2' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaJsonFilePath1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitExpanded2' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaIdentityExpanded2' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaIdentityExpanded1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SubmitViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
