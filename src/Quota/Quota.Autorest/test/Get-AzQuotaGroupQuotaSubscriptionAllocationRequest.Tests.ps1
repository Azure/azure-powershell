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
    It 'Get' -skip {
        {   
            $allocationId = "a1b2c3d4-e5f6-7890-abcd-1234567890ab"
            $subscriptionId = $($env.SubscriptionId)
            Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId $allocationId -ManagementGroupId "admintest" -GroupQuotaName "ComputeGroupQuota01" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId 
        } | Should -Not -Throw
    }

    It 'GetViaIdentityResourceProvider' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityManagementGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityGroupQuota' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
