$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVmssVMCommand.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVmssVMCommand' {
    It 'RunExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
