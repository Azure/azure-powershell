$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorLogAnalyticsSolution.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMonitorLogAnalyticsSolution' {
    It 'Delete' {
        $monitor = New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId02
        Remove-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup -Name $monitor.Name
        $monitorList = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup
        $monitorList.Name | Should -Not -Contain $monitor.Name
    }

    It 'DeleteViaIdentity' {
        $monitor = New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId02
        Remove-AzMonitorLogAnalyticsSolution -InputObject $monitor
        $monitorList = Get-AzMonitorLogAnalyticsSolution -ResourceGroupName $env.resourceGroup
        $monitorList.Name | Should -Not -Contain $monitor.Name
    }
}
