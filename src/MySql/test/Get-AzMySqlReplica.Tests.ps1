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

Describe 'Get-AzMySqlReplica' {
    It 'List' {
        $server = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        New-AzMySqlReplica -InputObject $server -Replica $env.replicaName -ResourceGroupName $env.resourceGroup
        $replica = Get-AzMySqlReplica -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $replica.Count | Should -Be 1
        Remove-AzMySqlServer -InputObject $replica
    }
}
