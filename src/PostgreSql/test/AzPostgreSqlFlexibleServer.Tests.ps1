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
        $Sku = 'Standard_D2s_v3'
        $SkuTier = 'GeneralPurpose'
        $BackupRetentionDay = 11 

        # Get
        $Server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName4
        $Server.NetworkPublicNetworkAccess | Should -Be "Enabled"
        $Server.SkuName | Should -Be $Sku
        $Server.SkuTier | Should -Be $SkuTier
        $Server.BackupRetentionDay | Should -Be $BackupRetentionDay

        # stop
        Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName

        # start
        Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        
        # restart
        Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
     
        # update - half paramaeters
        $UpdatedServer = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -MaintenanceWindow Mon:1:20
        $UpdatedServer.MaintenanceWindowCustomWindow | Should -Be 'Enabled'
        $UpdatedServer.MaintenanceWindowDayOfWeek | Should -Be 1
        $UpdatedServer.MaintenanceWindowStartHour | Should -Be 1
        $UpdatedServer.MaintenanceWindowStartMinute | Should -Be 20

    }

    It 'ViaIdentity' {
        $Server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName4

        # stop
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/flexibleServers/$($env.flexibleServerName4)/stop"
        Stop-AzPostgreSqlFlexibleServer -InputObject $ID

        # start
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/flexibleServers/$($env.flexibleServerName4)/start"
        Start-AzPostgreSqlFlexibleServer -InputObject $ID
        
        # restart
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/flexibleServers/$($env.flexibleServerName4)/restart"
        Restart-AzPostgreSqlFlexibleServer -InputObject $ID

        $UpdatedServer = Update-AzPostgreSqlFlexibleServer -BackupRetentionDay 15 -InputObject $server
        $UpdatedServer.BackupRetentionDay | Should -Be 15
        
        Remove-AzPostgreSqlFlexibleServer -InputObject $Server.Id
    }
}