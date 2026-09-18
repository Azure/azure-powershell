---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/update-azcosmosdbfleetspace
schema: 2.0.0
---

# Update-AzCosmosDBFleetspace

## SYNOPSIS
Updates an Azure Cosmos DB Fleetspace.

## SYNTAX

### ByNameParameterSet (Default)
```
Update-AzCosmosDBFleetspace -ResourceGroupName <String> -FleetName <String> -Name <String>
 [-ThroughputPoolMinThroughput <Int32>] [-ThroughputPoolMaxThroughput <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzCosmosDBFleetspace -InputObject <PSFleetspaceGetResults> [-ThroughputPoolMinThroughput <Int32>]
 [-ThroughputPoolMaxThroughput <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzCosmosDBFleetspace** cmdlet updates properties of an existing Azure Cosmos DB Fleetspace, specifically the throughput pool configuration settings.

## EXAMPLES

### Example 1: Update Fleetspace throughput pool configuration
```powershell
Update-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace" `
    -ThroughputPoolMinThroughput 2000 -ThroughputPoolMaxThroughput 20000
```

```output
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name                            : myFleetspace
Type                            : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind               : NoSQL
ServiceTier                     : BusinessCritical
DataRegions                     : {eastus}
ThroughputPoolMinThroughput     : 2000
ThroughputPoolMaxThroughput     : 20000
ProvisioningState               : Succeeded
```

Updates the throughput pool limits for the specified Fleetspace.

### Example 2: Update only minimum throughput
```powershell
Update-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace" `
    -ThroughputPoolMinThroughput 1500
```

```output
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name                            : myFleetspace
Type                            : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind               : NoSQL
ServiceTier                     : GeneralPurpose
DataRegions                     : {eastus}
ThroughputPoolMinThroughput     : 1500
ThroughputPoolMaxThroughput     : 10000
ProvisioningState               : Succeeded
```

Updates only the minimum throughput setting.

### Example 3: Update Fleetspace using pipeline input
```powershell
$fleetspace = Get-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace"
$fleetspace | Update-AzCosmosDBFleetspace -ThroughputPoolMaxThroughput 15000
```

```output
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name                            : myFleetspace
Type                            : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind               : NoSQL
ServiceTier                     : BusinessCritical
DataRegions                     : {eastus}
ThroughputPoolMinThroughput     : 1000
ThroughputPoolMaxThroughput     : 15000
ProvisioningState               : Succeeded
```

Gets a Fleetspace object and updates it using pipeline input.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FleetName
Name of the parent Fleet.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Fleetspace object to update.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Fleetspace to update.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases: FleetspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: ByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThroughputPoolMaxThroughput
Maximum throughput (RU/s) for the throughput pool.

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

### -ThroughputPoolMinThroughput
Minimum throughput (RU/s) for the throughput pool.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults

## NOTES

## RELATED LINKS

[New-AzCosmosDBFleetspace](./New-AzCosmosDBFleetspace.md)

[Get-AzCosmosDBFleetspace](./Get-AzCosmosDBFleetspace.md)

[Remove-AzCosmosDBFleetspace](./Remove-AzCosmosDBFleetspace.md)
