# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionWithFullObject'

Describe 'Backcompat-PolicyDefinitionWithFullObject' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $policyNameOverride = Get-ResourceName
        $policyNameUpdate = Get-ResourceName
    }

    It 'make a policy definition using full object from a file' {
        {
            # make a policy definition using the full policy object (from a file), get it back and validate
            $actual = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull $actual.Properties.PolicyRule
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
        } | Should -Not -Throw
    }

    It 'parameters override properties on the full object' {
        {
            # verify that description, displayname, mode, metadata, and parameters correctly overload what's in the object
            $actual = New-AzPolicyDefinition -Name $policyNameOverride -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -DisplayName testDisplay -Description $description -Mode Indexed -Metadata $metadata -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json" -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyNameOverride -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.DisplayName testDisplay
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-AreEqual $expected.Properties.Description $description
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
            Assert-AreEqual $expected.Properties.Mode Indexed
            Assert-NotNull $actual.Properties.Metadata
            Assert-NotNull $expected.Properties.Metadata
            Assert-AreEqual $expected.Properties.Metadata.$metadataName $actual.Properties.Metadata.$metadataName
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-NotNull $actual.Properties.Parameters
            Assert-NotNull $expected.Properties.Parameters
            Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations
            Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
            Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
            Assert-NotNull $expected.Properties.Parameters.effectParam
            Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
            Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type
        } | Should -Not -Throw
    }

    It 'update policy definition using full object from a file' {
        {
            # now create a basic policy, update with Set-AzPolicyDefinition using full object, and validate
            New-AzPolicyDefinition -Name $policyNameUpdate -Policy "$testFilesFolder\SamplePolicyDefinition.json" -BackwardCompatible
            $actual = Set-AzPolicyDefinition -Name $policyNameUpdate -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyNameUpdate -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.DisplayName 'Fake Test policy'
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-AreEqual $expected.Properties.Description 'Sample fake test policy for unit tests.'
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
            Assert-AreEqual $expected.Properties.Mode Indexed
            Assert-NotNull $actual.Properties.Metadata
            Assert-NotNull $expected.Properties.Metadata
            Assert-AreEqual $expected.Properties.Metadata.category $actual.Properties.Metadata.category
            Assert-AreEqual $expected.Properties.Metadata.category 'Unit Test'
            Assert-NotNull $actual.Properties.Parameters
            Assert-NotNull $expected.Properties.Parameters
            Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations
            Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
            Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
            Assert-NotNull $expected.Properties.Parameters.effectParam
            Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
            Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type
        } | Should -Not -Throw
    }

    AfterAll {
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $policyNameOverride -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyNameUpdate -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
