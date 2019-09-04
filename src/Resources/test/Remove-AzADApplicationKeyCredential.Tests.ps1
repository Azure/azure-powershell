$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'Remove-AzADApplicationKeyCredential.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Remove-AzADApplicationKeyCredential' {
    It '__AllParameterSets' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
