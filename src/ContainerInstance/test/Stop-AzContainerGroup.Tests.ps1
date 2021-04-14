$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzContainerGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzContainerGroup' {
    It 'Stop' {
        Stop-AzContainerGroup -Name $env.containerGroupName -ResourceGroupName $env.resourceGroupName
    }

    It 'StopViaIdentity' {
        Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName | Stop-AzContainerGroup
    }
}
