$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlReplica' {
    It 'List' {
        Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzPostgreSqlReplica -Name $env.replicaName -ResourceGroupName $env.resourceGroup
        $replica = Get-AzPostgreSqlReplica -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $replica.Count | Should -Be 1
        Remove-AzPostgreSqlServer -InputObject $replica
    }
}
