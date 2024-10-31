---
external help file: Az.DataProtection-help.xml
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
Start-AzDataProtectionBackupInstanceRestore -ResourceGroupName <String> -BackupInstanceName <String>
 -VaultName <String> -Parameter <IAzureBackupRestoreRequest> [-SubscriptionId <String>]
 [-ResourceGuardOperationRequest <String[]>] [-Token <String>] [-SecureToken <SecureString>]
 [-RestoreToSecondaryRegion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TriggerExpanded
```
Start-AzDataProtectionBackupInstanceRestore -ResourceGroupName <String> -BackupInstanceName <String>
 -VaultName <String> [-SubscriptionId <String>] [-ResourceGuardOperationRequest <String[]>] [-Token <String>]
 [-SecureToken <SecureString>] [-RestoreToSecondaryRegion] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 -ObjectType <String> -RestoreTargetInfo <IRestoreTargetInfoBase> -SourceDataStoreType <SourceDataStoreType>
 [-IdentityDetailUserAssignedIdentityArmUrl <String>] [-IdentityDetailUseSystemAssignedIdentity]
 [-SourceResourceId <String>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
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
The third command initializes the ARM Id for target container.
This parameter is needed for vaults where cross subscription restore is disabled and optional for  CSR enabled vaults.
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

This command command triggers the cross region restore for AzureDatabaseForPostgreSQL.
For triggering cross region restore to secondary region, use RestoreToSecondaryRegion switch.

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
The fifth command initializes the restore request object for AzureDatabaseForPGFlexServer restore.
This example also works for datasource type AzureDatabaseForMySQL.
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
The fourth command initializes the prefix array for each container.
PrefixMatch is a hashtable where each key is the conatiner name being restored and the value is a list of string prfixes for container names for Item level recovery.
The fifth command initializes the target storage account Id.
The sixth command initializes the restore request object for AzureBlob restore with parameters ContainersList, PrefixMatch.
The seventh command triggers validate before restore.
The last command triggers prefix match Item level restore for vaulted blob containers.

### Example 11: Trigger alternate location vaulted restore for AzureKubernetesService
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

# assign necessary permissions from portal
Set-AzContext -SubscriptionId $subId
Set-AzDataProtectionMSIPermission -VaultResourceGroup $resourceGroupName -VaultName $vaultName -PermissionsScope "ResourceGroup" -RestoreRequest $aksALRRestoreRequest -SnapshotResourceGroupId $snapshotResourceGroupId

$validateRestore = Test-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -RestoreRequest $aksALRRestoreRequest -Name $instance.BackupInstanceName 

$restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName  -VaultName $vaultName -BackupInstanceName $instance.BackupInstanceName -Parameter $aksALRRestoreRequest
```

First, we initialize the necessary variables that will be used in the restore script.
Then, we fetch the backup instance and recovery point for the instance.
Next, we initialize the Restore Configuration client object, which is used to set up the restore request client object.
Note that for vaulted restores, we have included the StagingResourceGroupId and StagingStorageAccountId parameters.

We then initialize the restore request object for an Azure Kubernetes Service (AKS) alternate location restore.
After that, we assign the required permissions to the backup vault and the target AKS cluster to enable the restore operation.
Please note that this command is not fully supported for all AKS scenarios; use the Azure portal to assign the necessary permissions.

Finally, we use the Test command to validate the restore configuration and ensure that the necessary permissions are in place before triggering the restore for Azure Kubernetes Service.

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
The name of the backup instance

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

### -IdentityDetailUserAssignedIdentityArmUrl
ARM URL for User Assigned Identity

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

### -IdentityDetailUseSystemAssignedIdentity
Specifies if the BI is protected by System Identity

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: TriggerExpanded
Aliases:

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
Object type of the restore request

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
Restore request object to be initialized using Initialize-AzDataProtectionRestoreRequest cmdlet
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRestoreRequest
Parameter Sets: Trigger
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
The name of the resource group where the backup vault is present

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

### -ResourceGuardOperationRequest
Resource guard operation request in the format similar to \<resourceguard-ARMID\>/dppTriggerRestoreRequests/default.
Use this parameter when the operation is MUA protected.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreTargetInfo
Gets or sets the restore target information
To construct, see NOTES section for RESTORETARGETINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IRestoreTargetInfoBase
Parameter Sets: TriggerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreToSecondaryRegion
Switch parameter to trigger restore to secondary region (Cross region restore)

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

### -SecureToken
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDataStoreType
Type of the source data store

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
Fully qualified Azure Resource Manager ID of the datasource which is being recovered

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
Subscription Id of the backup vault

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

### -Token
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch secure authorization token for different tenant and then convert to string using ConvertFrom-SecureString cmdlet.

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
The name of the backup vault

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRestoreRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IOperationJobExtendedInfo

## NOTES

## RELATED LINKS
