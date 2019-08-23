$TestRecordingFile = Join-Path $PSScriptRoot 'ConvertTo-AzVMManagedDisk.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'ConvertTo-AzVMManagedDisk' {
    It 'Convert1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConvertViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
