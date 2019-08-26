$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppServiceClassicMobileServiceClassicMobileService.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzAppServiceClassicMobileServiceClassicMobileService' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
