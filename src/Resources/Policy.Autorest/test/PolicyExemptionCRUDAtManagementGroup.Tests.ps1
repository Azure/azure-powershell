# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyExemptionCRUDAtManagementGroup'

Describe 'PolicyExemptionCRUDAtManagementGroup' {

    BeforeAll {
        $testPA = Get-ResourceName -MaxLength 24
        $testExemption = Get-ResourceName -MaxLength 24
        $testExemption2 = Get-ResourceName -MaxLength 24

        # Get built-in Audit resource location matches resource group location
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"

        # make a policy assignment at MG level
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $managementGroupScope -DisplayName $description

        # create the policy exemption to the MG
        $future1 = [DateTime]::Parse('3021-03-09T07:30:10Z').ToUniversalTime()
        $future2 = $future1.AddDays(1).ToUniversalTime()
        $exemption = New-AzPolicyExemption -Name $testExemption -PolicyAssignment $assignment -Scope $managementGroupScope -ExemptionCategory Waiver -Description $description -DisplayName $description -Metadata $metadata -ExpiresOn $future1
    }

    It 'Make policy exemption at MG level' {
        $exemption.Name | Should -Be $testExemption
        $exemption.Type | Should -Be 'Microsoft.Authorization/policyExemptions'
        $exemption.Id | Should -Be "$managementGroupScope/providers/Microsoft.Authorization/policyExemptions/$testExemption"
        $exemption.PolicyAssignmentId | Should -Be $assignment.Id
        $exemption.ExemptionCategory | Should -Be 'Waiver'
        $exemption.Description | Should -Be $description
        $exemption.DisplayName | Should -Be $description
        $exemption.ExpiresOn.ToUniversalTime() | Should -Be $future1
        $exemption.Metadata | Should -Not -BeNullOrEmpty
        $exemption.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Update policy exemption at MG level' {
        # update the policy exemption, validate the result
        $exemption = Update-AzPolicyExemption -Id $exemption.Id -DisplayName testDisplay -ExemptionCategory Mitigated -ExpiresOn $future2 -Metadata '{}'
        $exemption.DisplayName | Should -Be 'testDisplay'
        $exemption.ExemptionCategory | Should -Be 'Mitigated'
        $exemption.ExpiresOn.ToUniversalTime() | Should -Be $future2
        $exemption.Metadata.$metadataName | Should -BeNull
    }

    It 'Update policy exemption at MG level to clear expiration' {
        # update the exemption to clear the expiration
        $exemption = Update-AzPolicyExemption -Id $exemption.Id -ClearExpiration
        $exemption.ExpiresOn | Should -BeNull
    }

    It 'List policy exemptions at MG level' {
        # make another policy exemption, ensure both are present in management group scope listing
        $exemption2 = New-AzPolicyExemption -Name $testExemption2 -PolicyAssignment $assignment -Scope $managementGroupScope -ExemptionCategory Mitigated -ExpiresOn $future2
        $list = Get-AzPolicyExemption -Scope $managementGroupScope | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 2
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyExemption -Name $testExemption -Scope $managementGroupScope -Force -PassThru
        $remove = (Remove-AzPolicyExemption -Name $testExemption2 -Scope $managementGroupScope -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $managementGroupScope -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
