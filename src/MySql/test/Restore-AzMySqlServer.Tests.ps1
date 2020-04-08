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
    It 'GeoRestore' -skip {
        $replica = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | New-AzMySqlServerReplica -Name $env.replicaName -ResourceGroupName $env.resourceGroup
        $restoreServer = Restore-AzMySqlServer -Name $env.serverName -ResourceGroupName $env.resourceGroup -InputObject $replica -UseGeoRestore 
        $restoreServer.Count | Should -Be 1
    }

    It 'PointInTimeRestore' -skip {
        $restorePointInTime = (Get-Date).AddMinutes(-10)
        $restoreServer = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | Restore-AzMySqlServer -Name $env.restoreName2 -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime -UsePointInTimeRestore
        $restoreServer.Count | Should -Be 1
    }
}
