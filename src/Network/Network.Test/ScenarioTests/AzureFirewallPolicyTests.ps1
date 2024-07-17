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

    # AzureFirewallPolicyApplicationRule 3
    $appRule3Name = "appRule3"
    $appRule3Fqdn1 = "www.ssllabs.com"
    $appRule3Protocol1 = "mssql:1433"
    $appRule3SourceAddress1 = "192.168.0.0/16"

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
        $appRule3 = New-AzFirewallPolicyApplicationRule -Name $appRule3Name -Protocol $appRule3Protocol1 -TargetFqdn $appRule3Fqdn1 -SourceAddress $appRule3SourceAddress1

        # Create Network Rule
        $networkRule = New-AzFirewallPolicyNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1


        # Create Filter Rule with 3 application rules
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule, $appRule2, $appRule3 -ActionType $appRcActionType
        
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
        Assert-AreEqual 3 $filterRuleCollection1.Rules.Count

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

        # Verify mssql application rule 
        $mssqlRule = $filterRuleCollection1.GetRuleByName($appRule3Name)
        Assert-AreEqual $appRule3Name $mssqlRule.Name

        Assert-AreEqual 1 $mssqlRule.SourceAddresses.Count
        Assert-AreEqual $appRule3SourceAddress1 $mssqlRule.SourceAddresses[0]

        Assert-AreEqual 1 $mssqlRule.Protocols.Count 
        Assert-AreEqual "mssql" $mssqlRule.Protocols[0].ProtocolType
        Assert-AreEqual 1433 $mssqlRule.Protocols[0].Port

        Assert-AreEqual 1 $mssqlRule.TargetFqdns.Count 
        Assert-AreEqual $appRule3Fqdn1 $mssqlRule.TargetFqdns[0]

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
    $location = "westus2"

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
    $location = "westus2"
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
Tests AzureFirewallPolicyWithSQLSettings
#>
function Test-AzureFirewallPolicyWithSQLSetting {
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyName2 = Get-ResourceName
    $location = "westus2"

    try {

        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # test new AzureFirewallPolicy with sql redirect
        $allowSql = New-AzFirewallPolicySqlSetting -AllowSqlRedirect
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SqlSetting $allowSql
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

        # check sql setting
        Assert-NotNull $getAzureFirewallPolicy.SqlSetting
        Assert-AreEqual true $getAzureFirewallPolicy.SqlSetting.AllowSqlRedirect

        # test set AzureFirewallPolicy without sql redirect
        $disallowSql = New-AzFirewallPolicySqlSetting
        $azureFirewallPolicy = Set-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SqlSetting $disallowSql
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        Assert-AreEqual false $getAzureFirewallPolicy.SqlSetting.AllowSqlRedirect

        # test set AzureFirewallPolicy with sql redirect
        $azureFirewallPolicy = Set-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SqlSetting $allowSql
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        Assert-NotNull $getAzureFirewallPolicy.SqlSetting
        Assert-AreEqual true $getAzureFirewallPolicy.SqlSetting.AllowSqlRedirect

        # test new AzureFirewallPolicy without sql redirect
        $azureFirewallPolicy2 = New-AzFirewallPolicy -Name $azureFirewallPolicyName2 -ResourceGroupName $rgname -Location $location
        $getAzureFirewallPolicy2 = Get-AzFirewallPolicy -Name $azureFirewallPolicyName2 -ResourceGroupName $rgname

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy2.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName2 $getAzureFirewallPolicy2.Name
        Assert-NotNull $getAzureFirewallPolicy2.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy2.Location

        # check sql setting
        Assert-Null $getAzureFirewallPolicy2.SqlSetting
        
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
    $location = "westus2"
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
    $location = "westus2"
    $ipGroupLocation = Get-ProviderLocation ResourceManagement "westus2"
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
Tests AzureFirewallPolicyPremiumWithTerminateTLSEnabled.
#>
function Test-AzureFirewallPolicyPremiumWithTerminateTLSEnabled {
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
    $appRule1Fqdn1 = "*google.com"
    $appRule1Fqdn2 = "*microsoft.com"
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
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier Premium

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

        # Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1 -TerminateTLS
        
        # Create Filter Rule with 1 application rule
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
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

        Assert-AreEqual 2 $appRule.TargetFqdns.Count 
        Assert-AreEqual $appRule1Fqdn1 $appRule.TargetFqdns[0]
        Assert-AreEqual $appRule1Fqdn2 $appRule.TargetFqdns[1]

        # Verify TerminatTLS flag is set
        Assert-AreEqual true $appRule.TerminateTLS

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
Tests AzureFirewallPolicyPremiumWithTerminateTLSDisabledAndTargetUrls.
#>
function Test-AzureFirewallPolicyPremiumWithTerminateTLSDisabledAndTargetUrls {
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
    $appRule1TargetUrl1 = "www.google.com/index.html"
    $appRule1TargetUrl2 = "www.microsoft.com/index.html"
    $appRule1Protocol1 = "http:80"
    $appRule1Port1 = 80
    $appRule1ProtocolType1 = "http"
    $appRule1SourceAddress1 = "192.168.0.0/16"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier Premium

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

        #Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1 -TargetUrl $appRule1TargetUrl1, $appRule1TargetUrl2 -SourceAddress $appRule1SourceAddress1
        
        # Create Filter Rule with 1 application rule
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
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

        Assert-AreEqual 1 $appRule.Protocols.Count 
        Assert-AreEqual $appRule1ProtocolType1 $appRule.Protocols[0].ProtocolType
        Assert-AreEqual $appRule1Port1 $appRule.Protocols[0].Port

        Assert-AreEqual 2 $appRule.TargetUrls.Count 
        Assert-AreEqual $appRule1TargetUrl1 $appRule.TargetUrls[0]
        Assert-AreEqual $appRule1TargetUrl2 $appRule.TargetUrls[1]

        # Verify TerminatTLS flag is NOT set
        Assert-AreEqual false $appRule.TerminateTLS

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
Tests AzureFirewallPolicyPremiumWithTerminateTLSEnabledAndTargetUrls.
#>
function Test-AzureFirewallPolicyPremiumWithTerminateTLSEnabledAndTargetUrls {
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
    $appRule1TargetUrl1 = "www.google.com"
    $appRule1TargetUrl2 = "www.microsoft.com"
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
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier Premium

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location

        #Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetUrl $appRule1TargetUrl1, $appRule1TargetUrl2 -SourceAddress $appRule1SourceAddress1 -TerminateTLS
        
        # Create Filter Rule with 1 application rule
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
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

        Assert-AreEqual 2 $appRule.TargetUrls.Count 
        Assert-AreEqual $appRule1TargetUrl1 $appRule.TargetUrls[0]
        Assert-AreEqual $appRule1TargetUrl2 $appRule.TargetUrls[1]

        # Verify TerminatTLS flag is set
        Assert-AreEqual true $appRule.TerminateTLS

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

<#
.SYNOPSIS
Tests function Test-AzureFirewallPolicyPremiumFeatures.
#>
function Test-AzureFirewallPolicyPremiumFeatures {

    param
	(
		[string]$basedir = "./",
		[string]$spn
	)

    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $transportSecurityName = "ts-test"
    $tier = "Premium"
    $bypassTestName = "bypass-test"
    $identityName = Get-ResourceName

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create Managed Identity
        $identity = New-AzUserAssignedIdentity -Name $identityName -Location $location -ResourceGroup $rgname

        # Intrusion Detection Settings
        $bypass = New-AzFirewallPolicyIntrusionDetectionBypassTraffic -Name $bypassTestName -Protocol "TCP" -DestinationPort "80" -SourceAddress "10.0.0.0" -DestinationAddress "10.0.0.0"
        $sigOverride = New-AzFirewallPolicyIntrusionDetectionSignatureOverride -Id "123456798" -Mode "Deny"
        $intrusionDetection = New-AzFirewallPolicyIntrusionDetection -Mode "Alert" -SignatureOverride $sigOverride -BypassTraffic $bypass -PrivateRange @("10.0.0.0/8", "172.16.0.0/12")

        # Create AzureFirewallPolicy (with Intrusion Detection, TransportSecurity and Identity parameters)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier $tier -IntrusionDetection $intrusionDetection  -UserAssignedIdentityId $identity.Id
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqual $tier $getAzureFirewallPolicy.Sku.Tier

        # IntrusionDetection verification
        Assert-NotNull $getAzureFirewallPolicy.IntrusionDetection
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.IntrusionDetection.Mode
        Assert-NotNull $getAzureFirewallPolicy.IntrusionDetection.Configuration.SignatureOverrides
        Assert-NotNull $getAzureFirewallPolicy.IntrusionDetection.Configuration.BypassTrafficSettings
        Write-Host $getAzureFirewallPolicy.IntrusionDetection.Configuration
        Assert-NotNull $getAzureFirewallPolicy.IntrusionDetection.Configuration.PrivateRanges
        Assert-AreEqual "123456798" $getAzureFirewallPolicy.IntrusionDetection.Configuration.SignatureOverrides[0].Id
        Assert-AreEqual "Deny" $getAzureFirewallPolicy.IntrusionDetection.Configuration.SignatureOverrides[0].Mode
        Assert-AreEqual "10.0.0.0/8" $getAzureFirewallPolicy.IntrusionDetection.Configuration.PrivateRanges[0]
        Assert-AreEqual $bypassTestName $getAzureFirewallPolicy.IntrusionDetection.Configuration.BypassTrafficSettings[0].Name
        Assert-AreEqual "TCP" $getAzureFirewallPolicy.IntrusionDetection.Configuration.BypassTrafficSettings[0].Protocol
        Assert-AreEqual "80" $getAzureFirewallPolicy.IntrusionDetection.Configuration.BypassTrafficSettings[0].DestinationPorts[0]
        Assert-AreEqual "10.0.0.0" $getAzureFirewallPolicy.IntrusionDetection.Configuration.BypassTrafficSettings[0].SourceAddresses[0]
        Assert-AreEqual "10.0.0.0" $getAzureFirewallPolicy.IntrusionDetection.Configuration.BypassTrafficSettings[0].DestinationAddresses[0]

        # Identity verification
        Assert-AreEqual $getAzureFirewallPolicy.Identity.UserAssignedIdentities.Count 1
		Assert-NotNull $getAzureFirewallPolicy.Identity.UserAssignedIdentities.Values[0].PrincipalId
		Assert-NotNull $getAzureFirewallPolicy.Identity.UserAssignedIdentities.Values[0].ClientId
        
        # Set AzureFirewallPolicy
        $azureFirewallPolicy.IntrusionDetection.Mode = "Off"
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName
        Assert-AreEqual "Off" $getAzureFirewallPolicy.IntrusionDetection.Mode
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall Policy PrivateRange
#>
function Test-AzureFirewallPolicyPrivateRangeCRUD {
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $vnetName = Get-ResourceName
    $privateRange2 = @("IANAPrivateRanges", "0.0.0.0/0", "66.92.0.0/16")
    $privateRange1 = @("3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20")
    $privateRange2Translated = @("0.0.0.0/0", "66.92.0.0/16", "10.0.0.0/8", "172.16.0.0/12", "192.168.0.0/16", "100.64.0.0/10")
    $privateRange3 = @("255.255.255.255/32", "0.0.0.0/32", "1.0.0.0/32", "0.0.0.1/32")

    try {

        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -PrivateRange $privateRange1

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqualArray $privateRange1 $getAzureFirewallPolicy.PrivateRange

        # Modify
        $azureFirewallPolicy.PrivateRange = $privateRange2
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        Assert-AreEqualArray $privateRange2Translated $getAzureFirewallPolicy.PrivateRange

        # Test Always SNAT and /32
        $azureFirewallPolicy.PrivateRange = $privateRange3
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        Assert-AreEqualArray $privateRange3 $getAzureFirewallPolicy.PrivateRange
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall Policy Basic Sku
#>
function Test-AzureFirewallPolicyBasicSku {
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $skuTier = "Basic"

    try {

        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier $skuTier -ThreatIntelMode "Off"

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-NotNull $getAzureFirewallPolicy.Sku
        Assert-AreEqual $skuTier $getAzureFirewallPolicy.Sku.Tier
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests AzureFirewall Policy Explicit Proxy
#>
function Test-AzureFirewallPolicyExplicitProxyCRUD {
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $vnetName = Get-ResourceName
    $pacFile ="https://packetcapturesdev.blob.core.windows.net/explicit-proxy/pacfile.pac?sp=r&st=2022-06-02T21:14:54Z&se=2022-07-15T05:14:54Z&spr=https&sv=2021-06-08&sr=b&sig=VqX7Jfqb0P2HhuoDFDCeGLHvtM65Tu8lpkV96kCWZn0%3D"
   
    try {

        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        $explicitProxySettings = New-AzFirewallPolicyExplicitProxy -EnableExplicitProxy  -HttpPort 85 -HttpsPort 121 -EnablePacFile  -PacFilePort 122 -PacFile $pacFile

        # Create AzureFirewallPolicy (with Explicit Proxy Settings)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -ExplicitProxy $explicitProxySettings

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
       

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull  $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-NotNull  $getAzureFirewallPolicy.ExplicitProxy
        Assert-AreEqual 85 $getAzureFirewallPolicy.ExplicitProxy.HttpPort
        Assert-AreEqual 121 $getAzureFirewallPolicy.ExplicitProxy.HttpsPort
        Assert-AreEqual 122 $getAzureFirewallPolicy.ExplicitProxy.PacFilePort
        Assert-AreEqual $pacFile $getAzureFirewallPolicy.ExplicitProxy.PacFile

        # Modify
        $exProxy = New-AzFirewallPolicyExplicitProxy -EnableExplicitProxy  -HttpPort 86 -HttpsPort 123 -EnablePacFile  -PacFilePort 124 -PacFile $pacFile
        # Set AzureFirewallPolicy
        $azureFirewallPolicy.ExplicitProxy = $exProxy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        Assert-NotNull $getAzureFirewallPolicy.ExplicitProxy
        Assert-AreEqual 86 $getAzureFirewallPolicy.ExplicitProxy.HttpPort
        Assert-AreEqual 123 $getAzureFirewallPolicy.ExplicitProxy.HttpsPort
        Assert-AreEqual 124 $getAzureFirewallPolicy.ExplicitProxy.PacFilePort
        Assert-AreEqual $pacFile $getAzureFirewallPolicy.ExplicitProxy.PacFile
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall Policy Rule Description
#>
function Test-AzureFirewallPolicyRuleDescription {
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"

    $ruleGroupName = Get-ResourceName
    # AzureFirewallPolicyApplicationRule 1
    $appRule1Name = "appRule"
    $appRule1Desc = "appRuleDesc1"
    $appRule1Fqdn1 = "*google.com"
    $appRule1Fqdn2 = "*microsoft.com"
    $appRule1Protocol1 = "http:80"
    $appRule1Port1 = 80
    $appRule1ProtocolType1 = "http"
    $appRule1Protocol2 = "https:443"
    $appRule1Port2 = 443
    $appRule1ProtocolType2 = "https"
    $appRule1SourceAddress1 = "192.168.0.0/16"

    # AzureFirewallPolicyNetworkRule 1
    $networkRule1Name = "networkRule"
    $networkRule1Desc = "networkRuleDesc1"
    $networkRule1SourceAddress1 = "10.0.0.0"
    $networkRule1SourceAddress2 = "111.1.0.0/24"
    $networkRule1DestinationAddress1 = "10.10.10.1"
    $networkRule1Protocol1 = "UDP"
    $networkRule1Protocol2 = "TCP"
    $networkRule1Protocol3 = "ICMP"
    $networkRule1DestinationPort1 = "90"


    # AzureFirewallPolicyNatRule 1
    $natRule1Name = "natRule"
    $natRule1Desc = "natRuleDesc1"
    $natRule1SourceAddress1 = "10.0.0.0"
    $natRule1SourceAddress2 = "111.1.0.0/24"
    $natRule1Protocol1 = "UDP"
    $natRule1Protocol2 = "TCP"
    $natRule1DestinationPort1 = "90"
    $natRule1TranslatedAddress = "10.1.2.3"
    $natRule1TranslatedPort = "91"

    # AzureFirewallPolicyApplicationRuleCollection
    $appRcName = "appRc"
    $appRcPriority = 400
    $appRcActionType = "Allow"

    # AzureFirewallPolicyNetworkRuleCollection
    $networkRcName = "networkRc"
    $networkRcPriority = 200
    $networkRcActionType = "Deny"

    # AzureFirewallPolicyNatRuleCollection
    $natRcName = "natRc"
    $natRcPriority = 100
    $natRcActionType = "Dnat"

    try {

        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location 
      
        #Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1
      
        # Create Network Rule
        $networkRule = New-AzFirewallPolicyNetworkRule -Name $networkRule1Name -Description $networkRule1Desc -Protocol $networkRule1Protocol1, $networkRule1Protocol2 -SourceAddress $networkRule1SourceAddress1, $networkRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $networkRule1DestinationPort1

        # Create NAT rule
        $natRule = New-AzFirewallPolicyNatRule -Name $natRule1Name -Description $natRule1Desc -Protocol $natRule1Protocol1, $natRule1Protocol2 -SourceAddress $natRule1SourceAddress1, $natRule1SourceAddress2 -DestinationAddress $networkRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedAddress $natRule1TranslatedAddress -TranslatedPort $natRule1TranslatedPort

         # Create Filter Rule with 1 application rule
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType
        
        # Create a second Filter Rule Collection with 1 network rule
        $appRc2 = New-AzFirewallPolicyFilterRuleCollection -Name $networkRcName -Priority $networkRcPriority -Rule $networkRule -ActionType $networkRcActionType
    
        # Create a NAT Rule Collection
        $natRc = New-AzFirewallPolicyNatRuleCollection -Name $natRcName -ActionType $natRcActionType -Priority $natRcPriority -Rule $natRule

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc, $appRc2, $natRc -FirewallPolicyObject $azureFirewallPolicy

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $appRule1Desc $appRule.Description
        Assert-AreEqual $networkRule1Desc $networkRule.Description
        Assert-AreEqual $natRule1Desc $natRule.Description

        # Check rule groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy

        Assert-AreEqual 3 @($getRg.properties.ruleCollection).Count

        $filterRuleCollection1 = $getRg.Properties.GetRuleCollectionByName($appRcName)
        $filterRuleCollection2 = $getRg.Properties.GetRuleCollectionByName($networkRcName)
        $natRuleCollection = $getRg.Properties.GetRuleCollectionByName($natRcName)

        $appRule = $filterRuleCollection1.GetRuleByName($appRule1Name)
        # Verify application rule 
        Assert-AreEqual $appRule1Desc $appRule.Description

        $getNetworkRule = $filterRuleCollection2.GetRuleByName($networkRule1Name)
        # Verify Network rule 
        Assert-AreEqual $networkRule1Desc $getNetworkRule.Description

        $getNatRule = $natRuleCollection.GetRuleByName($natRule1Name)
        # Verify Nat rule 
        Assert-AreEqual $natRule1Desc $getNatRule.Description
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests AzureFirewall SNAT
#>
function Test-AzureFirewallSnat {
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $vnetName = Get-ResourceName
    $privateRange = @("3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20")
    $privateRange2 = @("0.0.0.0/0", "66.92.0.0/16")
    $emptyPrivateRange = @()
   
    try {
        
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }

        $snat = New-AzFirewallPolicySnat -PrivateRange $privateRange -AutoLearnPrivateRange
        
        # Create AzureFirewallPolicy (with SNAT)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -Snat $snat
        
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull  $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-NotNull  $getAzureFirewallPolicy.Snat
        Assert-AreEqualArray $privateRange $getAzureFirewallPolicy.Snat.PrivateRanges
        Assert-AreEqual "Enabled" $getAzureFirewallPolicy.Snat.AutoLearnPrivateRanges

         # Modify
        $snat = New-AzFirewallPolicySnat -PrivateRange $privateRange2
        # Set AzureFirewallPolicy
        $azureFirewallPolicy.Snat = $snat
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        $policy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        Assert-NotNull $policy.Snat
        Assert-AreEqualArray $privateRange2 $policy.Snat.PrivateRanges
        Assert-AreEqual "Disabled" $policy.Snat.AutoLearnPrivateRanges

          # Modify
        $snat = New-AzFirewallPolicySnat -AutoLearnPrivateRange
        Assert-AreEqual $emptyPrivateRange $snat.PrivateRanges
        Assert-NotNull $snat.PrivateRanges
        Assert-AreEqual $snat.PrivateRanges.count 0
     
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Azure Firewall Policy Application Rule creation and custom http header addition
#>
function Test-AzureFirewallPolicyApplicationRuleCustomHttpHeader {
# Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "centralindia"
    $ruleGroupName = Get-ResourceName

    # RuleCollection parameters
    $rcName = "RC"
    $rcPriority = 200
    $actionType = "Deny"

    # Rules parameters
    $ruleName1 = "appRule1"
    $ruleName2 = "appRule2"
    $ruleName3 = "appRule3"
    $sourceAddress = "10.0.0.0"
    $targetFqdn = "www.bing.com"
    $httpProtocol = "HTTP"
    $httpsProtocol = "HTTPS"
    $headerName1 = "header1"
    $headerValue1 = "value1"
    $headerName2 = "header2"
    $headerValue2 = "value2"
    $headerName3 = "header3"
    $headerValue3 = "value3"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Create AzureFirewallPolicy
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier "Premium" 

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        
        # Create Application Rules with custom http headers
        $appRule1 = New-AzFirewallPolicyApplicationRule -Name $ruleName1 -Protocol $httpProtocol -SourceAddress $sourceAddress -TargetFqdn $targetFqdn
        Assert-NotNull $appRule1
        $customHeader1 = New-AzFirewallPolicyApplicationRuleCustomHttpHeader -HeaderName $headerName1 -HeaderValue $headerValue1
        Assert-NotNull $customHeader1
        $appRule1.AddCustomHttpHeaderToInsert($customHeader1)

        $appRule2 = New-AzFirewallPolicyApplicationRule -Name $ruleName2 -Protocol $httpsProtocol -SourceAddress $sourceAddress -TargetFqdn $targetFqdn -TerminateTLS
        Assert-NotNull $appRule2
        $customHeader2 = New-AzFirewallPolicyApplicationRuleCustomHttpHeader -HeaderName $headerName2 -HeaderValue $headerValue2
        Assert-NotNull $customHeader2
        $appRule2.AddCustomHttpHeaderToInsert($customHeader2)
        
        $appRule3 = New-AzFirewallPolicyApplicationRule -Name $ruleName3 -Protocol $httpProtocol, $httpsProtocol -SourceAddress $sourceAddress -TargetFqdn $targetFqdn -TerminateTLS
        Assert-NotNull $appRule3
        $customHeader3 = New-AzFirewallPolicyApplicationRuleCustomHttpHeader -HeaderName $headerName3 -HeaderValue $headerValue3
        Assert-NotNull $customHeader3
        $appRule3.AddCustomHttpHeaderToInsert($customHeader3)

        # Create Rule Collection
        $ruleCollection = New-AzFirewallPolicyFilterRuleCollection -Name $rcName -Priority $rcPriority -Rule $appRule1, $appRule2, $appRule3 -ActionType $actionType

        # Create Rule Collection Group
        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $ruleCollection -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count
        
        $getRcg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy
        Assert-AreEqual 1 @($getRcg.properties.ruleCollection).Count        
        $filterRuleCollection = $getRcg.Properties.GetRuleCollectionByName($rcName)
        Assert-AreEqual 3 $filterRuleCollection.Rules.Count

        # Verify application rule 1
        $getAppRule1 = $filterRuleCollection.GetRuleByName($ruleName1)
        Assert-AreEqual 1 $getAppRule1.HttpHeadersToInsert.Count
        Assert-AreEqual $headerName1 $getAppRule1.HttpHeadersToInsert[0].HeaderName
        Assert-AreEqual $headerValue1 $getAppRule1.HttpHeadersToInsert[0].HeaderValue

        # Verify application rule 2
        $getAppRule2 = $filterRuleCollection.GetRuleByName($ruleName2)
        Assert-AreEqual 1 $getAppRule2.HttpHeadersToInsert.Count
        Assert-AreEqual $headerName2 $getAppRule2.HttpHeadersToInsert[0].HeaderName
        Assert-AreEqual $headerValue2 $getAppRule2.HttpHeadersToInsert[0].HeaderValue

        # Verify application rule 2
        $getAppRule3 = $filterRuleCollection.GetRuleByName($ruleName3)
        Assert-AreEqual 1 $getAppRule3.HttpHeadersToInsert.Count
        Assert-AreEqual $headerName3 $getAppRule3.HttpHeadersToInsert[0].HeaderName
        Assert-AreEqual $headerValue3 $getAppRule3.HttpHeadersToInsert[0].HeaderValue
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AzureFirewallPolicySizeProperty {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $location = "westus2"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        
        # Create AzureFirewallPolicy (with no rules, ThreatIntel is in Alert mode by default)
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location 

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        #verification
        Assert-NotNull $getAzureFirewallPolicy.Size
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AzureFirewallPolicyRuleCollectionGroupSizeProperty {
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
    $appRule1Fqdn1 = "*google.com"
    $appRule1Fqdn2 = "*microsoft.com"
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
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier Premium

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        # Create Application Rules
        $appRule = New-AzFirewallPolicyApplicationRule -Name $appRule1Name -Description $appRule1Desc -Protocol $appRule1Protocol1, $appRule1Protocol2 -TargetFqdn $appRule1Fqdn1, $appRule1Fqdn2 -SourceAddress $appRule1SourceAddress1 -TerminateTLS
        
        # Create Filter Rule with 1 application rule
        $appRc = New-AzFirewallPolicyFilterRuleCollection -Name $appRcName -Priority $appRcPriority -Rule $appRule -ActionType $appRcActionType

        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $appRc -FirewallPolicyObject $azureFirewallPolicy

        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        $getRg = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -AzureFirewallPolicy $getAzureFirewallPolicy
        Assert-NotNull $getRg.properties.priority
        Assert-NotNull $getRg.properties.size
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests function Test-AzureFirewallPolicyIDPSProfiles.
#>
function Test-AzureFirewallPolicyIDPSProfiles {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $tier = "Premium"

    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

        # Intrusion Detection Settings
        $sigOverride = New-AzFirewallPolicyIntrusionDetectionSignatureOverride -Id "123456798" -Mode "Deny"
        $intrusionDetection = New-AzFirewallPolicyIntrusionDetection -Mode "Alert" -Profile "Advanced" -SignatureOverride $sigOverride -PrivateRange @("10.0.0.0/8", "172.16.0.0/12")

        # Create AzureFirewallPolicy
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier $tier -IntrusionDetection $intrusionDetection

        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual (Normalize-Location $location) $getAzureFirewallPolicy.Location
        Assert-AreEqual $tier $getAzureFirewallPolicy.Sku.Tier

        # IntrusionDetection verification
        Assert-NotNull $getAzureFirewallPolicy.IntrusionDetection
        Assert-AreEqual "Alert" $getAzureFirewallPolicy.IntrusionDetection.Mode
        Assert-NotNull $getAzureFirewallPolicy.IntrusionDetection.Configuration.SignatureOverrides
        Assert-AreEqual "123456798" $getAzureFirewallPolicy.IntrusionDetection.Configuration.SignatureOverrides[0].Id
        Assert-AreEqual "Deny" $getAzureFirewallPolicy.IntrusionDetection.Configuration.SignatureOverrides[0].Mode
        Assert-AreEqual "Advanced" $getAzureFirewallPolicy.IntrusionDetection.Profile
        
        # Set AzureFirewallPolicy with Standard Profile
        $azureFirewallPolicy.IntrusionDetection.Profile = "Standard"
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName
        Assert-AreEqual "Standard" $getAzureFirewallPolicy.IntrusionDetection.Profile

        # Set AzureFirewallPolicy with Standard Profile
        $azureFirewallPolicy.IntrusionDetection.Profile = "Basic"
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy
        
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName
        Assert-AreEqual "Basic" $getAzureFirewallPolicy.IntrusionDetection.Profile
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
<#
.SYNOPSIS
Tests function Test-AzureFirewallPolicyDraft.
#>
function Test-AzureFirewallPolicyDraft {
    # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "westus2"
    $tier = "Premium"
 
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        # Intrusion Detection Settings
        $intrusionDetection = New-AzFirewallPolicyIntrusionDetection -Mode "Alert"
        # Create AzureFirewallPolicy
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location -SkuTier $tier -IntrusionDetection $intrusionDetection
        # Create AzureFirewallPolicyDraft
        $newAzureFirewallPolicyDraft = New-AzFirewallPolicyDraft -FirewallPolicyObject $azureFirewallPolicy
        # Get AzureFirewallPolicyDraft
        $getAzureFirewallPolicyDraft = Get-AzFirewallPolicyDraft -AzureFirewallPolicyName $azureFirewallPolicyName -ResourceGroupName $rgname
        
        # verification
        Assert-NotNull $getAzureFirewallPolicyDraft.IntrusionDetection
        Assert-AreEqual "Alert" $getAzureFirewallPolicyDraft.IntrusionDetection.Mode
        Assert-Null $getAzureFirewallPolicyDraft.Snat

        # Updated Intrusion Detection Settings
        $intrusionDetection = New-AzFirewallPolicyIntrusionDetection -Mode "Deny"
        $setAzureFirewallPolicy = Set-AzFirewallPolicyDraft -AzureFirewallPolicyName $azureFirewallPolicyName -ResourceGroupName $rgname -IntrusionDetection $intrusionDetection
        # Get AzureFirewallPolicyDraft
        $getAzureFirewallPolicyDraft = Get-AzFirewallPolicyDraft -AzureFirewallPolicyName $azureFirewallPolicyName -ResourceGroupName $rgname
        
        # verification
        Assert-AreEqual "Deny" $getAzureFirewallPolicyDraft.IntrusionDetection.Mode

        # Deploy policy draft
        Deploy-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        # verification
        Assert-NotNull $getAzureFirewallPolicyDraft.IntrusionDetection
        Assert-AreEqual "Deny" $getAzureFirewallPolicyDraft.IntrusionDetection.Mode
    }

    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
 
<#
.SYNOPSIS
Tests function Test-AzureFirewallPolicyRCGDraft.
#>
function Test-AzureFirewallPolicyRCGDraft {
   # Setup
    $rgname = Get-ResourceGroupName
    $azureFirewallPolicyName = Get-ResourceName
    $azureFirewallPolicyAsJobName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/FirewallPolicies"
    $location = "canadacentral"
 
    $ruleGroupName = Get-ResourceName
    $ruleGroupDraftName = Get-ResourceName
 
    # AzureFirewallPolicyNatRuleCollection
    $natRcName = "natRc"
    $natRcName2 = "natRc2"
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
 
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval" }
        # Create AzureFirewallPolicy
        $azureFirewallPolicy = New-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname -Location $location
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        # Create NAT rule
        $natRule = New-AzFirewallPolicyNatRule -Name $natRule1Name -Description $natRule1Desc -Protocol $natRule1Protocol1, $natRule1Protocol2 -SourceAddress $natRule1SourceAddress1, $natRule1SourceAddress2 -DestinationAddress $natRule1DestinationAddress1 -DestinationPort $natRule1DestinationPort1 -TranslatedFqdn $natRule1TranslatedFqdn -TranslatedPort $natRule1TranslatedPort
        # Create a NAT Rule Collection
        $natRc = New-AzFirewallPolicyNatRuleCollection -Name $natRcName -ActionType $natRcActionType -Priority $natRcPriority -Rule $natRule
        New-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -Priority 100 -RuleCollection $natRc -FirewallPolicyObject $azureFirewallPolicy
        # Set AzureFirewallPolicy
        Set-AzFirewallPolicy -InputObject $azureFirewallPolicy

        # Create Policy Draft
        New-AzFirewallPolicyDraft -AzureFirewallPolicyName $azureFirewallPolicyName -ResourceGroupName $rgname
        # Create a NAT Rule Collection
        $natRc2 = New-AzFirewallPolicyNatRuleCollection -Name $natRcName2 -ActionType $natRcActionType -Priority $natRcPriority -Rule $natRule
        # Create RuleCollection Group Draft
        New-AzFirewallPolicyRuleCollectionGroupDraft -AzureFirewallPolicyRuleCollectionGroupName $ruleGroupName -Priority 100 -RuleCollection $natRc2 -FirewallPolicyObject $azureFirewallPolicy
        # Get AzureFirewallPolicy Rule Collection Group draft
        $getAzureFirewallPolicyDraft = Get-AzFirewallPolicyDraft -AzureFirewallPolicyName $azureFirewallPolicyName -ResourceGroupName $rgName
        $getAzureFirewallPolicyRuleCollectionGroupDraft = Get-AzFirewallPolicyRuleCollectionGroupDraft -AzureFirewallPolicyRuleCollectionGroupName $ruleGroupName -FirewallPolicyObject $azureFirewallPolicy
  
        # Verification
        Assert-AreEqual 1 @($getAzureFirewallPolicyRuleCollectionGroupDraft.properties.ruleCollection).Count
        $natRuleCollection = $getAzureFirewallPolicyRuleCollectionGroupDraft.Properties.GetRuleCollectionByName($natRcName2)
 
        # Verify NAT rule collection and NAT rule
        $natRule = $natRuleCollection.GetRuleByName($natRule1Name)
 
        Assert-AreEqual $natRcName2 $natRuleCollection.Name
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
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroupDraft -AzureFirewallPolicyRuleCollectionGroupName $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        $testPipelineRg|Set-AzFirewallPolicyRuleCollectionGroupDraft -Priority $pipelineRcPriority
                
        $testPipelineRg = Get-AzFirewallPolicyRuleCollectionGroupDraft -AzureFirewallPolicyRuleCollectionGroupName $ruleGroupName -AzureFirewallPolicyName $getAzureFirewallPolicy.Name -ResourceGroupName $rgname
        Assert-AreEqual $pipelineRcPriority $testPipelineRg.properties.Priority
 
        $azureFirewallPolicyAsJob = New-AzFirewallPolicy -Name $azureFirewallPolicyAsJobName -ResourceGroupName $rgname -Location $location -AsJob
        $result = $azureFirewallPolicyAsJob | Wait-Job
        Assert-AreEqual "Completed" $result.State
        
        # Deploy policy draft
        Deploy-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgname
        # Get AzureFirewallPolicy
        $getAzureFirewallPolicyRuleCollectionGroup = Get-AzFirewallPolicyRuleCollectionGroup -Name $ruleGroupName -ResourceGroupName $rgname -AzureFirewallPolicyName  $azureFirewallPolicyName
        $getAzureFirewallPolicy = Get-AzFirewallPolicy -Name $azureFirewallPolicyName -ResourceGroupName $rgName

        # verification
        Assert-AreEqual $rgName $getAzureFirewallPolicy.ResourceGroupName
        Assert-AreEqual $azureFirewallPolicyName $getAzureFirewallPolicy.Name
        Assert-NotNull $getAzureFirewallPolicy.Location
        Assert-AreEqual $location $getAzureFirewallPolicy.Location

        # Check rule collection groups count
        Assert-AreEqual 1 @($getAzureFirewallPolicy.RuleCollectionGroups).Count
        Assert-AreEqual 1 @($getAzureFirewallPolicyRuleCollectionGroup.properties.ruleCollection).Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}