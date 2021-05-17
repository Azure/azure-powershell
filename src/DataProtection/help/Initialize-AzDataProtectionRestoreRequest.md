---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/powershell/module/az.dataprotection/initialize-azdataprotectionrestorerequest
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
 [-PointInTime <DateTime>] [-RecoveryPoint <String>] [<CommonParameters>]
```

### OriginalLocationFullRecovery
```
Initialize-AzDataProtectionRestoreRequest -BackupInstance <BackupInstanceResource>
 -DatasourceType <DatasourceTypes> -RestoreLocation <String> -RestoreType <RestoreTargetType>
 -SourceDataStore <DataStoreType> [-PointInTime <DateTime>] [-RecoveryPoint <String>] [<CommonParameters>]
```

### OriginalLocationILR
```
Initialize-AzDataProtectionRestoreRequest -BackupInstance <BackupInstanceResource>
 -DatasourceType <DatasourceTypes> -ItemLevelRecovery -RestoreLocation <String>
 -RestoreType <RestoreTargetType> -SourceDataStore <DataStoreType> [-ContainersList <String[]>]
 [-FromPrefixPattern <String[]>] [-PointInTime <DateTime>] [-RecoveryPoint <String>]
 [-ToPrefixPattern <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Initializes Restore Request object for triggering restore on a protected backup instance.

## EXAMPLES

### Example 1: Get restore request object for Protected Azure Disk Backup instance
```powershell
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault"
PS C:\> $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault" -BackupInstanceName $instance.Name
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "westus"  -RestoreType AlternateLocation -TargetResourceId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{DiskName}" -RecoveryPoint "892e5c5014dc4a96807d22924f5745c9"
PS C:\> $restoreRequest

ObjectType                                  RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointI
                                                                                                                                                             d
----------                                  --------------------------- ------------------------------- -------------------------------- ------------------- --------------
AzureBackupRecoveryPointBasedRestoreRequest RestoreTargetInfo           FailIfExists                    westus                           OperationalStore    892e5c5014dc4a96807d22924f5745c9
```

This command initialized a restore request object which can be used to trigger restore.

### Example 2: Get restore request object for Protected Azure Blob Backup instance
```powershell
PS C:\> $startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
PS C:\> $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instance[0] -PointInTime (Get-Date -Date $pointInTimeRange.RestorableTimeRange.EndTime)
PS C:\> $restoreRequest

ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest restoreTargetInfo           FailIfExists                    eastus2euap                      OperationalStore    2021-04-24T13:32:41.7018481Z

```

This command initialized a restore request object which can be used to trigger restore for Blobs.

### Example 3: Get restore request object for Item Level recovery for containers under protected AzureBlob Backup instance
```powershell
PS C:\> $startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
PS C:\> $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date).AddDays(-1) -ItemLevelRecovery -ContainersList "containerName1","containerName2"
PS C:\> $restoreRequest

ObjectType                                 RestoreTargetInfoObjectType RestoreTargetInfoRecoveryOption RestoreTargetInfoRestoreLocation SourceDataStoreType RecoveryPointTime
----------                                 --------------------------- ------------------------------- -------------------------------- ------------------- -----------------
AzureBackupRecoveryTimeBasedRestoreRequest itemLevelRestoreTargetInfo  FailIfExists                    eastus2euap                      OperationalStore    2021-04-23T02:47:02.9500000Z

```

This command initialized a restore request object which can be used to trigger Item Level Recovery at container level for Blobs.

### Example 4: Get restore request object for Item Level recovery for containers/prefixMatch under protected AzureBlob Backup instance
```powershell
PS C:\> $startTime = (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $endTime = (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "rgName" -VaultName "vaultName"
PS C:\> $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "subscriptionId"  -VaultName "vaultName" -SourceDataStoreType OperationalStore -StartTime $startTime -EndTime $endTime
PS C:\> $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date).AddDays(-1) -ItemLevelRecovery -FromPrefixPattern "container1/aaa","container1/ccc", "container2/aab", "container3" -ToPrefixPattern "container1/bbb","container1/ddd", "container2/abc", "container3-0"
PS C:\> $restoreRequest

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
Reference: https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-containers--blobs--and-metadata

## PARAMETERS

### -BackupInstance
Backup Instance object to trigger original localtion restore.
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupInstanceResource
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
Switch Parameter to enable item level recovery.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: OriginalLocationILR
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
Parameter Sets: (All)
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

### -TargetResourceId
Target resource Id to which backup data will be restored.

```yaml
Type: System.String
Parameter Sets: AlternateLocationFullRecovery
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequest

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BACKUPINSTANCE <BackupInstanceResource>: Backup Instance object to trigger original localtion restore.
  - `[Property <IBackupInstance>]`: BackupInstanceResource properties
    - `DataSourceInfo <IDatasource>`: Gets or sets the data source information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
      - `[Type <String>]`: DatasourceType of the resource.
    - `FriendlyName <String>`: Gets or sets the Backup Instance friendly name.
    - `ObjectType <String>`: 
    - `PolicyInfo <IPolicyInfo>`: Gets or sets the policy information.
      - `PolicyId <String>`: 
      - `[PolicyParameter <IPolicyParameters>]`: Policy parameters for the backup instance
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

## RELATED LINKS

