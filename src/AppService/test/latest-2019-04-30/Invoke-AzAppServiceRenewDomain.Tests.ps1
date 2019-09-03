$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzAppServiceRenewDomain.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzAppServiceRenewDomain' {
    It 'Renew' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RenewViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
