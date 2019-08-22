$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPolicyDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzPolicyDefinition' {
    It 'List2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity3' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
