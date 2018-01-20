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
Tests SecureGatewayCRUD.
#>
function Test-SecureGatewayCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"

	$vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGateway
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier

        # Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName
        
        #verification
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
		Assert-NotNull $getSecureGateway.Location
		Assert-AreEqual $rglocation $getSecureGateway.Location
		Assert-AreEqual $secureGatewaySkuName $getSecureGateway.Sku.Name
		Assert-AreEqual $secureGatewaySkuTier $getSecureGateway.Sku.Tier
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-AreEqual 0 @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual 0 @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $getSecureGateway.VirtualHub
		Assert-Null $getSecureGateway.VirtualNetwork

        # list all Secure Gateways in the resource group
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
		Assert-AreEqual $list[0].Sku.Name $getSecureGateway.Sku.Name
		Assert-AreEqual $list[0].Sku.Tier $getSecureGateway.Sku.Tier
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $list[0].VirtualHub
		Assert-Null $list[0].VirtualNetwork

		# list all Secure Gateways in the subscription
        $list = Get-AzureRmSecureGateway 
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
		Assert-AreEqual $list[0].Sku.Name $getSecureGateway.Sku.Name
		Assert-AreEqual $list[0].Sku.Tier $getSecureGateway.Sku.Tier
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $list[0].VirtualHub
		Assert-Null $list[0].VirtualNetwork

		# Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

		# Associate the Virtual Network to Secure Gateway
		$secureGateway.VirtualNetwork = $vnet.Id

		# Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
		Assert-NotNull $getSecureGateway.Location
		Assert-AreEqual $rglocation $getSecureGateway.Location
		Assert-AreEqual $secureGatewaySkuName $getSecureGateway.Sku.Name
		Assert-AreEqual $secureGatewaySkuTier $getSecureGateway.Sku.Tier
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-AreEqual 0 @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual 0 @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $getSecureGateway.VirtualHub
		Assert-AreEqual vnet.Id $getSecureGateway.VirtualNetwork

        # Delete VirtualNetwork
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayApplicationRuleCollectionCRUD
#>
function Test-SecureGateway-ApplicationRuleCollectionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $applicationRuleCollection1Name = Get-ResourceName
	$applicationRuleCollection1Priority = 301
	$rulePriority = 1
	$ruleName = "name1"
	$ruleDesc = "sample"
	$ruleDirection = "Inbound"
	$ruleTargetUrl = "https://test.com"
	$ruleProtocolType = "Https"
	$ruleProtocolPort = 3389
	$ruleActionType = "Allow"

    $applicationRuleCollection2Name = Get-ResourceName
	$applicationRuleCollection2Priority = 302
	$rule2Priority = 2
	$rule2Name = "name2"
	$rule2Desc = "sample2"
	$rule2Direction = "Outbound"
	$rule2TargetUrl = "https://test2.com"
	$rule2ProtocolType = "Http"
	$rule2ProtocolPort = 3390
	$rule2ActionType = "Deny"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayApplicationRuleCollection
		$protocol = New-AzureRmSecureGatewayApplicationProtocolConfig -ProtocolType $ruleProtocolType -Port $ruleProtocolPort
		$action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $ruleActionType
		$ruleConfig = New-AzureRmSecureGatewayApplicationRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollection1Name -Priority $applicationRuleCollection1Priority -Rules $ruleConfig

		# Create SecureGateway with an Application Rule Collection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -ApplicationRuleCollections $ruleCollection

        # Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName

        #verification
		# Verify Secure Gateway
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
		Assert-NotNull $getSecureGateway.Location
		Assert-AreEqual $rglocation $getSecureGateway.Location
		Assert-AreEqual $secureGatewaySkuName $getSecureGateway.Sku.Name
		Assert-AreEqual $secureGatewaySkuTier $getSecureGateway.Sku.Tier
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-AreEqual 0 @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $getSecureGateway.VirtualHub
		Assert-Null $getSecureGateway.VirtualNetwork

		# Verify Secure Gateway Application Rule Collection
        Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[0].Rules).Count
        Assert-AreEqual $applicationRuleCollection1Name $getSecureGateway.ApplicationRuleCollections[0].Name
		Assert-AreEqual $applicationRuleCollection1Priority $getSecureGateway.ApplicationRuleCollections[0].Priority
		Assert-NotNull $getSecureGateway.ApplicationRuleCollections[0].Etag

		# Verify Rule
		Assert-AreEqual $ruleName $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Name
        Assert-AreEqual $ruleDesc $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Description
		Assert-AreEqual $ruleDirection $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Direction
		Assert-AreEqual $rulePriority $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Priority
		
		# Verify Rule Target URLs
		Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[0].Rules[0].TargetUrls).Count
		Assert-AreEqual $ruleTargetUrl $getSecureGateway.ApplicationRuleCollections[0].Rules[0].TargetUrls[0]

		# Verify Rule Protocols
		Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[0].Rules[0].Protocols).Count
		Assert-AreEqual $ruleProtocolType $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Protocols[0].ProtocolType
		Assert-AreEqual $ruleProtocolPort $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Protocols[0].Port

		# Verify Rule Actions
		Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[0].Rules[0].Actions).Count
		Assert-AreEqual $ruleActionType $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Actions[0].ActionType

        # List SecureGateways
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
		Assert-AreEqual $list[0].Sku.Name $getSecureGateway.Sku.Name
		Assert-AreEqual $list[0].Sku.Tier $getSecureGateway.Sku.Tier
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $list[0].VirtualHub
		Assert-Null $list[0].VirtualNetwork

        Assert-AreEqual $list[0].ApplicationRuleCollections[0].Name $getSecureGateway.ApplicationRuleCollections[0].Name
        Assert-AreEqual $list[0].ApplicationRuleCollections[0].Etag $getSecureGateway.ApplicationRuleCollections[0].Etag

        # Add a Secure Gateway Application Rule Collection
		$protocol = New-AzureRmSecureGatewayApplicationProtocolConfig -ProtocolType $rule2ProtocolType -Port $rule2ProtocolPort
		$action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $rule2ActionType
		$ruleConfig = New-AzureRmSecureGatewayApplicationRuleConfig –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Direction $rule2Direction -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action
        $secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName | Add-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollection2Name -Priority $applicationRuleCollection2Priority -Rules $ruleConfig

		# Verify 
		Assert-AreEqual 2 @($secureGateway.ApplicationRuleCollections).Count
		Assert-NotNull $secureGateway.ApplicationRuleCollections[1].Etag
		Assert-AreEqual $applicationRuleCollection1Name $secureGateway.ApplicationRuleCollections[0].Name
		Assert-AreEqual $applicationRuleCollection2Name $secureGateway.ApplicationRuleCollections[1].Name
		
		# Get ApplicationRuleCollection
		$applicationRuleCollection2 = $secureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection -name $applicationRuleCollection2Name 

		# Verify Secure Gateway Application Rule Collection
		Assert-AreEqual $applicationRuleCollection2.Name $secureGateway.ApplicationRuleCollections[1].Name
		Assert-AreEqual $applicationRuleCollection2Priority $getSecureGateway.ApplicationRuleCollections[1].Priority

		# Verify Rule
		Assert-AreEqual $rule2Name $getSecureGateway.ApplicationRuleCollections[1].Rules[0].Name
        Assert-AreEqual $rule2Desc $getSecureGateway.ApplicationRuleCollections[1].Rules[0].Description
		Assert-AreEqual $rule2Direction $getSecureGateway.ApplicationRuleCollections[1].Rules[0].Direction
		Assert-AreEqual $rule2Priority $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Priority
		
		# Verify Rule Target URLs
		Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[1].Rules[0].TargetUrls).Count
		Assert-AreEqual $rule2TargetUrl $getSecureGateway.ApplicationRuleCollections[1].Rules[0].TargetUrls[0]

		# Verify Rule Protocols
		Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[1].Rules[0].Protocols).Count
		Assert-AreEqual $rule2ProtocolType $getSecureGateway.ApplicationRuleCollections[1].Rules[0].Protocols[0].ProtocolType
		Assert-AreEqual $rule2ProtocolPort $getSecureGateway.ApplicationRuleCollections[1].Rules[0].Protocols[0].Port

		# Verify Rule Actions
		Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections[1].Rules[0].Actions).Count
		Assert-AreEqual $rule2ActionType $getSecureGateway.ApplicationRuleCollections[1].Rules[0].Actions[0].ActionType

	    # List ApplicationRuleCollection
		$applicationRuleCollections = $secureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection -SecureGateway $secureGateway
		Assert-AreEqual 2 @($applicationRuleCollections).Count
		Assert-AreEqual $applicationRuleCollections[0].Name $secureGateway.ApplicationRuleCollections[0].Name
		Assert-AreEqual $applicationRuleCollections[1].Name $secureGateway.ApplicationRuleCollections[1].Name
		
		# Set ApplicationRuleCollection with new priority and rule
		$priority3 = 5000
		$ruleConfig = New-AzureRmSecureGatewayApplicationRuleConfig –Name "newRule" -Description $rule2Desc -Priority $rule2Priority -Direction $rule2Direction -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action
		$secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName | Set-AzureRmSecureGatewayApplicationRuleCollection -Name $applicationRuleCollection2Name -Priority $priority3 -Rules $ruleConfig | Set-AzureRmSecureGateway
		$applicationRuleCollection2 = $secureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection -name $applicationRuleCollection2Name
		Assert-AreEqual $priority3 $applicationRuleCollection2.Priority
		Assert-AreEqual 1 @($applicationRuleCollection2.Rules).Count
		Assert-AreEqual $ruleConfig.Name $applicationRuleCollection2.Rules[0].Name

		# Remove ApplicationRuleCollection
		$secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName | Remove-AzureRmSecureGatewayApplicationRuleCollection -Name $applicationRuleCollection2Name | Set-AzureRmSecureGateway
		$applicationRuleCollections = $secureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection
		Assert-AreEqual 1 @($applicationRuleCollections).Count
		Assert-AreEqual $applicationRuleCollection1Name $applicationRuleCollections[0].Name

        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayNetworkRuleCollectionCRUD
#>
function Test-SecureGateway-NetworkRuleCollectionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $networkRuleCollection1Name = Get-ResourceName
	$networkRuleCollection1Priority = 301
	$ruleName = "name1"
	$ruleDesc = "sample"
	$rulePriority = 10
	$ruleDirection = "Inbound"
	$ruleSourceIp = "10.0.0.0"
	$ruleDestinationIp = "10.0.0.1"
	$ruleSourcePort = "3389"
	$ruleDestinationPort = "3390"
	$ruleActionType = "Allow"
	$ruleProtocolType = "TCP"

    $networkRuleCollection2Name = Get-ResourceName
	$networkRuleCollection2Priority = 302
	$rule2Name = "name2"
	$rule2Desc = "sample2"
	$rule2Priority = 20
	$rule2Direction = "Outbound"
	$rule2SourceIp = "20.0.0.0"
	$rule2DestinationIp = "20.0.0.1"
	$rule2SourcePort = "4389"
	$rule2DestinationPort = "4390"
	$rule2ActionType = "Deny"
	$rule2ProtocolType = "UDP"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayNetworkRuleCollection
		$action = New-AzureRmSecureGatewayNetworkRuleActionConfig -ActionType $ruleActionType
		$ruleConfig = New-AzureRmSecureGatewayNetworkRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $ruleProtocolType -SourceIp $ruleSourceIp -DestinationIp $ruleDestinationIp -SourcePorts $ruleSourcePort -DestinationPort $ruleDestinationPort -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayNetworkRuleCollection –Name $networkRuleCollection1Name -Priority $networkRuleCollection1Priority -Rules $ruleConfig

		# Create SecureGateway with an Network Rule Collection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -NetworkRuleCollections $ruleCollection

        # Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName

        #verification
		# Verify Secure Gateway
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
		Assert-NotNull $getSecureGateway.Location
		Assert-AreEqual $rglocation $getSecureGateway.Location
		Assert-AreEqual $secureGatewaySkuName $getSecureGateway.Sku.Name
		Assert-AreEqual $secureGatewaySkuTier $getSecureGateway.Sku.Tier
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual 0 @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $getSecureGateway.VirtualHub
		Assert-Null $getSecureGateway.VirtualNetwork

		# Verify Secure Gateway Network Rule Collection
        Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules).Count
        Assert-AreEqual $networkRuleCollection1Name $getSecureGateway.NetworkRuleCollections[0].Name
		Assert-AreEqual $networkRuleCollection1Priority $getSecureGateway.NetworkRuleCollections[0].Priority
		Assert-NotNull $getSecureGateway.NetworkRuleCollections[0].Etag

		# Verify Rule
		Assert-AreEqual $ruleName $getSecureGateway.NetworkRuleCollections[0].Rules[0].Name
        Assert-AreEqual $ruleDesc $getSecureGateway.NetworkRuleCollections[0].Rules[0].Description
		Assert-AreEqual $ruleDirection $getSecureGateway.NetworkRuleCollections[0].Rules[0].Direction
		Assert-AreEqual $rulePriority $getSecureGateway.NetworkRuleCollections[0].Rules[0].Priority
		
		# Verify Rule Protocols
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules[0].Protocols).Count
		Assert-AreEqual $ruleProtocolType $getSecureGateway.NetworkRuleCollections[0].Rules[0].Protocols[0]

		# Verify Rule Source IPs
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules[0].SourceIps).Count
		Assert-AreEqual $ruleSourceIp $getSecureGateway.NetworkRuleCollections[0].Rules[0].SourceIps[0]

		# Verify Rule Destination IPs
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules[0].DestinationIps).Count
		Assert-AreEqual $ruleDestinationIp $getSecureGateway.NetworkRuleCollections[0].Rules[0].DestinationIps[0]

		# Verify Rule Source Ports
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules[0].SourcePorts).Count
		Assert-AreEqual $ruleSourcePort $getSecureGateway.NetworkRuleCollections[0].Rules[0].SourcePorts[0]

		# Verify Rule Destination Ports
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules[0].DestinationPorts).Count
		Assert-AreEqual $ruleDestinationPort $getSecureGateway.NetworkRuleCollections[0].Rules[0].DestinationPorts[0]

		# Verify Rule Actions
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[0].Rules[0].Actions).Count
		Assert-AreEqual $ruleActionType $getSecureGateway.NetworkRuleCollections[0].Rules[0].Actions[0].ActionType

        # List SecureGateways
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
		Assert-AreEqual $list[0].Sku.Name $getSecureGateway.Sku.Name
		Assert-AreEqual $list[0].Sku.Tier $getSecureGateway.Sku.Tier
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getSecureGateway.NetworkRuleCollections).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count
		Assert-Null $list[0].VirtualHub
		Assert-Null $list[0].VirtualNetwork

        Assert-AreEqual $list[0].NetworkRuleCollections[0].Name $getSecureGateway.NetworkRuleCollections[0].Name
        Assert-AreEqual $list[0].NetworkRuleCollections[0].Etag $getSecureGateway.NetworkRuleCollections[0].Etag

        # Add a Secure Gateway Network Rule Collection
		$action = New-AzureRmSecureGatewayNetworkRuleActionConfig -ActionType $rule2ActionType
		$ruleConfig = New-AzureRmSecureGatewayNetworkRuleConfig –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Direction $rule2Direction -Protocols $rule2ProtocolType -SourceIp $rule2SourceIp -DestinationIp $rule2DestinationIp -SourcePorts $rule2SourcePort -DestinationPort $rule2DestinationPort -Actions $action
        $secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName | Add-AzureRmSecureGatewayNetworkRuleCollection –Name $networkRuleCollection2Name -Priority $networkRuleCollection2Priority -Rules $ruleConfig

		# Verify 
		Assert-AreEqual 2 @($secureGateway.NetworkRuleCollections).Count
		Assert-NotNull $secureGateway.NetworkRuleCollections[1].Etag
		Assert-AreEqual $networkRuleCollection1Name $secureGateway.NetworkRuleCollections[0].Name
		Assert-AreEqual $networkRuleCollection2Name $secureGateway.NetworkRuleCollections[1].Name
		
		# Get NetworkRuleCollection
		$networkRuleCollection2 = $secureGateway | Get-AzureRmSecureGatewayNetworkRuleCollection -name $networkRuleCollection2Name 

		# Verify Secure Gateway Network Rule Collection
		Assert-AreEqual $networkRuleCollection2.Name $secureGateway.NetworkRuleCollections[1].Name
		Assert-AreEqual $networkRuleCollection2Priority $getSecureGateway.NetworkRuleCollections[1].Priority

		# Verify Rule
		Assert-AreEqual $rule2Name $getSecureGateway.NetworkRuleCollections[1].Rules[0].Name
        Assert-AreEqual $rule2Desc $getSecureGateway.NetworkRuleCollections[1].Rules[0].Description
		Assert-AreEqual $rule2Direction $getSecureGateway.NetworkRuleCollections[1].Rules[0].Direction
		Assert-AreEqual $rule2Priority $getSecureGateway.NetworkRuleCollections[1].Rules[0].Priority
		
		# Verify Rule Protocols
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[1].Rules[0].Protocols).Count
		Assert-AreEqual $rule2ProtocolType $getSecureGateway.NetworkRuleCollections[1].Rules[0].Protocols[0]

		# Verify Rule Source IPs
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[1].Rules[0].SourceIps).Count
		Assert-AreEqual $rule2SourceIp $getSecureGateway.NetworkRuleCollections[1].Rules[0].SourceIps[0]

		# Verify Rule Destination IPs
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[1].Rules[0].DestinationIps).Count
		Assert-AreEqual $rule2DestinationIp $getSecureGateway.NetworkRuleCollections[1].Rules[0].DestinationIps[0]

		# Verify Rule Source Ports
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[1].Rules[0].SourcePorts).Count
		Assert-AreEqual $rule2SourcePort $getSecureGateway.NetworkRuleCollections[1].Rules[0].SourcePorts[0]

		# Verify Rule Destination Ports
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[1].Rules[0].DestinationPorts).Count
		Assert-AreEqual $rule2DestinationPort $getSecureGateway.NetworkRuleCollections[1].Rules[0].DestinationPorts[0]

		# Verify Rule Actions
		Assert-AreEqual 1 @($getSecureGateway.NetworkRuleCollections[1].Rules[0].Actions).Count
		Assert-AreEqual $rule2ActionType $getSecureGateway.NetworkRuleCollections[1].Rules[0].Actions[0].ActionType

	    # List NetworkRuleCollection
		$networkRuleCollections = $secureGateway | Get-AzureRmSecureGatewayNetworkRuleCollection -SecureGateway $secureGateway
		Assert-AreEqual 2 @($networkRuleCollections).Count
		Assert-AreEqual $networkRuleCollections[0].Name $secureGateway.NetworkRuleCollections[0].Name
		Assert-AreEqual $networkRuleCollections[1].Name $secureGateway.NetworkRuleCollections[1].Name
		
		# Set NetworkRuleCollection with new priority and rule
		$priority3 = 5000
		$ruleConfig = New-AzureRmSecureGatewayNetworkRuleConfig –Name "newRule" -Description $rule2Desc -Priority $rulePriority -Direction $ruleDirection -Protocols $ruleProtocolType -SourceIp $ruleSourceIp -DestinationIp $ruleDestinationIp -SourcePorts $ruleSourcePort -DestinationPort $ruleDestinationPort -Actions $action
		$secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName | Set-AzureRmSecureGatewayNetworkRuleCollection -Name $networkRuleCollection2Name -Priority $priority3 -Rules $ruleConfig | Set-AzureRmSecureGateway
		$networkRuleCollection2 = $secureGateway | Get-AzureRmSecureGatewayNetworkRuleCollection -name $networkRuleCollection2Name
		Assert-AreEqual $priority3 $networkRuleCollection2.Priority
		Assert-AreEqual 1 @($networkRuleCollection2.Rules).Count
		Assert-AreEqual $ruleConfig.Name $networkRuleCollection2.Rules[0].Name

		# Remove NetworkRuleCollection
		$secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName | Remove-AzureRmSecureGatewayNetworkRuleCollection -Name $networkRuleCollection2Name | Set-AzureRmSecureGateway
		$networkRuleCollections = $secureGateway | Get-AzureRmSecureGatewayNetworkRuleCollection
		Assert-AreEqual 1 @($networkRuleCollections).Count
		Assert-AreEqual $networkRuleCollection1Name $networkRuleCollections[0].Name

        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayApplicationRuleCRUD
#>
function Test-SecureGateway-ApplicationRuleCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $applicationRuleCollectionName = Get-ResourceName
	$applicationRuleCollectionPriority = 301
	$ruleName = "name1"
	$rulePriority = 1
	$ruleDesc = "sample"
	$ruleDirection = "Inbound"
	$ruleTargetUrl = "https://test.com"
	$ruleProtocolType = "Https"
	$ruleProtocolPort = 3389
	$ruleActionType = "Allow"

	$rule2Name = "name2"
	$rule2Priority = 2
	$rule2Desc = "sample2"
	$rule2Direction = "Outbound"
	$rule2TargetUrl = "https://test2.com"
	$rule2ProtocolType = "Http"
	$rule2ProtocolPort = 3390
	$rule2ActionType = "Deny"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Application/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayApplicationRuleCollection
		$action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $ruleActionType
		$protocol = New-AzureRmSecureGatewayApplicationProtocolConfig -ProtocolType $rule1ProtocolType -Port $rule1ProtocolPort
		$ruleConfig = New-AzureRmSecureGatewayApplicationRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollectionName -Priority $applicationRuleCollectionPriority -Rules $ruleConfig

		# Create SecureGateway with a SecureGatewayApplicationRuleCollection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -ApplicationRuleCollections $ruleCollection

        # Get ApplicationRuleCollection
		$applicationRuleCollection = $getSecureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection -name $applicationRuleCollectionName 

		# Verify Rule has been created
		Assert-AreEqual 1 @($applicationRuleCollection.Rules).Count
		Assert-AreEqual $ruleName $applicationRuleCollection.Rules[0].Name
        Assert-AreEqual $ruleDesc $applicationRuleCollection.Rules[0].Description
		Assert-AreEqual $ruleDirection $applicationRuleCollection.Rules[0].Direction
		Assert-AreEqual $rulePriority $applicationRuleCollection.Rules[0].Priority
		
		# Verify Secure Gateway Application Rule Collection Rule Target URLs
		Assert-AreEqual 1 @($applicationRuleCollection.Rules[0].TargetUrls).Count
		Assert-AreEqual $ruleTargetUrl $applicationRuleCollection.Rules[0].TargetUrls[0]

		# Verify Secure Gateway Application Rule Collection Rule Protocols
		Assert-AreEqual 1 @($applicationRuleCollection.Rules[0].Protocols).Count
		Assert-AreEqual $ruleProtocolType $applicationRuleCollection.Rules[0].Protocols[0].ProtocolType
		Assert-AreEqual $ruleProtocolPort $applicationRuleCollection.Rules[0].Protocols[0].Port

		# Verify Secure Gateway Application Rule Collection Rule Actions
		Assert-AreEqual 1 @($applicationRuleCollection.Rules[0].Actions).Count
		Assert-AreEqual $ruleActionType $applicationRuleCollection.Rules[0].Actions[0].ActionType

        # Add a Rule 
		$action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $rule2ActionType
        $getApplicationRuleCollection = Get-AzureRmSecureGatewayApplicationRuleCollection -Name $applicationRuleCollectionName -SecureGateway $getSecureGateway | Add-AzureRmSecureGatewayApplicationRuleConfig –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Direction $rule2Direction -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action

		# Verify a rule was added
		Assert-AreEqual 2 @($getApplicationRuleCollection.Rules).Count
		Assert-AreEqual $ruleName $getApplicationRuleCollection.Rules[0].Name
		Assert-AreEqual $rule2Name $getApplicationRuleCollection.Rules[1].Name

		# Get Rule 2
		$rule2 = $getApplicationRuleCollection | Get-AzureRmSecureGatewayApplicationRuleConfig -Name $rule2Name

		# Verify Rule 2
		Assert-AreEqual $rule2Name $rule2.Name
        Assert-AreEqual $rule2Desc $rule2.Description
		Assert-AreEqual $rule2Direction $rule2.Direction
		Assert-AreEqual $rule2Priority $rule2.Priority
		
		# Verify Rule Target URLs
		Assert-AreEqual 1 @($rule2.TargetUrls).Count
		Assert-AreEqual $rule2TargetUrl $rule2.TargetUrls[0]

		# Verify Rule Protocols
		Assert-AreEqual 1 @($rule2.Protocols).Count
		Assert-AreEqual $rule2ProtocolType $rule2.Protocols[0].ProtocolType
		Assert-AreEqual $rule2ProtocolPort $rule2.Protocols[0].Port

		# Verify Rule Actions
		Assert-AreEqual 1 @($rule2.Actions).Count
		Assert-AreEqual $rule2ActionType $rule2.Actions[0].ActionType

	    # List Rules
		$rules = Get-AzureRmSecureGatewayApplicationRuleConfig -SecureGatewayApplicationRuleCollection  $getApplicationRuleCollection

		# Verify list of rules
		Assert-AreEqual 2 @($rules).Count
		Assert-AreEqual $rules[0].Name $getApplicationRuleCollection.Rules[0].Name
		Assert-AreEqual $rules[1].Name $getApplicationRuleCollection.Rules[1].Name
		
		# Set ApplicationRule with new priority 
		$priority3 = 5000
		$applicationRuleCollection = $getApplicationRuleCollection | Set-AzureRmSecureGatewayApplicationRuleConfig –Name $rule2Name -Description $rule2Desc -Priority $priority3 -Direction $rule2Direction -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action
		$rule = $applicationRuleCollection | Get-AzureRmSecureGatewayApplicationRuleConfig -name $rule2Name
		Assert-AreEqual $priority3 $rule.Priority

		# Remove Rule 2
		$getApplicationRuleCollection = $applicationRuleCollection | Remove-AzureRmSecureGatewayApplicationRuleConfig -Name $rule2Name | Set-AzureRmSecureGatewayApplicationRuleCollection
		$rules = $getApplicationRuleCollection | Get-AzureRmSecureGatewayApplicationRuleConfig
		Assert-AreEqual 1 @($rules).Count
		Assert-AreEqual $ruleName $rules[0].Name

        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayNetworkRuleCRUD
#>
function Test-SecureGateway-NetworkRuleCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $networkRuleCollectionName = Get-ResourceName
	$networkRuleCollectionPriority = 301
	$ruleName = "name1"
	$ruleDesc = "sample"
	$rulePriority = 10
	$ruleDirection = "Inbound"
	$ruleSourceIp = "10.0.0.0"
	$ruleDestinationIp = "10.0.0.1"
	$ruleSourcePort = "3389"
	$ruleDestinationPort = "3390"
	$ruleActionType = "Allow"
	$ruleProtocolType = "TCP"

	$rule2Name = "name2"
	$rule2Desc = "sample"
	$rule2Priority = 11
	$rule2Direction = "Outbound"
	$rule2SourceIp = "20.0.0.0"
	$rule2DestinationIp = "20.0.0.1"
	$rule2SourcePort = "4389"
	$rule2DestinationPort = "4390"
	$rule2ActionType = "Deny"
	$rule2ProtocolType = "UDP"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayNetworkRuleCollection
		$action = New-AzureRmSecureGatewayNetworkRuleActionConfig -ActionType $ruleActionType
		$ruleConfig = New-AzureRmSecureGatewayNetworkRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $ruleProtocolType -SourceIp $ruleSourceIp -DestinationIp $ruleDestinationIp -SourcePorts $ruleSourcePort -DestinationPort $ruleDestinationPort -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayNetworkRuleCollection –Name $networkRuleCollectionName -Priority $networkRuleCollectionPriority -Rules $ruleConfig

		# Create SecureGateway with a SecureGatewayNetworkRuleCollection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -NetworkRuleCollections $ruleCollection

        # Get NetworkRuleCollection
		$networkRuleCollection = $getSecureGateway | Get-AzureRmSecureGatewayNetworkRuleCollection -name $networkRuleCollectionName 

		# Verify Rule
		Assert-AreEqual 1 @($networkRuleCollection.Rules).Count
		Assert-AreEqual $ruleName $getApplicationRuleCollection.Rules[0].Name
        Assert-AreEqual $ruleDesc $networkRuleCollection.Rules[0].Description
		Assert-AreEqual $ruleDirection $networkRuleCollection.Rules[0].Direction
		Assert-AreEqual $rulePriority $networkRuleCollection.Rules[0].Priority
		
		# Verify Secure Gateway Network Rule Collection Rule Protocols
		Assert-AreEqual 1 @($networkRuleCollection.Rules[0].Protocols).Count
		Assert-AreEqual $ruleProtocolType $networkRuleCollection.Rules[0].Protocols[0]

		# Verify Secure Gateway Network Rule Collection Rule Source IPs
		Assert-AreEqual 1 @($networkRuleCollection.Rules[0].SourceIps).Count
		Assert-AreEqual $ruleSourceIp $networkRuleCollection.Rules[0].SourceIps[0]

		# Verify Secure Gateway Network Rule Collection Rule Destination IPs
		Assert-AreEqual 1 @($networkRuleCollection.Rules[0].DestinationIps).Count
		Assert-AreEqual $ruleDestinationIp $networkRuleCollection.Rules[0].DestinationIps[0]

		# Verify Secure Gateway Network Rule Collection Rule Source Ports
		Assert-AreEqual 1 @($networkRuleCollection.Rules[0].SourcePorts).Count
		Assert-AreEqual $ruleSourcePort $networkRuleCollection.Rules[0].SourcePorts[0]

		# Verify Secure Gateway Network Rule Collection Rule Destination Ports
		Assert-AreEqual 1 @($networkRuleCollection.Rules[0].DestinationPorts).Count
		Assert-AreEqual $ruleDestinationPort $networkRuleCollection.Rules[0].DestinationPorts[0]

		# Verify Secure Gateway Network Rule Collection Rule Actions
		Assert-AreEqual 1 @($networkRuleCollection.Rules[0].Actions).Count
		Assert-AreEqual $ruleActionType $networkRuleCollection.Rules[0].Actions[0].ActionType

        # Add a Rule 
		$action = New-AzureRmSecureGatewayNetworkRuleActionConfig -ActionType $rule2ActionType
        $getNetworkRuleCollection = Get-AzureRmSecureGatewayNetworkRuleCollection -Name $networkRuleCollectionName -SecureGateway $getSecureGateway | Add-AzureRmSecureGatewayNetworkRuleConfig –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Direction $rule2Direction -Protocols $rule2ProtocolType -SourceIp $rule2SourceIp -DestinationIp $rule2DestinationIp -SourcePorts $rule2SourcePort -DestinationPort $rule2DestinationPort -Actions $action

		# Verify a rule was added
		Assert-AreEqual 2 @($getNetworkRuleCollection.Rules).Count
		Assert-AreEqual $ruleName $getNetworkRuleCollection.Rules[0].Name
		Assert-AreEqual $rule2Name $getNetworkRuleCollection.Rules[1].Name

		# Get Rule 2
		$rule2 = $getNetworkRuleCollection | Get-AzureRmSecureGatewayNetworkRuleConfig -Name $rule2Name

		# Verify Rule 2
		Assert-AreEqual $rule2Name $rule2.Name
        Assert-AreEqual $rule2Desc $rule2.Description
		Assert-AreEqual $rule2Direction $rule2.Direction
		Assert-AreEqual $rule2Priority $rule2.Priority
		
		# Verify Secure Gateway Network Rule Collection Rule Protocols
		Assert-AreEqual 1 @($rule2.Protocols).Count
		Assert-AreEqual $rule2ProtocolType $rule2.Protocols[0]

		# Verify Secure Gateway Network Rule Collection Rule Source IPs
		Assert-AreEqual 1 @($rule2.SourceIps).Count
		Assert-AreEqual $rule2SourceIp $rule2.SourceIps[0]

		# Verify Secure Gateway Network Rule Collection Rule Destination IPs
		Assert-AreEqual 1 @($rule2.DestinationIps).Count
		Assert-AreEqual $rule2DestinationIp $rule2.DestinationIps[0]

		# Verify Secure Gateway Network Rule Collection Rule Source Ports
		Assert-AreEqual 1 @($rule2.SourcePorts).Count
		Assert-AreEqual $rule2SourcePort $rule2.SourcePorts[0]

		# Verify Secure Gateway Network Rule Collection Rule Destination Ports
		Assert-AreEqual 1 @($rule2.DestinationPorts).Count
		Assert-AreEqual $rule2DestinationPort $rule2.DestinationPorts[0]

		# Verify Secure Gateway Network Rule Collection Rule Actions
		Assert-AreEqual 1 @($rule2.Actions).Count
		Assert-AreEqual $rule2ActionType $rule2.Actions[0].ActionType

	    # List Rules
		$rules = Get-AzureRmSecureGatewayNetworkRuleConfig -SecureGatewayNetworkRuleCollection  $getNetworkRuleCollection

		# Verify list of rules
		Assert-AreEqual 2 @($rules).Count
		Assert-AreEqual $rules[0].Name $getNetworkRuleCollection.Rules[0].Name
		Assert-AreEqual $rules[1].Name $getNetworkRuleCollection.Rules[1].Name
		
		# Set NetworkRule with new priority 
		$priority3 = 5000
		$networkRuleCollection = $getNetworkRuleCollection | Set-AzureRmSecureGatewayNetworkRuleConfig –Name $rule2Name -Description $rule2Desc -Priority $priority3 -Direction $rule2Direction -Protocols $rule2ProtocolType -SourceIp $rule2SourceIp -DestinationIp $rule2DestinationIp -SourcePorts $rule2SourcePort -DestinationPort $rule2DestinationPort -Actions $action
		$rule = $networkRuleCollection | Get-AzureRmSecureGatewayNetworkRuleConfig -name $rule2Name
		Assert-AreEqual $priority3 $rule.Priority

		# Remove Rule 2
		$getNetworkRuleCollection = $networkRuleCollection | Remove-AzureRmSecureGatewayNetworkRuleConfig -Name $rule2Name | Set-AzureRmSecureGatewayNetworkRuleCollection
		$rules = $getNetworkRuleCollection | Get-AzureRmSecureGatewayNetworkRuleConfig
		Assert-AreEqual 1 @($rules).Count
		Assert-AreEqual $ruleName $rules[0].Name

        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayApplicationRuleActionCRUD
#>
function Test-SecureGateway-ApplicationRuleActionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $applicationRuleCollectionName = Get-ResourceName
	$applicationRuleCollectionPriority = 301
	$ruleName = "name1"
	$rulePriority = 1
	$ruleDesc = "sample"
	$ruleDirection = "Inbound"
	$ruleTargetUrl = "https://test.com"
	$ruleProtocolType = "Https"
	$ruleProtocolPort = 3389
	$ruleActionType = "Allow"

	$rule2ActionType = "Deny"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Application/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayApplicationRuleCollection
		$action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $ruleActionType
		$protocol = New-AzureRmSecureGatewayApplicationProtocolConfig -ProtocolType $ruleProtocolType -Port $ruleProtocolPort
		$ruleConfig = New-AzureRmSecureGatewayApplicationRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollectionName -Priority $applicationRuleCollectionPriority -Rules $ruleConfig

		# Create SecureGateway with a SecureGatewayApplicationRuleCollection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -ApplicationRuleCollections $ruleCollection

        # Get ApplicationRuleCollection
		$applicationRuleCollection = $getSecureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection -name $applicationRuleCollectionName 

		# Get Rule
		$rule = $getApplicationRuleCollection | Get-AzureRmSecureGatewayApplicationRuleConfig -Name $ruleName

		# Verify Rule Actions
		Assert-AreEqual 1 @($rule.Actions).Count
		Assert-AreEqual $ruleActionType $rule.Actions[0].ActionType

        # Add a Rule Action 
        $getRule = Get-AzureRmSecureGatewayApplicationRuleConfig -Name $ruleName -SecureGatewayApplicationRuleCollection $applicationRulecollection | Add-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $rule2ActionType

		# Verify a RuleAction was added
		Assert-AreEqual 2 @($getRule.Actions).Count
		Assert-AreEqual $ruleActionType $getRule.Actions[0].ActionType
		Assert-AreEqual $rule2ActionType $getRule.Actions[1].ActionType

	    # List Rule Actions
		$actions = Get-AzureRmSecureGatewayApplicationRuleActionConfig -SecureGatewayApplicationRuleConfig $getRule

		# Verify list of Rule Actions
		Assert-AreEqual 2 @($actions).Count
		Assert-AreEqual $actions[0].ActionType $getRule.Actions[0].ActionType
		Assert-AreEqual $actions[1].ActionType $getRule.Actions[1].ActionType
		
        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayNetworkRuleActionCRUD
#>
function Test-SecureGateway-NetworkRuleActionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $networkRuleCollectionName = Get-ResourceName
	$networkRuleCollectionPriority = 301
	$ruleName = "name1"
	$ruleDesc = "sample"
	$rulePriority = 10
	$ruleDirection = "Inbound"
	$ruleSourceIp = "10.0.0.0"
	$ruleDestinationIp = "10.0.0.1"
	$ruleSourcePort = "3389"
	$ruleDestinationPort = "3390"
	$ruleProtocolType = "TCP"
	$ruleActionType = "Allow"

	$rule2ActionType = "Deny"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayNetworkRuleCollection
		$action = New-AzureRmSecureGatewayNetworkRuleActionConfig -ActionType $ruleActionType
		$ruleConfig = New-AzureRmSecureGatewayNetworkRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $ruleProtocolType -SourceIp $ruleSourceIp -DestinationIp $ruleDestinationIp -SourcePorts $ruleSourcePort -DestinationPort $ruleDestinationPort -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayNetworkRuleCollection –Name $networkRuleCollectionName -Priority $networkRuleCollectionPriority -Rules $ruleConfig

		# Create SecureGateway with a SecureGatewayNetworkRuleCollection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -NetworkRuleCollections $ruleCollection

        # Get NetworkRuleCollection
		$networkRuleCollection = $getSecureGateway | Get-AzureRmSecureGatewayNetworkRuleCollection -name $networkRuleCollectionName 

		# Get Rule
		$rule = $getNetworkRuleCollection | Get-AzureRmSecureGatewayNetworkRuleConfig -Name $ruleName

		# Verify Rule Actions
		Assert-AreEqual 1 @($rule.Actions).Count
		Assert-AreEqual $ruleActionType $rule.Actions[0].ActionType

        # Add a Rule Action 
        $getRule = Get-AzureRmSecureGatewayNetworkRuleConfig -Name $ruleName -SecureGatewayNetworkRuleCollection $networkRulecollection | Add-AzureRmSecureGatewayNetworkRuleActionConfig -ActionType $rule2ActionType

		# Verify a RuleAction was added
		Assert-AreEqual 2 @($getRule.Actions).Count
		Assert-AreEqual $ruleActionType $getRule.Actions[0].ActionType
		Assert-AreEqual $rule2ActionType $getRule.Actions[1].ActionType

	    # List Rule Actions
		$actions = Get-AzureRmSecureGatewayNetworkRuleActionConfig -SecureGatewayNetworkRuleConfig $getRule

		# Verify list of Rule Actions
		Assert-AreEqual 2 @($actions).Count
		Assert-AreEqual $actions[0].ActionType $getRule.Actions[0].ActionType
		Assert-AreEqual $actions[1].ActionType $getRule.Actions[1].ActionType
		
        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
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
Tests SecureGatewayApplicationRuleProtocolCRUD
#>
function Test-SecureGateway-ApplicationRuleProtocolCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $secureGatewayName = Get-ResourceName

    $applicationRuleCollectionName = Get-ResourceName
	$applicationRuleCollectionPriority = 301
	$ruleName = "name1"
	$rulePriority = 1
	$ruleDesc = "sample"
	$ruleDirection = "Inbound"
	$ruleTargetUrl = "https://test.com"
	$ruleProtocolType = "Https"
	$ruleProtocolPort = 3389
	$ruleActionType = "Allow"

	$rule2ProtocolType = "Http"
	$rule2ProtocolPort = 3390

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Application/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
	$secureGatewaySkuName = "StandardSmall"
	$secureGatewaySkuTier = "Standard"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayApplicationRuleCollection
		$action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $ruleActionType
		$protocol = New-AzureRmSecureGatewayApplicationProtocolConfig -ProtocolType $ruleProtocolType -Port $ruleProtocolPort
		$ruleConfig = New-AzureRmSecureGatewayApplicationRuleConfig –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Direction $ruleDirection -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
		$ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollectionName -Priority $applicationRuleCollectionPriority -Rules $ruleConfig

		# Create SecureGateway with a SecureGatewayApplicationRuleCollection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -SkuName $secureGatewaySkuName -SkuTier $secureGatewaySkuTier -ApplicationRuleCollections $ruleCollection

        # Get ApplicationRuleCollection
		$applicationRuleCollection = $getSecureGateway | Get-AzureRmSecureGatewayApplicationRuleCollection -name $applicationRuleCollectionName 

		# Get Rule
		$rule = $getApplicationRuleCollection | Get-AzureRmSecureGatewayApplicationRuleConfig -Name $ruleName

		# Verify Rule Protocols
		Assert-AreEqual 1 @($rule.Protocols).Count
		Assert-AreEqual $ruleProtocolType $rule.Protocols[0].ProtocolType
		Assert-AreEqual $ruleProtocolPort $rule.Protocols[0].Port

        # Add a Rule Protocol 
        $getRule = Get-AzureRmSecureGatewayApplicationRuleConfig -Name $ruleName -SecureGatewayApplicationRuleCollection $applicationRulecollection | Add-AzureRmSecureGatewayApplicationRuleProtocolConfig -ProtocolType $rule2ProtocolType -Port $rule2ProtocolPort

		# Verify a Rule Protocol was added
		Assert-AreEqual 2 @($getRule.Protocols).Count
		Assert-AreEqual $ruleProtocolType $getRule.Protocols[0].ProtocolType
		Assert-AreEqual $rule2ProtocolType $getRule.Protocols[1].ProtocolType

	    # List Rule Protocols
		$protocols = Get-AzureRmSecureGatewayApplicationRuleProtocolConfig -SecureGatewayApplicationRuleConfig $getRule

		# Verify list of Rule Protocols
		Assert-AreEqual 2 @($protocols).Count
		Assert-AreEqual $protocols[0].ProtocolType $getRule.Protocols[0].ProtocolType
		Assert-AreEqual $protocols[0].Port $getRule.Protocols[0].Port
		Assert-AreEqual $protocols[1].ProtocolType $getRule.Protocols[1].ProtocolType
		Assert-AreEqual $protocols[1].Port $getRule.Protocols[1].Port
		
        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}