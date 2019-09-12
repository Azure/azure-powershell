$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'New-AzWebAppPublishingPassword.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzWebAppPublishingPassword' {
    It 'GenerateBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
