$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataProtectionBackupVault.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataProtectionBackupVault' {
    It 'Get' {
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $env.TestBackupVault.SubscriptionId -ResourceGroupName $env.TestBackupVault.ResourceGroupName -VaultName $env.TestBackupVault.VaultName
        $vault.Name | Should be $env.TestBackupVault.VaultName
    }
}
