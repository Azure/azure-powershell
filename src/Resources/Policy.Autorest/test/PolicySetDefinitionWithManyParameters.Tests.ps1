# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionWithManyParameters'

Describe 'PolicySetDefinitionWithManyParameters' {

    BeforeAll {
        $policySetDefName = Get-ResourceName
        $metadata = ConvertTo-Json @{ version = "1.0.0"; category = "ScenarioTest" }
    }

    # Note: casing mismatches are intentional to validate case-insensitive behavior of serializers
    It 'make policy set definition with many parameters' {
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition "$testFilesFolder\SamplePolicySetDefinitionWithManyParameters.json" -Parameter "$testFilesFolder\SamplePolicySetDefinitionParameters.json" -Metadata $metadata -DisplayName $someDisplayName -Description $description
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $expected.metadata.version | Should -Be "1.0.0"
        $expected.metadata.category | Should -Be "ScenarioTest"

        # explicitly validate a few parameters
        $expected.Parameter | Should -Not -BeNullOrEmpty
        $expected.Parameter.WafMode | Should -Not -BeNullOrEmpty
        $expected.Parameter.WafMode.type | Should -Be "string"
        $expected.Parameter.WafMode.DefaultValue | Should -Be "Audit"
        $expected.Parameter.WafMode.allowedvalues.Length | Should -Be @("Audit", "Deny", "Disabled").Length
        $expected.Parameter.WafMode.allowedvalues | Sort-Object | foreach { $_ | Should -BeIn @("Audit", "Deny", "Disabled") }
        $expected.Parameter.wafmodeappGwRequirement | Should -Not -BeNullOrEmpty
        $expected.Parameter.wafmodeappGwRequirement.type | Should -Be "string"
        $expected.Parameter.wafmodeappGwRequirement.defaultvalue | Should -Be "prevention"
        $expected.Parameter.vpnAzureAD | Should -Not -BeNullOrEmpty
        $expected.Parameter.vpnAzureAD.type | Should -Be "string"
        $expected.Parameter.vpnAzureAD.DefaultValue | Should -Be "Audit"
        $expected.Parameter.vpnAzureAD.allowedvalues.Length | Should -Be @("Audit", "Deny", "Disabled").Length
        $expected.Parameter.vpnAzureAD.allowedvalues | Sort-Object | foreach { $_ | Should -BeIn @("Audit", "Deny", "Disabled") }

        # explicitly validate parts of the set definition
        $expected.policyDefinition.Length | Should -Be 15
        $expectedDefinitionReferenceId = "Deny-Waf-Afd-Enabled"
        $expectedDefinition = $expected.PolicyDefinition | Where-Object { $_.policydefinitionreferenceid -like $expectedDefinitionReferenceId }
        $expectedDefinition | Should -Not -BeNullOrEmpty
        $expectedDefinition.policydefinitionId | Should -Be '/providers/Microsoft.Authorization/policyDefinitions/055aa869-bc98-4af8-bafc-23f1ab6ffe2c'
        $expectedDefinition.groupNames | Should -BeNullOrEmpty
        $expectedDefinition.Parameters | Should -Not -BeNullOrEmpty
        $expectedDefinition.Parameters.effect | Should -Not -BeNullOrEmpty
        $expectedDefinition.Parameters.effect.value | Should -Be "[parameters('wafAfdEnabled')]"

        # validate the round trip on the parameters
        $actual.metadata.version | Should -Be $expected.metadata.version
        $actual.metadata.category | Should -Be $expected.metadata.category
        $actual.Parameter | Should -Not -BeNullOrEmpty
        $actual.Parameter.WafMode | Should -Not -BeNullOrEmpty
        $actual.Parameter.WafMode.type | Should -Be $expected.parameter.wafMode.type
        $actual.Parameter.WafMode.DefaultValue | Should -Be $expected.parameter.wafMode.defaultValue
        $actual.Parameter.WafMode.allowedvalues.Length | Should -Be $expected.parameter.wafMode.allowedValues.Length
        $actual.Parameter.WafMode.allowedvalues | foreach { $_ | Should -BeIn $expected.parameter.wafMode.allowedValues }
        $actual.Parameter.wafmodeappGwRequirement | Should -Not -BeNullOrEmpty
        $actual.Parameter.wafmodeappGwRequirement.type | Should -Be $expected.Parameter.wafModeAppGwRequirement.type
        $actual.Parameter.wafmodeappGwRequirement.defaultvalue | Should -Be $expected.Parameter.wafModeAppGwRequirement.defaultValue
        $actual.Parameter.vpnAzureAD | Should -Not -BeNullOrEmpty
        $actual.Parameter.vpnAzureAD.type | Should -Be $expected.parameter.vpnazuread.type
        $actual.Parameter.vpnAzureAD.DefaultValue | Should -Be $expected.parameter.vpnazuread.defaultValue
        $actual.Parameter.vpnAzureAD.allowedvalues.Length | Should -Be $expected.parameter.vpnazuread.allowedValues.Length
        $actual.Parameter.vpnAzureAD.allowedvalues | Sort-Object | foreach { $_ | Should -BeIn $expected.parameter.vpnazuread.allowedValues }

        # validate the round trip on the policy definition
        $actual.PolicyDefinition.Length | Should -Be $expected.PolicyDefinition.Length
        $definition = $actual.PolicyDefinition | Where-Object { $_.policydefinitionreferenceid -like $expectedDefinitionReferenceId }
        $definition | Should -Not -BeNullOrEmpty
        $definition.policydefinitionid | Should -Be $expectedDefinition.policydefinitionId
        $definition.groupnames | Should -Be $expectedDefinition.groupNames
        $definition.parameters.effect | Should -Not -BeNullOrEmpty
        $definition.parameters.effect.value | Should -Be $expectedDefinition.Parameters.effect.value
        $expectedReferenceIds = $expected.policyDefinition | Select-Object -ExpandProperty policydefinitionreferenceid
        $actual.PolicyDefinition | foreach { $_.policyDefinitionReferenceId | Should -BeIn $expectedReferenceIds }
    }

    It 'update modifiable part of policy set definition with many parameters' {
        $expected = Get-AzPolicySetDefinition -Name $policySetDefName
        $expectedReferenceId = "Deny-FW-TLS-Inspection"
        $expectedDefinition = $expected.PolicyDefinition | Where-Object { $_.policydefinitionreferenceid -like $expectedReferenceId }

        # update every policy definition reference ID
        foreach ($policyDefinition in $expected.PolicyDefinition) {
            $policyDefinition.policyDefinitionReferenceId = ($policyDefinition.policyDefinitionReferenceId + "-Updated")
        }

        $actual = Update-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition ($expected.PolicyDefinition | ConvertTo-Json -Depth 100)

        # validate the round trip on the parameters
        $actual.metadata.version | Should -Be $expected.metadata.version
        $actual.metadata.category | Should -Be $expected.metadata.category
        $actual.Parameter | Should -Not -BeNullOrEmpty
        $actual.Parameter.WafMode | Should -Not -BeNullOrEmpty
        $actual.Parameter.WafMode.type | Should -Be $expected.parameter.wafMode.type
        $actual.Parameter.WafMode.DefaultValue | Should -Be $expected.parameter.wafMode.defaultValue
        $actual.Parameter.WafMode.allowedvalues.Length | Should -Be $expected.parameter.wafMode.allowedValues.Length
        $actual.Parameter.WafMode.allowedvalues | foreach { $_ | Should -BeIn $expected.parameter.wafMode.allowedValues }
        $actual.Parameter.wafmodeappGwRequirement | Should -Not -BeNullOrEmpty
        $actual.Parameter.wafmodeappGwRequirement.type | Should -Be $expected.Parameter.wafModeAppGwRequirement.type
        $actual.Parameter.wafmodeappGwRequirement.defaultvalue | Should -Be $expected.Parameter.wafModeAppGwRequirement.defaultValue
        $actual.Parameter.vpnAzureAD | Should -Not -BeNullOrEmpty
        $actual.Parameter.vpnAzureAD.type | Should -Be $expected.parameter.vpnazuread.type
        $actual.Parameter.vpnAzureAD.DefaultValue | Should -Be $expected.parameter.vpnazuread.defaultValue
        $actual.Parameter.vpnAzureAD.allowedvalues.Length | Should -Be $expected.parameter.vpnazuread.allowedValues.Length
        $actual.Parameter.vpnAzureAD.allowedvalues | Sort-Object | foreach { $_ | Should -BeIn $expected.parameter.vpnazuread.allowedValues }

        # validate the round trip on the policy definition
        $actual.PolicyDefinition.Length | Should -Be $expected.PolicyDefinition.Length
        $definition = $actual.PolicyDefinition | Where-Object { $_.policydefinitionreferenceid -like "$($expectedReferenceId)-Updated" }
        $definition | Should -Not -BeNullOrEmpty
        $definition.policydefinitionid | Should -Be $expectedDefinition.policydefinitionId
        $definition.groupnames | Should -Be $expectedDefinition.groupNames
        $definition.parameters.effect | Should -Not -BeNullOrEmpty
        $definition.parameters.effect.value | Should -Be $expectedDefinition.Parameters.effect.value
        $expectedReferenceIds = $expected.policyDefinition | Select-Object -ExpandProperty policydefinitionreferenceid
        $actual.PolicyDefinition | foreach { $_.policyDefinitionReferenceId | Should -BeIn $expectedReferenceIds }
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
