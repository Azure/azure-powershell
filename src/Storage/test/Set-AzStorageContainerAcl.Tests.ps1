$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Storage\test' 'Set-AzStorageContainerAcl.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Set-AzStorageContainerAcl' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
