. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzRoleDefinition' {
    It 'GetByCustom' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
