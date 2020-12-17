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
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "eastus2euap"

    $ruleGroupName = Get-ResourceName

    # AzureFirewallPolicyApplicationRuleCollection
    $appRcName = "appRc"
    $appRcPriority = 400
    $appRcActionType = "Allow"

    $pipelineRcPriority = 154

    # AzureFirewallPolicyApplicationRule 1
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
    $appRule1SourceAddress1 = "192.168.0.0/16"

    # AzureFirewallPolicyApplicationRule 2
    $appRule2Name = "appRule2"
    $appRule2Fqdn1 = "*bing.com"
    $appRule2Protocol1 = "http:8080"
    $appRule2Protocol2 = "https:443"
    $appRule2Port1 = 8080
    $appRule2ProtocolType1 = "http"
    $appRule2SourceAddress1 = "192.168.0.0/16"

    # AzureFirewallPolicyNetworkRuleCollection
    $networkRcName = "networkRc"
    $networkRcPriority = 200
    $networkRcActionType = "Deny"

    # AzureFirewallPolicyNetworkRule 1
    $networkRule1Name = "networkRule"
    $networkRule1Desc = "desc1"
    $networkRule1SourceAddress1 = "10.0.0.0"
    $networkRule1SourceAddress2 = "111.1.0.0/24"
    $networkRule1DestinationAddress1 = "10.10.10.1"
    $networkRule1Protocol1 = "UDP"
    $networkRule1Protocol2 = "TCP"
    $networkRule1Protocol3 = "ICMP"
    $networkRule1DestinationPort1 = "90"

    # AzureFirewallPolicyNatRuleCollection
    $natRcName = "natRc"
    $natRcPriority = 100
    $natRcActionType = "Dnat"

    # AzureFirewallPolicyNatRule 1
    $natRule1Name = "natRule"
    $natRule1Desc = "desc1"
    $natRule1SourceAddress1 = "10.0.0.0"
    $natRule1SourceAddress2 = "111.1.0.0/24"
    $natRule1Protocol1 = "UDP"
    $natRule1Protocol2 = "TCP"
    $natRule1DestinationPort1 = "90"
    $natRule1TranslatedAddress = "10.1.2.3"
    $natRule1TranslatedPort = "91"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location 

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.ThreatIntelMode


        #Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1
        $appRule2 = New-AzFirewallPolicyApplicationRule -Name $appRule2Name -Description $appRule1Desc -Protocol $appRule2Protocol1, $appRule2Protocol2 -TargetFqdn $appRule2Fqdn1 -SourceAddress $appRule2SourceAddress1

        # Create Network Rule
        $networkRule = New-AzFirewallPolicyNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1


        # Create Filter Rule with 2 application rules
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule, $appRule2 -ActionType $appRcActionType
        
        # Create a second Filter Rule Collection with 1 network rule
        $appRc2 = New-AzFirewallPolicyFilterRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType


        # Create NAT rule
        $natRule = New-AzFirewallPolicyNatRule -Name $natRule1Name -Description $natRule1Desc -Protocol $natRule1Protocol1, $natRule1Protocol2 -SourceAddress $natRule1SourceAddress1, $natRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort

        # Create a NAT Rule Collection
        $natRc = New-AzFirewallPolicyNatRuleCollection -Name $natRcName -ActionType $natRcActionType -Priority $natRcPriority -Rule $natRule

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc, $appRc2, $natRc -FirewallPolicyObject $azureFirewallPolicy


        # # Update ThreatIntel mode
        $azureFirewallPolicy.ThreatIntelMode = "Deny"
        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-AreEqual "Deny" $getAzureFirewallPolicy.ThreatIntelMode

        # Check rule groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy

        Assert-AreEqual 3 @($getRg.properties.ruleCollection).Count

        $filterRuleCollection1 = $getRg.Properties.GetRuleCollectionByName($appRcName)
        $filterRuleCollection2 = $getRg.Properties.GetRuleCollectionByName($networkRcName)
        $natRuleCollection = $getRg.Properties.GetRuleCollectionByName($natRcName)

        # Verify Filter Rule Collection1 
        Assert-AreEqual $appRcName $filterRuleCollection1.Name
        Assert-AreEqual $appRcPriority $filterRuleCollection1.Priority
        Assert-AreEqual $appRcActionType $filterRuleCollection1.Action.Type
        Assert-AreEqual 2 $filterRuleCollection1.Rules.Count

        $appRule = $filterRuleCollection1.GetRuleByName($appRule1Name)
        # Verify application rule 1
        Assert-AreEqual $appRule1Name $appRule.Name

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

        # Verify Filter Rule Collection2 
        Assert-AreEqual $networkRcName $filterRuleCollection2.Name
        Assert-AreEqual $networkRcPriority $filterRuleCollection2.Priority
        Assert-AreEqual $networkRcActionType $filterRuleCollection2.Action.Type
        Assert-AreEqual 1 $filterRuleCollection2.Rules.Count

        $networkRule = $filterRuleCollection2.GetRuleByName($networkRule1Name)
        # Verify Network rule
        Assert-AreEqual $networkRule1Name $networkRule.Name

        Assert-AreEqual 2 $networkRule.SourceAddresses.Count
        Assert-AreEqual $networkRule1SourceAddress1 $networkRule.SourceAddresses[0]
        Assert-AreEqual $networkRule1SourceAddress2 $networkRule.SourceAddresses[1]

        Assert-AreEqual 2 $networkRule.Protocols.Count 
        Assert-AreEqual $networkRule1Protocol1 $networkRule.Protocols[0]
        Assert-AreEqual $networkRule1Protocol2 $networkRule.Protocols[1]

        Assert-AreEqual 1 $networkRule.DestinationPorts.Count 
        Assert-AreEqual $networkRule1DestinationPort1 $networkRule.DestinationPorts[0]

        # Verify NAT rule collection and NAT rule
        $natRule = $natRuleCollection.GetRuleByName($natRule1Name)

        Assert-AreEqual $natRcName $natRuleCollection.Name
        Assert-AreEqual $natRcPriority $natRuleCollection.Priority

        Assert-AreEqual $natRule1Name $natRule.Name

        Assert-AreEqual 2 $natRule.SourceAddresses.Count 
        Assert-AreEqual $natRule1SourceAddress1 $natRule.SourceAddresses[0]
        Assert-AreEqual $natRule1SourceAddress2 $natRule.SourceAddresses[1]

        Assert-AreEqual 1 $natRule.DestinationAddresses.Count

        Assert-AreEqual 2 $natRule.Protocols.Count
        Assert-AreEqual $natRule1Protocol1 $natRule.Protocols[0]
        Assert-AreEqual $natRule1Protocol2 $natRule.Protocols[1]

        Assert-AreEqual 1 $natRule.DestinationPorts.Count
        Assert-AreEqual $natRule1DestinationPort1 $natRule.DestinationPorts[0]

        Assert-AreEqual $natRule1TranslatedAddress $natRule.TranslatedAddress
        Assert-AreEqual $natRule1TranslatedPort $natRule.TranslatedPort


        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        $testPipelineRg|Set-AzFirewallPolicyRuleCollectionGroup -Priority $pipelineRcPriority
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        Assert-AreEqual $pipelineRcPriority $testPipelineRg.properties.Priority 

        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewallPolicyCRUD with ThreatIntelWhitelist.
#>
function Test-AzureFirewallPolicyWithThreatIntelWhitelistCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "eastus2euap"

    $ruleGroupName = Get-ResourceName
    $threatIntelWhiteListIp1 = "20.3.4.5"
    $threatIntelWhiteListIp2 = "37.1.2.3"
    $threatIntelWhiteListIp3 = "208.199.20.37"
    $threatIntelWhiteListFqdn1 = "microsoft.com"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        $tiWhiteList = New-AzFirewallPolicyThreatIntelWhitelist -IpAddress $threatIntelWhiteListIp1,$threatIntelWhiteListIp2 -FQDN $threatIntelWhiteListFqdn1

        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -ThreatIntelWhitelist $tiWhiteList

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.ThreatIntelMode
        Assert-NotNull $getAzureFirewallPolicy.ThreatIntelWhitelist
        Assert-AreEqual $threatIntelWhiteListIp1 $getAzureFirewallPolicy.ThreatIntelWhitelist.IpAddresses[0]
        Assert-AreEqual $threatIntelWhiteListIp2 $getAzureFirewallPolicy.ThreatIntelWhitelist.IpAddresses[1]
        Assert-AreEqual $threatIntelWhiteListFqdn1 $getAzureFirewallPolicy.ThreatIntelWhitelist.FQDNs[0]

        # # Update ThreatIntel Whitelist
        $azureFirewallPolicy.ThreatIntelWhitelist.IpAddresses[0] = $threatIntelWhiteListIp3

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.ThreatIntelWhitelist
        Assert-AreEqual $threatIntelWhiteListIp3 $getAzureFirewallPolicy.ThreatIntelWhitelist.IpAddresses[0]
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewallPolicyWithDNSSettings.
#>
function Test-AzureFirewallPolicyWithDNSSettings {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "eastus2euap"
    $dnsServers = @("10.10.10.1", "20.20.20.2")

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create AzureFirewallPolicy with No DNS Settings
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

         # Check DNS Proxy
        Assert-Null $getAzureFirewallPolicy.DnsSettings.EnableProxy
        Assert-Null $getAzureFirewallPolicy.DnsSettings.Servers

        # Update AzureFirewallPolicy with Enable Proxy and DNS Servers

        $dnsSetting = New-AzFirewallPolicyDnsSetting -EnableProxy -Server $dnsServers

        $azureFirewallPolicy = Set-AzFirewallPolicy -InputObject $azureFirewallPolicy -DnsSetting $dnsSetting

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

         # Check DNS Proxy
        Assert-AreEqual true $getAzureFirewallPolicy.DnsSettings.EnableProxy
        Assert-AreEqualArray $dnsServers $getAzureFirewallPolicy.DnsSettings.Servers

        # Update AzureFirewallPolicy with Enable Proxy and DNS Servers
        $dnsSettings2 = New-AzFirewallPolicyDnsSetting -EnableProxy -Server $dnsServers

        $azureFirewallPolicy = Set-AzFirewallPolicy -InputObject $azureFirewallPolicy -DnsSetting $dnsSettings2

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

         # Check DNS Proxy
        Assert-AreEqual true $getAzureFirewallPolicy.DnsSettings.EnableProxy
        Assert-AreEqualArray $dnsServers $getAzureFirewallPolicy.DnsSettings.Servers

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location

         # Check DNS Proxy
        Assert-AreEqual true $getAzureFirewallPolicy.DnsSettings.EnableProxy
        Assert-AreEqualArray $dnsServers $getAzureFirewallPolicy.DnsSettings.Servers

        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -DnsSetting $dnsSettings -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State;
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests function Test-AzureFirewallPolicyCRUDWithNetworkRuleDestinationFQDNs.
#>
function Test-AzureFirewallPolicyCRUDWithNetworkRuleDestinationFQDNs {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "eastus2euap"
    $dnsServers = @("10.10.10.1", "20.20.20.2")

    $ruleGroupName = Get-ResourceName

    # AzureFirewallPolicyNetworkRuleCollection
    $networkRcName = "networkRc"
    $networkRcPriority = 200
    $networkRcActionType = "Deny"

    # AzureFirewallPolicyNetworkRule 1
    $networkRule1Name = "networkRule"
    $networkRule1Desc = "desc1"
    $networkRule1SourceAddress1 = "10.0.0.0"
    $networkRule1SourceAddress2 = "111.1.0.0/24"
    $networkRuleDestinationFqdns = "www.bing.com"
    $networkRule1Protocol1 = "UDP"
    $networkRule1Protocol2 = "TCP"
    $networkRule1Protocol3 = "ICMP"
    $networkRule1DestinationPort1 = "90"

    $pipelineRcPriority = 154

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        $dnsSettings = New-AzFirewallPolicyDnsSetting -EnableProxy -Server $dnsServers

        # Create AzureFirewallPolicy (with DNS Settings)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -DnsSetting $dnsSettings

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.ThreatIntelMode

        # Create Network Rule
        $networkRule = New-AzFirewallPolicyNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationFqdn $networkRuleDestinationFqdns -DestinationPort $networkRule1DestinationPort1

        # Create a second Filter Rule Collection with 1 network rule
        $netRc1 = New-AzFirewallPolicyFilterRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $netRc1 -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.DnsSettings

        # Check rule collection groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy

        Assert-AreEqual 1 @($getRg.properties.ruleCollection).Count

        $filterRuleCollection = $getRg.Properties.GetRuleCollectionByName($networkRcName)
        
        # Verify Filter Rule Collection 
        Assert-AreEqual $networkRcName $filterRuleCollection.Name
        Assert-AreEqual $networkRcPriority $filterRuleCollection.Priority
        Assert-AreEqual $networkRcActionType $filterRuleCollection.Action.Type
        Assert-AreEqual 1 $filterRuleCollection.Rules.Count

        $networkRule = $filterRuleCollection.GetRuleByName($networkRule1Name)
        # Verify Network rule
        Assert-AreEqual $networkRule1Name $networkRule.Name

        Assert-AreEqual 2 $networkRule.SourceAddresses.Count
        Assert-AreEqual $networkRule1SourceAddress1 $networkRule.SourceAddresses[0]
        Assert-AreEqual $networkRule1SourceAddress2 $networkRule.SourceAddresses[1]

        Assert-AreEqual 2 $networkRule.Protocols.Count 
        Assert-AreEqual $networkRule1Protocol1 $networkRule.Protocols[0]
        Assert-AreEqual $networkRule1Protocol2 $networkRule.Protocols[1]

        Assert-AreEqual 1 $networkRule.DestinationPorts.Count 
        Assert-AreEqual $networkRule1DestinationPort1 $networkRule.DestinationPorts[0]

        Assert-Null $networkRule.DestinationAddresses
        Assert-AreEqual 1 $networkRule.DestinationFqdns.Count


        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        $testPipelineRg|Set-AzFirewallPolicyRuleCollectionGroup -Priority $pipelineRcPriority
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        Assert-AreEqual $pipelineRcPriority $testPipelineRg.properties.Priority 

        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewallPolicyWithIpGroups.
#>
function Test-AzureFirewallPolicyWithIpGroups {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "eastus2euap"
    $ipGroupLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $ipGroupName1 = Get-ResourceName
    $ipGroupName2 = Get-ResourceName

    $ruleGroupName = Get-ResourceName

    # AzureFirewallPolicyApplicationRuleCollection
    $appRcName = "appRc"
    $appRcPriority = 400
    $appRcActionType = "Allow"

    $pipelineRcPriority = 154

    # AzureFirewallPolicyApplicationRule 1
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

    # AzureFirewallPolicyApplicationRule 2
    $appRule2Name = "appRule2"
    $appRule2Fqdn1 = "*bing.com"
    $appRule2Protocol1 = "http:8080"
    $appRule2Protocol2 = "https:443"
    $appRule2Port1 = 8080
    $appRule2ProtocolType1 = "http"

    # AzureFirewallPolicyNetworkRuleCollection
    $networkRcName = "networkRc"
    $networkRcPriority = 200
    $networkRcActionType = "Deny"

    # AzureFirewallPolicyNetworkRule 1
    $networkRule1Name = "networkRule"
    $networkRule1Desc = "desc1"
    $networkRule1Protocol1 = "UDP"
    $networkRule1Protocol2 = "TCP"
    $networkRule1Protocol3 = "ICMP"
    $networkRule1DestinationAddress1 = "10.10.10.1"
    $networkRule1DestinationPort1 = "90"

    # AzureFirewallPolicyNatRuleCollection
    $natRcName = "natRc"
    $natRcPriority = 100
    $natRcActionType = "Dnat"

    # AzureFirewallPolicyNatRule 1
    $natRule1Name = "natRule"
    $natRule1Desc = "desc1"
    $natRule1Protocol1 = "UDP"
    $natRule1Protocol2 = "TCP"
    $natRule1DestinationPort1 = "90"
    $natRule1TranslatedAddress = "10.1.2.3"
    $natRule1TranslatedPort = "91"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location 

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.ThreatIntelMode

        # Create IpGroup
        $ipGroup1 = New-AzIpGroup -ResourceGroupName $rgname -location $ipgroupLocation -Name $ipGroupName1 -IpAddress 10.0.0.0/24,11.9.0.0/24
        $returnedIpGroup1 = Get-AzIpGroup -ResourceGroupName $rgname -Name $ipGroupName1
        Assert-AreEqual $returnedIpGroup1.ResourceGroupName $ipGroup1.ResourceGroupName	
        Assert-AreEqual $returnedIpGroup1.Name $ipGroup1.Name

        $ipGroup2 = New-AzIpGroup -ResourceGroupName $rgname -location $ipgroupLocation -Name $ipGroupName2 -IpAddress 12.0.0.0/24,13.9.0.0/24
        $returnedIpGroup2 = Get-AzIpGroup -ResourceGroupName $rgname -Name $ipGroupName2
        Assert-AreEqual $returnedIpGroup2.ResourceGroupName $ipGroup2.ResourceGroupName	
        Assert-AreEqual $returnedIpGroup2.Name $ipGroup2.Name


        #Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceIpGroup $ipGroup1.Id
        $appRule2 = New-AzFirewallPolicyApplicationRule -Name $appRule2Name -Description $appRule1Desc -Protocol $appRule2Protocol1, $appRule2Protocol2 -TargetFqdn $appRule2Fqdn1 -SourceIpGroup $ipGroup1.Id,$ipGroup2.Id

        # Create Network Rule
        $networkRule = New-AzFirewallPolicyNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceIpGroup $ipGroup1.Id -DestinationIpGroup $ipGroup2.Id -DestinationPort $networkRule1DestinationPort1


        # Create Filter Rule with 2 application rules
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule, $appRule2 -ActionType $appRcActionType
        
        # Create a second Filter Rule Collection with 1 network rule
        $appRc2 = New-AzFirewallPolicyFilterRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType


        # Create NAT rule
        $natRule = New-AzFirewallPolicyNatRule -Name $natRule1Name -Description $natRule1Desc -Protocol $natRule1Protocol1, $natRule1Protocol2 -SourceIpGroup $ipGroup1.Id, $ipGroup2.Id -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort

        # Create a NAT Rule Collection
        $natRc = New-AzFirewallPolicyNatRuleCollection -Name $natRcName -ActionType $natRcActionType -Priority $natRcPriority -Rule $natRule

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc, $appRc2, $natRc -FirewallPolicyObject $azureFirewallPolicy


        # # Update ThreatIntel mode
        $azureFirewallPolicy.ThreatIntelMode = "Deny"
        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-AreEqual "Deny" $getAzureFirewallPolicy.ThreatIntelMode

        # Check rule groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy

        Assert-AreEqual 3 @($getRg.properties.ruleCollection).Count

        $filterRuleCollection1 = $getRg.Properties.GetRuleCollectionByName($appRcName)
        $filterRuleCollection2 = $getRg.Properties.GetRuleCollectionByName($networkRcName)
        $natRuleCollection = $getRg.Properties.GetRuleCollectionByName($natRcName)

        # Verify Filter Rule Collection1 
        Assert-AreEqual $appRcName $filterRuleCollection1.Name
        Assert-AreEqual $appRcPriority $filterRuleCollection1.Priority
        Assert-AreEqual $appRcActionType $filterRuleCollection1.Action.Type
        Assert-AreEqual 2 $filterRuleCollection1.Rules.Count
        
        $appRule = $filterRuleCollection1.GetRuleByName($appRule1Name)
        # Verify application rule 1
        Assert-AreEqual $appRule1Name $appRule.Name

        Assert-AreEqual 1 $appRule.SourceIpGroups.Count

        Assert-AreEqual 2 $appRule.Protocols.Count
        Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
        Assert-AreEqual $appRule1ProtocolType2 $appRule.Protocols[1].ProtocolType
        Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port
        Assert-AreEqual $appRule1Port2 $appRule.Protocols[1].Port

        Assert-AreEqual 2 $appRule.TargetFqdns.Count
        Assert-AreEqual $appRule1Fqdn1 $appRule.TargetFqdns[0]
        Assert-AreEqual $appRule1Fqdn2 $appRule.TargetFqdns[1]

        # Verify application rule 2
        $appRule2 = $filterRuleCollection1.GetRuleByName($appRule2Name)
        Assert-AreEqual $appRule2Name $appRule2.Name

        Assert-AreEqual 2 $appRule2.SourceIpGroups.Count
        
        Assert-AreEqual 2 $appRule.TargetFqdns.Count
        Assert-AreEqual $appRule1Fqdn1 $appRule.TargetFqdns[0]
        Assert-AreEqual $appRule1Fqdn2 $appRule.TargetFqdns[1]

        # Verify Filter Rule Collection2 
        Assert-AreEqual $networkRcName $filterRuleCollection2.Name
        Assert-AreEqual $networkRcPriority $filterRuleCollection2.Priority
        Assert-AreEqual $networkRcActionType $filterRuleCollection2.Action.Type
        Assert-AreEqual 1 $filterRuleCollection2.Rules.Count

        $networkRule = $filterRuleCollection2.GetRuleByName($networkRule1Name)
        # Verify Network rule
        Assert-AreEqual $networkRule1Name $networkRule.Name

        Assert-AreEqual 1 $networkRule.SourceIpGroups.Count
        Assert-AreEqual 1 $networkRule.DestinationIpGroups.Count

        Assert-AreEqual 2 $networkRule.Protocols.Count
        Assert-AreEqual $networkRule1Protocol1 $networkRule.Protocols[0]
        Assert-AreEqual $networkRule1Protocol2 $networkRule.Protocols[1]

        Assert-AreEqual 1 $networkRule.DestinationPorts.Count 
        Assert-AreEqual $networkRule1DestinationPort1 $networkRule.DestinationPorts[0]

        # Verify NAT rule collection and NAT rule
        $natRule = $natRuleCollection.GetRuleByName($natRule1Name)

        Assert-AreEqual $natRcName $natRuleCollection.Name
        Assert-AreEqual $natRcPriority $natRuleCollection.Priority

        Assert-AreEqual $natRule1Name $natRule.Name

        Assert-AreEqual 2 $natRule.SourceIpGroups.Count

        Assert-AreEqual 1 $natRule.DestinationAddresses.Count

        Assert-AreEqual 2 $natRule.Protocols.Count
        Assert-AreEqual $natRule1Protocol1 $natRule.Protocols[0]
        Assert-AreEqual $natRule1Protocol2 $natRule.Protocols[1]

        Assert-AreEqual 1 $natRule.DestinationPorts.Count
        Assert-AreEqual $natRule1DestinationPort1 $natRule.DestinationPorts[0]

        Assert-AreEqual $natRule1TranslatedAddress $natRule.TranslatedAddress
        Assert-AreEqual $natRule1TranslatedPort $natRule.TranslatedPort


        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        $testPipelineRg|Set-AzFirewallPolicyRuleCollectionGroup -Priority $pipelineRcPriority
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        Assert-AreEqual $pipelineRcPriority $testPipelineRg.properties.Priority 

        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests function Test-AzureFirewallPolicyCRUDWithNatRuleTranslatedFQDN.
#>
function Test-AzureFirewallPolicyCRUDWithNatRuleTranslatedFQDN {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "canadacentral"

    $ruleGroupName = Get-ResourceName

    # AzureFirewallPolicyNatRuleCollection
    $natRcName = "natRc"
    $natRcPriority = 100
    $natRcActionType = "Dnat"

    # AzureFirewallPolicyNatRule 1
    $natRule1Name = "natRule"
    $natRule1Desc = "desc1"
    $natRule1SourceAddress1 = "10.0.0.0"
    $natRule1SourceAddress2 = "111.1.0.0/24"
    $natRule1Protocol1 = "UDP"
    $natRule1Protocol2 = "TCP"
    $natRule1DestinationAddress1 = "10.10.10.1"
    $natRule1DestinationPort1 = "90"
    $natRule1TranslatedFqdn = "server1.internal.com"
    $natRule1TranslatedPort = "91"

    $pipelineRcPriority = 154

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create AzureFirewallPolicy
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.ThreatIntelMode

        # Create NAT rule
        $natRule = New-AzFirewallPolicyNatRule -Name $natRule1Name -Description $natRule1Desc -Protocol $natRule1Protocol1, $natRule1Protocol2 -SourceAddress $natRule1SourceAddress1, $natRule1SourceAddress2 -DestinationAddress $natRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedFqdn $natRule1TranslatedFqdn -TranslatedPort $natRule1TranslatedPort

        # Create a NAT Rule Collection
        $natRc = New-AzFirewallPolicyNatRuleCollection -Name $natRcName -ActionType $natRcActionType -Priority $natRcPriority -Rule $natRule

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $natRc -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location

        # Check rule collection groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy

        Assert-AreEqual 1 @($getRg.properties.ruleCollection).Count

        $natRuleCollection = $getRg.Properties.GetRuleCollectionByName($natRcName)
        
        # Verify NAT rule collection and NAT rule
        $natRule = $natRuleCollection.GetRuleByName($natRule1Name)

        Assert-AreEqual $natRcName $natRuleCollection.Name
        Assert-AreEqual $natRcPriority $natRuleCollection.Priority

        Assert-AreEqual $natRule1Name $natRule.Name

        Assert-AreEqual 2 $natRule.SourceAddresses.Count 
        Assert-AreEqual $natRule1SourceAddress1 $natRule.SourceAddresses[0]
        Assert-AreEqual $natRule1SourceAddress2 $natRule.SourceAddresses[1]

        Assert-AreEqual 1 $natRule.DestinationAddresses.Count

        Assert-AreEqual 2 $natRule.Protocols.Count
        Assert-AreEqual $natRule1Protocol1 $natRule.Protocols[0]
        Assert-AreEqual $natRule1Protocol2 $natRule.Protocols[1]

        Assert-AreEqual 1 $natRule.DestinationPorts.Count
        Assert-AreEqual $natRule1DestinationPort1 $natRule.DestinationPorts[0]

        Assert-AreEqual $natRule1TranslatedFqdn $natRule.TranslatedFqdn
        Assert-AreEqual $natRule1TranslatedPort $natRule.TranslatedPort

        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        $testPipelineRg|Set-AzFirewallPolicyRuleCollectionGroup -Priority $pipelineRcPriority
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        Assert-AreEqual $pipelineRcPriority $testPipelineRg.properties.Priority 

        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewallPolicyWithWebCategories.
#>
function Test-AzureFirewallPolicyWithWebCategories {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"

    $ruleGroupName = Get-ResourceName

    # AzureFirewallPolicyApplicationRuleCollection
    $appRcName = "appRc"
    $appRcPriority = 400
    $appRcActionType = "Allow"

    $pipelineRcPriority = 154

    # AzureFirewallPolicyApplicationRule 1
    $appRule1Name = "appRule"
    $appRule1Desc = "desc1"
    $appRule1WC1 = "DatingAndPersonals"
    $appRule1WC2 = "Tasteless"
    $appRule1Protocol1 = "http:80"
    $appRule1Port1 = 80
    $appRule1ProtocolType1 = "http"
    $appRule1Protocol2 = "https:443"
    $appRule1Port2 = 443
    $appRule1ProtocolType2 = "https"
    $appRule1SourceAddress1 = "192.168.0.0/16"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location 

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location


        #Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -WebCategory $appRule1WC1, $appRule1WC2 -SourceAddress $appRule1SourceAddress1

        # Create Filter Rule with 2 application rules
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc -FirewallPolicyObject $azureFirewallPolicy

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location

        # Check rule groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy

        Assert-AreEqual 1 @($getRg.properties.ruleCollection).Count

        $filterRuleCollection1 = $getRg.Properties.GetRuleCollectionByName($appRcName)

        # Verify Filter Rule Collection1
        Assert-AreEqual $appRcName $filterRuleCollection1.Name
        Assert-AreEqual $appRcPriority $filterRuleCollection1.Priority
        Assert-AreEqual $appRcActionType $filterRuleCollection1.Action.Type
        Assert-AreEqual 1 $filterRuleCollection1.Rules.Count

        $appRule = $filterRuleCollection1.GetRuleByName($appRule1Name)
        # Verify application rule 1
        Assert-AreEqual $appRule1Name $appRule.Name

        Assert-AreEqual 1 $appRule.SourceAddresses.Count
        Assert-AreEqual $appRule1SourceAddress1 $appRule.SourceAddresses[0]

        Assert-AreEqual 2 $appRule.Protocols.Count 
        Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
        Assert-AreEqual $appRule1ProtocolType2 $appRule.Protocols[1].ProtocolType
        Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port
        Assert-AreEqual $appRule1Port2 $appRule.Protocols[1].Port

        Assert-AreEqual 2 $appRule.WebCategories.Count 
        Assert-AreEqual $appRule1WC1 $appRule.WebCategories[0]
        Assert-AreEqual $appRule1WC2 $appRule.WebCategories[1]


        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        $testPipelineRg|Set-AzFirewallPolicyRuleCollectionGroup -Priority $pipelineRcPriority
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        Assert-AreEqual $pipelineRcPriority $testPipelineRg.properties.Priority 

        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}