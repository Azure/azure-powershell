$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageFileSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageFileSASToken' {
    It 'NameSasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'NameSasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileSasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileSasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
