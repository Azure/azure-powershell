$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Test-AzDeployment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Test-AzDeployment' {
    It 'ValidateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Validate1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Validate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ValidateViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
