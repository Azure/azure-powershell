$TestRecordingFile = Join-Path $PSScriptRoot 'C:\Users\niassis\source\repos\generating\azure-powershell\src\Storage\test' 'Update-AzStorageAccountt.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Update-AzStorageAccountt' {
    It 'Update1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
