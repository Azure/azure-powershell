. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzResourceGroup' {
    It 'DeleteById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
