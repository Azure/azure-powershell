. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADApplication' {
    It 'HardDelete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
