$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataDogMonitorSetPasswordLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDataDogMonitorSetPasswordLink' {
    It 'Refresh' {
        { Update-AzDataDogMonitorSetPasswordLink -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 } | Should -Not -Throw
    }

    It 'RefreshViaIdentity' {
        {
          $obj = Get-AzDataDogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
          Update-AzDataDogMonitorSetPasswordLink -InputObject $obj
        } | Should -Not -Throw
    }
}
