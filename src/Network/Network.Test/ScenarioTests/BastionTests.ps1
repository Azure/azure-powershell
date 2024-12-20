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
BastionCRUD
#>
function Test-BastionCRUD {

    # Register-AzResourceProvider -ProviderNamespace "Microsoft.Network"
    # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = "$(Get-ResourceName)-Bastion"
    $resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = "$(Get-ResourceName)-Vnet"
    $subnetName = "AzureBastionSubnet"
    $publicIpName = "$(Get-ResourceName)-Pip"
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
        # Create Bastion
        $bastion = New-AzBastion -ResourceGroupName $rgname -Name $bastionName -PublicIpAddressRgName $rgname -PublicIpAddressName $publicIpName -VirtualNetworkRgName $rgname -VirtualNetworkName $vnetName -Sku "Standard"

        # Get Bastion by Name
        $bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj

        #verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $bastionObj.Sku.Name "Standard"
        Assert-AreEqual $bastionObj.ScaleUnit 2
        Assert-AreEqual $false $bastionObj.EnableKerberos
        Assert-AreEqual $false $bastionObj.DisableCopyPaste
        Assert-AreEqual $false $bastionObj.EnableTunneling
		Assert-AreEqual $false $bastionObj.EnableIpConnect
        Assert-AreEqual $false $bastionObj.EnableShareableLink
        Assert-AreEqual $false $bastionObj.EnableSessionRecording

        # Get Bastion by Id
        $bastionObj = Get-AzBastion -ResourceId $bastion.id
        Assert-NotNull $bastionObj

        #verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

        # Update Bastion Scale Units
        $bastionObj = Set-AzBastion -InputObject $bastionObj -ScaleUnit 3 -Force

        # Verification
        Assert-NotNull $bastionObj
        Assert-AreEqual $bastionObj.Sku.Name "Standard"
        Assert-AreEqual $bastionObj.ScaleUnit 3

        # Get all Bastions in ResourceGroup
        $bastions = Get-AzBastion -ResourceGroupName $rgName
        Assert-NotNull $bastions

        # list all Azure Bastion under subscription
        $bastionsAll = Get-AzBastion
        Assert-NotNull $bastionsAll
       
        # Delete Bastion
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Clean up
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
BastionCreate
#>
function Test-BastionCreateWithFeatures {
    # Setup
    $rgname = Get-ResourceGroupName
    $resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent
    $subnetName = "AzureBastionSubnet"
    $vnetName1 = "$(Get-ResourceName)-Vnet1"
    $publicIpName1 = "$(Get-ResourceName)-Pip1"
    $bastionName1 = "$(Get-ResourceName)-Bastion1"
    $vnetName2 = "$(Get-ResourceName)-Vnet2"
    $publicIpName2 = "$(Get-ResourceName)-Pip2"
    $bastionName2 = "$(Get-ResourceName)-Bastion2"
    $vnetName3 = "$(Get-ResourceName)-Vnet3"
    $publicIpName3 = "$(Get-ResourceName)-Pip3"
    $bastionName3 = "$(Get-ResourceName)-Bastion3"
    $vnetNameForFailures = "$(Get-ResourceName)-VnetForFailures"
    $publicIpNameForFailures = "$(Get-ResourceName)-PipForFailures"
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet1 = New-AzVirtualNetwork -Name $vnetName1 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet3 = New-AzVirtualNetwork -Name $vnetName3 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnetForFailures = New-AzVirtualNetwork -Name $vnetNameForFailures -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Get full subnet details
        $subnet1 = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet1 -Name $subnetName
        $subnet2 = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet2 -Name $subnetName
        $subnet3 = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet3 -Name $subnetName

        # Create public ip
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName1 -location $location -AllocationMethod Static -Sku Standard
        $publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Static -Sku Standard
        $publicip3 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName3 -location $location -AllocationMethod Static -Sku Standard
        $publicIpForFailures = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpNameForFailures -location $location -AllocationMethod Static -Sku Standard

        # Create Bastions
        $bastionJob1 = New-AzBastion -Name $bastionName1 -ResourceGroupName $rgname -VirtualNetwork $vnet1 -PublicIpAddress $publicip1 -Sku "Standard" -ScaleUnit 5 -EnableKerberos $true -DisableCopyPaste $true -EnableTunneling $true -EnableIpConnect $true -EnableShareableLink $true -AsJob
        $bastionJob2 = New-AzBastion -Name $bastionName2 -ResourceGroupName $rgname -VirtualNetwork $vnet2 -PublicIpAddress $publicip2 -Sku "Basic" -EnableKerberos $true -DisableCopyPaste $false -EnableTunneling $false -EnableIpConnect $false -EnableShareableLink $false -AsJob
        $bastionJob3 = New-AzBastion -Name $bastionName3 -ResourceGroupName $rgname -VirtualNetwork $vnet3 -PublicIpAddress $publicip3 -Sku "Premium" -EnableSessionRecording $true -AsJob

        Write-Debug "Started Bastion creations"

        # Receive error message
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Basic" -ScaleUnit 2 -EnableKerberos $true -DisableCopyPaste $true -EnableTunneling $false -EnableIpConnect $false -EnableShareableLink $false } "Toggling copy/paste is available on Standard SKU or higher"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Basic" -ScaleUnit 2 -EnableKerberos $true -DisableCopyPaste $false -EnableTunneling $true -EnableIpConnect $false -EnableShareableLink $false } "Toggling tunneling is available on Standard SKU or higher"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Basic" -ScaleUnit 2 -EnableKerberos $true -DisableCopyPaste $false -EnableTunneling $false -EnableIpConnect $true -EnableShareableLink $false } "Toggling IP connect is available on Standard SKU or higher"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Basic" -ScaleUnit 2 -EnableKerberos $true -DisableCopyPaste $false -EnableTunneling $false -EnableIpConnect $false -EnableShareableLink $true } "Toggling shareable link is available on Standard SKU or higher"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Basic" -ScaleUnit 1 -EnableKerberos $true -DisableCopyPaste $false -EnableTunneling $false -EnableIpConnect $false -EnableShareableLink $false } "Bastion scalable host is available on Standard SKU or higher"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Basic" -ScaleUnit 2 -EnableTunneling $false -EnableSessionRecording $true } "Toggling session recording is available on Premium SKU"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Premium" -EnableTunneling $true -EnableSessionRecording $true } "Tunneling and session recording cannot be enabled together"
        Assert-Throws { New-AzBastion -Name Get-ResourceName -ResourceGroupName $rgname -VirtualNetwork $vnetForFailures -PublicIpAddress $publicIpForFailures -Sku "Standard" -ScaleUnit 100 -EnableKerberos $true -DisableCopyPaste $false -EnableTunneling $false -EnableIpConnect $false -EnableShareableLink $false } "Please select scale units value between 2 and 50"

        Write-Debug "Done with expected Bastion failure assertions"

        # Wait for Bastion 1 job deployment completion
        $bastionJob1 | Wait-Job
        $bastion1 = $bastionJob1 | Receive-Job
        Assert-NotNull $bastion1

        # Verification for Bastion 1
        Assert-AreEqual $rgName $bastion1.ResourceGroupName
        Assert-AreEqual $bastionName1 $bastion1.Name
        Assert-NotNull $bastion1.Etag
        Assert-AreEqual "Succeeded" $bastion1.ProvisioningState
        Assert-AreEqual 1 @($bastion1.IpConfigurations).Count
        Assert-NotNull $bastion1.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastion1.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet1.Id $bastion1.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $bastion1.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual "Standard" $bastion1.Sku.Name
        Assert-AreEqual 5 $bastion1.ScaleUnit
        Assert-AreEqual $true $bastion1.EnableKerberos
        Assert-AreEqual $true $bastion1.DisableCopyPaste
        Assert-AreEqual $true $bastion1.EnableTunneling
        Assert-AreEqual $true $bastion1.EnableIpConnect
        Assert-AreEqual $true $bastion1.EnableShareableLink
        Assert-AreEqual $false $bastion1.EnableSessionRecording

        Write-Debug "Done with Bastion 1 assertions"

        # Wait for Bastion 2 job deployment completion
        $bastionJob2 | Wait-Job
        $bastion2 = $bastionJob2 | Receive-Job
        Assert-NotNull $bastion2

        # Verification for Bastion 2
        Assert-AreEqual $rgName $bastion2.ResourceGroupName
        Assert-AreEqual $bastionName2 $bastion2.Name
        Assert-NotNull $bastion2.Etag
        Assert-AreEqual "Succeeded" $bastion2.ProvisioningState
        Assert-AreEqual 1 @($bastion2.IpConfigurations).Count
        Assert-NotNull $bastion2.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastion2.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet2.Id $bastion2.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip2.Id $bastion2.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual "Basic" $bastion2.Sku.Name
        Assert-AreEqual 2 $bastion2.ScaleUnit
        Assert-AreEqual $true $bastion2.EnableKerberos
        Assert-AreEqual $false $bastion2.DisableCopyPaste
        Assert-AreEqual $false $bastion2.EnableTunneling
        Assert-AreEqual $false $bastion2.EnableIpConnect
        Assert-AreEqual $false $bastion2.EnableShareableLink
        Assert-AreEqual $false $bastion2.EnableSessionRecording

        Write-Debug "Done with Bastion 2 assertions"

        # Wait for Bastion 3 job deployment completion and assertions
        $bastionJob3 | Wait-Job
        $bastion3 = $bastionJob3 | Receive-Job
        Assert-NotNull $bastion3
        Assert-AreEqual "Succeeded" $bastion3.ProvisioningState
        Assert-AreEqual $subnet3.Id $bastion3.IpConfigurations[0].Subnet.Id
        Assert-AreEqual "Premium" $bastion3.Sku.Name
        Assert-AreEqual $true $bastion3.EnableSessionRecording

        # Try enabling tunneling and session recording together
        Assert-Throws { Set-AzBastion -InputObject $bastion1 -Sku "Premium" -EnableSessionRecording $true -Force } "Tunneling and session recording cannot be enabled together"
        Assert-Throws { Set-AzBastion -InputObject $bastion2 -Sku "Premium" -EnableTunneling $true -EnableSessionRecording $true -Force } "Tunneling and session recording cannot be enabled together"
        Assert-Throws { Set-AzBastion -InputObject $bastion3 -EnableTunneling $true -Force } "Tunneling and session recording cannot be enabled together"

        Write-Debug "Done with Bastion 3 assertions"

        # Get all Bastions in ResourceGroup
        $bastions = Get-AzBastion -ResourceGroupName $rgName
        Assert-NotNull $bastions

        # Delete Bastions
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName1 -PassThru -Force
        Assert-AreEqual true $delete
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName2 -PassThru -Force
        Assert-AreEqual true $delete
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName3 -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetNameForFailures -PassThru -Force
        Assert-AreEqual true $delete
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName1 -PassThru -Force
        Assert-AreEqual true $delete
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName2 -PassThru -Force
        Assert-AreEqual true $delete
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName3 -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Clean up
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
BastionVnetsIpObjectsParams
#>
function Test-BastionVnetsIpObjectsParams {

    # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
        # Create Bastion 
        $bastion = New-AzBastion -ResourceGroupName $rgname -Name $bastionName -PublicIpAddress $publicip -VirtualNetwork $vnet

        # Get Bastion by Name
        $bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj
		
        #verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

        # Delete Bastion
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Clean up
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
BastionVnetObjectParam
#>
function Test-BastionVnetObjectParam {

    # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
        # Create Bastion 
        $bastion = New-AzBastion -ResourceGroupName $rgname -Name $bastionName -PublicIpAddressRgName $rgname -PublicIpAddressName $publicIpName -VirtualNetwork $vnet

        # Get Bastion by Name
        $bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj
		
        #verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

        # Delete Bastion by ResourceId
        $delete = Remove-AzBastion -InputObject $bastionObj -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Clean up
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
BastionIpObjectParam
#>
function Test-BastionIpObjectParam {

    # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
        # Create Bastion 
        $bastion = New-AzBastion -ResourceGroupName $rgname -Name $bastionName -PublicIpAddress $publicip -VirtualNetworkRgName $rgname -VirtualNetworkName $vnetName

        # Get Bastion by Name
        $bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj
		
        #verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

        # Delete Bastion by ResourceId
        $delete = Remove-AzBastion -InputObject $bastionObj -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Clean up
        Clean-ResourceGroup $rgname
    }
}

<#
Test Bastion Shareable Link
#>
function Test-BastionShareableLink {
    # Setup
    $rgname = Get-ResourceGroupName
    $resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent
    $subnetName = "AzureBastionSubnet"
    $vnetName = "$(Get-ResourceName)-Vnet"
    $vnetName2 = "$(Get-ResourceName)-Vnet"
    $publicIpName = "$(Get-ResourceName)-Pip"
    $publicIpName2 = "$(Get-ResourceName)-Pip"
    $bastionName = "$(Get-ResourceName)-Bastion"
    $bastionName2 = "$(Get-ResourceName)-Bastion2"
    $vmUsername = "azureuser"
    $vmPassword = ConvertTo-SecureString "$vmUsername@123" -AsPlainText -Force
    $vmName = "$(Get-ResourceName)-Vm"
    $vmSize = "Standard_D2ds_v4"
    $nicName = "$(Get-ResourceName)-Nic"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet2 = New-AzVirtualNetwork -Name $vnetName2 -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Public IP
        $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
        $publicIp2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Static -Sku Standard

        # Create Bastion
        $createBastionJob = New-AzBastion -Name $bastionName -ResourceGroupName $rgname -VirtualNetwork $vnet -PublicIpAddress $publicIp -EnableShareableLink $true -AsJob
        $createBastionJob2 = New-AzBastion -Name $bastionName2 -ResourceGroupName $rgname -VirtualNetwork $vnet2 -PublicIpAddress $publicIp2 -Sku Basic -AsJob

        # Create VM
        $nic = New-AzNetworkInterface -Name $NICName -ResourceGroupName $RgName -Location $location -SubnetId $vnet.Subnets[0].Id
        $Credential = New-Object System.Management.Automation.PSCredential ($vmUsername, $vmPassword);
        $vm = New-AzVMConfig -VMName $vmName -VMSize $vmSize
        $vm = Set-AzVMOperatingSystem -VM $vm -Windows -ComputerName $vmName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate
        $vm = Add-AzVMNetworkInterface -VM $vm -Id $NIC.Id
        $vm = Set-AzVMSourceImage -VM $vm -PublisherName "MicrosoftWindowsServer" -Offer "WindowsServer" -Skus "2022-datacenter-azure-edition-core" -Version latest
        $vm = Set-AzVMBootDiagnostic -VM $vm -Disable
        $createVmJob = New-AzVM -ResourceGroupName $RgName -Location $location -VM $vm -Verbose -AsJob

        # Wait for create Basic Bastion completion
        $createBastionJob2 | Wait-Job
        $bastion2 = $createBastionJob2 | Receive-Job
        Assert-NotNull $bastion2

        # Receive error message
        $randomName = Get-ResourceName
        # New BSL
        Assert-Throws { New-AzBastionShareableLink -ResourceGroupName $rgname -Name $randomName -TargetVmId $bastionName2 } "Resource '$randomName' not found"
        Assert-Throws { New-AzBastionShareableLink -ResourceGroupName $rgname -Name $bastionName2 -TargetVmId $bastionName2 } "Shareable link feature is not enabled"
        # Get BSL
        Assert-Throws { Get-AzBastionShareableLink -ResourceGroupName $rgname -Name $randomName -TargetVmId $bastionName2 } "Resource '$randomName' not found"
        Assert-Throws { Get-AzBastionShareableLink -ResourceGroupName $rgname -Name $bastionName2 -TargetVmId $bastionName2 } "Shareable link feature is not enabled"
        # Remove BSL
        Assert-Throws { Remove-AzBastionShareableLink -ResourceGroupName $rgname -Name $randomName -TargetVmId $bastionName2 -Force } "Resource '$randomName' not found"
        Assert-Throws { Remove-AzBastionShareableLink -ResourceGroupName $rgname -Name $bastionName2 -TargetVmId $bastionName2 -Force } "Shareable link feature is not enabled"

        # Wait for create Bastion completion
        $createBastionJob | Wait-Job
        $bastion = $createBastionJob | Receive-Job
        Assert-NotNull $bastion
        Assert-AreEqual $true $bastion.EnableShareableLink

        # Wait for create VM completion
        $createVmJob | Wait-Job
        $vm = Get-AzVM -ResourceGroupName $RgName -Name $vmName
        Assert-NotNull $vm
        Assert-NotNull $vm.Id

        # Create BSL
        New-AzBastionShareableLink -InputObject $bastion -TargetVmId $vm.Id

        # Get BSL
        $getBsl = Get-AzBastionShareableLink -InputObject $bastion
        Assert-NotNull $getBsl
        Assert-AreEqual $vm.Id $getBsl.VmId
        Assert-NotNull $getBsl.Bsl
        Assert-NotNull $getBsl.CreatedAt

        # Delete BSL
        Remove-AzBastionShareableLink -InputObject $bastion -TargetVmId $vm.Id -Force

        # Get BSL
        $getBsl = Get-AzBastionShareableLink -InputObject $bastion
        Assert-AreEqual 0 $getBsl.Count
    }
    finally {
        # Clean up
        Clean-ResourceGroup $rgname
    }
}
