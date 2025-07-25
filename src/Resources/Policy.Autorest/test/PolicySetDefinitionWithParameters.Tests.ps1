# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionWithParameters'

Describe 'PolicySetDefinitionWithParameters' {

    BeforeAll {
        $policyDefName = Get-ResourceName
        $policySetDefName = Get-ResourceName

        # make a new policy definition with parameters
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Description $description -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json"

        # make a new policy set definition with parameters using the policy definition
        $parameters = "{ 'listOfAllowedLocations': { 'value': ""[parameters('listOfAllowedLocations')]"" } }"
        $policySet = "[{'policyDefinitionId': '$($policyDefinition.Id)', 'parameters': $parameters}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Parameter $parameterDefinition
    }

    It 'make policy set definition with parameters' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $actual.metadata.testName | Should -Be $metadataValue
        $expected.Parameter.listOfAllowedLocations.metadata.description | Should -Be $parameterDescription
        $expected.Parameter.listOfAllowedLocations.metadata.displayName | Should -Be $parameterDisplayName
    }

    It 'update policy set definition parameters' {
        # update the policy set definition to modify its parameter description and display name
        $updatedParameterDisplayName = 'Location Array'
        $updatedParameterDescription = 'Array of allowed resource locations.'
        $updatedParameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$updatedParameterDescription', 'strongType': 'location', 'displayName': '$updatedParameterDisplayName' } } }"
        $update = Update-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $updatedDescription -Metadata $updatedMetadata -Parameter $updatedParameterDefinition
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $actual.metadata.testName | Should -Be $metadataValue
        $actual.metadata.newTestName | Should -Be $updatedMetadataValue
        $update.Parameter.listOfAllowedLocations.metadata.description | Should -Be $updatedParameterDescription
        $update.Parameter.listOfAllowedLocations.metadata.displayName | Should -Be $updatedParameterDisplayName
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
