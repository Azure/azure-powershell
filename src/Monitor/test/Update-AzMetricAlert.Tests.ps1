$TestRecordingFile = Join-Path 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'Update-AzMetricAlert.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzMetricAlert' {
    It 'UpdateExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByResourceId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByScope' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
