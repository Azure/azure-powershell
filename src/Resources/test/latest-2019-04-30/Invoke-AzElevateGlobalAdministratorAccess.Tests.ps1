$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzElevateGlobalAdministratorAccess.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Invoke-AzElevateGlobalAdministratorAccess' {
    It 'Elevate' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
