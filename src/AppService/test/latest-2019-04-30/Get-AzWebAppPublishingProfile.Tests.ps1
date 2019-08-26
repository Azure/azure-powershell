$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppPublishingProfile.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppPublishingProfile' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
