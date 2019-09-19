$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzRoleDefinition' {
    It 'Get1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByCustom' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
