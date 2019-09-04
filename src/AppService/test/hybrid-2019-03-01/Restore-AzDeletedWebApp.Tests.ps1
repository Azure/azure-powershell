$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzDeletedWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzDeletedWebApp' {
    It 'RestoreExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Restore' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentityExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestoreViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
