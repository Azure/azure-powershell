---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/restore-azscvmmvmcheckpoint
schema: 2.0.0
---

# Restore-AzScVmmVMCheckpoint

## SYNOPSIS
Restores to a checkpoint in virtual machine.

## SYNTAX

### RestoreExpanded (Default)
```
Restore-AzScVmmVMCheckpoint -Name <String> -ResourceGroupName <String> -CheckpointId <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Restore
```
Restore-AzScVmmVMCheckpoint -Name <String> -ResourceGroupName <String>
 -Body <IVirtualMachineRestoreCheckpoint> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaJsonFilePath
```
Restore-AzScVmmVMCheckpoint -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaJsonString
```
Restore-AzScVmmVMCheckpoint -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Restores to a checkpoint in virtual machine.

## EXAMPLES

### Example 1: Restore a VM Checkpoint
```powershell
Restore-AzScVmmVMCheckpoint -Name "test-vm" -ResourceGroupName "test-rg-01" -CheckpointId "00000000-abcd-0000-abcd-000000000000"
```

Restore a VM Checkpoint with given `CheckpointId`.
To get the list of available checkpoints and their Id, do a get VM operation using `Get-AzScVmmVM`.

### Example 2: Restore a VM Checkpoint
```powershell
$CheckpointProperties = '{
    "id": "00000000-abcd-0000-abcd-000000000000"
}'
Restore-AzScVmmVMCheckpoint -Name "test-vm" -ResourceGroupName "test-rg-01" -JsonString $CheckpointProperties
```

Restore a VM Checkpoint with given `CheckpointId`.
To get the list of available checkpoints and their Id, do a get VM operation using `Get-AzScVmmVM`.

## PARAMETERS

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

### -Body
Defines the restore checkpoint action properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineRestoreCheckpoint
Parameter Sets: Restore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CheckpointId
ID of the checkpoint to be restored to.

```yaml
Type: System.String
Parameter Sets: RestoreExpanded
Aliases:

Required: True
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

### -JsonFilePath
Path of Json file supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VMName

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

### -PassThru
Returns true when the command succeeds

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
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineRestoreCheckpoint

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

