# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentVersionCRUD'

Describe 'PolicyAssignmentVersionCRUD' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $customSetDef = Get-ResourceName
        $testPA1 = Get-ResourceName
        $testPA2 = Get-ResourceName
        $testPA3 = Get-ResourceName
        $testPA4 = Get-ResourceName
        $testPA5 = Get-ResourceName
        $testPA6 = Get-ResourceName
        $testPA7 = Get-ResourceName
        $policyDefName = '36fd7371-8eb7-4321-9c30-a7100022d048'
        $policySetName = '1bb84455-9e6e-434c-8db6-fa6d03a67e87'
        $oldestDefVersion = '1.0.0'
        $oldestDefMinor = '1.0.*'
        $otherDefVersion = '1.1.1'
        $otherDefMinor = '1.1.*'
        $newestDefVersion = '2.0.0'
        $newestDefMinor = '2.0.*'
        $oldestSetVersion = '1.0.0'
        $oldestSetMinor = '1.0.*'
        $otherSetVersion = '1.1.1'
        $otherSetMinor = '1.1.*'
        $newestSetVersion = '2.0.0'
        $newestSetMinor = '2.0.*'

        $oldestDefinition = Get-AzPolicyDefinition -Name $policyDefName -Version $oldestDefVersion
        $otherDefinition = Get-AzPolicyDefinition -Name $policyDefName -Version $otherDefVersion
        $newestDefinition = Get-AzPolicyDefinition -Name $policyDefName -Version $newestDefVersion
        $baseDefinition = Get-AzPolicyDefinition -Name $policyDefName

        $oldestSetDefinition = Get-AzPolicySetDefinition -Name $policySetName -Version $oldestSetVersion
        $otherSetDefinition = Get-AzPolicySetDefinition -Name $policySetName -Version $otherSetVersion
        $newestSetDefinition = Get-AzPolicySetDefinition -Name $policySetName -Version $newestSetVersion
        $baseSetDefinition = Get-AzPolicySetDefinition -Name $policySetName
    }

    It 'Validate initial definitions and set definitions' {
        $oldestDefinition.Name | Should -Be $oldestDefVersion
        $oldestDefinition.PolicyType | Should -Be 'Builtin'
        $oldestDefinition.Version | Should -Be $oldestDefVersion
        $otherDefinition.Name | Should -Be $otherDefVersion
        $otherDefinition.PolicyType | Should -Be 'Builtin'
        $otherDefinition.Version | Should -Be $otherDefVersion
        $newestDefinition.Name | Should -Be $newestDefVersion
        $newestDefinition.PolicyType | Should -Be 'Builtin'
        $newestDefinition.Version | Should -Be $newestDefVersion
        $baseDefinition.Name | Should -Be $policyDefName
        $baseDefinition.PolicyType | Should -Be 'Builtin'
        $baseDefinition.Version | Should -Be $newestDefVersion

        $oldestSetDefinition.Name | Should -Be $oldestSetVersion
        $oldestSetDefinition.PolicyType | Should -Be 'Builtin'
        $oldestSetDefinition.Version | Should -Be $oldestSetVersion
        $otherSetDefinition.Name | Should -Be $otherSetVersion
        $otherSetDefinition.PolicyType | Should -Be 'Builtin'
        $otherSetDefinition.Version | Should -Be $otherSetVersion
        $newestSetDefinition.Name | Should -Be $newestSetVersion
        $newestSetDefinition.PolicyType | Should -Be 'Builtin'
        $newestSetDefinition.Version | Should -Be $newestSetVersion
        $baseSetDefinition.Name | Should -Be $policySetName
        $baseSetDefinition.PolicyType | Should -Be 'Builtin'
        $baseSetDefinition.Version | Should -Be $newestSetVersion
    }

    It 'Make and validate a policy definition assignment with version reference at RG scope' {
        # make a policy assignment of versioned definition
        $expected = New-AzPolicyAssignment -Name $testPA1 -PolicyDefinition $otherDefinition -Scope $rgScope -PolicyParameterObject @{ tagName_V1 = 'some definition V1 tag'; tagName = 'some definition tag' } -Description $description

        # ensure it's present in the resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -eq $testPA1 }
        $list1.Count | Should -Be 1

        # ensure it's not present in default listing (at subscription)
        $list2 = Get-AzPolicyAssignment | ?{ $_.Name -eq $testPA1 }
        $list2.Count | Should -Be 0

        # get it back and validate it's the right one
        $actual = Get-AzPolicyAssignment -Name $testPA1 -Scope $rgScope
        $actual.Name | Should -Be $testPA1
        $actual.PolicyDefinitionId | Should -Be $baseDefinition.Id
        $actual.DefinitionVersion | Should -Be $otherDefMinor
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.DefinitionVersion | Should -Be $actual.DefinitionVersion
    }

    It 'Make and validate a policy set definition assignment with version reference at RG scope' {
        # make a policy assignment of versioned definition
        $expected = New-AzPolicyAssignment -Name $testPA2 -PolicyDefinition $otherSetDefinition -Scope $rgScope -PolicyParameterObject @{ tagName_V1 = 'some set definition V1 tag'; tagName = 'some set definition tag' } -Description $description

        # ensure it's present in the resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -eq $testPA2 }
        $list1.Count | Should -Be 1

        # ensure it's not present in default listing (at subscription)
        $list2 = Get-AzPolicyAssignment | ?{ $_.Name -eq $testPA2 }
        $list2.Count | Should -Be 0

        # get it back and validate it's the right one
        $actual = Get-AzPolicyAssignment -Name $testPA2 -Scope $rgScope
        $actual.Name | Should -Be $testPA2
        $actual.PolicyDefinitionId | Should -Be $baseSetDefinition.Id
        $actual.DefinitionVersion | Should -Be $otherSetMinor
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.DefinitionVersion | Should -Be $actual.DefinitionVersion
    }

    It 'Make and validate a policy definition assignment using string ID with version reference at RG scope' {
        # make a policy assignment of versioned definition
        $expected = New-AzPolicyAssignment -Name $testPA4 -PolicyDefinition $otherDefinition.Id -Scope $rgScope -PolicyParameterObject @{ tagName_V1 = 'some definition V1 tag'; tagName = 'some definition tag' } -Description $description

        # ensure it's present in the resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -eq $testPA4 }
        $list1.Count | Should -Be 1

        # ensure it's not present in default listing (at subscription)
        $list2 = Get-AzPolicyAssignment | ?{ $_.Name -eq $testPA4 }
        $list2.Count | Should -Be 0

        # get it back and validate it's the right one
        $actual = Get-AzPolicyAssignment -Name $testPA4 -Scope $rgScope
        $actual.Name | Should -Be $testPA4
        $actual.PolicyDefinitionId | Should -Be $baseDefinition.Id
        $actual.DefinitionVersion | Should -Be $otherDefMinor
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.DefinitionVersion | Should -Be $actual.DefinitionVersion
    }

    It 'Make and validate a policy set definition assignment using string ID with version reference at RG scope' {
        # make a policy assignment of versioned definition
        $expected = New-AzPolicyAssignment -Name $testPA5 -PolicyDefinition "$($baseSetDefinition.Id)/versions/$($otherSetMinor)" -Scope $rgScope -PolicyParameterObject @{ tagName_V1 = 'some V1 set definition tag' } -Description $description

        # ensure it's present in the resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -eq $testPA5 }
        $list1.Count | Should -Be 1

        # ensure it's not present in default listing (at subscription)
        $list2 = Get-AzPolicyAssignment | ?{ $_.Name -eq $testPA5 }
        $list2.Count | Should -Be 0

        # get it back and validate it's the right one
        $actual = Get-AzPolicyAssignment -Name $testPA5 -Scope $rgScope
        $actual.Name | Should -Be $testPA5
        $actual.PolicyDefinitionId | Should -Be $baseSetDefinition.Id
        $actual.DefinitionVersion | Should -Be $otherSetMinor
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.DefinitionVersion | Should -Be $actual.DefinitionVersion
    }

    It 'Make and validate a policy definition assignment using version parameter at RG scope' {
        # make a policy assignment of versioned definition
        $expected = New-AzPolicyAssignment -Name $testPA6 -PolicyDefinition $baseDefinition -DefinitionVersion $otherDefMinor -Scope $rgScope -PolicyParameterObject @{ tagName_V1 = 'some definition V1 tag'; tagName = 'some definition tag' } -Description $description

        # ensure it's present in the resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -eq $testPA6 }
        $list1.Count | Should -Be 1

        # ensure it's not present in default listing (at subscription)
        $list2 = Get-AzPolicyAssignment | ?{ $_.Name -eq $testPA6 }
        $list2.Count | Should -Be 0

        # get it back and validate it's the right one
        $actual = Get-AzPolicyAssignment -Name $testPA6 -Scope $rgScope
        $actual.Name | Should -Be $testPA6
        $actual.PolicyDefinitionId | Should -Be $baseDefinition.Id
        $actual.DefinitionVersion | Should -Be $otherDefMinor
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.DefinitionVersion | Should -Be $actual.DefinitionVersion
    }

    It 'Make and validate a policy set definition assignment using version parameter at RG scope' {
        # make a policy assignment of versioned definition
        $expected = New-AzPolicyAssignment -Name $testPA7 -PolicyDefinition $baseSetDefinition -DefinitionVersion $otherDefMinor -Scope $rgScope -PolicyParameterObject @{ tagName_V1 = 'some set definition V1 tag'; tagName = 'some set definition tag' } -Description $description

        # ensure it's present in the resource group scope listing
        $list1 = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -eq $testPA7 }
        $list1.Count | Should -Be 1

        # ensure it's not present in default listing (at subscription)
        $list2 = Get-AzPolicyAssignment | ?{ $_.Name -eq $testPA7 }
        $list2.Count | Should -Be 0

        # get it back and validate it's the right one
        $actual = Get-AzPolicyAssignment -Name $testPA7 -Scope $rgScope
        $actual.Name | Should -Be $testPA7
        $actual.PolicyDefinitionId | Should -Be $baseSetDefinition.Id
        $actual.DefinitionVersion | Should -Be $otherSetMinor
        $expected.Name | Should -Be $actual.Name
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.DefinitionVersion | Should -Be $actual.DefinitionVersion
    }

    It 'Make and validate a custom policy set with version references at RG scope' {

        $policyDefinition = 
@"
[
    {
        'policyDefinitionId': '$($baseDefinition.Id)',
        'definitionVersion': '$newestDefMinor',
        'parameters': {
            'tagName': {
                'value': 'SetAssignmentTagName'
            }
        }
    },
    {
        'policyDefinitionId': '$($baseDefinition.Id)',
        'definitionVersion': '$oldestDefMinor',
        'parameters': {
            'tagName_V1': {
                'value': 'SetAssignmentTagNameV1'
            }
        }
    },
    {
        'policyDefinitionId': '$($baseDefinition.Id)',
        'definitionVersion': '$otherDefMinor',
        'parameters': {
            'tagName': {
                'value': 'SetAssignmentTagName'
            },
            'tagName_V1': {
                'value': 'SetAssignmentTagNameV1'
            }
        }
    }
]
"@

        $policySet = New-AzPolicySetDefinition -Name $customSetDef -PolicyDefinition $policyDefinition -Description $description -Metadata $metadata
        $policySet.PolicyDefinition.Length | Should -Be 3
        $policySet.PolicyDefinition[0].policyDefinitionReferenceId | Should -Not -BeNullOrEmpty
        $policySet.PolicyDefinition[1].policyDefinitionReferenceId | Should -Not -BeNullOrEmpty
        $policySet.PolicyDefinition[2].policyDefinitionReferenceId | Should -Not -BeNullOrEmpty

        $referenceVersions = @($newestDefMinor, $otherDefMinor, $oldestDefMinor) | sort
        $expectedVersions = $policySet.PolicyDefinition.DefinitionVersion | sort
        $expectedVersions | Should -Be $referenceVersions

        $actual = Get-AzPolicySetDefinition -Name $customSetDef
        $actualVersions = $actual.PolicyDefinition.DefinitionVersion | sort
        $actualVersions | Should -Be $expectedVersions
    }

    It 'Make and validate a custom policy set assignment with version references at RG scope' {

        # get and assign the policy set definition to the resource group, get the assignment back and validate
        $policySet = Get-AzPolicySetDefinition -Name $customSetDef
        $expected = $policySet | New-AzPolicyAssignment -Name $testPA3 -Scope $rgScope -Description $description

        # get it back by name and scope
        $actual = Get-AzPolicyAssignment -Name $testPA3 -Scope $rgScope

        # validate the results
        $actual.Type | Should -Be Microsoft.Authorization/policyAssignments
        $actual.Type | Should -Be $expected.Type
        $actual.Name | Should -Be $testPA3
        $actual.Name | Should -Be $expected.Name
        $actual.Id | Should -Be $expected.Id
        $actual.PolicyDefinitionId | Should -Be $policySet.Id
        $actual.PolicyDefinitionId | Should -Be $expected.PolicyDefinitionId
        $actual.Scope | Should -Be $rgScope
        $actual.Scope | Should -Be $expected.Scope
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testPA1 -Scope $rgScope -PassThru
        $remove = (Remove-AzPolicyAssignment -Name $testPA2 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA3 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA4 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA5 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA6 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA7 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicySetDefinition -Name $customSetDef -Force -PassThru) -and $remove

        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
