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

.NOTES
Requires: Az.Network and Az.FileShare modules
#>

Describe 'FileShare-PrivateEndpoint' {
    BeforeAll {
        # Initialize test variables with fixed names for recording consistency
        # These are set regardless of Az.Network availability to prevent empty string errors
        $script:vnetName = "vnet-fileshare-pe-fixed01"
        $script:subnetName = "subnet-pe"
        $script:privateEndpointName = "pe-fileshare-fixed01"
        $script:fileSharePeName = "share-pe-fixed01"
        $script:vnetAddressPrefix = "10.0.0.0/16"
        $script:subnetAddressPrefix = "10.0.1.0/24"
        $script:skipPrivateEndpointTests = $false
        
        # Check if Az.Network module is available
        # Even in playback mode, we need Az.Network cmdlets to be callable (HttpPipelineMocking intercepts them)
        $azNetworkAvailable = $null -ne (Get-Module -ListAvailable Az.Network | Where-Object { $_.Version -ge [Version]"7.0.0" })
        
        if (-not $azNetworkAvailable) {
            Write-Warning "Az.Network module not available or version too old. Private Endpoint tests will be skipped."
            $script:skipPrivateEndpointTests = $true
        }
        else {
            try {
                # Import Az.Network module (Az.FileShare is already loaded by test framework)
                Import-Module Az.Network -ErrorAction Stop
                Write-Host "Az.Network module loaded successfully"
            }
            catch {
                Write-Warning "Failed to load Az.Network module: $_. Private Endpoint tests will be skipped."
                $script:skipPrivateEndpointTests = $true
            }
        }
        
        Write-Host "Test Configuration:"
        Write-Host "  Resource Group: $($env.resourceGroup)"
        Write-Host "  Location: $($env.location)"
        Write-Host "  VNet: $script:vnetName"
        Write-Host "  Subnet: $script:subnetName"
        Write-Host "  Private Endpoint: $script:privateEndpointName"
        Write-Host "  FileShare for PE: $script:fileSharePeName"
    }
    
    Context 'Virtual Network Setup' {
        It 'Should create a new Virtual Network' -Skip:$script:skipPrivateEndpointTests {
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
        
        It 'Should retrieve existing Virtual Network' -Skip:$script:skipPrivateEndpointTests {
            {
                $vnet = Get-AzVirtualNetwork -Name $script:vnetName -ResourceGroupName $env.resourceGroup
                $vnet | Should -Not -BeNullOrEmpty
                $vnet.Name | Should -Be $script:vnetName
            } | Should -Not -Throw
        }
        
        It 'Should create a subnet for Private Endpoints' -Skip:$script:skipPrivateEndpointTests {
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
        
        It 'Should list VNet subnets' -Skip:$script:skipPrivateEndpointTests {
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
        It 'Should create FileShare with private network access' -Skip:$script:skipPrivateEndpointTests {
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
        
        It 'Should verify FileShare is not publicly accessible' -Skip:$script:skipPrivateEndpointTests {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup
                
                $fileShare.PublicNetworkAccess | Should -Be "Disabled"
            } | Should -Not -Throw
        }
    }
    
    Context 'Private Endpoint Creation and Configuration' {
        It 'Should create Private Endpoint for FileShare' -Skip:$script:skipPrivateEndpointTests {
            {
                # Get subnet and FileShare details
                $vnet = Get-AzVirtualNetwork -Name $script:vnetName -ResourceGroupName $env.resourceGroup
                $subnet = Get-AzVirtualNetworkSubnetConfig -Name $script:subnetName -VirtualNetwork $vnet
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName -ResourceGroupName $env.resourceGroup
                
                # Create Private Link Service Connection
                # GroupId for Microsoft.FileShares/fileShares is "fileshare"
                # Required members: ["file"]
                # Required zone names: ["privatelink.file.core.windows.net"]
                $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection `
                    -Name "$script:privateEndpointName-connection" `
                    -PrivateLinkServiceId $fileShare.Id `
                    -GroupId "fileshare"
                
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
        
        It 'Should retrieve Private Endpoint details' -Skip:$script:skipPrivateEndpointTests {
            {
                $pe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                            -ResourceGroupName $env.resourceGroup
                
                $pe | Should -Not -BeNullOrEmpty
                $pe.Name | Should -Be $script:privateEndpointName
                $pe.PrivateLinkServiceConnections.Count | Should -BeGreaterOrEqual 1
            } | Should -Not -Throw
        }
        
        It 'Should verify Private Endpoint connection state' -Skip:$script:skipPrivateEndpointTests {
            {
                $pe = Get-AzPrivateEndpoint -Name $script:privateEndpointName `
                                            -ResourceGroupName $env.resourceGroup
                
                $connection = $pe.PrivateLinkServiceConnections[0]
                $connection.PrivateLinkServiceConnectionState.Status | Should -BeIn @('Approved', 'Pending')
            } | Should -Not -Throw
        }
        
        It 'Should list all Private Endpoints in resource group' -Skip:$script:skipPrivateEndpointTests {
            {
                $endpoints = Get-AzPrivateEndpoint -ResourceGroupName $env.resourceGroup
                $endpoints | Should -Not -BeNullOrEmpty
                $endpoints.Name | Should -Contain $script:privateEndpointName
            } | Should -Not -Throw
        }
    }
    
    Context 'Network Security and Access Control' {
        It 'Should verify FileShare is only accessible via Private Endpoint' -Skip:$script:skipPrivateEndpointTests {
            {
                $fileShare = Get-AzFileShare -ResourceName $script:fileSharePeName `
                                             -ResourceGroupName $env.resourceGroup
                
                # Verify public access is disabled
                $fileShare.PublicNetworkAccess | Should -Be "Disabled"
                
                # This ensures the share can only be accessed through private network
            } | Should -Not -Throw
        }
        
        It 'Should update FileShare with network access rules' -Skip:$script:skipPrivateEndpointTests {
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
    

    
    AfterAll {
        # Skip cleanup in playback mode (no actual resources created)
        $isPlaybackMode = $env:AzPSAutorestTestPlaybackMode -eq $true
        
        if ($isPlaybackMode) {
            Write-Host "`nPlayback mode - skipping cleanup (no real resources created)"
            return
        }
        
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
            
            Write-Host "Cleanup completed"
        }
        catch {
            Write-Warning "Some cleanup operations failed: $_"
        }
    }
}
