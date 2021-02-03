$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMySqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMySqlFlexibleServer' {
    It 'UpdateExpanded' {
        {
            $server = Update-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 12
            $server.StorageProfileBackupRetentionDay | Should -Be 12

            $server = Update-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -MaintenanceWindow "Mon:1:30"
            $server.MaintenanceWindowCustomWindow | Should -Be 'Enabled'
            $server.MaintenanceWindowDayOfWeek | Should -Be '1'
            $server.MaintenanceWindowStartHour | Should -Be '1'
            $server.MaintenanceWindowStartMinute | Should -Be '30'

        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
            $server = Update-AzMySqlFlexibleServer -InputObject $ID -StorageInMb 20480
            $server.StorageProfileStorageMb | Should -Be 20480

            $server = Update-AzMySqlFlexibleServer -InputObject $ID -SkuTier GeneralPurpose -Sku Standard_D2ds_v4
            $server.SkuTier | Should -Be 'GeneralPurpose'
            $server.SkuName | Should -Be 'Standard_D2ds_v4'

        } | Should -Not -Throw
    }
}
