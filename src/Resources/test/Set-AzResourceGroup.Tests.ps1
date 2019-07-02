. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzResourceGroup' {
    It 'UpdateById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
