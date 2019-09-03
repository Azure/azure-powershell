$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPolicyAssignment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzPolicyAssignment' {
    It 'List6' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List5' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List4' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
