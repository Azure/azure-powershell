$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorLogAnalyticsSolution.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMonitorLogAnalyticsSolution' {
    It 'CreateExpanded' {
        $monitor = New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId02
        $monitor.ProvisioningState | Should -Be 'Succeeded'

        $monitor = New-AzMonitorLogAnalyticsSolution -Type SecurityCenterFree -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId01
        $monitor.ProvisioningState | Should -Be 'Succeeded'

        $monitor = New-AzMonitorLogAnalyticsSolution -Type Security -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId01
        $monitor.ProvisioningState | Should -Be 'Succeeded'

        $monitor = New-AzMonitorLogAnalyticsSolution -Type Updates -ResourceGroupName $env.resourceGroup -Location $env.location -WorkspaceResourceId $env.workspaceResourceId01
        $monitor.ProvisioningState | Should -Be 'Succeeded'
    }
}
