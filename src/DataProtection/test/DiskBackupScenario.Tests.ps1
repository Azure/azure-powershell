$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'DiskBackupScenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'DiskBackupScenario' {
    It 'EndtoEndTest' {
        $vaultName = $env.TestDiskBackupScenario.VaultName
        $rgName = $env.TestDiskBackupScenario.ResourceGroupName
        $diskId = $env.TestDiskBackupScenario.DiskId 
        $snapshotRg = $env.TestDiskBackupScenario.SnapshotRG
        $restoreDiskId = $env.TestDiskBackupScenario.RestoreDiskId
        $policyName = $env.TestDiskBackupScenario.NewPolicyName
        $sub = $env.SubscriptionId

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $defaultPolicy = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
        $policy = New-AzDataProtectionBackupPolicy -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName -Name $policyName -Policy $defaultPolicy
        $backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation centraluseuap -PolicyId $policy.Id -DatasourceId $diskId 
        $backupInstance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $snapshotRg
        $instance = New-AzDataProtectionBackupInstance -ResourceGroupName $rgName -VaultName $vaultName -BackupInstance $backupInstance -SubscriptionId $sub
        $backupInstanceName = $instance.Name

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
        $protectionStatus = $instance.Property.ProtectionStatus.Status
        while($protectionStatus -ne "ProtectionConfigured")
        {
            Start-Sleep -Seconds 5
            $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
            $protectionStatus = $instance.Property.ProtectionStatus.Status
        }

        $null = Backup-AzDataProtectionBackupInstanceAdhoc -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $backupInstanceName -BackupRuleOptionRuleName "BackupHourly" -TriggerOptionRetentionTagOverride "Default"
        $job = Search-AzDataProtectionJobInAzGraph -Subscription $sub -ResourceGroup $rgName -Vault $vaultName -DatasourceType AzureDisk -Operation OnDemandBackup -Status InProgress

        $jobstatus = $job[0].Status
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $job[0].Name -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }

        $rp = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $backupInstanceName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName
        $restoreRequestObject = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation centraluseuap -RestoreType AlternateLocation -RecoveryPoint $rp[0].Name -TargetResourceId $restoreDiskId
        $null = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $backupInstanceName -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Parameter $restoreRequestObject

        $job = Search-AzDataProtectionJobInAzGraph -Subscription $sub -ResourceGroup $rgName -Vault $vaultName -DatasourceType AzureDisk -Operation Restore -Status InProgress

        $jobstatus = $job[0].Status
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $job[0].Name -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }

        $null = Remove-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
        Start-Sleep -Seconds 10
        $null = Remove-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $policyName
     }

}
