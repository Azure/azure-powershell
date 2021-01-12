$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMySqlFlexibleServerConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMySqlFlexibleServerConfiguration' {
        It 'UpdateExpanded' {
        $config = Update-AzMySqlFlexibleServerConfiguration -Name net_retry_count -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Value 15 -Source user-override
        $config.Value | Should -Be 15
        $config.DefaultValue | Should -Be 10
    }

    It 'UpdateViaIdentityExpanded' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)/configurations/wait_timeout"
        $config = Update-AzMySqlFlexibleServerConfiguration -InputObject $ID -Value 150 -Source user-override
        $config.Value | Should -Be 150
        $config.DefaultValue | Should -Be 28800
    }
}
