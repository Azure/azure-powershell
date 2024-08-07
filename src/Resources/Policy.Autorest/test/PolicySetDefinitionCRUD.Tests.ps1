# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionCRUD'

Describe 'PolicySetDefinitionCRUD' {

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
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata
    }

    It 'Make a policy set definition' {
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinition | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinition.policyDefinitionId | Should -Be $policyDefinition.Id
        $expected.PolicyDefinition.policyDefinitionReferenceId | Should -Be $policyDefinitionReferenceId
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -BeNull
        $actual.Metadata.$metadataName | Should -Be $metadataValue
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinition.policyDefinitionId | Should -Be $expected.PolicyDefinition.policyDefinitionId
        $actual.PolicyDefinition.policyDefinitionReferenceId | Should -Be $expected.PolicyDefinition.policyDefinitionReferenceId
    }

    It 'Update policy set definition' {
        # update the policy set definition, get it back and validate
        $update = Update-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $update.DisplayName | Should -Be $actual.DisplayName
        $update.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -BeNull
        $actual.Metadata.$metadataName | Should -Be $metadataValue

        # get it from full listing and validate
        $actual = Get-AzPolicySetDefinition | ?{ $_.Name -eq $policySetDefName }
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $actual.PolicyDefinition | Should -Not -BeNullOrEmpty
        $update.DisplayName | Should -Be $actual.DisplayName
        $update.Description | Should -Be $actual.Description
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -BeNull
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Validate parameter round-trip' {
        # get the set definition, do an update with no changes, validate nothing is changed in response or backend
        $expected = Get-AzPolicySetDefinition -Name $policySetDefName
        $response = Update-AzPolicySetDefinition -Name $policySetDefName
        $response.DisplayName | Should -Be $expected.DisplayName
        $response.Description | Should -Be $expected.Description
        $response.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $response.PolicyRule | Should -BeLike $expected.PolicyRule
        $response.Parameter | Should -BeLike $expected.Parameter
        $response.PolicyDefinitionGroup | Should -BeLike $expected.PolicyDefinitionGroup
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $actual.DisplayName | Should -Be $expected.DisplayName
        $actual.Description | Should -Be $expected.Description
        $actual.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $actual.PolicyRule | Should -BeLike $expected.PolicyRule
        $actual.Parameter | Should -BeLike $expected.Parameter
        $actual.PolicyDefinitionGroup | Should -BeLike $expected.PolicyDefinitionGroup
    }

    It 'List builtin and custom' {
        # ensure that only custom set definitions are returned using the custom flag
        $list = Get-AzPolicySetDefinition -Custom
        $list.Count | Should -BeGreaterThan 0
        $builtIns = $list | Where-Object { $_.policyType -ieq 'BuiltIn' }
        $builtIns | Should -HaveCount 0
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
