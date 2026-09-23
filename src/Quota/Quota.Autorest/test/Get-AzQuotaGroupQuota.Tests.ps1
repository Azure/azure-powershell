if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuota' {
    BeforeAll {
        # Only use values from env.json plus your known management group
        $script:tenantId = $env.Tenant
        $script:subscriptionId = $env.SubscriptionId
        $script:testManagementGroupId = "AzureClientToolsBAMI"  
        $script:testGroupQuotaName = $null
        
        # Try to find a group quota in the demo management group
        try {
            $groupQuotas = Get-AzQuotaGroupQuota -ManagementGroupId $script:testManagementGroupId -ErrorAction SilentlyContinue
            if ($groupQuotas -and $groupQuotas.Count -gt 0) {
                $script:testGroupQuotaName = $groupQuotas[0].Name
            }
        } catch {
            # No group quotas exist in this management group
        }
    }

    It 'List' {
        if ($script:testManagementGroupId) {
            $result = Get-AzQuotaGroupQuota -ManagementGroupId $script:testManagementGroupId
            $result | Should -Not -BeNull
        } else {
            Set-ItResult -Skipped -Because "No accessible management group found"
        }
    }

    It 'Get' {
        if ($script:testManagementGroupId -and $script:testGroupQuotaName) {
            $result = Get-AzQuotaGroupQuota -ManagementGroupId $script:testManagementGroupId -GroupQuotaName $script:testGroupQuotaName
            $result | Should -Not -BeNull
            $result.Name | Should -Be $script:testGroupQuotaName
        } else {
            Set-ItResult -Skipped -Because "No group quota available for testing"
        }
    }

    It 'GetViaIdentityManagementGroup' {
        if ($script:testManagementGroupId -and $script:testGroupQuotaName) {
            $identity = @{
                ManagementGroupId = $script:testManagementGroupId
                GroupQuotaName = $script:testGroupQuotaName
            }
            $result = Get-AzQuotaGroupQuota -InputObject $identity
            $result | Should -Not -BeNull
        } else {
            Set-ItResult -Skipped -Because "No group quota available for testing"
        }
    }

    It 'GetViaIdentity' {
        if ($script:testManagementGroupId -and $script:testGroupQuotaName) {
            $resourceId = "/providers/Microsoft.Management/managementGroups/$($script:testManagementGroupId)/providers/Microsoft.Quota/groupQuotas/$($script:testGroupQuotaName)"
            $identity = @{ Id = $resourceId }
            $result = Get-AzQuotaGroupQuota -InputObject $identity
            $result | Should -Not -BeNull
        } else {
            Set-ItResult -Skipped -Because "No group quota available for testing"
        }
    }
}