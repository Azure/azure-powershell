$TestRecordingFile = Join-Path $PSScriptRoot 'ConvertTo-AzVmssSinglePlacementGroup.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'ConvertTo-AzVmssSinglePlacementGroup' {
    It 'ConvertExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ConvertViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
