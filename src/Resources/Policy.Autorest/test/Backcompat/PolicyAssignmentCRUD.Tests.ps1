# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyAssignmentCRUD'

Describe 'Backcompat-PolicyAssignmentCRUD' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $policyName = Get-ResourceName

        $policySetDefName = Get-ResourceName
        $policyDefName1 = Get-ResourceName
        $policyDefName2 = Get-ResourceName

        # make a new resource group and policy definition
        $policyDefinition1 = New-AzPolicyDefinition -Name $policyDefName1 -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible
        $policyDefinition2 = New-AzPolicyDefinition -Name $policyDefName2 -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible
        $policySetString = "[{""policyDefinitionId"":""" + $policyDefinition1.PolicyDefinitionId + """}, {""policyDefinitionId"":""" + $policyDefinition2.PolicyDefinitionId + """}]"
        $policySet = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySetString -Description $description -Metadata $metadata -BackwardCompatible
        $policyDefinitionReferenceId1 = $policySet.Properties.PolicyDefinitions[0].policyDefinitionReferenceId
        $policyDefinitionReferenceId2 = $policySet.Properties.PolicyDefinitions[1].policyDefinitionReferenceId

        $nonComplianceMessages = @(@{ Message = "General message" })
        $test1 = Get-ResourceName
        $test2 = Get-ResourceName
    }

    It 'make a policy assignment at RG scope' {
        {
            # assign the policy definition to the resource group, get the assignment back and validate
            $actual = New-AzPolicyAssignment -Name $test1 -PolicySetDefinition $policySet -Scope $rgScope -Description $description -NonComplianceMessage $nonComplianceMessages -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $test1 -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policySet.ResourceId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual 1 $expected.Properties.NonComplianceMessages.Length
            Assert-AreEqual "General message" $expected.Properties.NonComplianceMessages[0].Message
        } | Should -Not -Throw
    }

    It 'get policy assignment by Id' {
        {
            # get first assignment back by name
            $actual = Get-AzPolicyAssignment -Name $test1 -Scope $rgScope -BackwardCompatible

            # get it again by id and validate
            $actualId = Get-AzPolicyAssignment -Id $actual.ResourceId -BackwardCompatible
            Assert-AreEqual $actual.ResourceId $actualId.ResourceId
            Assert-AreEqual 1 $actualId.Properties.NonComplianceMessages.Length
            Assert-AreEqual "General message" $actualId.Properties.NonComplianceMessages[0].Message
        }
    }

    It 'make a policy assignment with multiple noncompliance messages' {
        {
            # get first assignment back by name
            $get = Get-AzPolicyAssignment -Name $test1 -Scope $rgScope -BackwardCompatible

            $nonComplianceMessages = $nonComplianceMessages + @(@{
                Message = "Specific message 1"
                PolicyDefinitionReferenceId = $policyDefinitionReferenceId1
            })

            # this is here because of weirdness around the += operator being different from scriptblock (Pester) vs. script file (Legacy)
            Assert-AreEqual 2 $nonComplianceMessages.Length

            # create it again with two non-compliance messages
            $new = New-AzPolicyAssignment -Name $test1 -PolicySetDefinition $policySet -Scope $rgScope -Description $description -NonComplianceMessage $nonComplianceMessages -BackwardCompatible
            Assert-AreEqual $get.ResourceId $new.ResourceId

            # get it again by id and validate non-compliance messages
            $get2 = Get-AzPolicyAssignment -Id $get.ResourceId -BackwardCompatible
            Assert-AreEqual 2 $get2.Properties.NonComplianceMessages.Length
            Assert-AreEqual "Specific message 1" $get2.Properties.NonComplianceMessages[1].Message
            Assert-AreEqual $policyDefinitionReferenceId1 $get2.Properties.NonComplianceMessages[1].PolicyDefinitionReferenceId

            # validate non-compliance messages after update
            Assert-AreEqual 2 $new.Properties.NonComplianceMessages.Length
            Assert-AreEqual "Specific message 1" $new.Properties.NonComplianceMessages[1].Message
            Assert-AreEqual $policyDefinitionReferenceId1 $new.Properties.NonComplianceMessages[1].PolicyDefinitionReferenceId

            # update the policy assignment, validate the result
            $set = Set-AzPolicyAssignment -Id $get.ResourceId -DisplayName testDisplay -BackwardCompatible
            Assert-AreEqual testDisplay $set.Properties.DisplayName

            # validate non-compliance messages from update
            Assert-AreEqual 2 $set.Properties.NonComplianceMessages.Length
            Assert-AreEqual "Specific message 1" $set.Properties.NonComplianceMessages[1].Message
            Assert-AreEqual $policyDefinitionReferenceId1 $set.Properties.NonComplianceMessages[1].PolicyDefinitionReferenceId
        } | Should -Not -Throw
    }

    It 'update policy assignment to a single noncompliance message' {
        {
            # get first assignment back again
            $actual = Get-AzPolicyAssignment -Name $test1 -Scope $rgScope -BackwardCompatible

            $nonComplianceMessages = @(@{ Message = "General non-compliance message" })

            # update the policy assignment's non-compliance messages with one new general message
            $set = Set-AzPolicyAssignment -Id $actual.ResourceId -NonComplianceMessage $nonComplianceMessages -BackwardCompatible
            Assert-AreEqual 1 $set.Properties.NonComplianceMessages.Length
            Assert-AreEqual "General non-compliance message" $set.Properties.NonComplianceMessages[0].Message
            Assert-Null $set.Properties.NonComplianceMessages[0].PolicyDefinitionReferenceId
        } | Should -Not -Throw
    }

    It 'update policy assignment back to a multiple noncompliance message' {
        {
            # get first assignment back again
            $actual = Get-AzPolicyAssignment -Name $test1 -Scope $rgScope -BackwardCompatible

            $nonComplianceMessages = @(
            @{
                Message = "Specific message 1"
                PolicyDefinitionReferenceId = $policyDefinitionReferenceId1
            },
            @{
                Message = "Specific message 2"
                PolicyDefinitionReferenceId = $policyDefinitionReferenceId2
            }
            )

            # update the policy assignment's non-compliance message with two specific messages
            $set = Set-AzPolicyAssignment -Id $actual.ResourceId -NonComplianceMessage $nonComplianceMessages -BackwardCompatible
            Assert-AreEqual 2 $set.Properties.NonComplianceMessages.Length
            Assert-AreEqual "Specific message 2" $set.Properties.NonComplianceMessages[1].Message
            Assert-AreEqual $policyDefinitionReferenceId2 $set.Properties.NonComplianceMessages[1].PolicyDefinitionReferenceId
        } | Should -Not -Throw
    }

    It 'list policy assignments' {
        {
            # make another policy assignment, ensure both are present in resource group scope listing
            $expected = New-AzPolicyAssignment -Name $test2 -Scope $rgScope -PolicyDefinition $policyDefinition1 -Description $description -BackwardCompatible
            $list1 = Get-AzPolicyAssignment -Scope $rgScope -BackwardCompatible | ?{ $_.Name -in @($test1, $test2) }
            Assert-AreEqual 2 $list1.Count

            # ensure both are present in full listing
            $list2 = Get-AzPolicyAssignment -IncludeDescendent -BackwardCompatible | ?{ $_.Name -in @($test1, $test2) }
            Assert-AreEqual 2 $list2.Count

            # ensure neither are present in default listing (at subscription)
            $list3 = Get-AzPolicyAssignment -BackwardCompatible | ?{ $_.Name -in @($test1, $test2) }
            Assert-AreEqual 0 $list3.Count
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $test1 -Scope $rgScope -BackwardCompatible
        $remove = (Remove-AzPolicyAssignment -Name $test2 -Scope $rgScope -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicySetDefinition -Name $policySetDefName -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName1 -Force -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName2 -Force -BackwardCompatible) -and $remove

        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
