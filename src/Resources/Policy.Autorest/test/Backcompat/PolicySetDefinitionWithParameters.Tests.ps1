# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicySetDefinitionWithParameters'

Describe 'Backcompat-PolicySetDefinitionWithParameters' {

    BeforeAll {
        $policyDefName = Get-ResourceName
        $policySetDefName = Get-ResourceName

        # make a new policy definition with parameters
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Description $description -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json" -BackwardCompatible

        # make a new policy set definition with parameters using the policy definition
        $parameters = "{ 'listOfAllowedLocations': { 'value': ""[parameters('listOfAllowedLocations')]"" } }"
        $policySet = "[{'policyDefinitionId': '$($policyDefinition.PolicyDefinitionId)', 'parameters': $parameters}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Parameter $parameterDefinition -BackwardCompatible
    }

    It 'make policy set definition with parameters' {
        {
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $metadataValue $actual.Properties.metadata.testName
            Assert-AreEqual $parameterDescription $expected.Properties.Parameters.listOfAllowedLocations.metadata.description
            Assert-AreEqual $parameterDisplayName $expected.Properties.Parameters.listOfAllowedLocations.metadata.displayName
        } | Should -Not -Throw
    }

    It 'update policy set definition parameters' {
        {
            # update the policy set definition to modify its parameter description and display name
            $updatedParameterDisplayName = 'Location Array'
            $updatedParameterDescription = 'Array of allowed resource locations.'
            $updatedParameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$updatedParameterDescription', 'strongType': 'location', 'displayName': '$updatedParameterDisplayName' } } }"
            $set = Set-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $updatedDescription -Metadata $updatedMetadata -Parameter $updatedParameterDefinition -BackwardCompatible
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $metadataValue $actual.Properties.metadata.testName
            Assert-AreEqual $updatedMetadataValue $actual.Properties.metadata.newTestName
            Assert-AreEqual $updatedParameterDescription $set.Properties.Parameters.listOfAllowedLocations.metadata.description
            Assert-AreEqual $updatedParameterDisplayName $set.Properties.Parameters.listOfAllowedLocations.metadata.displayName
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
