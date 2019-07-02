. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzPolicySetDefinition' {
    It 'UpdateById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
