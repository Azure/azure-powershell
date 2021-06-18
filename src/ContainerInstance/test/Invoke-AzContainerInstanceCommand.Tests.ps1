$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzContainerInstanceCommand.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzContainerInstanceCommand' {
    It 'ExecuteExpanded' {
        Invoke-AzContainerInstanceCommand -ContainerGroupName $env.ContainerGroupName -ContainerName $env.containerInstanceName -ResourceGroupName　$env.ResourceGroupName -Command "echo hello" -TerminalSizeCol 12 -TerminalSizeRow 12    
    }
}
