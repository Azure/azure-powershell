$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlConnectionString' {
    It 'Get' {
        $connectionString = Get-AzMySqlConnectionString -Client ADO.NET -Name $env.serverName -ResourceGroupName $env.resourceGroup
        $connectionString.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $connectionString = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName | Get-AzMySqlConnectionString -Client PHP
        $connectionString.Count | Should -Be 1
    }
}
