$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppServiceSiteIdentifierAssignedToHostName.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzAppServiceSiteIdentifierAssignedToHostName' {
    It 'ListExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
