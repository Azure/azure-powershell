$TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzResource.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Move-AzResource' {
    It 'MoveExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveByComponents' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Move' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MoveViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
