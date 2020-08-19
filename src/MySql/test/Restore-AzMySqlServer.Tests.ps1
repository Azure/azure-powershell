$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzMySqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzMySqlServer' {
    It 'GeoRestore' {
        $replica = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzMySqlReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup
        $restoreServer = Restore-AzMySqlServer -Name $env.serverName -ResourceGroupName $env.resourceGroup -InputObject $replica -UseGeoRestore 
        $restoreServer.Name | Should -Be $env.serverName
        $restoreServer.SkuName | Should -Be $env.Sku
    }

    It 'PointInTimeRestore' {
        $restorePointInTime = (Get-Date).AddMinutes(-10)
        $restoreServer = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | Restore-AzMySqlServer -Name $env.restoreName2 -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime -UsePointInTimeRestore
        $restoreServer.Name | Should -Be $env.restoreName2
        $restoreServer.SkuName | Should -Be $env.Sku
    }
}
