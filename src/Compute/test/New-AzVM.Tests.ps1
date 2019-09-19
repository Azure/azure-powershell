$TestRecordingFile = Join-Path 'C:\zd\azure-powershell\src\Compute\test' 'New-AzVM.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzVM' {
    It 'SimpleParameterSet' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
