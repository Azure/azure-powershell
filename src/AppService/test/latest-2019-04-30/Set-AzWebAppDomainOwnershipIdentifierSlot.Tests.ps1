$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebAppDomainOwnershipIdentifierSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebAppDomainOwnershipIdentifierSlot' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
