$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzWebSiteDomainOwnershipIdentifier.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzWebSiteDomainOwnershipIdentifier' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
