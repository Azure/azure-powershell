# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentCRUD'

Describe 'PolicyAssignmentCRUD' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $policySetDefName = Get-ResourceName
        $policyDefName1 = Get-ResourceName
        $policyDefName2 = Get-ResourceName
        $testPA = Get-ResourceName
        $test2 = Get-ResourceName

        # make a new resource group and policy definition
        $policyDefinition1 = New-AzPolicyDefinition -Name $policyDefName1 -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policyDefinition2 = New-AzPolicyDefinition -Name $policyDefName2 -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        $policySetString = "[{""policyDefinitionId"":""" + $policyDefinition1.Id + """}, {""policyDefinitionId"":""" + $policyDefinition2.Id + """}]"
        $policySet = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySetString -Description $description -Metadata $metadata
        $policyDefinitionReferenceId1 = $policySet.PolicyDefinition[0].policyDefinitionReferenceId
        $policyDefinitionReferenceId2 = $policySet.PolicyDefinition[1].policyDefinitionReferenceId

        $nonComplianceMessage = @(@{ Message = 'General message' })
    }

    It 'Make and validate a policy assignment at RG scope' {
        # assign the policy definition to the resource group, get the assignment back
        $actual = New-AzPolicyAssignment -Name $testPA -PolicySetDefinition $policySet -Scope $rgScope -Description $description -NonComplianceMessage $nonComplianceMessage

        # get it back by name and scope
        $expected = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # validate the results
        $actual.Type | Should -Be Microsoft.Authorization/policyAssignments 
        $expected.Name | Should -Be $actual.Name
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policySet.Id
        $expected.Scope | Should -Be $rgScope
        $expected.NonComplianceMessage.Length | Should -Be 1
        $expected.NonComplianceMessage[0].Message | Should -Be 'General message'
    }

    It 'Get policy assignment by Id' {
        # get original assignment back by name and scope
        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # get it again by id
        $actualId = Get-AzPolicyAssignment -Id $actual.Id

        # validate results
        $actual.Id | Should -Be $actualId.Id
        $actualId.NonComplianceMessage.Length | Should -Be 1
        $actualId.NonComplianceMessage[0].Message | Should -Be 'General message'
    }

    It 'Make and validate a policy assignment with multiple non-compliance messages' {
        # get original assignment back by name and scope
        $get = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # make a new non-compliance message
        $nonComplianceMessage = $nonComplianceMessage + @(@{
            Message = "Specific message 1"
            PolicyDefinitionReferenceId = $policyDefinitionReferenceId1
        })

        # this is here because of weirdness around the += operator being different from scriptblock (Pester) vs. script file (Legacy)
        $nonComplianceMessage.Length | Should -Be 2

        # create it again with two non-compliance messages
        $new = New-AzPolicyAssignment -Name $testPA -PolicySetDefinition $policySet -Scope $rgScope -Description $description -NonComplianceMessage $nonComplianceMessage -DisplayName $someDisplayName
        $new.Id | Should -Be $get.Id

        # get it again by id and validate non-compliance messages
        $get2 = Get-AzPolicyAssignment -Id $get.Id
        $get2.NonComplianceMessage.Length | Should -Be 2
        $get2.NonComplianceMessage[1].Message | Should -Be 'Specific message 1'
        $get2.NonComplianceMessage[1].PolicyDefinitionReferenceId | Should -Be $policyDefinitionReferenceId1

        # validate non-compliance messages after update
        $new.NonComplianceMessage.Length | Should -Be 2
        $new.NonComplianceMessage[1].Message | Should -Be 'Specific message 1'
        $new.NonComplianceMessage[1].PolicyDefinitionReferenceId | Should -Be $policyDefinitionReferenceId1

        # update the policy assignment with no change, validate DisplayName and Description (this was a previously reported issue)
        $update = Update-AzPolicyAssignment -Id $get.Id -EnforcementMode Default
        $update.DisplayName | Should -Be $someDisplayName
        $update.Description | Should -Be $description

        # validate Get result as well
        $temp = Get-AzPolicyAssignment -Id $get.Id
        $temp.DisplayName | Should -Be $someDisplayName
        $temp.Description | Should -Be $description

        # update the policy assignment, validate the result
        $update = Update-AzPolicyAssignment -Id $get.Id -DisplayName testDisplay
        $update.DisplayName | Should -Be testDisplay

        # validate non-compliance messages from update
        $update.NonComplianceMessage.Length | Should -Be 2
        $update.NonComplianceMessage[1].Message | Should -Be 'Specific message 1'
        $update.NonComplianceMessage[1].PolicyDefinitionReferenceId | Should -Be $policyDefinitionReferenceId1
    }

    It 'Validate parameter round-trip' {
        # get the definition, do an update with no changes, validate nothing is changed in response or backend
        $expected = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope
        $response = Update-AzPolicyAssignment -Name $testPA -Scope $rgScope
        $response.DisplayName | Should -Be $expected.DisplayName
        $response.Description | Should -Be $expected.Description
        $response.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $response.NonComplianceMessage[0] | Should -BeLike $expected.NonComplianceMessage[0]
        $response.NonComplianceMessage[1] | Should -BeLike $expected.NonComplianceMessage[1]
        $response.Parameter | Should -BeLike $expected.Parameter
        $response.NotScope | Should -BeLike $expected.NotScope
        $response.Location | Should -BeLike $expected.Location
        $response.EnforcementMode | Should -BeLike $expected.EnforcementMode
        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope
        $actual.DisplayName | Should -Be $expected.DisplayName
        $actual.Description | Should -Be $expected.Description
        $actual.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $actual.NonComplianceMessage[0] | Should -BeLike $expected.NonComplianceMessage[0]
        $actual.NonComplianceMessage[1] | Should -BeLike $expected.NonComplianceMessage[1]
        $actual.Parameter | Should -BeLike $expected.Parameter
        $actual.NotScope | Should -Be $expected.NotScope
        $actual.Location | Should -BeLike $expected.Location
        $actual.EnforcementMode | Should -BeLike $expected.EnforcementMode
    }

    It 'Update the policy assignment to have a single non-compliance message' {
        # get original assignment back again
        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # make a singleton non-compliance message
        $nonComplianceMessage = @(@{ Message = "General non-compliance message" })

        # update the policy assignment's non-compliance messages
        $update = Update-AzPolicyAssignment -Id $actual.Id -NonComplianceMessage $nonComplianceMessage

        # validate results
        $update.NonComplianceMessage.Length | Should -Be 1
        $update.NonComplianceMessage[0].Message | Should -Be 'General non-compliance message'
        $update.NonComplianceMessage[0].PolicyDefinitionReferenceId | Should -BeNull
    }

    It 'Update the policy assignment back to a multiple non-compliance message' {
        # get original assignment back again
        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # make a multi non-compliance message array
        $nonComplianceMessage = @(
        @{
            Message = 'Specific message 1'
            PolicyDefinitionReferenceId = $policyDefinitionReferenceId1
        },
        @{
            Message = 'Specific message 2'
            PolicyDefinitionReferenceId = $policyDefinitionReferenceId2
        }
        )

        # update the policy assignment's non-compliance messages
        $update = Update-AzPolicyAssignment -Id $actual.Id -NonComplianceMessage $nonComplianceMessage
        $update.NonComplianceMessage.Length | Should -Be 2
        $update.NonComplianceMessage[1].Message | Should -Be 'Specific message 2'
        $update.NonComplianceMessage[1].PolicyDefinitionReferenceId | Should -Be $policyDefinitionReferenceId2

        # validate the metadata has the same set of properties (some values can validly be different)
        @($update.Metadata | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty Name) | Should -Be @($actual.Metadata | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty Name)

        # use -BeLike, since -Be fails when both value are empty
        $update.Parameter | Should -BeLike $actual.Parameter
        $update.PolicyRule | Should -Be $actual.PolicyRule
        $update.Description | Should -Be $actual.Description
        $update.Mode | Should -Be $actual.Mode
        $update.PolicyType | Should -Be $actual.PolicyType
        $update.Name | Should -Be $actual.Name
        $update.Id | Should -Be $actual.Id
        $update.Type | Should -Be $actual.Type
        $update.SystemDataCreatedAt | Should -Be $actual.SystemDataCreatedAt
        $update.SystemDataCreatedBy | Should -Be $actual.SystemDataCreatedBy
        $update.SystemDataCreatedByType | Should -Be $actual.SystemDataCreatedByType
        $update.SystemDataLastModifiedAt | Should -BeGreaterThan $actual.SystemDataLastModifiedAt
        $update.SystemDataLastModifiedBy | Should -Not -BeNullOrEmpty
        $update.SystemDataLastModifiedByType | Should -Be 'User'
    }

    It 'List policy assignments and validate results' {
        # make another policy assignment
        $expected = New-AzPolicyAssignment -Name $test2 -Scope $rgScope -PolicyDefinition $policyDefinition1 -Description $description

        # ensure both are present in resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -in @($testPA, $test2) }
        $list1.Count | Should -Be 2

        # ensure both are present in full listing
        $list2 = Get-AzPolicyAssignment -IncludeDescendent | ?{ $_.Name -in @($testPA, $test2) }
        $list2.Count | Should -Be 2

        # ensure neither are present in default listing (at subscription)
        $list3 = Get-AzPolicyAssignment | ?{ $_.Name -in @($testPA, $test2) }
        $list3.Count | Should -Be 0
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testPA -Scope $rgScope -PassThru
        $remove = (Remove-AzPolicyAssignment -Name $test2 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicySetDefinition -Name $policySetDefName -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName1 -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName2 -Force -PassThru) -and $remove

        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
