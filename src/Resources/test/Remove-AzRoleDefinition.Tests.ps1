. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzRoleDefinition' {
    It 'DeleteByName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
