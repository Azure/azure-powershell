$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlFlexibleServerReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlFlexibleServerReplica' {
    It 'List' {
        {
            $replica = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzMySqlFlexibleServerReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup 
            $replica.Count | Should -Be 1
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.serverName)"
            Remove-AzMySqlFlexibleServer -InputObject $ID
        } | Should -Not -Throw
    }
}
