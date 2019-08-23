$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzVmssVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restart-AzVmssVM' {
    It 'Restart1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestartViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
