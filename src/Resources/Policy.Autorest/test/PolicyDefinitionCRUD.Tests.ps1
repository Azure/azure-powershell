# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyDefinitionCRUD'

Describe 'PolicyDefinitionCRUD' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $policyName = Get-ResourceName
        $test2 = Get-ResourceName
        $test3 = Get-ResourceName
    }

    It 'Make a policy definition from rule file' {
        # make a policy definition, get it back and validate
        $expected = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Mode Indexed -Description $description
        $actual = Get-AzPolicyDefinition -Name $policyName
        $actual | Should -Not -BeNullOrEmpty
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $actual.PolicyRule | Should -Not -BeNullOrEmpty
        $expected.Mode | Should -Be $actual.Mode
    }

    It 'Update policy descriptors and metadata' {
        # update the same policy definition, get it back and validate the new properties
        $actual = Update-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Metadata $metadata
        $expected = Get-AzPolicyDefinition -Name $policyName
        $expected.DisplayName | Should -Be $actual.DisplayName
        $expected.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Validate parameter round-trip' {
        # get the definition, do an update with no changes, validate nothing is changed in response or backend
        $expected = Get-AzPolicyDefinition -Name $policyName
        $response = Update-AzPolicyDefinition -Name $policyName
        $response.DisplayName | Should -Be $expected.DisplayName
        $response.Description | Should -Be $expected.Description
        $response.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $response.PolicyDefinition | Should -BeLike $expected.PolicyDefinition
        $response.Parameter | Should -BeLike $expected.Parameter
        $response.Mode | Should -BeLike $expected.Mode
        $actual = Get-AzPolicyDefinition -Name $policyName
        $actual.DisplayName | Should -Be $expected.DisplayName
        $actual.Description | Should -Be $expected.Description
        $actual.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $actual.PolicyDefinition | Should -BeLike $expected.PolicyDefinition
        $actual.Parameter | Should -BeLike $expected.Parameter
        $actual.Mode | Should -BeLike $expected.Mode
    }

    It 'Make policy definition from command line rule' {
        # make another policy definition, ensure both are present in listing
        New-AzPolicyDefinition -Name $test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
        $list = Get-AzPolicyDefinition | ?{ $_.Name -in @($policyName, $test2) }
        $list | Should -HaveCount 2
    }

    It 'Check policy definition listing filters' {
        # ensure that only builtin definitions are returned using the builtin flag
        $list = Get-AzPolicyDefinition -BuiltIn
        $list.Count | Should -BeGreaterThan 0
        $nonBuiltIn = $list | Where-Object { !($_.policyType -ieq 'BuiltIn') }
        $nonBuiltIn | Should -HaveCount 0

        # ensure that only custom definitions are returned using the custom flag
        $list = Get-AzPolicyDefinition -Custom
        $list.Count | Should -BeGreaterThan 0
        $nonCustom = $list | Where-Object { !($_.policyType -ieq 'Custom') }
        $nonCustom | Should -HaveCount 0

        # ensure that only static definitions are returned using the static flag
        $list = Get-AzPolicyDefinition -Static
        $list.Count | Should -BeGreaterThan 0
        $nonStatics = $list | Where-Object { !($_.policyType -ieq 'Static') }
        $nonStatics | Should -HaveCount 0
    }

    It 'Make a policy definition from an export file' {
        # make a policy definition from export format, get it back and validate
        $expected = New-AzPolicyDefinition -Name $test3 -Policy "$testFilesFolder\SamplePolicyDefinitionFromExport.json" -Description $description
        $actual = Get-AzPolicyDefinition -Name $test3
        $actual | Should -Not -BeNullOrEmpty
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.Mode | Should -Be $actual.Mode
        $expected.Description | Should -Be $actual.Description
        $expected.PolicyRule | Should -BeLike $actual.PolicyRule
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyDefinition -Name $policyName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $test2 -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $test3 -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
