$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzVmssVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzVmssVM' {
    It 'PowerOff' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PowerOffViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
