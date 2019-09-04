$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Get-AzProviderFeature.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzProviderFeature' {
    It 'ListRegistered' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetByFeature' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByNamespace' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListAvailable' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
