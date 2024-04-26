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
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"  | Where-Object { $_.Name -match "aks-cluster-name" }
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
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where-Object { $_.Name -match "storageAcountName" }
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
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where-Object { $_.Name -match "storageAcountName" }
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
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where-Object { $_.Property.DataSourceInfo.ResourceType -match "Postgre" }
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
The third command initializes the ARM Id for target container. This parameter is needed for vaults where cross subscription restore is disabled and optional for  CSR enabled vaults.
The fourth, fifth command initializes targetContainerURI and fileNamePrefix for restore.
The sixth command initializes the restore request object for AzureDatabaseForPostgreSQL restore.
The seventh command triggers validate before restore.
The last command triggers the cross subscription restore as files for AzureDatabaseForPostgreSQL.

### Example 8: Trigger cross region restore for AzureDatabaseForPostgreSQL.
```powershell
$restoreJobCRR = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.Name -ResourceGroupName $ResourceGroupName -VaultName $vaultName -SubscriptionId $SubscriptionId -Parameter $OssRestoreReq -RestoreToSecondaryRegion
$jobid = $restoreJobCRR.JobId.Split("/")[-1]
$jobstatus = "InProgress"
while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -UseSecondaryRegion
    $jobstatus = $currentjob.Status
}
```


This command command triggers the cross region restore for AzureDatabaseForPostgreSQL. For triggering cross region restore to secondary region, use RestoreToSecondaryRegion switch.

### Example 9: Trigger restore as Files for datasource type AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"  | Where-Object { $_.Name -match "test-pgflex" }
$rps = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$targetContainerURI = "https://teststorageaccount.blob.core.windows.net/powershellpgflexrestore"
$storageAccId = (Get-AzStorageAccount -ResourceGroupName "teststorageaccountRG" -Name "teststorageaccount").Id
$pgFlexRestoreAsFilesRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPGFlexServer -SourceDataStore VaultStore -RestoreLocation $vault.Location -RestoreType RestoreAsFiles -RecoveryPoint $rps[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI
Set-AzDataProtectionMSIPermission -VaultResourceGroup "resourceGroupName" -VaultName "vaultName" -PermissionsScope "ResourceGroup" -RestoreRequest $pgFlexRestoreAsFilesRequest -DatasourceType AzureDatabaseForPGFlexServer -SubscriptionId $SubscriptionId -StorageAccountARMId $storageAccId
$validateRestore = Test-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -RestoreRequest $pgFlexRestoreAsFilesRequest -Name $instance.BackupInstanceName
$restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.BackupInstanceName -Parameter $pgFlexRestoreAsFilesRequest
```

The first, second commands fetch the instance and recovery point for the instance.
The third and fourthcommand initializes the target container id and target storage account ARM id.
The fifth command initializes the restore request object for AzureDatabaseForPGFlexServer restore. This example also works for datasource type AzureDatabaseForMySQL.
The sixth command assigns the permissions to the backup vault and other permissions necessary for triggering the restore for AzureDatabaseForPGFlexServer.
The last command triggers the restore for AzureDatabaseForPGFlexServer.

### Example 10: Trigger vaulted backup conatiners ItemLevelRestore with PrefixMatch for Azureblob.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" | Where-Object { $_.Name -match "storageAcountName" }
$rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.Name
$backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList
$prefMatch = @{
    $backedUpContainers[0] = @("Su", "PS")
    $backedUpContainers[1]= @("meta", "coll", "Su")
}
$targetStorageAccountId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/targetStorageAccount"
$restoreReqILR = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore VaultStore -RestoreLocation "vaultLocation" -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetStorageAccountId -ContainersList $backedUpContainers[0,1] -PrefixMatch $prefMatch
Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName "resourceGroupName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -RestoreRequest $restoreReqILR
$restoreJobILR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -BackupInstanceName $instance.BackupInstanceName -Parameter $restoreJobILR
```

The first, second commands fetch the instance and recovery point for the instance.
The third command fetches the containers which are protected with vaulted policy.
The fourth command initializes the prefix array for each container. PrefixMatch is a hashtable where each key is the conatiner name being restored and the value is a list of string prfixes for container names for Item level recovery.
The fifth command initializes the target storage account Id.
The sixth command initializes the restore request object for AzureBlob restore with parameters ContainersList, PrefixMatch.
The seventh command triggers validate before restore.
The last command triggers prefix match Item level restore for vaulted blob containers.