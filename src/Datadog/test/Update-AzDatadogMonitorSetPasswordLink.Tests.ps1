$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDatadogMonitorSetPasswordLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDatadogMonitorSetPasswordLink' {
    It 'Refresh' {
        { Update-AzDatadogMonitorSetPasswordLink -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 } | Should -Not -Throw
    }

    It 'RefreshViaIdentity' {
        {
          $obj = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
          Update-AzDatadogMonitorSetPasswordLink -InputObject $obj
        } | Should -Not -Throw
    }
}
