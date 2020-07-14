$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorLogAnalyticsSolution.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMonitorLogAnalyticsSolution' {
    It 'List1' {
        $monitorList = Get-AzMonitorLogAnalyticsSolution 
        $monitorList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        $monitor.Name | Should -Be $env.monitorName01
    }

    It 'List' {
        $monitorList = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup
        $monitorList.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $monitor = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        $newMonitor = Get-AzMonitorLogAnalyticsSolution -InputObject $monitor
        $newMonitor.Name | Should -Be $env.monitorName01
    }
}
