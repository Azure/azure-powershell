$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVmssReimage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVmssReimage' {
    It 'ReimageExpanded2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageExpanded3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
