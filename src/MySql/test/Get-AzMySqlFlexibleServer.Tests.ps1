$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlFlexibleServer' {
    It 'List1' {
        {
            $servers = Get-AzMySqlFlexibleServer
            $servers.Count | Should -BeGreaterOrEqual 1    
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $servers = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            $servers.Name | Should -Be $env.flexibleServerName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $servers = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup
            $servers.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.DBForMySql/flexibleServers/$($env.flexibleServerName)"
            $servers = Get-AzMySqlFlexibleServer -InputObject $ID
            $servers.Name | Should -Be $env.flexibleServerName
        } | Should -Not -Throw
    }
}
