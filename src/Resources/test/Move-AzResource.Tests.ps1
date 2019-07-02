. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Move-AzResource' {
    It 'MoveByComponents' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
