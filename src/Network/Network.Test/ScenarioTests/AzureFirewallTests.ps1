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
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    # AzureFirewallApplicationRuleCollection
    $appRcName = "appRc"
    $appRcPriority = 100
    $appRcActionType = "Allow"

    # AzureFirewallApplicationRuleCollection 2
    $appRc2Name = "appRc2"
    $appRc2Priority = 101
    $appRc2ActionType = "Deny"

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
    $appRule2Port1 = 8080
    $appRule2ProtocolType1 = "http"

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
    $networkRule1Protocol1 = "UDP"
    $networkRule1Protocol2 = "TCP"
    $networkRule1Protocol3 = "ICMP"
    $networkRule1DestinationPort1 = "90"

    # AzureFirewallNatRuleCollection
    $natRcName = "natRc"
    $natRcPriority = 200

    # AzureFirewallNatRule 1
    $natRule1Name = "natRule"
    $natRule1Desc = "desc1"
    $natRule1SourceAddress1 = "10.0.0.0"
    $natRule1SourceAddress2 = "111.1.0.0/24"
    $natRule1DestinationAddress1 = "1.2.3.4"
    $natRule1Protocol1 = "UDP"
    $natRule1Protocol2 = "TCP"
    $natRule1DestinationPort1 = "90"
    $natRule1TranslatedAddress = "10.1.2.3"
    $natRule1TranslatedPort = "91"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual "Alert" $getAzureFirewall.ThreatIntelMode
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NatRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollections).Count

        # list all Azure Firewalls in the resource group
        $list = Get-AzFirewall -ResourceGroupName $rgname
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
        Assert-AreEqual @($list[0].NatRuleCollections).Count @($getAzureFirewall.NatRuleCollections).Count
        Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getAzureFirewall.NetworkRuleCollections).Count

        # list all Azure Firewalls under subscription
        $listAll = Get-AzureRmFirewall
        Assert-NotNull $listAll

        $listAll = Get-AzureRmFirewall -Name "*"
        Assert-NotNull $listAll

        $listAll = Get-AzureRmFirewall -ResourceGroupName "*"
        Assert-NotNull $listAll

        $listAll = Get-AzureRmFirewall -ResourceGroupName "*" -Name "*"
        Assert-NotNull $listAll

        # Create Application Rules
        $appRule = New-AzFirewallApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1

        $appRule2 = New-AzFirewallApplicationRule -Name $appRule2Name -Protocol $appRule2Protocol1 -TargetFqdn $appRule2Fqdn1

        # Create Application Rule Collection with 1 rule
        $appRc = New-AzFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        # Add a rule to the rule collection using AddRule method
        $appRc.AddRule($appRule2)

        # Create a second Application Rule Collection with 1 rule
        $appRc2 = New-AzFirewallApplicationRuleCollection -Name $appRc2Name -Priority $appRc2Priority -Rule $appRule -ActionType $appRc2ActionType

        # Create Network Rule
        $networkRule = New-AzFirewallNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1
        $networkRule.AddProtocol($networkRule1Protocol3)

        # Test handling of incorrect values
        Assert-ThrowsContains { $networkRule.AddProtocol() } "Cannot find an overload"
        Assert-ThrowsContains { $networkRule.AddProtocol($null) } "A protocol must be provided"
        Assert-ThrowsContains { $networkRule.AddProtocol("ABCD") } "Invalid protocol"

        # Create Network Rule Collection
        $netRc = New-AzFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType

        # Create a NAT rule
        $natRule = New-AzFirewallNatRule -Name $natRule1Name -Description $natRule1Desc -Protocol $natRule1Protocol1 -SourceAddress $natRule1SourceAddress1, $natRule1SourceAddress2 -DestinationAddress $publicip.IpAddress -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort
        $natRule.AddProtocol($natRule1Protocol2)

        # Test handling of incorrect values
        Assert-ThrowsContains { $natRule.AddProtocol() } "Cannot find an overload"
        Assert-ThrowsContains { $natRule.AddProtocol($null) } "A protocol must be provided"
        Assert-ThrowsContains { $natRule.AddProtocol("ABCD") } "Invalid protocol"
        # Test handling of ICMP protocol
        Assert-ThrowsContains {
            New-AzFirewallNatRule -Name $natRule1Name -Protocol $natRule1Protocol1,"ICMP" -SourceAddress $natRule1SourceAddress1 -DestinationAddress $natRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort
        } "The argument `"ICMP`" does not belong to the set"
        Assert-ThrowsContains { $natRule.AddProtocol("ICMP") } "Invalid protocol"

        # Create a NAT Rule Collection
        $natRc = New-AzFirewallNatRuleCollection -Name $natRcName -Priority $natRcPriority -Rule $natRule

        # Add ApplicationRuleCollections to the Firewall using method AddApplicationRuleCollection
        $azureFirewall.AddApplicationRuleCollection($appRc)
        $azureFirewall.AddApplicationRuleCollection($appRc2)

        # Add NatRuleCollections to the Firewall using method AddNatRuleCollection
        $azureFirewall.AddNatRuleCollection($natRc)

        # Add NetworkRuleCollections to the Firewall using method AddNetworkRuleCollection
        $azureFirewall.AddNetworkRuleCollection($netRc)

		# Update ThreatIntel mode
		$azureFirewall.ThreatIntelMode = "Deny"

        # Set AzureFirewall
        Set-AzFirewall -AzureFirewall $azureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName
        $azureFirewallIpConfiguration = $getAzureFirewall.IpConfigurations

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
		Assert-AreEqual "Deny" $getAzureFirewall.ThreatIntelMode

        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
        Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
        Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress

        # Check rule collections
        Assert-AreEqual 2 @($getAzureFirewall.ApplicationRuleCollections).Count
        Assert-AreEqual 2 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[1].Rules).Count

        Assert-AreEqual 1 @($getAzureFirewall.NatRuleCollections).Count
        Assert-AreEqual 1 @($getAzureFirewall.NatRuleCollections[0].Rules).Count

        Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
        Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

        $appRc = $getAzureFirewall.GetApplicationRuleCollectionByName($appRcName)
        $appRule = $appRc.GetRuleByName($appRule1Name)
        $appRule2 = $appRc.GetRuleByName($appRule2Name)

        # Verify application rule collection 1 
        Assert-AreEqual $appRcName $appRc.Name
        Assert-AreEqual $appRcPriority $appRc.Priority
        Assert-AreEqual $appRcActionType $appRc.Action.Type

        # Verify application rule 1
        Assert-AreEqual $appRule1Name $appRule.Name
        Assert-AreEqual $appRule1Desc $appRule.Description

        Assert-AreEqual 1 $appRule.SourceAddresses.Count
        Assert-AreEqual $appRule1SourceAddress1 $appRule.SourceAddresses[0]

        Assert-AreEqual 2 $appRule.Protocols.Count 
        Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
        Assert-AreEqual $appRule1ProtocolType2 $appRule.Protocols[1].ProtocolType
        Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port
        Assert-AreEqual $appRule1Port2 $appRule.Protocols[1].Port

        Assert-AreEqual 2 $appRule.TargetFqdns.Count 
        Assert-AreEqual $appRule1Fqdn1 $appRule.TargetFqdns[0]
        Assert-AreEqual $appRule1Fqdn2 $appRule.TargetFqdns[1]

        # Verify application rule 2
        Assert-AreEqual $appRule2Name $appRule2.Name
        Assert-Null $appRule2.Description

        Assert-AreEqual 0 $appRule2.SourceAddresses.Count

        Assert-AreEqual 1 $appRule2.Protocols.Count 
        Assert-AreEqual $appRule2ProtocolType1 $appRule2.Protocols[0].ProtocolType
        Assert-AreEqual $appRule2Port1 $appRule2.Protocols[0].Port

        Assert-AreEqual 1 $appRule2.TargetFqdns.Count 
        Assert-AreEqual $appRule2Fqdn1 $appRule2.TargetFqdns[0]

        # Verify application rule collection 2
        $appRc2 = $getAzureFirewall.GetApplicationRuleCollectionByName($appRc2Name)

        Assert-AreEqual $appRc2Name $appRc2.Name
        Assert-AreEqual $appRc2Priority $appRc2.Priority
        Assert-AreEqual $appRc2ActionType $appRc2.Action.Type

        # Verify application rule
        $appRule = $appRc2.GetRuleByName($appRule1Name)

        Assert-AreEqual $appRule1Name $appRule.Name
        Assert-AreEqual $appRule1Desc $appRule.Description

        Assert-AreEqual 1 $appRule.SourceAddresses.Count
        Assert-AreEqual $appRule1SourceAddress1 $appRule.SourceAddresses[0]

        Assert-AreEqual 2 $appRule.Protocols.Count 
        Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
        Assert-AreEqual $appRule1ProtocolType2 $appRule.Protocols[1].ProtocolType
        Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port
        Assert-AreEqual $appRule1Port2 $appRule.Protocols[1].Port
        
        Assert-AreEqual 2 $appRule.TargetFqdns.Count 
        Assert-AreEqual $appRule1Fqdn1 $appRule.TargetFqdns[0]
        Assert-AreEqual $appRule1Fqdn2 $appRule.TargetFqdns[1]

        # Verify NAT rule collection and NAT rule
        $natRc = $getAzureFirewall.GetNatRuleCollectionByName($natRcName)
        $natRule = $natRc.GetRuleByName($natRule1Name)

        Assert-AreEqual $natRcName $natRc.Name
        Assert-AreEqual $natRcPriority $natRc.Priority

        Assert-AreEqual $natRule1Name $natRule.Name
        Assert-AreEqual $natRule1Desc $natRule.Description

        Assert-AreEqual 2 $natRule.SourceAddresses.Count 
        Assert-AreEqual $natRule1SourceAddress1 $natRule.SourceAddresses[0]
        Assert-AreEqual $natRule1SourceAddress2 $natRule.SourceAddresses[1]

        Assert-AreEqual 1 $natRule.DestinationAddresses.Count 
        Assert-AreEqual $publicip.IpAddress $natRule.DestinationAddresses[0]

        Assert-AreEqual 2 $natRule.Protocols.Count 
        Assert-AreEqual $natRule1Protocol1 $natRule.Protocols[0]
        Assert-AreEqual $natRule1Protocol2 $natRule.Protocols[1]

        Assert-AreEqual 1 $natRule.DestinationPorts.Count 
        Assert-AreEqual $natRule1DestinationPort1 $natRule.DestinationPorts[0]

        Assert-AreEqual $natRule1TranslatedAddress $natRule.TranslatedAddress
        Assert-AreEqual $natRule1TranslatedPort $natRule.TranslatedPort

        # Verify network rule collection and network rule
        $networkRc = $getAzureFirewall.GetNetworkRuleCollectionByName($networkRcName)
        $networkRule = $networkRc.GetRuleByName($networkRule1Name)

        Assert-AreEqual $networkRcName $networkRc.Name
        Assert-AreEqual $networkRcPriority $networkRc.Priority
        Assert-AreEqual $networkRcActionType $networkRc.Action.Type

        Assert-AreEqual $networkRule1Name $networkRule.Name
        Assert-AreEqual $networkRule1Desc $networkRule.Description

        Assert-AreEqual 2 $networkRule.SourceAddresses.Count 
        Assert-AreEqual $networkRule1SourceAddress1 $networkRule.SourceAddresses[0]
        Assert-AreEqual $networkRule1SourceAddress2 $networkRule.SourceAddresses[1]

        Assert-AreEqual 1 $networkRule.DestinationAddresses.Count 
        Assert-AreEqual $networkRule1DestinationAddress1 $networkRule.DestinationAddresses[0]

        Assert-AreEqual 3 $networkRule.Protocols.Count
        Assert-AreEqual $networkRule1Protocol1 $networkRule.Protocols[0]
        Assert-AreEqual $networkRule1Protocol2 $networkRule.Protocols[1]
        Assert-AreEqual $networkRule1Protocol3 $networkRule.Protocols[2]

        Assert-AreEqual 1 $networkRule.DestinationPorts.Count 
        Assert-AreEqual $networkRule1DestinationPort1 $networkRule.DestinationPorts[0]

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
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
function Test-AzureFirewallAllocateAndDeallocate
{
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall (with no vnet, public ip)
        $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        
        Assert-AreEqual 0 @($getAzureFirewall.IpConfigurations).Count
        
        # Verify rule collections 
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NatRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollections).Count

        # Allocate the firewall
        $getAzureFirewall.Allocate($vnet, $publicip)

        # Set Azure Firewall
        Set-AzFirewall -AzureFirewall $getAzureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

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
        
        # Verify rule collections 
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollections).Count
        
        # Deallocate the firewall
        $getAzureFirewall.Deallocate()
        $getAzureFirewall | Set-AzFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag

        # verify ip configuration
        Assert-AreEqual 0 @($getAzureFirewall.IpConfigurations).Count

        # Verify rule collections
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NatRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewall.NetworkRuleCollections).Count

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
