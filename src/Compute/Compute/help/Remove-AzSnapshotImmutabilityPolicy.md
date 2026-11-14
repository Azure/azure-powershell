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

### DefaultParameterSet (Default)
```
Remove-AzSnapshotImmutabilityPolicy -ResourceGroupName <String> [-Name] <String> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzSnapshotImmutabilityPolicy [-ResourceId] <String> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzSnapshotImmutabilityPolicy [-InputObject] <PSSnapshot> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzSnapshotImmutabilityPolicy** cmdlet expires an active Unlocked policy without deleting the snapshot. Policies that are absent, expired, or Locked cannot be removed.

Removal requires `Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action` and snapshot read permission. Ordinary policy-update permission alone is insufficient. The returned snapshot retains an expired Unlocked policy with duration 0. Repeating removal returns an error.

The cmdlet prompts for acknowledgement before ending protection. Use `-Force` to suppress this additional prompt; `-Confirm:$false` alone does not.

If verification fails, the change may already have applied. Inspect the snapshot's `ImmutabilityPolicy` with **Get-AzSnapshot** before retrying.

## EXAMPLES

### Example 1: Remove an Unlocked policy from a snapshot object
```powershell
$snapshot = Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01"
$snapshot = Remove-AzSnapshotImmutabilityPolicy -InputObject $snapshot
$snapshot.ImmutabilityPolicy | Format-List
```

This example expires the Unlocked policy and displays the result.

### Example 2: Remove a policy by resource ID
```powershell
Remove-AzSnapshotImmutabilityPolicy -ResourceId "/subscriptions/<subscription-id>/resourceGroups/rg-backup/providers/Microsoft.Compute/snapshots/snapshot-01"
```

This command removes protection from the snapshot identified by its resource ID.

### Example 3: Preview removal by piping a snapshot
```powershell
Get-AzSnapshot -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" |
    Remove-AzSnapshotImmutabilityPolicy -WhatIf
```

This command previews removal without changing the snapshot.

### Example 4: Remove protection in a background job
```powershell
$job = Remove-AzSnapshotImmutabilityPolicy -ResourceGroupName "rg-backup" -SnapshotName "snapshot-01" -AsJob
$snapshot = $job | Wait-Job | Receive-Job -ErrorAction Stop
$snapshot.ImmutabilityPolicy |
    Format-List Type, ImmutabilityDurationDays, PolicyStartTime, PolicyExpirationTime, IsPolicyExpired
```

This example expires protection in a background job and returns the remaining snapshot.

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

### -Force
Suppresses the additional removal acknowledgement, but not standard confirmation, permissions, or retention restrictions.

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
Specifies the snapshot whose policy is removed. Only its resource ID is used; current policy is read from Azure.

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
Snapshots in Pending, Unknown, or InstantAccess states cannot be updated.

Acknowledgement occurs before a background job starts. Cancelling a job does not guarantee server cancellation or rollback.

## RELATED LINKS

[Get-AzSnapshot](./Get-AzSnapshot.md)

[Set-AzSnapshotImmutabilityPolicy](./Set-AzSnapshotImmutabilityPolicy.md)
