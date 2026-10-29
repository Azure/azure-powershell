---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/remove-azsnapshotimmutabilitypolicy
schema: 2.0.0
---

# Remove-AzSnapshotImmutabilityPolicy

## SYNOPSIS
Expires an active Unlocked immutability policy on a managed disk snapshot.

## SYNTAX

```
Remove-AzSnapshotImmutabilityPolicy -Name <String> -ResourceGroupName <String> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-AzSnapshotImmutabilityPolicy -ResourceId <String> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]

Remove-AzSnapshotImmutabilityPolicy -InputObject <PSSnapshot> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet expires an active Unlocked policy without deleting the snapshot. An absent, expired, or Locked policy cannot be removed. The policy action requires `Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action` and snapshot read permission. The command returns a snapshot after reading back and verifying the expired policy state.

## EXAMPLES

### Example 1: Remove an Unlocked policy from a snapshot object
```powershell
$snapshot = Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01"
$snapshot = Remove-AzSnapshotImmutabilityPolicy -InputObject $snapshot
$snapshot.ImmutabilityPolicy | Format-List
```

This expires the snapshot's active Unlocked policy and displays the persisted state.

### Example 2: Preview policy removal
```powershell
Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" |
    Remove-AzSnapshotImmutabilityPolicy -WhatIf
```

The administrative policy action is required when executing the command.

### Example 3: Use a snapshot resource ID
```powershell
Remove-AzSnapshotImmutabilityPolicy -ResourceId "/subscriptions/<subscription-id>/resourceGroups/rg-backup/providers/Microsoft.Compute/snapshots/snapshot-01"
```

This removes protection from the identified snapshot in the current subscription context.

## PARAMETERS

### -AsJob
Run the cmdlet in the background. The job's output is a verified `PSSnapshot`.

### -Confirm
Prompts you for confirmation before running the cmdlet.

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

### -Force
Suppresses the additional confirmation prompt. It does not override retention restrictions or role-based access control permissions.

### -InputObject
The snapshot object whose policy will be removed. The cmdlet uses its resource ID to identify the snapshot and reads its current state from Azure.

### -Name
The snapshot name. `SnapshotName` is an alias.

### -ResourceGroupName
The snapshot's resource group.

### -ResourceId
The ARM resource ID of a snapshot in the current subscription context. `Id` is an alias.

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

## INPUTS
### Microsoft.Azure.Commands.Compute.Automation.Models.PSSnapshot

## OUTPUTS
### Microsoft.Azure.Commands.Compute.Automation.Models.PSSnapshot
