$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzADApplication.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzADApplication' {
    It 'PatchExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Patch' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchByApplicationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
