$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageTableSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageTableSASToken' {
    It 'SasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
