if(($null -eq $TestName) -or ($TestName -contains 'Test-AzGuestConfigurationAssignmentByHcrp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzGuestConfigurationAssignmentByHcrp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzGuestConfigurationAssignmentByHcrp' {
    # No ARC marchine to test
    It 'CreateExpanded' -skip{
        New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName $env.assignmentName -ResourceGroupName $env.resourcegroupName -MachineName "test" -GuestConfigurationName $env.guestConfigName -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
        Get-AzGuestConfigurationAssignment -ResourceGroupName $env.resourcegroupName -MachineName "test"
        Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName $env.assignmentName -ResourceGroupName $env.resourcegroupName -MachineName "test"
        Remove-AzGuestConfigurationAssignment -InputObject $assignment
    }
}
