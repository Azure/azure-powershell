$TestRecordingFile = Join-Path $PSScriptRoot 'C:\B\azure-powershell\src\AppService\test' 'Get-AzWebAppSlotConfigurationName.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzWebAppSlotConfigurationName' {
    It 'ListByWebApp' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
