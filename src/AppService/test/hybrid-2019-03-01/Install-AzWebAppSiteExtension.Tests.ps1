$TestRecordingFile = Join-Path $PSScriptRoot 'Install-AzWebAppSiteExtension.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Install-AzWebAppSiteExtension' {
    It 'Install' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'InstallViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
