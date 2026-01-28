if(($null -eq $TestName) -or ($TestName -contains 'New-AzQuotaGroupQuotaSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzQuotaGroupQuotaSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzQuotaGroupQuotaSubscription' {
    It 'Create' {
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testlocation"
        
        # First, ensure the GroupQuota exists
        $groupQuota = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ErrorAction SilentlyContinue
        if (-not $groupQuota) {
            $groupQuota = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Location Group Quota"
        }
        
        # Remove subscription if it already exists to ensure clean test
        Remove-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        Start-Sleep -Seconds 5
        
        # Now create the subscription in the GroupQuota
        $result = New-AzQuotaGroupQuotaSubscription -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -SubscriptionId $env.SubscriptionId
        $result | Should -Not -BeNullOrEmpty
    }
}
