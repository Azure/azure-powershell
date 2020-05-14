$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzPostgreSqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzPostgreSqlServer' {
    It 'GeoRestore' {
        $replica = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzPostgreSqlReplica -Name $env.replicaName -ResourceGroupName $env.resourceGroup
        $restoreServer = Restore-AzPostgreSqlServer -Name $env.serverName -ResourceGroupName $env.resourceGroup -InputObject $replica -UseGeoRestore 
        $restoreServer.Name | Should -Be $env.serverName
        $restoreServer.SkuName | Should -Be $env.Sku
    }

    It 'PointInTimeRestore' {
        $restorePointInTime = (Get-Date).AddMinutes(-10)
        $restoreServer = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | Restore-AzPostgreSqlServer -Name $env.restoreName2 -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime -UsePointInTimeRestore
        $restoreServer.Name | Should -Be $env.restoreName2
        $restoreServer.SkuName | Should -Be $env.Sku
    }
}
