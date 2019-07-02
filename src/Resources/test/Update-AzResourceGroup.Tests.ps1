. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzResourceGroup' {
    It 'UpdateById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
