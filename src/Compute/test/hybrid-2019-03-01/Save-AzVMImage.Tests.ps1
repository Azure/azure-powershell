$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzVMImage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Save-AzVMImage' {
    It 'CaptureExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
