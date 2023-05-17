---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesbackuppolicy
schema: 2.0.0
---

# New-AzRecoveryServicesBackupPolicy

## SYNOPSIS
Creates a new backup policy in a given recovery services vault

## SYNTAX

```
New-AzRecoveryServicesBackupPolicy -Policy <IProtectionPolicy> -PolicyName <String>
 -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>] [-MoveToArchiveTier <Boolean?>]
 [-SnapshotRetentionDurationInDays <Int32?>] [-SubscriptionId <String>] [-TierAfterDuration <Int32?>]
 [-TierAfterDurationType <String>] [-TieringMode <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new backup policy in a given recovery services vault

## EXAMPLES

### Example 1: Enable TierRecommended for AzureVM
```powershell
$pol1=Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
New-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-vault -Policy $pol1 -PolicyName tiertest4 -MoveToArchiveTier $true -TieringMode TierRecommended
$pol1.TieringPolicy.AdditionalProperties.ArchivedRP | fl
```

```output

Duration     : 0
DurationType : Invalid
TieringMode  : TierRecommended
```

The first command gets the default policy template for a given DatasourceType.
The second command modifies the tiering policy and creates a new policy.
The third command is to display modified tiering policy.

### Example 2: Enable TierAfter for AzureVM
```powershell
$pol1=Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
New-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-vault -Policy $pol1 -PolicyName tiertest5 -MoveToArchiveTier $true -TierAfterDuration 54 -TieringMode TierAfter -TierAfterDurationType Months
$pol1.TieringPolicy.AdditionalProperties.ArchivedRP | fl
```

```output

Duration     : 54
DurationType : Months
TieringMode  : TierAfter
```

The first command gets the default policy template for a given DatasourceType.
The second command modifies the tiering policy and creates a new policy.
The third command is to display modified tiering policy.

### Example 3: Enable TierAfter for SAPHANA
```powershell
$pol1=Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
New-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-vault -Policy $pol1 -PolicyName tiertest6 -MoveToArchiveTier $true -TierAfterDuration 64 -TieringMode TierAfter -TierAfterDurationType Days
$pol1.SubProtectionPolicy[0].TieringPolicy.AdditionalProperties.ArchivedRP | fl
```

```output

Duration     : 64
DurationType : Days
TieringMode  : TierAfter
```

The first command gets the default policy template for a given DatasourceType.
The second command modifies the tiering policy and creates a new policy.
The third command is to display modified tiering policy.

### Example 4: Disable Tiering Policy
```powershell
New-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-vault -Policy $pol1 -PolicyName tiertest5 -MoveToArchiveTier $false
$pol1.TieringPolicy.AdditionalProperties.ArchivedRP | fl
```

```output

Duration     :
DurationType :
TieringMode  : DoNotTier
```

The first command disables the tiering policy and creates a new policy.
The second command is to display modified tiering policy.

## PARAMETERS

### -DefaultProfile


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

### -MoveToArchiveTier


```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Workload specific Backup policy object.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyName
Policy Name for the policy to be created

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

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

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

### -SnapshotRetentionDurationInDays


```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id

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

### -TierAfterDuration


```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TierAfterDurationType


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

### -TieringMode


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

### -VaultName
The name of the recovery services vault.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICY <IProtectionPolicy>`: Workload specific Backup policy object.
  - `BackupManagementType <String>`: This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
  - `[ProtectedItemsCount <Int32?>]`: Number of items associated with this policy.
  - `[ResourceGuardOperationRequest <String[]>]`: ResourceGuard Operation Requests

## RELATED LINKS

