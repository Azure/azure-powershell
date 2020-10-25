$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDigitalTwinsInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDigitalTwinsInstance' {
    It 'List' {
        $DigitalTwinsInstanceList = Get-AzDigitalTwinsInstance
        $DigitalTwinsInstanceList.Count | Should -Be 2
    }

    It 'List1' {
        $DigitalTwinsInstanceList = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup
        $DigitalTwinsInstanceList.Count | Should -Be 2
    }

    It 'Get' {
        $DigitalTwinsInstance = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $DigitalTwinsInstance.Name | Should -Be $env.digitalTwins
    }

    It 'GetViaIdentity' {
        $DigitalTwinsInstance01 = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $DigitalTwinsInstance = Get-AzDigitalTwinsInstance -inputObject $DigitalTwinsInstance01
        $DigitalTwinsInstance.Name | Should -Be $env.digitalTwins
    }
}
