$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. "$loadEnvPath"
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName
Write-Host "group:", $evn.resourceGroup
Describe 'Get-AzMySqlServer' {
    $servers = $null
    It 'List1' {
        { 
            $servers = Get-AzMySqlServer 
        } | Should -Not -Throw
        $servers.Length | Should Be 1
    }

    It 'Get' {
        $servers = $null
        {
            $servers = Get-AzMySqlServer -ResourceGroupName $evn.resourceGroup -Name $env.serverName
        } | Should -Not -Throw
        $servers.Length | Should Be 1
    }

    It 'List' {
        $servers = $null
        {
            $servers = Get-AzMySqlServer -ResourceGroupName $evn.resourceGroup
        } | Should -Not -Throw
        $servers.Length | Should Be 1
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
