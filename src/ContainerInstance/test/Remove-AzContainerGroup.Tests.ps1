$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzContainerGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzContainerGroup' {
    It 'Delete' {
        Remove-AzContainerGroup -Name $env.containerGroupName -ResourceGroupName $env.resourceGroupName
    }

    It 'DeleteViaIdentity' {
        Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName | Remove-AzContainerGroup
    }
}
