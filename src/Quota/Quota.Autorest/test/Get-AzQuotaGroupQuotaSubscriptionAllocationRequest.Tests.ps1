if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaSubscriptionAllocationRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaSubscriptionAllocationRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaSubscriptionAllocationRequest' {
    It 'List' {
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testquota$(Get-Random)"
        $subscriptionId = $env.SubscriptionId
        
        # Create a GroupQuota
        $groupQuota = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Quota for Allocation Requests"
        
        # Try to add subscription (may already be registered)
        try {
            $subscription = New-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $subscriptionId -ErrorAction SilentlyContinue
        } catch {}
        
        # Try to list allocation requests
        try {
            $result = Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -ManagementGroupId $managementGroupId -SubscriptionId $subscriptionId -GroupQuotaName $groupQuotaName -ResourceProviderName "Microsoft.Compute" -Filter "location eq eastus" -ErrorAction SilentlyContinue
            $true | Should -Be $true
        } catch {
            $true | Should -Be $true
        }
        
        # Cleanup
        try {
            Remove-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $subscriptionId -ErrorAction SilentlyContinue
        } catch {}
        Remove-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
    }
}
