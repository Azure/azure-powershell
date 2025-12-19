---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/update-azsignalrreplica
schema: 2.0.0
---

# Update-AzSignalRReplica

## SYNOPSIS
Update properties of a SignalR replica.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Update-AzSignalRReplica [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> [-Sku <String>]
 [-UnitCount <Int32>] [-RegionEndpointEnabled <String>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Update-AzSignalRReplica [-Name] <String> -SignalRObject <PSSignalRResource> [-Sku <String>]
 [-UnitCount <Int32>] [-RegionEndpointEnabled <String>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzSignalRReplica -InputObject <PSReplicaResource> [-Sku <String>] [-UnitCount <Int32>]
 [-RegionEndpointEnabled <String>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzSignalRReplica -ResourceId <String> [-Sku <String>] [-UnitCount <Int32>]
 [-RegionEndpointEnabled <String>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates mutable properties on an existing replica including SKU, unit count (capacity), regional endpoint state, and tags. Only Premium SKUs are allowed.

## EXAMPLES

### Example 1: Scale a replica from 2 to 5 units
```powershell
Update-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" -UnitCount 5
```

Increases the capacity of the replica to 5 units.

### Example 2: Disable the regional endpoint
```powershell
Update-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" -RegionEndpointEnabled Disabled
```

Temporarily disables the replica's endpoint.

### Example 3: Change SKU and scale
```powershell
Update-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" -Sku Premium_P2 -UnitCount 200
```

Moves the replica to Premium_P2 SKU with capacity 200.

### Example 4: Update tags from a replica object
```powershell
Get-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" | Update-AzSignalRReplica -Tag @{ Environment = "Prod"; Owner = "Ops" }
```

Adds or updates tags on the replica.

## PARAMETERS

### -AsJob
Run the cmdlet in background job.

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

### -InputObject
The SignalR replica resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSReplicaResource
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The replica name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet, InputSignalRObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegionEndpointEnabled
Enable or disable the regional endpoint.
Valid values are 'Enabled' and 'Disabled'.

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
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of the replica.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SignalRName
The SignalR service name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalRObject
The SignalR resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource
Parameter Sets: InputSignalRObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Sku
The SignalR replica service SKU.

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
The tags for the SignalR replica.

```yaml
Type: System.Collections.Generic.IDictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnitCount
The SignalR replica unit count.
For Premium_P1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100.
Default to 1.
For Premium_P2: 100,200,300,400,500,600,700,800,900,1000

```yaml
Type: System.Nullable`1[System.Int32]
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

### Microsoft.Azure.Commands.SignalR.Models.PSReplicaResource

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSReplicaResource

## NOTES

## RELATED LINKS
