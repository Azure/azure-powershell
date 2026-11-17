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

### DefaultParameterSet (Default)
```
Set-AzSnapshotImmutabilityPolicy -PolicyType <String> -DurationInDays <Int32> -ResourceGroupName <String>
 [-Name] <String> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Set-AzSnapshotImmutabilityPolicy -PolicyType <String> -DurationInDays <Int32> [-ResourceId] <String> [-Force]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Set-AzSnapshotImmutabilityPolicy -PolicyType <String> -DurationInDays <Int32> [-InputObject] <PSSnapshot>
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSnapshotImmutabilityPolicy** cmdlet applies or updates deletion protection on an existing managed disk snapshot. Unlocked policies can be shortened or extended. Active Locked policies can only be extended; they cannot be removed or changed to Unlocked.

Duration is total retention from the service-assigned start, not additional days from now. Active-policy updates, including changing Unlocked to Locked, retain that start. Replacing an expired policy creates a new start. Reducing an Unlocked policy's duration, including when locking it, can immediately expire protection.

Unlocked updates require `Microsoft.Compute/snapshots/updateImmutabilityPolicy/action`; Locked updates require `Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action`. Both require snapshot read permission. Every Locked update requires acknowledgement because applying or extending Locked retention cannot be undone before expiry.

The cmdlet returns the snapshot after verifying the persisted policy. If verification fails, the change may already have applied. Inspect the snapshot's `ImmutabilityPolicy` with **Get-AzSnapshot** before retrying.

## EXAMPLES

### Example 1: Apply an Unlocked policy by name
```powershell
$snapshot = Set-AzSnapshotImmutabilityPolicy -ResourceGroupName "rg-backup" -Name "snapshot-01" -PolicyType Unlocked -DurationInDays 7
$snapshot.ImmutabilityPolicy | Format-List
```

This command applies a seven-day Unlocked policy and displays it.

### Example 2: Apply a policy by resource ID
```powershell
Set-AzSnapshotImmutabilityPolicy -ResourceId "/subscriptions/<subscription-id>/resourceGroups/rg-backup/providers/Microsoft.Compute/snapshots/snapshot-01" -PolicyType Unlocked -DurationInDays 7
```

This command applies the policy to the snapshot identified by its resource ID.

### Example 3: Change a policy by piping a snapshot
```powershell
Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" |
    Set-AzSnapshotImmutabilityPolicy -PolicyType Unlocked -DurationInDays 14
```

This command sets Unlocked retention to 14 days without resetting its start.

### Example 4: Shorten the total Unlocked duration
```powershell
$snapshot = Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01"
$snapshot = Set-AzSnapshotImmutabilityPolicy -InputObject $snapshot -PolicyType Unlocked -DurationInDays 7
$snapshot.ImmutabilityPolicy |
    Format-List Type, ImmutabilityDurationDays, PolicyStartTime, PolicyExpirationTime, IsPolicyExpired
```

This example shortens an active 14-day Unlocked policy to seven days from its original start. If seven days have elapsed, protection expires.

### Example 5: Preview locking a policy
```powershell
Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" |
    Set-AzSnapshotImmutabilityPolicy -PolicyType Locked -DurationInDays 14 -WhatIf
```

This command previews a Locked policy without changing the snapshot. Locking an active Unlocked policy retains its original start; the requested duration is measured from that start.

### Example 6: Run an Unlocked update as a job
```powershell
$job = Set-AzSnapshotImmutabilityPolicy -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" -PolicyType Unlocked -DurationInDays 7 -AsJob
$snapshot = $job | Wait-Job | Receive-Job -ErrorAction Stop
$snapshot.ImmutabilityPolicy | Format-List
```

This example retrieves the updated snapshot from a background job.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AsJob
Runs the cmdlet in the background and returns a job.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -DurationInDays
Specifies total retention in days. The value must be positive; the service validates the maximum supported duration.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Suppresses the additional Locked-retention acknowledgement, but not standard confirmation, permissions, or retention restrictions. `-Confirm:$false` alone does not suppress this acknowledgement.

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

### -InputObject
Specifies the snapshot whose policy is updated. Only its resource ID is used; current policy is read from Azure.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSSnapshot
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the snapshot name.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases: SnapshotName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyType
Specifies the policy type: `Unlocked` or `Locked`.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Unlocked, Locked

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the snapshot's resource group.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Specifies the snapshot resource ID in the current subscription.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSSnapshot

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSSnapshot

## NOTES
Apply policies after snapshot creation. Copies do not inherit protection. Snapshots in Pending, Unknown, or InstantAccess states cannot be updated.

Acknowledgement occurs before a background job starts. Cancelling a job does not guarantee server cancellation or rollback.

## RELATED LINKS

[Get-AzSnapshot](./Get-AzSnapshot.md)

[Remove-AzSnapshotImmutabilityPolicy](./Remove-AzSnapshotImmutabilityPolicy.md)
