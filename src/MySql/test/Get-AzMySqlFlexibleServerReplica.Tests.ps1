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

# !Important: some test cases are skipped and require to be recorded again
# See https://github.com/Azure/autorest.powershell/issues/580
Describe 'Get-AzMySqlFlexibleServerReplica' {
    It 'List' {
        {
            Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.serverName | New-AzMySqlFlexibleServerReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup 
            $replica = Get-AzMySqlFlexibleServerReplica -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
            $replica.Count | Should -Be 1
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.serverName)"
            Remove-AzMySqlFlexibleServer -InputObject $ID
        } | Should -Not -Throw
    }
}
