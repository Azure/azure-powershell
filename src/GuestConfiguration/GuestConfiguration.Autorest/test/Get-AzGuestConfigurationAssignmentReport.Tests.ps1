if(($null -eq $TestName) -or ($TestName -contains 'Get-AzGuestConfigurationAssignmentReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzGuestConfigurationAssignmentReport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzGuestConfigurationAssignmentReport' {
    # Skip as all tests are added in Test-AzGuestConfigurationAssignmentBy*.Tests.ps1
    It 'List' -skip {
        { Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName $env.assignmentName -ResourceGroupName $env.resourcegroupName -VMName $env.vmName} | Should -Not -Throw
    }

    # Skip as no command supports creating a report to test by far
    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    # Skip it as no command supports creating a report to test by far
    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
