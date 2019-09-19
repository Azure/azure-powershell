$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzVMImage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Save-AzVMImage' {
    It 'CaptureExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
