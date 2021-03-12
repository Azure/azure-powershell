$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataProtectionBackupInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataProtectionBackupInstance' {
    It 'GetAll' {
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupInstance.ResourceGroupName -VaultName $env.TestBackupInstance.VaultName
        $instance.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $instances = Get-AzDataProtectionBackupInstance -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupInstance.ResourceGroupName -VaultName $env.TestBackupInstance.VaultName
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupInstance.ResourceGroupName -VaultName $env.TestBackupInstance.VaultName -Name $instances[0].Name
        $instance.Name | should be $instances[0].Name
    }
}
