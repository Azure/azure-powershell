$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVMCommand.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVMCommand' {
    It 'RunExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RunViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
