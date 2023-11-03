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
        $sub = $env.TestTriggerBackup.SubscriptionId
        $rgName = $env.TestTriggerBackup.ResourceGroupName
        $vaultName = $env.TestTriggerBackup.VaultName
        $diskId = $env.TestTriggerBackup.DiskId
        $backupRuleName = $env.TestTriggerBackup.BackupRuleName

        $instances = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $instance = $instances | where-object {$_.Property.DataSourceInfo.ResourceId -eq $diskId}
        $job = Backup-AzDataProtectionBackupInstanceAdhoc -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $instance.Name -BackupRuleOptionRuleName $backupRuleName -TriggerOptionRetentionTagOverride Default

        $jobid = $job.JobId.Split("/")[-1]

        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-Sleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }

        $jobstatus | Should be "Completed"
    }

    It 'OssBackup' {
        # Test trigger Backup for Oss DB
        # Delete this test 
        $sub = $env.TestOssBackupScenario.SubscriptionId
        $rgName = $env.TestOssBackupScenario.ResourceGroupName
        $vaultName = $env.TestOssBackupScenario.VaultName
        $policyName = $env.TestOssBackupScenario.PolicyName   
        $dataSourceId = $env.TestOssBackupScenario.OssDbId
        $serverName = $env.TestOssBackupScenario.OssServerName
        $keyVault = $env.TestOssBackupScenario.KeyVault
        $secretURI = $env.TestOssBackupScenario.SecretURI
        
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName  -VaultName  $vaultName
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $policyName}

        $instance  = Get-AzDataProtectionBackupInstance -Subscription $sub -ResourceGroup $rgName -Vault $vaultName | Where-Object {($_.Property.DataSourceInfo.Type -eq "Microsoft.DBforPostgreSQL/servers/databases") -and ($_.Property.DataSourceInfo.ResourceId -match $serverName)}
        
        ($instance -ne $null) | Should be $true

        $backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName -BackupRuleOptionRuleName $policy.Property.PolicyRule[0].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[0].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $backupJob.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -ne "Completed")
        {
            Start-Sleep -Seconds 10
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
