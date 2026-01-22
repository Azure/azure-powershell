---
external help file:
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
 [-VirtualNetworkArmResourceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### List
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String>
 -Parameter <IVirtualNetworkSubnetUsageParameter> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String> -JsonFilePath <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -LocationName <String> -JsonString <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Lists the virtual network subnet usage for a given virtual network.

## EXAMPLES

### Example 1: Get subnet usage for a virtual network
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -Location "East US" -VirtualNetworkArmResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVNet"
```

```output
SubnetName        : database-subnet
UsedIPAddresses   : 5
TotalIPAddresses  : 254
AvailableIPAddresses : 249
Description       : Subnet usage for PostgreSQL Flexible Servers

SubnetName        : application-subnet
UsedIPAddresses   : 12
TotalIPAddresses  : 254
AvailableIPAddresses : 242
Description       : Subnet usage for PostgreSQL Flexible Servers
```

Retrieves subnet usage information for PostgreSQL Flexible Servers in the specified virtual network.

### Example 2: Get usage for a specific subnet
```powershell
Get-AzPostgreSqlFlexibleServerVirtualNetworkSubnetUsage -Location "West Europe" -VirtualNetworkArmResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/production-rg/providers/Microsoft.Network/virtualNetworks/prod-vnet" -SubnetArmResourceId "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/production-rg/providers/Microsoft.Network/virtualNetworks/prod-vnet/subnets/database-subnet"
```

```output
SubnetName        : database-subnet
UsedIPAddresses   : 8
TotalIPAddresses  : 62
AvailableIPAddresses : 54
Description       : Subnet usage for PostgreSQL Flexible Servers in production
```

Retrieves usage information for a specific subnet used by PostgreSQL Flexible Servers.

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

