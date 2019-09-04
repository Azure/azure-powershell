$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzVM' {
    It 'PowerOff1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PowerOffViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
