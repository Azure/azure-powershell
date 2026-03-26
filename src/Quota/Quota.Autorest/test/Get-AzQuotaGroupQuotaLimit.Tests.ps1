if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaLimit'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaLimit.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaLimit' {
    It 'List' {
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testquota-limit"
        
        # Create a GroupQuota first
        $groupQuota = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Quota for Limits"
        $groupQuota | Should -Not -BeNull
        
        # Now list the limits (may be empty initially but should not error)
        $result = Get-AzQuotaGroupQuotaLimit -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ResourceProviderName "Microsoft.Compute" -Location "eastus"
        
        # Should execute without error
        $? | Should -Be $true
        
        # Cleanup
        Remove-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
    }
}
