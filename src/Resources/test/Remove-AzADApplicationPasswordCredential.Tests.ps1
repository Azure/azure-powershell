$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Remove-AzADApplicationPasswordCredential.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADApplicationPasswordCredential' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
