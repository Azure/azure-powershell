---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: 838026E4-F001-434C-86F0-B2A838E93A9C
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackuprecoverypoint
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupRecoveryPoint

## SYNOPSIS

Gets the recovery points for a backed up item.

## SYNTAX

### NoFilterParameterSet (Default)
```
Get-AzRecoveryServicesBackupRecoveryPoint [-Item] <ItemBase> [-UseSecondaryRegion] [-Tier <RecoveryPointTier>]
 [-IsReadyForMove <Boolean>] [-TargetTier <RecoveryPointTier>] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DateTimeFilter
```
Get-AzRecoveryServicesBackupRecoveryPoint [[-StartDate] <DateTime>] [[-EndDate] <DateTime>] [-Item] <ItemBase>
 [-UseSecondaryRegion] [-Tier <RecoveryPointTier>] [-IsReadyForMove <Boolean>]
 [-TargetTier <RecoveryPointTier>] [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### RecoveryPointId
```
Get-AzRecoveryServicesBackupRecoveryPoint [-Item] <ItemBase> [-RecoveryPointId] <String>
 [[-KeyFileDownloadLocation] <String>] [-UseSecondaryRegion] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

The **Get-AzRecoveryServicesBackupRecoveryPoint** cmdlet gets the recovery points for a backed up Azure Backup item.
After an item has been backed up, an **AzureRmRecoveryServicesBackupRecoveryPoint** object has one or more recovery points.
Set the vault context by using the -VaultId parameter.

## EXAMPLES

### Example 1: Get recovery points from the last week for an item

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$startDate = (Get-Date).AddDays(-7)
$endDate = Get-Date
$container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVM -Status Registered -FriendlyName "V2VM" -VaultId $vault.ID
$backupItem = Get-AzRecoveryServicesBackupItem -Container $container -WorkloadType AzureVM -VaultId $vault.ID
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $backupItem -StartDate $startdate.ToUniversalTime() -EndDate $enddate.ToUniversalTime() -VaultId $vault.ID
```

The first command gets vault object based on vaultName. 
The second command gets the date from seven days ago, and then stores it in the $startDate variable.
The third command gets today's date, and then stores it in the $endDate variable.
The fourth command gets AzureVM backup containers, and stores them in the $Container variable. 
The fifth command gets the backup item based on workloadType, vaultId and then stores it in the $backupItem variable.
The last command gets an array of recovery points for the item in $BackupItem, and then stores them in the $rp variable.

### Example 2: Get recovery points which are ready to be moved to VaultArchive

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$startDate = (Get-Date).AddDays(-7).ToUniversalTime()
$endDate = (Get-Date).ToUniversalTime()
$item = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -VaultId $vault.ID
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -StartDate $startDate -EndDate $endDate -VaultId $vault.ID -Item $item[3] `
-IsReadyForMove $true -TargetTier VaultArchive
```

The first command gets vault object based on vaultName. The second command gets the date from seven days ago, and then stores it in the $startDate variable.
The third command gets today's date, and then stores it in the $endDate variable.
The fourth command gets backup items based on backupManagementType and workloadType, vaultId and then stores it in the $item variable.
The last command gets an array of recovery points for the item in $backupItem which are ready to be moved to VaultArchive tier and 
then stores them in the $rp variable.

### Example 3: Get recovery points in a particular tier

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$startDate = (Get-Date).AddDays(-7).ToUniversalTime()
$endDate = (Get-Date).ToUniversalTime()
$item = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -VaultId $vault.ID
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -StartDate $startDate -EndDate $endDate -VaultId $vault.ID -Item $item[3] `
-Tier VaultStandard
```

The first command gets vault object based on vaultName. The second command gets the date from seven days ago, and then stores it in the $startDate variable.
The third command gets today's date, and then stores it in the $endDate variable.
The fourth command gets backup items based on backupManagementType and workloadType, vaultId and then stores it in the $item variable.
The last command gets an array of recovery points for the item in $backupItem which are ready to be moved to VaultArchive tier and 
then stores them in the $rp variable. 

## PARAMETERS

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with azure.

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

### -EndDate

Specifies the end of the date range.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: DateTimeFilter
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsReadyForMove

Filters the Recovery Points based on whether RP is Ready to move to target tier. Use this along with target tier parameter.

```yaml
Type: System.Boolean
Parameter Sets: NoFilterParameterSet, DateTimeFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Item

Specifies the item for which this cmdlet gets recovery points.
To obtain an **AzureRmRecoveryServicesBackupItem** object, use the **Get-AzRecoveryServicesBackupItem** cmdlet.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ItemBase
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyFileDownloadLocation

Specifies the location to download the input file to restore the KeyVault key for an encrypted virtual machine.

```yaml
Type: System.String
Parameter Sets: RecoveryPointId
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPointId

Specifies the recovery point ID.

```yaml
Type: System.String
Parameter Sets: RecoveryPointId
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate

Specifies the start of the date range.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: DateTimeFilter
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetTier

Target tier to check move readiness of recovery point. Currently only valid value is 'VaultArchive'.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointTier
Parameter Sets: NoFilterParameterSet, DateTimeFilter
Aliases:
Accepted values: VaultArchive

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tier

Filter recovery points based on tier value.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointTier
Parameter Sets: NoFilterParameterSet, DateTimeFilter
Aliases:
Accepted values: VaultStandard, Snapshot, VaultArchive, VaultStandardRehydrated, SnapshotAndVaultStandard, SnapshotAndVaultArchive

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSecondaryRegion
Filters from Secondary Region for Cross Region Restore

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

### -VaultId

ARM ID of the Recovery Services Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ItemBase

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointBase

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesBackupContainer](./Get-AzRecoveryServicesBackupContainer.md)

[Get-AzRecoveryServicesBackupItem](./Get-AzRecoveryServicesBackupItem.md)
