$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzStreamAnalyticsJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzStreamAnalyticsJob' {
  It 'StopExpanded' {
    $result = Stop-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
    $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
    $result.JobState | Should -Be 'Stopped'
    Start-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
    }

    It 'StopViaIdentityExpanded' {
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
        $result = Stop-AzStreamAnalyticsJob -InputObject $result
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
        $result.JobState | Should -Be 'Stopped'    
    }
}
