# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicySetDefinitionCRUD'

Describe 'PolicySetDefinitionCRUD' {

    BeforeAll {
        # setup
        $policySetDefName = Get-ResourceName
        $policySetDefName2 = Get-ResourceName
        $policyDefName = Get-ResourceName
        $policyDefinitionReferenceId = "Definition-Reference-1"
        $oldestVersion = "1.0.0"
        $newestVersion = "2.0.0"

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
        $expected.Version | Should -Be $oldestVersion
        $expected.Version | Should -Be $actual.Version
        $expected.Versions | Should -HaveCount 1
        $expected.Versions | Should -Be $actual.Versions
        $expected.PolicyDefinition | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinition.policyDefinitionId | Should -Be $policyDefinition.Id
        $expected.PolicyDefinition.policyDefinitionReferenceId | Should -Be $policyDefinitionReferenceId
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
        $update.Version | Should -Be $oldestVersion
        $update.Version | Should -Be $actual.Version
        $update.Versions | Should -HaveCount 1
        $update.Versions | Should -Be $actual.Versions
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
        $update.Version | Should -Be $oldestVersion
        $update.Version | Should -Be $actual.Version
        $update.Versions | Should -HaveCount 1
        $update.Versions | Should -Be $actual.Versions
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.PolicyDefinitionGroup | Should -BeNull
        $actual.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Update policy set definition version' {
        # update the policy set definition version, get it back and validate
        $update = Update-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription -Version $newestVersion
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName
        $update.DisplayName | Should -Be $actual.DisplayName
        $update.Description | Should -Be $actual.Description
        $update.Version | Should -Be $newestVersion
        $update.Version | Should -Be $actual.Version
        $update.Versions | Should -HaveCount 2
        $update.Versions | Should -Be $actual.Versions
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
        $update.Version | Should -Be $newestVersion
        $update.Version | Should -Be $actual.Version
        $update.Versions | Should -HaveCount 2
        $update.Versions | Should -Be $actual.Versions
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

    It 'Make a policy set definition with version from rule file' {
        # make a policy set definition with version, get it back and validate
        $expected = New-AzPolicySetDefinition -Name $policySetDefName2 -PolicyDefinition $policySet -Description $description -Metadata $metadata -Version $newestVersion
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName2
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.Version | Should -Be $newestVersion
        $expected.Version | Should -Be $actual.Version
        $expected.Versions | Should -HaveCount 1
        $expected.Versions | Should -Be $actual.Versions
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
        $remove = Remove-AzPolicySetDefinition -Name $policySetDefName2 -Force -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
