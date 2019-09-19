$TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzVMImage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Save-AzVMImage' {
    It 'CaptureExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CaptureViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
