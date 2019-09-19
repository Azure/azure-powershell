$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzGalleryApplicationVersion.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzGalleryApplicationVersion' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
