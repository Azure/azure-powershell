$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteConnectionKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteConnectionKey' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
