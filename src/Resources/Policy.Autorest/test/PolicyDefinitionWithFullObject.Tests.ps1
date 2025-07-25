# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionWithFullObject'

Describe 'PolicyDefinitionWithFullObject' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $policyNameOverride = Get-ResourceName
        $policyNameUpdate = Get-ResourceName
    }

    It 'Make a policy definition using full object from a file' {
        # make a policy definition using the full policy object (from a file), get it back and validate
        $actual = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json"
        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.Mode | Should -Be $actual.Mode
    }

    It 'Parameters override properties on the full object' {
        # verify that description, displayname, mode, metadata, and parameters correctly overload what's in the object
        $actual = New-AzPolicyDefinition -Name $policyNameOverride -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -DisplayName testDisplay -Description $description -Mode Indexed -Metadata $metadata -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json"
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName | Should -Be $metadataValue
        $actual.Parameter | Should -Not -BeNullOrEmpty
        $expected = Get-AzPolicyDefinition -Name $policyNameOverride
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.DisplayName | Should -Be testDisplay
        $expected.Description | Should -Be $actual.Description
        $expected.Description | Should -Be $description
        $expected.Mode | Should -Be $actual.Mode
        $expected.Mode | Should -Be 'Indexed'
        $expected.Metadata | Should -Not -BeNullOrEmpty
        $expected.Metadata.$metadataName | Should -Be $actual.Metadata.$metadataName
        $expected.Parameter | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations.type | Should -Be 'array'
        $expected.Parameter.listOfAllowedLocations.metadata.strongType | Should -Be 'location'
        $expected.Parameter.effectParam | Should -Not -BeNullOrEmpty
        $expected.Parameter.effectParam.defaultValue | Should -Be 'deny'
        $expected.Parameter.effectParam.type | Should -Be 'string'
    }

    It 'Update policy definition using full object from a file' {
        # now create a basic policy, update with Update-AzPolicyDefinition using full object, and validate
        New-AzPolicyDefinition -Name $policyNameUpdate -Policy "$testFilesFolder\SamplePolicyDefinition.json"
        $actual = Update-AzPolicyDefinition -Name $policyNameUpdate -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json"
        $expected = Get-AzPolicyDefinition -Name $policyNameUpdate
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.DisplayName | Should -Be 'Fake Test policy'
        $expected.Description | Should -Be $actual.Description
        $expected.Description | Should -Be 'Sample fake test policy for unit tests.'
        $expected.Mode | Should -Be $actual.Mode
        $expected.Mode | Should -Be 'Indexed'
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $expected.Metadata | Should -Not -BeNullOrEmpty
        $expected.Metadata.category | Should -Be $actual.Metadata.category
        $expected.Metadata.category | Should -Be 'Unit Test'
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
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyNameOverride -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyNameUpdate -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
