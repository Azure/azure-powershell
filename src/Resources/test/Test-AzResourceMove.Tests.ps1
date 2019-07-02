. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzResourceMove' {
    It 'ValidateByComponents' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
