$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataProtectionJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataProtectionJob' {
    It 'List' -skip {
        $jobs = Get-AzDataProtectionJob -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupJob.ResourceGroupName -VaultName $env.TestBackupJob.VaultName
        $jobs.Length | Should -BeGreaterThan 0
    }

    It 'Get' -skip {
        $jobs = Get-AzDataProtectionJob -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupJob.ResourceGroupName -VaultName $env.TestBackupJob.VaultName
        $jobs.Length | Should -BeGreaterThan 0
        $job = Get-AzDataProtectionJob -Id $jobs[0].Id -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.TestBackupJob.ResourceGroupName -VaultName $env.TestBackupJob.VaultName
        $job.Id | Should be $jobs[0].Id
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
