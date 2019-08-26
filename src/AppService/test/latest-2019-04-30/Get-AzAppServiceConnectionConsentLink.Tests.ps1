$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceConnectionConsentLink.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceConnectionConsentLink' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
