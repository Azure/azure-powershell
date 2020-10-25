$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzDigitalTwinsInstanceNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzDigitalTwinsInstanceNameAvailability' {
    It 'CheckExpanded' {
        $testAzDigitalTwinsnameResult = Test-AzDigitalTwinsInstanceNameAvailability -Location $env.location -name $env.testDigitalTwinsName
        $testAzDigitalTwinsnameResult.NameAvailable | Should -Be $True
    }

    It 'Check' {
        $testAzDigitalTwinsname = New-AzDigitalTwinsCheckNameRequestObject -name $env.testDigitalTwinsName
        $testAzDigitalTwinsnameResult = Test-AzDigitalTwinsInstanceNameAvailability -Location $env.location -DigitalTwinsInstanceCheckName $testAzDigitalTwinsname
        $testAzDigitalTwinsnameResult.NameAvailable | Should -Be $True
    }

    It 'CheckViaIdentityExpanded' {
        $getDigitalTwins = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $testAzDigitalTwinsnameResult = Test-AzDigitalTwinsInstanceNameAvailability -InputObject $getDigitalTwins -DigitalTwinsInstanceCheckName $getDigitalTwins
        $testAzDigitalTwinsnameResult.NameAvailable | Should -Be $False
    }

    It 'CheckViaIdentity' {
        $getDigitalTwins = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.digitalTwins
        $testAzDigitalTwinsnameResult = Test-AzDigitalTwinsInstanceNameAvailability -InputObject $getDigitalTwins -name $env.testDigitalTwinsName
        $testAzDigitalTwinsnameResult.NameAvailable | Should -Be $True
    }
}
