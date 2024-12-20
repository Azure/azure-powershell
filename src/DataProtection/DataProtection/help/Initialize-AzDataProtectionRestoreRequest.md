---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/initialize-azdataprotectionrestorerequest
schema: 2.0.0
---

# Initialize-AzDataProtectionRestoreRequest

## SYNOPSIS
Initializes Restore Request object for triggering restore on a protected backup instance.

## SYNTAX

### AlternateLocationFullRecovery (Default)
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -SourceDataStore <DataStoreType>
 -RestoreLocation <String> -RestoreType <RestoreTargetType> -TargetResourceId <String>
 [-RecoveryPoint <String>] [-PointInTime <DateTime>] [-RehydrationDuration <String>]
 [-RehydrationPriority <String>] [-RestoreConfiguration <PSObject>] [-SecretStoreURI <String>]
 [-SecretStoreType <SecretStoreTypes>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AlternateLocationILR
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -SourceDataStore <DataStoreType>
 -RestoreLocation <String> -RestoreType <RestoreTargetType> -TargetResourceId <String>
 [-RecoveryPoint <String>] [-RestoreConfiguration <PSObject>] [-ItemLevelRecovery] [-ContainersList <String[]>]
 [-PrefixMatch <Hashtable>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### OriginalLocationFullRecovery
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -SourceDataStore <DataStoreType>
 -RestoreLocation <String> -RestoreType <RestoreTargetType> [-RecoveryPoint <String>] [-PointInTime <DateTime>]
 [-RehydrationDuration <String>] [-RehydrationPriority <String>] [-RestoreConfiguration <PSObject>]
 [-SecretStoreURI <String>] [-SecretStoreType <SecretStoreTypes>] -BackupInstance <BackupInstanceResource>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### OriginalLocationILR
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -SourceDataStore <DataStoreType>
 -RestoreLocation <String> -RestoreType <RestoreTargetType> [-RecoveryPoint <String>] [-PointInTime <DateTime>]
 [-RehydrationDuration <String>] [-RehydrationPriority <String>] [-RestoreConfiguration <PSObject>]
 [-SecretStoreURI <String>] [-SecretStoreType <SecretStoreTypes>] [-ItemLevelRecovery]
 [-ContainersList <String[]>] -BackupInstance <BackupInstanceResource> [-FromPrefixPattern <String[]>]
 [-ToPrefixPattern <String[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### RestoreAsFiles
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -SourceDataStore <DataStoreType>
 -RestoreLocation <String> -RestoreType <RestoreTargetType> [-RecoveryPoint <String>]
 [-RehydrationDuration <String>] [-RehydrationPriority <String>] [-SecretStoreURI <String>]
 [-SecretStoreType <SecretStoreTypes>] -TargetContainerURI <String>
 [-TargetResourceIdForRestoreAsFile <String>] [-FileNamePrefix <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Initializes Restore Request object for triggering restore on a protected backup instance.

## EXAMPLES

### Example 1: Get restore request object for Protected Azure Disk Backup instance
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault"
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault" -BackupInstanceName $instance.Name
Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "westus"  -RestoreType AlternateLocation -TargetResourceId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{DiskName}" -RecoveryPoint "892e5c5014dc4a96807d22924f5745c9"
```

```output
ObjectType                                  RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointI
                                                                                                                                                             d
----------                                  --------------------------- ------------------------------- -------------------------------- ------------------- --------------
AzureBackupRecoveryPointBasedRestoreRequest RestoreTargetInfo           FailIfExists                    westus                           OperationalStore    892e5c5014dc4a96807d22924f5745c9
```

This command initialized a restore request object which can be used to trigger restore.

### Example 2: Get restore request object for Protected Azure Blob Backup instance
```powershell
$startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
$endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
$pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instance[0] -PointInTime (Get-Date -Date $pointInTimeRange.RestorableTimeRange.EndTime)
```

```output
ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest restoreTargetInfo           FailIfExists                    eastus2euap                      OperationalStore    2021-04-24T13:32:41.7018481Z
```

This command initialized a restore request object which can be used to trigger restore for Blobs.

### Example 3: Get restore request object for Item Level recovery for containers under protected AzureBlob Backup instance
```powershell
$startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
$endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
$pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date).AddDays(-1) -ItemLevelRecovery -ContainersList "containerName1","containerName2"
```

```output
ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest itemLevelRestoreTargetInfo  FailIfExists                    eastus2euap                      OperationalStore    2021-04-23T02:47:02.9500000Z
```

This command initialized a restore request object which can be used to trigger Item Level Recovery at container level for Blobs.

### Example 4: Get restore request object for Item Level recovery for containers/prefixMatch under protected AzureBlob Backup instance
```powershell
$startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
$endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
$pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date).AddDays(-1) -ItemLevelRecovery -FromPrefixPattern "container1/aaa","container1/ccc", "container2/aab", "container3" -ToPrefixPattern "container1/bbb","container1/ddd", "container2/abc", "container3-0"
```

```output
ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest itemLevelRestoreTargetInfo  FailIfExists                    eastus2euap                      OperationalStore    2021-04-23T02:47:02.9500000Z
```

This command initialized a restore request object which can be used to trigger Item Level Recovery at blobs level based on name prefixes under Blob containers.

The above restoreRequest restore the following containers/blobs:

FromPrefix           ToPrefix
"container1/aaa"    "container1/bbb"  (restores all blobs matched in this Prefix range)
"container1/ccc"    "container1/ddd"
"container2/aab"    "container2/abc" 
"container3"        "container3-0"   (restores whole container3)
                    
Note: The ranges shouldn't overlap with each other.
Reference: https://learn.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-containers--blobs--and-metadata

### Example 5: Get cross region restore request object for restore as database for datasource type AzureDatabaseForPostgreSQL
```powershell
$vault = Search-AzDataProtectionBackupVaultInAzGraph -ResourceGroup $ResourceGroupName -Subscription $SubscriptionId -Vault $VaultName
$instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup  $resourceGroupName  -Vault $vaultName -DatasourceType AzureDatabaseForPostgreSQL
$recoveryPointsCrr = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -UseSecondaryRegion
$targetResourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/{targetResourceGroupName}/providers/Microsoft.DBforPostgreSQL/servers/{targetServerName}/databases/{targetDatabaseName}"
$secretURI = "https://{crr-key-vault}.vault.azure.net/secrets/{secret-for-crr}"
$OssRestoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.ReplicatedRegion[0] -RestoreType AlternateLocation -RecoveryPoint $recoveryPointsCrr[0].Property.RecoveryPointId -TargetResourceId $targetResourceId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault
```

```output
ObjectType                                  SourceDataStoreType SourceResourceId RecoveryPointId
----------                                  ------------------- ---------------- ---------------
AzureBackupRecoveryPointBasedRestoreRequest VaultStore                           d49aeb83264456ccab92a105cade9afe
```

First and second commands fetch the vault and backup instance from Azure resource graph.
Third command is used to fetch recovery points from secondary region for cross region restore.
Last command constructs the cross region restore request object for restore to alternate location as database for datasourcetype AzureDatabaseForPostgreSQL.
Please note that we set RestoreLocation parameter to $vault.ReplicatedRegion[0] (paired region) instead of $vault.Location for normal restore.
Use Test-AzDataProtectionBackupInstanceRestore, Start-AzDataProtectionBackupInstanceRestore commands to validate and trigger restore.

### Example 6: Get cross region restore request object for restore as database for datasource type AzureDatabaseForPostgreSQL
```powershell
$vault = Search-AzDataProtectionBackupVaultInAzGraph -ResourceGroup $ResourceGroupName -Subscription $SubscriptionId -Vault $VaultName
$instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup  $resourceGroupName  -Vault $vaultName -DatasourceType AzureDatabaseForPostgreSQL
$recoveryPointsCrr = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -UseSecondaryRegion
$targetContainerURI = "https://{targetStorageAccountName}.blob.core.windows.net/{targetContainerName}"
$fileNamePrefix = "oss-pstest-crrasfiles"
$OssRestoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.ReplicatedRegion[0] -RestoreType RestoreAsFiles -RecoveryPoint $recoveryPointsCrr[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix
```

```output
ObjectType                                  SourceDataStoreType SourceResourceId RecoveryPointId
----------                                  ------------------- ---------------- ---------------
AzureBackupRecoveryPointBasedRestoreRequest VaultStore                           d49aeb83264456ccab92a105cade9afe
```

First and second commands fetch the vault and backup instance from Azure resource graph.
Third command is used to fetch recovery points from secondary region for cross region restore.
Last command constructs the cross region restore request object for restore as files for datasourcetype AzureDatabaseForPostgreSQL.
Please note that we set RestoreLocation parameter to $vault.ReplicatedRegion[0] (paired region) instead of $vault.Location for normal restore.
Use Test-AzDataProtectionBackupInstanceRestore, Start-AzDataProtectionBackupInstanceRestore commands to validate and trigger restore.

### Example 7: Get restore request object for alternate location vaulted restore for AzureKubernetesService
```powershell
$subId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$resourceGroupName = "resourceGroupName"
$vaultName = "vaultName"
$location = "eastasia"
$snapshotResourceGroupId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/stagingRG"
$stagingStorageAccount = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/stagingRG/providers/Microsoft.Storage/storageAccounts/snapshotsa"
$targetAKSClusterARMId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/targetRG/providers/Microsoft.ContainerService/managedClusters/targetKubernetesCluster"

$instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match "aks-cluster-name" }
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

 $aksRestoreCriteria = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService  -PersistentVolumeRestoreMode RestoreWithVolumeData -IncludeClusterScopeResource $true -StagingResourceGroupId $snapshotResourceGroupId -StagingStorageAccountId $stagingStorageAccount -IncludedNamespace "hrweb" -NamespaceMapping @{"hrweb"="hrwebrestore"}

$aksALRRestoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureKubernetesService -SourceDataStore VaultStore -RestoreLocation $location -RestoreType AlternateLocation -RecoveryPoint $rp[0].Property.RecoveryPointId -RestoreConfiguration $aksRestoreCriteria -TargetResourceId $targetAKSClusterARMId
```

First, we initialize the necessary variables that will be used in the restore script.
Then, we fetch the backup instance and recovery point for the instance.
Next, we initialize the Restore Configuration client object, which is used to set up the restore request client object.
Note that for vaulted restore for AzureKubernetesService, we have passed the StagingResourceGroupId and StagingStorageAccountId parameters.

We then initialize the restore request object for an Azure Kubernetes Service (AKS) alternate location restore.
Note that the $aksRestoreCriteria object contains the necessary parameters for Vaulted/operations tier restore accordingly.
The RestoreConfiguration object is passed to the Initialize-AzDataProtectionRestoreRequest cmdlet to create the restore request object.
The restore request object is then used to trigger the restore operation.

## PARAMETERS

### -BackupInstance
Backup Instance object to trigger original localtion restore.
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.BackupInstanceResource
Parameter Sets: OriginalLocationFullRecovery, OriginalLocationILR
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainersList
Container names for Item Level Recovery.

```yaml
Type: System.String[]
Parameter Sets: AlternateLocationILR, OriginalLocationILR
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:
Accepted values: AzureDisk, AzureBlob, AzureDatabaseForPostgreSQL, AzureKubernetesService, AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileNamePrefix
File name to be prefixed to the restored backup data.

```yaml
Type: System.String
Parameter Sets: RestoreAsFiles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromPrefixPattern
Specify the blob restore start range for PITR.
You can use this option to specify the starting range for a subset of blobs in each container to restore.
use a forward slash (/) to separate the container name from the blob prefix pattern.

```yaml
Type: System.String[]
Parameter Sets: OriginalLocationILR
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ItemLevelRecovery
Switch parameter to enable item level recovery.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AlternateLocationILR, OriginalLocationILR
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PointInTime
Point In Time for restore.

```yaml
Type: System.DateTime
Parameter Sets: AlternateLocationFullRecovery, OriginalLocationFullRecovery, OriginalLocationILR
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrefixMatch
Use this parameter to filter block blobs by prefix in a container for alternate location ILR.
When you specify a prefix, only blobs matching that prefix in the container will be restored.
Input for this parameter is a hashtable where each key is a container name and each value is an array of string prefixes for that container.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: AlternateLocationILR
Aliases:

Required: False
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

### -RecoveryPoint
Id of the recovery point to be restored.

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

### -RehydrationDuration
Rehydration duration for the archived recovery point to stay rehydrated, default value for rehydration duration is 15.

```yaml
Type: System.String
Parameter Sets: AlternateLocationFullRecovery, OriginalLocationFullRecovery, OriginalLocationILR, RestoreAsFiles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RehydrationPriority
Rehydration priority for archived recovery point.
This parameter is mandatory for rehydrate restore of archived points.

```yaml
Type: System.String
Parameter Sets: AlternateLocationFullRecovery, OriginalLocationFullRecovery, OriginalLocationILR, RestoreAsFiles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreConfiguration
Restore configuration for restore.
Use this parameter to restore with AzureKubernetesService.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: AlternateLocationFullRecovery, AlternateLocationILR, OriginalLocationFullRecovery, OriginalLocationILR
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreLocation
Target Restore Location

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

### -RestoreType
Restore Target Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetType
Parameter Sets: (All)
Aliases:
Accepted values: AlternateLocation, OriginalLocation, RestoreAsFiles

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretStoreType
Secret store type for secret store authentication of data source.
This parameter is only supported for AzureDatabaseForPostgreSQL currently.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SecretStoreTypes
Parameter Sets: AlternateLocationFullRecovery, OriginalLocationFullRecovery, OriginalLocationILR, RestoreAsFiles
Aliases:
Accepted values: AzureKeyVault

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretStoreURI
Secret uri for secret store authentication of data source.
This parameter is only supported for AzureDatabaseForPostgreSQL currently.

```yaml
Type: System.String
Parameter Sets: AlternateLocationFullRecovery, OriginalLocationFullRecovery, OriginalLocationILR, RestoreAsFiles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDataStore
DataStore Type of the Recovery point

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreType
Parameter Sets: (All)
Aliases:
Accepted values: ArchiveStore, OperationalStore, VaultStore

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetContainerURI
Target storage account container Id to which backup data will be restored as files.

```yaml
Type: System.String
Parameter Sets: RestoreAsFiles
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
Specify the target resource ID for restoring backup data in an alternate location.
For instance, provide the target database ARM ID that you want to restore to, for workloadType AzureDatabaseForPostgreSQL.

```yaml
Type: System.String
Parameter Sets: AlternateLocationFullRecovery, AlternateLocationILR
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceIdForRestoreAsFile
Target storage account container ARM Id to which backup data will be restored as files.
This parameter is required for restoring as files when cross subscription restore is disabled on the backup vault.

```yaml
Type: System.String
Parameter Sets: RestoreAsFiles
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToPrefixPattern
Specify the blob restore end range for PITR.
You can use this option to specify the ending range for a subset of blobs in each container to restore.
use a forward slash (/) to separate the container name from the blob prefix pattern.

```yaml
Type: System.String[]
Parameter Sets: OriginalLocationILR
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRestoreRequest

## NOTES

## RELATED LINKS
