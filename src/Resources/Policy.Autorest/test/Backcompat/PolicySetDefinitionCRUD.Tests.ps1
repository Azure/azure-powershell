# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicySetDefinitionCRUD'

Describe 'Backcompat-PolicySetDefinitionCRUD' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -BackwardCompatible
    }

    It 'make a policy set definition' {
        {
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
            Assert-NotNull $actual.Properties.PolicyDefinitions
            Assert-NotNull $actual.Properties.Metadata
            Assert-Null $actual.Properties.PolicyDefinitionGroups
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'update policy set definition' {
        {
            # update the policy set definition, get it back and validate
            $set = Set-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription -BackwardCompatible
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $set.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $set.Properties.Description $actual.Properties.Description
            Assert-NotNull $actual.Properties.Metadata
            Assert-Null $actual.Properties.PolicyDefinitionGroups
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

            # get it from full listing and validate
            $actual = Get-AzPolicySetDefinition -BackwardCompatible | ?{ $_.Name -eq $policySetDefName }
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
            Assert-NotNull $actual.Properties.PolicyDefinitions
            Assert-AreEqual $set.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $set.Properties.Description $actual.Properties.Description
            Assert-NotNull $actual.Properties.Metadata
            Assert-Null $actual.Properties.PolicyDefinitionGroups
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'list builtin and custom' {
        {
            # ensure that only custom set definitions are returned using the custom flag
            $list = Get-AzPolicySetDefinition -Custom -BackwardCompatible
            Assert-True { $list.Count -gt 0 }
            $builtIns = $list | Where-Object { $_.Properties.policyType -ieq 'BuiltIn' }
            Assert-True { $builtIns.Count -eq 0 }
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
