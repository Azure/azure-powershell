$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataProtectionBackupVault.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDataProtectionBackupVault' {
    It 'CreateExpanded' {
        $storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -Type LocallyRedundant -DataStoreType VaultStore
        $vault = New-AzDataProtectionBackupVault -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.NewVaultName -Location centraluseuap -StorageSetting $storagesetting
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.NewVaultName
        $vault.Location | Should be "centraluseuap"
        $vault.Name | Should be $env.TestBackupVault.NewVaultName
        Remove-AzDataProtectionBackupVault -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.NewVaultName
    }

    It 'Create' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
