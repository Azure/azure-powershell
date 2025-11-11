if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaLimit'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaLimit.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaLimit' {
    It 'List' {
        if ($script:testGroupQuotaName) {
            # Test listing group quota limits for Microsoft.Compute in eastus
            $result = Get-AzQuotaGroupQuotaLimit -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:testGroupQuotaName -ResourceProviderName "Microsoft.Compute" -Location "eastus"
            
            # Should execute without error (result can be empty)
            $? | Should -Be $true
            
            # If results exist, validate structure
            if ($result) {
                foreach ($limit in $result) {
                    $limit.Properties | Should -Not -BeNull
                    $limit.Properties.Name | Should -Not -BeNull
                }
            }
        } else {
            Set-ItResult -Skipped -Because "No group quotas available for testing"
        }
    }
}
