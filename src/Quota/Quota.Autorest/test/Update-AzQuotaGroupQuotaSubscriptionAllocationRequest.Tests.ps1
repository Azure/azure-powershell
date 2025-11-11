if(($null -eq $TestName) -or ($TestName -contains 'Update-AzQuotaGroupQuotaSubscriptionAllocationRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzQuotaGroupQuotaSubscriptionAllocationRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzQuotaGroupQuotaSubscriptionAllocationRequest' {
    BeforeAll {
        # Use values from env.json
        $script:tenantId = $env.Tenant
        $script:subscriptionId = $env.SubscriptionId
        $script:managementGroupId = "mg-demo"
        $script:groupQuotaName = "testlocation"
        $script:location = "eastus"
        $script:resourceProviderName = "Microsoft.Compute"
        $script:resourceName = "standardFSv2Family"  # Use the same resource name as other tests
        $script:groupQuotaExists = $false
        
        # Check if group quota "testlocation" exists
        try {
            $existingQuota = Get-AzQuotaGroupQuota -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ErrorAction SilentlyContinue
            if ($existingQuota) {
                $script:groupQuotaExists = $true
            }
        } catch {
            # Group quota doesn't exist
        }
        
        # If group quota doesn't exist, create it
        if (-not $script:groupQuotaExists) {
            try {
                $newQuota = New-AzQuotaGroupQuota -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -DisplayName "Test Location Group Quota"
                if ($newQuota) {
                    $script:groupQuotaExists = $true
                }
            } catch {
                Write-Host "Failed to create group quota: $($_.Exception.Message)"
            }
        }
    }

    It 'UpdateExpanded' {
        # Create the allocation request using the correct resource name
        $allocationRequest = @{
            Properties = @{
                Value = @(
                    @{
                        Properties = @{
                            Limit = 25
                            ResourceName = $script:resourceName
                        }
                    }
                )
            }
        }
        
        $result = Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location -SubscriptionId $script:subscriptionId -QuotaAllocationRequest $allocationRequest
        
        $result | Should -Not -BeNull
    }
}