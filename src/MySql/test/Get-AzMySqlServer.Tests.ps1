$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlServer' {
    It 'List1' {
        $servers = Get-AzMySqlServer
        $servers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName
        $servers.Name | Should -Be $env.serverName
    }

    It 'List' {
        $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup
        $servers.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/servers/$($env.serverName)"
        $servers = Get-AzMySqlServer -InputObject $ID
        $servers.Name | Should -Be $env.serverName
    }
}
