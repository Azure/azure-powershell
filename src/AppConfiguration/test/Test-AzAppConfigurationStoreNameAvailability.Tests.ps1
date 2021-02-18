$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppConfigurationStoreNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzAppConfigurationStoreNameAvailability' {
    It 'CheckExpanded' {
        $nameAvailability = Test-AzAppConfigurationStoreNameAvailability -Name "appconf-randomname"
        $nameAvailability.NameAvailable | Should -BeTrue

        $nameAvailability = Test-AzAppConfigurationStoreNameAvailability -Name $env.appconfName00
        $nameAvailability.NameAvailable | Should -BeFalse
    }
}
