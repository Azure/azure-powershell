$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageContainerSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageContainerSASToken' {
    It 'SasPermission' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasPolicy' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
