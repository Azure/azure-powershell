if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFileShareProvisioningRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileShareProvisioningRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFileShareProvisioningRecommendation' {
    It 'GetExpanded' {
        {
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location `
                                                                 -ProvisionedStorageGiB 1000
            $config | Should -Not -BeNullOrEmpty
            $config.ProvisionedIOPerSec | Should -Not -BeNullOrEmpty
            $config.ProvisionedThroughputMiBPerSec | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaJsonString' {
        {
            $jsonString = @{
                properties = @{
                    provisionedStorageGiB = 1000
                }
            } | ConvertTo-Json -Depth 10
            
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location -JsonString $jsonString
            $config | Should -Not -BeNullOrEmpty
            $config.ProvisionedIOPerSec | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-recommendation.json'
            $jsonContent = @{
                properties = @{
                    provisionedStorageGiB = 1000
                }
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location -JsonFilePath $jsonFilePath
            $config | Should -Not -BeNullOrEmpty
            $config.ProvisionedIOPerSec | Should -Not -BeNullOrEmpty
            
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $requestBody = @{
                ProvisionedStorageGiB = 1000
            }
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location -Body $requestBody
            $config | Should -Not -BeNullOrEmpty
            $config.ProvisionedIOPerSec | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentityExpanded' {
        {
            $inputObj = @{ 
                Location = $env.location
                SubscriptionId = $env.SubscriptionId
            }
            $config = Get-AzFileShareProvisioningRecommendation -InputObject $inputObj `
                                                                 -ProvisionedStorageGiB 1000
            $config | Should -Not -BeNullOrEmpty
            $config.ProvisionedIOPerSec | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $inputObj = @{ 
                Location = $env.location
                SubscriptionId = $env.SubscriptionId
            }
            $requestBody = @{
                ProvisionedStorageGiB = 1000
            }
            $config = Get-AzFileShareProvisioningRecommendation -InputObject $inputObj -Body $requestBody
            $config | Should -Not -BeNullOrEmpty
            $config.ProvisionedIOPerSec | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
