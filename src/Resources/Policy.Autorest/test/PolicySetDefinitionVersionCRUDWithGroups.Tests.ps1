# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionVersionCRUDWithGroups'

Describe 'PolicySetDefinitionVersionCRUDWithGroups' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.Id + """, 'groupNames': [ 'group2' ] }]"
        $baseDefinition = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -GroupDefinition "[{ 'name': 'group1' }, { 'name': 'group2' }]" -Version $someNewVersion
    }

    It 'Make a policy set definition version with groups' {
        # update the policy set definition, get it back and validate
        $expected = New-AzPolicySetDefinitionVersion -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -GroupDefinition "[{ 'name': 'group2' }]" -Version $someOldVersion
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $actual.Version
        $expected.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
        $expected.PolicyDefinitionGroup | Should -HaveCount 1
        $actual.PolicyDefinitionGroup | Should -HaveCount 1
        $actual.Metadata.$metadataName | Should -Be $metadataValue

        # get it from full listing that picks up newer version and validate
        $actual = Get-AzPolicySetDefinition | ?{ $_.Name -eq $policySetDefName }
        $baseDefinition.Name | Should -Be $actual.Name
        $baseDefinition.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $baseDefinition.DisplayName | Should -Be $actual.DisplayName
        $baseDefinition.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
        $actual.PolicyDefinitionGroup | Should -HaveCount 2
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Get policy set definition with groups' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $actual.Name | Should -Be $baseDefinition.Name
        $actual.Id | Should -Be $baseDefinition.Id
        $actual.Version | Should -Be $baseDefinition.Version
        $actual.Versions | Should -HaveCount 2
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -HaveCount 2
        $actual.Metadata.$metadataName | Should -Be $metadataValue

        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -Version $someOldVersion
        $actual.Name | Should -Be $someOldVersion
        $actual.Version | Should -Be $someOldVersion
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -HaveCount 1
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}