$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataProtectionBackupVault.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDataProtectionBackupVault' {
    It 'PatchExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Patch' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CostManagementGranularity' {
        # Set granularity to VaultLevel
        $vault = Update-AzDataProtectionBackupVault -SubscriptionId $env.TestBackupVault.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.VaultName -CostManagementGranularity VaultLevel
        $vault.CostManagementSettingGranularityLevel | Should -Be "VaultLevel"

        # Update granularity to ProtectedItemLevel
        $vault = Update-AzDataProtectionBackupVault -SubscriptionId $env.TestBackupVault.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.VaultName -CostManagementGranularity ProtectedItemLevel
        $vault.CostManagementSettingGranularityLevel | Should -Be "ProtectedItemLevel"

        # Verify Get also returns the updated granularity
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $env.TestBackupVault.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.VaultName
        $vault.CostManagementSettingGranularityLevel | Should -Be "ProtectedItemLevel"

        # Update granularity to ProtectedItemWithParentTag
        $vault = Update-AzDataProtectionBackupVault -SubscriptionId $env.TestBackupVault.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.VaultName -CostManagementGranularity ProtectedItemWithParentTag
        $vault.CostManagementSettingGranularityLevel | Should -Be "ProtectedItemWithParentTag"

        # Verify Get also returns the updated granularity
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $env.TestBackupVault.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.VaultName
        $vault.CostManagementSettingGranularityLevel | Should -Be "ProtectedItemWithParentTag"
    }
}
