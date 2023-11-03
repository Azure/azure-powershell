$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbServer' {
    It 'List1' {
        $mariaDb = Get-AzMariaDbServer
        $mariaDb.Count | Should -BeGreaterOrEqual 7
    }

    It 'Get' {
        $mariaDb = Get-AzMariaDbServer -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $mariaDb.Name | Should -Be $env.rstrbc01
    }

    It 'List' {
        $mariaDb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariaDb.Count | Should -Be 7
    }
}
