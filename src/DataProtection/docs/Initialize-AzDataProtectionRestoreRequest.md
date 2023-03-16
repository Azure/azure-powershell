---
external help file:
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
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -RestoreLocation <String>
 -RestoreType <RestoreTargetType> -SourceDataStore <DataStoreType> -TargetResourceId <String>
 [-PointInTime <DateTime>] [-RecoveryPoint <String>] [-RehydrationDuration <String>]
 [-RehydrationPriority <String>] [-RestoreConfiguration <KubernetesClusterRestoreCriteria>]
 [-SecretStoreType <SecretStoreTypes>] [-SecretStoreURI <String>] [<CommonParameters>]
```

### AlternateLocationILR
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -ItemLevelRecovery
 -RestoreLocation <String> -RestoreType <RestoreTargetType> -SourceDataStore <DataStoreType>
 -TargetResourceId <String> [-RecoveryPoint <String>]
 [-RestoreConfiguration <KubernetesClusterRestoreCriteria>] [<CommonParameters>]
```

### OriginalLocationFullRecovery
```
Initialize-AzDataProtectionRestoreRequest -BackupInstance <BackupInstanceResource>
 -DatasourceType <DatasourceTypes> -RestoreLocation <String> -RestoreType <RestoreTargetType>
 -SourceDataStore <DataStoreType> [-PointInTime <DateTime>] [-RecoveryPoint <String>]
 [-RehydrationDuration <String>] [-RehydrationPriority <String>]
 [-RestoreConfiguration <KubernetesClusterRestoreCriteria>] [-SecretStoreType <SecretStoreTypes>]
 [-SecretStoreURI <String>] [<CommonParameters>]
```

### OriginalLocationILR
```
Initialize-AzDataProtectionRestoreRequest -BackupInstance <BackupInstanceResource>
 -DatasourceType <DatasourceTypes> -ItemLevelRecovery -RestoreLocation <String>
 -RestoreType <RestoreTargetType> -SourceDataStore <DataStoreType> [-ContainersList <String[]>]
 [-FromPrefixPattern <String[]>] [-PointInTime <DateTime>] [-RecoveryPoint <String>]
 [-RehydrationDuration <String>] [-RehydrationPriority <String>]
 [-RestoreConfiguration <KubernetesClusterRestoreCriteria>] [-SecretStoreType <SecretStoreTypes>]
 [-SecretStoreURI <String>] [-ToPrefixPattern <String[]>] [<CommonParameters>]
```

### RestoreAsFiles
```
Initialize-AzDataProtectionRestoreRequest -DatasourceType <DatasourceTypes> -FileNamePrefix <String>
 -RestoreLocation <String> -RestoreType <RestoreTargetType> -SourceDataStore <DataStoreType>
 -TargetContainerURI <String> [-RecoveryPoint <String>] [-RehydrationDuration <String>]
 [-RehydrationPriority <String>] [-SecretStoreType <SecretStoreTypes>] [-SecretStoreURI <String>]
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

## PARAMETERS

### -BackupInstance
Backup Instance object to trigger original localtion restore.
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.BackupInstanceResource
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
Parameter Sets: OriginalLocationILR
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FromPrefixPattern
Minimum matching value for Item Level Recovery.

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
To construct, see NOTES section for RESTORECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.KubernetesClusterRestoreCriteria
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
Target resource Id to which backup data will be restored.

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

### -ToPrefixPattern
Maximum matching value for Item Level Recovery.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IAzureBackupRestoreRequest

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BACKUPINSTANCE <BackupInstanceResource>`: Backup Instance object to trigger original localtion restore.
  - `[Property <IBackupInstance>]`: BackupInstanceResource properties
    - `DataSourceInfo <IDatasource>`: Gets or sets the data source information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
      - `[Type <String>]`: DatasourceType of the resource.
    - `ObjectType <String>`: 
    - `PolicyInfo <IPolicyInfo>`: Gets or sets the policy information.
      - `PolicyId <String>`: 
      - `[PolicyParameter <IPolicyParameters>]`: Policy parameters for the backup instance
        - `[BackupDatasourceParametersList <IBackupDatasourceParameters[]>]`: Gets or sets the Backup Data Source Parameters
          - `ObjectType <String>`: Type of the specific object - used for deserializing
        - `[DataStoreParametersList <IDataStoreParameters[]>]`: Gets or sets the DataStore Parameters
          - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
          - `ObjectType <String>`: Type of the specific object - used for deserializing
    - `[DataSourceSetInfo <IDatasourceSet>]`: Gets or sets the data source set information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[DatasourceType <String>]`: DatasourceType of the resource.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
    - `[DatasourceAuthCredentials <IAuthCredentials>]`: Credentials to use to authenticate with data source provider.
      - `ObjectType <String>`: Type of the specific object - used for deserializing
    - `[FriendlyName <String>]`: Gets or sets the Backup Instance friendly name.
    - `[ValidationType <ValidationType?>]`: Specifies the type of validation. In case of DeepValidation, all validations from /validateForBackup API will run again.
  - `[Tag <IDppProxyResourceTags>]`: Proxy Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`RESTORECONFIGURATION <KubernetesClusterRestoreCriteria>`: Restore configuration for restore. Use this parameter to restore with AzureKubernetesService.
  - `IncludeClusterScopeResource <Boolean>`: Gets or sets the include cluster resources property. This property if enabled will include cluster scope resources during restore.
  - `ObjectType <String>`: Type of the specific object - used for deserializing
  - `[ConflictPolicy <ExistingResourcePolicy?>]`: Gets or sets the Conflict Policy property. This property sets policy during conflict of resources during restore.
  - `[ExcludedNamespace <String[]>]`: Gets or sets the exclude namespaces property. This property sets the namespaces to be excluded during restore.
  - `[ExcludedResourceType <String[]>]`: Gets or sets the exclude resource types property. This property sets the resource types to be excluded during restore.
  - `[IncludedNamespace <String[]>]`: Gets or sets the include namespaces property. This property sets the namespaces to be included during restore.
  - `[IncludedResourceType <String[]>]`: Gets or sets the include resource types property. This property sets the resource types to be included during restore.
  - `[LabelSelector <String[]>]`: Gets or sets the LabelSelectors property. This property sets the resource with such label selectors to be included during restore.
  - `[NamespaceMapping <IKubernetesClusterRestoreCriteriaNamespaceMappings>]`: Gets or sets the Namespace Mappings property. This property sets if namespace needs to be change during restore.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[PersistentVolumeRestoreMode <PersistentVolumeRestoreMode?>]`: Gets or sets the PV (Persistent Volume) Restore Mode property. This property sets whether volumes needs to be restored.

## RELATED LINKS

