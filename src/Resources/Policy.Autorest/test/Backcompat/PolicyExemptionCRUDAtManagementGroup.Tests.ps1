# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyExemptionCRUDAtManagementGroup'

Describe 'Backcompat-PolicyExemptionCRUDAtManagementGroup' {

    BeforeAll {
        $testPA = Get-ResourceName -MaxLength 24
        $testExemption = Get-ResourceName -MaxLength 24
        $testExemption2 = Get-ResourceName -MaxLength 24

        # Get built-in Audit resource location matches resource group location
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a" -BackwardCompatible

        # make a policy assignment at MG level
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $managementGroupScope -DisplayName $description -BackwardCompatible

        # create the policy exemption to the MG
        $future1 = [DateTime]::Parse('3021-03-09T07:30:10Z').ToUniversalTime()
        $future2 = $future1.AddDays(1).ToUniversalTime()
        $exemption = New-AzPolicyExemption -Name $testExemption -PolicyAssignment $assignment -Scope $managementGroupScope -ExemptionCategory Waiver -Description $description -DisplayName $description -Metadata $metadata -ExpiresOn $future1 -BackwardCompatible
    }

    It 'make policy exemption at MG level' {
        {
            Assert-AreEqual $testExemption $exemption.Name 
            Assert-AreEqual Microsoft.Authorization/policyExemptions $exemption.ResourceType
            Assert-AreEqual "$managementGroupScope/providers/Microsoft.Authorization/policyExemptions/$testExemption" $exemption.ResourceId
            Assert-AreEqual $assignment.ResourceId $exemption.Properties.PolicyAssignmentId
            Assert-AreEqual "Waiver" $exemption.Properties.ExemptionCategory
            Assert-AreEqual $description $exemption.Properties.Description
            Assert-AreEqual $description $exemption.Properties.DisplayName
            Assert-AreEqual $future1 $exemption.Properties.ExpiresOn.ToUniversalTime()
            Assert-NotNull $exemption.Properties.Metadata
            Assert-AreEqual $metadataValue $exemption.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'update policy exemption at MG level' {
        {
            # update the policy exemption, validate the result
            $exemption = Set-AzPolicyExemption -Id $exemption.ResourceId -DisplayName testDisplay -ExemptionCategory Mitigated -ExpiresOn $future2 -Metadata '{}' -BackwardCompatible
            Assert-AreEqual "testDisplay" $exemption.Properties.DisplayName
            Assert-AreEqual "Mitigated" $exemption.Properties.ExemptionCategory
            Assert-AreEqual $future2 $exemption.Properties.ExpiresOn.ToUniversalTime()
            Assert-Null $exemption.Properties.Metadata.$metadataName
        }
    }

    It 'update policy exemption at MG level to clear expiration' {
        {
            # update the exemption to clear the expiration
            $exemption = Set-AzPolicyExemption -Id $exemption.ResourceId -ClearExpiration -BackwardCompatible
            Assert-Null $exemption.Properties.ExpiresOn
        }
    }

    It 'list policy exemptions at MG level' {
        {
            # make another policy exemption, ensure both are present in management group scope listing
            $exemption2 = New-AzPolicyExemption -Name $testExemption2 -PolicyAssignment $assignment -Scope $managementGroupScope -ExemptionCategory Mitigated -ExpiresOn $future2 -BackwardCompatible
            $list = Get-AzPolicyExemption -Scope $managementGroupScope -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 2 @($list).Count
        }
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyExemption -Name $testExemption -Scope $managementGroupScope -Force -BackwardCompatible
        $remove = (Remove-AzPolicyExemption -Name $testExemption2 -Scope $managementGroupScope -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $managementGroupScope -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
