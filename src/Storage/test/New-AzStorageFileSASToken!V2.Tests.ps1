$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'New-AzStorageFileSASToken!V2.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageFileSASToken!V2' {
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
