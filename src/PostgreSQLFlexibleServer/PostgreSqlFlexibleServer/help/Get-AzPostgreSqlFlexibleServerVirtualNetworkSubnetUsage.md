---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservervirtualnetworksubnetusage
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage

## SYNOPSIS
Lists the virtual network subnet usage for a given virtual network.

## SYNTAX

### ListExpanded (Default)
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String> [-SubscriptionId <String[]>]
 [-VirtualNetworkArmResourceId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String> [-SubscriptionId <String[]>]
 -Parameter <IVirtualNetworkSubnetUsageParameter> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String> [-SubscriptionId <String[]>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String> [-SubscriptionId <String[]>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Lists the virtual network subnet usage for a given virtual network.

## EXAMPLES

### Example 1: Check subnet usage for PostgreSQL Flexible Server deployment
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName "East US" -VirtualNetworkResourceId "/subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/network-rg/providers/Microsoft.Network/virtualNetworks/my-vnet" -SubnetName "postgresql-subnet"
```

```output
SubscriptionId         : ssssssss-ssss-ssss-ssss-ssssssssssss
VirtualNetworkResourceId: /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/network-rg/providers/Microsoft.Network/virtualNetworks/my-vnet
SubnetName            : postgresql-subnet
Usage                 : 2
Available             : 251
```

Checks how many IP addresses are currently used and available in the specified subnet for PostgreSQL Flexible Server deployments.

### Example 2: Verify subnet capacity before server deployment
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName "West Europe" -VirtualNetworkResourceId "/subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/production-network/providers/Microsoft.Network/virtualNetworks/prod-vnet" -SubnetName "database-subnet"
```

```output
SubscriptionId         : ssssssss-ssss-ssss-ssss-ssssssssssss
VirtualNetworkResourceId: /subscriptions/ssssssss-ssss-ssss-ssss-ssssssssssss/resourceGroups/production-network/providers/Microsoft.Network/virtualNetworks/prod-vnet
SubnetName            : database-subnet
Usage                 : 0
Available             : 256
```

Verifies that the production subnet has sufficient IP addresses available before deploying new PostgreSQL Flexible Servers with private access.

## PARAMETERS

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

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationName
The name of the location.

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

### -Parameter
Virtual network subnet usage parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageParameter
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkArmResourceId
Virtual network resource id.

```yaml
Type: System.String
Parameter Sets: ListExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageParameter

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageModel

## NOTES

## RELATED LINKS
