. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Add-AzADGroupOwner' {
    It 'AddByComponents' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
