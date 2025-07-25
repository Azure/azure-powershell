$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResourceGraphQuery.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzResourceGraphQuery' {
    It 'List'  {
        $queryList = Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup
        $queryList.Count | Should -Be 2
    }

    It 'Get' {
        $query = Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup -Name $env.query01
        $query.Name | Should -Be $env.query01
    }

    It 'GetViaIdentity' {
        $query = Get-AzResourceGraphQuery -ResourceGroupName $env.resourceGroup -Name $env.query01
        $query = Get-AzResourceGraphQuery -InputObject $query
        $query.Name | Should -Be $env.query01
    }
}
