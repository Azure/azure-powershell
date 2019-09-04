$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceConnectionKey.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceConnectionKey' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
