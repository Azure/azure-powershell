$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDigitalTwinsInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDigitalTwinsInstance' {
    It 'CreateExpanded'{
        $NewAzDigitalTwinsInstance = New-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins -Location $env.location
        $NewAzDigitalTwinsInstance.Name | Should -Be $env.digitalTwins
    }

    It 'Create' {
        $key = 'dtt1'
        $value = '001'
        $tag = @($key=$value)
        $getAzdigitalTwins = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $NewAzDigitalTwinsInstance = New-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins1 -DigitalTwinsCreate $getAzdigitalTwins
        $NewAzDigitalTwinsInstance.Name | Should -Be $env.digitalTwins1
    }
}
