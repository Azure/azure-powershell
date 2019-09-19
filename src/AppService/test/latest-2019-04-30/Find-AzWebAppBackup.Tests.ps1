$TestRecordingFile = Join-Path $PSScriptRoot 'Find-AzWebAppBackup.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Find-AzWebAppBackup' {
    It 'DiscoverExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiscoverSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiscoverExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Discover' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiscoverViaIdentityExpandedSlot' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiscoverViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DiscoverViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
