$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\KeyVault\test' 'New-AzKeyVault.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzKeyVault' {
    It 'CreateExpandedDefault' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
