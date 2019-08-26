$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReissueAppServiceCertificateOrder.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzReissueAppServiceCertificateOrder' {
    It 'ReissueExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Reissue' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReissueViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReissueViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
