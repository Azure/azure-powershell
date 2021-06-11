$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStreamAnalyticsJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStreamAnalyticsJob' {
    It 'UpdateExpanded' {
      { Update-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 -EventsLateArrivalMaxDelayInSecond 13 -EventsOutOfOrderMaxDelayInSecond 21 } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
      $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01
      { Update-AzStreamAnalyticsJob -InputObject $result -EventsLateArrivalMaxDelayInSecond 13 -EventsOutOfOrderMaxDelayInSecond 21 } | Should -Not -Throw
    }

}
