. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzTag' {
    It 'CreateWithValue' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
