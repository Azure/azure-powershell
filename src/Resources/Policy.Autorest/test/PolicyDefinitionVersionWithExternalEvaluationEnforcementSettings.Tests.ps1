# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionVersionWithExternalEvaluationEnforcementSettings'

Describe 'PolicyDefinitionVersionWithExternalEvaluationEnforcementSettings' {

    BeforeAll {
        $policyName = Get-ResourceName
        $policyRule = "$testFilesFolder\SamplePolicyDefinitionWithClaims.json"
        $endpointKind = 'CoinFlip'
        $roleDefinitionIds = @( "/providers/Microsoft.Authorization/roleDefinitions/b24988ac-6180-42a0-ab88-20f7382dd24c" )
    }

    It 'Make a policy definition with external evaluation enforcement settings' {
        $actual = New-AzPolicyDefinition `
            -Name $policyName `
            -Policy $policyRule `
            -EndpointSettingKind $endpointKind `
            -ExternalEvaluationEnforcementSettingRoleDefinitionId $roleDefinitionIds `
            -Version $someNewVersion

        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $someNewVersion
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.EndpointSettingKind | Should -Be $actual.EndpointSettingKind
        ($expected.EndpointSettingDetail.AdditionalProperties.Count) | Should -Be 0
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $actual.ExternalEvaluationEnforcementSettingRoleDefinitionId
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -BeNullOrEmpty
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -BeNullOrEmpty
    }

    It 'Make a policy definition version with external evaluation enforcement settings' {
        $actual = New-AzPolicyDefinitionVersion `
            -Name $policyName `
            -Policy $policyRule `
            -EndpointSettingKind $endpointKind `
            -ExternalEvaluationEnforcementSettingRoleDefinitionId $roleDefinitionIds `
            -Version $someOldVersion

        $expected = Get-AzPolicyDefinition -Name $policyName -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $actual.Version
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.EndpointSettingKind | Should -Be $actual.EndpointSettingKind
        ($expected.EndpointSettingDetail.AdditionalProperties.Count) | Should -Be 0
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $actual.ExternalEvaluationEnforcementSettingRoleDefinitionId
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -BeNullOrEmpty
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -BeNullOrEmpty
    }

    AfterAll {
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}