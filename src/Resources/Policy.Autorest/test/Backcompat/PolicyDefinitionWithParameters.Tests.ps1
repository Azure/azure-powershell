# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionWithParameters'

Describe 'Backcompat-PolicyDefinitionWithParameters' {

    BeforeAll {
        $testPDWP = Get-ResourceName
        # make a policy definition with parameters from a file
        $actual = New-AzPolicyDefinition -Name $testPDWP -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json" -Description $description -BackwardCompatible
    }

    It 'make a policy definition with parameters from a file' {
        {
            # get it back and validate
            $expected = Get-AzPolicyDefinition -Name $testPDWP -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-NotNull($actual.Properties.Parameters)
            Assert-NotNull($expected.Properties.Parameters)
            Assert-NotNull($expected.Properties.Parameters.listOfAllowedLocations)
            Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
            Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
            Assert-NotNull($expected.Properties.Parameters.effectParam)
            Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
            Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type
        } | Should -Not -Throw
    }

    It 'make a policy definition with parameters on the command line' {
        {
            # delete the policy definition
            $remove = Remove-AzPolicyDefinition -Name $testPDWP -Force -BackwardCompatible
            Assert-AreEqual True $remove

            # make a policy definition with parameters from the command line, get it back and validate
            $actual = New-AzPolicyDefinition -Name $testPDWP -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Parameter $fullParameterDefinition -Description $description -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $testPDWP -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-NotNull($actual.Properties.Parameters)
            Assert-NotNull($expected.Properties.Parameters)
            Assert-NotNull($expected.Properties.Parameters.listOfAllowedLocations)
            Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
            Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
            Assert-NotNull($expected.Properties.Parameters.effectParam)
            Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
            Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type
        } | Should -Not -Throw
    }

    AfterAll {
        # delete the policy definition
        $remove = Remove-AzPolicyDefinition -Name $testPDWP -Force -BackwardCompatible
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
