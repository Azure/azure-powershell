$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'ElasticSanBackupRestoreScenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'ElasticSanBackupRestoreScenario' -Tag 'LiveOnly' {
    It 'Backs up and restores an Elastic SAN volume' {
        $subId = $env.TestElasticSanScenario.SubscriptionId
        $location = $env.TestElasticSanScenario.Location
        $resourceGroupName = $env.TestElasticSanScenario.ResourceGroupName
        $vaultName = $env.TestElasticSanScenario.VaultName
        $policyName = $env.TestElasticSanScenario.PolicyName
        $volumeGroupName = $env.TestElasticSanScenario.VolumeGroupName
        $sourceVolumeName = $env.TestElasticSanScenario.SourceVolumeName
        $restoredVolumeName = $env.TestElasticSanScenario.RestoredVolumeName
        $volumeGroupId = $env.TestElasticSanScenario.VolumeGroupId
        $snapshotResourceGroupId = $env.TestElasticSanScenario.SnapshotResourceGroupId
        $restoredVolumeId = "$volumeGroupId/volumes/$restoredVolumeName"

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Name -eq $policyName }
        $policy | Should -Not -BeNullOrEmpty

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceId -eq $volumeGroupId }
        if($instance -ne $null) {
            Remove-AzDataProtectionBackupInstance -Name $instance[0].Name -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            Start-TestSleep -Seconds 30
        }

        $existingRestoredVolume = Get-AzResource -ResourceId $restoredVolumeId -ErrorAction SilentlyContinue
        if($existingRestoredVolume -ne $null) {
            Remove-AzResource -ResourceId $restoredVolumeId -Force
        }

        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceSelector @($sourceVolumeName)
        $backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureElasticSAN -DatasourceLocation $location -PolicyId $policy.Id -DatasourceId $volumeGroupId -FriendlyName $sourceVolumeName -SnapshotResourceGroupId $snapshotResourceGroupId -BackupConfiguration $backupConfig

        Set-AzDataProtectionMSIPermission -VaultResourceGroup $resourceGroupName -VaultName $vaultName -BackupInstance $backupInstance -PermissionsScope ResourceGroup -Confirm:$false

        $operationResponse = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstance.Property -NoWait
        $operationId = $operationResponse.Target.Split('/')[-1].Split('?')[0]
        $operationStatus = Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId
        while($operationStatus.Status -eq 'Inprogress') {
            Start-TestSleep -Seconds 10
            $operationStatus = Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId
        }
        $operationStatus.Status | Should Be 'Succeeded'

        $createdInstance = New-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstance
        $createdInstance | Should -Not -BeNullOrEmpty

        $startTime = Get-Date
        do {
            if ((Get-Date) - $startTime -gt (New-TimeSpan -Minutes 15)) {
                throw "Timeout waiting for ProtectionConfigured state for backup instance $($backupInstance.BackupInstanceName)."
            }
            Start-TestSleep -Seconds 15
            $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -Name $backupInstance.BackupInstanceName
        } while($instance.Property.CurrentProtectionState -ne 'ProtectionConfigured')

        $backupRule = $policy.Property.PolicyRule | Where-Object { $_.ObjectType -eq 'AzureBackupRule' } | Select-Object -First 1
        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -BackupRuleOptionRuleName $backupRule.Name -TriggerOptionRetentionTagOverride $backupRule.Trigger.TaggingCriterion[0].TagInfoTagName
        $backupJobId = $backupJob.JobId.Split('/')[-1]

        $backupJobStatus = 'InProgress'
        $startTime = Get-Date
        while($backupJobStatus -eq 'InProgress') {
            if ((Get-Date) - $startTime -gt (New-TimeSpan -Minutes 30)) {
                throw "Timeout waiting for backup job $backupJobId."
            }
            Start-TestSleep -Seconds 30
            $currentJob = Get-AzDataProtectionJob -Id $backupJobId -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $backupJobStatus = $currentJob.Status
        }
        $backupJobStatus | Should Be 'Completed'

        $recoveryPoints = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name
        $recoveryPoints | Should -Not -BeNullOrEmpty

        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @($sourceVolumeName) -ResourceNameOverride @{$sourceVolumeName = $restoredVolumeName}
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureElasticSAN -SourceDataStore OperationalStore -RestoreLocation $location -RestoreType AlternateLocation -RecoveryPoint $recoveryPoints[0].Name -TargetResourceId $volumeGroupId -RestoreConfiguration $restoreConfig -ItemLevelRecovery

        Set-AzDataProtectionMSIPermission -VaultResourceGroup $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -DatasourceType AzureElasticSAN -RestoreRequest $restoreRequest -SnapshotResourceGroupId $snapshotResourceGroupId -PermissionsScope ResourceGroup -Confirm:$false

        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreRequest
        $validateRestore.ObjectType | Should Be 'OperationJobExtendedInfo'

        $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -Parameter $restoreRequest
        $restoreJobId = $restoreJob.JobId.Split('/')[-1]

        $restoreJobStatus = 'InProgress'
        $startTime = Get-Date
        while($restoreJobStatus -eq 'InProgress') {
            if ((Get-Date) - $startTime -gt (New-TimeSpan -Minutes 30)) {
                throw "Timeout waiting for restore job $restoreJobId."
            }
            Start-TestSleep -Seconds 30
            $currentJob = Get-AzDataProtectionJob -Id $restoreJobId -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $restoreJobStatus = $currentJob.Status
        }
        $restoreJobStatus | Should Be 'Completed'

        $restoredVolume = Get-AzResource -ResourceId $restoredVolumeId
        $restoredVolume | Should -Not -BeNullOrEmpty
        $restoredVolume.Name | Should Be $restoredVolumeName
    }
}
