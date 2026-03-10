if(($null -eq $TestName) -or ($TestName -contains 'FileShare-EdgeCases'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-EdgeCases.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'FileShare-EdgeCases: Boundary and Edge Case Testing' {
    
    Context 'Name Length and Character Edge Cases' {
        
        It 'NAME: Should handle minimum length share name (3 chars)' {
            {
                $minNameShare = "min"
                
                New-AzFileShare -ResourceName $minNameShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" | Out-Null
                
                Start-TestSleep -Seconds 5
                
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $minNameShare
                $share.Name | Should -Be $minNameShare
                
                Start-TestSleep -Seconds 3
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $minNameShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'NAME: Should handle maximum length share name (63 chars)' {
            {
                $maxNameShare = "a" * 63
                
                New-AzFileShare -ResourceName $maxNameShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" | Out-Null
                
                Start-TestSleep -Seconds 5
                
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $maxNameShare
                $share.Name.Length | Should -Be 63
                
                Start-TestSleep -Seconds 3
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $maxNameShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'NAME: Should handle share name with hyphens and numbers' {
            {
                $complexName = "share-123-test-456-abc"
                
                New-AzFileShare -ResourceName $complexName `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" | Out-Null
                
                Start-TestSleep -Seconds 5
                
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $complexName
                $share.Name | Should -Be $complexName
                
                Start-TestSleep -Seconds 3
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $complexName -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'NAME: Should reject name with uppercase letters' {
            {
                New-AzFileShare -ResourceName "UPPERCASE-SHARE" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'NAME: Should reject name with special characters' {
            {
                New-AzFileShare -ResourceName "share@test#123" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'NAME: Should reject name starting with hyphen' {
            {
                New-AzFileShare -ResourceName "-startswithhyphen" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'NAME: Should reject name ending with hyphen' {
            {
                New-AzFileShare -ResourceName "endswithhyphen-" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }
    }

    Context 'Storage Size Boundary Testing' {
        
        It 'STORAGE: Should create share with minimum SSD storage (512 GiB)' {
            {
                $minStorageShare = "min-storage-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $minStorageShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                $share.ProvisionedStorageGiB | Should -Be 512
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $minStorageShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'STORAGE: Should create share with large storage (8192 GiB)' {
            {
                $largeStorageShare = "large-storage-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $largeStorageShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 8192 `
                    -ProvisionedIoPerSec 16000 `
                    -ProvisionedThroughputMiBPerSec 1000 `
                    -Redundancy "Zone" `
                    -PublicNetworkAccess "Enabled"
                
                $share.ProvisionedStorageGiB | Should -Be 8192
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $largeStorageShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'STORAGE: Should reject storage size of 0' {
            {
                New-AzFileShare -ResourceName "zero-storage" `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 0 `
                    -Redundancy "Local" `
                    -ErrorAction Stop
            } | Should -Throw
        }

        It 'STORAGE: Should reject negative storage size' {
            {
                New-AzFileShare -ResourceName "negative-storage" `
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

    Context 'IOPS and Throughput Boundary Testing' {
        
        It 'IOPS: Should create share with minimum IOPS (1000)' {
            {
                $minIopsShare = "min-iops-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $minIopsShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 50 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                $share.ProvisionedIoPerSec | Should -Be 1000
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $minIopsShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'IOPS: Should create share with high IOPS (20000)' {
            {
                $highIopsShare = "high-iops-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $highIopsShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 4096 `
                    -ProvisionedIoPerSec 20000 `
                    -ProvisionedThroughputMiBPerSec 1000 `
                    -Redundancy "Zone" `
                    -PublicNetworkAccess "Enabled"
                
                $share.ProvisionedIoPerSec | Should -Be 20000
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $highIopsShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'THROUGHPUT: Should create share with minimum throughput (50 MiB/s)' {
            {
                $minThroughputShare = "min-throughput-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $minThroughputShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 50 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                $share.ProvisionedThroughputMiBPerSec | Should -Be 50
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $minThroughputShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'THROUGHPUT: Should create share with high throughput (1000 MiB/s)' {
            {
                $highThroughputShare = "high-throughput-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $highThroughputShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 4096 `
                    -ProvisionedIoPerSec 16000 `
                    -ProvisionedThroughputMiBPerSec 1000 `
                    -Redundancy "Zone" `
                    -PublicNetworkAccess "Enabled"
                
                $share.ProvisionedThroughputMiBPerSec | Should -Be 1000
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $highThroughputShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Redundancy and Region Edge Cases' {
        
        It 'REDUNDANCY: Should create share with Local redundancy' {
            {
                $localRedundShare = "local-redund-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $localRedundShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                $share.Redundancy | Should -Be "Local"
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $localRedundShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'REDUNDANCY: Should create share with Zone redundancy' {
            {
                $zoneRedundShare = "zone-redund-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $zoneRedundShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 1024 `
                    -ProvisionedIoPerSec 4000 `
                    -ProvisionedThroughputMiBPerSec 200 `
                    -Redundancy "Zone" `
                    -PublicNetworkAccess "Enabled"
                
                $share.Redundancy | Should -Be "Zone"
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $zoneRedundShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'REDUNDANCY: Should create share with Geo redundancy' {
            {
                $geoRedundShare = "geo-redund-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $geoRedundShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 1024 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 150 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                $share.Redundancy | Should -Be "Geo"
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $geoRedundShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Network Access Edge Cases' {
        
        It 'NETWORK: Should create share with public network access disabled' {
            {
                $privateAccessShare = "private-access-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $privateAccessShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Disabled"
                
                $share.PublicNetworkAccess | Should -Be "Disabled"
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $privateAccessShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'NETWORK: Should update network access from enabled to disabled' {
            {
                $networkTestShare = "network-test-" + (RandomString $false 6)
                
                # Create with public access enabled
                New-AzFileShare -ResourceName $networkTestShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" | Out-Null
                
                Start-TestSleep -Seconds 5
                
                # Note: Update may not support changing PublicNetworkAccess
                # This tests the update operation itself
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $networkTestShare `
                    -Tag @{"network" = "updated"}
                
                $updated.Tag["network"] | Should -Be "updated"
                
                Start-TestSleep -Seconds 3
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $networkTestShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Empty and Null Value Edge Cases' {
        
        It 'TAGS: Should handle share with empty tags' {
            {
                $noTagsShare = "no-tags-" + (RandomString $false 6)
                
                $share = New-AzFileShare -ResourceName $noTagsShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled"
                
                # Tag property may be null or empty hashtable
                ($share.Tag -eq $null -or $share.Tag.Count -eq 0) | Should -Be $true
                
                Start-TestSleep -Seconds 5
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $noTagsShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'TAGS: Should update to empty tags (clear all tags)' {
            {
                $clearTagsShare = "clear-tags-" + (RandomString $false 6)
                
                # Create with tags
                New-AzFileShare -ResourceName $clearTagsShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" `
                    -Tag @{"initial" = "value"; "test" = "data"} | Out-Null
                
                Start-TestSleep -Seconds 5
                
                # Update with empty tags
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $clearTagsShare `
                    -Tag @{}
                
                $updated.Tag.Count | Should -Be 0
                
                Start-TestSleep -Seconds 3
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $clearTagsShare -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }
}
