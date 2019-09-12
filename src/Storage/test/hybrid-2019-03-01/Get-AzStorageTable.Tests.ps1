$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageTable.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzStorageTable' {
    It 'TableName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TablePrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
