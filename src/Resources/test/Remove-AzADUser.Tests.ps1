. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADUser' {
    It 'DeleteByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
