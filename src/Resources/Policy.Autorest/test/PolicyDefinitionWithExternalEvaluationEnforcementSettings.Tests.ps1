# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionWithExternalEvaluationEnforcementSettings'

Describe 'PolicyDefinitionWithExternalEvaluationEnforcementSettings' {

    BeforeAll {
        $policyName = Get-ResourceName
        $policyRule = "$testFilesFolder\SamplePolicyDefinitionWithClaims.json"
        $endpointKind = 'CoinFlip'
        $endpointDetails = @"
{
    "successProbability": 0.99,
    "requireChangeReference": true
}
"@
        $missingTokenAction = 'Audit'
        $resultLifespan = 'PT30M'
        $roleDefinitionIds = @( "/providers/Microsoft.Authorization/roleDefinitions/b24988ac-6180-42a0-ab88-20f7382dd24c" )
    }

    It 'Make a policy definition with external evaluation enforcement settings' {
        $actual = New-AzPolicyDefinition `
            -Name $policyName `
            -Policy $policyRule `
            -EndpointSettingKind $endpointKind `
            -ExternalEvaluationEnforcementSettingRoleDefinitionId $roleDefinitionIds `

        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.EndpointSettingKind | Should -Be $actual.EndpointSettingKind
        ($expected.EndpointSettingDetail.AdditionalProperties.Count) | Should -Be 0
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $actual.ExternalEvaluationEnforcementSettingRoleDefinitionId
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -BeNullOrEmpty
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -BeNullOrEmpty
    }

    It 'Update policy definition with external evaluation enforcement settings' {
        $actual = Update-AzPolicyDefinition `
            -Name $policyName `
            -Policy $policyRule `
            -EndpointSettingDetail $endpointDetails
        
        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.EndpointSettingKind | Should -Be $endpointKind
        $expected.EndpointSettingKind | Should -Be $actual.EndpointSettingKind
        ($expected.EndpointSettingDetail | ConvertTo-Json -Depth 20) | Should -Be ($actual.EndpointSettingDetail | ConvertTo-Json -Depth 20)
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $actual.ExternalEvaluationEnforcementSettingRoleDefinitionId
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -Be $actual.ExternalEvaluationEnforcementSettingResultLifespan
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -Be $actual.ExternalEvaluationEnforcementSettingMissingTokenAction

        $actual = Update-AzPolicyDefinition `
            -Name $policyName `
            -ExternalEvaluationEnforcementSettingRoleDefinitionId $roleDefinitionIds `
            -ExternalEvaluationEnforcementSettingResultLifespan $resultLifespan `
            -ExternalEvaluationEnforcementSettingMissingTokenAction $missingTokenAction
        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.EndpointSettingKind | Should -Be $endpointKind
        $expected.EndpointSettingKind | Should -Be $actual.EndpointSettingKind
        $expected.EndpointSettingDetail.successProbability | Should -Be 0.99
        $expected.EndpointSettingDetail.requireChangeReference | Should -Be true
        ($expected.EndpointSettingDetail | ConvertTo-Json -Depth 20) | Should -Be ($actual.EndpointSettingDetail | ConvertTo-Json -Depth 20)
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $roleDefinitionIds
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $actual.ExternalEvaluationEnforcementSettingRoleDefinitionId
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -Be $resultLifespan
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -Be $actual.ExternalEvaluationEnforcementSettingResultLifespan
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -Be $missingTokenAction
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -Be $actual.ExternalEvaluationEnforcementSettingMissingTokenAction

        # no-op update should not change the external evaluation enforcement settings
        $actual = Update-AzPolicyDefinition -Name $policyName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
        $expected.EndpointSettingKind | Should -Be $endpointKind
        $expected.EndpointSettingKind | Should -Be $actual.EndpointSettingKind
        ($expected.EndpointSettingDetail | ConvertTo-Json -Depth 20) | Should -Be ($actual.EndpointSettingDetail | ConvertTo-Json -Depth 20)
        $expected.ExternalEvaluationEnforcementSettingRoleDefinitionId | Should -Be $actual.ExternalEvaluationEnforcementSettingRoleDefinitionId
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -Be $resultLifespan
        $expected.ExternalEvaluationEnforcementSettingResultLifespan | Should -Be $actual.ExternalEvaluationEnforcementSettingResultLifespan
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -Be $missingTokenAction
        $expected.ExternalEvaluationEnforcementSettingMissingTokenAction | Should -Be $actual.ExternalEvaluationEnforcementSettingMissingTokenAction
    }

    AfterAll {
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}