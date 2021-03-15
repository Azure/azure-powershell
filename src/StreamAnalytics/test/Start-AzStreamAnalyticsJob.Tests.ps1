$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzStreamAnalyticsJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzStreamAnalyticsJob' {
    It 'StartExpanded' {
        $result = Start-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
        $result.JobState | Should -Be 'Running'
        Stop-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
    }

    It 'StartViaIdentityExpanded' {
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
        $result = Start-AzStreamAnalyticsJob -InputObject $result
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01 
        $result.JobState | Should -Be 'Running'    
    }

}
