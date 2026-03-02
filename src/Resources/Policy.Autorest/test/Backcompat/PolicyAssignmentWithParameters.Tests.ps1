# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyAssignmentWithParameters'

Describe 'Backcompat-PolicyAssignmentWithParameters' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $policyName = Get-ResourceName
        $testPAWP = Get-ResourceName

        # make a resource group and policy definition with parameters
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinitionWithParameters.json" -Parameter "$testFilesFolder\SamplePolicyDefinitionParameters.json" -Description $description -BackwardCompatible
        $array = @("West US", "West US 2")
        $param = @{"listOfAllowedLocations"=$array}
    }

    It 'make policy assignment with parameters' {
        {
            # assign the policy definition to the resource group supplying powershell object parameters, get the policy assignment back and validate
            $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -PolicyParameterObject $param -Description $description -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

            # delete the policy assignment
            $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual True $remove
        } | Should -Not -Throw
    }

    It 'make policy assignment with parameters from a file' {
        {
            # assign the policy definition to the resource group supplying file parameters, get the policy assignment back and validate
            $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -PolicyParameter "$testFilesFolder\SamplePolicyAssignmentParameters.json" -Description $description -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]
        } | Should -Not -Throw
    }

    It 'update policy assignment parameters' {
        {
            # update parameters
            # this is validation for https://github.com/Azure/azure-powershell/issues/6055
            $actual = Set-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "something", "something else" ] } }' -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual "something" $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual "something else" $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

            # delete the policy assignment
            $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual True $remove
        } | Should -Not -Throw
    }

    It 'make policy assignment with hashtable of parameters' {
        {
            # assign the policy definition to the resource group supplying command line literal parameters, get the policy assignment back and validate
            $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }' -Description $description -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-NotNull $actual.Properties.Metadata
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

            # delete the policy assignment (commented out because next two tests are -Skip'd)
            #$remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            #Assert-AreEqual True $remove
        } | Should -Not -Throw
    }

    # This test is -Skip'd because dynamic parameters don't work in Pester 4.X + autorest-generated cmdlets (not sure about v5)
    # Note: this code works fine in a command shell or regular script
    It 'make policy assignment with dynamic parameters' -Skip {
        {
            # assign the policy definition to the resource group supplying Powershell parameters, get the policy assignment back and validate
            $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -listOfAllowedLocations $array -Description $description -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-NotNull $actual.Properties.Metadata
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

            # delete the policy assignment
            $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual True $remove
        } | Should -Not -Throw
    }

    # This test is -Skip'd because dynamic parameters don't work in Pester 4.X + autorest-generated cmdlets (not sure about v5)
    # Note: this code works fine in a command shell or regular script
    It 'make policy assignment overriding default dynamic parameter' -Skip {
        {
            # assign the policy definition to the resource group supplying Powershell parameters (including overriding a default value), get the policy assignment back and validate
            $actual = New-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyDefinition $policy -listOfAllowedLocations $array -effectParam "Disabled" -Description $description -Metadata $metadata -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-NotNull $actual.Properties.Metadata
            Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
            Assert-AreEqual "Disabled" $expected.Properties.Parameters.effectParam.Value
            Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]
        } | Should -Not -Throw
    }

    It 'update policy assignment description and metadata' {
        {
            # update the policy assignment (one with parameters and metadata), get it back and validate
            # this is validation for https://github.com/Azure/azure-powershell/issues/6055
            $newDescription = "$description - Updated"
            $newMetadata =  "{'Meta1': 'Value1', 'Meta2': { 'Meta22': 'Value22' }}"
            $actual = Set-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -Description $newDescription -Metadata $newMetadata -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]
            Assert-AreEqual $newDescription $expected.Properties.Description
            Assert-NotNull $expected.Properties.Metadata
            Assert-AreEqual 'Value1' $expected.Properties.Metadata.Meta1
            Assert-AreEqual 'Value22' $expected.Properties.Metadata.Meta2.Meta22
        } | Should -Not -Throw
    }

    It 'update policy assignment powershell object parameters' {
        {
            # update parameters
            # this is validation for https://msazure.visualstudio.com/One/_workitems/edit/4421756
            $array2 = @("West2 US2", "West2 US22")
            $param2 = @{"listOfAllowedLocations"=$array2}
            $actual = Set-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -PolicyParameterObject $param2 -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual $array2[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
            Assert-AreEqual $array2[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testPAWP -Scope $rgScope -BackwardCompatible
        $remove = (Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
