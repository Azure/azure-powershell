# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionVersionCRUD'

Describe 'PolicyDefinitionVersionCRUD' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $baseDefinition = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -Version $someNewVersion
    }

    It 'Make policy definition version from command line rule' {
        $actual = New-AzPolicyDefinitionVersion -Name $policyName -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description -Version $somePreviewVersion
        $expected = Get-AzPolicyDefinition -Name $policyName -Version $somePreviewVersion
        $expected.Name | Should -Be $somePreviewVersion
        $expected.Description | Should -Be $actual.Description
        $actual.Version | Should -Be $somePreviewVersion
        $expected.Version | Should -Be $actual.Version
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
    }

    It 'Make policy definition version from rule file' {
        $actual = New-AzPolicyDefinitionVersion -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -Version $someOldVersion
        $expected = Get-AzPolicyDefinition -Name $policyName -Version $someOldVersion
        $expected.Name | Should -Be $someOldVersion
        $expected.Description | Should -Be $actual.Description
        $actual.Version | Should -Be $someOldVersion
        $expected.Version | Should -Be $actual.Version
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
    }

    It 'Check policy definition version listing filters' {
        $list = Get-AzPolicyDefinition | ?{ $_.Name -in @($policyName) }
        $list | Should -HaveCount 1

        $list = Get-AzPolicyDefinition -Id $baseDefinition.Id -ListVersion
        $list | Should -HaveCount 3
        
        $actual = Get-AzPolicyDefinition -Id $baseDefinition.Id
        $actual.Version | Should -Be $someNewVersion
        $actual.Versions | Should -HaveCount 3
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
