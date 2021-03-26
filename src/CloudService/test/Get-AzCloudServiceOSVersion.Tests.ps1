$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCloudServiceOSVersion.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCloudServiceOSVersion' {
    It 'List OS versions in location' {
        $osVersions = Get-AzCloudServiceOSVersion -Location $env.Location
        $osVersions.Count | Should BeGreaterThan 0
    }

    It 'Get OS version' {
        $osVersion = Get-AzCloudServiceOSVersion -Location $env.Location -OSVersionName $env.OSVersionName
        $osVersion.Name | Should Not BeNullOrEmpty
        $osVersion.Family | Should Not BeNullOrEmpty
        $osVersion.FamilyLabel | Should Not BeNullOrEmpty
        $osVersion.Version | Should Not BeNullOrEmpty
        $osVersion.Label | Should Not BeNullOrEmpty
    }

    # TODO: add this test once id is fixed on server side to match case sensitive req
    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
