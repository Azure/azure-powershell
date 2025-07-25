---
external help file:
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
New-AzNetworkFabric -Name <String> -ResourceGroupName <String> -FabricAsn <Int64> -Ipv4Prefix <String>
 -Location <String> -ManagementNetworkConfiguration <IManagementNetworkConfigurationProperties>
 -NetworkFabricControllerId <String> -NetworkFabricSku <String> -ServerCountPerRack <Int32>
 -TerminalServerConfiguration <ITerminalServerConfiguration> [-SubscriptionId <String>] [-Annotation <String>]
 [-Ipv6Prefix <String>] [-RackCount <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabric -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabric -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create Network Fabric resource.

## EXAMPLES

### Example 1: Create the Network Fabric Resource
```powershell
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

$terminalServerConfiguration = @{
    UserName = "username"
    Password = "password"
    SerialNumber = "2351"
    PrimaryIpv4Prefix = "172.31.0.0/30"
    SecondaryIpv4Prefix = "172.31.0.20/30"
}

New-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName -Location $location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $nfcId -NetworkFabricSku "fab1" -ServerCountPerRack 5 -RackCount 2 -FabricAsn 30 -Ipv4Prefix "20.1.0.0/19" -TerminalServerConfiguration $terminalServerConfiguration
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                                                  /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the Network Fabric resource with Option B Properties.

### Example 2: Create the Network Fabric Resource
```powershell
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

$terminalServerConfiguration = @{
    UserName = "username"
    Password = "password"
    SerialNumber = "2351"
    PrimaryIpv4Prefix = "172.31.0.0/30"
    SecondaryIpv4Prefix = "172.31.0.20/30"
}

New-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName -Location $location -ManagementNetworkConfiguration $managementNetworkConfiguration -NetworkFabricControllerId $nfcId -NetworkFabricSku "fab1" -ServerCountPerRack 5 -RackCount 2 -FabricAsn 30 -Ipv4Prefix "20.1.0.0/19" -TerminalServerConfiguration $terminalServerConfiguration
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                                                  /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the Network Fabric resource with Option A Properties.

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
Default value: None
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
Default value: None
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
Default value: None
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
Default value: None
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
Default value: (Get-AzContext).Subscription.Id
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

## RELATED LINKS

