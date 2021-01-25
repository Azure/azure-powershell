$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlFlexibleServerConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlFlexibleServerConfiguration' {
    It 'List' {
        {
            $config = Get-AzMySqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Count | Should -BeGreaterOrEqual 1      
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $config = Get-AzMySqlFlexibleServerConfiguration -Name time_zone -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Name | Should -Be time_zone
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)/configurations/server_id"
            $config = Get-AzMySqlFlexibleServerConfiguration -InputObject $ID 
            $config.Name | Should -Be server_id
        } | Should -Not -Throw
    }
}
