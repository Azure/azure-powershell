if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzQuotaGroupQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzQuotaGroupQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzQuotaGroupQuota' {
    It 'Delete' -skip {
        { 
            $mgId = $($env.SubscriptionId)
            $groupQuotaName = "ComputeGroupQuota01"
            Remove-AzQuotaGroupQuota -ManagementGroupId $mgId -Name $groupQuotaName -Confirm
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityManagementGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
