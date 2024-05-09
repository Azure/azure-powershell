# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentWithParameters'

Describe 'PolicyAssignmentWithParameters' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $policyName = Get-ResourceName
        $testPAWP = Get-ResourceName

        # make a resource group and policy definition with parameters
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json" -Description $description
        $array = @("West US", "West US 2")
        $param = @{"listOfAllowedLocations"=$array}
    }

    It 'Make policy assignment with parameters' {
        # assign the policy definition to the resource group supplying powershell object parameters, get the policy assignment back and validate
        $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -PolicyParameterObject $param -Description $description
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name

        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $actual.Type | Should -Be $expected.Type

        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array[1]

        # delete the policy assignment
        $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PassThru
        $remove | Should -Be $true
    }

    It 'Make policy assignment with parameters from a file' {
        # assign the policy definition to the resource group supplying file parameters, get the policy assignment back and validate
        $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -PolicyParameter "$testFilesFolder\SamplePolicyAssignmentParameters.json" -Description $description
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $expected.Type | Should -Be $actual.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array[1]
    }

    It 'Update policy assignment parameters' {
        # update parameters
        # this is validation for https://github.com/Azure/azure-powershell/issues/6055
        $actual = Update-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "something", "something else" ] } }'
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be 'something'
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be 'something else'

        # delete the policy assignment
        $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PassThru
        $remove | Should -Be $true
    }

    It 'Make policy assignment with hashtable of parameters' {
        # assign the policy definition to the resource group supplying command line literal parameters, get the policy assignment back and validate
        $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }' -Description $description -Metadata $metadata
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $expected.Type | Should -Be $actual.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName | Should -Be $metadataValue
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array[1]

        # delete the policy assignment (commented out because next two tests are -Skip'd)
        #$remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PassThru
        #$remove | Should -Be $true
    }

    # This test is -Skip'd because dynamic parameters don't work in Pester 4.X + autorest-generated cmdlets (not sure about v5)
    # Note: this code works fine in a command shell or regular script
    It 'Make policy assignment with dynamic parameters' -Skip {
        # assign the policy definition to the resource group supplying Powershell parameters, get the policy assignment back and validate
        $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -listOfAllowedLocations $array -Description $description -Metadata $metadata
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be $expected.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName| Should -Be $metadataValue
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array[1]

        # delete the policy assignment
        $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $remove | Should -Be $true
    }

    # This test is -Skip'd because dynamic parameters don't work in Pester 4.X + autorest-generated cmdlets (not sure about v5)
    # Note: this code works fine in a command shell or regular script
    It 'Make policy assignment overriding default dynamic parameter' -Skip {
        # assign the policy definition to the resource group supplying Powershell parameters (including overriding a default value), get the policy assignment back and validate
        $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -listOfAllowedLocations $array -effectParam "Disabled" -Description $description -Metadata $metadata
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $actual.Type | Should -Be $expected.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $actual.Metadata | Should -Not -BeNullOrEmpty
        $actual.Metadata.$metadataName | Should -Be $metadataValue
        $expected.Parameter.effectParam.Value | Should -Be 'Disabled'
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array[1]
    }

    It 'Update policy assignment description and metadata' {
        # update the policy assignment (one with parameters and metadata), get it back and validate
        # this is validation for https://github.com/Azure/azure-powershell/issues/6055
        $newDescription = "$description - Updated"
        $newMetadata =  "{'Meta1': 'Value1', 'Meta2': { 'Meta22': 'Value22' }}"
        $actual = Update-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -Description $newDescription -Metadata $newMetadata
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be $expected.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array[1]
        $expected.Description | Should -Be $newDescription
        $expected.Metadata | Should -Not -BeNullOrEmpty
        $expected.Metadata.Meta1 | Should -Be 'Value1'
        $expected.Metadata.Meta2.Meta22 | Should -Be 'Value22'
    }

    It 'Update policy assignment powershell object parameters' {
        # update parameters
        # this is validation for https://msazure.visualstudio.com/One/_workitems/edit/4421756
        $array2 = @("West2 US2", "West2 US22")
        $param2 = @{"listOfAllowedLocations"=$array2}
        $actual = Update-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyParameterObject $param2
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be $expected.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.Parameter.listOfAllowedLocations.Value[0] | Should -Be $array2[0]
        $expected.Parameter.listOfAllowedLocations.Value[1] | Should -Be $array2[1]
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PassThru
        $remove = (Remove-AzPolicyDefinition -Name $policyName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
