$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerGroupSpotPriority.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzContainerGroupSpotPriority' {
    
   It 'Get' {
        $get = Get-AzContainerGroup -Name $env.spotContainerGroupName -ResourceGroupName $env.resourceGroupName
        $get.Priority | Should -Be $env.spotPriority
    }

    It 'GetViaIdentity' {
        $get = Update-AzContainerGroup -Name $env.spotContainerGroupName -ResourceGroupName $env.resourceGroupName -Tag @{"key"="value"}
        Get-AzContainerGroup -InputObject $get
    }
}
