$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVmssVMReimage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVmssVMReimage' {
    It 'ReimageExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
