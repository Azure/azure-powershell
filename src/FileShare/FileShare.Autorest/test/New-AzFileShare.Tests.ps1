if(($null -eq $TestName) -or ($TestName -contains 'New-AzFileShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFileShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFileShare' {
    It 'CreateExpanded' {
        {
            $config = New-AzFileShare -ResourceName $env.fileShareName01 `
                                      -ResourceGroupName $env.resourceGroup `
                                      -Location $env.location `
                                      -MediaTier "SSD" `
                                      -Protocol "NFS" `
                                      -ProvisionedStorageGiB 1024 `
                                      -ProvisionedIoPerSec 4024 `
                                      -ProvisionedThroughputMiBPerSec 228 `
                                      -Redundancy "Local" `
                                      -PublicNetworkAccess "Enabled" `
                                      -NfProtocolPropertyRootSquash "NoRootSquash" `
                                      -Tag @{"environment" = "test"; "purpose" = "testing"}
            $config.Name | Should -Be $env.fileShareName01
            $config.ProvisioningState | Should -Be "Succeeded"
            $config.MediaTier | Should -Be "SSD"
            $config.Protocol | Should -Be "NFS"
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-fileshare.json'
            $jsonContent = @{
                location = $env.location
                properties = @{
                    mediaTier = "SSD"
                    protocol = "NFS"
                    provisionedStorageGiB = 1024
                    provisionedIoPerSec = 4024
                    provisionedThroughputMiBPerSec = 228
                    redundancy = "Local"
                    publicNetworkAccess = "Enabled"
                    nfProtocolProperties = @{
                        rootSquash = "NoRootSquash"
                    }
                }
                tags = @{
                    environment = "test"
                    method = "jsonfile"
                }
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $config = New-AzFileShare -ResourceName $env.fileShareName02 `
                                      -ResourceGroupName $env.resourceGroup `
                                      -JsonFilePath $jsonFilePath
            $config.Name | Should -Be $env.fileShareName02
            $config.ProvisioningState | Should -Be "Succeeded"
            
            # Clean up JSON file
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            $jsonString = @{
                location = $env.location
                properties = @{
                    mediaTier = "SSD"
                    protocol = "NFS"
                    provisionedStorageGiB = 1024
                    provisionedIoPerSec = 4024
                    provisionedThroughputMiBPerSec = 228
                    redundancy = "Local"
                    publicNetworkAccess = "Enabled"
                    nfProtocolProperties = @{
                        rootSquash = "NoRootSquash"
                    }
                }
                tags = @{
                    environment = "test"
                    method = "jsonstring"
                }
            } | ConvertTo-Json -Depth 10
            
            $config = New-AzFileShare -ResourceName $env.fileShareName03 `
                                      -ResourceGroupName $env.resourceGroup `
                                      -JsonString $jsonString
            $config.Name | Should -Be $env.fileShareName03
            $config.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }
}
