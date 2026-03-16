if(($null -eq $TestName) -or ($TestName -contains 'FileShare-PipelineTests'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-PipelineTests.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'FileShare-PipelineTests: Cmdlet Pipeline Interaction Tests' {
    
    BeforeAll {
        # Create base resources for pipeline tests
        $script:pipelineShare1 = "pipeline-share1-" + (RandomString $false 8)
        $script:pipelineShare2 = "pipeline-share2-" + (RandomString $false 8)
        $script:pipelineShare3 = "pipeline-share3-" + (RandomString $false 8)
        $script:pipelineShare4 = "pipeline-share4-" + (RandomString $false 8)
        $script:pipelineShare5 = "pipeline-share5-" + (RandomString $false 8)
        $script:pipelineSnapshot1 = "pipeline-snap1-" + (RandomString $false 8)
        $script:pipelineSnapshot2 = "pipeline-snap2-" + (RandomString $false 8)
        
        # Create test shares for pipeline operations
        New-AzFileShare -ResourceName $script:pipelineShare1 `
            -ResourceGroupName $env.resourceGroup `
            -Location $env.location `
            -MediaTier "SSD" `
            -Protocol "SMB" `
            -ProvisionedStorageGiB 512 `
            -Tag @{"pipeline" = "test1"; "stage" = "initial"}
            
        New-AzFileShare -ResourceName $script:pipelineShare2 `
            -ResourceGroupName $env.resourceGroup `
            -Location $env.location `
            -MediaTier "SSD" `
            -Protocol "SMB" `
            -ProvisionedStorageGiB 512 `
            -Tag @{"pipeline" = "test2"; "stage" = "initial"}
            
        New-AzFileShare -ResourceName $script:pipelineShare3 `
            -ResourceGroupName $env.resourceGroup `
            -Location $env.location `
            -MediaTier "SSD" `
            -Protocol "NFS" `
            -ProvisionedStorageGiB 512 `
            -NfProtocolPropertyRootSquash "RootSquash" `
            -Tag @{"pipeline" = "test3"; "stage" = "initial"; "protocol" = "nfs"}
    }

    # ==================== BASIC PIPELINE OPERATIONS ====================
    
    Context 'Basic Pipeline: Get -> Update' {
        
        It 'Should pipe Get-AzFileShare to Update-AzFileShare' {
            {
                $updated = Get-AzFileShare -ResourceName $script:pipelineShare1 `
                    -ResourceGroupName $env.resourceGroup | 
                    Update-AzFileShare -ProvisionedStorageGiB 768
                
                $updated | Should -Not -BeNullOrEmpty
                $updated.Property.ProvisionedStorageGiB | Should -Be 768
            } | Should -Not -Throw
        }
        
        It 'Should pipe Get-AzFileShare with filtering to Update-AzFileShare' {
            {
                # Get all shares with specific tag and update them
                $result = Get-AzFileShare -ResourceGroupName $env.resourceGroup | 
                    Where-Object { $_.Tag.ContainsKey('pipeline') -and $_.Tag['pipeline'] -eq 'test2' } |
                    Update-AzFileShare -Tag @{"pipeline" = "test2"; "stage" = "updated"; "timestamp" = (Get-Date -Format "yyyy-MM-dd")}
                
                $result | Should -Not -BeNullOrEmpty
                $result.Tag['stage'] | Should -Be 'updated'
                $result.Tag.ContainsKey('timestamp') | Should -Be $true
            } | Should -Not -Throw
        }
        
        It 'Should pipe Get-AzFileShare with Select-Object to Update-AzFileShare' {
            {
                # Select specific properties and pipe to update
                Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup | 
                    Select-Object -First 1 |
                    Update-AzFileShare -Tag @{"pipeline" = "test1"; "stage" = "selected-and-updated"}
            } | Should -Not -Throw
        }
    }

    Context 'Basic Pipeline: Get -> Remove' {
        
        It 'Should create and immediately remove a share through pipeline' {
            {
                # Create a temporary share
                $tempName = "pipeline-temp-" + (RandomString $false 8)
                New-AzFileShare -ResourceName $tempName `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 512
                
                # Get and remove through pipeline
                Get-AzFileShare -ResourceName $tempName -ResourceGroupName $env.resourceGroup | 
                    Remove-AzFileShare
                
                # Verify removal
                $exists = Get-AzFileShare -ResourceName $tempName -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue
                $exists | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }
        
        It 'Should pipe filtered results to Remove-AzFileShare' -Skip {
            # Skip by default - removes multiple resources
            {
                # Create shares with specific tag
                $temp1 = "pipeline-bulk-del1-" + (RandomString $false 8)
                $temp2 = "pipeline-bulk-del2-" + (RandomString $false 8)
                
                New-AzFileShare -ResourceName $temp1 -ResourceGroupName $env.resourceGroup `
                    -Location $env.location -MediaTier "SSD" -Protocol "SMB" `
                    -ProvisionedStorageGiB 512 -Tag @{"delete-me" = "yes"; "batch" = "1"}
                    
                New-AzFileShare -ResourceName $temp2 -ResourceGroupName $env.resourceGroup `
                    -Location $env.location -MediaTier "SSD" -Protocol "SMB" `
                    -ProvisionedStorageGiB 512 -Tag @{"delete-me" = "yes"; "batch" = "1"}
                
                # Filter and remove through pipeline
                Get-AzFileShare -ResourceGroupName $env.resourceGroup | 
                    Where-Object { $_.Tag.ContainsKey('delete-me') -and $_.Tag['delete-me'] -eq 'yes' } |
                    Remove-AzFileShare
                
                # Verify both removed
                $remaining = Get-AzFileShare -ResourceGroupName $env.resourceGroup | 
                    Where-Object { $_.Tag.ContainsKey('delete-me') }
                $remaining | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }

    # ==================== COMPLEX PIPELINE CHAINS ====================
    
    Context 'Complex Pipeline Chains' {
        
        It 'Should handle New -> Get -> Update -> Get chain' {
            {
                $chainName = "pipeline-chain-" + (RandomString $false 8)
                
                # New -> Get -> Update -> Get
                $final = New-AzFileShare -ResourceName $chainName `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "SMB" `
                    -ProvisionedStorageGiB 512 `
                    -Tag @{"stage" = "created"} |
                    Get-AzFileShare |
                    Update-AzFileShare -ProvisionedStorageGiB 768 -Tag @{"stage" = "updated"} |
                    Get-AzFileShare
                
                $final | Should -Not -BeNullOrEmpty
                $final.Property.ProvisionedStorageGiB | Should -Be 768
                $final.Tag['stage'] | Should -Be 'updated'
                
                # Cleanup
                Remove-AzFileShare -ResourceName $chainName -ResourceGroupName $env.resourceGroup
            } | Should -Not -Throw
        }
        
        It 'Should handle Get -> Update -> Get -> Update chain with multiple property changes' {
            {
                $result = Get-AzFileShare -ResourceName $script:pipelineShare2 -ResourceGroupName $env.resourceGroup |
                    Update-AzFileShare -ProvisionedStorageGiB 1024 |
                    Get-AzFileShare |
                    Update-AzFileShare -Tag @{"pipeline" = "test2"; "stage" = "multi-update"; "chain" = "complete"}
                
                $result | Should -Not -BeNullOrEmpty
                $result.Property.ProvisionedStorageGiB | Should -Be 1024
                $result.Tag['stage'] | Should -Be 'multi-update'
                $result.Tag['chain'] | Should -Be 'complete'
            } | Should -Not -Throw
        }
        
        It 'Should handle pipeline with ForEach-Object for batch operations' {
            {
                # Create multiple shares
                $shares = @()
                1..3 | ForEach-Object {
                    $name = "pipeline-batch$_-" + (RandomString $false 6)
                    $share = New-AzFileShare -ResourceName $name `
                        -ResourceGroupName $env.resourceGroup `
                        -Location $env.location `
                        -MediaTier "SSD" `
                        -Protocol "SMB" `
                        -ProvisionedStorageGiB 512 `
                        -Tag @{"batch" = "test"; "index" = "$_"}
                    $shares += $name
                }
                
                # Update all through pipeline with ForEach-Object
                $updated = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Tag.ContainsKey('batch') -and $_.Tag['batch'] -eq 'test' } |
                    ForEach-Object {
                        $_ | Update-AzFileShare -Tag @{
                            "batch" = "test"
                            "index" = $_.Tag['index']
                            "updated" = "true"
                            "timestamp" = (Get-Date -Format "yyyy-MM-dd")
                        }
                    }
                
                $updated | Should -Not -BeNullOrEmpty
                $updated.Count | Should -BeGreaterOrEqual 3
                $updated | ForEach-Object { $_.Tag['updated'] | Should -Be 'true' }
                
                # Cleanup
                $shares | ForEach-Object {
                    Remove-AzFileShare -ResourceName $_ -ResourceGroupName $env.resourceGroup
                }
            } | Should -Not -Throw
        }
    }

    # ==================== PIPELINE WITH FILTERING ====================
    
    Context 'Pipeline with Advanced Filtering' {
        
        It 'Should pipe with Where-Object for property-based filtering' {
            {
                # Filter shares by storage size
                $largeshares = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Property.ProvisionedStorageGiB -ge 768 }
                
                $largeshares | Should -Not -BeNullOrEmpty
                $largeshares | ForEach-Object {
                    $_.Property.ProvisionedStorageGiB | Should -BeGreaterOrEqual 768
                }
            } | Should -Not -Throw
        }
        
        It 'Should pipe with Where-Object for protocol-based filtering' {
            {
                # Filter NFS shares
                $nfsShares = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Property.Protocol -eq 'NFS' }
                
                $nfsShares | Should -Not -BeNullOrEmpty
                $nfsShares | ForEach-Object {
                    $_.Property.Protocol | Should -Be 'NFS'
                }
            } | Should -Not -Throw
        }
        
        It 'Should pipe with Select-Object for property selection' {
            {
                # Select specific properties
                $selected = Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup |
                    Select-Object -Property Name, Location, @{Name='StorageGB'; Expression={$_.Property.ProvisionedStorageGiB}}
                
                $selected | Should -Not -BeNullOrEmpty
                $selected.Name | Should -Not -BeNullOrEmpty
                $selected.Location | Should -Not -BeNullOrEmpty
                $selected.StorageGB | Should -BeGreaterThan 0
            } | Should -Not -Throw
        }
        
        It 'Should pipe with Sort-Object and Select-Object for top N query' {
            {
                # Get top 2 largest shares
                $topShares = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Sort-Object -Property {$_.Property.ProvisionedStorageGiB} -Descending |
                    Select-Object -First 2
                
                $topShares | Should -Not -BeNullOrEmpty
                if ($topShares.Count -gt 1) {
                    $topShares[0].Property.ProvisionedStorageGiB | 
                        Should -BeGreaterOrEqual $topShares[1].Property.ProvisionedStorageGiB
                }
            } | Should -Not -Throw
        }
    }

    # ==================== SNAPSHOT PIPELINE OPERATIONS ====================
    
    Context 'Snapshot Pipeline Operations' {
        
        It 'Should create snapshot from piped FileShare' {
            {
                $snapshot = Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup |
                    New-AzFileShareSnapshot -SnapshotName $script:pipelineSnapshot1
                
                $snapshot | Should -Not -BeNullOrEmpty
                $snapshot.Name | Should -Be $script:pipelineSnapshot1
            } | Should -Not -Throw
        }
        
        It 'Should pipe Get-AzFileShareSnapshot to Update-AzFileShareSnapshot' {
            {
                $updated = Get-AzFileShareSnapshot -ResourceName $script:pipelineShare1 `
                    -SnapshotName $script:pipelineSnapshot1 `
                    -ResourceGroupName $env.resourceGroup |
                    Update-AzFileShareSnapshot -Metadata @{"snapshot" = "piped"; "updated" = "true"}
                
                $updated | Should -Not -BeNullOrEmpty
                $updated.Tag['updated'] | Should -Be 'true'
            } | Should -Not -Throw
        }
        
        It 'Should create multiple snapshots through pipeline' {
            {
                # Create snapshots for multiple shares
                $sharesForSnaps = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Tag.ContainsKey('pipeline') -and $_.Name -match 'pipeline-share[12]' }
                
                $snapshots = $sharesForSnaps | ForEach-Object {
                    $snapName = "multi-snap-" + $_.Name.Substring($_.Name.Length - 8) + "-" + (RandomString $false 4)
                    $_ | New-AzFileShareSnapshot -SnapshotName $snapName
                }
                
                $snapshots | Should -Not -BeNullOrEmpty
                $snapshots.Count | Should -BeGreaterOrEqual 2
                
                # Cleanup snapshots
                for ($i = 0; $i -lt $snapshots.Count; $i++) {
                    Remove-AzFileShareSnapshot -ResourceName $sharesForSnaps[$i].Name `
                        -SnapshotName $snapshots[$i].Name -ResourceGroupName $env.resourceGroup
                }
            } | Should -Not -Throw
        }
        
        It 'Should pipe Get-AzFileShareSnapshot to Remove-AzFileShareSnapshot' {
            {
                # Create a temp snapshot to remove
                $tempSnap = "pipeline-temp-snap-" + (RandomString $false 8)
                New-AzFileShareSnapshot -ResourceName $script:pipelineShare1 `
                    -SnapshotName $tempSnap -ResourceGroupName $env.resourceGroup
                
                # Get and remove through pipeline
                Get-AzFileShareSnapshot -ResourceName $script:pipelineShare1 `
                    -SnapshotName $tempSnap -ResourceGroupName $env.resourceGroup |
                    Remove-AzFileShareSnapshot
                
                # Verify removal
                $exists = Get-AzFileShareSnapshot -ResourceName $script:pipelineShare1 `
                    -SnapshotName $tempSnap -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue
                $exists | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }

    # ==================== PARAMETER BINDING ====================
    
    Context 'Pipeline Parameter Binding' {
        
        It 'Should bind parameters by property name from pipeline' {
            {
                # Get share and update using property name binding
                $share = Get-AzFileShare -ResourceName $script:pipelineShare3 -ResourceGroupName $env.resourceGroup
                
                # Create custom object with property names matching cmdlet parameters
                $updateParams = [PSCustomObject]@{
                    ResourceName = $share.Name
                    ResourceGroupName = $env.resourceGroup
                    Tag = @{"binding" = "by-property-name"; "test" = "true"}
                }
                
                $updated = $updateParams | Update-AzFileShare
                $updated | Should -Not -BeNullOrEmpty
                $updated.Tag['binding'] | Should -Be 'by-property-name'
            } | Should -Not -Throw
        }
        
        It 'Should bind parameters by value from pipeline' {
            {
                # Direct object piping (by value)
                $result = Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup |
                    Update-AzFileShare -Tag @{"binding" = "by-value"; "direct" = "true"}
                
                $result | Should -Not -BeNullOrEmpty
                $result.Tag['binding'] | Should -Be 'by-value'
            } | Should -Not -Throw
        }
        
        It 'Should handle pipeline with explicit parameter passing' {
            {
                # Mix of pipeline and explicit parameters
                Get-AzFileShare -ResourceName $script:pipelineShare2 -ResourceGroupName $env.resourceGroup |
                    Update-AzFileShare -ProvisionedStorageGiB 1536 `
                        -Tag @{"explicit" = "params"; "mixed" = "true"} `
                        -ProvisionedIoPerSec 5000
            } | Should -Not -Throw
        }
    }

    # ==================== ERROR HANDLING IN PIPELINES ====================
    
    Context 'Pipeline Error Handling' {
        
        It 'Should handle errors in pipeline with -ErrorAction Continue' {
            {
                $results = @()
                $errors = @()
                
                # Create mix of valid and invalid resource names
                @($script:pipelineShare1, "nonexistent-share-999", $script:pipelineShare2) | ForEach-Object {
                    try {
                        $share = Get-AzFileShare -ResourceName $_ -ResourceGroupName $env.resourceGroup -ErrorAction Stop
                        $results += $share
                    } catch {
                        $errors += $_
                    }
                }
                
                $results.Count | Should -BeGreaterThan 0
                $errors.Count | Should -BeGreaterThan 0
            } | Should -Not -Throw
        }
        
        It 'Should stop pipeline on error with -ErrorAction Stop' {
            {
                # This should throw when hitting the non-existent share
                @($script:pipelineShare1, "nonexistent-share-999", $script:pipelineShare2) |
                    ForEach-Object {
                        Get-AzFileShare -ResourceName $_ -ResourceGroupName $env.resourceGroup -ErrorAction Stop
                    }
            } | Should -Throw
        }
        
        It 'Should silently continue with -ErrorAction SilentlyContinue' {
            {
                $results = @($script:pipelineShare1, "nonexistent-share-999", $script:pipelineShare2) |
                    ForEach-Object {
                        Get-AzFileShare -ResourceName $_ -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue
                    } | Where-Object { $null -ne $_ }
                
                # Should only get the valid shares
                $results.Count | Should -Be 2
            } | Should -Not -Throw
        }
        
        It 'Should handle validation errors early in pipeline' {
            {
                # Invalid storage size should fail before reaching API
                Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup |
                    Update-AzFileShare -ProvisionedStorageGiB 50000  # Exceeds max
            } | Should -Throw
        }
    }

    # ==================== PERFORMANCE AND BULK OPERATIONS ====================
    
    Context 'Bulk Operations Through Pipeline' {
        
        It 'Should handle bulk update through pipeline efficiently' -Skip {
            # Skip by default - creates many resources
            {
                $bulkShares = @()
                
                # Create 10 shares
                1..10 | ForEach-Object {
                    $name = "pipeline-bulk$_-" + (RandomString $false 6)
                    New-AzFileShare -ResourceName $name `
                        -ResourceGroupName $env.resourceGroup `
                        -Location $env.location `
                        -MediaTier "SSD" `
                        -Protocol "SMB" `
                        -ProvisionedStorageGiB 512 `
                        -Tag @{"bulk" = "true"; "index" = "$_"}
                    $bulkShares += $name
                }
                
                # Update all through pipeline
                $startTime = Get-Date
                Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Tag.ContainsKey('bulk') } |
                    Update-AzFileShare -Tag @{"bulk" = "true"; "updated" = "true"; "timestamp" = (Get-Date -Format "yyyy-MM-dd")}
                $duration = (Get-Date) - $startTime
                
                # Should complete in reasonable time
                $duration.TotalSeconds | Should -BeLessThan 120
                
                # Cleanup
                $bulkShares | ForEach-Object {
                    Remove-AzFileShare -ResourceName $_ -ResourceGroupName $env.resourceGroup
                }
            } | Should -Not -Throw
        }
        
        It 'Should handle pipeline with measure performance' {
            {
                # Measure pipeline performance
                $measured = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Tag.ContainsKey('pipeline') } |
                    Measure-Object
                
                $measured.Count | Should -BeGreaterThan 0
            } | Should -Not -Throw
        }
    }

    # ==================== CROSS-RESOURCE PIPELINES ====================
    
    Context 'Cross-Resource Pipeline Operations' {
        
        It 'Should pipe FileShare information to create Snapshots' {
            {
                # Get multiple shares and create snapshots for each
                $snapshots = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Name -match 'pipeline-share[12]' } |
                    ForEach-Object {
                        $snapName = "cross-snap-" + (RandomString $false 8)
                        New-AzFileShareSnapshot -ResourceName $_.Name `
                            -SnapshotName $snapName `
                            -ResourceGroupName $env.resourceGroup `
                            -Tag @{"source" = $_.Name; "created-via" = "pipeline"}
                    }
                
                $snapshots | Should -Not -BeNullOrEmpty
                $snapshots.Count | Should -BeGreaterOrEqual 2
                $snapshots | ForEach-Object { $_.Tag['created-via'] | Should -Be 'pipeline' }
                
                # Cleanup
                $snapshots | ForEach-Object {
                    Remove-AzFileShareSnapshot -ResourceName $_.Tag['source'] `
                        -SnapshotName $_.Name -ResourceGroupName $env.resourceGroup
                }
            } | Should -Not -Throw
        }
        
        It 'Should use pipeline to aggregate information across resources' {
            {
                # Get total provisioned storage across all shares
                $totalStorage = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Measure-Object -Property {$_.Property.ProvisionedStorageGiB} -Sum
                
                $totalStorage.Sum | Should -BeGreaterThan 0
            } | Should -Not -Throw
        }
        
        It 'Should group resources through pipeline' {
            {
                # Group shares by protocol
                $grouped = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Group-Object -Property {$_.Property.Protocol}
                
                $grouped | Should -Not -BeNullOrEmpty
                $grouped | ForEach-Object { $_.Name | Should -Match '^(SMB|NFS)$' }
            } | Should -Not -Throw
        }
    }

    # ==================== ADVANCED PIPELINE SCENARIOS ====================
    
    Context 'Advanced Pipeline Scenarios' {
        
        It 'Should handle pipeline with Tee-Object for dual output' {
            {
                $captured = $null
                Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup |
                    Tee-Object -Variable captured |
                    Update-AzFileShare -Tag @{"tee" = "test"; "captured" = "true"}
                
                $captured | Should -Not -BeNullOrEmpty
                $captured.Name | Should -Be $script:pipelineShare1
            } | Should -Not -Throw
        }
        
        It 'Should handle pipeline with Out-GridView -PassThru simulation' {
            {
                # Simulate interactive selection (without actual GUI)
                $selected = Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                    Where-Object { $_.Tag.ContainsKey('pipeline') } |
                    Select-Object -First 2  # Simulates user selection
                
                $updated = $selected | Update-AzFileShare -Tag @{"selected" = "true"; "interactive" = "simulated"}
                $updated | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }
        
        It 'Should handle pipeline with Export-Csv and Import-Csv workflow' {
            {
                $csvPath = Join-Path $env:TEMP "fileshare-export-$(Get-Random).csv"
                
                try {
                    # Export to CSV
                    Get-AzFileShare -ResourceGroupName $env.resourceGroup |
                        Select-Object Name, Location, @{N='Protocol';E={$_.Property.Protocol}}, `
                            @{N='StorageGiB';E={$_.Property.ProvisionedStorageGiB}} |
                        Export-Csv -Path $csvPath -NoTypeInformation
                    
                    # Import and verify
                    $imported = Import-Csv -Path $csvPath
                    $imported | Should -Not -BeNullOrEmpty
                    $imported[0].Name | Should -Not -BeNullOrEmpty
                    $imported[0].Protocol | Should -Match '^(SMB|NFS)$'
                } finally {
                    if (Test-Path $csvPath) {
                        Remove-Item $csvPath -Force
                    }
                }
            } | Should -Not -Throw
        }
        
        It 'Should handle pipeline with ConvertTo-Json and ConvertFrom-Json' {
            {
                # Export as JSON
                $json = Get-AzFileShare -ResourceName $script:pipelineShare1 -ResourceGroupName $env.resourceGroup |
                    Select-Object Name, Location, Tag, Property |
                    ConvertTo-Json -Depth 5
                
                $json | Should -Not -BeNullOrEmpty
                
                # Re-import and verify
                $restored = $json | ConvertFrom-Json
                $restored.Name | Should -Be $script:pipelineShare1
                $restored.Tag | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }

    # ==================== CLEANUP ====================
    
    AfterAll {
        # Remove test snapshots
        try {
            Remove-AzFileShareSnapshot -ResourceName $script:pipelineShare1 `
                -SnapshotName $script:pipelineSnapshot1 `
                -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue
        } catch {
            Write-Host "Snapshot cleanup error (expected if not created): $_"
        }
        
        # Remove test shares in reverse order
        @($script:pipelineShare5, $script:pipelineShare4, $script:pipelineShare3, 
          $script:pipelineShare2, $script:pipelineShare1) | ForEach-Object {
            try {
                Remove-AzFileShare -ResourceName $_ -ResourceGroupName $env.resourceGroup -ErrorAction SilentlyContinue
            } catch {
                Write-Host "Share cleanup error for $_`: $($_.Exception.Message)"
            }
        }
        
        Write-Host "Pipeline tests cleanup completed" -ForegroundColor Green
    }
}
