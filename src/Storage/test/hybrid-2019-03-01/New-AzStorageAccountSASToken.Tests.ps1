$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageAccountSASToken.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageAccountSASToken' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
