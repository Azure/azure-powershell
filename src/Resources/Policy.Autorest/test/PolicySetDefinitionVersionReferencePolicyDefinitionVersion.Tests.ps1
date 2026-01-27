# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionVersionReferencePolicyDefinitionVersion'

Describe 'PolicySetDefinitionVersionReferencePolicyDefinitionVersion' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $oldestVersionReference = '1.0.*'
        $newestVersionReference = '2.*.*'

        $baseDefinition = Get-AzPolicyDefinition -Name $builtInDefName
        
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
        $baseSetDefinition = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Parameter "{ 'tagName': { 'type': 'string' } }" -Description $description -Metadata $metadata -Version $someNewVersion
    }

    It 'Make and validate a policy set definition with version reference' {
        # make a policy set definition that references an old definition version
        $expected = New-AzPolicySetDefinitionVersion -Name $policySetDefName -PolicyDefinition $policySet -Parameter "{ 'tagName': { 'type': 'string' } }" -Description $description -Metadata $metadata -Version $someOldVersion
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $someOldVersion
        $expected.Version | Should -Be $actual.Version
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

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
