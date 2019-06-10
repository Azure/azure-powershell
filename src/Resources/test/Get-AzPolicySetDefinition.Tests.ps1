. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzPolicySetDefinition' {
    It 'GetById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'WithBuiltIn' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
