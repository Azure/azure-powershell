$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServerConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzPostgreSqlFlexibleServerConfiguration' {
    It 'List' {
        {
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Count | Should -BeGreaterOrEqual 1      
        } | Should -Not -Throw
    }

    It 'ViaName' {
        { 
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $config.Name | Should -Be work_mem

            $config = Update-AzPostgreSqlFlexibleServerConfiguration -Name work_mem -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Value 10240
            $config.Value | Should -Be 10240
            $config.DefaultValue | Should -Be 4096
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)/configurations/work_mem"
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -InputObject $ID 
            $config.Name | Should -Be work_mem
            $config = Update-AzPostgreSqlFlexibleServerConfiguration -InputObject $config -Value 20480           
            $config.Value | Should -Be 20480
            $config.DefaultValue | Should -Be 4096
        } | Should -Not -Throw
    }
}