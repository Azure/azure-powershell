$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzContainerGroupSpotPriority.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzContainerGroupSpotPriority' {
    It 'Start' {
        Start-AzContainerGroup -Name $env.spotContainerGroupName -ResourceGroupName $env.resourceGroupName
    }

    It 'StartViaIdentity' {
        $start = Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.spotContainerGroupName
        Start-AzContainerGroup -InputObject $start
    }
}
