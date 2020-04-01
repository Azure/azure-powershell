$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzMariaDBServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzMariaDbServer' {
    It 'PointInTimeRestore' {
        $restoreMariaDbName = $env.rstrgp02 + '-rst01' 
        $restorePointInTime = [datetime]::parse($env.restorePointInTime)
        Restore-AzMariaDBServer -Name $restoreMariaDbName -ServerName $env.rstrgp02 -ResourceGroupName $env.ResourceGroup -UsePointInTimeRestore -RestorePointInTime $restorePointInTime -Location $env.Location
        $restoreMariaDb = Get-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup
        $restoreMariaDb.Name | Should -Be $restoreMariaDbName
    }
    It 'PointInTimeRestoreServerObject' {
        $restoreMariaDbName = $env.rstrgp02 +'-rst02'
        $restorePointInTime = [datetime]::parse($env.restorePointInTime)
        $mariadb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrgp02
        Restore-AzMariaDBServer -Name $restoreMariaDbName -InputObject $mariadb -UsePointInTimeRestore -RestorePointInTime $restorePointInTime -Location $env.Location
        $restoreMariaDb = Get-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup
        $restoreMariaDb.Name | Should -Be $restoreMariaDbName
    }
    It 'GeoRestore' {
        $repMariaDbName = $env.rstrgp02 + '-geo01' 
        Restore-AzMariaDBServer -Name $repMariaDbName -ServerName $env.rstrgp02 -ResourceGroupName $env.ResourceGroup -UseGeoRetore -Location $env.Location
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroupName $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }
    It 'GeoRestoreServerObject' {
        $repMariaDbName = $env.rstrgp02 + '-geo02' 
        $mariadb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrgp02
        Restore-AzMariaDBServer -Name $repMariaDbName -InputObject $mariadb -UseGeoRetore -Location $env.Location
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroupName $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }
}
