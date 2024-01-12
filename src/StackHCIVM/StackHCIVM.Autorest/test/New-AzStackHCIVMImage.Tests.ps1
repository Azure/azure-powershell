$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStackHCIVMImage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStackHCIVMImage' {
    It 'MarketplaceURN' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GalleryImage' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Marketplace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
