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
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $policyName}
        
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
        $sub = $env.TestAksBackupScenario.SubscriptionId
        $rgName = $env.TestAksBackupScenario.ResourceGroupName
        $vaultName = $env.TestAksBackupScenario.VaultName
        $policyName = $env.TestAksBackupScenario.PolicyName
        $dataSourceLocation = $env.TestAksBackupScenario.DataSourceLocation
        $sourceClusterId = $env.TestAksBackupScenario.SourceClusterId
        $targetClusterId = $env.TestAksBackupScenario.TargetClusterId
        $snapshotResourceGroupId = $env.TestAksBackupScenario.SnapshotResourceGroupId
        $friendlyName = $env.TestAksBackupScenario.FriendlyName
        
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName        
        $backupInstance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName | Where { $_.Name -match "aks-pstest" }        
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | where {$_.Name -eq $policyName}

        # remove permissions
        #
        # if($backupInstance -ne $null){
        #    Remove-azdataProtectionBackupInstance -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Name $backupInstance.BackupInstanceName
        # }
        # 
        # $roles = Get-AzRoleAssignment -ObjectId $vault.Identity.PrincipalId
        # foreach ($role in $roles){
        #    Remove-AzRoleAssignment -ObjectId $vault.Identity.PrincipalId -RoleDefinitionName $role.RoleDefinitionName -Scope $role.Scope
        # }
        # 
        # $aksCluster = Get-AzAksCluster -Id $backupInstance.Property.DataSourceInfo.ResourceId -SubscriptionId $sub        
        # $dataSourceMSIRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $aksCluster.Identity.PrincipalId
        # Remove-AzRoleAssignment -ObjectId $aksCluster.Identity.PrincipalId -RoleDefinitionName "Contributor" -Scope $snapshotResourceGroupId

        # configure backup        
        if($backupInstance -eq $null){
            $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService # -LabelSelector "x=y","foo=bar"

            $backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService  -DatasourceLocation $dataSourceLocation -PolicyId $policy.Id -DatasourceId $sourceClusterId -SnapshotResourceGroupId $snapshotResourceGroupId -FriendlyName $friendlyName -BackupConfiguration $backupConfig
                        
            ## set MSI permissions
            # Set-AzDataProtectionMSIPermission -BackupInstance $backupInstance -VaultResourceGroup $rgName -VaultName $vaultName -PermissionsScope "ResourceGroup"

            ## enable protection
            $tag= @{"MABUsed"="Yes";"Owner"="hiaga";"Purpose"="Testing";"DeleteBy"="06-2027"}
            $biCreate = New-AzDataProtectionBackupInstance -ResourceGroupName $rgName -VaultName $vaultName -BackupInstance $backupInstance -SubscriptionId $sub -Tag $tag        
        }
        
        # validate bi created
        $backupInstance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName | Where { $_.Name -match "aks-pstest" }
        ($backupInstance -ne $null) | Should be $true
                
        while($backupInstance.Property.ProtectionStatus.Status -ne "ProtectionConfigured")
        {
            Start-Sleep -Seconds 10
            $backupInstance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName | Where { $_.Name -match "aks-pstest" }
        }

        # adhoc backup
        Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $backupInstance.BackupInstanceName  -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupRuleOptionRuleName  $policy.Property.PolicyRule[1].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[1].Trigger.TaggingCriterion[0].TagInfoTagName
         
        Start-Sleep -Seconds 30

        # get recovery point
        $rps = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $backupInstance.BackupInstanceName -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName 

        # restore
        if($rps -ne $null){
            $aksRestoreCriteria = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService  -PersistentVolumeRestoreMode RestoreWithVolumeData  -IncludeClusterScopeResource $true # -NamespaceMapping  @{"default"="restore-default";"ns1"="ns2"}

            $aksRestoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureKubernetesService  -SourceDataStore OperationalStore -RestoreLocation $dataSourceLocation -RestoreType OriginalLocation -RecoveryPoint $rps[0].Property.RecoveryPointId -RestoreConfiguration $aksRestoreCriteria -BackupInstance $backupInstance 

            # Set-AzDataProtectionMSIPermission -VaultResourceGroup $rgName -VaultName $vaultName -PermissionsScope "ResourceGroup" -RestoreRequest $aksRestoreRequest -SnapshotResourceGroupId $snapshotResourceGroupId

            $validateRestore = Test-AzDataProtectionBackupInstanceRestore -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -RestoreRequest $aksRestoreRequest -Name $backupInstance.BackupInstanceName

            $validateRestore.ObjectType | Should be "OperationJobExtendedInfo"
            
            $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $backupInstance.BackupInstanceName -Parameter $aksRestoreRequest

            Start-Sleep -Seconds 10
                
            $jobid = $restoreJob.JobId.Split("/")[-1]
            ($jobid -ne $null) | Should be $true

            $jobstatus = "InProgress"
            while($jobstatus -ne "Completed")
            {
                Start-Sleep -Seconds 10
                $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
                $jobstatus = $currentjob.Status
            }
        }
    }
}
