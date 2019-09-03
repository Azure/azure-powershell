$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppMetric.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppMetric' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByFilter' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
