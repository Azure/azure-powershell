# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicySetDefinitionCRUDAtManagementGroup'

Describe 'Backcompat-PolicySetDefinitionCRUDAtManagementGroup' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -PolicyDefinition $policySet -Description $description -BackwardCompatible
    }

    It 'make policy set definition at MG level' {
        {
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
            Assert-NotNull $actual.Properties.PolicyDefinitions
        } | Should -Not -Throw
    }

    It 'update policy set definition at MG level' {
        {
            # update the policy set definition, get it back and validate
            $expected = Set-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription -BackwardCompatible
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
        } | Should -Not -Throw
    }

    It 'list policy set definition at MG level' {
        {
            # get it from full listing and validate
            $actual = Get-AzPolicySetDefinition -ManagementGroupName $managementGroup -BackwardCompatible | ?{ $_.Name -eq $policySetDefName }
            Assert-AreEqual $policySetDefName $actual.Name
            Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
            Assert-NotNull $actual.Properties.PolicyDefinitions
            Assert-AreEqual testDisplay $actual.Properties.DisplayName
            Assert-AreEqual $updatedDescription $actual.Properties.Description
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
