# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicySetDefinitionCRUDWithGroups'

Describe 'Backcompat-PolicySetDefinitionCRUDWithGroups' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """, 'groupNames': [ 'group2' ] }]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -GroupDefinition "[{ 'name': 'group1' }, { 'name': 'group2' }]" -BackwardCompatible
    }

    It 'make a policy definition with groups' {
        {
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
            Assert-NotNull($actual.Properties.PolicyDefinitions)
            Assert-AreEqual "group2" $actual.Properties.PolicyDefinitions.GroupNames
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual 2 @($expected.Properties.PolicyDefinitionGroups).Count
            Assert-AreEqual 2 @($actual.Properties.PolicyDefinitionGroups).Count
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'make a policy definition using a URI to the policy rule' {
        {
            # update the policy set definition, get it back and validate
            $set = Set-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription -GroupDefinition "[{ 'name': 'group2' }]" -BackwardCompatible
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $set.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $set.Properties.Description $actual.Properties.Description
            Assert-NotNull $actual.Properties.Metadata
            Assert-AreEqual "group2" $actual.Properties.PolicyDefinitions.GroupNames
            Assert-AreEqual 1 @($set.Properties.PolicyDefinitionGroups).Count
            Assert-AreEqual 1 @($actual.Properties.PolicyDefinitionGroups).Count
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

            # get it from full listing and validate
            $actual = Get-AzPolicySetDefinition -BackwardCompatible | ?{ $_.Name -eq $policySetDefName }
            Assert-AreEqual $set.Name $actual.Name
            Assert-AreEqual $set.PolicySetDefinitionId $actual.PolicySetDefinitionId
            Assert-NotNull $actual.Properties.PolicyDefinitions
            Assert-AreEqual $set.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $set.Properties.Description $actual.Properties.Description
            Assert-NotNull $actual.Properties.Metadata
            Assert-AreEqual "group2" $actual.Properties.PolicyDefinitions.GroupNames
            Assert-AreEqual 1 @($actual.Properties.PolicyDefinitionGroups).Count
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
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
