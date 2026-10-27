$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'CosmosRestoreConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'CosmosRestoreConfiguration' {
    BeforeAll {
        $subId = $env.TestCosmosDBItemLevelRestore.SubscriptionId
        $resourceGroupName = $env.TestCosmosDBItemLevelRestore.ResourceGroupName
        $vaultName = $env.TestCosmosDBItemLevelRestore.VaultName
        $location = $env.TestCosmosDBItemLevelRestore.Location
        $sourceAccountName = $env.TestCosmosDBItemLevelRestore.SourceCosmosDBAccountName
        $targetResourceId = $env.TestCosmosDBItemLevelRestore.TargetCosmosDBAccountId
        $userAssignedIdentityArmId = $env.TestCosmosDBItemLevelRestore.UserAssignedIdentityArmId
    }

    It 'RestoreConfigDatabaseAndContainer' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1", "db2")

        $restoreConfig.ObjectType | Should Be "GenericRestoreDatasourceCriteria"
        $restoreConfig.ResourceSelector.ObjectType | Should Be "ResourceListSelectionCriteria"
        $restoreConfig.ResourceSelector.ResourceIdentifier.Count | Should Be 2
        $restoreConfig.ResourceSelector.ResourceIdentifier[0] | Should Be "db1/col1"
        $restoreConfig.ResourceSelector.ResourceIdentifier[1] | Should Be "db2"
    }

    It 'RestoreConfigThrowsWhenResourceIdentifierMissing' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB } | Should -Throw "ResourceIdentifier"
    }

    It 'RestoreConfigThrowsWhenForeignParametersSupplied' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1") -IncludedNamespace @("ns1") } | Should -Throw "Invalid parameters"
    }

    It 'RestoreConfigThrowsWhenResourceNameOverrideSupplied' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1") -ResourceNameOverride @{"db1/col1" = "db1/col2"} } | Should -Throw "Invalid parameters"
    }

    It 'ItemLevelRestoreRequest' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1")
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery

        $restoreRequest.RestoreTargetInfo.ObjectType | Should Be "ItemLevelRestoreTargetInfo"
        $restoreRequest.RestoreTargetInfo.RestoreCriterion.Count | Should Be 1
        $restoreRequest.RestoreTargetInfo.RestoreCriterion[0].ResourceSelector.ResourceIdentifier[0] | Should Be "db1/col1"
        $restoreRequest.RestoreTargetInfo.DatasourceInfo.ResourceId | Should Be $targetResourceId
    }

    It 'ItemLevelRestoreRequestThrowsWhenRestoreConfigurationMissing' {
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -ItemLevelRecovery } | Should -Throw "RestoreConfiguration"
    }

    It 'ItemLevelRestoreRequestThrowsWhenContainersListOrPrefixMatchSupplied' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1")

        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -ContainersList @("col1") } | Should -Throw "ContainersList and PrefixMatch are not supported"
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -PrefixMatch @{ "db1" = @("col1") } } | Should -Throw "ContainersList and PrefixMatch are not supported"
    }

    It 'ItemLevelRestoreRequestThrowsWhenRestoreConfigurationIsNotCosmosSelection' {
        $aksRestoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService
        $emptyRestoreConfig = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria]::new()

        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $aksRestoreConfig -ItemLevelRecovery } | Should -Throw "Invalid RestoreConfiguration"
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $emptyRestoreConfig -ItemLevelRecovery } | Should -Throw "Invalid RestoreConfiguration"
    }

    It 'FullRestoreRequestThrowsWhenRestoreConfigurationSupplied' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1")

        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig } | Should -Throw "requires ItemLevelRecovery"
    }

    It 'RestoreRequestWithSystemAssignedIdentity' {
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -UseSystemAssignedIdentity $true

        $restoreRequest.IdentityDetailUseSystemAssignedIdentity | Should Be $true
    }

    It 'RestoreRequestWithUserAssignedIdentity' {
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -UseSystemAssignedIdentity $false -UserAssignedIdentityArmId $userAssignedIdentityArmId

        $restoreRequest.IdentityDetailUseSystemAssignedIdentity | Should Be $false
        $restoreRequest.IdentityDetailUserAssignedIdentityArmUrl | Should Be $userAssignedIdentityArmId
    }

    It 'ItemLevelRestoreRequestSerializesUserAssignedIdentity' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1")
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -UseSystemAssignedIdentity $false -UserAssignedIdentityArmId $userAssignedIdentityArmId
        $restoreRequestJson = $restoreRequest.ToJsonString() | ConvertFrom-Json

        $restoreRequestJson.restoreTargetInfo.objectType | Should Be "ItemLevelRestoreTargetInfo"
        $restoreRequestJson.identityDetails.useSystemAssignedIdentity | Should Be $false
        $restoreRequestJson.identityDetails.userAssignedIdentityArmUrl | Should Be $userAssignedIdentityArmId
    }

    It 'NonCosmosRestoreRequestSerializesIdentity' {
        $diskResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/resourceGroupName/providers/Microsoft.Compute/disks/diskName"
        $systemAssignedRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $diskResourceId -UseSystemAssignedIdentity $true
        $userAssignedRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureDisk -SourceDataStore OperationalStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $diskResourceId -UseSystemAssignedIdentity $false -UserAssignedIdentityArmId $userAssignedIdentityArmId
        $systemAssignedJson = $systemAssignedRequest.ToJsonString() | ConvertFrom-Json
        $userAssignedJson = $userAssignedRequest.ToJsonString() | ConvertFrom-Json

        $systemAssignedJson.identityDetails.useSystemAssignedIdentity | Should Be $true
        $systemAssignedJson.identityDetails.userAssignedIdentityArmUrl | Should BeNullOrEmpty
        $userAssignedJson.identityDetails.useSystemAssignedIdentity | Should Be $false
        $userAssignedJson.identityDetails.userAssignedIdentityArmUrl | Should Be $userAssignedIdentityArmId
    }

    It 'RestoreRequestThrowsWhenSystemAssignedIdentityIsNull' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1")

        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -UseSystemAssignedIdentity $null } | Should -Throw "UseSystemAssignedIdentity cannot be null"
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -UseSystemAssignedIdentity $null } | Should -Throw "UseSystemAssignedIdentity cannot be null"
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -UseSystemAssignedIdentity $null -UserAssignedIdentityArmId $userAssignedIdentityArmId } | Should -Throw "UseSystemAssignedIdentity cannot be null"
    }

    It 'ItemLevelRestoreValidation' {
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceName -eq $sourceAccountName }
        $recoveryPoints = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

        foreach ($selection in "db1/col1", "db2", "db1/col1,db2") {
            $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $selection.Split(",")
            $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation $location -RestoreType AlternateLocation -RecoveryPoint $recoveryPoints[0].Name -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -UseSystemAssignedIdentity $true
            $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreRequest
            $validateRestore.ObjectType | Should Be "OperationJobExtendedInfo"
        }
    }

    It 'ItemLevelRestoreValidationWithUserAssignedIdentity' {
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceName -eq $sourceAccountName }
        $recoveryPoints = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1")
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation $location -RestoreType AlternateLocation -RecoveryPoint $recoveryPoints[0].Name -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -UseSystemAssignedIdentity $false -UserAssignedIdentityArmId $userAssignedIdentityArmId
        $validateRestore = Test-AzDataProtectionBackupInstanceRestore -Name $instance.Name -ResourceGroupName $resourceGroupName -SubscriptionId $subId -VaultName $vaultName -RestoreRequest $restoreRequest
        $validateRestore.ObjectType | Should Be "OperationJobExtendedInfo"
    }

    It 'ItemLevelRestore' {
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName | Where-Object { $_.Property.DataSourceInfo.ResourceName -eq $sourceAccountName }
        $recoveryPoints = Get-AzDataProtectionRecoveryPoint -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name

        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1", "db2")
        $restoreRequest = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation $location -RestoreType AlternateLocation -RecoveryPoint $recoveryPoints[0].Name -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -UseSystemAssignedIdentity $true
        $restoreJob = Start-AzDataProtectionBackupInstanceRestore -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -Parameter $restoreRequest
        $jobId = $restoreJob.JobId.Split("/")[-1]

        $jobStatus = "InProgress"
        while ($jobStatus -eq "InProgress") {
            Start-TestSleep -Seconds 30
            $currentJob = Get-AzDataProtectionJob -Id $jobId -SubscriptionId $subId -ResourceGroupName $resourceGroupName -VaultName $vaultName
            $jobStatus = $currentJob.Status
        }
        $jobStatus | Should Be "Completed"
    }
}
