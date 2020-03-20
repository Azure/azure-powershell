$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlServer' {
    It 'List1' {
        { 
            $servers = Get-AzMySqlServer
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -Name $env.serverName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $servers = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
