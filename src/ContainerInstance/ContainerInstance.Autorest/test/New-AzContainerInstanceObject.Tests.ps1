$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerInstanceContainerObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzContainerInstanceContainerObject' {
    It '__AllParameterSets' {
        $container = New-AzContainerInstanceObject -Name "test-container" -Image $env.image -RequestCpu 1 -RequestMemoryInGb 1.5
        $container.Name | Should -Be "test-container"
        $container.Image | Should -Be $env.image
        $container.RequestCpu | Should -Be 1
        $container.RequestMemoryInGb | Should -Be 1.5
    }
}
