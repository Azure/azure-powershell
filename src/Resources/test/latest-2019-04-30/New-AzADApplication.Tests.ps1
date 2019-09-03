$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzADApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzADApplication' {
    It 'CreateExpanded2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Create2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
