﻿$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
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
        $policyId = "/subscriptions/" + $sub + "/resourceGroups/" + $rgName + "/providers/Microsoft.DataProtection/backupVaults/" + $vaultName + "/backupPolicies/" + $policyName
        $backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation centraluseuap -PolicyId $policyId -DatasourceId $diskId 
        $backupInstance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $snapshotRg
        
        $instances = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $instance = $instances | where-Object {$_.Property.DataSourceInfo.ResourceId -eq $diskId}
        $backupInstanceName = $instance.Name

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
        $protectionStatus = $instance.Property.ProtectionStatus.Status
        while($protectionStatus -ne "ProtectionConfigured")
        {
            Start-Sleep -Seconds 5
            $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
            $protectionStatus = $instance.Property.ProtectionStatus.Status
        }

        $job = Backup-AzDataProtectionBackupInstanceAdhoc -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $backupInstanceName -BackupRuleOptionRuleName "BackupHourly" -TriggerOptionRetentionTagOverride "Default"
        $jobid = $job.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }

        $rp = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $backupInstanceName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName
        $restoreRequestObject = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation centraluseuap -RestoreType AlternateLocation -RecoveryPoint $rp[0].Name -TargetResourceId $restoreDiskId
        $job = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $backupInstanceName -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Parameter $restoreRequestObject

        $jobid = $job.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
     }

}
