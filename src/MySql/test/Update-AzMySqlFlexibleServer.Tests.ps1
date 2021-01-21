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
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)"
            $server = Update-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -BackupRetentionDay 13
            $server.StorageProfileBackupRetentionDay | Should -Be 13
        } | Should -Not -Throw
    }
}
