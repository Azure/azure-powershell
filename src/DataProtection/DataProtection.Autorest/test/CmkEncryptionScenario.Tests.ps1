$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'CmkEncryptionScenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'CmkEncryptionScenario' {

    It 'Get-AzDataProtectionBackupVault' {
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $env.TestCmkEncryption.SubscriptionId -ResourceGroupName $env.TestCmkEncryption.ResourceGroupName -VaultName $env.TestCmkEncryption.VaultName
        
        $vault.EncryptionSetting.State | Should be "Enabled"
        $vault.EncryptionSetting.CmkInfrastructureEncryption | Should be "Enabled"
        $vault.EncryptionSetting.CmkIdentity.IdentityType | Should be "UserAssigned"
        $vault.EncryptionSetting.CmkIdentity.IdentityId | Should be $env.TestCmkEncryption.CmkUserAssignedIdentityId
        $vault.EncryptionSetting.CmkKeyVaultProperty.KeyUri | Should be $env.TestCmkEncryption.CmkEncryptionKeyUriUpdated
    }

    It 'New-AzDataProtectionBackupVault' {
        $storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -Type LocallyRedundant -DataStoreType VaultStore

        $userAssignedIdentity = @{$env.TestCmkEncryption.CmkUserAssignedIdentityId = @{}}

        $vault = New-AzDataProtectionBackupVault -SubscriptionId $env.TestCmkEncryption.SubscriptionId -ResourceGroupName $env.TestCmkEncryption.ResourceGroupName -VaultName $env.TestCmkEncryption.VaultName -Location $env.TestCmkEncryption.Location -StorageSetting $storagesetting -IdentityType UserAssigned -UserAssignedIdentity $userAssignedIdentity -CmkEncryptionState Enabled -CmkIdentityType UserAssigned -CmkUserAssignedIdentityId $env.TestCmkEncryption.CmkUserAssignedIdentityId -CmkEncryptionKeyUri $env.TestCmkEncryption.CmkEncryptionKeyUri  -CmkInfrastructureEncryption Enabled

        $vault.EncryptionSetting.State | Should be "Enabled"
        $vault.EncryptionSetting.CmkInfrastructureEncryption | Should be "Enabled"
        $vault.EncryptionSetting.CmkIdentity.IdentityType | Should be "UserAssigned"
        $vault.EncryptionSetting.CmkIdentity.IdentityId | Should be $env.TestCmkEncryption.CmkUserAssignedIdentityId
        $vault.EncryptionSetting.CmkKeyVaultProperty.KeyUri | Should be $env.TestCmkEncryption.CmkEncryptionKeyUri
    }

    It 'Update-AzDataProtectionBackupVault' {

        $vault = Update-AzDataProtectionBackupVault -SubscriptionId $env.TestCmkEncryption.SubscriptionId -ResourceGroupName $env.TestCmkEncryption.ResourceGroupName -VaultName $env.TestCmkEncryption.VaultName -CmkEncryptionKeyUri $env.TestCmkEncryption.CmkEncryptionKeyUriUpdated

        $vault.EncryptionSetting.State | Should be "Enabled"
        $vault.EncryptionSetting.CmkInfrastructureEncryption | Should be "Enabled"
        $vault.EncryptionSetting.CmkIdentity.IdentityType | Should be "UserAssigned"
        $vault.EncryptionSetting.CmkIdentity.IdentityId | Should be $env.TestCmkEncryption.CmkUserAssignedIdentityId
        $vault.EncryptionSetting.CmkKeyVaultProperty.KeyUri | Should be $env.TestCmkEncryption.CmkEncryptionKeyUriUpdated
    }
}
