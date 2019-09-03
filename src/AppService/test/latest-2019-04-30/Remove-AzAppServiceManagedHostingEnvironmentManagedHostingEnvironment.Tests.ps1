$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironment.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironment' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
