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

########################## New Network Security Group Tests #############################

<#
.SYNOPSIS
Tests New-AzureNetworkSecurityGroup and Remove-AzureNetworkSecurityGroup.
#>
function Test-CreateAndRemoveNetworkSecurityGroup
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    New-NetworkSecurityGroup $securityGroupName

    # Test
    $isDeleted = Remove-AzureNetworkSecurityGroup -Name $securityGroupName -Force -PassThru
    
    # Assert
    Assert-True { $isDeleted } "Failed to delete Network Security Group $securityGroupName"
    Assert-Throws { Get-AzureNetworkSecurityGroup -Name $securityGroupName } "ResourceNotFound: The Network Security Group $securityGroupName does not exist."
}

<#
.SYNOPSIS
Tests Remove-AzureNetworkSecurityGroup with non existing name
#>
function Test-RemoveNetworkSecurityGroupWithNonExistingName
{
    # Setup
    $nonExistingSecurityGroupName = Get-SecurityGroupName "nonexisting"

    # Assert
    Assert-Throws { Remove-AzureNetworkSecurityGroup -Name $nonExistingSecurityGroupName -Force } "ResourceNotFound : The Network Security Group $nonExistingSecurityGroupName does not exist."
}


########################## Get Network Security Group Tests #############################

<#
.SYNOPSIS
Tests Get-AzureNetworkSecurityGroup <name>
#>
function Test-GetSecurityGroup
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName

    # Test
    $retrievedSecurityGroup = Get-AzureNetworkSecurityGroup $securityGroupName
    
    # Assert
    Assert-AreEqualObjectProperties $createdSecurityGroup $retrievedSecurityGroup
}

<#
.SYNOPSIS
Tests Get-AzureNetworkSecurityGroup
#>
function Test-GetMultipleNetworkSecurityGroups
{
    # Setup
    $securityGroupName1 = "$(Get-SecurityGroupName)1"
    $securityGroupName2 = "$(Get-SecurityGroupName)2"

    $createdSecurityGroup1 = New-NetworkSecurityGroup $securityGroupName1
    $createdSecurityGroup2 = New-NetworkSecurityGroup $securityGroupName2
    
    # Test
    $retrievedSecurityGroups = Get-AzureNetworkSecurityGroup
    
    # Assert
    Assert-True { $($retrievedSecurityGroups | select -ExpandProperty Name) -Contains $securityGroupName1 } "Assert failed, security group '$securityGroupName1' not found"
    Assert-True { $($retrievedSecurityGroups | select -ExpandProperty Name) -Contains $securityGroupName2 } "Assert failed, security group '$securityGroupName2' not found"
}

########################## Set Network Security Rule Tests #############################

<#
.SYNOPSIS
Tests Set-AzureNetworkSecurityRule
#>
function Test-SetNetworkSecurityRule
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName

    # Test
    $addedRuleGroup = Set-NetworkSecurityRule $securityRuleName $createdSecurityGroup

    # Assert
    Assert-AreEqual $securityRuleName $addedRuleGroup.Rules[0].Name
    Assert-AreEqual $RuleType $addedRuleGroup.Rules[0].Type
    Assert-AreEqual $RulePriority $addedRuleGroup.Rules[0].Priority
    Assert-AreEqual $RuleAction $addedRuleGroup.Rules[0].Action
    Assert-AreEqual $RuleSourceAddressPrefix $addedRuleGroup.Rules[0].SourceAddressPrefix
    Assert-AreEqual $RuleSourcePortRange $addedRuleGroup.Rules[0].SourcePortRange
    Assert-AreEqual $RuleDestinationAddressPrefix $addedRuleGroup.Rules[0].DestinationAddressPrefix
    Assert-AreEqual $RuleDestinationPortRange $addedRuleGroup.Rules[0].DestinationPortRange
    Assert-AreEqual $RuleProtocol $addedRuleGroup.Rules[0].Protocol
}

<#
.SYNOPSIS
Tests Set-AzureNetworkSecurityRule with invalid parameter
#>
function Test-SetNetworkSecurityRuleWithInvalidParameter
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName
    
    # Assert
    $expectedMessage = "BadRequest: The Source Address Prefix provided 'INVALID' is invalid. Please provide correct CIDR address or one of the allowed Address Tags."
    Assert-Throws { Set-AzureNetworkSecurityRule -Name $securityRuleName -Type $RuleType -Priority $RulePriority -Action $RuleAction -SourceAddressPrefix "INVALID" -SourcePortRange $RuleSourcePortRange -DestinationAddressPrefix $RuleDestinationAddressPrefix -DestinationPortRange $RuleDestinationPortRange -Protocol $RuleProtocol -NetworkSecurityGroup $createdSecurityGroup } $expectedMessage
}

########################## Remove Network Security Rule Tests #############################

<#
.SYNOPSIS
Tests Remove-AzureNetworkSecurityRule
#>
function Test-RemoveNetworkSecurityRule
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName
    $addedRuleGroup = Set-NetworkSecurityRule $securityRuleName $createdSecurityGroup

    # Test
    Remove-AzureNetworkSecurityRule -Name $securityRuleName -NetworkSecurityGroup $addedRuleGroup -Force
    $NoRulesGroup = Get-AzureNetworkSecurityGroup -Name $securityGroupName -Detailed

    # Assert
    Assert-AreEqual $addedRuleGroup.Rules.Count ($NoRulesGroup.Rules.Count + 1)
}

########################## Set and Get Network Security Group for Subnet Tests #############################

<#
.SYNOPSIS
Tests Set and Get-AzureNetworkSecurityGroupForSubnet
#>
function Test-SetAndGetNetworkSecurityGroupForSubnet
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")
    Set-AzureNetworkSecurityGroupToSubnet -Name $securityGroupName -VirtualNetwork $VirtualNetworkName -Subnet $SubnetName -Force

    # Test
    $securityGroupFromSubnet = Get-AzureNetworkSecurityGroupForSubnet -VirtualNetwork $VirtualNetworkName -Subnet $SubnetName

    # Assert
    Assert-AreEqual $securityGroupFromSubnet.Name $securityGroupName
}

<#
.SYNOPSIS
Tests Set and Get-AzureNetworkSecurityGroupForSubnet
#>
function Test-SetNetworkSecurityGroupToSubnetInDifferentRegion
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $securityGroupLocation = $locations[1].Name
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName $securityGroupLocation
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")

    # Assert
    $expectedMessage = "BadRequest : The region uswest specified for the Network Security Group $securityGroupName is different than the region usnorth that Virtual Network $VirtualNetworkName belongs to, they need to belong to the same region."
    Assert-Throws { Set-AzureNetworkSecurityGroupToSubnet -Name $securityGroupName -VirtualNetwork $VirtualNetworkName -Subnet $SubnetName -Force } $expectedMessage
}

########################## Remove Network Security Group from Subnet Tests #############################

<#
.SYNOPSIS
Tests Remove-AzureNetworkSecurityGroupFromSubnet
#>
function Test-RemoveNetworkSecurityGroupFromSubnet
{
    # Setup
    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")
    Set-AzureNetworkSecurityGroupToSubnet -Name $securityGroupName -VirtualNetwork $VirtualNetworkName -Subnet $SubnetName -Force

    # Test
    Remove-AzureNetworkSecurityGroupFromSubnet -Name $securityGroupName -VirtualNetwork $VirtualNetworkName -Subnet $SubnetName -Force

    # Assert
    $expectedMessage = "ResourceNotFound: The virtual network name $VirtualNetworkName and subnet $SubnetName does not have any network security group assigned."
    Assert-Throws { Get-AzureNetworkSecurityGroupForSubnet -VirtualNetwork $VirtualNetworkName -Subnet $SubnetName } $expectedMessage
}

########################## Update-AzureVM keeps NSG on Role and on NIC #############################

<#
.SYNOPSIS
Tests Update-AzureVM after a VM has NSG on Role
#>
function Test-SetNSGOnRoleAndUpdateVM
{
    # Setup
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")
    $VMName = getAssetName
    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName
    $image = "b9a55fa61dad4dd88bab1b26ca2ed075__Test-Win2K8R2SP1-Datacenter-201401.01-en.us-127GB.vhd"

    # Test
    New-AzureVMConfig -ImageName $image -Name $VMName -InstanceSize Small |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    Set-AzureSubnet -SubnetNames $SubnetName |
    New-AzureVM -VNetName $VirtualNetworkName -ServiceName $VMName -Location $Location

    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName

    # Test
    Get-AzureVM $VMName | Set-AzureNetworkSecurityGroupAssociation $securityGroupName
    Get-AzureVM $VMName |
    Add-AzureEndpoint -Name "http" -Protocol tcp -LocalPort 80 -PublicPort 80 |
    Update-AzureVM

    # Assert
    $retrievedNSG = Get-AzureVM $VMName | Get-AzureNetworkSecurityGroupAssociation
    Assert-AreEqual $securityGroupName $retrievedNSG.Name
}
<#
.SYNOPSIS
Tests Update-AzureVM after a VM has NSG on Role
#>
function Test-SetNSGOnNICAndUpdateVM
{
    # Setup
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\SimpleNetworkConfiguration.xml")
    $VMName = getAssetName
    $nicName = getAssetName
    $image = get-azurevmimage | Where-Object {$_.OS -eq 'Windows'} | Select-Object -First 1 -ExpandProperty ImageName
    $image = "b9a55fa61dad4dd88bab1b26ca2ed075__Test-Win2K8R2SP1-Datacenter-201401.01-en.us-127GB.vhd"

    # Test
    New-AzureVMConfig -ImageName $image -Name $VMName -InstanceSize Large |
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Add-AzureProvisioningConfig -Windows -AdminUsername azuretest -Password "Pa@!!w0rd" |
    Set-AzureSubnet -SubnetNames $SubnetName |
    Add-AzureNetworkInterfaceConfig -Name $nicName -SubnetName $SubnetName |
    New-AzureVM -VNetName $VirtualNetworkName -ServiceName $VMName -Location $Location

    $securityGroupName = Get-SecurityGroupName
    $securityRuleName = Get-SecurityRuleName
    $createdSecurityGroup = New-NetworkSecurityGroup $securityGroupName

    # Test
    Get-AzureVM $VMName | Set-AzureNetworkSecurityGroupAssociation -Name $securityGroupName -NetworkInterfaceName $nicName
    Get-AzureVM $VMName |
    Add-AzureEndpoint -Name "http" -Protocol tcp -LocalPort 80 -PublicPort 80 |
    Update-AzureVM

    # Assert
    $retrievedNSG = Get-AzureVM $VMName | Get-AzureNetworkSecurityGroupAssociation -NetworkInterfaceName $nicName
    Assert-AreEqual $securityGroupName $retrievedNSG.Name
}
