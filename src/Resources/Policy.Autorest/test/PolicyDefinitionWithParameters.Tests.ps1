# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionWithParameters'

Describe 'PolicyDefinitionWithParameters' {

    BeforeAll {
        # make a policy definition with parameters from a file
        $testPDWP = Get-ResourceName
        $actual = New-AzPolicyDefinition -Name $testPDWP -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json" -Description $description
    }

    It 'make a policy definition with parameters from a file' {
        # get it back and validate
        $expected = Get-AzPolicyDefinition -Name $testPDWP
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $actual.Parameter | Should -Not -BeNullOrEmpty
        $expected.Parameter | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations.type | Should -Be 'array'
        $expected.Parameter.listOfAllowedLocations.metadata.strongType | Should -Be 'location'
        $expected.Parameter.effectParam | Should -Not -BeNullOrEmpty
        $expected.Parameter.effectParam.defaultValue | Should -Be 'deny'
        $expected.Parameter.effectParam.type | Should -Be 'string'
    }

    It 'make a policy definition with parameters on the command line' {
        # delete the policy definition
        $remove = Remove-AzPolicyDefinition -Name $testPDWP -Force -PassThru
        $remove | Should -Be $true

        # make a policy definition with parameters from the command line, get it back and validate
        $actual = New-AzPolicyDefinition -Name $testPDWP -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Parameter $fullParameterDefinition -Description $description
        $expected = Get-AzPolicyDefinition -Name $testPDWP
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $actual.Parameter | Should -Not -BeNullOrEmpty
        $expected.Parameter | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations.type | Should -Be 'array'
        $expected.Parameter.listOfAllowedLocations.metadata.strongType | Should -Be 'location'
        $expected.Parameter.effectParam | Should -Not -BeNullOrEmpty
        $expected.Parameter.effectParam.defaultValue | Should -Be 'deny'
        $expected.Parameter.effectParam.type | Should -Be 'string'
    }

    AfterAll {
        # delete the policy definition
        $remove = Remove-AzPolicyDefinition -Name $testPDWP -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
