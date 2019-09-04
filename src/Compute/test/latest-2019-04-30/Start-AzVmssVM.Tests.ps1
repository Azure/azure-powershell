$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzVmssVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Start-AzVmssVM' {
    It 'Start1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'StartViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
