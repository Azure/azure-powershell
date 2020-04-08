$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlServer' {
    It 'List1' {
<<<<<<< Updated upstream
        { 
            $servers = Get-AzMySqlServer
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName
        } | Should -Not -Throw
=======
        $servers = Get-AzMySqlServer
        $servers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName
        $servers.Name | Should -Be $env.serverName
>>>>>>> Stashed changes
    }

    It 'List' {
        $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup
        $servers.Count | Should -Be 1
    }

<<<<<<< Updated upstream
    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
=======
    It 'GetViaIdentity' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/servers/$($env.serverName)"
        $servers = Get-AzMySqlServer -InputObject $ID
        $servers.Name | Should -Be $env.serverName
>>>>>>> Stashed changes
    }
}
