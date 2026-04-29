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
                                      -RootSquash "NoRootSquash" `
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
    
    It 'CreateUpdate FileShare With all parameters' {
        {
            # To run the test case in a clear enviroment, first create a subnet with following command and update "subnetId" in env.json 
            # $subnetId = (New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location "eastus2euap" -AddressPrefix 10.0.0.0/24 -Name $vnetName | Add-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix "10.0.0.0/28" -ServiceEndpoint "Microsoft.Storage"  | Set-AzVirtualNetwork).Id

            $config = New-AzFileShare -ResourceName $env.fileShareName04 `
                                      -ResourceGroupName $env.resourceGroup `
                                      -Location $env.location `
                                      -MediaTier "SSD" `
                                      -Protocol "NFS" `
                                      -ProvisionedStorageGiB 1024 `
                                      -ProvisionedIoPerSec 4024 `
                                      -ProvisionedThroughputMiBPerSec 228 `
                                      -Redundancy "Zone" `
                                      -PublicNetworkAccess "Enabled" `
                                      -RootSquash "NoRootSquash" `
                                      -AllowedSubnet $env.subnetId `
                                      -EncryptionInTransitRequired Enabled
            $config.Name | Should -Be $env.fileShareName04
            $config.ProvisioningState | Should -Be "Succeeded"
            $config.MediaTier | Should -Be "SSD"
            $config.Location | Should -Be $env.location
            $config.Protocol | Should -Be "NFS"
            $config.Redundancy | Should -Be "Zone"
            $config.ProvisionedStorageGiB | Should -Be 1024
            $config.ProvisionedIoPerSec | Should -Be 4024
            $config.ProvisionedThroughputMiBPerSec | Should -Be 228
            $config.PublicNetworkAccess | Should -Be "Enabled"
            $config.RootSquash | Should -Be "NoRootSquash"
            $config.AllowedSubnet.Count | Should -Be 1
            $config.AllowedSubnet[0] | Should -be $env.subnetId
            $config.EncryptionInTransitRequired | Should -Be "Enabled"

            $config = Get-AzFileShare -ResourceName $env.fileShareName04 `
                                   -ResourceGroupName $env.resourceGroup  
            $config.Name | Should -Be $env.fileShareName04
            $config.ProvisioningState | Should -Be "Succeeded"
            $config.Location | Should -Be $env.location
            $config.MediaTier | Should -Be "SSD"
            $config.Protocol | Should -Be "NFS"
            $config.Redundancy | Should -Be "Zone"
            $config.ProvisionedStorageGiB | Should -Be 1024
            $config.ProvisionedIoPerSec | Should -Be 4024
            $config.ProvisionedThroughputMiBPerSec | Should -Be 228
            $config.PublicNetworkAccess | Should -Be "Enabled"
            $config.RootSquash | Should -Be "NoRootSquash"
            $config.AllowedSubnet.Count | Should -Be 1
            $config.AllowedSubnet[0] | Should -be $env.subnetId
            $config.EncryptionInTransitRequired | Should -Be "Enabled" 

            $config = Update-AzFileShare -ResourceName $env.fileShareName04 `
                                      -ResourceGroupName $env.resourceGroup `
                                      -ProvisionedStorageGiB 1025 `
                                      -ProvisionedIoPerSec 5001 `
                                      -ProvisionedThroughputMiBPerSec 229 `
                                      -PublicNetworkAccess "Disabled" `
                                      -RootSquash "RootSquash" `
                                      -AllowedSubnet @() `
                                      -EncryptionInTransitRequired Disabled
            $config.Name | Should -Be $env.fileShareName04
            $config.ProvisioningState | Should -Be "Succeeded"
            $config.Location | Should -Be $env.location
            $config.MediaTier | Should -Be "SSD"
            $config.Protocol | Should -Be "NFS"
            $config.Redundancy | Should -Be "Zone"
            $config.ProvisionedStorageGiB | Should -Be 1025
            $config.ProvisionedIoPerSec | Should -Be 5001
            $config.ProvisionedThroughputMiBPerSec | Should -Be 229
            $config.PublicNetworkAccess | Should -Be "Disabled"
            $config.RootSquash | Should -Be "RootSquash"
            $config.AllowedSubnet.Count | Should -Be 0
            $config.EncryptionInTransitRequired | Should -Be "Disabled"

            
            $config = Get-AzFileShare -ResourceName $env.fileShareName04 `
                                   -ResourceGroupName $env.resourceGroup  
            $config.Name | Should -Be $env.fileShareName04
            $config.ProvisioningState | Should -Be "Succeeded"
            $config.Location | Should -Be $env.location
            $config.MediaTier | Should -Be "SSD"
            $config.Protocol | Should -Be "NFS"
            $config.Redundancy | Should -Be "Zone"
            $config.ProvisionedStorageGiB | Should -Be 1025
            $config.ProvisionedIoPerSec | Should -Be 5001
            $config.ProvisionedThroughputMiBPerSec | Should -Be 229
            $config.PublicNetworkAccess | Should -Be "Disabled"
            $config.RootSquash | Should -Be "RootSquash"
            $config.AllowedSubnet.Count | Should -Be 0
            $config.EncryptionInTransitRequired | Should -Be "Disabled"

            Remove-AzFileShare -ResourceName $env.fileShareName04 `
                               -ResourceGroupName $env.resourceGroup  

        } | Should -Not -Throw
    }
}
