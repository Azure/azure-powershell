$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzVMImage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Save-AzVMImage' {
    It 'CaptureExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
