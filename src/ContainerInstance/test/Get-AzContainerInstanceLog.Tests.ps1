$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerInstanceLog.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzContainerInstanceLog' {
    It 'List' {
        Get-AzContainerInstanceLog -ContainerGroupName $env.containerGroupName -ContainerName $env.containerInstanceName -ResourceGroupName $env.resourceGroupName
    }

    It 'Get the tail 2 lines of log of a container instance' {
        Get-AzContainerInstanceLog -ContainerGroupName $env.containerGroupName -ContainerName $env.containerInstanceName -ResourceGroupName $env.resourceGroupName -Tail 2
    }
}
