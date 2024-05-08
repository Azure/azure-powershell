# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionMode'

Describe 'Backcompat-PolicyDefinitionMode' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $policyMGName = Get-ResourceName
        $policySubName = Get-ResourceName
        $policyDPName = Get-ResourceName
    }

    It 'make a policy definition with non-default mode at default (sub) scope' {
        {
            # make a policy definition with non-default mode, get it back and validate
            $expected = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode All -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at sub scope without changing mode' {
        {
            # update the same policy definition without touching mode, get it back and validate
            $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at sub scope specifying the same mode' {
        {
            # update the same policy definition explicitly providing the same mode, get it back and validate
            $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at sub scope specifying a different mode' {
        {
            # update the same policy definition explicitly providing a different mode, get it back and validate
            $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'Indexed' $actual.Properties.Mode
            Assert-AreEqual 'Indexed' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    # repeat at management group
    It 'make a policy definition with non-default mode at MG scope' {
        {
            # make a policy definition with non-default mode, get it back and validate
            $expected = New-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode All -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at MG scope without changing mode' {
        {
            # update the same policy definition without touching mode, get it back and validate
            $actual = Set-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at MG scope specifying the same mode' {
        {
            # update the same policy definition explicitly providing the same mode, get it back and validate
            $actual = Set-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at MG scope specifying a different mode' {
        {
            # update the same policy definition explicitly providing a different mode, get it back and validate
            $actual = Set-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'Indexed' $actual.Properties.Mode
            Assert-AreEqual 'Indexed' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    # repeat at subscription id
    It 'make a policy definition with non-default mode at specific sub scope' {
        {
            # make a policy definition with non-default mode, get it back and validate
            $expected = New-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode All -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at specific sub scope without changing mode' {
        {
            # update the same policy definition without touching mode, get it back and validate
            $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at specific sub scope specifying the same mode' {
        {
            # update the same policy definition explicitly providing the same mode, get it back and validate
            $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'All' $actual.Properties.Mode
            Assert-AreEqual 'All' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update the policy definition at specific sub scope specifying a different mode' {
        {
            # update the same policy definition explicitly providing a different mode, get it back and validate
            $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'Indexed' $actual.Properties.Mode
            Assert-AreEqual 'Indexed' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    # test policy with data plane mode
    It 'make a policy definition with dataplane mode at specific sub scope' {
        {
            # make a policy definition with data plane mode, get it back and validate
            $expected = New-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -Policy "$testFilesFolder\SampleKeyVaultDataPolicyDefinition.json" -Mode 'Microsoft.KeyVault.Data' -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual 'Microsoft.KeyVault.Data' $actual.Properties.Mode
            Assert-AreEqual 'Microsoft.KeyVault.Data' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update policy definition at specific sub scope without changing mode' {
        {
            # update the same policy definition without touching mode, get it back and validate
            $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SampleKeyVaultDataPolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'Microsoft.KeyVault.Data' $actual.Properties.Mode
            Assert-AreEqual 'Microsoft.KeyVault.Data' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update policy definition at specific sub scope with the same mode' {
        {
            # update the same policy definition explicitly providing the same mode, get it back and validate
            $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -DisplayName testDisplay -Mode 'Microsoft.KeyVault.Data' -Description $updatedDescription -Policy "$testFilesFolder\SampleKeyVaultDataPolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual 'Microsoft.KeyVault.Data' $actual.Properties.Mode
            Assert-AreEqual 'Microsoft.KeyVault.Data' $expected.Properties.Mode
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyMGName -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policySubName -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyDPName -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
