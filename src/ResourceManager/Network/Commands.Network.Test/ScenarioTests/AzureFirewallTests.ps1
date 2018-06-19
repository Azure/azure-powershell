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
Tests AzureFirewallCRUD.
#>
function Test-AzureFirewallCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = "eastus2euap" #Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$publicIpName = Get-ResourceName

	# AzureFirewallApplicationRuleCollection
	$appRcName = "appRc"
	$appRcPriority = 100
	$appRcActionType = "Allow"

	# AzureFirewallApplicationRule 1
	$appRule1Name = "appRule"
	$appRule1Desc = "desc1"
	$appRule1Fqdn1 = "*google.com"
	$appRule1Fqdn2 = "*microsoft.com"
	$appRule1Protocol1 = "http:80"
	$appRule1Port1 = 80
	$appRule1ProtocolType1 = "http"
	$appRule1Protocol2 = "https:443"
	$appRule1Port2 = 443
	$appRule1ProtocolType2 = "https"
	$appRule1SourceAddress1 = "10.0.0.0"

	# AzureFirewallApplicationRule 2
	$appRule2Name = "appRule2"
	$appRule2Fqdn1 = "*bing.com"
	$appRule2Protocol1 = "http:8080"

	# AzureFirewallNetworkRuleCollection
	$networkRcName = "networkRc"
	$networkRcPriority = 200
	$networkRcActionType = "Deny"

	# AzureFirewallNetworkRule 1
	$networkRule1Name = "networkRule"
	$networkRule1Desc = "desc1"
	$networkRule1SourceAddress1 = "10.0.0.0"
	$networkRule1SourceAddress2 = "111.1.0.0/24"
	$networkRule1DestinationAddress1 = "*"
	$networkRule1DestinationPort1 = "90"
	$networkRule1DestinationPort2 = "900"
	$networkRule1Protocol1 = "Udp"
	$networkRule1Protocol2 = "Tcp"

	# AzureFirewallNetworkRule 2
	$networkRule2Name = "networkRule2"
	$networkRule2SourceAddress1 = "*"
	$networkRule2DestinationAddress1 = "10.8.6.9"
	$networkRule2DestinationAddress2 = "10.8.6.90/24"
	$networkRule2DestinationPort1 = "80"
	$networkRule2Protocol1 = "Tcp"
	$networkRule2Protocol2 = "Any"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
		# Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall (with no rules)
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname
        
        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
		Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet.Id
		Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
		Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollections).Count

        # list all Azure Firewalls in the resource group
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getAzureFirewall.IpConfigurations).Count
		Assert-AreEqual @($list[0].IpConfigurations)[0].Subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
		Assert-AreEqual @($list[0].IpConfigurations)[0].PublicIpAddress.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
		Assert-AreEqual @($list[0].IpConfigurations)[0].PrivateIpAddress $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getAzureFirewall.NetworkRuleCollections).Count

        # Create Application Rule
		$appRule = New-AzureRmFirewallApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1

		# Verification of application rule
		Assert-AreEqual $appRule1Name $appRule.Name
		Assert-AreEqual $appRule1Desc $appRule.Description

		Assert-AreEqual 1 $appRule.SourceAddresses.Count 
		Assert-AreEqual $appRule1SourceAddress1 $appRule.SourceAddresses[0]

		Assert-AreEqual 2 $appRule.Protocols.Count 
		Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port
		Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
		Assert-AreEqual $appRule1Port2 $appRule.Protocols[1].Port
		Assert-AreEqual $appRule1ProtocolType2 $appRule.Protocols[1].ProtocolType
		
		Assert-AreEqual 2 $appRule.TargetUrls.Count 
		Assert-AreEqual $appRule1Fqdn1 $appRule.TargetUrls[0]
		Assert-AreEqual $appRule1Fqdn2 $appRule.TargetUrls[1]

		# Create Application Rule Collection
		$appRc = New-AzureRmFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

		# Create Network Rule
		$networkRule = New-AzureRmFirewallNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1

		# Verification of Network rule
		Assert-AreEqual $networkRule1Name $networkRule.Name
		Assert-AreEqual $networkRule1Desc $networkRule.Description

		Assert-AreEqual 2 $networkRule.SourceAddresses.Count 
		Assert-AreEqual $networkRule1SourceAddress1 $networkRule.SourceAddresses[0]
		Assert-AreEqual $networkRule1SourceAddress2 $networkRule.SourceAddresses[1]

		Assert-AreEqual 1 $networkRule.DestinationAddresses.Count 
		Assert-AreEqual $networkRule1DestinationAddress1 $networkRule.DestinationAddresses[0]

		Assert-AreEqual 2 $networkRule.Protocols.Count 
		Assert-AreEqual $networkRule1Protocol1 $networkRule.Protocols[0]
		Assert-AreEqual $networkRule1Protocol2 $networkRule.Protocols[1]
		
		Assert-AreEqual 1 $networkRule.DestinationPorts.Count 
		Assert-AreEqual $networkRule1DestinationPort1 $networkRule.DestinationPorts[0]

		# Create Network Rule Collection
		$netRc = New-AzureRmFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType

		# Update AzureFirewall with ApplicationRuleCollection and NetworkRuleCollection
		$azureFirewall.ApplicationRuleCollections = $appRc
		$azureFirewall.NetworkRuleCollections = $netRc

		# Set AzureFirewall
        Set-AzureRmFirewall -AzureFirewall $azureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgName
		$azureFirewallIpConfiguration = $getAzureFirewall.IpConfigurations

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        
		Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
		Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress

        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

		$appRc = $getAzureFirewall.ApplicationRuleCollections[0]
		$appRule = $appRc.Rules[0]

		# Verify application rule collection and application rule
		Assert-AreEqual $appRcName $appRc.Name
		Assert-AreEqual $appRcPriority $appRc.Priority
		Assert-AreEqual $appRcActionType $appRc.Action.Type

		Assert-AreEqual $appRc.Rules[0].Name $appRule.Name
		Assert-AreEqual $appRc.Rules[0].Description $appRule.Description

		Assert-AreEqual 1 $appRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $appRc.Rules[0].SourceAddresses.Count $appRule.SourceAddresses.Count
		Assert-AreEqual $appRc.Rules[0].SourceAddresses[0] $appRule.SourceAddresses[0]

		Assert-AreEqual 2 $appRc.Rules[0].Protocols.Count 
		Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
		Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
		Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]
		
		Assert-AreEqual 2 $appRc.Rules[0].TargetUrls.Count 
		Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
		Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
		Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]

		$networkRc = $getAzureFirewall.NetworkRuleCollections[0]
		$networkRule = $networkRc.Rules[0]

		# Verify network rule collection and network rule
		Assert-AreEqual $networkRcName $networkRc.Name
		Assert-AreEqual $networkRcPriority $networkRc.Priority
		Assert-AreEqual $networkRcActionType $networkRc.Action.Type

		Assert-AreEqual $networkRc.Rules[0].Name $networkRule.Name
		Assert-AreEqual $networkRc.Rules[0].Description $networkRule.Description

		Assert-AreEqual 2 $networkRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses.Count $networkRule.SourceAddresses.Count
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[0] $networkRule.SourceAddresses[0]
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[1] $networkRule.SourceAddresses[1]

		Assert-AreEqual 1 $networkRc.Rules[0].DestinationAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationAddresses.Count $networkRule.DestinationAddresses.Count

		Assert-AreEqual 2 $networkRc.Rules[0].Protocols.Count 
		Assert-AreEqual $networkRc.Rules[0].Protocols.Count $networkRule.Protocols.Count
		Assert-AreEqual $networkRc.Rules[0].Protocols[0] $networkRule.Protocols[0]
		Assert-AreEqual $networkRc.Rules[0].Protocols[1] $networkRule.Protocols[1]
		
		Assert-AreEqual 1 $networkRc.Rules[0].DestinationPorts.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts.Count $networkRule.DestinationPorts.Count
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts[0] $networkRule.DestinationPorts[0]

        # Delete AzureFirewall
        $delete = Remove-AzureRmFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall Set and Remove IpConfiguration
#>
function Test-AzureFirewallIpConfiguration
{
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = "eastus2euap" #Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$publicIpName = Get-ResourceName

	# AzureFirewallApplicationRuleCollection
	$appRcName = "appRc"
	$appRcPriority = 100
	$appRcActionType = "Allow"

	# AzureFirewallApplicationRule 1
	$appRule1Name = "appRule"
	$appRule1Desc = "desc1"
	$appRule1Fqdn1 = "*google.com"
	$appRule1Fqdn2 = "*microsoft.com"
	$appRule1Protocol1 = "http:80"
	$appRule1Port1 = 80
	$appRule1ProtocolType1 = "http"
	$appRule1Protocol2 = "https:443"
	$appRule1Port2 = 443
	$appRule1ProtocolType2 = "https"
	$appRule1SourceAddress1 = "10.0.0.0"

	# AzureFirewallNetworkRuleCollection
	$networkRcName = "networkRc"
	$networkRcPriority = 200
	$networkRcActionType = "Deny"

	# AzureFirewallNetworkRule 1
	$networkRule1Name = "networkRule"
	$networkRule1Desc = "desc1"
	$networkRule1SourceAddress1 = "10.0.0.0"
	$networkRule1SourceAddress2 = "111.1.0.0/24"
	$networkRule1DestinationAddress1 = "*"
	$networkRule1DestinationPort1 = "90"
	$networkRule1DestinationPort2 = "900"
	$networkRule1Protocol1 = "Udp"
	$networkRule1Protocol2 = "Tcp"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
		# Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create Application Rule
		$appRule = New-AzureRmFirewallApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1

		# Verification of application rule
		Assert-AreEqual $appRule1Name $appRule.Name
		Assert-AreEqual $appRule1Desc $appRule.Description

		Assert-AreEqual 1 $appRule.SourceAddresses.Count 
		Assert-AreEqual $appRule1SourceAddress1 $appRule.SourceAddresses[0]

		Assert-AreEqual 2 $appRule.Protocols.Count 
		Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port
		Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
		Assert-AreEqual $appRule1Port2 $appRule.Protocols[1].Port
		Assert-AreEqual $appRule1ProtocolType2 $appRule.Protocols[1].ProtocolType
		
		Assert-AreEqual 2 $appRule.TargetUrls.Count 
		Assert-AreEqual $appRule1Fqdn1 $appRule.TargetUrls[0]
		Assert-AreEqual $appRule1Fqdn2 $appRule.TargetUrls[1]

		# Create Application Rule Collection
		$appRc = New-AzureRmFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

		# Create Network Rule
		$networkRule = New-AzureRmFirewallNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1

		# Verification of Network rule
		Assert-AreEqual $networkRule1Name $networkRule.Name
		Assert-AreEqual $networkRule1Desc $networkRule.Description

		Assert-AreEqual 2 $networkRule.SourceAddresses.Count 
		Assert-AreEqual $networkRule1SourceAddress1 $networkRule.SourceAddresses[0]
		Assert-AreEqual $networkRule1SourceAddress2 $networkRule.SourceAddresses[1]

		Assert-AreEqual 1 $networkRule.DestinationAddresses.Count 
		Assert-AreEqual $networkRule1DestinationAddress1 $networkRule.DestinationAddresses[0]

		Assert-AreEqual 2 $networkRule.Protocols.Count 
		Assert-AreEqual $networkRule1Protocol1 $networkRule.Protocols[0]
		Assert-AreEqual $networkRule1Protocol2 $networkRule.Protocols[1]
		
		Assert-AreEqual 1 $networkRule.DestinationPorts.Count 
		Assert-AreEqual $networkRule1DestinationPort1 $networkRule.DestinationPorts[0]

		# Create Network Rule Collection
		$netRc = New-AzureRmFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType

		# Create AzureFirewall (with no IpConfiguration)
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -ApplicationRuleCollection $appRc -NetworkRuleCollection $netRc

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        
		Assert-AreEqual 0 @($getAzureFirewall.IpConfigurations).Count
		
		# Verify rule collections and rules
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

		$appRc = $getAzureFirewall.ApplicationRuleCollections[0]
		$appRule = $appRc.Rules[0]

		Assert-AreEqual $appRcName $appRc.Name
		Assert-AreEqual $appRcPriority $appRc.Priority
		Assert-AreEqual $appRcActionType $appRc.Action.Type

		Assert-AreEqual $appRc.Rules[0].Name $appRule.Name
		Assert-AreEqual $appRc.Rules[0].Description $appRule.Description

		Assert-AreEqual 1 $appRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $appRc.Rules[0].SourceAddresses.Count $appRule.SourceAddresses.Count
		Assert-AreEqual $appRc.Rules[0].SourceAddresses[0] $appRule.SourceAddresses[0]

		Assert-AreEqual 2 $appRc.Rules[0].Protocols.Count 
		Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
		Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
		Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]
		
		Assert-AreEqual 2 $appRc.Rules[0].TargetUrls.Count 
		Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
		Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
		Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]

		$networkRc = $getAzureFirewall.NetworkRuleCollections[0]
		$networkRule = $networkRc.Rules[0]

		Assert-AreEqual $networkRcName $networkRc.Name
		Assert-AreEqual $networkRcPriority $networkRc.Priority
		Assert-AreEqual $networkRcActionType $networkRc.Action.Type

		Assert-AreEqual $networkRc.Rules[0].Name $networkRule.Name
		Assert-AreEqual $networkRc.Rules[0].Description $networkRule.Description

		Assert-AreEqual 2 $networkRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses.Count $networkRule.SourceAddresses.Count
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[0] $networkRule.SourceAddresses[0]
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[1] $networkRule.SourceAddresses[1]

		Assert-AreEqual 1 $networkRc.Rules[0].DestinationAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationAddresses.Count $networkRule.DestinationAddresses.Count

		Assert-AreEqual 2 $networkRc.Rules[0].Protocols.Count 
		Assert-AreEqual $networkRc.Rules[0].Protocols.Count $networkRule.Protocols.Count
		Assert-AreEqual $networkRc.Rules[0].Protocols[0] $networkRule.Protocols[0]
		Assert-AreEqual $networkRc.Rules[0].Protocols[1] $networkRule.Protocols[1]
		
		Assert-AreEqual 1 $networkRc.Rules[0].DestinationPorts.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts.Count $networkRule.DestinationPorts.Count
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts[0] $networkRule.DestinationPorts[0]

		# Set ip configuration
		$getAzureFirewall.SetIpConfiguration($vnet, $publicip)

		# Set Azure Firewall
		Set-AzureRmFirewall -AzureFirewall $getAzureFirewall

		# Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname

		# Verification
		Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        
		# verify ip configuration
		Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
		Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet.Id
		Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
		Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
		
		# Verify rule collections and rules
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

		$appRc = $getAzureFirewall.ApplicationRuleCollections[0]
		$appRule = $appRc.Rules[0]

		Assert-AreEqual $appRcName $appRc.Name
		Assert-AreEqual $appRcPriority $appRc.Priority
		Assert-AreEqual $appRcActionType $appRc.Action.Type

		Assert-AreEqual $appRc.Rules[0].Name $appRule.Name
		Assert-AreEqual $appRc.Rules[0].Description $appRule.Description

		Assert-AreEqual 1 $appRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $appRc.Rules[0].SourceAddresses.Count $appRule.SourceAddresses.Count
		Assert-AreEqual $appRc.Rules[0].SourceAddresses[0] $appRule.SourceAddresses[0]

		Assert-AreEqual 2 $appRc.Rules[0].Protocols.Count 
		Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
		Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
		Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]
		
		Assert-AreEqual 2 $appRc.Rules[0].TargetUrls.Count 
		Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
		Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
		Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]

		$networkRc = $getAzureFirewall.NetworkRuleCollections[0]
		$networkRule = $networkRc.Rules[0]

		Assert-AreEqual $networkRcName $networkRc.Name
		Assert-AreEqual $networkRcPriority $networkRc.Priority
		Assert-AreEqual $networkRcActionType $networkRc.Action.Type

		Assert-AreEqual $networkRc.Rules[0].Name $networkRule.Name
		Assert-AreEqual $networkRc.Rules[0].Description $networkRule.Description

		Assert-AreEqual 2 $networkRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses.Count $networkRule.SourceAddresses.Count
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[0] $networkRule.SourceAddresses[0]
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[1] $networkRule.SourceAddresses[1]

		Assert-AreEqual 1 $networkRc.Rules[0].DestinationAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationAddresses.Count $networkRule.DestinationAddresses.Count

		Assert-AreEqual 2 $networkRc.Rules[0].Protocols.Count 
		Assert-AreEqual $networkRc.Rules[0].Protocols.Count $networkRule.Protocols.Count
		Assert-AreEqual $networkRc.Rules[0].Protocols[0] $networkRule.Protocols[0]
		Assert-AreEqual $networkRc.Rules[0].Protocols[1] $networkRule.Protocols[1]
		
		Assert-AreEqual 1 $networkRc.Rules[0].DestinationPorts.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts.Count $networkRule.DestinationPorts.Count
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts[0] $networkRule.DestinationPorts[0]

		# Remove ip configuration
		$getAzureFirewall.RemoveIpConfiguration()
		$getAzureFirewall | Set-AzureRmFirewall

		# Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname

		# Verification
		Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        
		# verify ip configuration
		Assert-AreEqual 0 @($getAzureFirewall.IpConfigurations).Count
		
		# Verify rule collections and rules
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

		$appRc = $getAzureFirewall.ApplicationRuleCollections[0]
		$appRule = $appRc.Rules[0]

		Assert-AreEqual $appRcName $appRc.Name
		Assert-AreEqual $appRcPriority $appRc.Priority
		Assert-AreEqual $appRcActionType $appRc.Action.Type

		Assert-AreEqual $appRc.Rules[0].Name $appRule.Name
		Assert-AreEqual $appRc.Rules[0].Description $appRule.Description

		Assert-AreEqual 1 $appRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $appRc.Rules[0].SourceAddresses.Count $appRule.SourceAddresses.Count
		Assert-AreEqual $appRc.Rules[0].SourceAddresses[0] $appRule.SourceAddresses[0]

		Assert-AreEqual 2 $appRc.Rules[0].Protocols.Count 
		Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
		Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
		Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]
		
		Assert-AreEqual 2 $appRc.Rules[0].TargetUrls.Count 
		Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
		Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
		Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]

		$networkRc = $getAzureFirewall.NetworkRuleCollections[0]
		$networkRule = $networkRc.Rules[0]

		Assert-AreEqual $networkRcName $networkRc.Name
		Assert-AreEqual $networkRcPriority $networkRc.Priority
		Assert-AreEqual $networkRcActionType $networkRc.Action.Type

		Assert-AreEqual $networkRc.Rules[0].Name $networkRule.Name
		Assert-AreEqual $networkRc.Rules[0].Description $networkRule.Description

		Assert-AreEqual 2 $networkRc.Rules[0].SourceAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses.Count $networkRule.SourceAddresses.Count
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[0] $networkRule.SourceAddresses[0]
		Assert-AreEqual $networkRc.Rules[0].SourceAddresses[1] $networkRule.SourceAddresses[1]

		Assert-AreEqual 1 $networkRc.Rules[0].DestinationAddresses.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationAddresses.Count $networkRule.DestinationAddresses.Count

		Assert-AreEqual 2 $networkRc.Rules[0].Protocols.Count 
		Assert-AreEqual $networkRc.Rules[0].Protocols.Count $networkRule.Protocols.Count
		Assert-AreEqual $networkRc.Rules[0].Protocols[0] $networkRule.Protocols[0]
		Assert-AreEqual $networkRc.Rules[0].Protocols[1] $networkRule.Protocols[1]
		
		Assert-AreEqual 1 $networkRc.Rules[0].DestinationPorts.Count 
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts.Count $networkRule.DestinationPorts.Count
		Assert-AreEqual $networkRc.Rules[0].DestinationPorts[0] $networkRule.DestinationPorts[0]

        # Delete AzureFirewall
        $delete = Remove-AzureRmFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}