$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTimeSeriesInsightsEventSource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzTimeSeriesInsightsEventSource' {
    It 'Delete' {
        $environmentName = $env.rstrenv03
        $tsiEevntSourceName = $env.rstres03 
        Remove-AzTimeSeriesInsightsEventSource -EnvironmentName $environmentName -Name $tsiEevntSourceName -ResourceGroupName $env.ResourceGroup
        $tsiEventSorceList = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $environmentName -ResourceGroupName $env.ResourceGroup
        $tsiEventSorceList.Name | Should -Not -Contain $tsiEevntSourceName
    }

    It 'DeleteViaIdentity' {
        $environmentName = $env.tsiEnvName01
        $tsiEevntSourceName = $env.tsiEsName01 
        $getTsiEventSorce = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup -Name $tsiEevntSourceName
        Remove-AzTimeSeriesInsightsEventSource -InputObject $getTsiEventSorce
        $tsiEventSorceList = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $environmentName -ResourceGroupName $env.ResourceGroup
        $tsiEventSorceList.Name | Should -Not -Contain $getTsiEventSorce.Name
    }
}
