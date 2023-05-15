---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/start-azdataprotectionbackupinstancerestore
schema: 2.0.0
---

# Start-AzDataProtectionBackupInstanceRestore

## SYNOPSIS
Triggers restore for a BackupInstance

## SYNTAX

### Trigger (Default)
```
Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName <String> -ResourceGroupName <String>
 -VaultName <String> -Parameter <IAzureBackupRestoreRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerExpanded
```
Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName <String> -ResourceGroupName <String>
 -VaultName <String> -ObjectType <String> -RestoreTargetInfo <IRestoreTargetInfoBase>
 -SourceDataStoreType <SourceDataStoreType> [-SubscriptionId <String>] [-SourceResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Triggers restore for a BackupInstance

## EXAMPLES

### Example 1: Trigger restore for a protected azure disk.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault"
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName "sarath-rg" -VaultName "sarath-vault" -BackupInstanceName $instance.Name
$restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "westus"  -RestoreType AlternateLocation -TargetResourceId "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{DiskName}" -RecoveryPoint $rp[0].name
Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName sarath-rg -VaultName sarath-vault -SubscriptionId "xxx-xxx-xxx" -Parameter $restorerequest
```



### Example 2: Trigger restore as DB for protected AzureDatabaseForPostgreSQL using secret store.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$targetResourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.DBforPostgreSQL/servers/serverName/databases/targetDbName"
$secretURI = "https://oss-keyvault.vault.azure.net/secrets/oss-secret"
$restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation "westus" -RestoreType AlternateLocation -TargetResourceId $targetResourceId -RecoveryPoint $rp[0].Property.RecoveryPointId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault
$restoreJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName resourceGroupName -VaultName vaultName -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Parameter $restorerequest
$jobid = $restoreJob.JobId.Split("/")[-1]
$jobstatus = "InProgress"
while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
    $jobstatus = $currentjob.Status
}
```

The first, second commands fetch the instance and recovery point for the instance.
The third command initializes the $targetResourceId with the Id of target postgre database (targetDbName should be the new database name).
The fourth command initializes the secret URI.
The fifth, sixth command initializes and triggers the restore request for AzureDatabaseForPostgreSQL with secret store.
The seventh, eight, ninth  commands track the restore job to completion.

### Example 3: Trigger restore as files for protected AzureDatabaseForPostgreSQL.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$targetContainerURI = "https://targetStorageAccount.blob.core.windows.net/targetContainerName"
$fileNamePrefix = "restore_as_files_12345"
$restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation "westus" -RestoreType RestoreAsFiles -RecoveryPoint $rp[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix
$restoreJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName resourceGroupName -VaultName vaultName -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Parameter $restorerequest
$jobid = $restoreJob.JobId.Split("/")[-1]
$jobstatus = "InProgress"
while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
    $jobstatus = $currentjob.Status
}
```

The first, second commands fetch the instance and recovery point for the instance.
The third command initializes the $targetContainerURI with the Id of target storage account container.
The fourth command initializes the file name prefix for restore.
The fifth, sixth command initializes and triggers the restore request for AzureDatabaseForPostgreSQL with secret store.
The seventh, eight, ninth  commands track the restore job to completion.

### Example 4: Trigger restore as Files for protected AzureKubernetesService.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"  | Where { $_.Name -match "aks-cluster-name" }
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$aksRestoreCriteria = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService  -PersistentVolumeRestoreMode RestoreWithVolumeData -IncludeClusterScopeResource $true -NamespaceMapping  @{"sourceNamespace1"="targetNamespace1";"sourceNamespace2"="targetNamespace2"}
$snapshotResourceGroupId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/snapshotResourceGroup"
$aksOLRRestoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureKubernetesService -SourceDataStore OperationalStore -RestoreLocation eastus -RestoreType OriginalLocation -RecoveryPoint $rps[0].Property.RecoveryPointId -RestoreConfiguration $aksRestoreCriteria -BackupInstance $instance 

Set-AzDataProtectionMSIPermission -VaultResourceGroup "resourceGroupName" -VaultName "vaultName" -PermissionsScope "ResourceGroup" -RestoreRequest $aksOLRRestoreRequest -SnapshotResourceGroupId $snapshotResourceGroupId
$validateRestore = Test-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -RestoreRequest $aksOLRRestoreRequest -Name $instance.BackupInstanceName
$restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.BackupInstanceName -Parameter $aksOLRRestoreRequest
```

The first, second commands fetch the instance and recovery point for the instance.
The third command initializes the Restore Configuration client object used to initialize restore request client object.
The fourth command initializes the snapshot resource group Id.
The fifth command initializes the restore request object for AzureKubernetesService restore.
The sixth command assigns the permissions to the backup vault and target AKS cluster necessary for triggering the restore for AzureKubernetesService.
The last command triggers the restore for AzureKubernetesService.

### Example 5: Trigger restore for vaulted blobs.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where { $_.Name -match "storageAcountName" }
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
$restoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore VaultStore -RestoreLocation "vaultLocation" -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId "targetStorageAccountId" -ContainersList $backedUpContainers[0,1]
Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName "resourceGroupName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -RestoreRequest $restoreReq
$restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.BackupInstanceName -Parameter $restoreReq
```

The first, second commands fetch the instance and recovery point for the instance.
The third command fetches the containers which are protected with vaulted policy.
The fourth command initializes the restore request object for AzureBlob restore.
The fifth command triggers validate before restore.
The last command triggers the restore for vaulted blob containers.

### Example 6: Trigger cross subscription restore for vaulted blobs.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where { $_.Name -match "storageAcountName" }
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
$targetCrossSubscriptionStorageAccountId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/targetStorageAccount"
$restoreReqCSR = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore VaultStore -RestoreLocation "vaultLocation" -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetCrossSubscriptionStorageAccountId -ContainersList $backedUpContainers[0,1]
Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName "resourceGroupName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -RestoreRequest $restoreReqCSR
$restoreJobCSR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.BackupInstanceName -Parameter $restoreReqCSR
```

The first, second commands fetch the instance and recovery point for the instance.
The third command fetches the containers which are protected with vaulted policy.
The fourth command initializes the target cross subscription storage account Id.
The fifth command initializes the restore request object for cross subscription AzureBlob restore.
The sixth command triggers validate before restore.
The last command triggers cross subscription restore for vaulted blob containers.

### Example 7: Trigger cross subscription restore as files for AzureDatabaseForPostgreSQL.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where { $_.Property.DataSourceInfo.ResourceType -match "Postgre" }
$rp = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName "resourceGroupName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName"
$targetResourceArmId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/crossSubResourceGroupName/providers/Microsoft.Storage/storageAccounts/akneemasaecy/blobServices/default/containers/oss-csr-container"
$targetContainerURI =  "https://akneemasaecy.blob.core.windows.net/oss-csr-container"
$fileNamePrefix = "oss-csr-pstest-restoreasfiles"
$ossRestoreReqFiles = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation "vaultLocation" -RestoreType RestoreAsFiles -RecoveryPoint $rp[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix -TargetResourceIdForRestoreAsFile $targetContainerArmId
$validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName "resourceGroupName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -RestoreRequest $ossRestoreReqFiles
$restoreJobCSR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.BackupInstanceName -Parameter $ossRestoreReqFiles
$jobid = $restoreJobCSR.JobId.Split("/")[-1]
$jobstatus = "InProgress"
while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
    $jobstatus = $currentjob.Status
}
```

The first, second commands fetch the backup instance and recovery point for the backup instance.
The third command initializes the ARM Id for target container.
This parameter is needed for cross sub restore for AzureDatabaseForPostgreSQL and not needed for same susbscription restore.
The fourth, fifth command initializes targetContainerURI and fileNamePrefix for restore.
The sixth command initializes the restore request object for AzureDatabaseForPostgreSQL restore.
The seventh command triggers validate before restore.
The last command triggers the cross subscription restore as files for AzureDatabaseForPostgreSQL.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -BackupInstanceName
The name of the backup instance.

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

### -NoWait
Run the command asynchronously

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

### -ObjectType
.

```yaml
Type: System.String
Parameter Sets: TriggerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Azure backup restore request
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IAzureBackupRestoreRequest
Parameter Sets: Trigger
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -RestoreTargetInfo
Gets or sets the restore target information.
To construct, see NOTES section for RESTORETARGETINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IRestoreTargetInfoBase
Parameter Sets: TriggerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDataStoreType
Gets or sets the type of the source data store.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType
Parameter Sets: TriggerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
Fully qualified Azure Resource Manager ID of the datasource which is being recovered.

```yaml
Type: System.String
Parameter Sets: TriggerExpanded
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IAzureBackupRestoreRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IOperationJobExtendedInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETER <IAzureBackupRestoreRequest>`: Azure backup restore request
  - `ObjectType <String>`: 
  - `RestoreTargetInfo <IRestoreTargetInfoBase>`: Gets or sets the restore target information.
    - `ObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `[RestoreLocation <String>]`: Target Restore region
  - `SourceDataStoreType <SourceDataStoreType>`: Gets or sets the type of the source data store.
  - `[SourceResourceId <String>]`: Fully qualified Azure Resource Manager ID of the datasource which is being recovered.

`RESTORETARGETINFO <IRestoreTargetInfoBase>`: Gets or sets the restore target information.
  - `ObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
  - `[RestoreLocation <String>]`: Target Restore region

## RELATED LINKS

