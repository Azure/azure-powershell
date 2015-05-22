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

$ErrorActionPreference = "Stop"

$NetworkSecurityGroupPrefix = "onesdk";

$NSGLabel = "Scenario Test NSG"

$locations = Get-AzureLocation
$Location = $locations[0].Name

$RuleType = "Outbound"
$RulePriority = 500
$RuleAction = "Deny"
$RuleSourceAddressPrefix = "*"
$RuleSourcePortRange = "*"
$RuleDestinationAddressPrefix = "*"
$RuleDestinationPortRange = "*"
$RuleProtocol = "TCP"

$VirtualNetworkName = "VirtualNetworkSiteName"
$SubnetName = "FrontEndSubnet"


<#
.SYNOPSIS
Gets valid Security Group name.
#>
function Get-SecurityGroupName
{
    $name = getAssetName
    Write-Debug "Using network security group with name: $name"
    return $name
}

<#
.SYNOPSIS
Gets valid Security Rule name.
#>
function Get-SecurityRuleName
{
    $name = getAssetName
    Write-Debug "Using network security rule with name: $name"
    return $name
}

<#
.SYNOPSIS
Creates a Security Group.
#>
function New-NetworkSecurityGroup
{
    param([string] $securityGroupName, [string] $location = $location)

    New-AzureNetworkSecurityGroup -Name $securityGroupName -Location $location -Label $NSGLabel
}

<#
.SYNOPSIS
Creates a Security Group.
#>
function Set-NetworkSecurityRule
{
    param([string] $securityRuleName, [object] $securityGroup)

    Set-AzureNetworkSecurityRule -Name $securityRuleName -Type $RuleType -Priority $RulePriority -Action $RuleAction -SourceAddressPrefix $RuleSourceAddressPrefix -SourcePortRange $RuleSourcePortRange -DestinationAddressPrefix $RuleDestinationAddressPrefix -DestinationPortRange $RuleDestinationPortRange -Protocol $RuleProtocol -NetworkSecurityGroup $securityGroup
}

<#
.SYNOPSIS
Creates a Security Group.
#>
function Get-NetworkSecurityGroupForSubnet
{
    Get-AzureNetworkSecurityGroupForSubnet -VirtualNetworkName $VirtualNetworkName -SubnetName $SubnetName
}


<#
.SYNOPSIS
Removes all NSGs created by Powershell tests from the current subscription.
#>
function Initialize-NetworkSecurityGroupTest
{
    Initialize-NetworkTest
    Get-AzureNetworkSecurityGroup | Where-Object { $_.Name.StartsWith($NetworkSecurityGroupPrefix) } | Remove-AzureNetworkSecurityGroup -Force
}
