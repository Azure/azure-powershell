$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDisk.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzDisk' {
    It 'Delete1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
