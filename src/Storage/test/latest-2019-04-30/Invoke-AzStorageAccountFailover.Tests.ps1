$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStorageAccountFailover.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzStorageAccountFailover' {
    It 'Failover' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FailoverViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
