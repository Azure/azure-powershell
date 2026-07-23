---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/start-azsignalrreplica
schema: 2.0.0
---

# Start-AzSignalRReplica

## SYNOPSIS
Start a stopped SignalR replica.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Start-AzSignalRReplica [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Start-AzSignalRReplica [-Name] <String> -SignalRObject <PSSignalRResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Start-AzSignalRReplica -InputObject <PSReplicaResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Start-AzSignalRReplica -ResourceId <String> [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Make a replica resource active and starts serving traffic (if its endpoint is enabled). Use this after creating a replica in a stopped state or after maintenance.

## EXAMPLES

### Example 1: Start a replica by name
```powershell
Start-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-dr" -PassThru
```

Starts the replica named "replica-dr" and returns the updated replica object.

### Example 2: Start a replica by resource ID
```powershell
Start-AzSignalRReplica -ResourceId "/subscriptions/{subId}/resourceGroups/myRg/providers/Microsoft.SignalRService/SignalR/mySignalR/replicas/replica-westus2"
```

Starts the specified replica using its resource ID.

### Example 3: Start a replica from a replica object
```powershell
Get-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" | Start-AzSignalRReplica
```

Starts the replica provided through the pipeline.

### Example 4: Start a replica from a SignalR object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myRg" -Name "mySignalR"
$signalr | Start-AzSignalRReplica -Name "replica-dr"
```

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

### -PassThru
Returns true when the command succeeds.

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
