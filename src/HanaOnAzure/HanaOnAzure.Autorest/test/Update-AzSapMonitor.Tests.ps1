$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSapMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzSapMonitor' {
    It 'UpdateExpanded' {
        $sapMonitor = Update-AzSapMonitor -ResourceGroupName $env.resourceGroup -Name $env.sapMonitor01 -Tag @{'key'=1;'key2'=2; 'key3'=3}
        $sapMonitor.Tag.Count | Should -Be 3
    }

    It 'UpdateViaIdentity' {
        $sapMonitor = Get-AzSapMonitor -ResourceGroupName $env.resourceGroup -Name $env.sapMonitor01 
        $sapMonitor = Update-AzSapMonitor -InputObject $sapMonitor -Tag @{'key'=1;'key2'=2}
        $sapMonitor.Tag.Count | Should -Be 2  
        }
}
