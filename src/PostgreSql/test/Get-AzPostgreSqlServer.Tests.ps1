$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlServer' {
    It 'List1' {
        $servers = Get-AzPostgreSqlServer
        $servers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $servers = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName
        $servers.Name | Should -Be $env.serverName
    }

    It 'List' {
        $servers = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup
        $servers.Count | Should -Be 1
    }

    It 'GetViaIdentity' -Skip {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)"
        $servers = Get-AzPostgreSqlServer -InputObject $ID
        $servers.Name | Should -Be $env.serverName
    }
}
