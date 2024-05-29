# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyExemptionCRUD'

Describe 'Backcompat-PolicyExemptionCRUD' {

    BeforeAll {
        $testPA = Get-ResourceName
        $testExemption = Get-ResourceName
        $testExemption2 = Get-ResourceName

        # Get built-in Audit resource location matches resource group location
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a" -BackwardCompatible

        # make a new resource group, policy assignment
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $rgScope -DisplayName $description -BackwardCompatible
        $future1 = [DateTime]::Parse('3021-03-09T07:30:10Z').ToUniversalTime()
        $future2 = $future1.AddDays(1)
    }

    It 'Make policy exemption' {
        {
            # create the policy exemption to the resource group
            $exemption = New-AzPolicyExemption -Name $testExemption -PolicyAssignment $assignment -Scope $rgScope -ExemptionCategory Waiver -Description $description -DisplayName $description -Metadata $metadata -BackwardCompatible
            Assert-AreEqual $testExemption $exemption.Name 
            Assert-AreEqual Microsoft.Authorization/policyExemptions $exemption.ResourceType
            Assert-AreEqual "$($rgScope)/providers/Microsoft.Authorization/policyExemptions/$testExemption" $exemption.ResourceId
            Assert-AreEqual $assignment.ResourceId $exemption.Properties.PolicyAssignmentId
            Assert-AreEqual "Waiver" $exemption.Properties.ExemptionCategory
            Assert-AreEqual $description $exemption.Properties.Description
            Assert-AreEqual $description $exemption.Properties.DisplayName
            Assert-NotNull $exemption.Properties.Metadata
            Assert-AreEqual $metadataValue $exemption.Properties.Metadata.$metadataName
            Assert-Null $exemption.Properties.ExpiresOn
        } | Should -Not -Throw
    }

    It 'Get policy exemption by name' {
        {
            # get the exemption by name
            $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $testExemption $exemption.Name 
            Assert-AreEqual Microsoft.Authorization/policyExemptions $exemption.ResourceType
            Assert-AreEqual "$($rgScope)/providers/Microsoft.Authorization/policyExemptions/$testExemption" $exemption.ResourceId
            Assert-AreEqual $assignment.ResourceId $exemption.Properties.PolicyAssignmentId
            Assert-AreEqual "Waiver" $exemption.Properties.ExemptionCategory
            Assert-AreEqual $description $exemption.Properties.Description
            Assert-AreEqual $description $exemption.Properties.DisplayName
            Assert-NotNull $exemption.Properties.Metadata
            Assert-AreEqual $metadataValue $exemption.Properties.Metadata.$metadataName
            Assert-Null $exemption.Properties.ExpiresOn
        } | Should -Not -Throw
    }

    It 'Get policy exemption by Id' {
        {
            # get the exemption by name first
            $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope -BackwardCompatible

            # get the exemption by id
            $exemption = Get-AzPolicyExemption -Id $exemption.ResourceId -BackwardCompatible
            Assert-AreEqual $testExemption $exemption.Name 
            Assert-AreEqual Microsoft.Authorization/policyExemptions $exemption.ResourceType
            Assert-AreEqual "$($rgScope)/providers/Microsoft.Authorization/policyExemptions/$testExemption" $exemption.ResourceId
            Assert-AreEqual $assignment.ResourceId $exemption.Properties.PolicyAssignmentId
            Assert-AreEqual "Waiver" $exemption.Properties.ExemptionCategory
            Assert-AreEqual $description $exemption.Properties.Description
            Assert-AreEqual $description $exemption.Properties.DisplayName
            Assert-NotNull $exemption.Properties.Metadata
            Assert-AreEqual $metadataValue $exemption.Properties.Metadata.$metadataName
            Assert-Null $exemption.Properties.ExpiresOn
        } | Should -Not -Throw
    }

    It 'Update policy exemption' {
        {
            # get the exemption by name first
            $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope -BackwardCompatible

            # update the policy exemption, validate the result
            $exemption = Set-AzPolicyExemption -Id $exemption.ResourceId -DisplayName testDisplay -ExemptionCategory Mitigated -ExpiresOn $future1 -Metadata '{}' -BackwardCompatible
            Assert-AreEqual "testDisplay" $exemption.Properties.DisplayName
            Assert-AreEqual "Mitigated" $exemption.Properties.ExemptionCategory
            Assert-AreEqual $future1 $exemption.Properties.ExpiresOn.ToUniversalTime()
            Assert-Null $exemption.Properties.Metadata.$metadataName
        } | Should -Not -Throw
    }

    It 'Update policy exemption by clearing the expiration' {
        {
            # get the exemption by name first
            $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $rgScope -BackwardCompatible

            # update the exemption to clear the expiration
            $exemption = Set-AzPolicyExemption -Id $exemption.ResourceId -ClearExpiration -BackwardCompatible
            Assert-Null $exemption.Properties.ExpiresOn
        } | Should -Not -Throw
    }

    It 'List policy exemptions by scope' {
        {
            # make another policy exemption, ensure both are present in resource group scope listing
            $exemption2 = New-AzPolicyExemption -Name $testExemption2 -PolicyAssignment $assignment -Scope $rgScope -ExemptionCategory Mitigated -ExpiresOn $future2 -BackwardCompatible
            $list = Get-AzPolicyExemption -Scope $rgScope -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 2 @($list).Count
        } | Should -Not -Throw
    }

    It 'List policy exemptions full scope' {
        {
            # ensure both are present in full listing
            $list = Get-AzPolicyExemption -IncludeDescendent -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 2 @($list).Count
        } | Should -Not -Throw
    }

    It 'List policy exemptions definitionId scope' {
        {
            # ensure both are present when filtering by assignment Id
            $list = Get-AzPolicyExemption -PolicyAssignmentIdFilter $assignment.ResourceId -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 2 @($list).Count
            $list = Get-AzPolicyExemption -PolicyAssignmentIdFilter "$($assignment.ResourceId)notexist" -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 0 @($list).Count
        } | Should -Not -Throw
    }

    It 'List policy exemptions default scope' {
        {
            # ensure neither are present in default listing (at subscription)
            $list = Get-AzPolicyExemption -BackwardCompatible | ?{ $_.Name -in @($testExemption, $testExemption2) }
            Assert-AreEqual 0 @($list).Count
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyExemption -Name $testExemption -Scope $rgScope -Force -BackwardCompatible
        $remove = (Remove-AzPolicyExemption -Name $testExemption2 -Scope $rgScope -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $rgScope -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
