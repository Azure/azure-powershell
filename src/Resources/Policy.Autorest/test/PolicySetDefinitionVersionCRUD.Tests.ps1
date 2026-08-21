# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionVersionCRUD'

Describe 'PolicySetDefinitionVersionCRUD' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName
        $policyDefinitionReferenceId = "Definition-Reference-1"

        # make a policy definition and policy set definition that references it, get the policy set definition back and validate
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySet = 
@"
[
  {
    "policyDefinitionId": "$($policyDefinition.Id)",
    "policydefinitionreferenceid": "$($policyDefinitionReferenceId)"
  }
]
"@
        $baseDefinition = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Version $someNewVersion
    }

    It 'Make policy set definition version' {
        $expected = Update-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Version $someOldVersion
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Description | Should -Be $actual.Description
        $actual.Version | Should -Be $someOldVersion
        $expected.Version | Should -Be $actual.Version
    }

    It 'Check policy set definition version listing filters' {
        $list = Get-AzPolicySetDefinition | ?{ $_.Name -in @($policySetDefName) }
        $list | Should -HaveCount 1

        $list = Get-AzPolicySetDefinition -Id $baseDefinition.Id -ListVersion
        $list | Should -HaveCount 2
        
        $actual = Get-AzPolicySetDefinition -Id $baseDefinition.Id
        $actual.Version | Should -Be $someNewVersion
        $actual.Versions | Should -HaveCount 2
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}