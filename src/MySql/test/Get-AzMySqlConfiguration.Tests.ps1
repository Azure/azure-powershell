$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlConfiguration' {
    It 'List' {
        $config = Get-AzMySqlConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $config.Count | Should -BeGreaterOrEqual 1       
    }

    It 'Get' {
        $config = Get-AzMySqlConfiguration -Name time_zone -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $config.Name | Should -Be time_zone
    }

    It 'GetViaIdentity' {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySQL/servers/$($env.serverName)/configurations/server_id"
        $config = Get-AzMySqlConfiguration -InputObject $ID 
        $config.Name | Should -Be server_id
    }
}
