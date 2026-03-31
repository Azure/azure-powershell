if(($null -eq $TestName) -or ($TestName -contains 'Update-AzQuotaGroupQuotaLimitsRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzQuotaGroupQuotaLimitsRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzQuotaGroupQuotaLimitsRequest' {
    It 'UpdateExpanded' {
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testlocation"
        $location = "eastus"
        $resourceProviderName = "Microsoft.Compute"
        
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
        
        $jsonBody = @{
            properties = @{
                value = @(
                    @{
                        properties = @{
                            comment = "Test quota limit request"
                            limit = 100
                            resourceName = "standardDSv3Family"
                        }
                    }
                )
            }
        } | ConvertTo-Json -Depth 10
        
        $result = Update-AzQuotaGroupQuotaLimitsRequest -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ResourceProviderName $resourceProviderName -Location $location -JsonString $jsonBody
        $result | Should -Not -BeNullOrEmpty
    }
}
