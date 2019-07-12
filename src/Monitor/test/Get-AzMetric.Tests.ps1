$TestRecordingFile = Join-Path $PSScriptRoot 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'Get-AzMetric.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzMetric' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
