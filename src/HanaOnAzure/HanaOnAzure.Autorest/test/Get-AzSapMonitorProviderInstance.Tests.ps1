$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSapMonitorProviderInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzSapMonitorProviderInstance' {
    It 'List' {
        $sapInsList = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01
        $sapInsList.Count | Should -Be 2
    }

    It 'Get' {
        $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01 -Name $env.sapIns01
        $sapIns.Name | Should -Be $env.sapIns01
    }

    It 'GetViaIdentity' {
        $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor01 -Name $env.sapIns01
        $sapIns = Get-AzSapMonitorProviderInstance -InputObject $sapIns
        $sapIns.Name | Should -Be $env.sapIns01
    }
}
