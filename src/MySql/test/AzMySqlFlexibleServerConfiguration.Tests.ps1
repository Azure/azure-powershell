$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzMySqlFlexibleServerConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzMySqlFlexibleServerConfiguration' {
    It 'List' {
        {
            $config = Get-AzMySqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Count | Should -BeGreaterOrEqual 1      
        } | Should -Not -Throw
    }

    It 'ViaName' {
        { 
            $config = Get-AzMySqlFlexibleServerConfiguration -Name time_zone -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Name | Should -Be time_zone
            $config = Update-AzMySqlFlexibleServerConfiguration -Name net_retry_count -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Value 15
            $config.Value | Should -Be 15
            $config.DefaultValue | Should -Be 10
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBforMySQL/flexibleServers/$($env.flexibleServerName)/configurations/wait_timeout"
            $config = Get-AzMySqlFlexibleServerConfiguration -InputObject $ID 
            $config.Name | Should -Be wait_timeout
            $config = Update-AzMySqlFlexibleServerConfiguration -InputObject $config -Value 10000           
            $config.Value | Should -Be 10000
            $config.DefaultValue | Should -Be 28800
        } | Should -Not -Throw
    }
}