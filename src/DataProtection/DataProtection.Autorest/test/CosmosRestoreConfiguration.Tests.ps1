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
        $targetResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/resourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/targetAccountName"
        $userAssignedIdentityArmId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"
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

    It 'RestoreRequestThrowsWhenSystemAssignedIdentityIsNull' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @("db1/col1")

        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -UseSystemAssignedIdentity $null } | Should -Throw "UseSystemAssignedIdentity cannot be null"
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -RestoreConfiguration $restoreConfig -ItemLevelRecovery -UseSystemAssignedIdentity $null } | Should -Throw "UseSystemAssignedIdentity cannot be null"
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureCosmosDB -SourceDataStore VaultStore -RestoreLocation "eastus" -RestoreType AlternateLocation -RecoveryPoint "recoveryPointId" -TargetResourceId $targetResourceId -UseSystemAssignedIdentity $null -UserAssignedIdentityArmId $userAssignedIdentityArmId } | Should -Throw "UseSystemAssignedIdentity cannot be null"
    }
}
