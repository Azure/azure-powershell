. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzADGroupMember' {
    It 'GetByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByOwner' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
