if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzVMwareRescheduleMaintenance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVMwareRescheduleMaintenance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzVMwareRescheduleMaintenance' {
    It 'RescheduleExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RescheduleViaIdentityPrivateCloudExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RescheduleViaIdentityPrivateCloud' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Reschedule' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RescheduleViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RescheduleViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
