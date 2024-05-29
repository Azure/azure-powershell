# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyExemptionCRUDOnPolicySet'

Describe 'Backcompat-PolicyExemptionCRUDOnPolicySet' {

    BeforeAll {
        $testPSD = Get-ResourceName
        $testPA = Get-ResourceName
        $testExemption = Get-ResourceName
        $testExemption2 = Get-ResourceName

        # Get built-in Audit resource location matches resource group location
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a" -BackwardCompatible

        # make a new policySet, policy assignment
        $policyRef = "[{""policyDefinitionId"":""" + $policy.PolicyDefinitionId + """}]"
        $policySet = New-AzPolicySetDefinition -Name $testPSD -PolicyDefinition $policyRef -DisplayName $description -BackwardCompatible
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicySetDefinition $policySet -DisplayName $description -BackwardCompatible
        # remove metadata added by autorest serializer
        $assignment.Metadata = $null

        # create the policy exemption to the subscription
        $future1 = [DateTime]::Parse('3021-03-09T07:30:10Z').ToUniversalTime()
        $future2 = $future1.AddDays(1).ToUniversalTime()
        $exemption = ($assignment | New-AzPolicyExemption -Name $testExemption -ExemptionCategory Waiver -DisplayName $description -ExpiresOn $future1 -BackwardCompatible)
    }

    It 'make policy exemption on policy set definition' {
        {
            Assert-AreEqual $testExemption $exemption.Name 
            Assert-AreEqual Microsoft.Authorization/policyExemptions $exemption.ResourceType
            Assert-AreEqual $assignment.ResourceId $exemption.Properties.PolicyAssignmentId
            Assert-AreEqual $description $exemption.Properties.DisplayName
            # autorest serializer doesn't support $null Metadata, now checking for empty
            #Assert-Null $exemption.Properties.Metadata
            Assert-AreEqual 0 $exemption.Properties.Metadata.Keys.Count
            Assert-Null $exemption.Properties.PolicyDefinitionReferenceIds
            Assert-AreEqual $future1 $exemption.Properties.ExpiresOn.ToUniversalTime()
        } | Should -Not -Throw
    }

    It 'update policy exemption by pipeline input' {
        {
            $exemption.DisplayName = 'testDisplay'
            $exemption.ExemptionCategory = 'Mitigated'
            $exemption.ExpiresOn = $future2
            $exemption.PolicyDefinitionReferenceId = @($policySet.Properties.PolicyDefinitions[0].policyDefinitionReferenceId)
            $exemption = $exemption | Set-AzPolicyExemption -BackwardCompatible
            Assert-AreEqual 'testDisplay' $exemption.Properties.DisplayName
            Assert-AreEqual 'Mitigated' $exemption.Properties.ExemptionCategory
            Assert-AreEqual $future2 $exemption.Properties.ExpiresOn.ToUniversalTime()
            Assert-NotNull $exemption.Properties.PolicyDefinitionReferenceIds
            Assert-AreEqual 1 $exemption.Properties.PolicyDefinitionReferenceIds.Count
            Assert-AreEqual $policySet.Properties.PolicyDefinitions[0].policyDefinitionReferenceId @($exemption.Properties.PolicyDefinitionReferenceIds)[0]
        } | Should -Not -Throw
    }

    It 'update policy exemption by parameters' {
        {
            # update the policy exemption set policy definition reference Id using parameters, validate the result
            $exemption = Set-AzPolicyExemption -Name $testExemption -DisplayName 'testDisplay1' -ExemptionCategory Waiver -PolicyDefinitionReferenceId @($policySet.Properties.PolicyDefinitions[0].policyDefinitionReferenceId) -BackwardCompatible
            Assert-AreEqual 'testDisplay1' $exemption.Properties.DisplayName
            Assert-AreEqual 'Waiver' $exemption.Properties.ExemptionCategory
            Assert-AreEqual $future2 $exemption.Properties.ExpiresOn.ToUniversalTime()
            Assert-NotNull $exemption.Properties.PolicyDefinitionReferenceIds
            Assert-AreEqual 1 $exemption.Properties.PolicyDefinitionReferenceIds.Count
            Assert-AreEqual $policySet.Properties.PolicyDefinitions[0].policyDefinitionReferenceId @($exemption.Properties.PolicyDefinitionReferenceIds)[0]
        } | Should -Not -Throw
    }

    It 'update policy exemption to clear the expiration' {
        {
            # update the exemption to clear the expiration
            $exemption.PolicyDefinitionReferenceId = @()
            $exemption = $exemption | Set-AzPolicyExemption -BackwardCompatible
            Assert-AreEqual 0 @($exemption.Properties.PolicyDefinitionReferenceIds).Count
        } | Should -Not -Throw
    }

    It 'list policy exemptions' {
        {
            # make another policy exemption, ensure both are present
            $exemption2 = $assignment | New-AzPolicyExemption -Name $testExemption2 -ExemptionCategory Mitigated -DisplayName $description -BackwardCompatible
            $list = Get-AzPolicyExemption -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 2 @($list).Count
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up cleanly
        $cleanupList = Get-AzPolicyExemption -IncludeDescendent -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }

        $remove = $true
        foreach ($exemption in $cleanupList) {
            $remove = ($exemption | Remove-AzPolicyExemption -Force -BackwardCompatible) -and $remove
        }

        $remove = (Remove-AzPolicyAssignment -Name $testPA -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicySetDefinition -Name $testPSD -Force -BackwardCompatible) -and $remove

        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
