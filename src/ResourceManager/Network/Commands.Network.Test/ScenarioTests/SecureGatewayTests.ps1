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

    $vnetName = Get-ResourceName
    $subnetName = "SecureGatewaySubnet"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
        
        # Create SecureGateway
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -Location $rglocation

        # Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgname
        
        #verification
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
        Assert-NotNull $getSecureGateway.Location
        Assert-AreEqual $rglocation $getSecureGateway.Location
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-AreEqual 0 @($getSecureGateway.IpConfigurations).Count
        Assert-AreEqual 0 @($getSecureGateway.ApplicationRuleCollections).Count

        # list all Secure Gateways in the resource group
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getSecureGateway.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count

        # list all Secure Gateways in the subscription
        $list = Get-AzureRmSecureGateway 
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getSecureGateway.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Associate the Virtual Network to Secure Gateway
        $ipConfig = New-AzureRmSecureGatewayIpConfiguration -Name "IpConf" -Subnet $vnet.Subnets[0]
        $secureGateway.IpConfigurations = @($ipConfig)

        # Update the Gateway
        Set-AzureRmSecureGateway -SecureGateway $secureGateway

        # Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName

        #verification
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
        Assert-NotNull $getSecureGateway.Location
        Assert-AreEqual $rglocation $getSecureGateway.Location
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-NotNull $getSecureGateway.IpConfigurations
        Assert-AreEqual 1 $getSecureGateway.IpConfigurations.Count
        Assert-NotNull $getSecureGateway.IpConfigurations[0].Subnet
        Assert-AreEqual $vnet.Subnets[0].Id $getSecureGateway.IpConfigurations[0].Subnet.Id
        Assert-AreEqual 0 @($getSecureGateway.ApplicationRuleCollections).Count

        # Delete VirtualNetwork - should fail
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual false $delete

        # Delete SecureGateway
        $delete = Remove-AzureRmSecureGateway -ResourceGroupName $rgname -name $secureGatewayName -PassThru -Force
        Assert-AreEqual true $delete

        # Delete VirtualNetwork again - this time it should succeed
        $delete = Remove-AzureRmVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
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
    $resourceTypeParent = "Microsoft.Network/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create SecureGatewayApplicationRuleCollection
        $protocol = New-AzureRmSecureGatewayApplicationProtocol -ProtocolType $ruleProtocolType
        $action = New-AzureRmSecureGatewayApplicationRuleAction -ActionType $ruleActionType
        $rule = New-AzureRmSecureGatewayApplicationRule –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
        $ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollection1Name -Priority $applicationRuleCollection1Priority -Rules $rule

        # Create SecureGateway with an Application Rule Collection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -Location $rglocation -ApplicationRuleCollections $ruleCollection

        # Get SecureGateway
        $getSecureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName

        #verification
        # Verify Secure Gateway
        Assert-AreEqual $rgName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $secureGatewayName $getSecureGateway.Name
        Assert-NotNull $getSecureGateway.Location
        Assert-AreEqual $rglocation $getSecureGateway.Location
        Assert-NotNull $getSecureGateway.ResourceGuid
        Assert-NotNull $getSecureGateway.Etag
        Assert-AreEqual 0 @($getSecureGateway.IpConfigurations).Count
        Assert-AreEqual 1 @($getSecureGateway.ApplicationRuleCollections).Count

        # Verify Secure Gateway Application Rule Collection
        Assert-NotNull $getSecureGateway.ApplicationRuleCollections[0].Rules
        Assert-AreEqual 1 $getSecureGateway.ApplicationRuleCollections[0].Rules.Count
        Assert-AreEqual $applicationRuleCollection1Name $getSecureGateway.ApplicationRuleCollections[0].Name
        Assert-AreEqual $applicationRuleCollection1Priority $getSecureGateway.ApplicationRuleCollections[0].Priority
        Assert-NotNull $getSecureGateway.ApplicationRuleCollections[0].Etag

        # Verify Rule
        Assert-AreEqual $ruleName $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Name
        Assert-AreEqual $ruleDesc $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Description
        Assert-AreEqual "Outbound" $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Direction
        Assert-AreEqual $rulePriority $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Priority

        # Verify Rule Target URLs
        Assert-NotNull $getSecureGateway.ApplicationRuleCollections[0].Rules[0].TargetUrls
        Assert-AreEqual 1 $getSecureGateway.ApplicationRuleCollections[0].Rules[0].TargetUrls.Count
        Assert-AreEqual $ruleTargetUrl $getSecureGateway.ApplicationRuleCollections[0].Rules[0].TargetUrls[0]

        # Verify Rule Protocols
        Assert-NotNull $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Protocols
        Assert-AreEqual 1 $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Protocols.Count
        Assert-AreEqual $ruleProtocolType $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Protocols[0].ProtocolType

        # Verify Rule Actions
        Assert-NotNull $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Actions
        Assert-AreEqual 1 $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Actions.Count
        Assert-AreEqual $ruleActionType $getSecureGateway.ApplicationRuleCollections[0].Rules[0].Actions[0].ActionType

        # List SecureGateways
        $list = Get-AzureRmSecureGateway -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getSecureGateway.ResourceGroupName
        Assert-AreEqual $list[0].Name $getSecureGateway.Name
        Assert-AreEqual $list[0].Location $getSecureGateway.Location
        Assert-AreEqual $list[0].Etag $getSecureGateway.Etag
        Assert-AreEqual @($list[0].IpConfigurations).Count @($getSecureGateway.IpConfigurations).Count
        Assert-AreEqual @($list[0].ApplicationRuleCollections).Count @($getSecureGateway.ApplicationRuleCollections).Count

        Assert-AreEqual $list[0].ApplicationRuleCollections[0].Name $getSecureGateway.ApplicationRuleCollections[0].Name
        Assert-AreEqual $list[0].ApplicationRuleCollections[0].Etag $getSecureGateway.ApplicationRuleCollections[0].Etag

        # Add a Secure Gateway Application Rule Collection
        $protocol = New-AzureRmSecureGatewayApplicationProtocol -ProtocolType $rule2ProtocolType
        $action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $rule2ActionType
        $rule = New-AzureRmSecureGatewayApplicationRule –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action
        $ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollection2Name -Priority $applicationRuleCollection2Priority -Rules $ruleConfig
        $secureGateway = Get-AzureRmSecureGateway -name $secureGatewayName -ResourceGroupName $rgName
        $secureGateway.ApplicationRuleCollections.Add($ruleCollection)

        # Verify 
        Assert-AreEqual 2 $secureGateway.ApplicationRuleCollections.Count
        Assert-NotNull $secureGateway.ApplicationRuleCollections[1].Etag
        Assert-AreEqual $applicationRuleCollection1Name $secureGateway.ApplicationRuleCollections[0].Name
        Assert-AreEqual $applicationRuleCollection2Name $secureGateway.ApplicationRuleCollections[1].Name

        # Get ApplicationRuleCollection
        $applicationRuleCollection2 = $secureGateway.GetApplicationRuleCollectionByName($applicationRuleCollection2Name)

        # Verify Secure Gateway Application Rule Collection
        Assert-AreEqual $applicationRuleCollection2 $secureGateway.ApplicationRuleCollections[1]

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
    $resourceTypeParent = "Microsoft.Application/SecureGateways"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create SecureGatewayApplicationRuleCollection
        $action = New-AzureRmSecureGatewayApplicationRuleAction -ActionType $ruleActionType
        $protocol = New-AzureRmSecureGatewayApplicationProtocol -ProtocolType $rule1ProtocolType
        $ruleConfig = New-AzureRmSecureGatewayApplicationRule –Name $ruleName -Description $ruleDesc -Priority $rulePriority -Protocols $protocol -TargetUrls $ruleTargetUrl -Actions $action
        $ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection –Name $applicationRuleCollectionName -Priority $applicationRuleCollectionPriority -Rules $ruleConfig

        # Create SecureGateway with a SecureGatewayApplicationRuleCollection
        $secureGateway = New-AzureRmSecureGateway –Name $secureGatewayName -ResourceGroupName $rgname -Location $rglocation -ApplicationRuleCollections $ruleCollection

        # Get ApplicationRuleCollection
        $applicationRuleCollection = $getSecureGateway.GetApplicationRuleCollectionByName($applicationRuleCollectionName)
        Assert-NotNull $applicationRuleCollection
        Assert-AreEqual 1 @($applicationRuleCollection.Rules).Count

        # Get ApplicationRule
        $rule = $applicationRuleCollection.GetRuleByName($ruleName)
        Assert-NotNull($rule)

        # Verify Rule has been created
        Assert-AreEqual $ruleName $rule.Name
        Assert-AreEqual $ruleDesc $rule.Description
        Assert-AreEqual $rulePriority $rule.Priority

        # Verify Secure Gateway Application Rule Collection Rule Target URLs
        Assert-NotNull $rule.TargetUrls
        Assert-AreEqual 1 $rule.TargetUrls.Count
        Assert-AreEqual $ruleTargetUrl $rule.TargetUrls[0]

        # Verify Secure Gateway Application Rule Collection Rule Protocols
        Assert-NotNull $rule.Protocols
        Assert-AreEqual 1 $rule.Protocols.Count
        Assert-AreEqual $ruleProtocolType $rule.Protocols[0].ProtocolType

        # Verify Secure Gateway Application Rule Collection Rule Actions
        Assert-NotNull $rule.Actions
        Assert-AreEqual 1 $rule.Actions.Count
        Assert-AreEqual $ruleActionType $rule.Actions[0].ActionType

        # Add a Rule
        $action = New-AzureRmSecureGatewayApplicationRuleActionConfig -ActionType $rule2ActionType
        $applicationRuleCollection.Rules.Add(New-AzureRmSecureGatewayApplicationRule –Name $rule2Name -Description $rule2Desc -Priority $rule2Priority -Protocols $protocol -TargetUrls $rule2TargetUrl -Actions $action)

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
