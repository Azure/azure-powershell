---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/stop-azsignalrreplica
schema: 2.0.0
---

# Stop-AzSignalRReplica

## SYNOPSIS
Stop (disable) a running SignalR replica.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Stop-AzSignalRReplica [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Stop-AzSignalRReplica [-Name] <String> -SignalRObject <PSSignalRResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Stop-AzSignalRReplica -InputObject <PSReplicaResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Stop-AzSignalRReplica -ResourceId <String> [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Sets `ResourceStopped` to `true` for a replica so it no longer serves traffic. Use this to temporarily remove a replica from rotation without deleting it (so it can later be restarted with Start-AzSignalRReplica).

## EXAMPLES

### Example 1: Stop a replica by name
```powershell
Stop-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-dr"
```

Stops the replica named "replica-dr".

### Example 2: Stop a replica from a replica object
```powershell
Get-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" | Stop-AzSignalRReplica
```

Stops the specified replica using pipeline input.

### Example 3: Stop a replica by resource ID
```powershell
Stop-AzSignalRReplica -ResourceId "/subscriptions/{subId}/resourceGroups/myRg/providers/Microsoft.SignalRService/SignalR/mySignalR/replicas/replica-westus2"
```

Stops the specified replica using its resource ID.

### Example 4: Stop a replica from a SignalR resource object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myRg" -Name "mySignalR"
$signalr | Stop-AzSignalRReplica -Name "replica-westus2"
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
