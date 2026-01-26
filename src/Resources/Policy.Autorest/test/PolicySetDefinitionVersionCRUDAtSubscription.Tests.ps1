# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionVersionCRUDAtSubscription'

Describe 'PolicySetDefinitionVersionCRUDAtSubscription' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.Id + """}]"
        $baseDefinition = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description -Version $someNewVersion
    }

    It 'Get policy set definition at subscription level' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
        $actual | Should -Not -BeNullOrEmpty
        $baseDefinition.Name | Should -Be $actual.Name
        $baseDefinition.Version | Should -Be $actual.Version
        $baseDefinition.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
    }

    It 'Make policy set definition version at subscription level' {
        # make a policy set definition version, get it back and validate
        $expected = New-AzPolicySetDefinitionVersion -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description -Version $someOldVersion
        $actual = Get-AzPolicySetDefinition -Id $baseDefinition.Id -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Name | Should -Be $actual.Name
        $expected.Version | Should -Be $actual.Version
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
    }

    It 'List policy set definitions at subscription level' {
        $list = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -in @($policySetDefName) }
        $list | Should -HaveCount 1
        $list = Get-AzPolicySetDefinition -Id $baseDefinition.Id -ListVersion
        $list | Should -HaveCount 2
    }

    It 'Remove policy set definition version at subscription level' {
        { Remove-AzPolicySetDefinition -Id $baseDefinition.Id -Version $someNewVersion -Force -PassThru } | Should -Throw $invalidLatestSetDefVersionDeletion
        $remove = Remove-AzPolicySetDefinition -Id $baseDefinition.Id -Version $someOldVersion -Force -PassThru
        $remove | Should -Be $true
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
