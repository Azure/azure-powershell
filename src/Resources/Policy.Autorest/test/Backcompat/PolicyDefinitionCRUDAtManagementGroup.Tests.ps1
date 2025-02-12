# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionCRUDAtManagementGroup'

Describe 'Backcompat-PolicyDefinitionCRUDAtManagementGroup' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
    }

    It 'make policy definition at MG level' {
        {
            # make a policy definition, get it back and validate
            $expected = New-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update policy definition at MG level' {
        {
            # update the same policy definition, get it back and validate the new properties
            $actual = Set-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'list policy definitions at MG level' {
        {
            # make another policy definition, ensure both are present in listing
            New-AzPolicyDefinition -Name $test2 -ManagementGroupName $managementGroup -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description -BackwardCompatible
            $list = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -BackwardCompatible | ?{ $_.Name -in @($policyName, $test2) }
            Assert-AreEqual 2 $list.Count
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $test2 -ManagementGroupName $managementGroup -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
