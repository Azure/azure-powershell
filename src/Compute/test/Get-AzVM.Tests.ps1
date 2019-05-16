. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzVM' {
    It 'WithStatus' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
