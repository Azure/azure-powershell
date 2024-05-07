# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyExemptionCRUDOnPolicySet'

Describe 'PolicyExemptionCRUDOnPolicySet' {

    BeforeAll {
        # Get built-in Audit resource location matches resource group location
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"
        $testExemption = Get-ResourceName
        $testExemption2 = Get-ResourceName
        $testPSD = Get-ResourceName
        $testPA = Get-ResourceName

        # make a new policySet, policy assignment
        $policyRef = "[{""policyDefinitionId"":""" + $policy.Id + """}]"
        $policySet = New-AzPolicySetDefinition -Name $testPSD -PolicyDefinition $policyRef -DisplayName $description
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicySetDefinition $policySet -DisplayName $description
        # remove metadata added by autorest serializer
        $assignment.Metadata = $null

        # create the policy exemption to the subscription
        $future1 = [DateTime]::Parse('3021-03-09T07:30:10Z').ToUniversalTime()
        $future2 = $future1.AddDays(1).ToUniversalTime()
        $exemption = ($assignment | New-AzPolicyExemption -Name $testExemption -ExemptionCategory Waiver -DisplayName $description -ExpiresOn $future1)
    }

    It 'Make policy exemption on policy set definition' {
        $exemption.Name | Should -Be $testExemption
        $exemption.Type | Should -Be 'Microsoft.Authorization/policyExemptions'
        $exemption.PolicyAssignmentId | Should -Be $assignment.Id
        $exemption.DisplayName | Should -Be $description
        # autorest serializer doesn't support $null Metadata, now checking for empty
        $exemption.Metadata | Should -BeNull
        $exemption.PolicyDefinitionReferenceId | Should -BeNull
        $exemption.ExpiresOn.ToUniversalTime() | Should -Be $future1
    }

    It 'Update policy exemption by pipeline input' {
        $exemption.DisplayName = 'testDisplay'
        $exemption.ExemptionCategory = 'Mitigated'
        $exemption.ExpiresOn = $future2
        $exemption.PolicyDefinitionReferenceId = @($policySet.PolicyDefinition[0].policyDefinitionReferenceId)
        $exemption = $exemption | Update-AzPolicyExemption
        $exemption.DisplayName | Should -Be 'testDisplay'
        $exemption.ExemptionCategory | Should -Be 'Mitigated'
        $exemption.ExpiresOn.ToUniversalTime() | Should -Be $future2
        $exemption.PolicyDefinitionReferenceId | Should -Not -BeNullOrEmpty
        $exemption.PolicyDefinitionReferenceId | Should -HaveCount 1
        $exemption.PolicyDefinitionReferenceId[0] | Should -Be $policySet.PolicyDefinition[0].policyDefinitionReferenceId[0]
    }

    It 'Update policy exemption by parameters' {
        # update the policy exemption set policy definition reference Id using parameters, validate the result
        $exemption = Update-AzPolicyExemption -Name $testExemption -DisplayName 'testDisplay1' -ExemptionCategory Waiver -PolicyDefinitionReferenceId @($policySet.PolicyDefinition[0].policyDefinitionReferenceId)
        $exemption.DisplayName | Should -Be 'testDisplay1'
        $exemption.ExemptionCategory | Should -Be 'Waiver'
        $exemption.ExpiresOn.ToUniversalTime() | Should -Be $future2
        $exemption.PolicyDefinitionReferenceId | Should -Not -BeNullOrEmpty
        $exemption.PolicyDefinitionReferenceId | Should -HaveCount 1
        $exemption.PolicyDefinitionReferenceId[0] | Should -Be $policySet.PolicyDefinition[0].policyDefinitionReferenceId[0]
    }

    It 'Update policy exemption to clear the expiration' {
        # update the exemption to clear the expiration
        $exemption.PolicyDefinitionReferenceId = @()
        $exemption = $exemption | Update-AzPolicyExemption
        # for some reason the next check fails, even though the array is empty (as confirmed by subsequent checks)
        #$exemption.PolicyDefinitionReferenceId | Should -HaveCount 0
        $exemption.PolicyDefinitionReferenceId.Count | Should -Be 0
        $exemption.PolicyDefinitionReferenceId | Should -Be @()
        $exemption.PolicyDefinitionReferenceId | Should -BeNull
        $exemption.PolicyDefinitionReferenceId | Should -BeNullOrEmpty
    }

    It 'List policy exemptions' {
        # make another policy exemption, ensure both are present
        $exemption2 = $assignment | New-AzPolicyExemption -Name $testExemption2 -ExemptionCategory Mitigated -DisplayName $description
        $list = Get-AzPolicyExemption | ?{ $_.Name -in @($testExemption, $testExemption2) }
        $list | Should -HaveCount 2
    }

    AfterAll {
        # clean up cleanly
        $cleanupList = Get-AzPolicyExemption -IncludeDescendent | ?{ $_.Name -in @($testExemption, $testExemption2) }

        $remove = $true
        foreach ($exemption in $cleanupList) {
            $remove = ($exemption | Remove-AzPolicyExemption -Force -PassThru) -and $remove
        }

        $remove = (Remove-AzPolicyAssignment -Name $testPA -PassThru) -and $remove
        $remove = (Remove-AzPolicySetDefinition -Name $testPSD -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
