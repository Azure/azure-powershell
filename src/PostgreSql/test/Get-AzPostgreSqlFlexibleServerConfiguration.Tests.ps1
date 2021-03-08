$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlFlexibleServerConfiguration' {
    It 'List' {
        {
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Count | Should -BeGreaterOrEqual 1      
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -Name TimeZone -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Name | Should -Be TimeZone
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/configurations/TimeZone"
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -InputObject $ID 
            $config.Name | Should -Be TimeZone
        } | Should -Not -Throw
    }
}
