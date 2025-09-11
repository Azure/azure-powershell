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
    It 'UpdateExpanded' -skip {
        { 
            $subscriptionId = $($env.SubscriptionId)
            $familyName = "standardDSv3Family"
            Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -ManagementGroupId "$($env.SubscriptionId)" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId -Value @(@{resourceName=$familyName; limit=10; unit="Count"})
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityManagementGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityResourceProviderExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityGroupQuotaExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
