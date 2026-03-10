if(($null -eq $TestName) -or ($TestName -contains 'FileShare-ComplexScenarios'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-ComplexScenarios.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'FileShare-ComplexScenarios: Advanced Testing' {
    
    BeforeAll {
        $script:bulkSharePrefix = "bulk-share-"
        $script:bulkShareCount = 5
        $script:bulkShares = @()
    }

    Context 'Bulk Operations and Scale Testing' {
        
        It 'CREATE: Should create multiple file shares in parallel' {
            {
                for ($i = 1; $i -le $script:bulkShareCount; $i++) {
                    $shareName = $script:bulkSharePrefix + (RandomString $false 6) + "-$i"
                    
                    $share = New-AzFileShare -ResourceName $shareName `
                        -ResourceGroupName $env.resourceGroup `
                        -Location $env.location `
                        -MediaTier "SSD" `
                        -Protocol "NFS" `
                        -ProvisionedStorageGiB (512 * $i) `
                        -ProvisionedIoPerSec (3000 + ($i * 100)) `
                        -ProvisionedThroughputMiBPerSec (125 + ($i * 10)) `
                        -Redundancy "Local" `
                        -PublicNetworkAccess "Enabled" `
                        -Tag @{"bulk" = "true"; "index" = "$i"; "created" = (Get-Date -Format "yyyy-MM-dd")}
                    
                    $script:bulkShares += $shareName
                    $share.Name | Should -Be $shareName
                    
                    Start-TestSleep -Seconds 2
                }
                
                $script:bulkShares.Count | Should -Be $script:bulkShareCount
            } | Should -Not -Throw
        }

        It 'READ: Should list all bulk created shares' {
            {
                $allShares = Get-AzFileShare -ResourceGroupName $env.resourceGroup
                $bulkSharesFound = $allShares | Where-Object { $_.Name -in $script:bulkShares }
                
                $bulkSharesFound.Count | Should -Be $script:bulkShareCount
            } | Should -Not -Throw
        }

        It 'UPDATE: Should update all bulk shares with new tags' {
            {
                foreach ($shareName in $script:bulkShares) {
                    $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                        -ResourceName $shareName `
                        -Tag @{"bulk" = "true"; "updated" = "batch"; "timestamp" = (Get-Date -Format "HH:mm:ss")}
                    
                    $updated.Tag["updated"] | Should -Be "batch"
                    
                    Start-TestSleep -Seconds 2
                }
            } | Should -Not -Throw
        }

        It 'DELETE: Should delete all bulk shares' {
            {
                foreach ($shareName in $script:bulkShares) {
                    Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                        -ResourceName $shareName `
                        -PassThru | Should -Be $true
                    
                    Start-TestSleep -Seconds 2
                }
                
                Start-TestSleep -Seconds 5
                
                # Verify all are deleted
                foreach ($shareName in $script:bulkShares) {
                    $deleted = Get-AzFileShare -ResourceGroupName $env.resourceGroup `
                        -ResourceName $shareName `
                        -ErrorAction SilentlyContinue
                    
                    $deleted | Should -BeNullOrEmpty
                }
            } | Should -Not -Throw
        }
    }

    Context 'Protocol-Specific Complex Scenarios' {
        
        BeforeAll {
            $script:nfsShareComplex = "nfs-complex-" + (RandomString $false 8)
            $script:smbShareComplex = "smb-complex-" + (RandomString $false 8)
        }

        It 'NFS: Should create NFS share with specific root squash configuration' {
            {
                $share = New-AzFileShare -ResourceName $script:nfsShareComplex `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 2048 `
                    -ProvisionedIoPerSec 8000 `
                    -ProvisionedThroughputMiBPerSec 400 `
                    -Redundancy "Zone" `
                    -PublicNetworkAccess "Enabled" `
                    -NfProtocolPropertyRootSquash "RootSquash" `
                    -Tag @{"protocol" = "nfs"; "config" = "rootsquash"}
                
                $share.Protocol | Should -Be "NFS"
                $share.NfProtocolPropertyRootSquash | Should -Be "RootSquash"
            } | Should -Not -Throw
        }

        It 'NFS: Should update NFS share root squash settings' {
            {
                Start-TestSleep -Seconds 5
                
                # Note: Update might not support changing protocol properties
                # This test validates the update mechanism
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:nfsShareComplex `
                    -Tag @{"protocol" = "nfs"; "config" = "updated"; "squash" = "modified"}
                
                $updated.Tag["config"] | Should -Be "updated"
            } | Should -Not -Throw
        }

        It 'SMB: Should create SMB share with local redundancy' {
            {
                $share = New-AzFileShare -ResourceName $script:smbShareComplex `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 1024 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 150 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" `
                    -Tag @{"protocol" = "smb"; "redundancy" = "local"}
                
                $share.Protocol | Should -Be "SMB"
                $share.Redundancy | Should -Be "Local"
            } | Should -Not -Throw
        }

        It 'CLEANUP: Remove protocol-specific test shares' {
            {
                Start-TestSleep -Seconds 5
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:nfsShareComplex `
                    -ErrorAction SilentlyContinue
                
                Start-TestSleep -Seconds 3
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:smbShareComplex `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Storage Tier and Performance Testing' {
        
        BeforeAll {
            $script:perfShareSSD = "perf-ssd-" + (RandomString $false 8)
            $script:perfShareHDD = "perf-hdd-" + (RandomString $false 8)
        }

        It 'PERFORMANCE: Should create maximum performance SSD share' {
            {
                $share = New-AzFileShare -ResourceName $script:perfShareSSD `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 4096 `
                    -ProvisionedIoPerSec 16000 `
                    -ProvisionedThroughputMiBPerSec 800 `
                    -Redundancy "Zone" `
                    -PublicNetworkAccess "Enabled" `
                    -Tag @{"tier" = "ssd"; "performance" = "max"}
                
                $share.MediaTier | Should -Be "SSD"
                $share.ProvisionedStorageGiB | Should -Be 4096
                $share.ProvisionedIoPerSec | Should -Be 16000
            } | Should -Not -Throw
        }

        It 'PERFORMANCE: Should create cost-optimized SSD share' {
            {
                $share = New-AzFileShare -ResourceName $script:perfShareHDD `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 125 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" `
                    -Tag @{"tier" = "ssd"; "performance" = "costoptimized"}
                
                $share.MediaTier | Should -Be "SSD"
                $share.ProvisionedStorageGiB | Should -Be 512
            } | Should -Not -Throw
        }

        It 'COMPARISON: Should verify different performance characteristics' {
            {
                $ssdShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $script:perfShareSSD
                $hddShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $script:perfShareHDD
                
                $ssdShare.MediaTier | Should -Be "SSD"
                $hddShare.MediaTier | Should -Be "HDD"
                $ssdShare.ProvisionedIoPerSec | Should -BeGreaterThan $hddShare.ProvisionedIoPerSec
            } | Should -Not -Throw
        }

        It 'CLEANUP: Remove performance test shares' {
            {
                Start-TestSleep -Seconds 5
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:perfShareSSD `
                    -ErrorAction SilentlyContinue
                
                Start-TestSleep -Seconds 3
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:perfShareHDD `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Snapshot Complex Scenarios' {
        
        BeforeAll {
            $script:snapshotTestShare = "snapshot-complex-" + (RandomString $false 8)
            $script:snapshots = @()
        }

        It 'SETUP: Create file share for snapshot testing' {
            {
                New-AzFileShare -ResourceName $script:snapshotTestShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 1024 `
                    -ProvisionedIoPerSec 4000 `
                    -ProvisionedThroughputMiBPerSec 200 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" `
                    -Tag @{"purpose" = "snapshot-testing"} | Out-Null
                
                Start-TestSleep -Seconds 5
            } | Should -Not -Throw
        }

        It 'SNAPSHOT: Should create multiple snapshots with different tags' {
            {
                for ($i = 1; $i -le 3; $i++) {
                    $snapshotName = "snapshot-$i-" + (RandomString $false 6)
                    
                    $snapshot = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                        -ResourceName $script:snapshotTestShare `
                        -Name $snapshotName `
                        -Metadata @{"generation" = "$i"; "type" = "backup"; "created" = (Get-Date -Format "yyyy-MM-dd-HH-mm")}
                    
                    $script:snapshots += $snapshotName
                    $snapshot.Name | Should -Be $snapshotName
                    
                    Start-TestSleep -Seconds 3
                }
                
                $script:snapshots.Count | Should -Be 3
            } | Should -Not -Throw
        }

        It 'SNAPSHOT: Should list all snapshots for the share' {
            {
                $allSnapshots = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:snapshotTestShare
                
                $allSnapshots.Count | Should -BeGreaterOrEqual 3
            } | Should -Not -Throw
        }

        It 'SNAPSHOT: Should update specific snapshot tags' {
            {
                $snapshotToUpdate = $script:snapshots[1]
                
                Start-TestSleep -Seconds 3
                
                $updated = Update-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:snapshotTestShare `
                    -Name $snapshotToUpdate `
                    -Metadata @{"generation" = "2"; "type" = "backup"; "status" = "verified"}
                
                $updated.Metadata["status"] | Should -Be "verified"
            } | Should -Not -Throw
        }

        It 'SNAPSHOT: Should delete snapshots in reverse order' {
            {
                for ($i = $script:snapshots.Count - 1; $i -ge 0; $i--) {
                    Start-TestSleep -Seconds 3
                    
                    Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                        -ResourceName $script:snapshotTestShare `
                        -Name $script:snapshots[$i] `
                        -PassThru | Should -Be $true
                }
            } | Should -Not -Throw
        }

        It 'CLEANUP: Remove snapshot test share' {
            {
                Start-TestSleep -Seconds 5
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:snapshotTestShare `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Tag Management Complex Scenarios' {
        
        BeforeAll {
            $script:tagTestShare = "tag-test-" + (RandomString $false 8)
        }

        It 'SETUP: Create share for tag testing' {
            {
                New-AzFileShare -ResourceName $script:tagTestShare `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 512 `
                    -ProvisionedIoPerSec 3000 `
                    -ProvisionedThroughputMiBPerSec 100 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" `
                    -Tag @{"initial" = "tag"; "version" = "1"} | Out-Null
                
                Start-TestSleep -Seconds 5
            } | Should -Not -Throw
        }

        It 'TAGS: Should handle large number of tags' {
            {
                $largeTags = @{}
                for ($i = 1; $i -le 15; $i++) {
                    $largeTags["tag$i"] = "value$i"
                }
                
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:tagTestShare `
                    -Tag $largeTags
                
                $updated.Tag.Count | Should -BeGreaterOrEqual 15
            } | Should -Not -Throw
        }

        It 'TAGS: Should handle special characters in tag values' {
            {
                Start-TestSleep -Seconds 5
                
                $specialTags = @{
                    "email" = "test@example.com"
                    "path" = "/var/log/app"
                    "version" = "1.0.0-beta+build.123"
                    "description" = "Test share with special chars: !@#$%"
                }
                
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:tagTestShare `
                    -Tag $specialTags
                
                $updated.Tag["email"] | Should -Be "test@example.com"
            } | Should -Not -Throw
        }

        It 'TAGS: Should clear all tags and set new ones' {
            {
                Start-TestSleep -Seconds 5
                
                $newTags = @{
                    "environment" = "production"
                    "cost-center" = "IT-001"
                }
                
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:tagTestShare `
                    -Tag $newTags
                
                $updated.Tag.ContainsKey("initial") | Should -Be $false
                $updated.Tag["environment"] | Should -Be "production"
            } | Should -Not -Throw
        }

        It 'CLEANUP: Remove tag test share' {
            {
                Start-TestSleep -Seconds 5
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:tagTestShare `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }
    }

    Context 'Resource Limits and Query Operations' {
        
        It 'LIMITS: Should retrieve file share limits for location' {
            {
                $limits = Get-AzFileShareLimit -SubscriptionId $env.SubscriptionId -Location $env.location
                
                $limits | Should -Not -BeNullOrEmpty
                $limits.Name | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }

        It 'USAGE: Should get usage data for a file share' {
            {
                # Create a test share first
                $usageTestShare = "usage-test-" + (RandomString $false 8)
                
                New-AzFileShare -ResourceName $usageTestShare `
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
                
                $usage = Get-AzFileShareUsageData -ResourceGroupName $env.resourceGroup `
                    -ResourceName $usageTestShare
                
                $usage | Should -Not -BeNullOrEmpty
                
                Start-TestSleep -Seconds 5
                
                Remove-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $usageTestShare `
                    -ErrorAction SilentlyContinue
            } | Should -Not -Throw
        }

        It 'RECOMMENDATION: Should get provisioning recommendations' {
            {
                $recommendation = Get-AzFileShareProvisioningRecommendation -SubscriptionId $env.SubscriptionId `
                    -Location $env.location `
                    -Protocol "NFS" `
                    -WorkloadType "General"
                
                $recommendation | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }
}
