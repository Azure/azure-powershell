$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSapMonitorProviderInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzSapMonitorProviderInstance' {
    It 'Delete' {
        Remove-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01 -Name $env.sapIns01
        $sapInsList = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01
        $sapInsList.Name | Should -Not -Contain $env.sapIns01
    }

    It 'DeleteViaIdentity' {
        $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01 -Name $env.sapIns02
        Remove-AzSapMonitorProviderInstance -InputObject $sapIns
        $sapInsList = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01
        $sapInsList.Name | Should -Not -Contain $env.sapIns02
    }
}
