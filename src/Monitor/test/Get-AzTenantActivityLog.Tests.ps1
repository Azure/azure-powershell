$TestRecordingFile = Join-Path $PSScriptRoot 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Monitor\test' 'Get-AzTenantActivityLog.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzTenantActivityLog' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CorrelationId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResourceProvider' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResourceGroupName' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ResourceId' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
