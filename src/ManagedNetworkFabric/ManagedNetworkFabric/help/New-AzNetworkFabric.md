---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabric
schema: 2.0.0
---

# New-AzNetworkFabric

## SYNOPSIS
Create Network Fabric resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -FabricAsn <Int64>
 -Ipv4Prefix <String> -Location <String>
 -ManagementNetworkConfiguration <IManagementNetworkConfigurationProperties>
 -NetworkFabricControllerId <String> -NetworkFabricSku <String> -ServerCountPerRack <Int32>
 -TerminalServerConfiguration <ITerminalServerConfiguration> [-Annotation <String>] [-Ipv6Prefix <String>]
 [-RackCount <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create Network Fabric resource.

## EXAMPLES

### EXAMPLE 1
```
$managementNetworkConfiguration = @{
    InfrastructureVpnConfigurationPeeringOption = "OptionB"
    WorkloadVpnConfigurationPeeringOption = "OptionB"
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget = @("65046:10039")
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget = @("65046:10039")
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget = @("65046:10039")
    InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget = @("65046:10039")
    WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget = @("65046:10039")
}
```

$terminalServerConfiguration = @{
    UserName = "username"
    Password = "password"
    SerialNumber = "2351"
    PrimaryIpv4Prefix = "172.31.0.0/30"
    SecondaryIpv4Prefix = "172.31.0.20/30"
}

New-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName -Location $location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $nfcId -NetworkFabricSku "fab1" -ServerCountPerRack 5 -RackCount 2 -FabricAsn 30 -Ipv4Prefix "20.1.0.0/19" -TerminalServerConfiguration $terminalServerConfiguration

### EXAMPLE 2
```
$managementNetworkConfiguration = @{
    InfrastructureVpnConfigurationPeeringOption = "OptionA"
    WorkloadVpnConfigurationPeeringOption = "OptionA"
    InfrastructureVpnConfigurationOptionAPropertiesBfdConfigurationIntervalInMilliSecond = 300
    InfrastructureVpnConfigurationOptionAPropertiesBfdConfigurationMultiplier = 3
    InfrastructureVpnConfigurationOptionAPropertiesMtu = 1500
    InfrastructureVpnConfigurationOptionAPropertiesPeerAsn = 28
    InfrastructureVpnConfigurationOptionAPropertiesVlanId = 501
    InfrastructureVpnConfigurationOptionAPropertiesPrimaryIpv4Prefix = "10.0.0.14/30"
    InfrastructureVpnConfigurationOptionAPropertiesSecondaryIpv4Prefix = "10.0.0.14/30"
    WorkloadVpnConfigurationOptionAPropertiesBfdConfigurationIntervalInMilliSecond = 300
    WorkloadVpnConfigurationOptionAPropertiesBfdConfigurationMultiplier = 3
    WorkloadVpnConfigurationOptionAPropertiesMtu = 1500
    WorkloadVpnConfigurationOptionAPropertiesPeerAsn = 28
    WorkloadVpnConfigurationOptionAPropertiesVlanId = 501
    WorkloadVpnConfigurationOptionAPropertiesPrimaryIpv4Prefix = "10.0.0.14/30"
    WorkloadVpnConfigurationOptionAPropertiesSecondaryIpv4Prefix = "10.0.0.14/30"
}
```

$terminalServerConfiguration = @{
    UserName = "username"
    Password = "password"
    SerialNumber = "2351"
    PrimaryIpv4Prefix = "172.31.0.0/30"
    SecondaryIpv4Prefix = "172.31.0.20/30"
}

New-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName -Location $location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $nfcId -NetworkFabricSku "fab1" -ServerCountPerRack 5 -RackCount 2 -FabricAsn 30 -Ipv4Prefix "20.1.0.0/19" -TerminalServerConfiguration $terminalServerConfiguration

## PARAMETERS

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricAsn
ASN of CE devices for CE/PE connectivity.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv4Prefix
IPv4Prefix for Management Network.
Example: 10.1.0.0/19.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6Prefix
IPv6Prefix for Management Network.
Example: 3FFE:FFFF:0:CD40::/59

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementNetworkConfiguration
Configuration to be used to setup the management network.
To construct, see NOTES section for MANAGEMENTNETWORKCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagementNetworkConfigurationProperties
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Network Fabric.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkFabricName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricControllerId
Azure resource ID for the NetworkFabricController the NetworkFabric belongs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricSku
Supported Network Fabric SKU.Example: Compute / Aggregate racks.
Once the user chooses a particular SKU, only supported racks can be added to the Network Fabric.
The SKU determines whether it is a single / multi rack Network Fabric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -RackCount
Number of compute racks associated to Network Fabric.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerCountPerRack
Number of servers.Possible values are from 1-16.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TerminalServerConfiguration
Network and credentials configuration currently applied to terminal server.
To construct, see NOTES section for TERMINALSERVERCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ITerminalServerConfiguration
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkFabric
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

MANAGEMENTNETWORKCONFIGURATION \<IManagementNetworkConfigurationProperties\>: Configuration to be used to setup the management network.
  InfrastructureVpnConfigurationPeeringOption \<String\>: Peering option list.
  WorkloadVpnConfigurationPeeringOption \<String\>: Peering option list.
  \[InfrastructureVpnConfigurationNetworkToNetworkInterconnectId \<String\>\]: ARM Resource ID of the Network To Network Interconnect.
  \[InfrastructureVpnConfigurationOptionAPropertiesBfdConfigurationIntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
  \[InfrastructureVpnConfigurationOptionAPropertiesBfdConfigurationMultiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
  \[InfrastructureVpnConfigurationOptionAPropertiesMtu \<Int32?\>\]: MTU to use for option A peering.
  \[InfrastructureVpnConfigurationOptionAPropertiesPeerAsn \<Int64?\>\]: Peer ASN number.Example : 28
  \[InfrastructureVpnConfigurationOptionAPropertiesPrimaryIpv4Prefix \<String\>\]: IPv4 Address Prefix.
  \[InfrastructureVpnConfigurationOptionAPropertiesPrimaryIpv6Prefix \<String\>\]: IPv6 Address Prefix.
  \[InfrastructureVpnConfigurationOptionAPropertiesSecondaryIpv4Prefix \<String\>\]: Secondary IPv4 Address Prefix.
  \[InfrastructureVpnConfigurationOptionAPropertiesSecondaryIpv6Prefix \<String\>\]: Secondary IPv6 Address Prefix.
  \[InfrastructureVpnConfigurationOptionAPropertiesVlanId \<Int32?\>\]: Vlan Id.Example : 501
  \[InfrastructureVpnConfigurationOptionBPropertiesExportRouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes from CE.
This is for backward compatibility.
  \[InfrastructureVpnConfigurationOptionBPropertiesImportRouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes into CE.
This is for backward compatibility.
  \[InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes into CE.
  \[InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes from CE.
  \[InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes into CE.
  \[InfrastructureVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes from CE.
  \[WorkloadVpnConfigurationNetworkToNetworkInterconnectId \<String\>\]: ARM Resource ID of the Network To Network Interconnect.
  \[WorkloadVpnConfigurationOptionAPropertiesBfdConfigurationIntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
  \[WorkloadVpnConfigurationOptionAPropertiesBfdConfigurationMultiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
  \[WorkloadVpnConfigurationOptionAPropertiesMtu \<Int32?\>\]: MTU to use for option A peering.
  \[WorkloadVpnConfigurationOptionAPropertiesPeerAsn \<Int64?\>\]: Peer ASN number.Example : 28
  \[WorkloadVpnConfigurationOptionAPropertiesPrimaryIpv4Prefix \<String\>\]: IPv4 Address Prefix.
  \[WorkloadVpnConfigurationOptionAPropertiesPrimaryIpv6Prefix \<String\>\]: IPv6 Address Prefix.
  \[WorkloadVpnConfigurationOptionAPropertiesSecondaryIpv4Prefix \<String\>\]: Secondary IPv4 Address Prefix.
  \[WorkloadVpnConfigurationOptionAPropertiesSecondaryIpv6Prefix \<String\>\]: Secondary IPv6 Address Prefix.
  \[WorkloadVpnConfigurationOptionAPropertiesVlanId \<Int32?\>\]: Vlan Id.Example : 501
  \[WorkloadVpnConfigurationOptionBPropertiesExportRouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes from CE.
This is for backward compatibility.
  \[WorkloadVpnConfigurationOptionBPropertiesImportRouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes into CE.
This is for backward compatibility.
  \[WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes into CE.
  \[WorkloadVpnConfigurationOptionBPropertiesRouteTargetsExportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes from CE.
  \[WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes into CE.
  \[WorkloadVpnConfigurationOptionBPropertiesRouteTargetsImportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes from CE.

TERMINALSERVERCONFIGURATION \<ITerminalServerConfiguration\>: Network and credentials configuration currently applied to terminal server.
  \[Password \<String\>\]: Password for the terminal server connection.
  \[SerialNumber \<String\>\]: Serial Number of Terminal server.
  \[Username \<String\>\]: Username for the terminal server connection.
  \[PrimaryIpv4Prefix \<String\>\]: IPv4 Address Prefix.
  \[PrimaryIpv6Prefix \<String\>\]: IPv6 Address Prefix.
  \[SecondaryIpv4Prefix \<String\>\]: Secondary IPv4 Address Prefix.
  \[SecondaryIpv6Prefix \<String\>\]: Secondary IPv6 Address Prefix.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabric](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabric)

