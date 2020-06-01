$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTimeSeriesInsightsEventSource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzTimeSeriesInsightsEventSource' {
    It 'UpdateExpanded' {
        $environmentName = $env.tsiEnvName
        $eventSourceName = $env.tsiEsName
        $key = 'tag1'
        $value = '001'
        $tag = @{$key=$value}
        $updateTsiEventSource = Update-AzTimeSeriesInsightsEventSource -EnvironmentName $environmentName -Name $eventSourceName -ResourceGroupName $env.ResourceGroup -Tag $tag
        $updateTsiEventSource.Tag.keys.Contains($key) | Should -BeTrue
        $updateTsiEventSource.Tag.Values.Contains($value) | Should -BeTrue
    }

    It 'UpdateViaIdentityExpanded' {
        $environmentName = $env.tsiEnvName
        $eventSourceName = $env.tsiEsName
        $getTsiEventSorce = Get-AzTimeSeriesInsightsEventSource -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup -Name $eventSourceName
        $key = 'tag2'
        $value = '002'
        $tag = @{$key=$value}
        $updateTsiEventSource = Update-AzTimeSeriesInsightsEventSource -InputObject $getTsiEventSorce -Tag $tag
        $updateTsiEventSource.Tag.keys.Contains($key) | Should -BeTrue
        $updateTsiEventSource.Tag.Values.Contains($value) | Should -BeTrue
    }
}
