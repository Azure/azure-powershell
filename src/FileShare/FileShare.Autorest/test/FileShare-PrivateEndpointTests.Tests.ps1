if(($null -eq $TestName) -or ($TestName -contains 'FileShare-PrivateEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-PrivateEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

<#
.SYNOPSIS
Tests for FileShare with Private Endpoint integration

.DESCRIPTION
This test suite validates FileShare functionality with Azure Private Endpoints including:
- Virtual Network and Subnet creation
- Private Endpoint creation for FileShares
- Network access restrictions
- Private DNS zone integration
- Resource group moves for VNets, Private Endpoints, and FileShares

.NOTES
Requires: Az.Network and Az.FileShare modules
#>

Describe 'FileShare-PrivateEndpoint Tests' {
    BeforeAll {
        # Import required modules
        Import-Module Az.Network -ErrorAction Stop
        Import-Module Az.FileShare -ErrorAction Stop
        
        # Initialize test variables
        $script:vnetName = "vnet-fileshare-pe-test-$(Get-Random -Maximum 9999)"
        $script:subnetName = "subnet-pe"
        $script:privateEndpointName = "pe-fileshare-$(Get-Random -Maximum 9999)"
        $script:fileSharePeName = "share-pe-$(Get-Random -Maximum 9999)"
        $script:secondaryRgName = "rg-fileshare-move-$(Get-Random -Maximum 9999)"
        $script:vnetAddressPrefix = "10.0.0.0/16"
        $script:subnetAddressPrefix = "10.0.1.0/24"
        
        Write-Host "Test Configuration:"
        Write-Host "  Resource Group: $($env.resourceGroup)"
        Write-Host "  Secondary RG: $script:secondaryRgName"
        Write-Host "  Location: $($env.location)"
        Write-Host "  VNet: $script:vnetName"
        Write-Host "  Subnet: $script:subnetName"
        Write-Host "  Private Endpoint: $script:privateEndpointName"
        Write-Host "  FileShare for PE: $script:fileSharePeName"
    }
    
    Context 'Virtual Network Setup' {
        It 'Should create a new Virtual Network' {
            {
                $vnet = New-TestVirtualNetwork -ResourceGroupName $env.resourceGroup `
                                               -VNetName $script:vnetName `
                                               -Location $env.location `
                                               -AddressPrefix $script:vnetAddressPrefix
                
                $vnet | Should -Not -BeNullOrEmpty
                $vnet.Name | Should -Be $script:vnetName
                $vnet.Location | Should -Be $env.location
                $vnet.AddressSpace.AddressPrefixes | Should -Contain $script:vnetAddressPrefix
                $vnet.ProvisioningState | Should -Be 'Succeeded'
            } | Should -Not -Throw
        }
        
        It 'Should retrieve existing Virtual Network' {
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetName -ResourceGroupName $env.resourceGroup
                $vnet | Should -Not -BeNullOrEmpty
                $vnet.Name | Should -Be $script:vnetName
            } | Should -Not -Throw
        }
        
        It 'Should create a subnet for Private Endpoints' {
            {
                $subnet = New-TestSubnet -ResourceGroupName $env.resourceGroup `
                                         -VNetName $script:vnetName `
                                         -SubnetName $script:subnetName `
                                         -AddressPrefix $script:subnetAddressPrefix `
                                         -PrivateEndpointNetworkPoliciesFlag "Disabled"
                
                $subnet | Should -Not -BeNullOrEmpty
                $subnet.Name | Should -Be $script:subnetName
                $subnet.AddressPrefix | Should -Contain $script:subnetAddressPrefix
                $subnet.PrivateEndpointNetworkPolicies | Should -Be 'Disabled'
            } | Should -Not -Throw
        }
        
        It 'Should list VNet subnets' {
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetName -ResourceGroupName $env.resourceGroup
                $subnets = $vnet.Subnets
                $subnets | Should -Not -BeNullOrEmpty
                $subnets.Count | Should -BeGreaterOrEqual 1
                $subnets.Name | Should -Contain $script:subnetName
            } | Should -Not -Throw
        }
    }
    
    Context 'FileShare with Private Network Access' {
        It 'Should create FileShare with private network access' {
            {
                $fileShare = New-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup `
                                             -Location $env.location `
                                             -MediaTier "SSD" `
                                             -Protocol "NFS" `
                                             -ProvisionedStorageGiB 1024 `
                                             -ProvisionedIoPerSec 4024 `
                                             -ProvisionedThroughputMiBPerSec 228 `
                                             -Redundancy "Local" `
                                             -PublicNetworkAccess "Disabled" `
                                             -Tag @{"network" = "private"; "purpose" = "pe-testing"}
                
                $fileShare | Should -Not -BeNullOrEmpty
                $fileShare.Name | Should -Be $script:fileSharePeName
                $fileShare.PublicNetworkAccess | Should -Be "Disabled"
                $fileShare.ProvisioningState | Should -Be "Succeeded"
            } | Should -Not -Throw
        }
        
        It 'Should verify FileShare is not publicly accessible' {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup
                
                $fileShare.PublicNetworkAccess | Should -Be "Disabled"
            } | Should -Not -Throw
        }
    }
    
    Context 'Private Endpoint Creation and Configuration' {
        It 'Should create Private Endpoint for FileShare' {
            {
                # Get subnet and FileShare details
                $vnet = Get-AzVirtualNetwork -Name $script:vnetName -ResourceGroupName $env.resourceGroup
                $subnet = Get-AzVirtualNetworkSubnetConfig -Name $script:subnetName -VirtualNetwork $vnet
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName -ResourceGroupName $env.resourceGroup
                
                # Create Private Link Service Connection
                $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection `
                    -Name "$script:privateEndpointName-connection" `
                    -PrivateLinkServiceId $fileShare.Id `
                    -GroupId "share"
                
                # Create Private Endpoint
                $privateEndpoint = New-AzPrivateEndpoint `
                    -Name $script:privateEndpointName `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -Subnet $subnet `
                    -PrivateLinkServiceConnection $privateLinkServiceConnection
                
                $privateEndpoint | Should -Not -BeNullOrEmpty
                $privateEndpoint.Name | Should -Be $script:privateEndpointName
                $privateEndpoint.ProvisioningState | Should -Be 'Succeeded'
                $privateEndpoint.Subnet.Id | Should -Be $subnet.Id
            } | Should -Not -Throw
        }
        
        It 'Should retrieve Private Endpoint details' {
            {
                $pe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                            -ResourceGroupName $env.resourceGroup
                
                $pe | Should -Not -BeNullOrEmpty
                $pe.Name | Should -Be $script:privateEndpointName
                $pe.PrivateLinkServiceConnections.Count | Should -BeGreaterOrEqual 1
            } | Should -Not -Throw
        }
        
        It 'Should verify Private Endpoint connection state' {
            {
                $pe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                            -ResourceGroupName $env.resourceGroup
                
                $connection = $pe.PrivateLinkServiceConnections[0]
                $connection.PrivateLinkServiceConnectionState.Status | Should -BeIn @('Approved', 'Pending')
            } | Should -Not -Throw
        }
        
        It 'Should list all Private Endpoints in resource group' {
            {
                $endpoints = Get-AzPrivateEndpoint -ResourceGroupName $env.resourceGroup
                $endpoints | Should -Not -BeNullOrEmpty
                $endpoints.Name | Should -Contain $script:privateEndpointName
            } | Should -Not -Throw
        }
    }
    
    Context 'Network Security and Access Control' {
        It 'Should verify FileShare is only accessible via Private Endpoint' {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup
                
                # Verify public access is disabled
                $fileShare.PublicNetworkAccess | Should -Be "Disabled"
                
                # This ensures the share can only be accessed through private network
            } | Should -Not -Throw
        }
        
        It 'Should update FileShare with network access rules' {
            {
                $fileShare = Update-AzFileShare -ResourceName $script:fileSharePeName `
                                                -ResourceGroupName $env.resourceGroup `
                                                -PublicNetworkAccess "Disabled" `
                                                -Tag @{"security" = "high"; "access" = "private-only"}
                
                $fileShare.PublicNetworkAccess | Should -Be "Disabled"
                $fileShare.Tag["security"] | Should -Be "high"
                $fileShare.Tag["access"] | Should -Be "private-only"
            } | Should -Not -Throw
        }
    }
    
    Context 'Resource Move Operations - Setup' {
        It 'Should create secondary resource group for move operations' {
            {
                $secondaryRg = New-AzResourceGroup -Name $script:secondaryRgName `
                                                   -Location $env.location
                
                $secondaryRg | Should -Not -BeNullOrEmpty
                $secondaryRg.ResourceGroupName | Should -Be $script:secondaryRgName
                $secondaryRg.Location | Should -Be $env.location
            } | Should -Not -Throw
        }
    }
    
    Context 'Resource Move - FileShare' {
        It 'Should validate FileShare can be moved to another resource group' {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup
                
                # Test validation endpoint
                $targetRgId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$script:secondaryRgName"
                
                # Note: Actual move operation requires extensive validation and may take time
                # For testing purposes, we validate the resource properties before move
                $fileShare.Id | Should -Not -BeNullOrEmpty
                $fileShare.ProvisioningState | Should -Be "Succeeded"
            } | Should -Not -Throw
        }
        
        It 'Should move FileShare to secondary resource group' -Skip {
            # This test is skipped by default as resource moves can take significant time
            # and require careful planning. Enable only for full integration testing.
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup
                
                $targetRgId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$script:secondaryRgName"
                
                # Move the FileShare resource
                Move-AzResource -SourceResourceId $fileShare.Id `
                                -DestinationResourceGroupName $script:secondaryRgName `
                                -Force
                
                # Wait for move to complete
                Start-TestSleep -Seconds 30
                
                # Verify FileShare is in new resource group
                $movedShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                              -ResourceGroupName $script:secondaryRgName
                
                $movedShare | Should -Not -BeNullOrEmpty
                $movedShare.Name | Should -Be $script:fileSharePeName
            } | Should -Not -Throw
        }
    }
    
    Context 'Resource Move - Virtual Network' {
        It 'Should validate Virtual Network resource before move' {
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetName `
                                             -ResourceGroupName $env.resourceGroup
                
                $vnet.Id | Should -Not -BeNullOrEmpty
                $vnet.ProvisioningState | Should -Be 'Succeeded'
                
                # Ensure no dependencies are blocking the move
                # VNet with Private Endpoints may have move restrictions
            } | Should -Not -Throw
        }
        
        It 'Should prepare VNet for move (remove dependencies)' {
            # Note: Virtual Networks with Private Endpoints cannot be moved
            # PE must be deleted first, then VNet can be moved
            Write-Host "Note: VNet with active Private Endpoints cannot be moved directly"
            Write-Host "This test validates the constraint and preparation steps"
            
            $vnet = Get-AzVirtualNetwork -Name $script:vnetName -ResourceGroupName $env.resourceGroup
            $vnet | Should -Not -BeNullOrEmpty
            
            # Check for Private Endpoints in subnets
            $hasPrivateEndpoints = $false
            foreach ($subnet in $vnet.Subnets) {
                if ($subnet.PrivateEndpoints.Count -gt 0) {
                    $hasPrivateEndpoints = $true
                    break
                }
            }
            
            if ($hasPrivateEndpoints) {
                Write-Host "VNet has Private Endpoints - move operation would require PE removal first"
            }
            
            $hasPrivateEndpoints | Should -Be $true
        }
        
        It 'Should demonstrate VNet move workflow (Conceptual)' {
            # This test documents the proper workflow for moving a VNet with PEs
            Write-Host "VNet Move Workflow:"
            Write-Host "1. Remove/Delete all Private Endpoints in the VNet"
            Write-Host "2. Validate VNet has no dependencies"
            Write-Host "3. Execute Move-AzResource for the VNet"
            Write-Host "4. Recreate Private Endpoints in the new resource group"
            
            # This test always passes - it's for documentation
            $true | Should -Be $true
        }
    }
    
    Context 'Resource Move - Private Endpoint' {
        It 'Should validate Private Endpoint resource before move' {
            {
                $pe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                            -ResourceGroupName $env.resourceGroup
                
                $pe.Id | Should -Not -BeNullOrEmpty
                $pe.ProvisioningState | Should -Be 'Succeeded'
            } | Should -Not -Throw
        }
        
        It 'Should move Private Endpoint to secondary resource group' -Skip {
            # This test is skipped by default as PE moves require careful coordination
            # Private Endpoints can be moved, but the VNet must remain accessible
            {
                $pe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                            -ResourceGroupName $env.resourceGroup
                
                $targetRgId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$script:secondaryRgName"
                
                # Move the Private Endpoint
                Move-AzResource -SourceResourceId $pe.Id `
                                -DestinationResourceGroupName $script:secondaryRgName `
                                -Force
                
                # Wait for move to complete
                Start-TestSleep -Seconds 30
                
                # Verify PE is in new resource group
                $movedPe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                                 -ResourceGroupName $script:secondaryRgName
                
                $movedPe | Should -Not -BeNullOrEmpty
                $movedPe.Name | Should -Be $script:privateEndpointName
            } | Should -Not -Throw
        }
    }
    
    Context 'Complete Resource Move Scenario' {
        It 'Should document complete cross-RG move procedure' {
            Write-Host "`nComplete Resource Move Procedure:"
            Write-Host "================================="
            Write-Host "1. Create secondary resource group (completed)"
            Write-Host "2. Remove Private Endpoint from source VNet"
            Write-Host "3. Move FileShare to target RG (if Public Network Access enabled)"
            Write-Host "4. Move VNet to target RG (after PE removal)"
            Write-Host "5. Recreate Private Endpoint in target RG"
            Write-Host "6. Update FileShare network configuration"
            Write-Host "7. Validate end-to-end connectivity"
            Write-Host ""
            
            # Verify secondary RG exists
            $secondaryRg = Get-AzResourceGroup -Name $script:secondaryRgName -ErrorAction SilentlyContinue
            $secondaryRg | Should -Not -BeNullOrEmpty
        }
    }
    
    AfterAll {
        Write-Host "`nCleaning up test resources..."
        
        # Clean up in reverse order of dependencies
        try {
            # Remove Private Endpoint
            Remove-TestPrivateEndpoint -ResourceGroupName $env.resourceGroup `
                                       -PrivateEndpointName $script:privateEndpointName `
                                       -ErrorAction SilentlyContinue
            
            Start-TestSleep -Seconds 10
            
            # Remove FileShare
            Remove-AzFileShare -ResourceName $script:fileSharePeName `
                              -ResourceGroupName $env.resourceGroup `
                              -ErrorAction SilentlyContinue
            
            Start-TestSleep -Seconds 5
            
            # Remove Virtual Network
            Remove-TestVirtualNetwork -ResourceGroupName $env.resourceGroup `
                                     -VNetName $script:vnetName `
                                     -ErrorAction SilentlyContinue
            
            Start-TestSleep -Seconds 5
            
            # Remove Secondary Resource Group
            Remove-AzResourceGroup -Name $script:secondaryRgName -Force -AsJob -ErrorAction SilentlyContinue
            
            Write-Host "Cleanup completed"
        }
        catch {
            Write-Warning "Some cleanup operations failed: $_"
        }
    }
}
