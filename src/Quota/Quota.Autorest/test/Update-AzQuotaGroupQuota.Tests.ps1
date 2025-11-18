if(($null -eq $TestName) -or ($TestName -contains 'Update-AzQuotaGroupQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzQuotaGroupQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzQuotaGroupQuota' {
    It 'UpdateExpanded' {
        # Create a group quota first
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testquota$(Get-Random)"
        $initialDisplayName = "Test Quota Group"
        $updatedDisplayName = "Updated Test Quota Group"
        
        # Create the group quota
        $created = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName $initialDisplayName
        $created | Should -Not -BeNull
        
        # Update the display name
        $updated = Update-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -Name $groupQuotaName -DisplayName $updatedDisplayName
        $updated | Should -Not -BeNull
        
        # Verify the update by getting the group quota
        $retrieved = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        $retrieved.Name | Should -Be $groupQuotaName
    }

    It 'UpdateViaIdentityExpanded' {
        # Create a group quota first
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testquota$(Get-Random)"
        $initialDisplayName = "Test Quota Via Identity"
        $updatedDisplayName = "Updated Via Identity"
        
        # Create the group quota
        $created = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName $initialDisplayName
        $created | Should -Not -BeNull
        
        # Get the group quota to obtain the identity object
        $groupQuota = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        
        # Update using identity
        $updated = Update-AzQuotaGroupQuota -InputObject $groupQuota -DisplayName $updatedDisplayName
        $updated | Should -Not -BeNull
    }
}
