. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzResource' {
    It 'GetByTag' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByTagNameAndValue' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
