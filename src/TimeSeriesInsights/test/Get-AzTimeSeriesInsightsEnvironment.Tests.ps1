$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTimeSeriesInsightsEnvironment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzTimeSeriesInsightsEnvironment' {
    It 'List' {
        $tsiList = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup
        $tsiList.Count | Should -Be 2
    }

    It 'Get' {
        $tsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.tsiEnvName
        $tsiEnv.Name | Should -Be $env.tsiEnvName
    }
    It 'InputObject' {
        $tsiEnv01 = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $env.tsiEnvName01
        $tsiEnv = Get-AzTimeSeriesInsightsEnvironment -InputObject $tsiEnv01
        $tsiEnv.Name | Should -Be $env.tsiEnvName01
    }
}
