$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebSiteInstanceDeploymentSlot.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzWebSiteInstanceDeploymentSlot' {
    It 'Delete' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
