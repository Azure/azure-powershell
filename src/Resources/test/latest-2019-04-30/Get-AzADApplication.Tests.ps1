$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADApplication' {
    It 'List2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetDeleted' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByIdentifierUri' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByDisplayNamePrefix' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByApplicationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
