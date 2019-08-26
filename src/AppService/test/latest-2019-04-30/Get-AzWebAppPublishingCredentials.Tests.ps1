$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppPublishingCredentials.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppPublishingCredentials' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
