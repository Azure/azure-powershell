$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageShareSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageShareSASToken' {
    It 'SasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
