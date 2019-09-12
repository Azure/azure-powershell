$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageAccount.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageAccount' {
    It 'List2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
