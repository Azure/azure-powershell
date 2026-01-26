# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionVersionCRUDAtSubscription'

Describe 'PolicyDefinitionVersionCRUDAtSubscription' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
        $baseDefinition = New-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -Version $someNewVersion
    }

    It 'Get policy definition at subscription level' {
        $actual = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId
        $actual | Should -Not -BeNull
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $baseDefinition.Name | Should -Be $actual.Name
        $baseDefinition.Id | Should -Be $actual.Id
        $baseDefinition.Version | Should -Be $actual.Version
        $baseDefinition.Versions | Should -Be $actual.Versions
        $baseDefinition.Versions | Should -HaveCount 1
        $baseDefinition.Mode | Should -Be $actual.Mode
        $baseDefinition.PolicyRule | Should -BeLike $actual.PolicyRule
    }

    It 'Make policy definition version at subscription level' {
        # make a policy definition version, get it back and validate
        $expected = New-AzPolicyDefinitionVersion -Name $policyName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -Version $someOldVersion
        $actual = Get-AzPolicyDefinition -Id $baseDefinition.Id -Version $someOldVersion
        $actual | Should -Not -BeNull
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $actual.Version
        $expected.Mode | Should -Be $actual.Mode
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
    }

    It 'List policy definitions at subscription level' {
        # make another policy definition, ensure both are present in listing
        New-AzPolicyDefinition -Name $test2 -SubscriptionId $subscriptionId -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
        $list = Get-AzPolicyDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -in @($policyName, $test2) }
        $list | Should -HaveCount 2
        $list = Get-AzPolicyDefinition -Id $baseDefinition.Id -ListVersion
        $list | Should -HaveCount 2
    }

    It 'Remove policy definition version at MG level' {
        { Remove-AzPolicyDefinition -Name $policyName -Version $someNewVersion -Force -PassThru } | Should -Throw $invalidLatestDefVersionDeletion
        $remove = Remove-AzPolicyDefinition -Name $policyName -Version $someOldVersion -Force -PassThru
        $remove | Should -Be $true
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $test2 -SubscriptionId $subscriptionId -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
