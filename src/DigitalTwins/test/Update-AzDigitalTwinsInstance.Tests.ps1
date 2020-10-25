$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDigitalTwinsInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDigitalTwinsInstance' {
    It 'UpdateExpanded' {
        $key = 'dtt'
        $value = '000'
        $tag = @{$key=$value}
        $updateDigitalTwinInstance = Update-AzDigitalTwinsInstance -ResourcegroupName $env.resourceGroup -ResourceName $env.digitalTwins -Tag $tag
        $updateDigitalTwinInstance.Tag.keys.Contains($key) | Should -BeTrue
        $updateDigitalTwinInstance.Tag.Values.Contains($value) | Should -BeTrue
    }

    It 'Update' {
        $key = 'dtt'
        $value = '001'
        $tag = @{$key=$value}
        $updateDigitalTwinInstance1 = Update-AzDigitalTwinsInstance -ResourcegroupName $env.resourceGroup -ResourceName $env.digitalTwins1 -Tag $tag
        $updateDigitalTwinInstance = Update-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins -DigitalTwinsPatchDescription $updateDigitalTwinInstance1
        $updateDigitalTwinInstance.Tag.keys.Contains($key) | Should -BeTrue
        $updateDigitalTwinInstance.Tag.Values.Contains($value) | Should -BeTrue
    }

    It 'UpdateViaIdentityExpanded' {
        $key = 'dtt'
        $value = '002'
        $tag = @{$key=$value}
        $updateDigitalTwinInstance1 = Update-AzDigitalTwinsInstance -ResourcegroupName $env.resourceGroup -ResourceName $env.digitalTwins1 -Tag $tag
        $getDigitalTwinInstance = Get-AzDigitalTwinsInstance -ResourcegroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $updateDigitalTwinInstance = Update-AzDigitalTwinsInstance -InputObject $getDigitalTwinInstance -DigitalTwinsPatchDescription $updateDigitalTwinInstance1
        $updateDigitalTwinInstance.Tag.keys.Contains($key) | Should -BeTrue
        $updateDigitalTwinInstance.Tag.Values.Contains($value) | Should -BeTrue
    }

    It 'UpdateViaIdentity' {
        $key = 'dtt'
        $value = '003'
        $tag = @{$key=$value}
        $getDigitalTwinInstance = Get-AzDigitalTwinsInstance -ResourcegroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $updateDigitalTwinInstance = Update-AzDigitalTwinsInstance -InputObject $getDigitalTwinInstance -Tag $tag
        $updateDigitalTwinInstance.Tag.keys.Contains($key) | Should -BeTrue
        $updateDigitalTwinInstance.Tag.Values.Contains($value) | Should -BeTrue
    }
}