---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/update-aznetworkfabricl3isolationdomain
schema: 2.0.0
---

# Update-AzNetworkFabricL3IsolationDomain

## SYNOPSIS
Update isolation domain resources for layer 3 connectivity between compute nodes and for communication with external services .This configuration is applied on the devices only after the creation of networks is completed and isolation domain is enabled.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFabricL3IsolationDomain -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AggregateRouteConfiguration <IAggregateRouteConfiguration>] [-Annotation <String>]
 [-ConnectedSubnetRoutePolicy <IConnectedSubnetRoutePolicy>] [-EnableSystemAssignedIdentity <Boolean>]
 [-ExportPolicyConfigurationExportPolicy <String[]>] [-RedistributeConnectedSubnet <String>]
 [-RedistributeStaticRoute <String>] [-StaticRoutePolicyExportRoutePolicy <IL3ExportRoutePolicy>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-V4RoutePrefixLimitHardLimit <Int32>]
 [-V4RoutePrefixLimitThreshold <Int32>] [-V6RoutePrefixLimitHardLimit <Int32>]
 [-V6RoutePrefixLimitThreshold <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFabricL3IsolationDomain -InputObject <IManagedNetworkFabricIdentity>
 [-AggregateRouteConfiguration <IAggregateRouteConfiguration>] [-Annotation <String>]
 [-ConnectedSubnetRoutePolicy <IConnectedSubnetRoutePolicy>] [-EnableSystemAssignedIdentity <Boolean>]
 [-ExportPolicyConfigurationExportPolicy <String[]>] [-RedistributeConnectedSubnet <String>]
 [-RedistributeStaticRoute <String>] [-StaticRoutePolicyExportRoutePolicy <IL3ExportRoutePolicy>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-V4RoutePrefixLimitHardLimit <Int32>]
 [-V4RoutePrefixLimitThreshold <Int32>] [-V6RoutePrefixLimitHardLimit <Int32>]
 [-V6RoutePrefixLimitThreshold <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update isolation domain resources for layer 3 connectivity between compute nodes and for communication with external services .This configuration is applied on the devices only after the creation of networks is completed and isolation domain is enabled.

## EXAMPLES

### Example 1: Update the L3 Isolation Domain
```powershell
Update-AzNetworkFabricL3IsolationDomain -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/example-l3domain
```

This command updates the properties of the given L3 Isolation Domain.

## PARAMETERS

### -AggregateRouteConfiguration
Aggregate route configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IAggregateRouteConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Annotation
Switch configuration description.

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

### -ConnectedSubnetRoutePolicy
Connected Subnet RoutePolicy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnetRoutePolicy
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportPolicyConfigurationExportPolicy
Export Policy for the BGP Monitoring Protocol (BMP) Configuration.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the L3 Isolation Domain.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: L3IsolationDomainName

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

### -RedistributeConnectedSubnet
Advertise Connected Subnets.
Ex: "True" | "False".

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

### -RedistributeStaticRoute
Advertise Static Routes.
Ex: "True" | "False".

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRoutePolicyExportRoutePolicy
Array of ARM Resource ID of the RoutePolicies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IL3ExportRoutePolicy
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -V4RoutePrefixLimitHardLimit
Hard limit for the routes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -V4RoutePrefixLimitThreshold
Threshold for the routes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -V6RoutePrefixLimitHardLimit
Hard limit for the routes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -V6RoutePrefixLimitThreshold
Threshold for the routes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IL3IsolationDomain

## NOTES

## RELATED LINKS
