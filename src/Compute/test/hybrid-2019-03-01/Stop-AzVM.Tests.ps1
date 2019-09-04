$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzVM' {
    It 'PowerOff' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PowerOffViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
