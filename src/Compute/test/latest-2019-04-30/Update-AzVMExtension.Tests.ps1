$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzVMExtension.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzVMExtension' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
