$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCloudServiceOSFamily.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCloudServiceOSFamily' {
    It 'List OS families in location' {
        $osFamilies = Get-AzCloudServiceOSFamily -location $env.Location
        $osFamilies.Count | Should BeGreaterThan 0
    }

    It 'Get OS family' {
        $osFamily = Get-AzCloudServiceOSFamily -location $env.Location -OSFamilyName $env.OSFamilyName
        $osFamily.Name | Should Not BeNullOrEmpty
        $osFamily.Label | Should Not BeNullOrEmpty
    }

    # TODO: add this test once id is fixed on server side to match case sensitive req
    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
