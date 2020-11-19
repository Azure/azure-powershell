$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDigitalTwinsInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDigitalTwinsInstance' {
    It 'Delete' {
        Remove-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $digitalTwinsList = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup
        $tisEnvList.Name | Should -Not -Contain $env.digitalTwins
    }

    It 'DeleteViaIdentity' {
        $getDigitalTwinsInstance1 = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins1
        Remove-AzDigitalTwinsInstance -InputObject $getDigitalTwinsInstance1
        $digitalTwinsList = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup
        $tisEnvList.Name | Should -Not -Contain $env.digitalTwins1
    }
}
