if(($null -eq $TestName) -or ($TestName -contains 'Test-AzGuestConfigurationAssignmentByVm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzGuestConfigurationAssignmentByVm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzGuestConfigurationAssignmentByVm' {
    It 'CreateExpanded' {
        New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName $env.assignmentName -ResourceGroupName $env.resourcegroupName -VMName $env.vmName -GuestConfigurationName $env.guestConfigName -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
        $assignment = Get-AzGuestConfigurationAssignment -ResourceGroupName $env.resourcegroupName -VMName $env.vmName
        $assignment | Should -Not -Be $null
        Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName $env.assignmentName -ResourceGroupName $env.resourcegroupName -VMName $env.vmName
        Remove-AzGuestConfigurationAssignment -InputObject $assignment
    }
}
