$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataProtectionBackupInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataProtectionBackupInstance' {
    It '__AllParameterSets' {
        $sub = $env.TestOssBackupScenario.SubscriptionId
        $rgName = $env.TestOssBackupScenario.ResourceGroupName
        $vaultName = $env.TestOssBackupScenario.VaultName
        $policyName = $env.TestOssBackupScenario.PolicyName
        $dataSourceId = $env.TestOssBackupScenario.OssDbId
        $serverName = $env.TestOssBackupScenario.OssServerName
        $keyVault = $env.TestOssBackupScenario.KeyVault
        $secretURI = $env.TestOssBackupScenario.SecretURI

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName  -VaultName  $vaultName
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | Where-Object {$_.Name -eq $policyName}

        $instance  = Get-AzDataProtectionBackupInstance -Subscription $sub -ResourceGroup $rgName -Vault $vaultName | Where-Object {($_.Property.DataSourceInfo.Type -eq "Microsoft.DBforPostgreSQL/servers/databases") -and ($_.Property.DataSourceInfo.ResourceId -match $serverName)}

        if($instance -eq $null){
            # will come here only if the instance is not protected (ideally won't come here')
            # remove command for backup instance below
            # Remove-AzDataProtectionBackupInstance -Name $instance.Name -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName

            $backupInstanceClientObject = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPostgreSQL -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $dataSourceId -SecretStoreURI $secretURI  -SecretStoreType AzureKeyVault

            $backupnstanceCreate = New-AzDataProtectionBackupInstance -ResourceGroupName $rgName -VaultName $vaultName -BackupInstance $backupInstanceClientObject -SubscriptionId $sub
        }

        $instance  = Get-AzDataProtectionBackupInstance -Subscription $sub -ResourceGroup $rgName -Vault $vaultName | Where-Object {($_.Property.DataSourceInfo.Type -eq "Microsoft.DBforPostgreSQL/servers/databases") -and ($_.Property.DataSourceInfo.ResourceId -match $serverName)}

        ($instance -ne $null) | Should be $true
    }

    It 'AzureKubernetesServiceBackup' {
        $sub = $env.TestAksRestoreScenario.SubscriptionId
        $rgName = $env.TestAksRestoreScenario.ResourceGroupName
        $vaultName = $env.TestAksRestoreScenario.VaultName
        $policyName = $env.TestAksRestoreScenario.PolicyName
        $dataSourceLocation = $env.TestAksRestoreScenario.DataSourceLocation
        $sourceClusterId = $env.TestAksRestoreScenario.SourceClusterId
        $targetClusterId = $env.TestAksRestoreScenario.TargetClusterId
        $snapshotResourceGroupId = $env.TestAksRestoreScenario.SnapshotResourceGroupId
        $friendlyName = $env.TestAksRestoreScenario.FriendlyName
        $clusterName = $env.TestAksRestoreScenario.ClusterName

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $backupInstance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceId -eq $sourceClusterId }
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | Where-Object {$_.Name -eq $policyName}

        # configure backup - create backup instance if it doesn't exist
        if ($null -eq $backupInstance) {
            $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService

            $backupInstanceInit = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService -DatasourceLocation $dataSourceLocation -PolicyId $policy.Id -DatasourceId $sourceClusterId -SnapshotResourceGroupId $snapshotResourceGroupId -FriendlyName $friendlyName -BackupConfiguration $backupConfig

            # set MSI permissions (may fail if user lacks role assignment permissions but roles are already configured)
            try {
                Set-AzDataProtectionMSIPermission -BackupInstance $backupInstanceInit -VaultResourceGroup $rgName -VaultName $vaultName -PermissionsScope "ResourceGroup" -Confirm:$false
            }
            catch {
                Write-Host "Set-AzDataProtectionMSIPermission failed (permissions may already be configured): $_"
            }

            # enable protection
            $tag = @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="Testing";"DeleteBy"="12-2027"}
            $biCreate = New-AzDataProtectionBackupInstance -ResourceGroupName $rgName -VaultName $vaultName -BackupInstance $backupInstanceInit -SubscriptionId $sub -Tag $tag
        }

        # validate bi created
        $backupInstance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceId -eq $sourceClusterId }
        ($backupInstance -ne $null) | Should be $true

        $maxRetries = 30
        $retryCount = 0
        while($backupInstance.Property.ProtectionStatus.Status -ne "ProtectionConfigured" -and $retryCount -lt $maxRetries)
        {
            Start-TestSleep -Seconds 10
            $retryCount++
            $backupInstance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceId -eq $sourceClusterId }
        }
        $backupInstance.Property.ProtectionStatus.Status | Should be "ProtectionConfigured"

        $policyRule = $policy.Property.PolicyRule | Where-Object { $_.ObjectType -eq "AzureBackupRule"}

        # adhoc backup
        Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $backupInstance.BackupInstanceName -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupRuleOptionRuleName  $policyRule.Name -TriggerOptionRetentionTagOverride $policyRule.Trigger.TaggingCriterion[0].TagInfoTagName

        Start-TestSleep -Seconds 30

        # get recovery point
        $rps = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $backupInstance.BackupInstanceName -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName

        # restore
        if($rps -ne $null){
            $aksRestoreCriteria = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -PersistentVolumeRestoreMode RestoreWithVolumeData  -IncludeClusterScopeResource $true # -NamespaceMapping  @{"default"="restore-default";"ns1"="ns2"}

            $aksRestoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureKubernetesService  -SourceDataStore OperationalStore -RestoreLocation $dataSourceLocation -RestoreType OriginalLocation -RecoveryPoint $rps[0].Property.RecoveryPointId -RestoreConfiguration $aksRestoreCriteria -BackupInstance $backupInstance

            # Set-AzDataProtectionMSIPermission -VaultResourceGroup $rgName -VaultName $vaultName -PermissionsScope "ResourceGroup" -RestoreRequest $aksRestoreRequest -SnapshotResourceGroupId $snapshotResourceGroupId

            $validateRestore = Test-AzDataProtectionBackupInstanceRestore -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -RestoreRequest $aksRestoreRequest -Name $backupInstance.BackupInstanceName

            $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"

            $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $backupInstance.BackupInstanceName -Parameter $aksRestoreRequest

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
        }
    }
}
