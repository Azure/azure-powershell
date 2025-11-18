if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaSubscription' {
    It 'Get' {
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testlocation"
        
        # Ensure the GroupQuota exists
        $groupQuota = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ErrorAction SilentlyContinue
        if (-not $groupQuota) {
            $groupQuota = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Location Group Quota"
        }
        
        # Ensure the subscription is in the GroupQuota
        $existingSub = Get-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        if (-not $existingSub) {
            New-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId
            Start-Sleep -Seconds 5
        }
        
        # Get specific subscription
        $result = Get-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId
        $result | Should -Not -BeNullOrEmpty
    }

    It 'List' {
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testlocation"
        
        # Ensure the GroupQuota exists
        $groupQuota = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ErrorAction SilentlyContinue
        if (-not $groupQuota) {
            $groupQuota = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Location Group Quota"
        }
        
        # Ensure at least one subscription is in the GroupQuota
        $existingSub = Get-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        if (-not $existingSub) {
            New-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId
            Start-Sleep -Seconds 5
        }
        
        # List all subscriptions in the GroupQuota
        $result = Get-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterThan 0
    }
}
