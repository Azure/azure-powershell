. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzAppConfigurationStoreNameAvailability' {
    It 'NoType' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
