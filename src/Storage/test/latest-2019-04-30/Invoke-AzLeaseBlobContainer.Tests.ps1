$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzLeaseBlobContainer.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzLeaseBlobContainer' {
    It 'LeaseExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Lease' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LeaseViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LeaseViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
