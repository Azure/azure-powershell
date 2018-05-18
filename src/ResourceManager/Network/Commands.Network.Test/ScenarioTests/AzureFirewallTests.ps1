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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "SecureGatewaySubnet"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
        
        # Create AzureFirewall
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $rglocation

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgname
        
        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $rglocation $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 0 @($getAzureFirewall.IpConfigurations).Count
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count

        # list all Azure Firewalls in the resource group
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getAzureFirewall.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewall.ApplicationRuleCollections).Count

        # list all Azure Firewalls in the subscription
        $list = Get-AzureRmFirewall 
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getAzureFirewall.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewall.ApplicationRuleCollections).Count

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Associate the Virtual Network to Azure Firewall
        $ipConfig = New-AzureRmFirewallIpConfiguration -Name "IpConf" -VirtualNetwork $vnet
        $azureFirewall.IpConfigurations = @($ipConfig)

        # Update the Firewall
        Set-AzureRmFirewall -AzureFirewall $azureFirewall

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $rglocation $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-NotNull $getAzureFirewall.IpConfigurations
        Assert-AreEqual 1 $getAzureFirewall.IpConfigurations.Count
        Assert-NotNull $getAzureFirewall.IpConfigurations[0].Subnet
        Assert-AreEqual $vnet.Subnets[0].Id $getAzureFirewall.IpConfigurations[0].Subnet.Id
        Assert-AreEqual 0 @($getAzureFirewall.ApplicationRuleCollections).Count

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
Tests AzureFirewallApplicationRuleCollectionCRUD
#>
function Test-AzureFirewall-ApplicationRuleCollectionCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName

    $applicationRuleCollection1Name = Get-ResourceName
    $applicationRuleCollection1Priority = 301
    $rulePriority = 1
    $ruleName = "name1"
    $ruleDesc = "sample"
    $ruleTargetUrl = "https://test.com"
    $ruleProtocolType = "Https"
    $ruleActionType = "Allow"

    $applicationRuleCollection2Name = Get-ResourceName
    $applicationRuleCollection2Priority = 302
    $rule2Priority = 2
    $rule2Name = "name2"
    $rule2Desc = "sample2"
    $rule2TargetUrl = "https://test2.com"
    $rule2ProtocolType = "Http"
    $rule2ActionType = "Deny"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create AzureFirewallApplicationRuleCollection
        $protocol = New-AzureRmFirewallApplicationProtocol -ProtocolType $ruleProtocolType
        $action = New-AzureRmFirewallApplicationRuleAction -ActionType $ruleActionType
        $rule = New-AzureRmFirewallApplicationRule –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
        $ruleCollection = New-AzureRmFirewallApplicationRuleCollection –Name $applicationRuleCollection1Name -Priority $applicationRuleCollection1Priority -Rules $rule

        # Create AzureFirewall with an Application Rule Collection
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $rglocation -ApplicationRuleCollections $ruleCollection

        # Get AzureFirewall
        $getAzureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgName

        #verification
        # Verify Azure Firewall
        Assert-AreEqual $rgName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $azureFirewallName $getAzureFirewall.Name
        Assert-NotNull $getAzureFirewall.Location
        Assert-AreEqual $rglocation $getAzureFirewall.Location
        Assert-NotNull $getAzureFirewall.ResourceGuid
        Assert-NotNull $getAzureFirewall.Etag
        Assert-AreEqual 0 @($getAzureFirewall.IpConfigurations).Count
        Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count

        # Verify Azure Firewall Application Rule Collection
        Assert-NotNull $getAzureFirewall.ApplicationRuleCollections[0].Rules
        Assert-AreEqual 1 $getAzureFirewall.ApplicationRuleCollections[0].Rules.Count
        Assert-AreEqual $applicationRuleCollection1Name $getAzureFirewall.ApplicationRuleCollections[0].Name
        Assert-AreEqual $applicationRuleCollection1Priority $getAzureFirewall.ApplicationRuleCollections[0].Priority
        Assert-NotNull $getAzureFirewall.ApplicationRuleCollections[0].Etag

        # Verify Rule
        Assert-AreEqual $ruleName $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Name
        Assert-AreEqual $ruleDesc $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Description
        Assert-AreEqual "Outbound" $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Direction
        Assert-AreEqual $rulePriority $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Priority

        # Verify Rule Target URLs
        Assert-NotNull $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].TargetUrls
        Assert-AreEqual 1 $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].TargetUrls.Count
        Assert-AreEqual $ruleTargetUrl $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].TargetUrls[0]

        # Verify Rule Protocols
        Assert-NotNull $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Protocols
        Assert-AreEqual 1 $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Protocols.Count
        Assert-AreEqual $ruleProtocolType $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Protocols[0].ProtocolType

        # Verify Rule Actions
        Assert-NotNull $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Actions
        Assert-AreEqual 1 $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Actions.Count
        Assert-AreEqual $ruleActionType $getAzureFirewall.ApplicationRuleCollections[0].Rules[0].Actions[0].ActionType

        # List AzureFirewalls
        $list = Get-AzureRmFirewall -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getAzureFirewall.ResourceGroupName
        Assert-AreEqual $list[0].Name $getAzureFirewall.Name
        Assert-AreEqual $list[0].Location $getAzureFirewall.Location
        Assert-AreEqual $list[0].Etag $getAzureFirewall.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getAzureFirewall.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getAzureFirewall.ApplicationRuleCollections).Count

        Assert-AreEqual $list[0].ApplicationRuleCollections[0].Name $getAzureFirewall.ApplicationRuleCollections[0].Name
        Assert-AreEqual $list[0].ApplicationRuleCollections[0].Etag $getAzureFirewall.ApplicationRuleCollections[0].Etag

        # Add an Azure Firewall Application Rule Collection
        $protocol = New-AzureRmFirewallApplicationProtocol -ProtocolType $rule2ProtocolType
        $action = New-AzureRmFirewallApplicationRuleActionConfig -ActionType $rule2ActionType
        $rule = New-AzureRmFirewallApplicationRule –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action
        $ruleCollection = New-AzureRmFirewallApplicationRuleCollection –Name $applicationRuleCollection2Name -Priority $applicationRuleCollection2Priority -Rules $ruleConfig
        $azureFirewall = Get-AzureRmFirewall -name $azureFirewallName -ResourceGroupName $rgName
        $azureFirewall.ApplicationRuleCollections.Add($ruleCollection)

        # Verify 
        Assert-AreEqual 2 $azureFirewall.ApplicationRuleCollections.Count
        Assert-NotNull $azureFirewall.ApplicationRuleCollections[1].Etag
        Assert-AreEqual $applicationRuleCollection1Name $azureFirewall.ApplicationRuleCollections[0].Name
        Assert-AreEqual $applicationRuleCollection2Name $azureFirewall.ApplicationRuleCollections[1].Name

        # Get ApplicationRuleCollection
        $applicationRuleCollection2 = $azureFirewall.GetApplicationRuleCollectionByName($applicationRuleCollection2Name)

        # Verify Azure Firewall Application Rule Collection
        Assert-AreEqual $applicationRuleCollection2 $azureFirewall.ApplicationRuleCollections[1]

        # Delete AzureFirewall
        $delete = Remove-AzureRmFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
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
Tests AzureFirewallApplicationRuleCRUD
#>
function Test-AzureFirewall-ApplicationRuleCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallName = Get-ResourceName

    $applicationRuleCollectionName = Get-ResourceName
    $applicationRuleCollectionPriority = 301
    $ruleName = "name1"
    $rulePriority = 1
    $ruleDesc = "sample"
    $ruleTargetUrl = "https://test.com"
    $ruleProtocolType = "Https"
    $ruleActionType = "Allow"

    $rule2Name = "name2"
    $rule2Priority = 2
    $rule2Desc = "sample2"
    $rule2TargetUrl = "https://test2.com"
    $rule2ProtocolType = "Http"
    $rule2ActionType = "Deny"

    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Application/AzureFirewalls"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create AzureFirewallApplicationRuleCollection
        $action = New-AzureRmFirewallApplicationRuleAction -ActionType $ruleActionType
        $protocol = New-AzureRmFirewallApplicationProtocol -ProtocolType $rule1ProtocolType
        $ruleConfig = New-AzureRmFirewallApplicationRule –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
        $ruleCollection = New-AzureRmFirewallApplicationRuleCollection –Name $applicationRuleCollectionName -Priority $applicationRuleCollectionPriority -Rules $ruleConfig

        # Create AzureFirewall with a AzureFirewallApplicationRuleCollection
        $azureFirewall = New-AzureRmFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $rglocation -ApplicationRuleCollections $ruleCollection

        # Get ApplicationRuleCollection
        $applicationRuleCollection = $getAzureFirewall.GetApplicationRuleCollectionByName($applicationRuleCollectionName)
        Assert-NotNull $applicationRuleCollection
        Assert-AreEqual 1 @($applicationRuleCollection.Rules).Count

        # Get ApplicationRule
        $rule = $applicationRuleCollection.GetRuleByName($ruleName)
        Assert-NotNull($rule)

        # Verify Rule has been created
        Assert-AreEqual $ruleName $rule.Name
        Assert-AreEqual $ruleDesc $rule.Description
        Assert-AreEqual $rulePriority $rule.Priority

        # Verify Azure Firewall Application Rule Collection Rule Target URLs
        Assert-NotNull $rule.TargetUrls
        Assert-AreEqual 1 $rule.TargetUrls.Count
        Assert-AreEqual $ruleTargetUrl $rule.TargetUrls[0]

        # Verify Azure Firewall Application Rule Collection Rule Protocols
        Assert-NotNull $rule.Protocols
        Assert-AreEqual 1 $rule.Protocols.Count
        Assert-AreEqual $ruleProtocolType $rule.Protocols[0].ProtocolType

        # Verify Azure Firewall Application Rule Collection Rule Actions
        Assert-NotNull $rule.Actions
        Assert-AreEqual 1 $rule.Actions.Count
        Assert-AreEqual $ruleActionType $rule.Actions[0].ActionType

        # Add a Rule
        $action = New-AzureRmFirewallApplicationRuleActionConfig -ActionType $rule2ActionType
        $applicationRuleCollection.Rules.Add(New-AzureRmFirewallApplicationRule –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action)

        # Verify a rule was added
        Assert-AreEqual 2 $getApplicationRuleCollection.Rules.Count
        Assert-AreEqual $ruleName $applicationRuleCollection.Rules[0].Name
        Assert-AreEqual $rule2Name $applicationRuleCollection.Rules[1].Name

        # Get Rule 2
        $rule2 = $applicationRuleCollection.GetRuleByName($rule2Name)

        # Verify Rule 2
        Assert-AreEqual $rule2Name $rule2.Name
        Assert-AreEqual $rule2Desc $rule2.Description
        Assert-AreEqual $rule2Priority $rule2.Priority

        # Verify Rule Target URLs
        Assert-NotNull $rule2.TargetUrls
        Assert-AreEqual 1 $rule2.TargetUrls.Count
        Assert-AreEqual $rule2TargetUrl $rule2.TargetUrls[0]

        # Verify Rule Protocols
        Assert-NotNull $rule2.Protocols
        Assert-AreEqual 1 $rule2.Protocols.Count
        Assert-AreEqual $rule2ProtocolType $rule2.Protocols[0].ProtocolType

        # Verify Rule Actions
        Assert-NotNull $rule2.Actions
        Assert-AreEqual 1 $rule2.Actions.Count
        Assert-AreEqual $rule2ActionType $rule2.Actions[0].ActionType

        # Delete AzureFirewall
        $delete = Remove-AzureRmFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
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
