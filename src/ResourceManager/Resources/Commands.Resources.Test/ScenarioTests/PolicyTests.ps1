# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

$description = 'Unit test junk: sorry for littering. Please delete me!'
$updatedDescription = "Updated $description"
$metadataName = 'testName'
$metadataValue = 'testValue'
$metadata = "{'$metadataName':'$metadataValue'}"

$updatedMetadataName = 'newTestName'
$updatedMetadataValue = 'newTestValue'
$updatedMetadata = "{'$metadataName':'$metadataValue', '$updatedMetadataName': '$updatedMetadataValue'}"

$parameterDisplayName = 'List of locations'
$parameterDescription = 'An array of permitted locations for resources.'
$parameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$parameterDescription', 'strongType': 'location', 'displayName': '$parameterDisplayName' } } }"
$fullParameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$parameterDescription', 'strongType': 'location', 'displayName': '$parameterDisplayName' } }, 'effectParam': { 'type': 'string', 'defaultValue': 'deny' } }"

<#
.SYNOPSIS
Tests Policy definition CRUD operations
#>
function Test-PolicyDefinitionCRUD
{
    # setup
    $policyName = Get-ResourceName

    # make a policy definition, get it back and validate
    $expected = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed -Description $description
    $actual = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # update the same policy definition, get it back and validate the new properties
    $actual = Set-AzureRMPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy ".\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # make another policy definition, ensure both are present in listing
    New-AzureRMPolicyDefinition -Name test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
    $list = Get-AzureRMPolicyDefinition | ?{ $_.Name -in @($policyName, 'test2') }
    Assert-True { $list.Count -eq 2 }

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name 'test2' -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy definition CRUD operations
#>
function Test-PolicyDefinitionMode
{
    # setup
    $policyName = Get-ResourceName

    # make a policy definition with non-default mode, get it back and validate
    $expected = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode All -Description $description
    $actual = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing a different mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Indexed' $actual.Properties.Mode
    Assert-AreEqual 'Indexed' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    # repeat the same four tests at management group
    $managementGroup = 'AzGovTest8'

    # make a policy definition with non-default mode, get it back and validate
    $expected = New-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode All -Description $description
    $actual = Get-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing a different mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Indexed' $actual.Properties.Mode
    Assert-AreEqual 'Indexed' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -Force
    Assert-AreEqual True $remove

    # repeat the same four tests at subscription id
    $subscriptionId = 'e8a0d3c2-c26a-4363-ba6b-f56ac74c5ae0'  # AIMES Deployment Test

    # make a policy definition with non-default mode, get it back and validate
    $expected = New-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode All -Description $description
    $actual = Get-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing a different mode, get it back and validate
    $actual = Set-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Indexed' $actual.Properties.Mode
    Assert-AreEqual 'Indexed' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy definition with uri
#>
function Test-PolicyDefinitionWithUri
{
    # setup
    $policyName = Get-ResourceName

    # make a policy definition using a Uri to the policy rule, get it back and validate
    $actual = New-AzureRMPolicyDefinition -Name $policyName -Policy "https://raw.githubusercontent.com/vivsriaus/armtemplates/master/policyDef.json" -Mode All -Description $description
    $expected = Get-AzureRMPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy assignment CRUD operations
#>
function Test-PolicyAssignmentCRUD
{
    # setup
    $rgname = Get-ResourceGroupName
    $policyName = Get-ResourceName

    # make a new resource group and policy definition
    $rg = New-AzureRMResourceGroup -Name $rgname -Location "west us"
    $policy = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description

    # assign the policy definition to the resource group, get the assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description
    $expected = Get-AzureRMPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId

    # get it back by id and validate
    $actualId = Get-AzureRMPolicyAssignment -Id $actual.ResourceId
    Assert-AreEqual $actual.ResourceId $actualId.ResourceId

    # update the policy assignment, validate the result
    $set = Set-AzureRMPolicyAssignment -Id $actualId.ResourceId -DisplayName testDisplay
    Assert-AreEqual testDisplay $set.Properties.DisplayName

    # make another policy assignment, ensure both are present in resource group scope listing
    $expected = New-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description
    $list = Get-AzureRMPolicyAssignment -Scope $rg.ResourceId | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 2 @($list).Count

    # ensure both are present in full listing
    $list = Get-AzureRMPolicyAssignment -IncludeDescendent | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 2 @($list).Count

    # ensure neither are present in default listing (at subscription)
    $list = Get-AzureRMPolicyAssignment | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 0 @($list).Count

    # clean up
    $remove = Remove-AzureRMPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMResourceGroup -Name $rgname -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy assignment operations with a resource identity
#>
function Test-PolicyAssignmentIdentity
{
    # setup
    $rgname = Get-ResourceGroupName
    $policyName = Get-ResourceName
    $location = "westus"

    # make a new resource group and policy definition
    $rg = New-AzureRMResourceGroup -Name $rgname -Location $location
    $policy = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description

    # assign the policy definition to the resource group, get the assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description -AssignIdentity -Location $location
    $expected = Get-AzureRMPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual "SystemAssigned" $expected.Identity.Type
    Assert-NotNull($expected.Identity.PrincipalId)
    Assert-NotNull($expected.Identity.TenantId)
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual $expected.Location $actual.Location

    # get it back by id and validate
    $actualById = Get-AzureRMPolicyAssignment -Id $actual.ResourceId
    Assert-AreEqual $actual.ResourceId $actualById.ResourceId
    Assert-AreEqual "SystemAssigned" $actualById.Identity.Type
    Assert-NotNull($actualById.Identity.PrincipalId)
    Assert-NotNull($actualById.Identity.TenantId)
    Assert-AreEqual $location $actualById.Location

    # update the policy assignment, validate it still has an identity
    $setResult = Set-AzureRMPolicyAssignment -Id $actualById.ResourceId -DisplayName "testDisplay"
    Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
    Assert-AreEqual "SystemAssigned" $setResult.Identity.Type
    Assert-NotNull($setResult.Identity.PrincipalId)
    Assert-NotNull($setResult.Identity.TenantId)
    Assert-AreEqual $location $setResult.Location

    # make another policy assignment without an identity
    $withoutIdentityResult = New-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description
    Assert-Null($withoutIdentityResult.Identity)
    Assert-Null($withoutIdentityResult.Location)

    # add an identity to the new assignment using the SET cmdlet
    $setResult = Set-AzureRMPolicyAssignment -Id $withoutIdentityResult.ResourceId -AssignIdentity -Location $location
    Assert-AreEqual "SystemAssigned" $setResult.Identity.Type
    Assert-NotNull($setResult.Identity.PrincipalId)
    Assert-NotNull($setResult.Identity.TenantId)
    Assert-AreEqual $location $setResult.Location

    # verify identity is returned in collection GET
    $list = Get-AzureRMPolicyAssignment -Scope $rg.ResourceId | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual "SystemAssigned" ($list.Identity.Type | Select -Unique)
    Assert-AreEqual 2 @($list.Identity.PrincipalId | Select -Unique).Count
    Assert-AreEqual 1 @($list.Identity.TenantId | Select -Unique).Count
    Assert-NotNull($list.Identity.TenantId | Select -Unique)
    Assert-AreEqual $location ($list.Location | Select -Unique)

    # clean up
    $remove = Remove-AzureRMPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMResourceGroup -Name $rgname -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy set definition CRUD operations
#>
function Test-PolicySetDefinitionCRUD
{
    # setup
    $policySetDefName = Get-ResourceName
    $policyDefName = Get-ResourceName

    # make a policy definition and policy set definition that references it, get the policy set definition back and validate
    $policyDefinition = New-AzureRMPolicyDefinition -Name $policyDefName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzureRMPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata
    $actual = Get-AzureRMPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # update the policy set definition, get it back and validate
    $expected = Set-AzureRMPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription
    $actual = Get-AzureRMPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # get it from full listing and validate
    $actual = Get-AzureRMPolicySetDefinition | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # clean up
    $remove = Remove-AzureRMPolicySetDefinition -Name $policySetDefName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyDefName -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy definition creation with parameters
#>
function Test-PolicyDefinitionWithParameters
{
    # make a policy definition with parameters from a file, get it back and validate
    $actual = New-AzureRMPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json" -Description $description
    $expected = Get-AzureRMPolicyDefinition -Name testPDWP
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-NotNull($actual.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters.listOfAllowedLocations)
    Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
    Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
    Assert-NotNull($expected.Properties.Parameters.effectParam)
    Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
    Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type

    # delete the policy definition
    $remove = Remove-AzureRMPolicyDefinition -Name testPDWP -Force
    Assert-AreEqual True $remove

    # make a policy definition with parameters from the command line, get it back and validate
    $actual = New-AzureRMPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter $fullParameterDefinition -Description $description
    $expected = Get-AzureRMPolicyDefinition -Name testPDWP
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-NotNull($actual.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters.listOfAllowedLocations)
    Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
    Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
    Assert-NotNull($expected.Properties.Parameters.effectParam)
    Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
    Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type

    # delete the policy definition
    $remove = Remove-AzureRMPolicyDefinition -Name testPDWP -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy set definition creation and update with parameters
#>
function Test-PolicySetDefinitionWithParameters
{
    $policyDefName = Get-ResourceName
    $policySetDefName = Get-ResourceName

    # make a new policy definition with parameters
    $policyDefinition = New-AzureRmPolicyDefinition -Name $policyDefName -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Description $description -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"

    # make a new policy set definition with parameters using the policy definition
    $parameters = "{ 'listOfAllowedLocations': { 'value': ""[parameters('listOfAllowedLocations')]"" } }"
    $policySet = "[{'policyDefinitionId': '$($policyDefinition.PolicyDefinitionId)', 'parameters': $parameters}]"
    $expected = New-AzureRmPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Parameter $parameterDefinition
    $actual = Get-AzureRmPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $metadataValue $actual.Properties.metadata.testName
    Assert-AreEqual $parameterDescription $expected.Properties.Parameters.listOfAllowedLocations.metadata.description
    Assert-AreEqual $parameterDisplayName $expected.Properties.Parameters.listOfAllowedLocations.metadata.displayName

    # update the policy set definition to modify its parameter description and display name
    $updatedParameterDisplayName = 'Location Array'
    $updatedParameterDescription = 'Array of allowed resource locations.'
    $updatedParameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$updatedParameterDescription', 'strongType': 'location', 'displayName': '$updatedParameterDisplayName' } } }"
    $expected = Set-AzureRmPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $updatedDescription -Metadata $updatedMetadata -Parameter $updatedParameterDefinition
    $actual = Get-AzureRmPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $metadataValue $actual.Properties.metadata.testName
    Assert-AreEqual $updatedMetadataValue $actual.Properties.metadata.newTestName
    Assert-AreEqual $updatedParameterDescription $expected.Properties.Parameters.listOfAllowedLocations.metadata.description
    Assert-AreEqual $updatedParameterDisplayName $expected.Properties.Parameters.listOfAllowedLocations.metadata.displayName

    # clean up
    $remove = Remove-AzureRMPolicySetDefinition -Name $policySetDefName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyDefName -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy assignment creation with parameters
#>
function Test-PolicyAssignmentWithParameters
{
    # setup
    $rgname = Get-ResourceGroupName
    $policyName = Get-ResourceName

    # make a resource group and policy definition with parameters
    $rg = New-AzureRMResourceGroup -Name $rgname -Location "west us"
    $policy = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json" -Description $description
    $array = @("West US", "West US 2")
    $param = @{"listOfAllowedLocations"=$array}

    # assign the policy definition to the resource group supplying powershell object parameters, get the policy assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameterObject $param -Description $description
    $expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # delete the policy assignment
    $remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying file parameters, get the policy assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter "$TestOutputRoot\SamplePolicyAssignmentParameters.json" -Description $description
    $expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # delete the policy assignment
    $remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying command line literal parameters, get the policy assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }' -Description $description -Metadata $metadata
    $expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # delete the policy assignment
    $remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying Powershell parameters, get the policy assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -listOfAllowedLocations $array -Description $description -Metadata $metadata
    $expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # delete the policy assignment
    $remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying Powershell parameters (including overriding a default value), get the policy assignment back and validate
    $actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -listOfAllowedLocations $array -effectParam "Disabled" -Description $description -Metadata $metadata
    $expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual "Disabled" $expected.Properties.Parameters.effectParam.Value
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # update the policy assignment (one with parameters and metadata), get it back and validate
    # this is validation for https://github.com/Azure/azure-powershell/issues/6055
    $newDescription = "$description - Updated"
    $newMetadata =  "{'Meta1': 'Value1', 'Meta2': { 'Meta22': 'Value22' }}"
    $actual = Set-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -Description $newDescription -Metadata $newMetadata
    $expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]
    Assert-AreEqual $newDescription $expected.Properties.Description
    Assert-NotNull $expected.Properties.Metadata
    Assert-AreEqual 'Value1' $expected.Properties.Metadata.Meta1
    Assert-AreEqual 'Value22' $expected.Properties.Metadata.Meta2.Meta22

    # clean up
    $remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRmResourceGroup -Name $rgname -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy definition CRUD operations at management group level
#>
function Test-PolicyDefinitionCRUDAtManagementGroup
{
    # setup
    $policyName = Get-ResourceName
    $managementGroup = 'AzGovTest8'

    # make a policy definition, get it back and validate
    $expected = New-AzureRMPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed -Description $description
    $actual = Get-AzureRMPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # make sure it can't be retrieved at default subscription level
    Assert-ThrowsContains { Get-AzureRMPolicyDefinition -Name $policyName } "PolicyDefinitionNotFound : The policy definition '$policyName' could not be found."

    # update the same policy definition, get it back and validate the new properties
    $actual = Set-AzureRMPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription -Policy ".\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup 
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # make another policy definition, ensure both are present in listing
    New-AzureRMPolicyDefinition -Name test2 -ManagementGroupName $managementGroup -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
    $list = Get-AzureRMPolicyDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -in @($policyName, 'test2') }
    Assert-True { $list.Count -eq 2 }

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name 'test2' -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy definition CRUD operations at specified subscription level
#>
function Test-PolicyDefinitionCRUDAtSubscription
{
    # setup
    $policyName = Get-ResourceName
    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    # make a policy definition, get it back and validate
    $expected = New-AzureRMPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed -Description $description
    $actual = Get-AzureRMPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId 
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # update the same policy definition, get it back and validate the new properties
    $actual = Set-AzureRMPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription -Policy ".\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzureRMPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # make another policy definition, ensure both are present in listing
    New-AzureRMPolicyDefinition -Name test2 -SubscriptionId $subscriptionId -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
    $list = Get-AzureRMPolicyDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -in @($policyName, 'test2') }
    Assert-True { $list.Count -eq 2 }

    # clean up
    $remove = Remove-AzureRMPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name 'test2' -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy set definition CRUD operations at management group level
#>
function Test-PolicySetDefinitionCRUDAtManagementGroup
{
    # setup
    $policySetDefName = Get-ResourceName
    $policyDefName = Get-ResourceName
    $managementGroup = 'AzGovTest8'

    # make a policy definition and policy set definition that references it, get the policy set definition back and validate
    $policyDefinition = New-AzureRMPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzureRMPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -PolicyDefinition $policySet -Description $description
    $actual = Get-AzureRMPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)

    # make sure it can't be retrieved at default subscription level
    Assert-ThrowsContains { Get-AzureRMPolicySetDefinition -Name $policySetDefName } "PolicySetDefinitionNotFound : The policy set definition '$policySetDefName' could not be found."

    # update the policy set definition, get it back and validate
    $expected = Set-AzureRMPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription
    $actual = Get-AzureRMPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # get it from full listing and validate
    $actual = Get-AzureRMPolicySetDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # clean up
    $remove = Remove-AzureRMPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy set definition CRUD operations at specified subscription level
#>
function Test-PolicySetDefinitionCRUDAtSubscription
{
    # setup
    $policySetDefName = Get-ResourceName
    $policyDefName = Get-ResourceName
    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    # make a policy definition and policy set definition that references it, get the policy set definition back and validate
    $policyDefinition = New-AzureRMPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzureRMPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description
    $actual = Get-AzureRMPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)

    # update the policy set definition, get it back and validate
    $expected = Set-AzureRMPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription
    $actual = Get-AzureRMPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # get it from full listing and validate
    $actual = Get-AzureRMPolicySetDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # clean up
    $remove = Remove-AzureRMPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzureRMPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove
}

<#
The following section contains tests for each cmdlet that validate as many combinations of
parameters as possible/reasonable. Tests for all combinations of parameters are present here
except for:

 1. Any test for parameter combinations that would result in a prompt for a required
    parameter or for confirmation must be omitted, since the framework can't handle tests
    that prompt for user input.
 2. If there is a test of a parameter combination that expects a parameter set error,
    then no similar tests with additional parameters are necessary, since a given set of
    parameters that fail to resolve to a parameter set can never be resolved by adding 
    additional parameters.
 3. Combinations involving parameters that are not part of any parameter set are also omitted,
    not because they are entirely unworthy of separate tests, but simply as a design decision
    trading off overall tractability and value of the test suite.
#>

# parameter values
$someName = 'someName'
$someScope = 'someScope'
$someId = 'someId'
$someManagementGroup = 'someManagementGroup'
$someJsonSnippet = "{ 'someThing': 'someOtherThing' }"
$someJsonArray = "[$someJsonSnippet]"
$somePolicyDefinition = 'somePolicyDefinition'
$somePolicySetDefinition = 'somePolicySetDefinition'
$somePolicyParameter = 'somePolicyParameter'
$someParameterObject = @{'parm1'='a'; 'parm2'='b' }

# exception strings
$parameterSetError = 'Parameter set cannot be resolved using the specified named parameters.'
$missingParameters = 'Cannot process command because of one or more missing mandatory parameters:'
$onlyDefinitionOrSetDefinition = 'Only one of PolicyDefinition or PolicySetDefinition can be specified, not both.'
$policyAssignmentNotFound = 'PolicyAssignmentNotFound : '
$policySetDefinitionNotFound = 'PolicySetDefinitionNotFound : '
$policyDefinitionNotFound = 'PolicyDefinitionNotFound : '
$invalidRequestContent = 'InvalidRequestContent : The request content was invalid and could not be deserialized: '
$missingSubscription = 'MissingSubscription : The request did not have a provided subscription. All requests must have an associated subscription Id.'
$undefinedPolicyParameter = 'UndefinedPolicyParameter : The policy assignment'
$invalidPolicyRule = 'InvalidPolicyRule : Failed to parse policy rule: '
$authorizationFailed = 'AuthorizationFailed : '
$allSwitchNotSupported = 'The -IncludeDescendent switch is not supported for management group scopes.'
$httpMethodNotSupported = "HttpMethodNotSupported : The http method 'DELETE' is not supported for a resource collection."

<#
.SYNOPSIS
Tests Get-AzureRmPolicyAssignment parameter combinations
#>
function Test-GetPolicyAssignmentParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $mgScope = "/providers/Microsoft.Management/managementGroups/$someManagementGroup"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"

    # validate with no parameters
    $ok = Get-AzureRmPolicyAssignment

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -Scope $goodScope } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -PolicyDefinitionId $someId } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -IncludeDescendent } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinitionId $someId } $missingSubscription
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Name $someName -Scope $someScope -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -Scope
    $ok = Get-AzureRmPolicyAssignment -Scope $goodScope
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError
    $ok = Get-AzureRmPolicyAssignment -Scope $goodScope -PolicyDefinitionId $someId
    Assert-AreEqual 0 $ok.Count
    $ok = Get-AzureRmPolicyAssignment -Scope $goodScope -IncludeDescendent
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Scope $mgScope -IncludeDescendent } $allSwitchNotSupported
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Scope $someScope -PolicyDefinitionId $someId -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Id $goodId } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Id $someId -PolicyDefinitionId $someId } $missingSubscription
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -Id $someId -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -PolicyDefinitionId
    $ok = Get-AzureRmPolicyAssignment -PolicyDefinitionId $someId
    Assert-AreEqual 0 $ok.Count
    Assert-ThrowsContains { Get-AzureRmPolicyAssignment -PolicyDefinitionId $someId -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -IncludeDescendent
    $ok = Get-AzureRmPolicyAssignment -IncludeDescendent
}

<#
.SYNOPSIS
Tests New-AzureRmPolicyAssignment parameter combinations
#>
function Test-NewPolicyAssignmentParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodPolicyDefinition = Get-AzureRmPolicyDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
    $goodPolicySetDefinition = Get-AzureRmPolicySetDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
    $wrongParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'

    # validate with no parameters
    Assert-ThrowsContains { New-AzureRmPolicyAssignment } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName } $missingParameters
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $goodScope } $invalidRequestContent
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition } $missingSubscription
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicySetDefinition $goodPolicySetDefinition } $onlyDefinitionOrSetDefinition
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject } $undefinedPolicyParameter
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameter $wrongParameters } $undefinedPolicyParameter
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter } $parameterSetError
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter } $parameterSetError
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject } $parameterSetError
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $somePolicyParameter } $parameterSetError

    # validate parameter combinations starting with -Scope
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Scope $someScope } $missingParameters
}

<#
.SYNOPSIS
Tests Remove-AzureRmPolicyAssignment parameter combinations
#>
function Test-RemovePolicyAssignmentParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
    $goodObject = Get-AzureRmPolicyAssignment | ?{ $_.Name -like '*test*' -or $_.Properties.Description -like '*test*' } | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Remove-AzureRmPolicyAssignment } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName } $missingParameters
    $ok = Remove-AzureRmPolicyAssignment -Name $someName -Scope $goodScope
    Assert-AreEqual True $ok
    Assert-ThrowsContains { Remove-AzureRmPolicyAssignment -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Remove-AzureRmPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError

    # validate remaining parameter combinations starting with -Scope
    Assert-ThrowsContains { Remove-AzureRmPolicyAssignment -Scope $someScope } $missingParameters
    Assert-ThrowsContains { Remove-AzureRmPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    $ok = Remove-AzureRmPolicyAssignment -Id $goodId
    Assert-AreEqual True $ok
}

<#
.SYNOPSIS
Tests Set-AzureRmPolicyAssignment parameter combinations
#>
function Test-SetPolicyAssignmentParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
    $goodObject = Get-AzureRmPolicyAssignment | ?{ $_.Name -like '*test*' -or $_.Properties.Description -like '*test*' } | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzureRmPolicyAssignment -Name $someName } $missingParameters
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment -Name $someName -Scope $goodScope } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError

    # validate remaining parameter combinations starting with -Scope
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment -Scope $someScope } $missingParameters
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    Assert-ThrowsContains { Set-AzureRmPolicyAssignment -Id $goodId } $policyAssignmentNotFound
}

<#
.SYNOPSIS
Tests Get-AzureRmPolicyDefinition parameter combinations
#>
function Test-GetPolicyDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"

    # validate with no parameters
    $ok = Get-AzureRmPolicyDefinition

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -SubscriptionId $subscriptionId } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Builtin } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Custom } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Id $someId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Name $someName -Id $someId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Id $goodId } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Id $goodId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Id $goodId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -Id $goodId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -ManagementGroup
    $ok = Get-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
    $ok = Get-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn
    $ok = Get-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup -Custom
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -SubscriptionId
    $ok = Get-AzureRmPolicyDefinition -SubscriptionId $subscriptionId
    $ok = Get-AzureRmPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn
    $ok = Get-AzureRmPolicyDefinition -SubscriptionId $subscriptionId -Custom
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -BuiltIn
    $ok = Get-AzureRmPolicyDefinition -BuiltIn
    Assert-ThrowsContains { Get-AzureRmPolicyDefinition -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Custom
    $ok = Get-AzureRmPolicyDefinition -Custom
}

<#
.SYNOPSIS
Tests New-AzureRmPolicyDefinition parameter combinations
#>
function Test-NewPolicyDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    # validate with no parameters
    Assert-ThrowsContains { New-AzureRmPolicyDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzureRmPolicyDefinition -Name $someName } $missingParameters
    Assert-ThrowsContains { New-AzureRmPolicyDefinition -Name $someName -Policy $someJsonSnippet } $invalidPolicyRule
    Assert-ThrowsContains { New-AzureRmPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup } $authorizationFailed
    Assert-ThrowsContains { New-AzureRmPolicyDefinition -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId } $invalidPolicyRule
    Assert-ThrowsContains { New-AzureRmPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate remaining parameter combinations starting with -Policy
    Assert-ThrowsContains { New-AzureRmPolicyDefinition -Policy $someJsonSnippet } $missingParameters
}

<#
.SYNOPSIS
Tests Remove-AzureRmPolicyDefinition parameter combinations
#>
function Test-RemovePolicyDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    $goodManagementGroup = 'AzGovTest8'
    $goodObject = Get-AzureRmPolicyDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Remove-AzureRmPolicyDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Remove-AzureRmPolicyDefinition -Name $someName -Id $someId } $parameterSetError
    $ok = Remove-AzureRmPolicyDefinition -Name $someName -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzureRmPolicyDefinition -Name $someName -ManagementGroupName $goodManagementGroup -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzureRmPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $ok

    # validate parameter combinations starting with -Id
    $ok = Remove-AzureRmPolicyDefinition -Id $goodId -Force
    Assert-AreEqual True $ok
    Assert-ThrowsContains { Remove-AzureRmPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Remove-AzureRmPolicyDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Remove-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Remove-AzureRmPolicyDefinition -SubscriptionId $subscriptionId -Force } $missingParameters
}

<#
.SYNOPSIS
Tests Set-AzureRmPolicyDefinition parameter combinations
#>
function Test-SetPolicyDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    $goodObject = Get-AzureRmPolicyDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Name $someName } $policyDefinitionNotFound
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policyDefinitionNotFound
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Name $someName -SubscriptionId $subscriptionId } $policyDefinitionNotFound

    # validate parameter combinations starting with -Id
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Id $goodId } $policyDefinitionNotFound
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup } $missingParameters
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Set-AzureRmPolicyDefinition -SubscriptionId $subscriptionId } $missingParameters
}

<#
.SYNOPSIS
Tests Get-AzureRmPolicySetDefinition parameter combinations
#>
function Test-GetPolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"

    # validate with no parameters
    $ok = Get-AzureRmPolicySetDefinition

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Builtin } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Custom } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Id $someId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Name $someName -Id $someId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Id $goodId } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Id $goodId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Id $goodId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -Id $goodId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -ManagementGroup
    $ok = Get-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
    $ok = Get-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn
    $ok = Get-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup -Custom
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -SubscriptionId
    $ok = Get-AzureRmPolicySetDefinition -SubscriptionId $subscriptionId
    $ok = Get-AzureRmPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn
    $ok = Get-AzureRmPolicySetDefinition -SubscriptionId $subscriptionId -Custom
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -BuiltIn
    $ok = Get-AzureRmPolicySetDefinition -BuiltIn
    Assert-ThrowsContains { Get-AzureRmPolicySetDefinition -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Custom
    $ok = Get-AzureRmPolicySetDefinition -Custom
}

<#
.SYNOPSIS
Tests New-AzureRmPolicySetDefinition parameter combinations
#>
function Test-NewPolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    # validate with no parameters
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition -Name $someName } $missingParameters
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray } $invalidRequestContent
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup } $authorizationFailed
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId } $invalidRequestContent
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate remaining parameter combinations starting with -PolicyDefinition
    Assert-ThrowsContains { New-AzureRmPolicySetDefinition -PolicyDefinition $someJsonArray } $missingParameters
}

<#
.SYNOPSIS
Tests Remove-AzureRmPolicySetDefinition parameter combinations
#>
function Test-RemovePolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    $goodManagementGroup = 'AzGovTest8'
    $goodObject = Get-AzureRmPolicySetDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Remove-AzureRmPolicySetDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Remove-AzureRmPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
    $ok = Remove-AzureRmPolicySetDefinition -Name $someName -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzureRmPolicySetDefinition -Name $someName -ManagementGroupName $goodManagementGroup -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzureRmPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $ok

    # validate parameter combinations starting with -Id
    $ok = Remove-AzureRmPolicySetDefinition -Id $goodId -Force
    Assert-AreEqual True $ok
    Assert-ThrowsContains { Remove-AzureRmPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Remove-AzureRmPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Remove-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Remove-AzureRmPolicySetDefinition -SubscriptionId $subscriptionId -Force } $httpMethodNotSupported
}

<#
.SYNOPSIS
Tests Set-AzureRmPolicySetDefinition parameter combinations
#>
function Test-SetPolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    $goodObject = Get-AzureRmPolicySetDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Name $someName } $policySetDefinitionNotFound
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policySetDefinitionNotFound
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId } $policySetDefinitionNotFound

    # validate parameter combinations starting with -Id
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Id $goodId } $policySetDefinitionNotFound
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup } $missingParameters
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Set-AzureRmPolicySetDefinition -SubscriptionId $subscriptionId } $missingParameters
}
