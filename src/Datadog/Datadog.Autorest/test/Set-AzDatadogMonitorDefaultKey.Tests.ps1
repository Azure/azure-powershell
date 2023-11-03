$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDatadogMonitorDefaultKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzDatadogMonitorDefaultKey' {
    It 'SetExpanded' {
        { 
            Set-AzDatadogMonitorDefaultKey -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Key 'xxxxxxxxxxxxxxxxxxxxxx'
        } | Should -Not -Throw
    }
}
