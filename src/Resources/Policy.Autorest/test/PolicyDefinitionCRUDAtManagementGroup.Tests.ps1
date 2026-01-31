# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionCRUDAtManagementGroup'

Describe 'PolicyDefinitionCRUDAtManagementGroup' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
    }

    It 'Make policy definition at MG level' {
        # make a policy definition, get it back and validate
        $expected = New-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description
        $actual = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup
        $actual | Should -Not -BeNullOrEmpty
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.Mode | Should -Be $actual.Mode
    }

    It 'Update policy definition at MG level' {
        # update the same policy definition, get it back and validate the new properties
        $actual = Update-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata
        $expected = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'List policy definitions at MG level' {
        # make another policy definition, ensure both are present in listing
        New-AzPolicyDefinition -Name $test2 -ManagementGroupName $managementGroup -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
        $list = Get-AzPolicyDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -in @($policyName, $test2) }
        $list | Should -HaveCount 2
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $test2 -ManagementGroupName $managementGroup -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
