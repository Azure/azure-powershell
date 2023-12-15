$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStackHCIVMVirtualMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStackHCIVMVirtualMachine' {
    It 'ByImageId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByImageName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByOsDiskId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByOsDiskName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
