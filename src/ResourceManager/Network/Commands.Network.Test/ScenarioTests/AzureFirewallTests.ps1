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
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$publicIpName = Get-ResourceName

	$appRule1Name = "appRule"
	$appRcName = "appRc"
	$appRcPriority = 100
	$appRcActionType = "Allow"
	$appRule1Fqdn1 = "*google.com"
	$appRule1Fqdn2 = "*microsoft.com"
	$appRule1Protocol1 = "http:80"
	$appRule1Protocol2 = "https:443"

	$networkRuleName = "networkRule"
	$networkRcName = "networkRc"
    $networkRcPriority = 100
	$networkRcActionType = "Deny"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
		# Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

		# Create public ip
		$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname
        $azureFirewallIpConfiguration = $getAzureFirewall.IpConfigurations

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
		Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress
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
		Assert-AreEqual @($list[0].IpConfigurations)[0].Subnet.Id $azureFirewallIpConfiguration[0].Subnet.Id
		Assert-AreEqual @($list[0].IpConfigurations)[0].PublicIpAddress.Id $azureFirewallIpConfiguration[0].PublicIpAddress.Id
		Assert-AreEqual @($list[0].IpConfigurations)[0].PrivateIpAddress $azureFirewallIpConfiguration[0].PrivateIpAddress
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getAzureFirewall.NetworkRuleCollections).Count

        # list all Azure Firewalls in the subscription
        $list = Get-AzureRmFirewall 
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getAzureFirewall.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewall.ApplicationRuleCollections).Count

        # Create Application Rule
		$appRule = New-AzureRmFirewallApplicationRule -Name $appRule1Name -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2

		# Create Application Rule Collection
		$appRc = New-AzureRmFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

		# Create Network Rule
		$netRule=New-AzureRmFirewallNetworkRule -Name $networkRuleName -Description "something" -Protocol "Udp" -SourceAddress "10.0.0.0" -DestinationAddress "10.0.0.0" -DestinationPort "90"

		# Create Network Rule Collection
		$netRc = New-AzureRmFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $netRule -ActionType $networkRcActionType

		# Update AzureFirewall with ApplicationRuleCollection and NetworkRuleCollection
		$azureFirewall.ApplicationRuleCollections = $appRc
		$azureFirewall.NetworkRuleCollections = $netRc

		# Set AzureFirewall
        Set-AzureRmFirewall -AzureFirewall $azureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
		Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
		Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count
		Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
		Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollections).Count

		$appRc = $getAzureFirewall.ApplicationRuleCollections[0]
		$appRule = $appRc.Rules[0]

		#verification
		Assert-AreEqual $appRcName $appRc.Name
		Assert-AreEqual $appRcPriority $appRc.Priority
		Assert-AreEqual $appRcActionType $appRc.Action.Type
		Assert-AreEqual 1 $appRc.Rules.Count

		Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
		Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
		Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]
		Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
		Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
		Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]

        # Delete VirtualNetwork - should fail
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual false $delete

        # Delete AzureFirewall
        $delete = Remove-AzureRmFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork again - this time it should succeed
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
Tests creating an Application Rule 
#>
function Test-NewAzureFirewallApplicationRule
{
	# Setup
	$appRule1Name = "appRule"
	$appRule1Fqdn1 = "*google.com"
	$appRule1Fqdn2 = "*microsoft.com"
	$appRule1Protocol1 = "http:80"
	$appRule1Protocol1Port = 80
	$appRule1Protocol1ProtocolType = "http"
	
	$appRule1Protocol2 = "https:443"
	$appRule1Protocol2Port = 443
	$appRule1Protocol2ProtocolType = "https"
	
	# Create Application Rule
	$appRule = New-AzureRmFirewallApplicationRule -Name $appRule1Name -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2

	#verification
	Assert-AreEqual 2 $appRule.TargetUrls.Count
	Assert-AreEqual $appRule1Fqdn1 $appRule.TargetUrls[0]
	Assert-AreEqual $appRule1Fqdn2 $appRule.TargetUrls[1]
	Assert-AreEqual 2 $appRule.Protocols.Count
	Assert-AreEqual $appRule1Protocol1Port $appRule.Protocols[0].Port 
	Assert-AreEqual $appRule1Protocol1ProtocolType $appRule.Protocols[0].ProtocolType
	Assert-AreEqual $appRule1Protocol2Port $appRule.Protocols[1].Port
	Assert-AreEqual $appRule1Protocol2 $appRule.Protocols[1].ProtocolType
}

<#
.SYNOPSIS
Tests creating an Application Rule Collection with rules
#>
function Test-NewAzureFirewallApplicationRuleCollection
{
	# Setup
	$appRcName = "appRc"
	$appRcPriority = 100
	$appRcActionType = "Allow"

	$appRule1Name = "appRule"
	$appRule1Fqdn1 = "*google.com"
	$appRule1Fqdn2 = "*microsoft.com"
	$appRule1Protocol1 = "http:80"
	$appRule1Protocol2 = "https:443"

	$appRule2Name = "appRule2"
	$appRule2Fqdn1 = "*bing.com"
	$appRule2Protocol1 = "http:8080"
	
	# Create Application Rule
	$appRule = New-AzureRmFirewallApplicationRule -Name $appRule1Name -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2

	# Create Application Rule Collection
	$appRc = New-AzureRmFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

	#verification
    Assert-AreEqual $appRcName $appRc.Name
    Assert-AreEqual $appRcPriority $appRc.Priority
	Assert-AreEqual $appRcActionType $appRc.Action.Type
	Assert-AreEqual 1 $appRc.Rules.Count

	Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
	Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
	Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]
	Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
	Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
	Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]

	# Create Application Rule
	$appRule2 = New-AzureRmFirewallApplicationRule -Name $appRule2Name -Protocol $appRule2Protocol1 -TargetFqdn $appRule2Fqdn1

	# Add a rule
	$appRc.AddRule($appRule2)

	#verification
    Assert-AreEqual $appRcName $appRc.Name
    Assert-AreEqual $appRcPriority $appRc.Priority
	Assert-AreEqual $appRcActionType $appRc.Action.Type
	Assert-AreEqual 2 $appRc.Rules.Count

	Assert-AreEqual $appRc.Rules[0].TargetUrls.Count $appRule.TargetUrls.Count
	Assert-AreEqual $appRc.Rules[0].TargetUrls[0] $appRule.TargetUrls[0]
	Assert-AreEqual $appRc.Rules[0].TargetUrls[1] $appRule.TargetUrls[1]
	Assert-AreEqual $appRc.Rules[0].Protocols.Count $appRule.Protocols.Count
	Assert-AreEqual $appRc.Rules[0].Protocols[0] $appRule.Protocols[0]
	Assert-AreEqual $appRc.Rules[0].Protocols[1] $appRule.Protocols[1]

	Assert-AreEqual $appRc.Rules[1].TargetUrls.Count $appRule2.TargetUrls.Count
	Assert-AreEqual $appRc.Rules[1].TargetUrls[0] $appRule2.TargetUrls[0]
	Assert-AreEqual $appRc.Rules[1].Protocols.Count $appRule2.Protocols.Count
	Assert-AreEqual $appRc.Rules[1].Protocols[0] $appRule2.Protocols[0]
}
