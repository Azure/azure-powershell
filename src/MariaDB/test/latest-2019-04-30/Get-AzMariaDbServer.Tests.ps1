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
        $mariaDb.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $mariaDb = Get-AzMariaDbServer -Name $env.rstr01 -ResourceGroupName $env.ResourceGroupGet
        $mariaDb.Name | Should -Be $env.rstr01
    }

    It 'List' {
        $mariaDb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroupGet
        $mariaDb.Count | Should -Be 2
    }

    It 'GetViaIdentity' {
        $mariaDbPipein = Get-AzMariaDbServer -Name $env.rstr01 -ResourceGroupName $env.ResourceGroupGet
        $mariaDb = Get-AzMariaDbServer -InputObject $mariaDbPipein
        $mariaDb.Name | Should -Be $env.rstr01
    }
}
