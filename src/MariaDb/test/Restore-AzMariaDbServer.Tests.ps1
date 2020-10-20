$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzMariaDbServer' {
    It 'PointInTimeRestore' {
        $restoreMariaDbName = $env.rstrgp02 + 'rst01'
        $restorePointInTime = [datetime]::parse($env.restorePointInTime)
        #-UsePointInTimeRestore
        Restore-AzMariaDBServer -Name $restoreMariaDbName -ServerName $env.rstrgp02 -ResourceGroupName $env.ResourceGroup -RestorePointInTime $restorePointInTime -Location $env.Location
        $restoreMariaDb = Get-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup
        $restoreMariaDb.Name | Should -Be $restoreMariaDbName
    }
    It 'PointInTimeRestoreServerObject' {
        $restoreMariaDbName = $env.rstrgp02 +'rst12'
        $restorePointInTime = [datetime]::parse($env.restorePointInTime)
        $mariadb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrgp02
        #-UsePointInTimeRestore
        Restore-AzMariaDBServer -Name $restoreMariaDbName -InputObject $mariadb -RestorePointInTime $restorePointInTime -Location $env.Location
        $restoreMariaDb = Get-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup
        $restoreMariaDb.Name | Should -Be $restoreMariaDbName
    }
    It 'GeoRestore' -skip {
        $adminLoginPasswordSecure =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force
        $dbname = $env.rstrgp02 + 'new01'
        New-AzMariaDbServer -Name $dbname -ResourceGroupName $env.ResourceGroup -Sku 'GP_Gen5_4' -StorageProfileGeoRedundantBackup Enabled -Location $env.Location -AdministratorUsername $env.AdminLogin -AdministratorLoginPassword $adminLoginPasswordSecure
        $geoMariaDbName = $dbname + '-geo01' 
        $repMariaDbName = $dbname + '-geo01rep01'
        $location = 'eastus2'
        New-AzMariaDbServerReplica -Name $repMariaDbName -ServerName $dbname -ResourceGroupName $env.ResourceGroup
        Restore-AzMariaDBServer -Name $geoMariaDbName -ServerName $repMariaDbName -ResourceGroupName $env.ResourceGroup -UseGeoRetore -Location $location
        $geoMariaDb = Get-AzMariaDBServer -Name $geoMariaDbName -ResourceGroupName $env.ResourceGroup
        $geoMariaDb.Name | Should -Be $geoMariaDbName
    }
    It 'GeoRestoreServerObject' -skip {
        $adminLoginPasswordSecure =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force
        $dbname = $env.rstrgp02 + 'new02'
        New-AzMariaDbServer -Name $dbname -ResourceGroupName $env.ResourceGroup -Sku 'GP_Gen5_4' -StorageProfileGeoRedundantBackup Enabled -Location $env.Location -AdministratorUsername $env.AdminLogin -AdministratorLoginPassword $adminLoginPasswordSecure
        $geoMariaDbName = $dbname + '-geo02' 
        $repMariaDbName = $dbname + '-geo02rep01'
        $location = 'eastus2'
        New-AzMariaDbServerReplica -Name $repMariaDbName -ServerName $dbname -ResourceGroupName $env.ResourceGroup
        $mariadb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $repMariaDbName
        Restore-AzMariaDBServer -Name $geoMariaDbName -InputObject $mariadb -UseGeoRetore -Location $location
        $geoMariaDb = Get-AzMariaDBServer -Name $geoMariaDbName -ResourceGroupName $env.ResourceGroup
        $geoMariaDb.Name | Should -Be $geoMariaDbName
    }
}
