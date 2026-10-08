$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'DiskBackupScenario.Recording.json'
$currentPath = $PSScriptRoot
if (-not $mockingPath) {
    $runtimePath = Join-Path $PSScriptRoot '../../../../generated/DataProtection/DataProtection.Autorest/generated/runtime/HttpPipelineMocking.ps1'
    if (Test-Path $runtimePath) {
        $mockingPath = Get-Item $runtimePath
    }
}
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}

. (Join-Path $PSScriptRoot 'BackupInstance.Offline.Helpers.ps1')

Pester\Describe 'Disk backup public create serialization (offline)' -Tag 'DataProtectionBackupInstanceOffline', 'DataProtectionBackupInstanceWire' {
    Pester\It 'serializes the initialized <SecurityType> <DiskRole> disk with <Assignment> snapshot RG assignment' -TestCases (Get-BackupInstanceOfflineDiskCases) {
        param($DiskName, $SecurityType, $DiskRole, $Assignment)

        $fixture = New-BackupInstanceOfflineFixture -DiskName $DiskName
        $parameters = @{
            DatasourceType = 'AzureDisk'
            DatasourceLocation = $fixture.Location
            DatasourceId = $fixture.DiskId
            PolicyId = $fixture.PolicyId
            ErrorAction = 'Stop'
        }
        if ($Assignment -eq 'Direct') {
            $parameters.SnapshotResourceGroupId = $fixture.SnapshotResourceGroupId
        }
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance @parameters
        if ($Assignment -eq 'Deferred') {
            $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $fixture.SnapshotResourceGroupId
        }
        Assert-BackupInstanceOperationalStore -Instance $instance -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId
        $pipeline = New-BackupInstanceOfflinePipeline -RecordingFile (Join-Path $TestDrive 'unused.Recording.json')
        $null = Az.DataProtection\New-AzDataProtectionBackupInstance -SubscriptionId $fixture.SubscriptionId -ResourceGroupName $fixture.ResourceGroupName -VaultName $fixture.TargetVaultName -BackupInstance $instance -HttpPipelinePrepend $pipeline.Steps -NoWait -Confirm:$false -ErrorAction Stop

        $pipeline.Sent.Count | Should -Be 1
        Assert-BackupInstanceDiskCreateRequest -Request $pipeline.Sent[0] -Fixture $fixture -Instance $instance
    }

    Pester\It 'reprotects a suspended source fixture into a different vault with <Assignment> snapshot RG assignment' -TestCases @(
        @{ Assignment = 'Direct' }
        @{ Assignment = 'Deferred' }
    ) {
        param($Assignment)

        $fixture = New-BackupInstanceOfflineFixture -DiskName 'cross-vault'
        # This is an already-suspended response fixture, not a live suspend/reprotect acceptance test.
        $sourceResponse = @{
            id = "$($fixture.SourceVaultId)/backupInstances/$($fixture.SourceInstanceName)"
            name = $fixture.SourceInstanceName
            type = 'Microsoft.DataProtection/backupVaults/backupInstances'
            properties = @{
                objectType = 'BackupInstance'
                friendlyName = $fixture.FriendlyName
                currentProtectionState = $fixture.Settings.SuspendedProtectionState
                protectionStatus = @{ status = $fixture.Settings.SuspendedProtectionState }
                dataSourceInfo = @{
                    objectType = 'Datasource'
                    datasourceType = 'Microsoft.Compute/disks'
                    resourceType = 'Microsoft.Compute/disks'
                    resourceID = $fixture.DiskId
                    resourceUri = $fixture.DiskId
                    resourceName = $fixture.DiskId.Split('/')[-1]
                    resourceLocation = $fixture.Location
                }
                policyInfo = @{
                    policyId = $fixture.SourcePolicyId
                    policyParameters = @{
                        dataStoreParametersList = @(@{
                            objectType = 'AzureOperationalStoreParameters'
                            dataStoreType = 'OperationalStore'
                            resourceGroupId = $fixture.SourceSnapshotResourceGroupId
                        })
                    }
                }
            }
        } | ConvertTo-Json -Depth 10
        $pipeline = New-BackupInstanceOfflinePipeline -RecordingFile (Join-Path $TestDrive 'unused.Recording.json') -GetResponse $sourceResponse
        $source = Az.DataProtection\Get-AzDataProtectionBackupInstance -SubscriptionId $fixture.SubscriptionId -ResourceGroupName $fixture.ResourceGroupName -VaultName $fixture.SourceVaultName -Name $fixture.SourceInstanceName -HttpPipelinePrepend $pipeline.Steps -ErrorAction Stop
        Assert-BackupInstanceOperationalStore -Instance $source -SnapshotResourceGroupId $fixture.SourceSnapshotResourceGroupId
        $source.Property.CurrentProtectionState | Should -Be $fixture.Settings.SuspendedProtectionState
        $sourceList = $source.Property.PolicyInfo.PolicyParameter.DataStoreParametersList
        $sourceElement = $sourceList[0]
        $parameters = @{
            DatasourceType = 'AzureDisk'
            DatasourceLocation = $source.Property.DataSourceInfo.ResourceLocation
            DatasourceId = $source.Property.DataSourceInfo.ResourceId
            PolicyId = $fixture.PolicyId
            ErrorAction = 'Stop'
        }
        if ($Assignment -eq 'Direct') {
            $parameters.SnapshotResourceGroupId = $fixture.SnapshotResourceGroupId
        }
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance @parameters
        if ($Assignment -eq 'Deferred') {
            $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $fixture.SnapshotResourceGroupId
        }
        [object]::ReferenceEquals($source, $instance) | Should -Be $false
        [object]::ReferenceEquals($source.Property, $instance.Property) | Should -Be $false
        [object]::ReferenceEquals($source.Property.DataSourceInfo, $instance.Property.DataSourceInfo) | Should -Be $false
        [object]::ReferenceEquals($source.Property.PolicyInfo, $instance.Property.PolicyInfo) | Should -Be $false
        [object]::ReferenceEquals($source.Property.PolicyInfo.PolicyParameter, $instance.Property.PolicyInfo.PolicyParameter) | Should -Be $false
        [object]::ReferenceEquals($sourceList, $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList) | Should -Be $false
        [object]::ReferenceEquals($sourceElement, $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0]) | Should -Be $false
        $null = Az.DataProtection\New-AzDataProtectionBackupInstance -SubscriptionId $fixture.SubscriptionId -ResourceGroupName $fixture.ResourceGroupName -VaultName $fixture.TargetVaultName -BackupInstance $instance -HttpPipelinePrepend $pipeline.Steps -NoWait -Confirm:$false -ErrorAction Stop

        $pipeline.Sent.Count | Should -Be 2
        $pipeline.Sent[0].Method | Should -Be 'GET'
        $pipeline.Sent[0].Uri.AbsolutePath | Should -Be "$($fixture.SourceVaultId)/backupInstances/$($fixture.SourceInstanceName)"
        Assert-BackupInstanceDiskCreateRequest -Request $pipeline.Sent[1] -Fixture $fixture -Instance $instance
        $fixture.TargetVaultId | Should -Not -Be $fixture.SourceVaultId
        $fixture.PolicyId | Should -Not -Be $fixture.SourcePolicyId
        $source.Id | Should -Be "$($fixture.SourceVaultId)/backupInstances/$($fixture.SourceInstanceName)"
        $source.Property.PolicyInfo.PolicyId | Should -Be $fixture.SourcePolicyId
        $source.Property.DataSourceInfo.ResourceId | Should -Be $fixture.DiskId
        $source.Property.DataSourceInfo.ResourceLocation | Should -Be $fixture.Location
        $source.Property.CurrentProtectionState | Should -Be $fixture.Settings.SuspendedProtectionState
        $source.Property.ProtectionStatus.Status | Should -Be $fixture.Settings.SuspendedProtectionState
        [object]::ReferenceEquals($sourceList, $source.Property.PolicyInfo.PolicyParameter.DataStoreParametersList) | Should -Be $true
        [object]::ReferenceEquals($sourceElement, $sourceList[0]) | Should -Be $true
        Assert-BackupInstanceOperationalStore -Instance $source -SnapshotResourceGroupId $fixture.SourceSnapshotResourceGroupId
    }
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'DiskBackupScenario' {
    It 'EndtoEndTest' {
        $vaultName = $env.TestDiskBackupScenario.VaultName
        $rgName = $env.TestDiskBackupScenario.ResourceGroupName
        $diskId = $env.TestDiskBackupScenario.DiskId
        $snapshotRg = $env.TestDiskBackupScenario.SnapshotRG
        $restoreDiskId = $env.TestDiskBackupScenario.RestoreDiskId
        if ($TestMode -ne 'playback') {
            $restoreDiskId = '{0}-{1}' -f $restoreDiskId, ([Guid]::NewGuid().ToString('N').Substring(0, 8))
        }
        $policyName = $env.TestDiskBackupScenario.NewPolicyName
        $sub = $env.TestDiskBackupScenario.SubscriptionId

        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $defaultPolicy = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
        $policyId = "/subscriptions/" + $sub + "/resourceGroups/" + $rgName + "/providers/Microsoft.DataProtection/backupVaults/" + $vaultName + "/backupPolicies/" + $policyName
        $backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation centraluseuap -PolicyId $policyId -DatasourceId $diskId -SnapshotResourceGroupId $snapshotRg

        $instances = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
        $instance = $instances | where-Object {$_.Property.DataSourceInfo.ResourceId -eq $diskId}
        $backupInstanceName = $instance.Name

        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
        $protectionStatus = $instance.Property.ProtectionStatus.Status
        while($protectionStatus -ne "ProtectionConfigured")
        {
            Start-TestSleep -Seconds 5

            $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -Name $backupInstanceName
            $protectionStatus = $instance.Property.ProtectionStatus.Status

            # configure backup if not configured
        }

        $backupPolicyId = $instance.Property.PolicyInfo.PolicyId
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName $vaultName -ResourceGroupName $rgName | Where-Object { $_.Id -eq $backupPolicyId  }

        $job = Backup-AzDataProtectionBackupInstanceAdhoc -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName -BackupInstanceName $backupInstanceName -BackupRuleOptionRuleName  $policy.Property.PolicyRule[0].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[0].Trigger.TaggingCriterion[0].TagInfoTagName

        $jobid = $job.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"

        $rp = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $backupInstanceName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName
        $restoreRequestObject = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation centraluseuap -RestoreType AlternateLocation -RecoveryPoint $rp[0].Name -TargetResourceId $restoreDiskId
        $job = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $backupInstanceName -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Parameter $restoreRequestObject

        $jobid = $job.JobId.Split("/")[-1]
        $jobstatus = "InProgress"
        while($jobstatus -eq "InProgress")
        {
            Start-TestSleep -Seconds 5
            $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
            $jobstatus = $currentjob.Status
        }
        $jobstatus | Should be "Completed"
     }
}
