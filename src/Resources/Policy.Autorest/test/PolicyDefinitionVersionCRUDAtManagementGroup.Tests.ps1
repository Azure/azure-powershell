# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionVersionCRUDAtManagementGroup'

Describe 'PolicyDefinitionVersionCRUDAtManagementGroup' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
        $baseDefinition = New-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -Version $someNewVersion
    }

    It 'Get policy definition at MG level' {
        $actual = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup
        $actual | Should -Not -BeNullOrEmpty
        $baseDefinition.Name | Should -Be $actual.Name
        $baseDefinition.Version | Should -Be $actual.Version
        $baseDefinition.Id | Should -Be $actual.Id
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $baseDefinition.Mode | Should -Be $actual.Mode
    }

    It 'Make policy definition version at MG level' {
        # make a policy definition version, get it back and validate
        $expected = Update-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description -Version $someOldVersion
        $actual = Get-AzPolicyDefinition -Id $baseDefinition.Id -Version $someOldVersion
        $actual | Should -Not -BeNullOrEmpty
        $expected.Name | Should -Be $actual.Name
        $expected.Version | Should -Be $actual.Version
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.Mode | Should -Be $actual.Mode
    }

    It 'List policy definitions at MG level' {
        # make another policy definition, ensure both are present in listing
        New-AzPolicyDefinition -Name $test2 -ManagementGroupName $managementGroup -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
        $list = Get-AzPolicyDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -in @($policyName, $test2) }
        $list | Should -HaveCount 2
        $list = Get-AzPolicyDefinition -Id $baseDefinition.Id -ListVersion
        $list | Should -HaveCount 2
    }

    It 'Remove policy definition version at MG level' {
        { Remove-AzPolicyDefinition -Id $baseDefinition.Id -Version $someNewVersion -Force -PassThru } | Should -Throw $invalidLatestDefVersionDeletion
        $remove = Remove-AzPolicyDefinition -Id $baseDefinition.Id -Version $someOldVersion -Force -PassThru
        $remove | Should -Be $true
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $test2 -ManagementGroupName $managementGroup -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
