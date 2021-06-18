$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlFlexibleServer' {
    It 'UpdateExpanded' {
        {
            $server = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 15 
            $server.StorageProfileBackupRetentionDay | Should -Be 15

            $server = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -MaintenanceWindow "Mon:1:30"
            $server.MaintenanceWindowCustomWindow | Should -Be 'Enabled'
            $server.MaintenanceWindowDayOfWeek | Should -Be '1'
            $server.MaintenanceWindowStartHour | Should -Be '1'
            $server.MaintenanceWindowStartMinute | Should -Be '30'

        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            # $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/flexibleServers/$($env.flexibleServerName)/"
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            $server = Update-AzPostgreSqlFlexibleServer -InputObject $server -StorageInMb 20480
            $server.StorageProfileStorageMb | Should -Be 20480
        } | Should -Not -Throw
    }
}
