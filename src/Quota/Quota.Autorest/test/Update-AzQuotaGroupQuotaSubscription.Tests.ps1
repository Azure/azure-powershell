if(($null -eq $TestName) -or ($TestName -contains 'Update-AzQuotaGroupQuotaSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzQuotaGroupQuotaSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzQuotaGroupQuotaSubscription' {
    It 'Update' {
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testlocation"
        
        # Ensure the GroupQuota exists
        $groupQuota = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ErrorAction SilentlyContinue
        if (-not $groupQuota) {
            $groupQuota = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Location Group Quota"
        }
        
        # Remove subscription if it exists to test update/add behavior
        Remove-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        Start-Sleep -Seconds 5
        
        # Update (adds) the subscription to the GroupQuota (PATCH operation)
        $result = Update-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId
        $result | Should -Not -BeNullOrEmpty
    }
}
