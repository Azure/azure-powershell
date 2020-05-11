$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTimeSeriesInsightsEnvironment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzTimeSeriesInsightsEnvironment' {
    It 'Delete' {
        $environmentName = $env.rstrenv01
        Remove-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $tisEnvList = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup 
        $tisEnvList.Name | Should -Not -Contain  $environmentName
    }
    It 'DeleteInputObject' {
        $environmentName = $env.rstrenv02
        $tsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        Remove-AzTimeSeriesInsightsEnvironment -InputObject $tsiEnv
        $tisEnvList = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup 
        $tisEnvList.Name | Should -Not -Contain $environmentName
    }
}
