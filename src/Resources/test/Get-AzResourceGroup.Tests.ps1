. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzResourceGroup' {
    It 'GetByTag' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
