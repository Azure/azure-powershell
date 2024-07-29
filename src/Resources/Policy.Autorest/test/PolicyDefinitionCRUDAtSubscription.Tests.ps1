# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionCRUDAtSubscription'

Describe 'PolicyDefinitionCRUDAtSubscription' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
    }

    It 'Make policy definition at subscription level' {
        # make a policy definition, get it back and validate
        $expected = New-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description
        $actual = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId
        $actual | Should -Not -BeNull
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Mode | Should -Be $actual.Mode
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
    }

    It 'Update policy definition at subscription level' {
        # update the same policy definition, get it back and validate the new properties
        $actual = Update-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata
        $expected = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.Description | Should -Be $actual.Description
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'List policy definitions at subscription level' {
        # make another policy definition, ensure both are present in listing
        New-AzPolicyDefinition -Name $test2 -SubscriptionId $subscriptionId -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
        $list = Get-AzPolicyDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -in @($policyName, $test2) }
        $list | Should -HaveCount 2
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $test2 -SubscriptionId $subscriptionId -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
