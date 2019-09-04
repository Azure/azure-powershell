$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzGalleryImageDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzGalleryImageDefinition' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
