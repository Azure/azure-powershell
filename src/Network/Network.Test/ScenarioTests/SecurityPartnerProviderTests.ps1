# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests SecurityPartnerProvider CRUD Operations without Hub
#>
function Test-SecurityPartnerProviderWithoutHubCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $securityPartnerProviderName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/SecurityPartnerProviders"
    $rglocation = Get-ProviderLocation "ResourceManagement" "westcentralus"
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $VirtualNetworkGatewayName = Get-ResourceName
	$routeTable1Name = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
    $securityProviderName = "ZScaler"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create SecurityPartnerProvider
        New-AzSecurityPartnerProvider –Name $securityPartnerProviderName -ResourceGroupName $rgname -Location $rglocation -SecurityProviderName $securityProviderName

        # Get SecurityPartnerProvider
        $getSecurityPartnerProvider = Get-AzSecurityPartnerProvider -name $securityPartnerProviderName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getSecurityPartnerProvider.ResourceGroupName
        Assert-AreEqual $securityPartnerProviderName $getSecurityPartnerProvider.Name
        Assert-NotNull $getSecurityPartnerProvider.Location
        Assert-AreEqual (Normalize-Location $rglocation) $getSecurityPartnerProvider.Location
        Assert-NotNull $getSecurityPartnerProvider.Etag

        # Delete SecurityPartnerProvider
        $delete = Remove-AzSecurityPartnerProvider -ResourceGroupName $rgname -name $securityProviderName -PassThru -Force
        Assert-AreEqual true $delete

    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SecurityPartnerProvider CRUD Operations with Hub
#>
function Test-SecurityPartnerProviderWithHubCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $securityPartnerProviderName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/SecurityPartnerProviders"
    $rglocation = Get-ProviderLocation "ResourceManagement" "westcentralus"
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $VirtualNetworkGatewayName = Get-ResourceName
	$routeTable1Name = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
    $securityProviderName = "ZScaler"

    try {
       # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
                
       # Create the Virtual Wan
        $createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
        $virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
        Write-Debug "Created Virtual WAN $virtualWanName successfully"

		# Create the Virtual Hub
        $createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.8.0.0/24" -VirtualWan $virtualWan
        $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        Write-Debug "Created Virtual Hub $virtualHubName successfully"

        # Create the VpnGateway
        $createdVpnGateway = New-AzVpnGateway  -ResourceGroupName $rgName -Name $VirtualNetworkGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 2
        Write-Debug "Created VpnGateway $VirtualNetworkGatewayName successfully"
        $vpnGateway = Get-AzVpnGateway  -ResourceGroupName $rgName -Name $VirtualNetworkGatewayName
        Assert-NotNull $vpnGateway
        Write-Debug "Retrieved VpnGateway $VirtualNetworkGatewayName successfully"

        # Create SecurityPartnerProvider with Virtual Hub Object
        New-AzSecurityPartnerProvider –Name $securityPartnerProviderName -ResourceGroupName $rgname -Location $rglocation -SecurityProviderName $securityProviderName -VirtualHub $virtualHub

        # Get SecurityPartnerProvider
        $getSecurityPartnerProvider = Get-AzSecurityPartnerProvider -name $securityPartnerProviderName -ResourceGroupName $rgname

        #verification
        Assert-NotNull $getSecurityPartnerProvider.VirtualHub
        
        # Delete SecurityPartnerProvider with SecurityPartnerProvider object
        $delete = Remove-AzSecurityPartnerProvider -SecurityPartnerProvider $getSecurityPartnerProvider -PassThru -Force
        Assert-AreEqual true $delete

        # Create SecurityPartnerProvider with Virtual Hub Id
        New-AzSecurityPartnerProvider –Name $securityPartnerProviderName -ResourceGroupName $rgname -Location $rglocation -SecurityProviderName $securityProviderName -VirtualHubId $virtualHub.Id

        # Get SecurityPartnerProvider
        $getSecurityPartnerProvider = Get-AzSecurityPartnerProvider -name $securityPartnerProviderName -ResourceGroupName $rgname

        #verification
        Assert-NotNull $getSecurityPartnerProvider.VirtualHub

        # Delete SecurityPartnerProvider with SecurityPartnerProvider Id
        $delete = Remove-AzSecurityPartnerProvider -ResourceId $getSecurityPartnerProvider.Id -PassThru -Force
        Assert-AreEqual true $delete

        # Create SecurityPartnerProvider with Virtual Hub name
        New-AzSecurityPartnerProvider –Name $securityPartnerProviderName -ResourceGroupName $rgname -Location $rglocation -SecurityProviderName $securityProviderName -VirtualHubName $virtualHubName

        # Get SecurityPartnerProvider
        $getSecurityPartnerProvider = Get-AzSecurityPartnerProvider -name $securityPartnerProviderName -ResourceGroupName $rgname

        #verification
        Assert-NotNull $getSecurityPartnerProvider.VirtualHub

        # Delete SecurityPartnerProvider with SecurityPartnerProvider name
        $delete = Remove-AzSecurityPartnerProvider -ResourceGroupName $rgname -name $securityProviderName -PassThru -Force
        Assert-AreEqual true $delete
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
