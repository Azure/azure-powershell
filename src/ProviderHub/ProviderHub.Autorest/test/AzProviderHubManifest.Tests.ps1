$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubManifest.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubManifest' {
    It 'Generate and Checkin the resource provider manifest' {
        $generatedManifest = New-AzProviderHubManifest -ProviderNamespace $env.ProviderNamespace
        $generatedManifest | Should -Not -BeNullOrEmpty

        $checkinManifest = Invoke-AzProviderHubManifestCheckin -ProviderNamespace $env.ProviderNamespace -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Canary"
        $checkinManifest | Should -Not -BeNullOrEmpty
    }
}
