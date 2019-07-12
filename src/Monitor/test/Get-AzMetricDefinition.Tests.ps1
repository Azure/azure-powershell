$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'Get-AzMetricDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzMetricDefinition' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
