. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzDeployment' {
    It 'DeleteById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
