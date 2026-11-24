if(($null -eq $TestName) -or ($TestName -contains 'Resume-AzResilienceManagementRecoveryJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzResilienceManagementRecoveryJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Resume-AzResilienceManagementRecoveryJob' {
    It 'ResumeExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentityServiceGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentityRecoveryPlanExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentityRecoveryPlan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Resume' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResumeViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
