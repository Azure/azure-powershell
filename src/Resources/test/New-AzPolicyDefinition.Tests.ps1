$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Resources\test' 'New-AzPolicyDefinition.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'New-AzPolicyDefinition' {
    It 'CreateExpandedPolicyRuleString' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateExpandedPolicyRuleStringPolicyRuleString1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
