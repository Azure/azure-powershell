if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFileShareNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFileShareNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFileShareNameAvailability' {
    It 'CheckExpanded' {
        {
            $config = Test-AzFileShareNameAvailability -Location $env.location -Name "testshare-available" -Type "Microsoft.FileShares/fileShares"
            $config.NameAvailable | Should -Be $true
        } | Should -Not -Throw
    }

    It 'CheckViaJsonString' {
        {
            $jsonString = @{
                name = "testshare-json"
                type = "Microsoft.FileShares/fileShares"
            } | ConvertTo-Json -Depth 10
            
            $config = Test-AzFileShareNameAvailability -Location $env.location -JsonString $jsonString
            $config.NameAvailable | Should -Be $true
        } | Should -Not -Throw
    }

    It 'CheckViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-availability.json'
            $jsonContent = @{
                name = "testshare-file"
                type = "Microsoft.FileShares/fileShares"
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $config = Test-AzFileShareNameAvailability -Location $env.location -JsonFilePath $jsonFilePath
            $config.NameAvailable | Should -Be $true
            
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Check' {
        {
            $requestBody = @{
                name = "testshare-body"
                type = "Microsoft.FileShares/fileShares"
            }
            $config = Test-AzFileShareNameAvailability -Location $env.location -Body $requestBody
            $config.NameAvailable | Should -Be $true
        } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' {
        {
            $inputObj = @{ 
                Location = $env.location
                SubscriptionId = $env.SubscriptionId
            }
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareIdentity]$inputObj
            $config = Test-AzFileShareNameAvailability -InputObject $identity -Name "testshare-identity" -Type "Microsoft.FileShares/fileShares"
            $config.NameAvailable | Should -Be $true
        } | Should -Not -Throw
    }

    It 'CheckViaIdentity' {
        {
            $inputObj = @{ 
                Location = $env.location
                SubscriptionId = $env.SubscriptionId
            }
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareIdentity]$inputObj
            $requestBody = @{
                name = "testshare-identity-body"
                type = "Microsoft.FileShares/fileShares"
            }
            $config = Test-AzFileShareNameAvailability -InputObject $identity -Body $requestBody
            $config.NameAvailable | Should -Be $true
        } | Should -Not -Throw
    }
}
