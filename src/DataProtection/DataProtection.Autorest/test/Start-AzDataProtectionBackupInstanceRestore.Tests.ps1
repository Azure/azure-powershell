$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzDataProtectionBackupInstanceRestore.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzDataProtectionBackupInstanceRestore' {
    It 'PGFlexRestore' {
        $subId = $env.TestPGFlexRestore.SubscriptionId
        $resourceGroupName = $env.TestPGFlexRestore.ResourceGroupName
        $vaultName = $env.TestPGFlexRestore.VaultName
        $policyName = $env.TestPGFlexRestore.PolicyName
        $targetContainerURI = $env.TestPGFlexRestore.TargetContainerURI
        $backupInstanceName = $env.TestPGFlexRestore.BackupInstanceName

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        
        $instance  =  Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $backupInstanceName }
        
        ($instance -ne $null) | Should be $true

        # Trigger Backup         
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subId -VaultName $vaultName -ResourceGroupName $resourceGroupName -Name $policyName

        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -BackupRuleOptionRuleName $policy.Property.PolicyRule[0].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[0].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $backupJob.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-Sleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"

        Start-Sleep -Seconds 5

        # Database restore 
        $rps = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName

        $pgFlexRestoreReqFiles = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPGFlexServer -SourceDataStore VaultStore -RestoreLocation $vault.Location -RestoreType RestoreAsFiles -RecoveryPoint $rps[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI

        # MuA
        $proxy = Get-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId
        $operationRequests = $proxy.ResourceGuardOperationDetail.DefaultResourceRequest
        $resourceGuardOperationRequest = $operationRequests | Where-Object { $_ -match "dppTriggerRestoreRequests" }

        $restoreFilesJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName  -VaultName $VaultName -BackupInstanceName $instance.BackupInstanceName -Parameter $pgFlexRestoreReqFiles -ResourceGuardOperationRequest $resourceGuardOperationRequest       

        $jobid = $restoreFilesJob.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-Sleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
    }

    It 'MySQLRestore' -skip {
        $subId = $env.TestMySQLRestore.SubscriptionId
        $resourceGroupName = $env.TestMySQLRestore.ResourceGroupName
        $vaultName = $env.TestMySQLRestore.VaultName
        $policyName = $env.TestMySQLRestore.PolicyName
        $targetContainerURI = $env.TestMySQLRestore.TargetContainerURI
        $backupInstanceName = $env.TestMySQLRestore.BackupInstanceName

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        
        $instance  =  Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -match $backupInstanceName }
        
        ($instance -ne $null) | Should be $true

        # Trigger Backup         
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subId -VaultName $vaultName -ResourceGroupName $resourceGroupName -Name $policyName

        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -BackupRuleOptionRuleName $policy.Property.PolicyRule[1].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[1].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $backupJob.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-Sleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"

        Start-Sleep -Seconds 5

        # Database restore 
        $rps = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.BackupInstanceName -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName

        $mySQLRestoreReqFiles = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForMySQL -SourceDataStore VaultStore -RestoreLocation $vault.Location -RestoreType RestoreAsFiles -RecoveryPoint $rps[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI

        $restoreFilesJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName  -VaultName $VaultName -BackupInstanceName $instance.BackupInstanceName -Parameter $mySQLRestoreReqFiles        

        $jobid = $restoreFilesJob.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-Sleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
    }

    It 'CrossRegionRestoreAsDatabase' -skip {
        $resourceGroupName  = $env.TestCrossRegionRestoreScenario.ResourceGroupName
        $vaultName = $env.TestCrossRegionRestoreScenario.VaultName
        $subscriptionId = $env.TestCrossRegionRestoreScenario.SubscriptionId
        $targetResourceId = $env.TestCrossRegionRestoreScenario.TargetResourceId
        $secretURI = $env.TestCrossRegionRestoreScenario.SecretURI

        $vault = Search-AzDataProtectionBackupVaultInAzGraph -ResourceGroup $resourceGroupName -Subscription $subscriptionId -Vault $vaultName -UseSecondaryRegion

        $instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup  $resourceGroupName  -Vault $vaultName -DatasourceType AzureDatabaseForPostgreSQL

        $recoveryPointsCrr = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance[0].Name -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -UseSecondaryRegion

        $OssRestoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.ReplicatedRegion[0] -RestoreType AlternateLocation -RecoveryPoint $recoveryPointsCrr[0].Property.RecoveryPointId -TargetResourceId $targetResourceId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault

        # assumes permissions are preassigned
        $validateCRR = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -RestoreRequest $OssRestoreReq -RestoreToSecondaryRegion

        $validateCRR.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJobCRR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance[0].Name -Parameter $OssRestoreReq -RestoreToSecondaryRegion

        $jobid = $restoreJobCRR.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 10

            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -UseSecondaryRegion

            ($currentjob.OperationCategory -eq "CrossRegionRestore") | Should be $true

            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
    }

    It 'CrossRegionRestoreAsFiles' -skip {
        $recordDate = $env.RecordDate
        $resourceGroupName  = $env.TestCrossRegionRestoreScenario.ResourceGroupName
        $vaultName = $env.TestCrossRegionRestoreScenario.VaultName
        $subscriptionId = $env.TestCrossRegionRestoreScenario.SubscriptionId
        $targetContainerURI = $env.TestCrossRegionRestoreScenario.TargetContainerURI
        $fileNamePrefix = $env.TestCrossRegionRestoreScenario.FileNamePrefix + "-" + $recordDate

        $vault = Search-AzDataProtectionBackupVaultInAzGraph -ResourceGroup $resourceGroupName -Subscription $subscriptionId -Vault $vaultName -UseSecondaryRegion

        $instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup  $resourceGroupName  -Vault $vaultName -DatasourceType AzureDatabaseForPostgreSQL

        $recoveryPointsCrr = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance[0].Name -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -UseSecondaryRegion

        $OssRestoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.ReplicatedRegion[0] -RestoreType RestoreAsFiles -RecoveryPoint $recoveryPointsCrr[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix

        # assumes permissions are preassigned
        $validateCRR = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -RestoreRequest $OssRestoreReq -RestoreToSecondaryRegion

        $validateCRR.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJobCRR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance[0].Name -Parameter $OssRestoreReq -RestoreToSecondaryRegion

        $jobid = $restoreJobCRR.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -ne "Completed")
        {
            Start-TestSleep -Seconds 10

            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -UseSecondaryRegion

            ($currentjob.OperationCategory -eq "CrossRegionRestore") | Should be $true

            $jobstatus = $currentjob.Status
        }
    }

    It 'CrossSubscriptionRestore' {
        $recordDate = $env.RecordDate
        $resourceGroupName  = $env.TestCrossSubscriptionRestoreScenario.ResourceGroupName
        $vaultName = $env.TestCrossSubscriptionRestoreScenario.VaultName
        $subscriptionId = $env.TestCrossSubscriptionRestoreScenario.SubscriptionId
        $targetContainerArmId = $env.TestCrossSubscriptionRestoreScenario.TargetContainerArmId
        $targetContainerURI = $env.TestCrossSubscriptionRestoreScenario.TargetContainerURI
        $fileNamePrefix = $env.TestCrossSubscriptionRestoreScenario.FileNamePrefix + "-" + $recordDate

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceType -match "Postgre" }

        $rp = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance[0].BackupInstanceName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName

        $ossRestoreReqFiles = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.Location -RestoreType RestoreAsFiles -RecoveryPoint $rp[0].Property.RecoveryPointId -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix -TargetResourceIdForRestoreAsFile $targetContainerArmId

        # assumes permissions are preassigned
        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance[0].Name -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -RestoreRequest $ossRestoreReqFiles
        $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

        $restoreJobCSR = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.BackupInstanceName -Parameter $ossRestoreReqFiles

        $jobid = $restoreJobCSR.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
    }

    It 'OssRestore' {
        # Test trigger Backup for Oss DB
        $recordDate = $env.RecordDate
        $sub = $env.TestOssBackupScenario.SubscriptionId
        $rgName = $env.TestOssBackupScenario.ResourceGroupName
        $vaultName = $env.TestOssBackupScenario.VaultName
        $policyName = $env.TestOssBackupScenario.PolicyName
        $dataSourceId = $env.TestOssBackupScenario.OssDbId
        $serverName = $env.TestOssBackupScenario.OssServerName
        $keyVault = $env.TestOssBackupScenario.KeyVault
        $secretURI = $env.TestOssBackupScenario.SecretURI
        $targetResourceId = $env.TestOssBackupScenario.TargetResourceId + "-" + $recordDate
        $targetContainerURI = $env.TestOssBackupScenario.TargetContainerURI
        $fileNamePrefix = $env.TestOssBackupScenario.FileNamePrefix + "-" + $recordDate

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName  -VaultName  $vaultName

        $instance  = Get-AzDataProtectionBackupInstance -Subscription $sub -ResourceGroup $rgName -Vault $vaultName | Where-Object {($_.Property.DataSourceInfo.Type -eq "Microsoft.DBforPostgreSQL/servers/databases") -and ($_.Property.DataSourceInfo.ResourceId -match $serverName)}

        ($instance -ne $null) | Should be $true

        # Trigger Backup
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | Where-Object {$_.Name -eq $policyName}

        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName -BackupRuleOptionRuleName $policy.Property.PolicyRule[0].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[0].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $backupJob.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"

        Start-TestSleep -Seconds 5

        # Database restore
        $rps = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.Name -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName

        $OssRestoreReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.Location -RestoreType AlternateLocation -RecoveryPoint $rps[0].Property.RecoveryPointId -TargetResourceId $targetResourceId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault

        $restoreJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.Name -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Parameter $OssRestoreReq

        Start-TestSleep -Seconds 10

        $jobid = $restoreJob.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"

        Start-TestSleep -Seconds 5

        # RestoreAsFiles
        $rps = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.Name -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName

        $OssRestoreReqFiles = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDatabaseForPostgreSQL -SourceDataStore VaultStore -RestoreLocation $vault.Location -RestoreType RestoreAsFiles -RecoveryPoint $rps[0].Property.RecoveryPointId  -TargetContainerURI $targetContainerURI -FileNamePrefix $fileNamePrefix

        $restoreFilesJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instance.Name -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Parameter $OssRestoreReqFiles

        $jobid = $restoreFilesJob.JobId.Split("/")[-1]
        ($jobid -ne $null) | Should be $true

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 10
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
    }    

    It 'TriggerExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Trigger' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TriggerViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TriggerViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
