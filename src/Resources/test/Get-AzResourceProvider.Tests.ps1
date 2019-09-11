$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Get-AzResourceProvider.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzResourceProvider' {
    It 'ListRegistered' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListAvailable' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
