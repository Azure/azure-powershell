$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlConfiguration' {
    It 'List' {
        $config = Get-AzPostgreSqlConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $config.Count | Should -BeGreaterOrEqual 1       
    }

    It 'Get' {
        $config = Get-AzPostgreSqlConfiguration -Name timezone -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $config.Name | Should -Be timezone
    }

    It 'GetViaIdentity' -Skip {
        $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforPostgreSQL/servers/$($env.serverName)/configurations/datestyle"
        $config = Get-AzPostgreSqlConfiguration -InputObject $ID 
        $config.Name | Should -Be datestyle
    }
}
