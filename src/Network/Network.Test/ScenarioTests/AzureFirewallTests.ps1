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
function Test-AzureFirewallCRUD {
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

    # AzureFirewallApplicationRule 3
    $appRule3Name = "appRule3"
    $appRule3Fqdn1 = "sql1.database.windows.net"
    $appRule3Protocol1 = "mssql:1433"
    $appRule3Port1 = 1433
    $appRule3ProtocolType1 = "mssql"

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

    # AzureFirewallNatRule 2
    $natRule2Name = "natRule2"
    $natRule2Desc = "desc2"
    $natRule2SourceAddress1 = "10.0.0.0"
    $natRule2SourceAddress2 = "111.1.0.0/24"
    $natRule2Protocol1 = "UDP"
    $natRule2Protocol2 = "TCP"
    $natRule2DestinationPort1 = "95"
    $natRule2TranslatedFqdn = "server1.internal.com"
    $natRule2TranslatedPort = "96"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName

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
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
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

        $appRule3 = New-AzFirewallApplicationRule -Name $appRule3Name -Protocol $appRule3Protocol1 -TargetFqdn $appRule3Fqdn1

        # Create Application Rule Collection with 1 rule
        $appRc = New-AzFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        # Add a rule to the rule collection using AddRule method
        $appRc.AddRule($appRule2)
        $appRc.AddRule($appRule3)

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
            New-AzFirewallNatRule -Name $natRule1Name -Protocol $natRule1Protocol1, "ICMP" -SourceAddress $natRule1SourceAddress1 -DestinationAddress $natRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort
        } "The argument `"ICMP`" does not belong to the set"
        Assert-ThrowsContains { $natRule.AddProtocol("ICMP") } "Invalid protocol"

        # Create second NAT rule
        $natRule2 = New-AzFirewallNatRule -Name $natRule2Name -Description $natRule2Desc -Protocol $natRule2Protocol1 -SourceAddress $natRule2SourceAddress1, $natRule2SourceAddress2 -DestinationAddress $publicip.IpAddress -DestinationPort $natRule2DestinationPort1 -TranslatedFqdn $natRule2TranslatedFqdn -TranslatedPort $natRule2TranslatedPort
        $natRule2.AddProtocol($natRule2Protocol2)

        # Create a NAT Rule Collection
        $natRc = New-AzFirewallNatRuleCollection -Name $natRcName -Priority $natRcPriority -Rule $natRule

        # Add second NAT Rule to rule Collection
        $natRc.AddRule($natRule2)

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
        Assert-AreEqual 3 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections[1].Rules).Count

        Assert-AreEqual 1 @($getAzureFirewall.NatRuleCollections).Count
        Assert-AreEqual 2 @($getAzureFirewall.NatRuleCollections[0].Rules).Count

        Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
        Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

        $appRc = $getAzureFirewall.GetApplicationRuleCollectionByName($appRcName)
        $appRule = $appRc.GetRuleByName($appRule1Name)
        $appRule2 = $appRc.GetRuleByName($appRule2Name)
        $appRule3 = $appRc.GetRuleByName($appRule3Name)

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

        # Verify application rule 3
        Assert-AreEqual $appRule3Name $appRule3.Name
        Assert-Null $appRule3.Description

        Assert-AreEqual 0 $appRule3.SourceAddresses.Count

        Assert-AreEqual 1 $appRule3.Protocols.Count
        Assert-AreEqual $appRule3ProtocolType1 $appRule3.Protocols[0].ProtocolType
        Assert-AreEqual $appRule3Port1 $appRule3.Protocols[0].Port

        Assert-AreEqual 1 $appRule3.TargetFqdns.Count
        Assert-AreEqual $appRule3Fqdn1 $appRule3.TargetFqdns[0]

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

        # Verify NAT rule collection and NAT rules
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

        $natRule2 = $natRc.GetRuleByName($natRule2Name)

        Assert-AreEqual $natRule2Name $natRule2.Name
        Assert-AreEqual $natRule2Desc $natRule2.Description

        Assert-AreEqual 2 $natRule2.SourceAddresses.Count 
        Assert-AreEqual $natRule2SourceAddress1 $natRule2.SourceAddresses[0]
        Assert-AreEqual $natRule2SourceAddress2 $natRule2.SourceAddresses[1]

        Assert-AreEqual 1 $natRule2.DestinationAddresses.Count 
        Assert-AreEqual $publicip.IpAddress $natRule2.DestinationAddresses[0]

        Assert-AreEqual 2 $natRule2.Protocols.Count 
        Assert-AreEqual $natRule2Protocol1 $natRule2.Protocols[0]
        Assert-AreEqual $natRule2Protocol2 $natRule2.Protocols[1]

        Assert-AreEqual 1 $natRule2.DestinationPorts.Count 
        Assert-AreEqual $natRule2DestinationPort1 $natRule2.DestinationPorts[0]

        Assert-AreEqual $natRule2TranslatedFqdn $natRule2.TranslatedFqdn
        Assert-AreEqual $natRule2TranslatedPort $natRule2.TranslatedPort

        # Verify network rule collection and network rules
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
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewallCRUD With Availability Zones.
#>
function Test-AzureFirewallCRUDWithZones {
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

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard -Zone 1, 2, 3

        # Create AzureFirewall (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -PublicIpAddress $publicip -Zone 1, 2, 3

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
        $listAll = Get-AzFirewall
        Assert-NotNull $listAll

        $listAll = Get-AzFirewall -Name "*"
        Assert-NotNull $listAll

        $listAll = Get-AzFirewall -ResourceGroupName "*"
        Assert-NotNull $listAll

        $listAll = Get-AzFirewall -ResourceGroupName "*" -Name "*"
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
            New-AzFirewallNatRule -Name $natRule1Name -Protocol $natRule1Protocol1, "ICMP" -SourceAddress $natRule1SourceAddress1 -DestinationAddress $natRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort
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

        # Get for zones
        Assert-AreEqual 3 @($getAzureFirewall.Zones).Count

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall with new style params for VNET and Public IPs - objects instead of strings
#>
function Test-AzureFirewallPIPAndVNETObjectTypeParams {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIp1Name = Get-ResourceName
    $publicIp2Name = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ips
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Static -Sku Standard
        $publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp2Name -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall with a single public IP address
        $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -PublicIpAddress $publicip1

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id

        # Test handling of incorrect values when adding public IP address
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress() } "Cannot find an overload"
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress($null) } "Public IP Address cannot be null"
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress("ABCD") } "Cannot convert argument"
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress($publicip1) } "already attached to firewall"

        # Test handling of incorrect values when removing public IP Address
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress() } "Cannot find an overload"
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress($null) } "Public IP Address cannot be null"
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress("ABCD") } "Cannot convert argument"
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress($publicip2) } "not attached to firewall"

        # Add second public IP Address
        $getAzureFirewall.AddPublicIpAddress($publicip2)

        # Set AzureFirewall
        Set-AzFirewall -AzureFirewall $getAzureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName
        $azureFirewallIpConfiguration = $getAzureFirewall.IpConfigurations

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag

        Assert-AreEqual 2 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
        Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
        Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $publicip2.Id $getAzureFirewall.IpConfigurations[1].PublicIpAddress.Id

        # Remove second public IP address
        $getAzureFirewall.RemovePublicIpAddress($publicip2)

        # Set AzureFirewall
        Set-AzFirewall -AzureFirewall $getAzureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName
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
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Create AzureFirewall with Two Public IP addresses
        $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -PublicIpAddress @($publicip1, $publicip2)

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname
        $azureFirewallIpConfiguration = $getAzureFirewall.IpConfigurations

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag

        Assert-AreEqual 2 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $azureFirewallIpConfiguration[0].Subnet.Id
        Assert-NotNull $azureFirewallIpConfiguration[0].PublicIpAddress.Id
        Assert-NotNull $azureFirewallIpConfiguration[1].PublicIpAddress.Id
        Assert-NotNull $azureFirewallIpConfiguration[0].PrivateIpAddress
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $publicip2.Id $getAzureFirewall.IpConfigurations[1].PublicIpAddress.Id

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AzureFirewallCRUDwithManagementIpConfig {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$mgmtSubnetName = "AzureFirewallManagementSubnet"
    $publicIp1Name = Get-ResourceName
    $mgmtPublicIpName = Get-ResourceName
	$mgmtPublicIp2Name = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $mgmtSubnet = New-AzVirtualNetworkSubnetConfig -Name $mgmtSubnetName -AddressPrefix 10.0.100.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet,$mgmtSubnet
        
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName
        $mgmtSubnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $mgmtSubnetName

        # Create public ips
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Static -Sku Standard
        $mgmtPublicIp = New-AzPublicIpAddress -ResourceGroupName $rgname -name $mgmtPublicIpName -location $location -AllocationMethod Static -Sku Standard
        $mgmtPublicIp2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $mgmtPublicIp2Name -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall with a management IP
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -PublicIpAddress $publicip1 -ManagementPublicIpAddress $mgmtPublicIp

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id
        Assert-AreEqual $mgmtSubnet.Id $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-AreEqual $mgmtPublicIp.Id $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id


        # Test handling of incorrect values when adding public IP address
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress() } "Cannot find an overload"
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress($null) } "Public IP Address cannot be null"
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress("ABCD") } "Cannot convert argument"
        Assert-ThrowsContains { $getAzureFirewall.AddPublicIpAddress($publicip1) } "already attached to firewall"

        # Test handling of incorrect values when removing public IP Address
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress() } "Cannot find an overload"
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress($null) } "Public IP Address cannot be null"
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress("ABCD") } "Cannot convert argument"
        Assert-ThrowsContains { $getAzureFirewall.RemovePublicIpAddress($mgmtPublicIp) } "not attached to firewall"

        # Change Management PIP
        $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress = $mgmtPublicIp2

        # Set AzureFirewall
        Set-AzFirewall -AzureFirewall $getAzureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $location $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag

        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id
        Assert-AreEqual $mgmtSubnet.Id $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-AreEqual $mgmtPublicIp2.Id $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall Set and Remove IpConfiguration
#>
function Test-AzureFirewallAllocateAndDeallocate {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

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
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall Set and Remove IpConfiguration
#>
function Test-AzureFirewallVirtualHubCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $policyLocation = "westcentralus"
    $location = Get-ProviderLocation $resourceTypeParent
    $azureFirewallPolicyName = Get-ResourceName
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $policyLocation

        # Get the AzureFirewallPolicy
        $getazureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        
        Assert-NotNull $azureFirewallPolicy
        Assert-NotNull $getazureFirewallPolicy.Id

        $azureFirewallPolicyId = $getazureFirewallPolicy.Id

        New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -FirewallPolicyId $azureFirewallPolicyId

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-NotNull $getAzureFirewall.FirewallPolicy
        Assert-AreEqual $azureFirewallPolicyId $getAzureFirewall.FirewallPolicy.Id
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Hub Firewall with Zones CRUD
#>
function Test-AzureFirewallVirtualHubCRUDWithZones {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $policyLocation = Get-ProviderLocation $resourceTypeParent "eastus"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"
    $azureFirewallPolicyName = Get-ResourceName
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"
    $firewallPIPCount = "2"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $policyLocation

        # Get the AzureFirewallPolicy
        $getazureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        Assert-NotNull $azureFirewallPolicy
        Assert-NotNull $getazureFirewallPolicy.Id

        $azureFirewallPolicyId = $getazureFirewallPolicy.Id

        $fwpips = New-AzFirewallHubPublicIpAddress -Count $firewallPIPCount
        $hubIpAddresses = New-AzFirewallHubIpAddress -PublicIP $fwpips

        New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier  -HubIPAddress $hubIpAddresses -FirewallPolicyId $azureFirewallPolicyId -Zone 1, 2, 3
        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-NotNull $getAzureFirewall.FirewallPolicy
        Assert-AreEqual $azureFirewallPolicyId $getAzureFirewall.FirewallPolicy.Id
        Assert-AreEqual 3 @($getAzureFirewall.Zones).Count
        Assert-NotNull $getAzureFirewall.HubIPAddresses
        Assert-NotNull $getAzureFirewall.HubIPAddresses.PublicIPs
        Assert-AreEqual $firewallPIPCount $getAzureFirewall.HubIPAddresses.PublicIPs.Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall ThreatIntelWhitelist
#>
function Test-AzureFirewallThreatIntelWhitelistCRUD {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    $threatIntelWhitelist1 = New-AzFirewallThreatIntelWhitelist -FQDN @("*.microsoft.com", "microsoft.com") -IpAddress @("8.8.8.8", "1.1.1.1")
    $threatIntelWhitelist2 = New-AzFirewallThreatIntelWhitelist -IpAddress @("  2.2.2.2  ", "  3.3.3.3  ") -FQDN @("  bing.com  ", "yammer.com  ")

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -ThreatIntelWhitelist $threatIntelWhitelist1

        # Verify
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqualArray $threatIntelWhitelist1.FQDNs $getAzureFirewall.ThreatIntelWhitelist.FQDNs
        Assert-AreEqualArray $threatIntelWhitelist1.IpAddresses $getAzureFirewall.ThreatIntelWhitelist.IpAddresses

        # Modify
        $azureFirewall.ThreatIntelWhitelist = $threatIntelWhitelist2
        Set-AzFirewall -AzureFirewall $azureFirewall
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqualArray $threatIntelWhitelist2.FQDNs $getAzureFirewall.ThreatIntelWhitelist.FQDNs
        Assert-AreEqualArray $threatIntelWhitelist2.IpAddresses $getAzureFirewall.ThreatIntelWhitelist.IpAddresses
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall PrivateRange
#>
function Test-AzureFirewallPrivateRangeCRUD {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    $privateRange1 = @("IANAPrivateRanges", "0.0.0.0/0", "66.92.0.0/16")
    $privateRange2 = @("3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20","10.226.0.0/16")
    $privateRange3 = @("255.255.255.255/32", "0.0.0.0/32", "1.0.0.0/32", "0.0.0.1/32")

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -PrivateRange $privateRange1

        # Verify
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqualArray $privateRange1 $getAzureFirewall.PrivateRange

        # Modify
        $azureFirewall.PrivateRange = $privateRange2
        Set-AzFirewall -AzureFirewall $azureFirewall
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqualArray $privateRange2 $getAzureFirewall.PrivateRange

        # Test Always SNAT and /32
        $azureFirewall.PrivateRange = $privateRange3
        Set-AzFirewall -AzureFirewall $azureFirewall
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqualArray $privateRange3 $getAzureFirewall.PrivateRange
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall DNS Proxy
#>
function Test-AzureFirewallWithDNSProxy {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName
    $dnsServers = @("10.10.10.1", "20.20.20.2")

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

    # AzureFirewallNetworkRule 2
    $networkRule2Name = "networkRule2"
    $networkRule2Desc = "desc2"
    $networkRule2SourceAddress1 = "10.0.0.0"
    $networkRule2SourceAddress2 = "111.1.0.0/24"
    $networkRule2DestinationFqdn1 = "www.bing.com"
    $networkRule2Protocol1 = "UDP"
    $networkRule2Protocol2 = "TCP"
    $networkRule2Protocol3 = "ICMP"
    $networkRule2DestinationPort1 = "80"

    $skuName = "AZFW_VNet"
    $skuTier = "Standard"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

         # Create Network Rule
        $networkRule = New-AzFirewallNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1
        $networkRule.AddProtocol($networkRule1Protocol3)

        # Test handling of incorrect values
        Assert-ThrowsContains { $networkRule.AddProtocol() } "Cannot find an overload"
        Assert-ThrowsContains { $networkRule.AddProtocol($null) } "A protocol must be provided"
        Assert-ThrowsContains { $networkRule.AddProtocol("ABCD") } "Invalid protocol"

        # Create Network Rule Collection
        $netRc = New-AzFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType

        # Create Second Network Rule
        $networkRule2 = New-AzFirewallNetworkRule -Name $networkRule2Name -Description $networkRule2Desc -Protocol $networkRule2Protocol1, $networkRule2Protocol2 -SourceAddress $networkRule2SourceAddress1, $networkRule2SourceAddress2 -DestinationFqdn $networkRule2DestinationFqdn1 -DestinationPort $networkRule2DestinationPort1
        $networkRule2.AddProtocol($networkRule2Protocol3)

        # Add this second Network Rule to the rule collection
        $netRc.AddRule($networkRule2)

        # Create AzureFirewall with DNSProxy enabled and DNS Servers provided
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName -NetworkRuleCollection $netRc -EnableDnsProxy -DnsServer $dnsServers -SkuName $skuName -SkuTier $skuTier

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier

        # Check rule collections
        Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
        Assert-AreEqual 2 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count

        # Check DNS Proxy
        Assert-AreEqual true $getAzureFirewall.DNSEnableProxy
        Assert-AreEqualArray $dnsServers $getAzureFirewall.DnsServer

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall with Multip IPs on Virtual Hub
#>
function Test-AzureFirewallVirtualHubMultiPublicIPCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = "eastus2euap"
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $virtualHubAddressPrefix = "10.0.0.0/16"
    $firewallPIPCount = "2"
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        $fwpips = New-AzFirewallHubPublicIpAddress -Count $firewallPIPCount
        $hubIpAddresses = New-AzFirewallHubIpAddress -PublicIP $fwpips
        $fw= New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -HubIPAddress $hubIpAddresses

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-NotNull $getAzureFirewall.HubIPAddresses
        Assert-NotNull $getAzureFirewall.HubIPAddresses.PublicIPs
        Assert-AreEqual $firewallPIPCount $getAzureFirewall.HubIPAddresses.PublicIPs.Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall AllowActiveFTP
#>
function Test-AzureFirewallCRUDAllowActiveFTP {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -AllowActiveFTP

        # Verify
        $azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqual true $azFirewall.AllowActiveFTP

        # Reset the AllowActiveFTP flag
        $azFirewall.AllowActiveFTP = $false
        Set-AzFirewall -AzureFirewall $azFirewall
        $azfw = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        
        Assert-AreEqual false $azfw.AllowActiveFTP
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall NoDataPip
#>
function Test-AzureFirewallNoDataPip {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "centraluseuap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$mgmtSubnetName = "AzureFirewallManagementSubnet"
    $mgmtPublicIpName = Get-ResourceName
    $publicIp1Name = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $mgmtSubnet = New-AzVirtualNetworkSubnetConfig -Name $mgmtSubnetName -AddressPrefix 10.0.100.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet,$mgmtSubnet
        
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName
        $mgmtSubnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $mgmtSubnetName

        # Create mgmt public ip
        $mgmtPublicIp = New-AzPublicIpAddress -ResourceGroupName $rgname -name $mgmtPublicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall with a management IP, without data PIP
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -ManagementPublicIpAddress $mgmtPublicIp

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        # Verify creating firewall without data PIP
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-Null $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id
        Assert-AreEqual $mgmtSubnet.Id $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-AreEqual $mgmtPublicIp.Id $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id

        # Verify adding a data PIP to firewall
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Static -Sku Standard
        $getAzureFirewall.AddPublicIpAddress($publicip1)
        Set-AzFirewall -AzureFirewall $getAzureFirewall
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations.PublicIpAddress.Id

        # Verify removing data PIP from exisiting FT firewall
        $getAzureFirewall.RemovePublicIpAddress($publicip1)
        Set-AzFirewall -AzureFirewall $getAzureFirewall
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-Null $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall with Multip IPs on Virtual Hub
#>
function Test-AzureFirewallVirtualHubAllocateDeallocated {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $location = "eastus2euap"
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"
    $firewallPIPCount = "2"
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName

    try {
        # Create the resource group and rest
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        $fwpips = New-AzFirewallHubPublicIpAddress -Count $firewallPIPCount
        $hubIpAddresses = New-AzFirewallHubIpAddress -PublicIP $fwpips

        # Create firewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -HubIPAddress $hubIpAddresses
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        # create virtual Hub
        $Vwan = New-AzVirtualWan -Name $virtualWanName -ResourceGroupName $rgname -Location $location -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic -VirtualWANType "Standard"
        $Hub = New-AzVirtualHub -Name $virtualHubName -ResourceGroupName $rgname -VirtualWan $Vwan -Location $Location -AddressPrefix "192.168.1.0/24" -Sku "Standard"

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-Null $getAzureFirewall.VirtualHub

        # Allocate Virtual Hub to Firewall
        $azureFirewall.Allocate($Hub.Id)
        Set-AzFirewall -AzureFirewall $azureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname
        Assert-NotNull $getAzureFirewall.VirtualHub
        Assert-AreEqual $Hub.Id $getAzureFirewall.VirtualHub.Id

        # Test Deallocate
        $azureFirewall.Deallocate()
        Set-AzFirewall -AzureFirewall $azureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname
        Assert-Null $getAzureFirewall.VirtualHub
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall Basic Sku
#>
function Test-AzureFirewallBasicSku {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName
   
    $skuName = "AZFW_VNet"
    $skuTier = "Basic"
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier 

        # Verify
       $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
       Assert-NotNull $getAzureFirewall.Sku
       Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier

    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall Management NIC Basic Sku
#>
function Test-AzureFirewallManagementNICBasicSku {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$mgmtSubnetName = "AzureFirewallManagementSubnet"
    $publicIp1Name = Get-ResourceName
    $mgmtPublicIpName = Get-ResourceName
    $skuTier = "Basic"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $mgmtSubnet = New-AzVirtualNetworkSubnetConfig -Name $mgmtSubnetName -AddressPrefix 10.0.100.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet,$mgmtSubnet
        
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName
        $mgmtSubnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $mgmtSubnetName

        # Create public ips
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Static -Sku Standard
        $mgmtPublicIp = New-AzPublicIpAddress -ResourceGroupName $rgname -name $mgmtPublicIpName -location $location -AllocationMethod Static -Sku Standard

         # Try to create basic sku Firewall without ManagementPublicIpAddress and Verify
         Assert-ThrowsContains { New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -PublicIpAddress $publicip1 -SkuTier $skuTier } "ManagementPublicIpAddress is required for Azure Firewalls with Basic SKU"

        # Create AzureFirewall with a Management PIP
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -ManagementPublicIpAddress $mgmtPublicIp -SkuTier $skuTier

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Etag

        Assert-Null $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-NotNull $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id
        Assert-AreEqual $mgmtSubnet.Id $getAzureFirewall.ManagementIpConfiguration.Subnet.Id
        Assert-AreEqual $mgmtPublicIp.Id $getAzureFirewall.ManagementIpConfiguration.PublicIpAddress.Id

        # Add PIP        
        $getAzureFirewall.AddPublicIpAddress($publicip1)

        # Set AzureFirewall
        Set-AzFirewall -AzureFirewall $getAzureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName

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
        Assert-AreEqual $subnet.Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip1.Id $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id

        # Delete AzureFirewall
        $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewall -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall EnableFatFlowLogging
#>
function Test-AzureFirewallCRUDEnableFatFlowLogging {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -EnableFatFlowLogging

        # Verify
        $azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqual true $azFirewall.EnableFatFlowLogging

        # Reset the EnableFatFlowLogging flag
        $azFirewall.EnableFatFlowLogging = $false
        Set-AzFirewall -AzureFirewall $azFirewall
        $azfw = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        
        Assert-AreEqual false $azfw.EnableFatFlowLogging
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall with Multip IPs on Virtual Hub
#>
function Test-AzureFirewallVirtualHubPrivateIPAddress {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $location = "eastus2euap"
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"
    $firewallPIPCount = "2"
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName

    try {
        # Create the resource group and rest
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        $fwpips = New-AzFirewallHubPublicIpAddress -Count $firewallPIPCount
        $hubIpAddresses = New-AzFirewallHubIpAddress -PublicIP $fwpips

        # create virtual Hub
        $Vwan = New-AzVirtualWan -Name $virtualWanName -ResourceGroupName $rgname -Location $location -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic -VirtualWANType "Standard"
        $Hub = New-AzVirtualHub -Name $virtualHubName -ResourceGroupName $rgname -VirtualWan $Vwan -Location $Location -AddressPrefix "192.168.1.0/24" -Sku "Standard"

        # Create firewall
        $vHubId = $Hub.Id
        $getAzureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -HubIPAddress $hubIpAddresses -VirtualHubId $vHubId

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-NotNull $getAzureFirewall.VirtualHub
        Assert-NotNull $getAzureFirewall.HubIPAddresses.PrivateIPAddress

        # Test Deallocate
        $getAzureFirewall.Deallocate()
        Set-AzFirewall -AzureFirewall $getAzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname
        Assert-Null $getAzureFirewall.VirtualHub
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall EnableUDPLogOptimization
#>
function Test-AzureFirewallCRUDEnableUDPLogOptimization {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -EnableUDPLogOptimization

        # Verify
        $azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqual true $azFirewall.EnableUDPLogOptimization

        # Reset the EnableUDPLogOptimization flag
        $azFirewall.EnableUDPLogOptimization = $false
        Set-AzFirewall -AzureFirewall $azFirewall
        $azfw = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        
        Assert-AreEqual false $azfw.EnableUDPLogOptimization
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall RouteServerId
#>
function Test-AzureFirewallCRUDRouteServerId {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName
    $routeServerId="/subscriptions/aeb5b02a-0f18-45a4-86d6-81808115cacf/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/TestRS"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -RouteServerId $routeServerId

        # Verify
        $azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqual $routeServerId $azFirewall.RouteServerId

        # Reset the RouteServerId 
        $azFirewall.RouteServerId = ""
        Set-AzFirewall -AzureFirewall $azFirewall
        $azfw = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        
        Assert-AreEqual "" $azfw.RouteServerId
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall RouteServerId on Hub Firewall
#>
function Test-AzureFirewallCRUDRouteServerIdHub {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"
    $routeServerId="/subscriptions/aeb5b02a-0f18-45a4-86d6-81808115cacf/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/TestRS"

    try {

         Assert-ThrowsContains { New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -RouteServerId $routeServerId } "The Route Server is not supported on AZFW_Hub SKU Firewalls"

    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests  Get Azure Firewall LearnedPrefixes
#>
function Test-GetAzureFirewallLearnedIpPrefixes {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "Eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location

        # Get Firewall Learned Prefixes
        $learnedPrefixes = Get-AzFirewallLearnedIpPrefix -Name $azureFirewallName -ResourceGroupName $rgname

        # Verify
         Assert-NotNull $learnedPrefixes
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Invoke-AzureFirewallPacketCapture
#>
function Test-InvokeAzureFirewallPacketCapture {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
	$mgmtSubnetName = "AzureFirewallManagementSubnet"
    $publicIp1Name = Get-ResourceName
    $mgmtPublicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $mgmtSubnet = New-AzVirtualNetworkSubnetConfig -Name $mgmtSubnetName -AddressPrefix 10.0.100.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet,$mgmtSubnet
        
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName
        $mgmtSubnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $mgmtSubnetName

        # Create public ips
        $publicip1 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIp1Name -location $location -AllocationMethod Static -Sku Standard
        $mgmtPublicIp = New-AzPublicIpAddress -ResourceGroupName $rgname -name $mgmtPublicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall with a management IP
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetwork $vnet -PublicIpAddress $publicip1 -ManagementPublicIpAddress $mgmtPublicIp

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        $sasurl = "https://powershellpacketcapture.blob.core.windows.net/testcapture?sp=wDummyURL"

        # Create a filter rules
        $filter1 = New-AzFirewallPacketCaptureRule -Source "10.0.0.2","192.123.12.1" -Destination "172.32.1.2" -DestinationPort "80","443"
        $filter2 = New-AzFirewallPacketCaptureRule -Source "10.0.0.5" -Destination "172.20.10.2" -DestinationPort "80","443"
    
        # Create the firewall packet capture parameters
        $Params =  New-AzFirewallPacketCaptureParameter  -DurationInSeconds 30 -NumberOfPackets 500 -SASUrl $sasurl -Filename "AzFwPowershellPacketCapture" -Flag "Syn","Ack" -Protocol "Any" -Filter $Filter1, $Filter2

        # Invoke a firewall packet capture
        $response = Invoke-AzFirewallPacketCapture -AzureFirewall $azureFirewall -Parameter $Params
        Assert-NotNull $response
        Assert-AreEqual "Microsoft.Azure.Management.Network.Models.AzureFirewallsPacketCaptureHeaders" $response.GetType().fullname
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Byopip feature for Hub Firewall
#>
function Test-InvokeAzureByopipHubFirewall {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "westcentralus"
    $azureFirewallPolicyName = Get-ResourceName
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"
    $publicIpName = Get-ResourceName
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        #Creating Public Ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create virtual Hub
        $Vwan = New-AzVirtualWan -Name $virtualWanName -ResourceGroupName $rgname -Location $location -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic -VirtualWANType "Standard"
        $Hub = New-AzVirtualHub -Name $virtualHubName -ResourceGroupName $rgname -VirtualWan $Vwan -Location $Location -AddressPrefix "192.168.1.0/24" -Sku "Standard"

        # Create firewall
        $vHubId = $Hub.Id

        New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -PublicIpAddress $publicip -VirtualHubId $vHubId
        
        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Tests Byopip Allocate feature for Hub Firewall
#>
function Test-InvokeAzureAllocateByopipHubFirewall {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "westcentralus"
    $azureFirewallPolicyName = Get-ResourceName
    $skuName = "AZFW_Hub"
    $skuTier = "Standard"
    $publicIpName = Get-ResourceName
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        #Creating Public Ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create virtual Hub
        $Vwan = New-AzVirtualWan -Name $virtualWanName -ResourceGroupName $rgname -Location $location -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic -VirtualWANType "Standard"
        $Hub = New-AzVirtualHub -Name $virtualHubName -ResourceGroupName $rgname -VirtualWan $Vwan -Location $Location -AddressPrefix "192.168.1.0/24" -Sku "Standard"

        # Create firewall
        $vHubId = $Hub.Id

        $hubIp = New-AzFirewallHubPublicIpAddress -Count 2
		$AzFWHubIPs = New-AzFirewallHubIpAddress -PublicIP $hubIp

        New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -SkuName $skuName -SkuTier $skuTier -HubIPAddress $AzFWHubIPs -VirtualHubId $vHubId

        $AzFw = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        $hubIp = New-AzFirewallHubPublicIpAddress -Count 0
		$AzFWHubIPs = New-AzFirewallHubIpAddress -PublicIP $hubIp
		$Azfw.HubIpAddresses = $AzFWHubIPs	
		$AzFw.Deallocate()
        Set-AzFirewall -AzureFirewall $AzFw	

        # Allocate the firewall
        $AzFw = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname
        $AzFw.Allocate($Hub.Id, $publicip)
        Set-AzFirewall -AzureFirewall $AzFw	

        # Get AzureFirewall
        $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.Sku
        Assert-AreEqual $skuName $getAzureFirewall.Sku.Name
        Assert-AreEqual $skuTier $getAzureFirewall.Sku.Tier
        Assert-AreEqual 1 @($getAzureFirewall.IpConfigurations).Count
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].PrivateIpAddress
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Azure Firewall Autoscale Configuration feature
#>
function Test-AzureFirewallAutoscaleConfiguration {
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent "eastus"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallSubnet"
    $publicIpName = Get-ResourceName

    $expectedMinCapacity = 3
    $expectedMaxCapacity = 5
    $expectedUpdatedMinCapacity = 4
    $expectedUpdatedMaxCapacity = 4

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewall
        $azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location -MinCapacity $expectedMinCapacity -MaxCapacity $expectedMaxCapacity

        # Verify
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqual $getAzureFirewall.AutoscaleConfiguration.MinCapacity $expectedMinCapacity
        Assert-AreEqual $getAzureFirewall.AutoscaleConfiguration.MaxCapacity $expectedMaxCapacity

        # Update Scale
        $azureFirewall.AutoscaleConfiguration.MinCapacity = $expectedUpdatedMinCapacity
        $azureFirewall.AutoscaleConfiguration.MaxCapacity = $expectedUpdatedMaxCapacity
        Set-AzFirewall -AzureFirewall $azureFirewall

        # Verify
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-AreEqual $getAzureFirewall.AutoscaleConfiguration.MinCapacity $expectedUpdatedMinCapacity
        Assert-AreEqual $getAzureFirewall.AutoscaleConfiguration.MaxCapacity $expectedUpdatedMaxCapacity

        # Reset
        $azureFirewall.AutoscaleConfiguration.MinCapacity = $null
        $azureFirewall.AutoscaleConfiguration.MaxCapacity = $null
        Set-AzFirewall -AzureFirewall $azureFirewall

        # Verify
        $getAzureFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname
        Assert-Null $getAzureFirewall.AutoscaleConfiguration
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}