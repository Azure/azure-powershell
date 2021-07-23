$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzPostgreSqlFlexibleServer' {

    It 'List' {
        # Public Access All
        $Servers = Get-AzPostgreSqlFlexibleServer
        $servers.Count | Should -BeGreaterOrEqual 1
        $Servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup
        $servers.Count | Should -BeGreaterOrEqual 1
    }

    It 'ViaName' {
        # New
        $Sku = 'Standard_D4s_v3'
        $SkuTier = 'GeneralPurpose'
        $BackupRetentionDay = 11
        $HaEnabled = 'Enabled'
        $Server = New-AzPostgreSqlFlexibleServer -Location $env.location -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2 -Sku $Sku -SkuTier $SkuTier -BackupRetentionDay $BackupRetentionDay -HaEnabled $HaEnabled -StorageInMb 65536 

        # Get
        $Server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName2
        $Server.NetworkPublicNetworkAccess | Should -Be "Enabled"
        $Server.SkuName | Should -Be $Sku
        $Server.SkuTier | Should -Be $SkuTier
        $Server.BackupRetentionDay | Should -Be $BackupRetentionDay
        $Server.HighAvailabilityMode | Should -Be 'ZoneRedundant'

        # stop
        Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName

        # start
        Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        
        # restart
        Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName

        # restore
        $restorePointInTime = (Get-Date).AddMinutes(-10)
        $RestoredName = $env.serverName + '-restored'
        $RestoredServer = Restore-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $RestoredName -SourceServerName $env.serverName -RestorePointInTime $restorePointInTime 
        $RestoredServer.Name | Should -Be $RestoredName
     
        # update - half paramaeters
        $UpdatedServer = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -MaintenanceWindow Mon:1:20
        $UpdatedServer.MaintenanceWindowCustomWindow | Should -Be 'Enabled'
        $UpdatedServer.MaintenanceWindowDayOfWeek | Should -Be 1
        $UpdatedServer.MaintenanceWindowStartHour | Should -Be 1
        $UpdatedServer.MaintenanceWindowStartMinute | Should -Be 20
    }

    It 'ViaIdentity' {
        $Server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName2

        # stop
        Stop-AzPostgreSqlFlexibleServer -InputObject $server

        # start
        Start-AzPostgreSqlFlexibleServer -InputObject $server
        
        # restart
        Restart-AzPostgreSqlFlexibleServer -InputObject $server

        $UpdatedServer = Update-AzPostgreSqlFlexibleServer -BackupRetentionDay 15 -InputObject $server
        $UpdatedServer.BackupRetentionDay | Should -Be 15
    }
}