$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageDirectory.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzStorageDirectory' {
    It 'ShareName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Share' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Directory' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
