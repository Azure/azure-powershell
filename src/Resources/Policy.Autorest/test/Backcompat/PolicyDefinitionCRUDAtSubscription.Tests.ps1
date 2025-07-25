# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyDefinitionCRUDAtSubscription'

Describe 'Backcompat-PolicyDefinitionCRUDAtSubscription' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
    }

    It 'make policy definition at subscription level' {
        {
            # make a policy definition, get it back and validate
            $expected = New-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -BackwardCompatible
            $actual = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -BackwardCompatible
            Assert-NotNull $actual
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
            Assert-NotNull($actual.Properties.PolicyRule)
            Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
        } | Should -Not -Throw
    }

    It 'update policy definition at subscription level' {
        {
            # update the same policy definition, get it back and validate the new properties
            $actual = Set-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -BackwardCompatible
            Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
            Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
            Assert-NotNull($actual.Properties.Metadata)
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'list policy definitions at subscription level' {
        {
            # make another policy definition, ensure both are present in listing
            New-AzPolicyDefinition -Name $test2 -SubscriptionId $subscriptionId -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description -BackwardCompatible
            $list = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BackwardCompatible | ?{ $_.Name -in @($policyName, $test2) }
            Assert-AreEqual 2 $list.Count
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Force -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $test2 -SubscriptionId $subscriptionId -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
