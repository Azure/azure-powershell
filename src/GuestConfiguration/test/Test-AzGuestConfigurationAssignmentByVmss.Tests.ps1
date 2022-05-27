if(($null -eq $TestName) -or ($TestName -contains 'Test-AzGuestConfigurationAssignmentByVmss'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzGuestConfigurationAssignmentByVmss.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzGuestConfigurationAssignmentByVmss' {
    # Do not support creating assignment for vmss operation
    It 'CreateExpanded' -skip{
        Get-AzGuestConfigurationAssignment -ResourceGroupName $env.resourcegroupName -VmssName $env.vmssName
        Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName $env.assignmentName -ResourceGroupName $env.resourcegroupName -VmssName $env.vmssName
        # No assignment to delete
        Remove-AzGuestConfigurationAssignment -InputObject $assignment
    }
}
