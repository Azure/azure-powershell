---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionrecoverypoint
schema: 2.0.0
---

# Get-AzDataProtectionRecoveryPoint

## SYNOPSIS
Gets a Recovery Point using recoveryPointId for a Datasource.

## SYNTAX

### List (Default)
```
Get-AzDataProtectionRecoveryPoint [-BackupInstanceName <String>] [-ResourceGroupName <String>]
 [-SubscriptionId <String[]>] [-VaultName <String>] [-DefaultProfile <PSObject>] [-StartTime <DateTime>]
 [-EndTime <DateTime>] [-UseSecondaryRegion] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionRecoveryPoint -BackupInstanceName <String> -Id <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -VaultName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionRecoveryPoint -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Recovery Point using recoveryPointId for a Datasource.

## EXAMPLES

### Example 1: Get all recovery points of a given backup instance
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[2].Name
```

```output
Name                             Type
----                             ----
aded40a562134f97b732f30d0b486fef Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
f458438d5ebb4098adbf67e9655cb624 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
515ba70e49d34b2bbff033dcc08593fe Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
e61293fdd1064fbdb4f42b7f5927a927 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
aecc362b85484f4eb905bb05ef445e3e Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
dc814d61a9624c36a1f9d635bc0b80f0 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
```

This command lists all available recovery points of a given backup instance

### Example 2: Get recovery point with given recovery point id.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[2].Name -Id 892e5c5014dc4a96807d22924f5745c9
```

```output
Name                             Type
----                             ----
892e5c5014dc4a96807d22924f5745c9 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
```

This command returns a recovery point with given id.

### Example 3: Get all recovery points of a given backup instance from secondary region
```powershell
$instance = $instance = Search-AzDataProtectionBackupInstanceInAzGraph -DatasourceType AzureDatabaseForPostgreSQL -Subscription "xxxxxxxx-xxxx-xxxxxxxxxxxx" -ResourceGroup sarath-rg -Vault sarath-vault
$recoveryPoints = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[2].Name -UseSecondaryRegion
```

```output
Name                            
----                            
aded40a562134f97b732f30d0b486fef
aecc362b85484f4eb905bb05ef445e3e
dc814d61a9624c36a1f9d635bc0b80f0
```

This command lists all recovery points of a given backup instance from secondary region.
One of these recovery points can be used to trigger cross region restore to secondary region.

## PARAMETERS

### -BackupInstanceName
The name of the backup instance.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Get
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

### -EndTime
End Time filter for recovery points

```yaml
Type: System.DateTime
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RecoveryPointId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Start Time filter for recovery points

```yaml
Type: System.DateTime
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSecondaryRegion
Switch parameter to fetch recovery points from secondary region

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRecoveryPointResource

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
