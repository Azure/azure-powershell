$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\AppService\test' 'Restore-AzWebApp.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Restore-AzWebApp' {
    It 'RestoreBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RecoverBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
