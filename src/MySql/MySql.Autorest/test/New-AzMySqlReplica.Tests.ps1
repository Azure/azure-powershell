$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMySqlServerReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMySqlReplica' {
    It 'CreateExpanded' {
        $server = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $replica = New-AzMySqlReplica -InputObject $server -Replica $env.replicaName -ResourceGroupName $env.resourceGroup
        $replica.Name | Should -Be $env.replicaName
        $replica.SkuName | Should -Be $env.Sku
        $replica.Location | Should -Be eastus
        Remove-AzMySqlServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName
    }
}
