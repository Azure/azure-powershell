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
Tests AzureFirewallPolicyCRUD.
#>
function Test-AzureFirewallPolicyCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewallPolicyPolicys"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    # AzureFirewallPolicyApplicationRuleCollection
    $appRcName = "appRc"
    $appRcPriority = 100
    $appRcActionType = "Allow"

    # AzureFirewallPolicyApplicationRuleCollection 2
    $appRc2Name = "appRc2"
    $appRc2Priority = 101
    $appRc2ActionType = "Deny"

    # AzureFirewallPolicyApplicationRuleCondition 1
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

    # AzureFirewallPolicyApplicationRuleCondition 2
    $appRule2Name = "appRule2"
    $appRule2Fqdn1 = "*bing.com"
    $appRule2Protocol1 = "http:8080"
    $appRule2Port1 = 8080
    $appRule2ProtocolType1 = "http"

    # AzureFirewallPolicyNetworkRuleCollection
    $networkRcName = "networkRc"
    $networkRcPriority = 200
    $networkRcActionType = "Deny"

    # AzureFirewallPolicyNetworkRuleCondition 1
    $networkRule1Name = "networkRule"
    $networkRule1Desc = "desc1"
    $networkRule1SourceAddress1 = "10.0.0.0"
    $networkRule1SourceAddress2 = "111.1.0.0/24"
    $networkRule1DestinationAddress1 = "*"
    $networkRule1Protocol1 = "UDP"
    $networkRule1Protocol2 = "TCP"
    $networkRule1Protocol3 = "ICMP"
    $networkRule1DestinationPort1 = "90"

    # AzureFirewallPolicyNatRuleCollection
    $natRcName = "natRc"
    $natRcPriority = 200
    $natRcActionType = "Dnat"

    # AzureFirewallPolicyNatRule 1
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
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy –Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location 

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.Etag
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.ThreatIntelMode
        Assert-AreEqual 0 @($getAzureFirewallPolicy.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NatRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NetworkRuleCollections).Count

        # # list all Azure FirewallPolicys in the resource group
        # $list = Get-AzFirewallPolicy -ResourceGroupName $rgname
        # Assert-AreEqual 1 @($list).Count
        # Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewallPolicy.ResourceGroupName
        # Assert-AreEqual $list[0].Name $getAzureFirewallPolicy.Name
        # Assert-AreEqual $list[0].Location $getAzureFirewallPolicy.Location
        # Assert-AreEqual $list[0].Etag $getAzureFirewallPolicy.Etag
        # Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewallPolicy.ApplicationRuleCollections).Count
        # Assert-AreEqual @($list[0].NatRuleCollections).Count @($getAzureFirewallPolicy.NatRuleCollections).Count
        # Assert-AreEqual @($list[0].NetworkRuleCollections).Count @($getAzureFirewallPolicy.NetworkRuleCollections).Count

        # # list all Azure FirewallPolicys under subscription
        # $listAll = Get-AzFirewallPolicy
        # Assert-NotNull $listAll

        # $listAll = Get-AzFirewallPolicy -Name "*"
        # Assert-NotNull $listAll

        # $listAll = Get-AzFirewallPolicy -ResourceGroupName "*"
        # Assert-NotNull $listAll

        # $listAll = Get-AzFirewallPolicy -ResourceGroupName "*" -Name "*"
        # Assert-NotNull $listAll

        # Create Application Rule Conditions
        $appRule = New-AzFirewallPolicyApplicationRuleCondition -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1
        $appRule2 = New-AzFirewallPolicyApplicationRuleCondition -Name $appRule2Name -Protocol $appRule2Protocol1 -TargetFqdn $appRule2Fqdn1

        # Create Network Rule Condition
        $networkRule = New-AzFirewallPolicyNetworkRuleCondition -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1
        $networkRule.AddProtocol($networkRule1Protocol3)


        # Create Filter Rule with 2 rules
        $appRc = New-AzFirewallPolicyFilterRule -Name $appRcName -Priority $appRcPriority -RuleCondition $appRule, $appRule2 -ActionType $appRcActionType
        # Create a second Filter Rule Collection with 1 rule
        $appRc2 = New-AzFirewallPolicyFilterRule -Name $appRc2Name -Priority $appRc2Priority -RuleCondition $networkRule -ActionType $appRc2ActionType

        # Create a NAT rule
        $natRule = New-AzFirewallPolicyNatRule -Name $natRule1Name -Priority $natRcPriority -TranslatedAddress -RuleCondition $networkRule $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort -ActionType $natRcActionType

        $rg1 = New-AzFirewallPolicyRuleGroup -Name rg1 -Priority 100 -Rule $appRc, $appRc2, $natRule -AzureFirewallPolicy $azureFirewallPolicy


        # Update ThreatIntel mode
        $azureFirewallPolicy.ThreatIntelMode = "Deny"
        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -AzureFirewallPolicy $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -name $azureFirewallPolicyName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.Etag
        Assert-AreEqual "Deny" $getAzureFirewallPolicy.ThreatIntelMode

        # Check rule collections
        Assert-AreEqual 2 @($getAzureFirewallPolicy).Count
        Assert-AreEqual 2 @($getAzureFirewallPolicy.ApplicationRuleCollections[0].Rules).Count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.ApplicationRuleCollections[1].Rules).Count

        Assert-AreEqual 1 @($getAzureFirewallPolicy.NatRuleCollections).Count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.NatRuleCollections[0].Rules).Count

        Assert-AreEqual 1 @($getAzureFirewallPolicy.NetworkRuleCollections).Count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.NetworkRuleCollections[0].Rules).Count

        $appRc = $getAzureFirewallPolicy.GetApplicationRuleCollectionByName($appRcName)
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
        $appRc2 = $getAzureFirewallPolicy.GetApplicationRuleCollectionByName($appRc2Name)

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
        $natRc = $getAzureFirewallPolicy.GetNatRuleCollectionByName($natRcName)
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
        $networkRc = $getAzureFirewallPolicy.GetNetworkRuleCollectionByName($networkRcName)
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

        # Delete AzureFirewallPolicy
        $delete = Remove-AzFirewallPolicy -ResourceGroupName $rgname -name $azureFirewallPolicyName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewallPolicy -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewallPolicy Set and Remove IpConfiguration
#>
function Test-AzureFirewallPolicyAllocateAndDeallocate {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/AzureFirewallPolicys"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $vnetName = Get-ResourceName
    $subnetName = "AzureFirewallPolicySubnet"
    $publicIpName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

        # Create AzureFirewallPolicy (with no vnet, public ip)
        $azureFirewallPolicy = New-AzFirewallPolicy –Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.Etag
        
        Assert-AreEqual 0 @($getAzureFirewallPolicy.IpConfigurations).Count
        
        # Verify rule collections 
        Assert-AreEqual 0 @($getAzureFirewallPolicy.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NatRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NetworkRuleCollections).Count

        # Allocate the FirewallPolicy
        $getAzureFirewallPolicy.Allocate($vnet, $publicip)

        # Set Azure FirewallPolicy
        Set-AzFirewallPolicy -AzureFirewallPolicy $getAzureFirewallPolicy

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -name $azureFirewallPolicyName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.Etag

        # verify ip configuration
        Assert-AreEqual 1 @($getAzureFirewallPolicy.IpConfigurations).Count
        Assert-NotNull $getAzureFirewallPolicy.IpConfigurations[0].Subnet.Id
        Assert-NotNull $getAzureFirewallPolicy.IpConfigurations[0].PublicIpAddress.Id
        Assert-NotNull $getAzureFirewallPolicy.IpConfigurations[0].PrivateIpAddress
        
        # Verify rule collections 
        Assert-AreEqual 0 @($getAzureFirewallPolicy.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NetworkRuleCollections).Count
        
        # Deallocate the FirewallPolicy
        $getAzureFirewallPolicy.Deallocate()
        $getAzureFirewallPolicy | Set-AzFirewallPolicy

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -name $azureFirewallPolicyName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.Etag

        # verify ip configuration
        Assert-AreEqual 0 @($getAzureFirewallPolicy.IpConfigurations).Count

        # Verify rule collections
        Assert-AreEqual 0 @($getAzureFirewallPolicy.ApplicationRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NatRuleCollections).Count
        Assert-AreEqual 0 @($getAzureFirewallPolicy.NetworkRuleCollections).Count

        # Delete AzureFirewallPolicy
        $delete = Remove-AzFirewallPolicy -ResourceGroupName $rgname -name $azureFirewallPolicyName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzFirewallPolicy -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
