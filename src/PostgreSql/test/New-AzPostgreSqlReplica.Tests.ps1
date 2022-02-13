$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzPostgreSqlReplica' {
    It 'CreateExpanded' {
        $replica = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzPostgreSqlReplica -Name $env.replicaName -ResourceGroupName $env.resourceGroup 
        $replica.Name | Should -Be $env.replicaName
        $replica.SkuName | Should -Be $env.Sku
        $replica.Location | Should -Be eastus2euap
        Remove-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName
    }
}
