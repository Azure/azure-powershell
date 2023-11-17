$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'BlobHardeningScenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'BlobHardeningScenario' {
    It 'ConfigureBackup' -skip {
        $subId = $env.TestBlobHardeningScenario.SubscriptionId
        $location = $env.TestBlobHardeningScenario.Location
        $resourceGroupName = $env.TestBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestBlobHardeningScenario.VaultName
        $policyName = $env.TestBlobHardeningScenario.PolicyName
        $storageAccountName = $env.TestBlobHardeningScenario.StorageAccountName
        $storageAccId = $env.TestBlobHardeningScenario.StorageAccId

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $pol = Get-AzDataProtectionBackupPolicy -SubscriptionId $subId -VaultName $vaultName -ResourceGroupName $resourceGroupName | Where { $_.Name -match $policyName }
        
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where { $_.Name -match $storageAcountName }

        # Remove-BI
        if($instance -ne $null){
            Remove-AzDataProtectionBackupInstance -Name $instance[0].Name -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        }

        Start-Sleep -Seconds 8

        # new backup config and initialize BI
                        
        $storageAccount = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName 
        $containers=Get-AzStorageContainer -Context $storageAccount.Context
        
        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -VaultedBackupContainer $containers.Name        
        $backupConfig.ContainersList = $backupConfig.ContainersList[1,3,4]

        $backupInstanceClientObject = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureBlob -DatasourceLocation $vault.Location -PolicyId $pol[0].Id -DatasourceId $storageAccId -BackupConfiguration $backupConfig

        # assign permissions and validate 
        Set-AzDataProtectionMSIPermission -VaultResourceGroup $resourceGroupName -VaultName $vaultName -BackupInstance $backupInstanceClientObject -PermissionsScope ResourceGroup

        $operationResponse = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstanceClientObject.Property -NoWait
        $operationId = $operationResponse.Target.Split("/")[-1].Split("?")[0]
        
        While((Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId).Status -eq "Inprogress"){
	        Start-Sleep -Seconds 10
        }

        # backup
        $backupnstanceCreate = New-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstanceClientObject

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where { $_.Name -match $storageAcountName }

        while($instance.Property.CurrentProtectionState -ne "ProtectionConfigured"){
            Start-Sleep -Seconds 10
            $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where { $_.Name -match $storageAcountName }
        }

        $instance[0].Name -match $storageAcountName | Should be $true

        # Trigger Backup
        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -BackupRuleOptionRuleName $pol[0].Property.PolicyRule[-1].Name -TriggerOptionRetentionTagOverride $pol[0].Property.PolicyRule[-1].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $backupJob.JobId.Split("/")[-1]
        $jobid -ne $null | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"        
    }

    It 'TriggerRestore' -skip {
        # DppRef: OLR should throw an error in case of vaulted backups 

        $subId = $env.TestBlobHardeningScenario.SubscriptionId
        $crossSubscriptionId = $env.TestBlobHardeningScenario.CrossSubscriptionId
        $location = $env.TestBlobHardeningScenario.Location
        $resourceGroupName = $env.TestBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestBlobHardeningScenario.VaultName
        $policyName = $env.TestBlobHardeningScenario.PolicyName
        $storageAccountName = $env.TestBlobHardeningScenario.StorageAccountName
        $storageAccId = $env.TestBlobHardeningScenario.StorageAccId
        $targetStorageAccId = $env.TestBlobHardeningScenario.TargetStorageAccId
        $targetCrossSubStorageAccId = $env.TestBlobHardeningScenario.TargetCrossSubStorageAccId
        $targetStorageAccountName = $env.TestBlobHardeningScenario.TargetStorageAccountName
        $targetStorageAccountRGName = $env.TestBlobHardeningScenario.TargetStorageAccountRGName
        $targetCrossSubStorageAccountName = $env.TestBlobHardeningScenario.TargetCrossSubStorageAccountName
        $targetCrossSubStorageAccountRGName = $env.TestBlobHardeningScenario.TargetCrossSubStorageAccountRGName

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where { $_.Name -match $storageAcountName }
        $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

        $backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList

        # remove containers in target cross sub storage account
        Set-AzContext -SubscriptionId $crossSubscriptionId
        $targetCrossSubStorageAccount = Get-AzStorageAccount -ResourceGroupName $targetCrossSubStorageAccountRGName -Name $targetCrossSubStorageAccountName
        $targetCrossSubContainers = Get-AzStorageContainer -Context $targetCrossSubStorageAccount.Context | Where { $_.Name -match "con" }
        foreach($crossSubContainerName in $targetCrossSubContainers.Name){
            Remove-AzStorageContainer -Context $targetCrossSubStorageAccount.Context -Name $crossSubContainerName -Confirm:$false -Force
        }
        
        # remove containers in target storage account
        Set-AzContext -SubscriptionId $subId
        $targetStorageAccount = Get-AzStorageAccount -ResourceGroupName $targetStorageAccountRGName -Name $targetStorageAccountName
        $targetContainers = Get-AzStorageContainer -Context $targetStorageAccount.Context | Where { $_.Name -match "con" }
        foreach($containerName in $targetContainers.Name){
            Remove-AzStorageContainer -Context $targetStorageAccount.Context -Name $containerName -Confirm:$false -Force
        }

        # Initialize Restore
        $restoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore VaultStore -RestoreLocation $vault.Location -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetStorageAccId -ContainersList $backedUpContainers[0,1]

        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreReq
        $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.BackupInstanceName -Parameter $restoreReq
        
        $restoreReqCSR = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore VaultStore -RestoreLocation $vault.Location -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetCrossSubStorageAccId -ContainersList $backedUpContainers[0,1]

        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreReqCSR
        $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJobCSR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.BackupInstanceName -Parameter $restoreReqCSR
    }
}
