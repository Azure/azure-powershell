$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Backup-AzDataProtectionBackupInstanceAdhoc.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Backup-AzDataProtectionBackupInstanceAdhoc' {
    It 'BackupExpanded' {
        $sub = $env.SubscriptionId
        $rgName = $env.TestTriggerBackup.ResourceGroupName
        $vaultName = $env.TestTriggerBackup.VaultName
        $diskId = $env.TestTriggerBackup.DiskId
        $backupRuleName = $env.TestTriggerBackup.BackupRuleName

        $instances = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $instance = $instances | where-object {$_.Property.DataSourceInfo.ResourceId -eq $diskId}
        $job = Backup-AzDataProtectionBackupInstanceAdhoc -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $instance.Name -BackupRuleOptionRuleName $backupRuleName -TriggerOptionRetentionTagOverride Default

        $jobid = $job.JobId.Split("/")[-1]

        $jobstatus = "InProgress"
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
    }

    It 'Backup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackupViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
