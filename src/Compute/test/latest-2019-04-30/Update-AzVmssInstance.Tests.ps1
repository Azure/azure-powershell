$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzVmssInstance.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzVmssInstance' {
    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
