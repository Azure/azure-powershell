$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzGalleryImageVersion.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzGalleryImageVersion' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
