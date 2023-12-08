---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupprotectionpolicy
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupProtectionPolicy

## SYNOPSIS
Gets backup protection policies for a recovery services vault.

## SYNTAX

### ListPolicy (Default)
```
Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName <String> -VaultName <String>
 [-DatasourceType <DatasourceTypes>] [-DefaultProfile <PSObject>] [-IsArchiveSmartTieringEnabled <Boolean?>]
 [-PolicySubType <String>] [-SubscriptionId <String>] [<CommonParameters>]
```

### GetPolicyByName
```
Get-AzRecoveryServicesBackupProtectionPolicy -Name <String> -ResourceGroupName <String> -VaultName <String>
 [-DefaultProfile <PSObject>] [-IsArchiveSmartTieringEnabled <Boolean?>] [-PolicySubType <String>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets backup protection policies for a recovery services vault.

## EXAMPLES

### Example 1: Get all backup policies in a recovery services vault
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault"
$pol
```

```output
ETag Location Name
---- -------- ----
              HourlyLogBackup
              DefaultPolicy
              NewSQLPolicy
              SAPPolicy
              DailyPolicy-l6dtamab
              EnhancedPolicy
```

Gets all the backup policies in the specified vault in the specified resource group.

### Example 2: Get a backup policy by Name
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault" -Name "HourlyLogBackup"
 $pol | fl
```

```output
BackupManagementType          : AzureWorkload
ETag                          :
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupPolicies/HourlyLogBackup
Location                      :
Name                          : HourlyLogBackup
Property                      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadProtectionPolicy
ProtectedItemsCount           : 3
ResourceGuardOperationRequest :
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                          : Microsoft.RecoveryServices/vaults/backupPolicies
```

Gets info for a specific backup policy by its name in the specified vault in the specified resource group.

### Example 3: Get all backup policies with given DatasourceType, PolicySubType and enabled Archive smart tiering
```powershell
$pol =  Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $ResourceGroupName -VaultName $VaultName -PolicySubType "Standard" -IsArchiveSmartTieringEnabled $true -DatasourceType MSSQL
 $pol
```

```output
ETag Location Name
---- -------- ----
              NewSQLPolicy
```

List all backup policies in the recovery services vault with DatasourceType MSSQL, PolicySubType Standard, and smart tiering enabled.

## PARAMETERS

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: ListPolicy
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -IsArchiveSmartTieringEnabled
Parameter to list policies for which smart tiering is Enabled/Disabled.
Allowed values are $true, $false.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the policy

```yaml
Type: System.String
Parameter Sets: GetPolicyByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicySubType
Type of policy to be fetched: Standard, Enhanced

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource

## NOTES

## RELATED LINKS

