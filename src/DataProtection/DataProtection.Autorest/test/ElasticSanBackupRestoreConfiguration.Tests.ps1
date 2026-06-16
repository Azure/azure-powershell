$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'ElasticSanBackupRestoreConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'ElasticSanBackupRestoreConfiguration' {

    It 'BackupConfigSingleVolume' {
        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceSelector @("volume001")

        ($backupConfig -ne $null) | Should Be $true
        $backupConfig.ObjectType | Should Be "GenericBackupDatasourceParameters"
        $backupConfig.ResourceSelector.Count | Should Be 1
        $backupConfig.ResourceSelector[0] | Should Be "volume001"
    }

    It 'BackupConfigThrowsWhenResourceSelectorMissing' {
        { New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureElasticSAN } | Should -Throw "*ResourceSelector*"
    }

    It 'BackupConfigThrowsWhenMoreThanOneVolume' {
        { New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceSelector @("volume001","volume002") } | Should -Throw "*exactly one volume*"
    }

    It 'BackupConfigThrowsWhenForeignParametersSupplied' {
        { New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceSelector @("volume001") -IncludedNamespace @("ns1") } | Should -Throw "*Invalid parameters*"
    }

    It 'RestoreConfigSingleIdentifier' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1")

        ($restoreConfig -ne $null) | Should Be $true
        $restoreConfig.ObjectType | Should Be "GenericRestoreDatasourceCriteria"
        ($restoreConfig.ResourceSelector -ne $null) | Should Be $true
        $restoreConfig.ResourceSelector.ObjectType | Should Be "ResourceListSelectionCriteria"
        $restoreConfig.ResourceSelector.ResourceIdentifier.Count | Should Be 1
        $restoreConfig.ResourceSelector.ResourceIdentifier[0] | Should Be "source-vol1"
    }

    It 'RestoreConfigWithResourceNameOverride' {
        $restoreConfig = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1") -ResourceNameOverride @{"source-vol1" = "restored-vol1"}

        $restoreConfig.ResourceSelector.ResourceNameOverride["source-vol1"] | Should Be "restored-vol1"
    }

    It 'RestoreConfigThrowsWhenResourceIdentifierMissing' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN } | Should -Throw "*ResourceIdentifier*"
    }

    It 'RestoreConfigThrowsWhenMoreThanOneIdentifier' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1","source-vol2") } | Should -Throw "*exactly one volume*"
    }

    It 'RestoreConfigThrowsWhenOverrideKeyNotInIdentifier' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1") -ResourceNameOverride @{"other-vol" = "restored-vol1"} } | Should -Throw "*not present in ResourceIdentifier*"
    }

    It 'RestoreConfigThrowsWhenOverrideTargetEmpty' {
        { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @("source-vol1") -ResourceNameOverride @{"source-vol1" = ""} } | Should -Throw "*non-empty target volume name*"
    }
}
