$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorLogAnalyticsSolution.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMonitorLogAnalyticsSolution' {
    It 'UpdateExpanded' {
        $tag = @{'key01' = 1; 'key02' = 2}
        $monitor = Update-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -Tag $tag
        $monitor.Tag.Count | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $tag = @{'key01' = 1; 'key02' = 2; 'key03' = 3}
        $monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        $newMonitor = Update-AzMonitorLogAnalyticsSolution -InputObject $monitor -Tag $tag
        $newMonitor.Tag.Count | Should -Be 3
    }
}
