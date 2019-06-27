. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Stop-AzDeployment' {
    It 'CancelById' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
