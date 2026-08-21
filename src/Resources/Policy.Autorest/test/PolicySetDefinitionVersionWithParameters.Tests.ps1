# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionVersionWithParameters'

Describe 'PolicySetDefinitionVersionWithParameters' {

    BeforeAll {
        $policyDefName = Get-ResourceName
        $policySetDefName = Get-ResourceName

        # make a new policy definition with parameters
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Description $description -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json"

        # make a new policy set definition with parameters using the policy definition
        $parameters = "{ 'listOfAllowedLocations': { 'value': ""[parameters('listOfAllowedLocations')]"" } }"
        $policySet = "[{'policyDefinitionId': '$($policyDefinition.Id)', 'parameters': $parameters}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Parameter $parameterDefinition -Version $someNewVersion
    }

    It 'make a policy set definition version with parameters' {
        $actual = Update-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Parameter $parameterDefinition -Version $someOldVersion
        $expected = Get-AzPolicySetDefinition -Name $policySetDefName -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Name | Should -Be $actual.Name
        $expected.Version | Should -Be $actual.Version
        $actual.metadata.testName | Should -Be $metadataValue
        $expected.Parameter.listOfAllowedLocations.metadata.description | Should -Be $parameterDescription
        $expected.Parameter.listOfAllowedLocations.metadata.displayName | Should -Be $parameterDisplayName
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
