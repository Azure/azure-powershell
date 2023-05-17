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

The first command gets the default policy template for a given DatasourceType. The second command modifies the tiering policy and creates a new policy. The third command is to display modified tiering policy.

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

The first command gets the default policy template for a given DatasourceType. The second command modifies the tiering policy and creates a new policy. The third command is to display modified tiering policy.

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

The first command gets the default policy template for a given DatasourceType. The second command modifies the tiering policy and creates a new policy. The third command is to display modified tiering policy.

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

The first command disables the tiering policy and creates a new policy. The second command is to display modified tiering policy.


