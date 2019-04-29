. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADGroup' {
    It 'GetByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
