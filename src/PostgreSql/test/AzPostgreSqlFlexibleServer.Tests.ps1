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


$DEFAULT_DB_NAME = 'flexibleserverdb'
$DELEGATION_SERVICE_NAME = "Microsoft.DBforPostgreSQL/flexibleServers"
$DEFAULT_VNET_PREFIX = '10.0.0.0/16'
$DEFAULT_SUBNET_PREFIX = '10.0.0.0/24'

Describe 'AzPostgreSqlFlexibleServer' {
    It 'List1' {
        {
            $servers = Get-AzPostgreSqlFlexibleServer
            $servers.Count | Should -BeGreaterOrEqual 1  
            $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup
            $servers.Count | Should -Be 1  
        } | Should -Not -Throw
    }

    It 'ViaName'  {
        {
            $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            $servers.Name | Should -Be $env.flexibleServerName
            
            $server = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 12 
            $server.StorageProfileBackupRetentionDay | Should -Be 12
            
            Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            
            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            
            Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
            $replica = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName | New-AzPostgreSqlFlexibleServerReplica -Replica $env.replicaName -ResourceGroupName $env.resourceGroup 
            $replica.Name | Should -Be $env.replicaName
            $replica.SkuName | Should -Be $env.flexibleSku

            New-AzPostgreSqlFlexibleServer -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -Location $env.location -PublicAccess none -HaEnabled Enabled

            $server = Update-AzPostgreSqlFlexibleServer -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup  -HaEnabled Disabled
            $server.HaEnabled  | Should -Be 'Disabled'

            $server = Update-AzPostgreSqlFlexibleServer -Name $env.flexibleServerName2 -ResourceGroupName $env.resourceGroup -HaEnabled Enabled
            $server.HaEnabled  | Should -Be 'Enabled'

            Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.replicaName
            Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2
        
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)"
            $server = Get-AzPostgreSqlFlexibleServer -InputObject $ID
            $server.Name | Should -Be $env.flexibleServerName

            $server = Update-AzPostgreSqlFlexibleServer -InputObject $server -StorageInMb 20480
            $server.StorageProfileStorageMb  | Should -Be 20480

            $server = Update-AzPostgreSqlFlexibleServer -InputObject $server -SkuTier GeneralPurpose -Sku Standard_D2ds_v4
            $server.SkuTier | Should -Be 'GeneralPurpose'
            $server.SkuName | Should -Be 'Standard_D2ds_v4'

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/stop"
            Stop-AzPostgreSqlFlexibleServer -InputObject $ID
            
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/start"
            Start-AzPostgreSqlFlexibleServer -InputObject $ID
            
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/restart"
            Restart-AzPostgreSqlFlexibleServer -InputObject $ID
            
            $restorePointInTime = (Get-Date).AddMinutes(-10)
            $restoredServer = Restore-AzPostgreSqlFlexibleServer -SourceServerName $env.flexibleServerName -Location $env.location -Name $env.restoreName -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime
            
            Remove-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $restoredServer

        } | Should -Not -Throw
    }
}