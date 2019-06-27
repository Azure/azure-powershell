$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\AppService\test' 'Get-AzWebAppPublishingProfile.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppPublishingProfile' {
    It 'ListBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
