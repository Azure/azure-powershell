$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSapMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzSapMonitor' {
    It 'List' {
        $sapMonitorList = Get-AzSapMonitor
        $sapMonitorList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $sapMonitor = Get-AzSapMonitor -ResourceGroupName $env.resourceGroup -Name $env.sapMonitor01
        $sapMonitor.Name | Should -Be $env.sapMonitor01
    }

    It 'GetViaIdentity' {
        $sapMonitor = Get-AzSapMonitor -ResourceGroupName $env.resourceGroup -Name $env.sapMonitor01
        $sapMonitor = Get-AzSapMonitor -InputObject $sapMonitor
        $sapMonitor.Name | Should -Be $env.sapMonitor01
    }
}
