---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azsnapshotimmutabilitypolicy
schema: 2.0.0
---

# Set-AzSnapshotImmutabilityPolicy

## SYNOPSIS
Sets or updates the time-bound deletion protection policy for a managed disk snapshot.

## SYNTAX

```
Set-AzSnapshotImmutabilityPolicy -Name <String> -ResourceGroupName <String> -PolicyType <String> -DurationDays <Int32> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]

Set-AzSnapshotImmutabilityPolicy -ResourceId <String> -PolicyType <String> -DurationDays <Int32> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]

Set-AzSnapshotImmutabilityPolicy -InputObject <PSSnapshot> -PolicyType <String> -DurationDays <Int32> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Use this cmdlet to apply or change a snapshot's immutability policy. `-DurationDays` is the total configured duration, not an additional number of days. An Unlocked policy can be extended, reduced, or explicitly removed. A Locked policy cannot be shortened, downgraded, or removed while active, but its duration can be extended.

The snapshot is created separately. Copies do not inherit an immutability policy. The command returns a snapshot after reading back and verifying the persisted policy.

## EXAMPLES

### Example 1: Apply an Unlocked policy by name
```powershell
$snapshot = Set-AzSnapshotImmutabilityPolicy -ResourceGroupName "rg-backup" -Name "snapshot-01" -PolicyType Unlocked -DurationDays 7
$snapshot.ImmutabilityPolicy | Format-List
```

This applies a seven-day Unlocked policy and displays its persisted values.

### Example 2: Change a policy by piping a snapshot
```powershell
Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" |
    Set-AzSnapshotImmutabilityPolicy -PolicyType Unlocked -DurationDays 14
```

This sets the total duration to 14 days for the snapshot returned by `Get-AzSnapshot`.

### Example 3: Preview locking a policy
```powershell
Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" |
    Set-AzSnapshotImmutabilityPolicy -PolicyType Locked -DurationDays 14 -WhatIf
```

Locking prevents reducing or removing an active policy until it expires. Use `-Force` to suppress the additional confirmation prompt; it does not bypass retention restrictions or permissions.

### Example 4: Use a snapshot resource ID
```powershell
Set-AzSnapshotImmutabilityPolicy -ResourceId "/subscriptions/<subscription-id>/resourceGroups/rg-backup/providers/Microsoft.Compute/snapshots/snapshot-01" -PolicyType Unlocked -DurationDays 7
```

This applies the policy to the snapshot identified by its ARM resource ID in the current subscription context.

## PARAMETERS

### -AsJob
Run the cmdlet in the background. The job's output is a verified `PSSnapshot`.

### -Confirm
Prompts you for confirmation before running the cmdlet.

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

### -DurationDays
The total policy duration in days. The value must be positive; the service validates the maximum supported duration.

### -Force
Suppresses the additional confirmation prompt for a Locked policy. It does not override policy rules or role-based access control permissions.

### -InputObject
The snapshot object whose policy will be changed. The cmdlet uses its resource ID to identify the snapshot and reads its current state from Azure.

### -Name
The snapshot name. `SnapshotName` is an alias.

### -PolicyType
The policy type to apply: `Unlocked` or `Locked`.

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
