$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVmssReimage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVmssReimage' {
    It 'ReimageExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
