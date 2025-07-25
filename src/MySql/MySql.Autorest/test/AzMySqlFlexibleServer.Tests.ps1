$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzMySqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzMySqlFlexibleServer' {
    It 'List1' {
        {
            $servers = Get-AzMySqlFlexibleServer
            $servers.Count | Should -BeGreaterOrEqual 1
            $servers = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup
            $servers.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'ViaName'  {
        {
            $servers = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            $servers.Name | Should -Be $env.flexibleServerName

            $server = Update-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 12
            $server.BackupRetentionDay | Should -Be 12

            $server = Update-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -MaintenanceWindow "Mon:1:30"
            $server.MaintenanceWindowCustomWindow | Should -Be 'Enabled'
            $server.MaintenanceWindowDayOfWeek | Should -Be '1'
            $server.MaintenanceWindowStartHour | Should -Be '1'
            $server.MaintenanceWindowStartMinute | Should -Be '30'

            Stop-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName

            Start-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName

            Restart-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName

            $flxServer = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $replica = New-AzMySqlFlexibleServerReplica -InputObject $flxServer -Replica $env.replicaName -ResourceGroupName $env.resourceGroup
            $replica.Name | Should -Be $env.replicaName
            $replica.SkuName | Should -Be $env.flexibleSku

            $replica = Get-AzMySqlFlexibleServerReplica -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $replica.Count | Should -Be 1

            Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName

        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)"
            $server = Get-AzMySqlFlexibleServer -InputObject $ID
            $server.Name | Should -Be $env.flexibleServerName

            $server = Update-AzMySqlFlexibleServer -InputObject $server -StorageInMb 20480
            $server.StorageSizeGb  | Should -Be 20

            $server = Update-AzMySqlFlexibleServer -InputObject $server -SkuTier GeneralPurpose -Sku Standard_D4ds_v4
            $server.SkuTier | Should -Be 'GeneralPurpose'
            $server.SkuName | Should -Be 'Standard_D4ds_v4'

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)/stop"
            Stop-AzMySqlFlexibleServer -InputObject $ID

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)/start"
            Start-AzMySqlFlexibleServer -InputObject $ID

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)/restart"
            Restart-AzMySqlFlexibleServer -InputObject $ID

            $restorePointInTime = (Get-Date).AddMinutes(-10)
            $restoredServer = Restore-AzMySqlFlexibleServer -Name $env.restoreName -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime -InputObject $server

            Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $restoredServer.Name

        } | Should -Not -Throw
    }
}
