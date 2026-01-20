if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzQuotaGroupQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzQuotaGroupQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzQuotaGroupQuota' {
    It 'Delete' {
        # Create a group quota to delete
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testquota$(Get-Random)"
        
        # Create the group quota
        $created = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Quota for Deletion"
        $created | Should -Not -BeNull
        
        # Verify it was created by getting it
        $retrieved = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        $retrieved | Should -Not -BeNull
        $retrieved.Name | Should -Be $groupQuotaName
        
        # Delete the group quota
        Remove-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -Name $groupQuotaName -PassThru | Should -Be $true
        
        # Verify it was deleted - this should fail or return nothing
        { Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        # Create a group quota to delete
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testquota$(Get-Random)"
        
        # Create the group quota
        $created = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Quota for Identity Deletion"
        $created | Should -Not -BeNull
        
        # Get the group quota to obtain the identity object
        $groupQuota = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        $groupQuota | Should -Not -BeNull
        
        # Delete using identity
        Remove-AzQuotaGroupQuota -InputObject $groupQuota -PassThru | Should -Be $true
        
        # Verify it was deleted
        { Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ErrorAction Stop } | Should -Throw
    }
}
