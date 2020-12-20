$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMySqlConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMySqlConfiguration' {
    It 'UpdateExpanded' {
        $config = Update-AzMySqlConfiguration -Name net_retry_count -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -Value 15
        $config.Value | Should -Be 15
    }

    It 'UpdateViaIdentityExpanded' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySQL/servers/$($env.serverName)/configurations/wait_timeout"
        $config = Update-AzMySqlConfiguration -InputObject $ID -Value 150
        $config.Value | Should -Be 150
    }
}
