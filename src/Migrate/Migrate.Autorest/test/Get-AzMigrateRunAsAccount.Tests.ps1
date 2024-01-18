$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateRunAsAccount.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateRunAsAccount' {
    It 'List' {
        $accounts = Get-AzMigrateRunAsAccount -SiteName  $env.migSiteName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $accounts.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $account = Get-AzMigrateRunAsAccount -AccountName $env.migRunAsAccountName -SiteName  $env.migSiteName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $account.Name | Should -Be $env.migRunAsAccountName
    }
}