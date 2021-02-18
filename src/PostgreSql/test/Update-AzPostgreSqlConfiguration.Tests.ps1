$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlConfiguration' {
    It 'UpdateExpanded' {
        $config = Update-AzPostgreSqlConfiguration -Name intervalstyle -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -Value SQL_STANDARD
        $config.Value | Should -Be SQL_STANDARD
    }

    It 'UpdateViaIdentityExpanded' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSQL/servers/$($env.serverName)/configurations/deadlock_timeout"
        $config = Update-AzPostgreSqlConfiguration -InputObject $ID -Value 2000
        $config.Value | Should -Be 2000
    }
}
