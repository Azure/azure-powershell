$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMySqlFlexibleServerReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMySqlFlexibleServerReplica' {
    It 'CreateExpanded' {
        {
            $replica = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzMySqlFlexibleServerReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup 
            $replica.Name | Should -Be $env.replicaName
            $replica.SkuName | Should -Be $env.FlexibleSku
            $replica.Location | Should -Be "West US 2"
            Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName
        } | Should -Not -Throw
    }
}
