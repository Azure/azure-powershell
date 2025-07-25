# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionCRUDWithGroups'

Describe 'PolicySetDefinitionCRUDWithGroups' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.Id + """, 'groupNames': [ 'group2' ] }]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -GroupDefinition "[{ 'name': 'group1' }, { 'name': 'group2' }]"
    }

    It 'Make a policy definition with groups' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinitionGroup | Should -HaveCount 2
        $actual.PolicyDefinitionGroup | Should -HaveCount 2
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Make a policy definition using a URI to the policy rule' {
        # update the policy set definition, get it back and validate
        $update = Update-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription -GroupDefinition "[{ 'name': 'group2' }]"
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $update.DisplayName | Should -Be $actual.DisplayName
        $update.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
        $update.PolicyDefinitionGroup | Should -HaveCount 1
        $actual.PolicyDefinitionGroup | Should -HaveCount 1
        $actual.Metadata.$metadataName | Should -Be $metadataValue

        # get it from full listing and validate
        $actual = Get-AzPolicySetDefinition | ?{ $_.Name -eq $policySetDefName }
        $update.Name | Should -Be $actual.Name
        $update.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $update.DisplayName | Should -Be $actual.DisplayName
        $update.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.GroupNames | Should -Be 'group2'
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
