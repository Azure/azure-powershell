# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyExemptionCRUD'

Describe 'PolicyExemptionCRUD' {

    BeforeAll {
        # Get built-in Audit resource location matches resource group location
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"
        $testPA = Get-ResourceName
        $testExemption = Get-ResourceName
        $testExemption2 = Get-ResourceName

        # make a new resource group, policy assignment
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $rgScope -DisplayName $description
        $future1 = [DateTime]::Parse('3021-03-09T07:30:10Z').ToUniversalTime()
        $future2 = $future1.AddDays(1)
    }

    It 'Make policy exemption' {
        # create the policy exemption to the resource group
        $exemption = New-AzPolicyExemption -Name $testExemption -PolicyAssignment $assignment -Scope $rgScope -ExemptionCategory Waiver -Description $description -DisplayName $description -Metadata $metadata
        $exemption.Name | Should -Be $testExemption
        $exemption.Type | Should -Be 'Microsoft.Authorization/policyExemptions'
        $exemption.Id | Should -Be "$($rgScope)/providers/Microsoft.Authorization/policyExemptions/$testExemption"
        $exemption.PolicyAssignmentId | Should -Be $assignment.Id
        $exemption.ExemptionCategory | Should -Be 'Waiver'
        $exemption.Description | Should -Be $description
        $exemption.DisplayName | Should -Be $description
        $exemption.Metadata | Should -Not -BeNullOrEmpty
        $exemption.Metadata.$metadataName | Should -Be $metadataValue
        $exemption.ExpiresOn | Should -BeNull
    }

    It 'Get policy exemption by name' {
        # get the exemption by name
        $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope
        $exemption.Name | Should -Be $testExemption
        $exemption.Type | Should -Be 'Microsoft.Authorization/policyExemptions'
        $exemption.Id | Should -Be "$($rgScope)/providers/Microsoft.Authorization/policyExemptions/$testExemption"
        $exemption.PolicyAssignmentId | Should -Be $assignment.Id
        $exemption.ExemptionCategory | Should -Be 'Waiver'
        $exemption.Description | Should -Be $description
        $exemption.DisplayName | Should -Be $description
        $exemption.Metadata | Should -Not -BeNullOrEmpty
        $exemption.Metadata.$metadataName | Should -Be $metadataValue
        $exemption.ExpiresOn | Should -BeNull
    }

    It 'Get policy exemption by Id' {
        # get the exemption by name first (to get the Id)
        $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope

        # get the exemption by id
        $exemption = Get-AzPolicyExemption -Id $exemption.Id
        $exemption.Name | Should -Be $testExemption
        $exemption.Type | Should -Be 'Microsoft.Authorization/policyExemptions'
        $exemption.Id | Should -Be "$($rgScope)/providers/Microsoft.Authorization/policyExemptions/$testExemption"
        $exemption.PolicyAssignmentId | Should -Be $assignment.Id
        $exemption.ExemptionCategory | Should -Be 'Waiver'
        $exemption.Description | Should -Be $description
        $exemption.DisplayName | Should -Be $description
        $exemption.Metadata | Should -Not -BeNullOrEmpty
        $exemption.Metadata.$metadataName | Should -Be $metadataValue
        $exemption.ExpiresOn | Should -BeNull
    }

    It 'Update policy exemption' {
        # get the exemption by name first (to get the Id)
        $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope

        # update the policy exemption, validate the result
        $exemption = Update-AzPolicyExemption -Id $exemption.Id -DisplayName testDisplay -ExemptionCategory Mitigated -ExpiresOn $future1 -Metadata '{}'
        $exemption.DisplayName | Should -Be 'testDisplay'
        $exemption.ExemptionCategory | Should -Be 'Mitigated'
        $exemption.ExpiresOn.ToUniversalTime() | Should -Be $future1
        $exemption.Metadata.$metadataName | Should -BeNull
    }

    It 'Validate parameter round-trip' {
        # get the definition, do an update with no changes, validate nothing is changed in response or backend
        $expected = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope
        $response = Update-AzPolicyExemption -Name $testExemption -Scope $rgScope
        $response.DisplayName | Should -Be $expected.DisplayName
        $response.Description | Should -Be $expected.Description
        $response.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $response.ExemptionCategory | Should -BeLike $expected.ExemptionCategory
        $response.Parameter | Should -BeLike $expected.Parameter
        $response.PolicyDefinitionReferenceId | Should -BeLike $expected.PolicyDefinitionReferenceId
        $response.ExpiresOn | Should -BeLike $expected.ExpiresOn
        $response.AssignmentScopeValidation | Should -BeLike $expected.AssignmentScopeValidation
        $actual = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope
        $actual.DisplayName | Should -Be $expected.DisplayName
        $actual.Description | Should -Be $expected.Description
        $actual.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $actual.ExemptionCategory | Should -BeLike $expected.ExemptionCategory
        $actual.Parameter | Should -BeLike $expected.Parameter
        $actual.PolicyDefinitionReferenceId | Should -BeLike $expected.PolicyDefinitionReferenceId
        $actual.ExpiresOn | Should -BeLike $expected.ExpiresOn
        $actual.AssignmentScopeValidation | Should -BeLike $expected.AssignmentScopeValidation
    }

    It 'Update policy exemption by clearing the expiration' {
        # get the exemption by name first
        $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope

        # update the exemption to clear the expiration
        $exemption = Update-AzPolicyExemption -Id $exemption.Id -ClearExpiration
        $exemption.ExpiresOn | Should -BeNull
    }

    It 'List policy exemptions by scope' {
        # make another policy exemption, ensure both are present in resource group scope listing
        $exemption2 = New-AzPolicyExemption -Name $testExemption2 -PolicyAssignment $assignment -Scope $rgScope -ExemptionCategory Mitigated -ExpiresOn $future2
        $list = Get-AzPolicyExemption -Scope $rgScope | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 2
    }

    It 'List policy exemptions full scope' {
        # ensure both are present in full listing
        $list = Get-AzPolicyExemption -IncludeDescendent | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 2
    }

    It 'List policy exemptions definitionId scope' {
        # ensure both are present when filtering by assignment Id
        $list = Get-AzPolicyExemption -PolicyAssignmentIdFilter $assignment.Id | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 2
        $list = Get-AzPolicyExemption -PolicyAssignmentIdFilter "$($assignment.Id)notexist" | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 0
    }

    It 'List policy exemptions default scope' {
        # ensure neither are present in default listing (at subscription)
        $list = Get-AzPolicyExemption | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 0
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyExemption -Name $testExemption -Scope $rgScope -Force -PassThru
        $remove = (Remove-AzPolicyExemption -Name $testExemption2 -Scope $rgScope -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $rgScope -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
