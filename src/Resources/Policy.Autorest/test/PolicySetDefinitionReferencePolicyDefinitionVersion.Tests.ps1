# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionReferencePolicyDefinitionVersion'

Describe 'PolicySetDefinitionReferencePolicyDefinitionVersion' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = '36fd7371-8eb7-4321-9c30-a7100022d048'
        $oldestVersionReference = '1.0.*'
        $newestVersionReference = '2.*.*'

        $baseDefinition = Get-AzPolicyDefinition -Name $policyDefName
    }

    It 'Make and validate a policy set definition with version reference' {
        # make a policy set definition that references an old definition version
        $policySet = 
@"
[
  {
    "policyDefinitionId": "$($baseDefinition.Id)",
    "definitionVersion": "$($oldestVersionReference)",
    "parameters": {
        "tagName_v1": {
            "value": "[parameters('tagName')]"
        }
    }
  }
]
"@
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Parameter "{ 'tagName': { 'type': 'string' } }" -Description $description -Metadata $metadata
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName

        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $defaultVersion
        $expected.Version | Should -Be $actual.Version
        $expected.Versions | Should -HaveCount 1
        $expected.Versions | Should -Be $actual.Versions
        $expected.PolicyDefinition | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinition.policyDefinitionId | Should -Be $baseDefinition.Id
        $expected.PolicyDefinition.DefinitionVersion | Should -Be $oldestVersionReference
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -BeNull
        $actual.Metadata.$metadataName | Should -Be $metadataValue
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.policyDefinitionId | Should -Be $expected.PolicyDefinition.policyDefinitionId
        $actual.PolicyDefinition.definitionVersion | Should -Be $expected.PolicyDefinition.definitionVersion
    }

    It 'Update policy set definition to reference base version' {
        # update policy set definition to reference the base definition version
        $policySet = 
@"
[
  {
    "policyDefinitionId": "$($baseDefinition.Id)",
    "parameters": {
        "tagName": {
            "value": "[parameters('tagName')]"
        }
    }
  }
]
"@
        $update = Update-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet 
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName

        $update.Name | Should -Be $actual.Name
        $update.Id | Should -Be $actual.Id
        $update.Version | Should -Be $defaultVersion
        $update.Version | Should -Be $actual.Version
        $update.Versions | Should -HaveCount 1
        $update.Versions | Should -Be $actual.Versions
        $update.PolicyDefinition | Should -Not -BeNullOrEmpty
        $update.PolicyDefinition.policyDefinitionId | Should -Be $baseDefinition.Id
        $update.PolicyDefinition.DefinitionVersion | Should -Be $newestVersionReference
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -BeNull
        $actual.Metadata.$metadataName | Should -Be $metadataValue
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.policyDefinitionId | Should -Be $update.PolicyDefinition.policyDefinitionId
        $actual.PolicyDefinition.definitionVersion | Should -Be $update.PolicyDefinition.definitionVersion
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
