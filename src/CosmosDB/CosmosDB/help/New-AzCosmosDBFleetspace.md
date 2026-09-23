---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbfleetspace
schema: 2.0.0
---

# New-AzCosmosDBFleetspace

## SYNOPSIS
Creates a new Azure Cosmos DB Fleetspace within a Fleet.

## SYNTAX

### ByNameParameterSet (Default)
```
New-AzCosmosDBFleetspace -ResourceGroupName <String> -FleetName <String> -Name <String>
 -FleetspaceApiKind <String> -ServiceTier <String> -DataRegions <String[]>
 [-ThroughputPoolMinThroughput <Int32>] [-ThroughputPoolMaxThroughput <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzCosmosDBFleetspace -ParentObject <PSFleetGetResults> -Name <String> -FleetspaceApiKind <String>
 -ServiceTier <String> -DataRegions <String[]> [-ThroughputPoolMinThroughput <Int32>]
 [-ThroughputPoolMaxThroughput <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCosmosDBFleetspace** cmdlet creates a new Fleetspace within an Azure Cosmos DB Fleet. A Fleetspace represents a logical workspace that groups database accounts with shared configuration and throughput settings.

## EXAMPLES

### Example 1: Create a NoSQL Fleetspace with General Purpose tier
```powershell
New-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace" `
    -FleetspaceApiKind "NoSQL" -ServiceTier "GeneralPurpose" -DataRegion @("eastus", "westus")
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name              : myFleetspace
Type              : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind : NoSQL
ServiceTier       : GeneralPurpose
DataRegions       : {eastus, westus}
ProvisioningState : Succeeded
```

Creates a new Fleetspace for NoSQL API with General Purpose service tier in two regions.

### Example 2: Create a Fleetspace with throughput pool configuration
```powershell
New-AzCosmosDBFleetspace -ResourceGroupName "myResourceGroup" -FleetName "myFleet" -Name "myFleetspace" `
    -FleetspaceApiKind "NoSQL" -ServiceTier "BusinessCritical" -DataRegion @("eastus") `
    -ThroughputPoolMinThroughput 1000 -ThroughputPoolMaxThroughput 10000
```

```output
Id                              : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name                            : myFleetspace
Type                            : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind               : NoSQL
ServiceTier                     : BusinessCritical
DataRegions                     : {eastus}
ThroughputPoolMinThroughput     : 1000
ThroughputPoolMaxThroughput     : 10000
ProvisioningState               : Succeeded
```

Creates a Fleetspace with Business Critical tier and configured throughput pool limits.

### Example 3: Create a Fleetspace using parent Fleet object
```powershell
$fleet = Get-AzCosmosDBFleet -ResourceGroupName "myResourceGroup" -Name "myFleet"
$fleet | New-AzCosmosDBFleetspace -Name "myFleetspace" -FleetspaceApiKind "NoSQL" `
    -ServiceTier "GeneralPurpose" -DataRegion @("eastus")
```

```output
Id                : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.DocumentDB/fleets/myFleet/fleetspaces/myFleetspace
Name              : myFleetspace
Type              : Microsoft.DocumentDB/fleets/fleetspaces
FleetspaceApiKind : NoSQL
ServiceTier       : GeneralPurpose
DataRegions       : {eastus}
ProvisioningState : Succeeded
```

Creates a Fleetspace using a Fleet object from the pipeline.

## PARAMETERS

### -DataRegion
Array of Azure regions where the Fleetspace data will be replicated.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -FleetspaceApiKind
The API kind for the Fleetspace. Currently supports: NoSQL.

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

### -Name
Name of the Fleetspace. Must be unique within the Fleet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FleetspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Fleet object representing the parent Fleet.

```yaml
Type: Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ServiceTier
The service tier for the Fleetspace. Valid values: GeneralPurpose, BusinessCritical.

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

### -ThroughputPoolMaxThroughput
Maximum throughput (RU/s) for the throughput pool. Optional.

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
Minimum throughput (RU/s) for the throughput pool. Optional.

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

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetGetResults

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSFleetspaceGetResults

## NOTES

## RELATED LINKS

[Get-AzCosmosDBFleetspace](./Get-AzCosmosDBFleetspace.md)

[Update-AzCosmosDBFleetspace](./Update-AzCosmosDBFleetspace.md)

[Remove-AzCosmosDBFleetspace](./Remove-AzCosmosDBFleetspace.md)
