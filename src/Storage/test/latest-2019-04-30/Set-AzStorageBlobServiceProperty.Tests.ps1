$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzStorageBlobServiceProperty.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzStorageBlobServiceProperty' {
    It 'SetExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Set' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
