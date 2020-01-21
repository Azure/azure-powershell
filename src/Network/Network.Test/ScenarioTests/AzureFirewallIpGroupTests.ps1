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
      $ipGroupLocation = Get-ProviderLocation ResourceManagement "southcentralus"
      $ipGroupName1 = Get-ResourceName
      $ipGroupName2 = Get-ResourceName
    
      $azureFirewallName = Get-ResourceName 
      #$resourceTypeParent = "Microsoft.Network/AzureFirewalls"
      #$location = Get-ProviderLocation $resourceTypeParent "eastus2euap"
  
      $vnetName = Get-ResourceName
      $subnetName = "AzureFirewallSubnet"
      $publicIpName = Get-ResourceName
  
      # AzureFirewallApplicationRuleCollection
      $someAppRuleCollectionName = "someAppRuleCollection"
      $someAppRuleCollectionPriority = 100
      $someAppRuleCollectionActionType = "Allow"
  
      # AzureFirewallApplicationRule 1
      $someAppRuleName = "someAppRule"
      $someAppRuleFqdn1 = "*bing.com"
      $someAppRuleProtocol1 = "http:8080"
      $someAppRulePort1 = 8080
      $someAppRuleProtocolType1 = "http"
  
      # AzureFirewallApplicationRule 2
      $someOtherAppRuleName = "someOtherAppRule"
      $someOtherAppRuleFqdn1 = "sql1.database.windows.net"
      $someOtherAppRuleProtocol1 = "mssql:1433"
      $someOtherAppRulePort1 = 1433
      $someOtherAppRuleProtocolType1 = "mssql"
  
      # AzureFirewallNetworkRuleCollection
      $networkRcName = "networkRc"
      $networkRcPriority = 200
      $networkRcActionType = "Deny"
  

      # AzureFirewallNetworkRule 1
      $someNetworkRuleName = "networkRule"
      $someNetworkRuleDesc = "desc1"
      $someNetworkRuleSourceAddress1 = "10.0.0.0"
      $someNetworkRuleSourceAddress2 = "111.1.0.0/24"
      $someNetworkRuleDestinationAddress1 = "*"
      $someNetworkRuleProtocol1 = "UDP"
      $someNetworkRuleProtocol2 = "TCP"
      $someNetworkRuleProtocol3 = "ICMP"
      $someNetworkRuleDestinationPort1 = "90"
  
      # AzureFirewallNatRuleCollection
      $someNatRuleCollectionName = "natRc"
      $someNatRuleCollectionPriority = 200
  
      # AzureFirewallNatRule 2
      $someNatRuleName = "natRule2"
      $someNatRuleDesc = "desc2"
      $someNatRuleSourceAddress1 = "10.0.0.0"
      $someNatRuleSourceAddress2 = "111.1.0.0/24"
      $someNatRuleProtocol1 = "UDP"
      $someNatRuleProtocol2 = "TCP"
      $someNatRuleDestinationPort1 = "95"
      $someNatRuleTranslatedFqdn = "server1.internal.com"
      $someNatRuleTranslatedPort = "96"

    try
    {
      # Create the resource group
      New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

      # Create IpGroup
      $ipGroup1 = New-AzIpGroup -ResourceGroupName $rgname -location $ipgroupLocation -Name $ipGroupName1 -IpAddress 10.0.0.0/24,11.9.0.0/24
      $returnedIpGroup1 = Get-AzIpGroup -ResourceGroupName $rgname -Name $ipGroupName1
      Assert-AreEqual $returnedIpGroup1.ResourceGroupName $ipGroup1.ResourceGroupName	
      Assert-AreEqual $returnedIpGroup1.Name $ipGroup1.Name

      $ipGroup2 = New-AzIpGroup -ResourceGroupName $rgname -location $ipgroupLocation -Name $ipGroupName2 -IpAddress 12.0.0.0/24,13.9.0.0/24
      $returnedIpGroup2 = Get-AzIpGroup -ResourceGroupName $rgname -Name $ipGroupName2
      Assert-AreEqual $returnedIpGroup2.ResourceGroupName $ipGroup2.ResourceGroupName	
      Assert-AreEqual $returnedIpGroup2.Name $ipGroup2.Name
      
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $ipGroupLocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      # Get full subnet details
      $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

      # Create public ip
      $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard

      # Create AzureFirewall (with no rules, ThreatIntel is in Alert mode by default)
      $azureFirewall = New-AzFirewall –Name $azureFirewallName -ResourceGroupName $rgname -Location $location -VirtualNetworkName $vnetName -PublicIpName $publicIpName
   
      #
      #  Application Rule Section
      #
      
      # Create Application Rules
      $someAppRule = New-AzFirewallApplicationRule -Name $someAppRuleName -SourceIpGroup $ipGroup1.Id -Protocol $someAppRuleProtocol1 -TargetFqdn $someAppRuleFqdn1

      $someOtherAppRule = New-AzFirewallApplicationRule -Name $someOtherAppRuleName -SourceIpGroup $ipGroup1.Id,$ipGroup2.Id -Protocol $someOtherAppRuleProtocol1 -TargetFqdn $someOtherAppRuleFqdn1

      # Create Application Rule Collection with 1 rule
      $someAppRuleCollection = New-AzFirewallApplicationRuleCollection -Name $someAppRuleCollectionName -Priority $someAppRuleCollectionPriority -Rule $someAppRule -ActionType $someAppRuleCollectionActionType
           
      # Add a rule to the rule collection using AddRule method
      $someAppRuleCollection.AddRule($someOtherAppRule)

      # Add ApplicationRuleCollections to the Firewall using method AddApplicationRuleCollection
      $azureFirewall.AddApplicationRuleCollection($someAppRuleCollection)

         
      #
      #  Network Rule Section
      #

      # Create Network Rule
      
      $someNetworkRule = New-AzFirewallNetworkRule -Name $someNetworkRuleName -Description $someNetworkRuleDesc -Protocol $someNetworkRuleProtocol1, $someNetworkRuleProtocol2 -SourceAddress $someNetworkRuleSourceAddress1, $someNetworkRuleSourceAddress2 -SourceIpGroup $ipGroup1.Id -DestinationIpGroup $ipGroup2.Id -DestinationPort $someNetworkRuleDestinationPort1
      $someNetworkRule.AddProtocol($someNetworkRuleProtocol3)

      # Create Network Rule Collection
      $someNetworkRuleCollection = New-AzFirewallNetworkRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $someNetworkRule -ActionType $networkRcActionType

      # Add this Network Rule to the rule collection
      #$someNetworkRuleCollection.AddRule($someNetworkRule)

      # Add NetworkRuleCollections to the Firewall using method AddNetworkRuleCollection
      $azureFirewall.AddNetworkRuleCollection($someNetworkRuleCollection)

      #
      #  NAT Rule Section
      #

      # Create  NAT rule
      $someNatRule = New-AzFirewallNatRule -Name $someNatRuleName -Description $someNatRuleDesc -Protocol $someNatRuleProtocol1 -SourceIpGroup $ipGroup1.Id, $ipGroup2.Id -DestinationAddress $publicip.IpAddress -DestinationPort $someNatRuleDestinationPort1 -TranslatedFqdn $someNatRuleTranslatedFqdn -TranslatedPort $someNatRuleTranslatedPort
      $someNatRule.AddProtocol($someNatRuleProtocol2)
      
      # Create a NAT Rule Collection
      $someNatRuleCollection = New-AzFirewallNatRuleCollection -Name $someNatRuleCollectionName -Priority $someNatRuleCollectionPriority -Rule $someNatRule
      
      # Add  NAT Rule to rule Collection
      #$someNatRuleCollection.AddRule($someNatRule)

      # Add NatRuleCollections to the Firewall using method AddNatRuleCollection
      $azureFirewall.AddNatRuleCollection($someNatRuleCollection)
 
      # Set AzureFirewall
      #Set-AzFirewall -AzureFirewall $azureFirewall

      # Get AzureFirewall
      #$getAzureFirewall = Get-AzFirewall -name $azureFirewallName -ResourceGroupName $rgName

      $getAzureFirewall = $azureFirewall

      #
      # Verification - Application Rule 
      #

      # Verify application rule collection 2
      $someAppRuleCollection2 = $getAzureFirewall.GetApplicationRuleCollectionByName($someAppRuleCollectionName)

      # Verify application rule
      $getSomeAppRule = $someAppRuleCollection2.GetRuleByName($someAppRule.Name)
      Assert-AreEqual 1 $getSomeAppRule.SourceIpGroups.Count

      $getSomeOtherAppRule = $someAppRuleCollection2.GetRuleByName($someOtherAppRule.Name)
      Assert-AreEqual 2 $getSomeOtherAppRule.SourceIpGroups.Count
            
      #
      # Verification - Network Rule 
      #

       # Verify Network rule collection 2
      $someNetworkRuleCollection2 = $getAzureFirewall.GetNetworkRuleCollectionByName($someNetworkRuleCollection.Name)

      # Verify Network rule
      $getSomeNetworkRule = $someNetworkRuleCollection2.GetRuleByName($someNetworkRule.Name)
      Assert-AreEqual 1 $getSomeNetworkRule.SourceIpGroups.Count
      Assert-AreEqual 1 $getSomeNetworkRule.DestinationIpGroups.Count

      #
      # Verification - NAT Rule 
      #
      $someNatRuleCollection2 = $getAzureFirewall.GetNatRuleCollectionByName($someNatRuleCollection.Name)
      $getSomeNatRule = $someNatRuleCollection2.GetRuleByName($someNatRule.Name)
      Assert-AreEqual 2 $getSomeNatRule.SourceIpGroups.Count  

	  # Delete IpGroup
	  $deleteIpGroup = Remove-AzIpGroup -ResourceGroupName $rgname -Name $ipGroupName1 -PassThru -Force
      Assert-AreEqual true $deleteIpGroup

      $deleteIpGroup = Remove-AzIpGroup -ResourceGroupName $rgname -Name $ipGroupName2 -PassThru -Force
      Assert-AreEqual true $deleteIpGroup

      # Delete AzureFirewall
      $delete = Remove-AzFirewall -ResourceGroupName $rgname -name $azureFirewallName -PassThru -Force
      Assert-AreEqual true $delete

      # Delete VirtualNetwork 
      $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
      Assert-AreEqual true $delete

    }
    finally
    {
      # Cleanup
      Clean-ResourceGroup $rgname
    }


}