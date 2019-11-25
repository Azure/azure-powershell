#----------------------------------------------------------------------------------

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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}


<#
.SYNOPSIS
Test creating new IpGroups
#>
function Test-AzureFirewallIpGroup
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement "southcentralus"
    $location = Get-ProviderLocation ResourceManagement "southcentralus"
    $IpGroupsName = Get-ResourceName
    
      $azureFirewallName = Get-ResourceName 
      #$resourceTypeParent = "Microsoft.Network/AzureFirewalls"
      #$location = Get-ProviderLocation $resourceTypeParent "eastus2euap"
  
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
  
      # AzureFirewallNatRuleCollection
      $natRcName = "natRc"
      $natRcPriority = 200
  
  
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

    try
    {
      # Create the resource group
      New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

      # Create IpGroup
	   $actualIpGroup = New-AzIpGroup -ResourceGroupName $rgname -location $location -Name $IpGroupsName -IpAddress 10.0.0.0/24,11.9.0.0/24
      $expectedIpGroup = Get-AzIpGroup -ResourceGroupName $rgname -Name $IpGroupsName
	   Assert-AreEqual $expectedIpGroup.ResourceGroupName $actualIpGroup.ResourceGroupName	
      Assert-AreEqual $expectedIpGroup.Name $actualIpGroup.Name

      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      # Get full subnet details
      $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

      # Create public ip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

      # Create AzureFirewall (with no rules, ThreatIntel is in Alert mode by default)
      $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName

      # Create Application Rules
      $appRule = New-AzFirewallApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1

      $appRule2 = New-AzFirewallApplicationRule -Name $appRule2Name -SourceIpGroup $actualIpGroup -Protocol $appRule2Protocol1 -TargetFqdn $appRule2Fqdn1

      $appRule3 = New-AzFirewallApplicationRule -Name $appRule3Name -Protocol $appRule3Protocol1 -TargetFqdn $appRule3Fqdn1

      # Create Application Rule Collection with 1 rule
      $appRc = New-AzFirewallApplicationRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

      # Add a rule to the rule collection using AddRule method
      $appRc.AddRule($appRule2)
      $appRc.AddRule($appRule3)

      # Create Network Rule
      $networkRule = New-AzFirewallNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1
      $networkRule.AddProtocol($networkRule1Protocol3)

      # Create Second Network Rule
      $networkRule2 = New-AzFirewallNetworkRule -Name $networkRule2Name -Description $networkRule2Desc -Protocol $networkRule2Protocol1, $networkRule2Protocol2 -SourceAddress $networkRule2SourceAddress1, $networkRule2SourceAddress2 -DestinationFqdn $networkRule2DestinationFqdn1 -DestinationPort $networkRule2DestinationPort1
      $networkRule2.AddProtocol($networkRule2Protocol3)

      # Create Network Rule Collection
      $netRc = New-AzFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType

      # Add this second Network Rule to the rule collection
      $netRc.AddRule($networkRule2)

      # Create second NAT rule
      $natRule2 = New-AzFirewallNatRule -Name $natRule2Name -Description $natRule2Desc -Protocol $natRule2Protocol1 -SourceAddress $natRule2SourceAddress1, $natRule2SourceAddress2 -DestinationAddress $publicip.IpAddress -DestinationPort $natRule2DestinationPort1 -TranslatedFqdn $natRule2TranslatedFqdn -TranslatedPort $natRule2TranslatedPort
      $natRule2.AddProtocol($natRule2Protocol2)
      
      # Create a NAT Rule Collection
      $natRc = New-AzFirewallNatRuleCollection -Name $natRcName -Priority $natRcPriority -Rule $natRule
      
      # Add second NAT Rule to rule Collection
      $natRc.AddRule($natRule2)

      # Add ApplicationRuleCollections to the Firewall using method AddApplicationRuleCollection
      azureFirewall.AddApplicationRuleCollection($appRc)

      # Add NatRuleCollections to the Firewall using method AddNatRuleCollection
      $azureFirewall.AddNatRuleCollection($natRc)

      # Add NetworkRuleCollections to the Firewall using method AddNetworkRuleCollection
      $azureFirewall.AddNetworkRuleCollection($netRc)

      # Set AzureFirewall
      Set-AzFirewall -AzureFirewall $azureFirewall


      # Get AzureFirewall
      $getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName

      # Check rule collections
      Assert-AreEqual 1 @($getAzureFirewall.ApplicationRuleCollections).Count
      Assert-AreEqual 3 @($getAzureFirewall.ApplicationRuleCollections[0].Rules).Count

      Assert-AreEqual 1 @($getAzureFirewall.NatRuleCollections).Count
      Assert-AreEqual 2 @($getAzureFirewall.NatRuleCollections[0].Rules).Count

      Assert-AreEqual 1 @($getAzureFirewall.NetworkRuleCollections).Count
      Assert-AreEqual 2 @($getAzureFirewall.NetworkRuleCollections[0].Rules).Count     

      $list = Get-AzFirewall -ResourceGroupName $rgname
      Assert-AreEqual 0 @($list).Count

      <#
	   # Delete IpGroup
	   $deleteIpGroup = Remove-AzIpGroup -ResourceGroupName $rgname -Name $IpGroupsName -PassThru -Force
      Assert-AreEqual true $deleteIpGroup

      # Delete AzureFirewall
      $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
      Assert-AreEqual true $delete

      # Delete VirtualNetwork 
      $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
      Assert-AreEqual true $delete
#>


    }
    finally
    {
        # Cleanup
        #Clean-ResourceGroup $rgname
    }
}