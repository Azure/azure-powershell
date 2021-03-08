$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzPostgreSqlFlexibleServer' {
    It 'List1' {
        {
            $servers = Get-AzPostgreSqlFlexibleServer
            $servers.Count | Should -BeGreaterOrEqual 1    
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            $servers.Name | Should -Be $env.flexibleServerName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup
            $servers.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForPostgreSql/flexibleServers/$($env.flexibleServerName)"
            $servers = Get-AzPostgreSqlFlexibleServer -InputObject $ID
            $servers.Name | Should -Be $env.flexibleServerName
        } | Should -Not -Throw
    }
}
