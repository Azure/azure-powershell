$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzGalleryApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzGalleryApplication' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
