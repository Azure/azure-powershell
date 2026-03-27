---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/remove-azsignalrreplica
schema: 2.0.0
---

# Remove-AzSignalRReplica

## SYNOPSIS
Delete a SignalR replica resource.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Remove-AzSignalRReplica [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> [-PassThru]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Remove-AzSignalRReplica [-Name] <String> -SignalRObject <PSSignalRResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzSignalRReplica -ResourceId <String> [-PassThru] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzSignalRReplica -InputObject <PSReplicaResource> [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Removes a specified replica from a SignalR service. This action is irreversible; the replica and its regional capacity are released. The primary SignalR resource remains unaffected.

## EXAMPLES

### Example 1: Remove a replica by name
```powershell
Remove-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-westus2" -PassThru
```

Deletes the replica named "replica-westus2" and returns `True` on success.

### Example 2: Remove a replica by resource ID
```powershell
Remove-AzSignalRReplica -ResourceId "/subscriptions/{subId}/resourceGroups/myRg/providers/Microsoft.SignalRService/SignalR/mySignalR/replicas/replica-westus2"
```

Deletes the specified replica using its full resource ID.

### Example 3: Remove a replica from a replica object
```powershell
Get-AzSignalRReplica -ResourceGroupName "myRg" -SignalRName "mySignalR" -Name "replica-dr" | Remove-AzSignalRReplica -PassThru
```

Pipes the replica object into the removal cmdlet.

### Example 4: Remove a replica from a SignalR object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myRg" -Name "mySignalR"
$signalr | Remove-AzSignalRReplica -Name "replica-eastus2"
```

Removes the specified replica by piping the primary SignalR resource.

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
The replica resource object.

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
The resource ID of a replica

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

### System.String

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

### Microsoft.Azure.Commands.SignalR.Models.PSReplicaResource

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
