---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: F49FA524-28BC-464F-BD0A-F898E99C83D8
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/restore-azrecoveryservicesbackupitem
schema: 2.0.0
---

# Restore-AzRecoveryServicesBackupItem

## SYNOPSIS

Restores the data and configuration for a Backup item to the specified recovery point. The required parameters vary with the backup item type.
The same command is used to restore Azure Virtual machines, databases running within Azure Virtual machines and Azure file shares as well.

## SYNTAX

### AzureManagedVMReplaceExistingParameterSet (Default)
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-RecoveryPoint] <RecoveryPointBase>
 [-StorageAccountName] <String> [-StorageAccountResourceGroupName] <String> [-RestoreOnlyOSDisk]
 [-RestoreDiskList <String[]>] [-DiskEncryptionSetId <String>] [-RestoreToSecondaryRegion]
 [-TargetZoneNumber <Int32>] [-RehydratePriority <String>] [-UseSystemAssignedIdentity]
 [-UserAssignedIdentityId <String>] [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-RehydrateDuration <String>] [-Token <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AzureFileShareParameterSet
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-RecoveryPoint] <RecoveryPointBase>
 -ResolveConflict <RestoreFSResolveConflictOption> [-SourceFilePath <String>]
 [-SourceFileType <SourceFileType>] [-TargetStorageAccountName <String>] [-TargetFileShareName <String>]
 [-TargetFolder <String>] [-MultipleSourceFilePath <String[]>] [-RestoreToSecondaryRegion] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-Token <String>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AzureVMRestoreManagedAsUnmanaged
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-RecoveryPoint] <RecoveryPointBase>
 [-StorageAccountName] <String> [-StorageAccountResourceGroupName] <String> [-RestoreOnlyOSDisk]
 [-RestoreDiskList <String[]>] [-RestoreAsUnmanagedDisks] [-RestoreToSecondaryRegion]
 [-RehydratePriority <String>] [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-RehydrateDuration <String>] [-Token <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AzureManagedVMCreateNewParameterSet
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-RecoveryPoint] <RecoveryPointBase>
 [-StorageAccountName] <String> [-StorageAccountResourceGroupName] <String> [-TargetResourceGroupName] <String>
 [-RestoreOnlyOSDisk] [-RestoreDiskList <String[]>] [-DiskEncryptionSetId <String>] [-RestoreToSecondaryRegion]
 [-TargetZoneNumber <Int32>] [-RehydratePriority <String>] [-UseSystemAssignedIdentity]
 [-UserAssignedIdentityId <String>] [-TargetVMName <String>] [-TargetVNetName <String>]
 [-TargetVNetResourceGroup <String>] [-TargetSubnetName <String>] [-TargetSubscriptionId <String>]
 [-RestoreToEdgeZone] [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-RehydrateDuration <String>] [-Token <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AzureVMUnManagedDiskParameterSet
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-RecoveryPoint] <RecoveryPointBase>
 [-StorageAccountName] <String> [-StorageAccountResourceGroupName] <String> [-UseOriginalStorageAccount]
 [-RestoreOnlyOSDisk] [-RestoreDiskList <String[]>] [-RestoreToSecondaryRegion] [-RehydratePriority <String>]
 [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>] [-RehydrateDuration <String>] [-Token <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureVMRestoreUnmanagedAsManaged
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-RecoveryPoint] <RecoveryPointBase>
 [-StorageAccountName] <String> [-StorageAccountResourceGroupName] <String> [-TargetResourceGroupName] <String>
 [-UseOriginalStorageAccount] [-RestoreOnlyOSDisk] [-RestoreDiskList <String[]>] [-RestoreToSecondaryRegion]
 [-RestoreAsManagedDisk] [-RehydratePriority <String>] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-RehydrateDuration <String>] [-Token <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureWorkloadParameterSet
```
Restore-AzRecoveryServicesBackupItem [-VaultLocation <String>] [-WLRecoveryConfig] <RecoveryConfigBase>
 [-RestoreToSecondaryRegion] [-RehydratePriority <String>] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-RehydrateDuration <String>] [-Token <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

The **Restore-AzRecoveryServicesBackupItem** cmdlet restores the data and configuration for an Azure Backup item to a specified recovery point.

**For Azure VM  backup**

You can backup Azure virtual machines and restore disks (both managed and un-managed) using this command. The restore operation does not restore the full virtual machine.
If this is a managed disk VM, a target Resource group should be specified where the restored disks are kept. When target resource group is specified, if the snapshots are present in the resource group that was specified in backup policy, the restore operation will be instant and the disks are created from local snapshots and kept in target-resource group. There is also an option to restore them as un-managed disks but this will leverage the data present in Azure recovery services vault and hence will be lot slower. The configuration of the VM and the deployment template which can be used to create VM out of the restored disks will be downloaded to the specified storage account.
If this is an un-managed disk VM, then the snapshots are present in disk's original storage account and/or in the recovery services vault. If user gives an option to use Original storage account to restore, then instant restore can be provided. Otherwise, data is fetched from Azure Recovery services vault and disks are created in specified storage account along with the configuration of the VM and the deployment template.

> [!IMPORTANT]
> By default, Azure VM backup backs up all disks. You can selectively backup relevant disks using the exclusionList or InclusionList parameters during Enable-Backup. The option to selectively restore disks is available only if one has selectively backed them up.

Please refer to different possible parameter sets and parameter text for more information.

> [!NOTE]
> If -VaultId parameter is used then -VaultLocation parameter should be used as well.

**For Azure File share backup**

You can restore an entire file share or specific/multiple files/folders on the share. You can restore to the original location or to an alternate location.

**For Azure Workloads**

You can restore SQL DBs within Azure VMs

## EXAMPLES

### Example 1: Restore the disks of a backed up Managed disk Azure VM from a given recovery point

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -Name "V2VM" -VaultId $vault.ID
$StartDate = (Get-Date).AddDays(-7)
$EndDate = Get-Date
$RP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem -StartDate $StartDate.ToUniversalTime() -EndDate $EndDate.ToUniversalTime() -VaultId $vault.ID
$RestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -TargetResourceGroupName "Target_RG" -StorageAccountName "DestAccount" -StorageAccountResourceGroupName "DestRG" -VaultId $vault.ID -VaultLocation $vault.Location
```

```output
WorkloadName    Operation       Status          StartTime              EndTime
    ------------    ---------       ------          ---------              -------
    V2VM            Restore         InProgress      26-Apr-16 1:14:01 PM   01-Jan-01 12:00:00 AM
```

The first command gets the Recovery Services vault and stores it in $vault variable.
The second command gets the Backup item of type AzureVM, of the name "V2VM", and stores it in the $BackupItem variable.
The third command gets the date from seven days earlier, and then stores it in the $StartDate variable.
The fourth command gets the current date, and then stores it in the $EndDate variable.
The fifth command gets a list of recovery points for the specific backup item filtered by $StartDate and $EndDate.
The last command restores all the disks to the target Resource group Target_RG, and then provides the VM configuration information and the deployment template in the storage account DestAccount in the DestRG resource group.

### Example 2: Restore a Managed AzureVM from a given recovery point to original/alternate location

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -Name "V2VM" -VaultId $vault.ID
$StartDate = (Get-Date).AddDays(-7)
$EndDate = Get-Date
$RP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem -StartDate $StartDate.ToUniversalTime() -EndDate $EndDate.ToUniversalTime() -VaultId $vault.ID
$AlternateLocationRestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -TargetResourceGroupName "Target_RG" -StorageAccountName "DestStorageAccount" -StorageAccountResourceGroupName "DestStorageAccRG" -TargetVMName "TagetVirtualMachineName" -TargetVNetName "Target_VNet" -TargetVNetResourceGroup "" -TargetSubnetName "subnetName" -VaultId $vault.ID -VaultLocation $vault.Location 
$OriginalLocationRestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -StorageAccountName "DestStorageAccount" -StorageAccountResourceGroupName "DestStorageAccRG" -VaultId $vault.ID -VaultLocation $vault.Location
```

```output
WorkloadName    Operation       Status          StartTime              EndTime
    ------------    ---------       ------          ---------              -------
    V2VM            Restore         InProgress      26-Apr-16 1:14:01 PM   01-Jan-01 12:00:00 AM
```

The first command gets the Recovery Services vault and stores it in $vault variable.
The second command gets the Backup item of type AzureVM, of the name "V2VM", and stores it in the $BackupItem variable.
The third command gets the date from seven days earlier, and then stores it in the $StartDate variable.
The fourth command gets the current date, and then stores it in the $EndDate variable.
The fifth command gets a list of recovery points for the specific backup item filtered by $StartDate and $EndDate.
The sixth command triggers an Alternate Location Restore (ALR) to create a new VM in Target_RG resource group as per the inputs specified by parameters TargetVMName, TargetVNetName, TargetVNetResourceGroup, TargetSubnetName. 
Alternately, if a user wants to perform an in-place restore to the originally backed up VM in the original location, it can be done with the last command. Please **avoid** using TargetResourceGroupName, RestoreAsUnmanagedDisks, TargetVMName, TargetVNetName, TargetVNetResourceGroup, TargetSubnetName parameters for performing Original Location Restore (OLR).

### Example 3: Restore specified disks of a backed up Managed disk Azure VM from a given recovery point

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -Name "V2VM" -VaultId $vault.ID
$StartDate = (Get-Date).AddDays(-7)
$EndDate = Get-Date
$RP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem -StartDate $StartDate.ToUniversalTime() -EndDate $EndDate.ToUniversalTime() -VaultId $vault.ID
$restoreDiskLUNs = ("0", "1")
$RestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -TargetResourceGroupName "Target_RG" -StorageAccountName "DestAccount" -StorageAccountResourceGroupName "DestRG" -RestoreDiskList $restoreDiskLUNs -VaultId $vault.ID -VaultLocation $vault.Location
```

```output
WorkloadName    Operation       Status          StartTime              EndTime
    ------------    ---------       ------          ---------              -------
    V2VM            Restore         InProgress      26-Apr-16 1:14:01 PM   01-Jan-01 12:00:00 AM
```

The first command gets the Recovery Services vault and stores it in $vault variable.
The second command gets the Backup item of type AzureVM, of the name "V2VM", and stores it in the $BackupItem variable.
The third command gets the date from seven days earlier, and then stores it in the $StartDate variable.
The fourth command gets the current date, and then stores it in the $EndDate variable.
The fifth command gets a list of recovery points for the specific backup item filtered by $StartDate and $EndDate.
The sixth command stores the list of disks to be restored in the restoreDiskLUN variable.
The last command restores the given disks, of the specified LUNs, to the target Resource group Target_RG, and then provides the VM configuration information and the deployment template in the storage account DestAccount in the DestRG resource group.

### Example 4: Restore disks of a managed VM as unmanaged Disks

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -Name "V2VM" -VaultId $vault.ID
$StartDate = (Get-Date).AddDays(-7)
$EndDate = Get-Date
$RP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem[0] -StartDate $StartDate.ToUniversalTime() -EndDate $EndDate.ToUniversalTime() -VaultId $vault.ID
$RestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -RestoreAsUnmanagedDisks -StorageAccountName "DestAccount" -StorageAccountResourceGroupName "DestRG" -VaultId $vault.ID -VaultLocation $vault.Location
```

```output
WorkloadName    Operation       Status          StartTime              EndTime
    ------------    ---------       ------          ---------              -------
    V2VM            Restore         InProgress      26-Apr-16 1:14:01 PM   01-Jan-01 12:00:00 AM
```

The first command gets the RecoveryServices vault and stores it in $vault variable.
The second command gets the Backup item and then stores it in the $BackupItem variable.
The third command gets the date from seven days earlier, and then stores it in the $StartDate variable.
The fourth command gets the current date, and then stores it in the $EndDate variable.
The fifth command gets a list of recovery points for the specific backup item filtered by $StartDate and $EndDate.
The sixth command restores the disks as unmanaged disks.

### Example 5: Restore an unmanaged VM as unmanaged Disks using original storage account

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -Name "UnManagedVM" -VaultId $vault.ID
$StartDate = (Get-Date).AddDays(-7)
$EndDate = Get-Date
$RP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem[0] -StartDate $StartDate.ToUniversalTime() -EndDate $EndDate.ToUniversalTime() -VaultId $vault.ID
$RestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -UseOriginalStorageAccount -StorageAccountName "DestAccount" -StorageAccountResourceGroupName "DestRG" -VaultId $vault.ID -VaultLocation $vault.Location
```

```output
WorkloadName    Operation       Status          StartTime              EndTime
    ------------    ---------       ------          ---------              -------
    V2VM            Restore         InProgress      26-Apr-16 1:14:01 PM   01-Jan-01 12:00:00 AM
```

The first command gets the RecoveryServices vault and stores it in $vault variable.
The second command gets the Backup item and then stores it in the $BackupItem variable.
The third command gets the date from seven days earlier, and then stores it in the $StartDate variable.
The fourth command gets the current date, and then stores it in the $EndDate variable.
The fifth command gets a list of recovery points for the specific backup item filtered by $StartDate and $EndDate.
The sixth command restores the disks as unmanaged disks to their original storage accounts

### Example 6: Restore Multiple files of an AzureFileShare item

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureStorage -WorkloadType AzureVM -VaultId $vault.ID -Name "fileshareitem"
$RP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem -VaultId $vault.ID
$files = ("file1.txt", "file2.txt")
$RestoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $RP[0] -MultipleSourceFilePath $files -SourceFileType File -ResolveConflict Overwrite -VaultId $vault.ID -VaultLocation $vault.Location
```

```output
WorkloadName    Operation       Status          StartTime              EndTime
    ------------    ---------       ------          ---------              -------
    fileshareitem   Restore         InProgress      26-Apr-16 1:14:01 PM   01-Jan-01 12:00:00 AM
```

The first command gets the Recovery Services vault and stores it in $vault variable.
The second command gets the Backup item named fileshareitem and then stores it in the $BackupItem variable.
The third command gets a list of recovery points for the specific backup item.
The fourth command specifies which files to restore and stores it in $files variable.
The last command restores the specified files to its original location.

### Example 7: Restore a SQL DB within an Azure VM to another target VM for a distinct full recovery point

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID -Name "MSSQLSERVER;model"
$StartDate = (Get-Date).AddDays(-7)
$EndDate = Get-Date
$FullRP = Get-AzRecoveryServicesBackupRecoveryPoint -Item $BackupItem -StartDate $StartDate.ToUniversalTime() -EndDate $EndDate.ToUniversalTime() -VaultId $vault.ID
$TargetInstance = Get-AzRecoveryServicesBackupProtectableItem -WorkloadType MSSQL -ItemType SQLInstance -Name "<SQLInstance Name>" -ServerName "<SQL VM name>" -VaultId $vault.ID
$AnotherInstanceWithFullConfig = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $FullRP -TargetItem $TargetInstance -AlternateWorkloadRestore -VaultId $vault.ID
Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $AnotherInstanceWithLogConfig -VaultId $vault.ID
```

```output
WorkloadName       Operation        Status            StartTime                 EndTime          JobID
    ------------       ---------        ------            ---------                 -------          -----
    MSSQLSERVER/m...   Restore          InProgress        3/17/2019 10:02:45 AM                      3274xg2b-e4fg-5952-89b4-8cb566gc1748
```

### Example 8: Restore a SQL DB within an Azure VM to another target VM for a log recovery point

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$BackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID -Name "MSSQLSERVER;model"
$PointInTime = Get-Date -Date "2019-03-20 01:00:00Z"
$TargetInstance = Get-AzRecoveryServicesBackupProtectableItem -WorkloadType MSSQL -ItemType SQLInstance -Name "<SQLInstance Name>" -ServerName "<SQL VM name>" -VaultId $vault.ID
$AnotherInstanceWithLogConfig = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -PointInTime $PointInTime -Item $BackupItem -AlternateWorkloadRestore -VaultId $vault.ID
Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $AnotherInstanceWithLogConfig -VaultId $vault.ID
```

```output
WorkloadName     Operation      Status           StartTime                 EndTime           JobID
    ------------     ---------      ------           ---------                 -------           -----
    MSSQLSERVER/m... Restore        InProgress       3/17/2019 10:02:45 AM                       3274xg2b-e4fg-5952-89b4-8cb566gc1748
```

### Example 9: Rehydrate Restore for IaasVM from an archived recovery point

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -StartDate (Get-Date).AddDays(-29).ToUniversalTime() -EndDate (Get-Date).AddDays(0).ToUniversalTime() -VaultId $vault.ID -Item $item[3] -Tier VaultArchive
$restoreJob = Restore-AzRecoveryServicesBackupItem -RecoveryPoint $rp[0] -RehydratePriority "Standard" -RehydrateDuration "13" -TargetResourceGroupName "Target_RG" -StorageAccountName "DestAccount" -StorageAccountResourceGroupName "DestRG" -RestoreDiskList $restoreDiskLUNs -VaultId $vault.ID -VaultLocation $vault.Location
```

Here we filter the recovery points present in the VaultArchive tier and trigger a restore with rehydration priority and rehydration duration.

### Example 10: Cross zonal restore for non-ZonePinned VM in a ZRS vault

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -StartDate (Get-Date).AddDays(-29).ToUniversalTime() -EndDate (Get-Date).AddDays(0).ToUniversalTime() -VaultId $vault.ID -Item $item[3] -Tier VaultStandard
$restoreJob = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location -RecoveryPoint $rp[0] -StorageAccountName "saName" -StorageAccountResourceGroupName $vault.ResourceGroupName -TargetResourceGroupName $vault.ResourceGroupName -TargetVMName "targetVMName" -TargetVNetName "targetVNet" -TargetVNetResourceGroup $vault.ResourceGroupName -TargetSubnetName "default" -TargetZoneNumber 2
```

Here we filter the recovery points present in the VaultStandard tier and trigger a cross zonal restore for non-ZonePinned VM in a ZRS vault. For CZR we pass -TargetZoneNumber parameter. For Non-ZonedPinned VM, CZR is supported only for ZRS vaults. For ZonePinned VMs CZR is supported for ZRS vaults and cross region restore to secondary region for CRR enabled vaults. We can use Snapshot or vaulted tier enabled recovery points for CZR with a limitation that snapshot recovery point should be more than 4 hrs old.

### Example 11: Edge zone restore for a managed AzureVM to alternate location

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$item = Get-AzRecoveryServicesBackupItem -BackupManagementType AzureVM -WorkloadType AzureVM -VaultId $vault.ID
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -StartDate (Get-Date).AddDays(-29).ToUniversalTime() -EndDate (Get-Date).AddDays(0).ToUniversalTime() -VaultId $vault.ID -Item $item[3]
$restoreJob = Restore-AzRecoveryServicesBackupItem -VaultId $vault.ID -VaultLocation $vault.Location -RecoveryPoint $rp[0] -StorageAccountName "saName" -StorageAccountResourceGroupName $vault.ResourceGroupName -TargetResourceGroupName $vault.ResourceGroupName -TargetVMName "targetVMName" -TargetVNetName "targetVNet" -TargetVNetResourceGroup $vault.ResourceGroupName -TargetSubnetName "default" -TargetZoneNumber 2 -RestoreToEdgeZone
```

In this example, we use RestoreToEdgeZone parameter to trigger a restore to new edge zone vm in alternate location. For Original location restore (OLR), restore will implicitly be an edge zone restore if the source VM is an edge zone VM.

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

### -DiskEncryptionSetId

The DES ID to encrypt the restored disks.

```yaml
Type: System.String
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MultipleSourceFilePath
Used for Multiple files restore from a file share. The paths of the items to be restored within the file share.

```yaml
Type: System.String[]
Parameter Sets: AzureFileShareParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPoint

Specifies the recovery point to which to restore the backup item.
To obtain an **AzureRmRecoveryServicesBackupRecoveryPoint** object, use the **Get-AzRecoveryServicesBackupRecoveryPoint** cmdlet.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointBase
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureFileShareParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RehydrateDuration

Duration in days for which to keep the archived recovery point rehydrated. Value can range from 10 to 30 days, default value is 15 days.

```yaml
Type: System.String
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged, AzureWorkloadParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RehydratePriority

Rehydration priority for an archived recovery point while triggering the restore. Acceptable values are Standard, High.

```yaml
Type: System.String
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged, AzureWorkloadParameterSet
Aliases:
Accepted values: Standard, High

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResolveConflict

In case the restored item also exists in the destination, use this to indicate whether to overwrite or not.
The acceptable values for this parameter are:

- Overwrite
- Skip

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RestoreFSResolveConflictOption
Parameter Sets: AzureFileShareParameterSet
Aliases:
Accepted values: Overwrite, Skip

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreAsManagedDisk
Use this switch to specify to restore as managed disks.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreAsUnmanagedDisks
Use this switch to specify to restore as unmanaged disks

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureVMRestoreManagedAsUnmanaged
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreDiskList
Specify which disks to recover of the backed up VM

```yaml
Type: System.String[]
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreOnlyOSDisk
Use this switch to restore only OS disks of a backed up VM

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreToEdgeZone
Switch parameter to indicate edge zone VM restore. This parameter can't be used in cross region and corss subscription restore scenario

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreToSecondaryRegion

Use this switch to trigger the Cross region restore to secondary region.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceFilePath

Used for a particular item restore from a file share. The path of the item to be restored within the file share.

```yaml
Type: System.String
Parameter Sets: AzureFileShareParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceFileType

Used for a particular item restore from a file share. The type of the item to be restored within the file share.
The acceptable values for this parameter are:

- File
- Directory

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.SourceFileType]
Parameter Sets: AzureFileShareParameterSet
Aliases:
Accepted values: File, Directory

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName

Specifies the name of the target Storage account in your subscription.
As a part of the restore process, this cmdlet stores the disks and the configuration information in this Storage account.

```yaml
Type: System.String
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceGroupName

Specifies the name of the resource group that contains the target Storage account in your subscription.
As a part of the restore process, this cmdlet stores the disks and the configuration information in this Storage account.

```yaml
Type: System.String
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureVMRestoreManagedAsUnmanaged, AzureManagedVMCreateNewParameterSet, AzureVMUnManagedDiskParameterSet, AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetFileShareName

The File Share to which the file share has to be restored to.

```yaml
Type: System.String
Parameter Sets: AzureFileShareParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetFolder

The folder under which the file share has to be restored to within the TargetFileShareName. If the backed-up content is to be restored to a root folder, give the target folder values as an empty string.

```yaml
Type: System.String
Parameter Sets: AzureFileShareParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupName

The resource group to which the managed disks are restored. Applicable to backup of VM with managed disks

```yaml
Type: System.String
Parameter Sets: AzureManagedVMCreateNewParameterSet, AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetStorageAccountName

The storage account to which the file share has to be restored to.

```yaml
Type: System.String
Parameter Sets: AzureFileShareParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSubnetName
Name of the subnet in which the target VM should be created, in the case of Alternate Location restore to a new VM

```yaml
Type: System.String
Parameter Sets: AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSubscriptionId
ID of the target subscription to which the resource should be restored. Use this parameter for Cross subscription restore

```yaml
Type: System.String
Parameter Sets: AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMName
Name of the VM to which the data should be restored, in the case of Alternate Location restore to a new VM

```yaml
Type: System.String
Parameter Sets: AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVNetName
Name of the VNet in which the target VM should be created, in the case of Alternate Location restore to a new VM

```yaml
Type: System.String
Parameter Sets: AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVNetResourceGroup
Name of the resource group which contains the target VNet, in the case of Alternate Location restore to a new VM

```yaml
Type: System.String
Parameter Sets: AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetZoneNumber

The target availability zone number where the restored disks are pinned.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant

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

### -UseOriginalStorageAccount

Use this switch if the disks from the recovery point are to be restored to their original storage accounts.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureVMUnManagedDiskParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureVMRestoreUnmanagedAsManaged
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId
UserAssigned Identity Id to trigger MSI based restore with UserAssigned Identity

```yaml
Type: System.String
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureManagedVMCreateNewParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSystemAssignedIdentity
Use this switch to trigger MSI based restore with SystemAssigned Identity

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureManagedVMReplaceExistingParameterSet, AzureManagedVMCreateNewParameterSet
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

### -VaultLocation

Location of the Recovery Services Vault.

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

### -WLRecoveryConfig

Recovery config

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryConfigBase
Parameter Sets: AzureWorkloadParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### System.String

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointBase

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.JobBase

## NOTES

## RELATED LINKS

[Backup-AzRecoveryServicesBackupItem](./Backup-AzRecoveryServicesBackupItem.md)

[Get-AzRecoveryServicesBackupItem](./Get-AzRecoveryServicesBackupItem.md)

[Get-AzRecoveryServicesBackupRecoveryPoint](./Get-AzRecoveryServicesBackupRecoveryPoint.md)
