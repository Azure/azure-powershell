$TestRecordingFile = Join-Path $PSScriptRoot 'Switch-AzWebAppSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Switch-AzWebAppSlot' {
    It 'SwapExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Swap1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Swap' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
