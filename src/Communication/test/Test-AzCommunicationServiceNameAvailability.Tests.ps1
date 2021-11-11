$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzCommunicationServiceNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzCommunicationServiceNameAvailability' {
    It 'CheckExpanded' {
        $nameAvailability = Test-AzCommunicationServiceNameAvailability -Name $env.resourceNameAvailable
        $nameAvailability.NameAvailable | Should -BeTrue

        $nameAvailability = Test-AzCommunicationServiceNameAvailability -Name $env.persistentResourceName
        $nameAvailability.NameAvailable | Should -BeFalse
    }
}
