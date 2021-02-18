$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTimeSeriesInsightsEventSource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzTimeSeriesInsightsEventSource' {
    It 'List' {
        $tsiEventSorceList = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup
        $tsiEventSorceList.Count | Should -Be 1
    }

    It 'Get' {
        $getTsiEventSorce = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -Name $env.tsiEsName
        $getTsiEventSorce.Name | Should -Be $env.tsiEsName
    }

    It 'GetViaIdentity' {
        $getTsiEventSorce01 = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -Name $env.tsiEsName
        $getTsiEventSorce = Get-AzTimeSeriesInsightsEventSource -InputObject $getTsiEventSorce01
        $getTsiEventSorce.Name | Should -Be $getTsiEventSorce01.Name
    }
}
