$TestRecordingFile = Join-Path $PSScriptRoot 'ConvertTo-AzVMManagedDisk.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'ConvertTo-AzVMManagedDisk' {
    It 'Convert' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConvertViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
