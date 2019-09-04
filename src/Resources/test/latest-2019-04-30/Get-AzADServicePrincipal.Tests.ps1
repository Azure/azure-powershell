$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADServicePrincipal.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADServicePrincipal' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByApplicationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByDisplayNamePrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetBySPN' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
