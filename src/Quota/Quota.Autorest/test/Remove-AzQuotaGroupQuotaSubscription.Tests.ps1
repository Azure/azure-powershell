if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzQuotaGroupQuotaSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzQuotaGroupQuotaSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzQuotaGroupQuotaSubscription' {
    It 'Delete' {
        { 
            $groupQuotaName = "ComputeGroupQuota01"
            $mgId = $($env.SubscriptionId)
            $subscriptionId = $($env.SubscriptionId)
            Remove-AzQuotaGroupQuotaSubscription -GroupQuotaName $groupQuotaName -ManagementGroupId $mgId -SubscriptionId $subscriptionId -Confirm } | Should -Not -Throw
    }

    It 'DeleteViaIdentityManagementGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
