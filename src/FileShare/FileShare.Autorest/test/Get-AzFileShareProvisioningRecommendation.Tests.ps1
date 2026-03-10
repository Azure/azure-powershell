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
                                                                 -TargetStorageGiB 1000 `
                                                                 -TargetIoPerSec 3000 `
                                                                 -TargetThroughputMiBPerSec 125
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaJsonString' {
        {
            $jsonString = @{
                targetStorageGiB = 1000
                targetIoPerSec = 3000
                targetThroughputMiBPerSec = 125
            } | ConvertTo-Json -Depth 10
            
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location -JsonString $jsonString
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-recommendation.json'
            $jsonContent = @{
                targetStorageGiB = 1000
                targetIoPerSec = 3000
                targetThroughputMiBPerSec = 125
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location -JsonFilePath $jsonFilePath
            $config | Should -Not -BeNullOrEmpty
            
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $requestBody = @{
                targetStorageGiB = 1000
                targetIoPerSec = 3000
                targetThroughputMiBPerSec = 125
            }
            $config = Get-AzFileShareProvisioningRecommendation -Location $env.location -Body $requestBody
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentityExpanded' {
        {
            $inputObj = @{ Location = $env.location }
            $config = Get-AzFileShareProvisioningRecommendation -InputObject $inputObj `
                                                                 -TargetStorageGiB 1000 `
                                                                 -TargetIoPerSec 3000 `
                                                                 -TargetThroughputMiBPerSec 125
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $inputObj = @{ Location = $env.location }
            $requestBody = @{
                targetStorageGiB = 1000
                targetIoPerSec = 3000
                targetThroughputMiBPerSec = 125
            }
            $config = Get-AzFileShareProvisioningRecommendation -InputObject $inputObj -Body $requestBody
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
