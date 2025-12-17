---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/new-azsignalrreplica
schema: 2.0.0
---

# New-AzSignalRReplica

## SYNOPSIS
Create a new replica for an existing SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
New-AzSignalRReplica [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> -Location <String>
 [-Sku <String>] [-UnitCount <Int32>] [-RegionEndpointEnabled <String>] [-ResourceStopped <String>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
New-AzSignalRReplica [-Name] <String> -SignalRObject <PSSignalRResource> -Location <String> [-Sku <String>]
 [-UnitCount <Int32>] [-RegionEndpointEnabled <String>] [-ResourceStopped <String>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new replica in a different region (or same region if supported) for a Premium tier SignalR service. Replicas are supported only for Premium SKUs (Premium_P1 or Premium_P2) and can be used for geo-distribution, disaster recovery, or traffic latency optimization.

## EXAMPLES

### Example 1: Create a replica in West US 2
```powershell
New-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" -Location "West US 2" -Sku Premium_P1 -UnitCount 2
```

Creates a replica named "replica-westus2" in West US 2 with 2 units using Premium_P1.

### Example 2: Create a replica using a SignalR object from the pipeline
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myRg" -Name "mySignalR"
$signalr | New-AzSignalRReplica -Name "replica-eastus2" -Location "East US 2" -Sku Premium_P1
```

Creates a replica in East US 2 by piping the primary SignalR resource.

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

### -Location
The location where the replica will be created.

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
The replica name.

```yaml
Type: System.String
Parameter Sets: (All)
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
Default is 'Enabled'.

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

### -ResourceStopped
Stop or start the resource.
Valid values are 'true' and 'false'.
Default is 'false'.

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
The SKU of the SignalR replica.
Default is Premium_P1.
Only Premium_P1, Premium_P2 are supported.

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

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSReplicaResource

## NOTES

## RELATED LINKS
