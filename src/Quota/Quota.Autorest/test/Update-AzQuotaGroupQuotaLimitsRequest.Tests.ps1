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
        # NOTE: This test requires a subscription to be added to the group quota first
        # Currently there is no Set-AzQuotaGroupQuotaSubscription cmdlet to do this setup
        # Prerequisite: Manually add subscription using Azure Portal or REST API
        
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testlocation"
        $location = "eastus"
        $resourceProviderName = "Microsoft.Compute"
        
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
