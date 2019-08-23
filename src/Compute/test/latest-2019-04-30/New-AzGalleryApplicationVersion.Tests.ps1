$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzGalleryApplicationVersion.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzGalleryApplicationVersion' {
    It 'CreateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
