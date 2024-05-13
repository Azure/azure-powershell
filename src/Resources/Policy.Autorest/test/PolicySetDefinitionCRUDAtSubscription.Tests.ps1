# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionCRUDAtSubscription'

Describe 'PolicySetDefinitionCRUDAtSubscription' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.Id + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description
    }

    It 'Make policy set definition at subscription level' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
    }

    It 'Update policy set definition at subscription level' {
        # update the policy set definition, get it back and validate
        $expected = Set-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.Description | Should -Be $actual.Description
    }

    It 'List policy set definition at subscription level' {
        # get it from full listing and validate
        $actual = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -eq $policySetDefName }
        $policySetDefName | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.DisplayName | Should -Be 'testDisplay'
        $actual.Description | Should -Be $updatedDescription
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
