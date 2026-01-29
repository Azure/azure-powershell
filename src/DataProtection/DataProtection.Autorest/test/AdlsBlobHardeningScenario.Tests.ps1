$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AdlsBlobHardeningScenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AdlsBlobHardeningScenario' -Tag 'LiveOnly' {
        It 'ConfigureBackup' {
        $subId = $env.TestAdlsBlobHardeningScenario.SubscriptionId
        $location = $env.TestAdlsBlobHardeningScenario.Location
        $resourceGroupName = $env.TestAdlsBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestAdlsBlobHardeningScenario.VaultName
        $policyName = $env.TestAdlsBlobHardeningScenario.PolicyName
        $storageAccountName = $env.TestAdlsBlobHardeningScenario.StorageAccountName
        $storageAccId = $env.TestAdlsBlobHardeningScenario.StorageAccId

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $pol = Get-AzDataProtectionBackupPolicy -SubscriptionId $subId -VaultName $vaultName -ResourceGroupName $resourceGroupName | Where-Object { $_.Name -match $policyName }

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $storageAcountName }

        # Remove-BI
        if($instance -ne $null){
            Remove-AzDataProtectionBackupInstance -Name $instance[0].Name -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        }

        Start-TestSleep -Seconds 8

        # new backup config and initialize BI

        $storageAccount = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName
        $containers=Get-AzStorageContainer -Context $storageAccount.Context

        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureDataLakeStorage -VaultedBackupContainer $containers.Name
        $backupConfig.ContainersList = $backupConfig.ContainersList[1,3,4]

        $backupInstanceClientObject = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDataLakeStorage -DatasourceLocation $vault.Location -PolicyId $pol[0].Id -DatasourceId $storageAccId -BackupConfiguration $backupConfig

        # assign permissions and validate
        Set-AzDataProtectionMSIPermission -VaultResourceGroup $resourceGroupName -VaultName $vaultName -BackupInstance $backupInstanceClientObject -PermissionsScope ResourceGroup

        $operationResponse = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstanceClientObject.Property -NoWait
        $operationId = $operationResponse.Target.Split("/")[-1].Split("?")[0]

        While((Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId).Status -eq "Inprogress"){
	        Start-TestSleep -Seconds 10
        }

        # backup
        $backupnstanceCreate = New-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstanceClientObject

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $storageAcountName }

        while($instance.Property.CurrentProtectionState -ne "ProtectionConfigured"){
            Start-TestSleep -Seconds 10
            $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $storageAcountName }
        }

        $instance[0].Name -match $storageAcountName | Should be $true

        # Trigger Backup
        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -BackupRuleOptionRuleName $pol[0].Property.PolicyRule[-1].Name -TriggerOptionRetentionTagOverride $pol[0].Property.PolicyRule[-1].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $backupJob.JobId.Split("/")[-1]
        $jobid -ne $null | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
    }

    It 'AdlsBlobVaultedILR' {        
        $subId = $env.TestAdlsBlobHardeningScenario.SubscriptionId
        $resourceGroupName = $env.TestAdlsBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestAdlsBlobHardeningScenario.VaultName
        
        $storageAccountName = $env.TestAdlsBlobHardeningScenario.StorageAccountName
        $targetStorageAccId = $env.TestAdlsBlobHardeningScenario.TargetStorageAccId
        $targetStorageAccountRGName = $env.TestAdlsBlobHardeningScenario.TargetStorageAccountRGName
        $targetStorageAccountName = $env.TestAdlsBlobHardeningScenario.TargetStorageAccountName

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $storageAccountName }

        $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

        $backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList

        # remove containers in target storage account
        Set-AzContext -SubscriptionId $subId
        $targetStorageAccount = Get-AzStorageAccount -ResourceGroupName $targetStorageAccountRGName -Name $targetStorageAccountName
        $targetContainers = Get-AzStorageContainer -Context $targetStorageAccount.Context | Where-Object { $_.Name -match "^con" }
        foreach($containerName in $targetContainers.Name){
            Remove-AzStorageContainer -Context $targetStorageAccount.Context -Name $containerName -Confirm:$false -Force
        }

        $prefMatch = @{
            $backedUpContainers[0] = @("a", "B")
            $backedUpContainers[1]= @("c")
        }


        # Initialize Restore
        $restoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDataLakeStorage -SourceDataStore VaultStore -RestoreLocation $vault.Location -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetStorageAccId -ContainersList $backedUpContainers[0,1] -PrefixMatch $prefMatch
	
        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreReq
        $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -Parameter $restoreReq

        $jobid = $restoreJob.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName

        ($currentjob.Status -in "InProgress", "Completed") | Should be $true

        # Wait for job completion
        Write-Host "Waiting for restore job to complete..."
        $jobstatus = "InProgress"
        $timeout = 1800  # 30 minutes timeout
        $elapsed = 0
        while($jobstatus -eq "InProgress" -and $elapsed -lt $timeout)
        {
            #Start-TestSleep -Seconds 30 uncomment for PR
            Start-Sleep -Seconds 30
            $elapsed += 30
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
            Write-Host "Job Status: $jobstatus (Elapsed: $elapsed seconds)"
        }

        # Validate job completed successfully
        $jobstatus | Should be "Completed"

        Write-Host "AdlsBlobVaultedILR test completed successfully - all validations passed!"
    }

    It 'TriggerRestore' -skip {
        # TODO: OLR should throw an error in case of vaulted backups

        $subId = $env.TestAdlsBlobHardeningScenario.SubscriptionId
        $crossSubscriptionId = $env.TestAdlsBlobHardeningScenario.CrossSubscriptionId
        $location = $env.TestAdlsBlobHardeningScenario.Location
        $resourceGroupName = $env.TestAdlsBlobHardeningScenario.ResourceGroupName
        $vaultName = $env.TestAdlsBlobHardeningScenario.VaultName
        $policyName = $env.TestAdlsBlobHardeningScenario.PolicyName
        $storageAccountName = $env.TestAdlsBlobHardeningScenario.StorageAccountName
        $storageAccId = $env.TestAdlsBlobHardeningScenario.StorageAccId
        $targetStorageAccId = $env.TestAdlsBlobHardeningScenario.TargetStorageAccId
        $targetCrossSubStorageAccId = $env.TestAdlsBlobHardeningScenario.TargetCrossSubStorageAccId
        $targetStorageAccountName = $env.TestAdlsBlobHardeningScenario.TargetStorageAccountName
        $targetStorageAccountRGName = $env.TestAdlsBlobHardeningScenario.TargetStorageAccountRGName
        $targetCrossSubStorageAccountName = $env.TestAdlsBlobHardeningScenario.TargetCrossSubStorageAccountName
        $targetCrossSubStorageAccountRGName = $env.TestAdlsBlobHardeningScenario.TargetCrossSubStorageAccountRGName

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $storageAcountName }
        $rp = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

        $backedUpContainers = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList

        # remove containers in target cross sub storage account
        Set-AzContext -SubscriptionId $crossSubscriptionId
        $targetCrossSubStorageAccount = Get-AzStorageAccount -ResourceGroupName $targetCrossSubStorageAccountRGName -Name $targetCrossSubStorageAccountName
        $targetCrossSubContainers = Get-AzStorageContainer -Context $targetCrossSubStorageAccount.Context | Where-Object { $_.Name -match "con" }
        foreach($crossSubContainerName in $targetCrossSubContainers.Name){
            Remove-AzStorageContainer -Context $targetCrossSubStorageAccount.Context -Name $crossSubContainerName -Confirm:$false -Force
        }

        # remove containers in target storage account
        Set-AzContext -SubscriptionId $subId
        $targetStorageAccount = Get-AzStorageAccount -ResourceGroupName $targetStorageAccountRGName -Name $targetStorageAccountName
        $targetContainers = Get-AzStorageContainer -Context $targetStorageAccount.Context | Where-Object { $_.Name -match "con" }
        foreach($containerName in $targetContainers.Name){
            Remove-AzStorageContainer -Context $targetStorageAccount.Context -Name $containerName -Confirm:$false -Force
        }

        # Initialize Restore
        $restoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDataLakeStorage -SourceDataStore VaultStore -RestoreLocation $vault.Location -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetStorageAccId -ContainersList $backedUpContainers[0,1]

        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreReq
        $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -Parameter $restoreReq

        $restoreReqCSR = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDataLakeStorage -SourceDataStore VaultStore -RestoreLocation $vault.Location -RecoveryPoint $rp[0].Name -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId $targetCrossSubStorageAccId -ContainersList $backedUpContainers[0,1]

        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreReqCSR
        $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJobCSR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -Parameter $restoreReqCSR
    }
}