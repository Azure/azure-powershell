. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzPolicySetDefinition' {
    It 'GetById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
