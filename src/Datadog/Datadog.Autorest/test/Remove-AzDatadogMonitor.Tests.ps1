$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDatadogMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDatadogMonitor' {
    It 'Delete' {
        { Remove-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02 } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
          $obj = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03 
          Remove-AzDatadogMonitor -InputObject $obj
        } | Should -Not -Throw
    }
}
