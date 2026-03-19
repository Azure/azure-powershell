if(($null -eq $TestName) -or ($TestName -contains 'FileShare-Negative'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-Negative.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'FileShare-Negative' {
    
    BeforeAll {
        $script:testShareName = "negative-test-fixed01"
        $script:nonExistentShare = "does-not-exist-fixed01"
        $script:invalidNameShare = "Invalid@Name#123!"
    }

    Context 'Resource Not Found Scenarios' {
        
        It 'GET: Should return null when getting non-existent file share' {
            {
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:nonExistentShare `
                    -ErrorAction SilentlyContinue
                
                $share | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }

        It 'GET: Should throw proper error for non-existent resource group' {
            {
                Get-AzFileShare -ResourceGroupName "NonExistentResourceGroup123456" `
                    -ResourceName $script:testShareName `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'UPDATE: Should fail when updating non-existent file share' {
            {
                Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:nonExistentShare `
                    -Tag @{"test" = "fail"} `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'DELETE: Should handle deleting non-existent file share gracefully' {
            {
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:nonExistentShare `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'SNAPSHOT GET: Should return null for non-existent snapshot' {
            {
                # First create a share to test snapshot retrieval
                New-AzFileShare -ResourceName $script:testShareName `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 125 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" | Out-Null
                
                Start-TestSleep -Seconds 5
                
                $snapshot = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:testShareName `
                    -Name "non-existent-snapshot" `
                    -ErrorAction SilentlyContinue
                
                $snapshot | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }

    Context 'Invalid Parameter Scenarios' {
        
        It 'CREATE: Should fail with invalid location' {
            {
                New-AzFileShare -ResourceName "test-invalid-location" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location "InvalidLocation123" `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'CREATE: Should fail with invalid MediaTier value' {
            {
                New-AzFileShare -ResourceName "test-invalid-tier" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "InvalidTier" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'CREATE: Should fail with invalid Protocol value' {
            {
                New-AzFileShare -ResourceName "test-invalid-protocol" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "InvalidProtocol" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'CREATE: Should fail with storage size below minimum (if applicable)' {
            {
                New-AzFileShare -ResourceName "test-small-storage" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 1 `
                    -ProvisionedIoPerSec 100 `
                    -ProvisionedThroughputMiBPerSec 10 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'CREATE: Should fail with negative storage values' {
            {
                New-AzFileShare -ResourceName "test-negative-storage" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB -100 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }
    }

    Context 'Duplicate Resource Scenarios' {
        
        It 'CREATE: Should succeed when creating duplicate file share (idempotent)' {
            {
                # First creation should succeed
                $share1 = New-AzFileShare -ResourceName "duplicate-test-share" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 125 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                Start-TestSleep -Seconds 5
                
                # Second creation should succeed (idempotent PUT)
                $share2 = New-AzFileShare -ResourceName "duplicate-test-share" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
                
                $share2 | Should -Not -BeNullOrEmpty
                $share2.Name | Should -Be "duplicate-test-share"
            } | Should -Not -Throw
        }

        It 'CLEANUP: Remove duplicate test share' {
            {
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName "duplicate-test-share" `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Invalid JSON Input Scenarios' {
        
        It 'CREATE: Should fail with malformed JSON string' {
            {
                $malformedJson = '{ "location": "eastus", "properties": { "mediaTier": "SSD" '
                
                New-AzFileShare -ResourceName "test-bad-json" `
                    -ResourceGroupName $env.resourceGroup `
                    -JsonString $malformedJson `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'CREATE: Should fail with non-existent JSON file path' {
            {
                New-AzFileShare -ResourceName "test-missing-file" `
                    -ResourceGroupName $env.resourceGroup `
                    -JsonFilePath "C:\NonExistent\Path\file.json" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'UPDATE: Should fail with invalid JSON structure' {
            {
                $invalidJson = @{
                    invalidKey = @{
                        badStructure = "value"
                    }
                } | ConvertTo-Json
                
                Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:testShareName `
                    -JsonString $invalidJson `
                    -ErrorAction Stop
            } | Should -Throw
        }
    }

    Context 'Permission and Access Scenarios' {
        
        It 'Should handle operations with invalid subscription ID' {
            {
                Get-AzFileShare -SubscriptionId "00000000-0000-0000-0000-000000000000" `
                    -ErrorAction Stop
            } | Should -Throw
        }
    }

    Context 'Snapshot Error Scenarios' {
        
        It 'SNAPSHOT CREATE: Should fail creating snapshot for non-existent share' {
            {
                New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName "non-existent-share-for-snapshot" `
                    -Name "test-snapshot" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'SNAPSHOT DELETE: Should handle deleting non-existent snapshot' {
            {
                Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:testShareName `
                    -Name "non-existent-snapshot-delete" `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Name Validation Scenarios' {
        
        It 'Name Availability: Should check name availability for existing share' {
            {
                $result = Test-AzFileShareNameAvailability -SubscriptionId $env.SubscriptionId `
                    -Location $env.location `
                    -Name $script:testShareName `
                    -Type "Microsoft.FileShares/fileShares"
                
                $result.NameAvailable | Should -Be $false
                $result.Reason | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }

        It 'Name Availability: Should return available for unique name' {
            {
                $uniqueName = "unique-name-fixed-never-created-01"
                $result = Test-AzFileShareNameAvailability -SubscriptionId $env.SubscriptionId `
                    -Location $env.location `
                    -Name $uniqueName `
                    -Type "Microsoft.FileShares/fileShares"
                
                $result.NameAvailable | Should -Be $true
            } | Should -Not -Throw
        }
    }

    AfterAll {
        # Cleanup test resources
        Start-TestSleep -Seconds 5
        Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
            -ResourceName $script:testShareName `
            -ErrorAction SilentlyContinue
    }
}
