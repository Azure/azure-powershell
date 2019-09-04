$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADGroupMember.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADGroupMember' {
    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByOwner' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
