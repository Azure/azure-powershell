$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzVM' {
    It 'Restart' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
