$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPolicyDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzPolicyDefinition' {
    It 'GetById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'WithBuiltIn' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
