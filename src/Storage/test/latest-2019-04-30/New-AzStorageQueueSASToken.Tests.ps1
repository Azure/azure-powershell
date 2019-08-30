$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageQueueSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageQueueSASToken' {
    It 'SasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
