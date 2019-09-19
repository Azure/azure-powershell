$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADApplication' {
    It 'Delete2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'HardDelete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByDisplayName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteByApplicationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity2' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
