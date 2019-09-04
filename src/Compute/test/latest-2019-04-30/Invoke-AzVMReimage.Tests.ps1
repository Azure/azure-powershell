$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVMReimage.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzVMReimage' {
    It 'Redeploy1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RedeployViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
