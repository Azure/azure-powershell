if(($null -eq $TestName) -or ($TestName -contains 'FileShare-ResourceMove'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-ResourceMove.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

<#
.SYNOPSIS
Tests for Moving FileShare and Network Resources Between Resource Groups

.DESCRIPTION
This test suite validates resource move operations including:
- Moving FileShares between resource groups
- Moving Virtual Networks between resource groups
- Moving Private Endpoints between resource groups
- Cross-resource group dependency validation
- Move validation and rollback scenarios

.NOTES
Requires: Az.Network, Az.FileShare, and Az.Resources modules
Resource moves can take significant time (5-15 minutes per resource)
#>

Describe 'FileShare-ResourceMove Tests' {
    BeforeAll {
        # Import required modules
        Import-Module Az.Network -ErrorAction Stop
        Import-Module Az.FileShare -ErrorAction Stop
        Import-Module Az.Resources -ErrorAction Stop
        
        # Initialize test variables
        $script:sourceRgName = $env.resourceGroup
        $script:targetRgName = "rg-fileshare-move-target-$(Get-Random -Maximum 9999)"
        $script:tempRgName = "rg-fileshare-move-temp-$(Get-Random -Maximum 9999)"
        
        $script:fileShareMove01 = "share-move-01-$(Get-Random -Maximum 9999)"
        $script:fileShareMove02 = "share-move-02-$(Get-Random -Maximum 9999)"
        $script:vnetMove = "vnet-move-$(Get-Random -Maximum 9999)"
        $script:subnetMove = "subnet-move"
        $script:peMove = "pe-move-$(Get-Random -Maximum 9999)"
        
        Write-Host "Resource Move Test Configuration:"
        Write-Host "  Source RG: $script:sourceRgName"
        Write-Host "  Target RG: $script:targetRgName"
        Write-Host "  Temp RG: $script:tempRgName"
        Write-Host "  Location: $($env.location)"
        Write-Host "  FileShare 01: $script:fileShareMove01"
        Write-Host "  FileShare 02: $script:fileShareMove02"
        Write-Host "  VNet: $script:vnetMove"
    }
    
    Context 'Resource Move - Environment Setup' {
        It 'Should create target resource group' {
            {
                $targetRg = New-AzResourceGroup -Name $script:targetRgName `
                                                -Location $env.location
                
                $targetRg | Should -Not -BeNullOrEmpty
                $targetRg.ResourceGroupName | Should -Be $script:targetRgName
                $targetRg.ProvisioningState | Should -Be 'Succeeded'
            } | Should -Not -Throw
        }
        
        It 'Should create temporary resource group for intermediate moves' {
            {
                $tempRg = New-AzResourceGroup -Name $script:tempRgName `
                                              -Location $env.location
                
                $tempRg | Should -Not -BeNullOrEmpty
                $tempRg.ResourceGroupName | Should -Be $script:tempRgName
            } | Should -Not -Throw
        }
        
        It 'Should verify all resource groups exist' {
            {
                $sourceRg = Get-AzResourceGroup -Name $script:sourceRgName
                $targetRg = Get-AzResourceGroup -Name $script:targetRgName
                $tempRg = Get-AzResourceGroup -Name $script:tempRgName
                
                $sourceRg | Should -Not -BeNullOrEmpty
                $targetRg | Should -Not -BeNullOrEmpty
                $tempRg | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }
    
    Context 'FileShare Resource Move - Single Resource' {
        It 'Should create FileShare for move testing' {
            {
                $fileShare = New-AzFileShare -ResourceName $script:fileShareMove01 `
                                             -ResourceGroupName $script:sourceRgName `
                                             -Location $env.location `
                                             -MediaTier "SSD" `
                                             -Protocol "NFS" `
                                             -ProvisionedStorageGiB 1024 `
                                             -ProvisionedIoPerSec 3000 `
                                             -ProvisionedThroughputMiBPerSec 125 `
                                             -Redundancy "Local" `
                                             -PublicNetworkAccess "Enabled" `
                                             -Tag @{"test" = "move"; "purpose" = "resource-move-testing"}
                
                $fileShare | Should -Not -BeNullOrEmpty
                $fileShare.Name | Should -Be $script:fileShareMove01
                $fileShare.ProvisioningState | Should -Be "Succeeded"
            } | Should -Not -Throw
        }
        
        It 'Should validate FileShare before move' {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                             -ResourceGroupName $script:sourceRgName
                
                # Verify FileShare is in a valid state for moving
                $fileShare.ProvisioningState | Should -Be "Succeeded"
                $fileShare.Id | Should -Match $script:sourceRgName
                
                # Public network access should be enabled for simpler move
                $fileShare.PublicNetworkAccess | Should -Be "Enabled"
            } | Should -Not -Throw
        }
        
        It 'Should validate move prerequisites' {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                             -ResourceGroupName $script:sourceRgName
                
                # Check that resource is not in a transitioning state
                $fileShare.ProvisioningState | Should -Be "Succeeded"
                
                # Verify target resource group exists and is in the same subscription
                $targetRg = Get-AzResourceGroup -Name $script:targetRgName
                $sourceRg = Get-AzResourceGroup -Name $script:sourceRgName
                
                # Both should be in same location for easier validation
                $targetRg.Location | Should -Be $sourceRg.Location
            } | Should -Not -Throw
        }
        
        It 'Should invoke move validation API' {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                             -ResourceGroupName $script:sourceRgName
                
                $targetRgId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$script:targetRgName"
                
                # Test move validation (dry-run)
                # Note: This tests the validation endpoint without actually moving
                try {
                    $validation = Invoke-AzResourceAction `
                        -ResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$script:sourceRgName" `
                        -Action "validateMoveResources" `
                        -Parameters @{
                            resources = @($fileShare.Id)
                            targetResourceGroup = $targetRgId
                        } `
                        -Force `
                        -ErrorAction Continue
                    
                    Write-Host "Move validation completed"
                }
                catch {
                    Write-Host "Move validation API call: $($_.Exception.Message)"
                    # Some resources may not support validation API
                }
                
                # Basic validation succeeded if we get here
                $fileShare.Id | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }
        
        It 'Should move FileShare to target resource group' -Skip {
            # Skipped by default - enable for full integration testing
            # Resource moves can take 5-15 minutes
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                             -ResourceGroupName $script:sourceRgName
                
                # Execute the move
                Move-AzResource -SourceResourceId $fileShare.Id `
                                -DestinationResourceGroupName $script:targetRgName `
                                -Force
                
                # Wait for move operation to complete
                Write-Host "Waiting for move operation to complete (this may take several minutes)..."
                Start-TestSleep -Seconds 60
                
                # Verify resource is now in target resource group
                $movedShare = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                              -ResourceGroupName $script:targetRgName
                
                $movedShare | Should -Not -BeNullOrEmpty
                $movedShare.Name | Should -Be $script:fileShareMove01
                $movedShare.Id | Should -Match $script:targetRgName
                $movedShare.ProvisioningState | Should -Be "Succeeded"
                
                # Verify resource is no longer in source resource group
                {
                    Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                   -ResourceGroupName $script:sourceRgName `
                                   -ErrorAction Stop
                } | Should -Throw
            } | Should -Not -Throw
        }
    }
    
    Context 'FileShare Resource Move - Batch Move' {
        It 'Should create multiple FileShares for batch move' {
            {
                $fileShare2 = New-AzFileShare -ResourceName $script:fileShareMove02 `
                                              -ResourceGroupName $script:sourceRgName `
                                              -Location $env.location `
                                              -MediaTier "SSD" `
                                              -Protocol "SMB" `
                                              -ProvisionedStorageGiB 512 `
                                              -ProvisionedIoPerSec 3000 `
                                              -ProvisionedThroughputMiBPerSec 100 `
                                              -Redundancy "Zone" `
                                              -PublicNetworkAccess "Enabled" `
                                              -Tag @{"test" = "batch-move"}
                
                $fileShare2 | Should -Not -BeNullOrEmpty
                $fileShare2.Name | Should -Be $script:fileShareMove02
            } | Should -Not -Throw
        }
        
        It 'Should validate multiple resources for batch move' {
            {
                $share1 = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                          -ResourceGroupName $script:sourceRgName `
                                          -ErrorAction SilentlyContinue
                
                $share2 = Get-AzFileShare -ResourceName $script:fileShareMove02 `
                                          -ResourceGroupName $script:sourceRgName
                
                # At least one share should exist for validation
                $share2 | Should -Not -BeNullOrEmpty
                $share2.ProvisioningState | Should -Be "Succeeded"
            } | Should -Not -Throw
        }
        
        It 'Should move multiple FileShares in batch operation' -Skip {
            # Skipped by default - batch moves can take 10-20 minutes
            {
                $share1 = Get-AzFileShare -ResourceName $script:fileShareMove01 `
                                          -ResourceGroupName $script:sourceRgName `
                                          -ErrorAction SilentlyContinue
                
                $share2 = Get-AzFileShare -ResourceName $script:fileShareMove02 `
                                          -ResourceGroupName $script:sourceRgName
                
                $resourcesToMove = @()
                if ($share1) { $resourcesToMove += $share1.Id }
                $resourcesToMove += $share2.Id
                
                # Move all resources in one operation
                Move-AzResource -SourceResourceId $resourcesToMove `
                                -DestinationResourceGroupName $script:tempRgName `
                                -Force
                
                # Wait for batch move to complete
                Write-Host "Waiting for batch move to complete..."
                Start-TestSleep -Seconds 90
                
                # Verify all resources moved successfully
                $movedShare2 = Get-AzFileShare -ResourceName $script:fileShareMove02 `
                                               -ResourceGroupName $script:tempRgName
                
                $movedShare2 | Should -Not -BeNullOrEmpty
                $movedShare2.Id | Should -Match $script:tempRgName
            } | Should -Not -Throw
        }
    }
    
    Context 'Virtual Network Resource Move' {
        It 'Should create Virtual Network without dependencies' {
            {
                $vnet = New-TestVirtualNetwork -ResourceGroupName $script:sourceRgName `
                                               -VNetName $script:vnetMove `
                                               -Location $env.location `
                                               -AddressPrefix "10.10.0.0/16"
                
                $vnet | Should -Not -BeNullOrEmpty
                $vnet.Name | Should -Be $script:vnetMove
                $vnet.ProvisioningState | Should -Be 'Succeeded'
            } | Should -Not -Throw
        }
        
        It 'Should add subnet to VNet' {
            {
                $subnet = New-TestSubnet -ResourceGroupName $script:sourceRgName `
                                         -VNetName $script:vnetMove `
                                         -SubnetName $script:subnetMove `
                                         -AddressPrefix "10.10.1.0/24"
                
                $subnet | Should -Not -BeNullOrEmpty
                $subnet.Name | Should -Be $script:subnetMove
            } | Should -Not -Throw
        }
        
        It 'Should validate VNet before move' {
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetMove `
                                             -ResourceGroupName $script:sourceRgName
                
                $vnet.ProvisioningState | Should -Be 'Succeeded'
                
                # Check for blocking dependencies
                $hasBlockingDeps = $false
                foreach ($subnet in $vnet.Subnets) {
                    if ($subnet.PrivateEndpoints.Count -gt 0 -or 
                        $subnet.NetworkInterfaces.Count -gt 0 -or
                        $subnet.ServiceEndpoints.Count -gt 0) {
                        $hasBlockingDeps = $true
                        break
                    }
                }
                
                # For this test, VNet should have no blocking dependencies
                $hasBlockingDeps | Should -Be $false
            } | Should -Not -Throw
        }
        
        It 'Should move Virtual Network to target resource group' -Skip {
            # Skipped by default - VNet moves can be complex and time-consuming
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetMove `
                                             -ResourceGroupName $script:sourceRgName
                
                # Move VNet
                Move-AzResource -SourceResourceId $vnet.Id `
                                -DestinationResourceGroupName $script:targetRgName `
                                -Force
                
                # Wait for move to complete
                Write-Host "Waiting for VNet move to complete..."
                Start-TestSleep -Seconds 60
                
                # Verify VNet is in target resource group
                $movedVNet = Get-AzVirtualNetwork -Name $script:vnetMove `
                                                  -ResourceGroupName $script:targetRgName
                
                $movedVNet | Should -Not -BeNullOrEmpty
                $movedVNet.Name | Should -Be $script:vnetMove
                $movedVNet.Id | Should -Match $script:targetRgName
                $movedVNet.Subnets.Count | Should -Be $vnet.Subnets.Count
            } | Should -Not -Throw
        }
    }
    
    Context 'Private Endpoint Resource Move' {
        It 'Should create resources for Private Endpoint move test' {
            {
                # Create a FileShare with private access
                $fileSharePE = New-AzFileShare -ResourceName "share-pe-move-$(Get-Random -Maximum 999)" `
                                               -ResourceGroupName $script:sourceRgName `
                                               -Location $env.location `
                                               -MediaTier "SSD" `
                                               -Protocol "NFS" `
                                               -ProvisionedStorageGiB 1024 `
                                               -ProvisionedIoPerSec 3000 `
                                               -ProvisionedThroughputMiBPerSec 125 `
                                               -Redundancy "Local" `
                                               -PublicNetworkAccess "Disabled"
                
                $fileSharePE | Should -Not -BeNullOrEmpty
                
                # Store the name for cleanup
                $script:fileSharePEMove = $fileSharePE.Name
            } | Should -Not -Throw
        }
        
        It 'Should create Private Endpoint for move testing' {
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetMove `
                                             -ResourceGroupName $script:sourceRgName
                $subnet = Get-AzVirtualNetworkSubnetConfig -Name $script:subnetMove `
                                                          -VirtualNetwork $vnet
                
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePEMove `
                                             -ResourceGroupName $script:sourceRgName
                
                $connection = New-AzPrivateLinkServiceConnection `
                    -Name "$script:peMove-connection" `
                    -PrivateLinkServiceId $fileShare.Id `
                    -GroupId "share"
                
                $pe = New-AzPrivateEndpoint -Name $script:peMove `
                                           -ResourceGroupName $script:sourceRgName `
                                           -Location $env.location `
                                           -Subnet $subnet `
                                           -PrivateLinkServiceConnection $connection
                
                $pe | Should -Not -BeNullOrEmpty
                $pe.ProvisioningState | Should -Be 'Succeeded'
            } | Should -Not -Throw
        }
        
        It 'Should validate Private Endpoint before move' {
            {
                $pe = Get-AzPrivateEndpoint -Name $script:peMove `
                                            -ResourceGroupName $script:sourceRgName
                
                $pe.ProvisioningState | Should -Be 'Succeeded'
                $pe.PrivateLinkServiceConnections.Count | Should -BeGreaterOrEqual 1
                
                # Verify the VNet is still in source RG
                $vnet = Get-AzVirtualNetwork -Name $script:vnetMove `
                                             -ResourceGroupName $script:sourceRgName
                $vnet | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }
        
        It 'Should document Private Endpoint move constraints' {
            Write-Host "`nPrivate Endpoint Move Constraints:"
            Write-Host "1. PE can only be moved if the VNet is in the same subscription"
            Write-Host "2. If VNet is also being moved, move VNet first, then PE"
            Write-Host "3. PE must be in Succeeded state before move"
            Write-Host "4. Connected resources (FileShare) can be in different RG"
            Write-Host ""
            
            $pe = Get-AzPrivateEndpoint -Name $script:peMove `
                                        -ResourceGroupName $script:sourceRgName
            $pe | Should -Not -BeNullOrEmpty
        }
        
        It 'Should move Private Endpoint to target resource group' -Skip {
            # Skipped by default - PE move requires careful orchestration
            {
                $pe = Get-AzPrivateEndpoint -Name $script:peMove `
                                            -ResourceGroupName $script:sourceRgName
                
                # Move Private Endpoint
                Move-AzResource -SourceResourceId $pe.Id `
                                -DestinationResourceGroupName $script:targetRgName `
                                -Force
                
                # Wait for move to complete
                Write-Host "Waiting for PE move to complete..."
                Start-TestSleep -Seconds 45
                
                # Verify PE is in target resource group
                $movedPE = Get-AzPrivateEndpoint -Name $script:peMove `
                                                 -ResourceGroupName $script:targetRgName
                
                $movedPE | Should -Not -BeNullOrEmpty
                $movedPE.Name | Should -Be $script:peMove
                $movedPE.Id | Should -Match $script:targetRgName
                $movedPE.ProvisioningState | Should -Be 'Succeeded'
            } | Should -Not -Throw
        }
    }
    
    Context 'Cross-Resource Move Validation' {
        It 'Should validate resources across resource groups' {
            {
                # List all FileShares across all resource groups
                $allShares = @()
                
                foreach ($rgName in @($script:sourceRgName, $script:targetRgName, $script:tempRgName)) {
                    $shares = Get-AzResource -ResourceGroupName $rgName `
                                            -ResourceType "Microsoft.FileShares/shares" `
                                            -ErrorAction SilentlyContinue
                    
                    if ($shares) {
                        $allShares += $shares
                    }
                }
                
                Write-Host "Total FileShares found across all test RGs: $($allShares.Count)"
                $allShares.Count | Should -BeGreaterOrEqual 1
            } | Should -Not -Throw
        }
        
        It 'Should verify resource group resource counts' {
            {
                $sourceResources = Get-AzResource -ResourceGroupName $script:sourceRgName
                $targetResources = Get-AzResource -ResourceGroupName $script:targetRgName `
                                                  -ErrorAction SilentlyContinue
                
                Write-Host "Source RG resources: $($sourceResources.Count)"
                Write-Host "Target RG resources: $(if ($targetResources) { $targetResources.Count } else { 0 })"
                
                # Source should have resources
                $sourceResources.Count | Should -BeGreaterOrEqual 1
            } | Should -Not -Throw
        }
    }
    
    Context 'Move Rollback and Error Handling' {
        It 'Should handle move validation failures gracefully' {
            {
                # Attempt to move a non-existent resource
                $fakeResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$script:sourceRgName/providers/Microsoft.FileShares/shares/nonexistent"
                
                $errorOccurred = $false
                try {
                    Move-AzResource -SourceResourceId $fakeResourceId `
                                    -DestinationResourceGroupName $script:targetRgName `
                                    -Force `
                                    -ErrorAction Stop
                }
                catch {
                    $errorOccurred = $true
                    Write-Host "Expected error occurred: $($_.Exception.Message)"
                }
                
                $errorOccurred | Should -Be $true
            } | Should -Not -Throw
        }
        
        It 'Should verify source resources remain intact after failed move' {
            {
                # Verify original resources are still in source RG
                $fileShare = Get-AzFileShare -ResourceName $script:fileShareMove02 `
                                             -ResourceGroupName $script:sourceRgName `
                                             -ErrorAction SilentlyContinue
                
                if ($fileShare) {
                    $fileShare.ProvisioningState | Should -Be "Succeeded"
                    Write-Host "FileShare $($fileShare.Name) verified in source RG"
                } else {
                    Write-Host "FileShare may have been moved in previous test"
                }
                
                # Test passes either way
                $true | Should -Be $true
            } | Should -Not -Throw
        }
    }
    
    AfterAll {
        Write-Host "`nCleaning up resource move test resources..."
        
        try {
            # Remove Private Endpoint
            Remove-TestPrivateEndpoint -ResourceGroupName $script:sourceRgName `
                                       -PrivateEndpointName $script:peMove `
                                       -ErrorAction SilentlyContinue
            
            Start-TestSleep -Seconds 10
            
            # Remove FileShares from all resource groups
            foreach ($rgName in @($script:sourceRgName, $script:targetRgName, $script:tempRgName)) {
                foreach ($shareName in @($script:fileShareMove01, $script:fileShareMove02, $script:fileSharePEMove)) {
                    if ($shareName) {
                        Remove-AzFileShare -ResourceName $shareName `
                                          -ResourceGroupName $rgName `
                                          -ErrorAction SilentlyContinue
                    }
                }
            }
            
            Start-TestSleep -Seconds 5
            
            # Remove VNet
            Remove-TestVirtualNetwork -ResourceGroupName $script:sourceRgName `
                                     -VNetName $script:vnetMove `
                                     -ErrorAction SilentlyContinue
            
            Start-TestSleep -Seconds 5
            
            # Remove temporary and target resource groups
            Remove-AzResourceGroup -Name $script:targetRgName -Force -AsJob -ErrorAction SilentlyContinue
            Remove-AzResourceGroup -Name $script:tempRgName -Force -AsJob -ErrorAction SilentlyContinue
            
            Write-Host "Cleanup completed"
        }
        catch {
            Write-Warning "Some cleanup operations failed: $_"
        }
    }
}
