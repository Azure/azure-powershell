$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSapMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzSapMonitor' {
    It 'CreateExpanded' {
        $sapMonitor = New-AzSapMonitor -Name $env.sapMonitor02 -ResourceGroupName $env.resourceGroup -Location $env.location -EnableCustomerAnalytic `
        -MonitorSubnet $env.MonitorSubnet `
        -LogAnalyticsWorkspaceSharedKey $env.workspace02Key `
        -LogAnalyticsWorkspaceId $env.workspace02Id `
        -LogAnalyticsWorkspaceResourceId $env.workspaceResourceId02

        $sapMonitor.ProvisioningState | Should -Be 'Succeeded'
    }
}
