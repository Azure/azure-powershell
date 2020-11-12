$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFlexibleServerConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlFlexibleServerConfiguration' {
    It 'UpdateExpanded' -Skip {
        $config = Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -Value 10240
        $config.Value | Should -Be 10240
        $config.DefaultValue | Should -Be 4096
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.serverName)/configurations/work_mem"
        $config = Update-AzPostgreSqlFlexibleServerConfiguration -InputObject $ID -Value 4096
        $config.Value | Should -Be 4096
        $config.DefaultValue | Should -Be 4096
    }
}
