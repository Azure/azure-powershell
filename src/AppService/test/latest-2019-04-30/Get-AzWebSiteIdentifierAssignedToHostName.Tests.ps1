$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebSiteIdentifierAssignedToHostName.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebSiteIdentifierAssignedToHostName' {
    It 'ListExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
