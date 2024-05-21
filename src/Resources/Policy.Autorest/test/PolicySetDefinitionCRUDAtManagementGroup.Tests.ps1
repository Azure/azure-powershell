# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionCRUDAtManagementGroup'

Describe 'PolicySetDefinitionCRUDAtManagementGroup' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.Id + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -PolicyDefinition $policySet -Description $description
    }

    It 'Make policy set definition at MG level' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
    }

    It 'Update policy set definition at MG level' {
        # update the policy set definition, get it back and validate
        $expected = Update-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.Description | Should -Be $actual.Description
    }

    It 'List policy set definition at MG level' {
        # get it from full listing and validate
        $actual = Get-AzPolicySetDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -eq $policySetDefName }
        $policySetDefName | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.DisplayName | Should -Be 'testDisplay'
        $actual.Description | Should -Be $updatedDescription
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
