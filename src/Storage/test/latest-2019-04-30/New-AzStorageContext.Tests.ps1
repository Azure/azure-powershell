$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageContext.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzStorageContext' {
    It 'OAuthAccount' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'OAuthAccountEnvironment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasTokenWithAzureEnvironment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SasToken' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnonymousAccountEnvironment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AnonymousAccount' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AccountNameAndKeyEnvironment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AccountNameAndKey' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConnectionString' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LocalDevelopment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
