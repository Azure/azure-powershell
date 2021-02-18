$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedKubernetes.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConnectedKubernetes' {
    It 'List1' {
        $connaksList = Get-AzConnectedKubernetes
        $connaksList.Count | Should -BeGreaterOrEqual 2
    }
    It 'List' {
        $connaksList = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup
        $connaksList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName00
        $connaks.Name | Should -Be $env.connaksName00
    }

    It 'GetViaIdentity' {
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName01
        $connaks = Get-AzConnectedKubernetes -InputObject $connaks
        $connaks.Name | Should -Be $env.connaksName01
    }
}
