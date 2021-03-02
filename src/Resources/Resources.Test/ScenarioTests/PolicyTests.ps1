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

$managementGroup = 'AzGovPerfTest'
$description = 'Unit test junk: sorry for littering. Please delete me!'
$updatedDescription = "Updated $description"
$metadataName = 'testName'
$metadataValue = 'testValue'
$metadata = "{'$metadataName':'$metadataValue'}"
$enforcementModeDefault = 'Default'
$enforcementModeDoNotEnforce = 'DoNotEnforce'

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
    $expected = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed -Description $description
    $actual = Get-AzPolicyDefinition -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # update the same policy definition, get it back and validate the new properties
    $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy ".\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # make another policy definition, ensure both are present in listing
    New-AzPolicyDefinition -Name test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
    $list = Get-AzPolicyDefinition | ?{ $_.Name -in @($policyName, 'test2') }
    Assert-True { $list.Count -eq 2 }

    # ensure that only custom definitions are returned using the custom flag
    $list = Get-AzPolicyDefinition -Custom
    Assert-True { $list.Count -gt 0 }
    $builtIns = $list | Where-Object { $_.Properties.policyType -ieq 'BuiltIn' }
    Assert-True { $builtIns.Count -eq 0 }

    # make a policy definition from export format, get it back and validate
    $expected = New-AzPolicyDefinition -Name test3 -Policy "$TestOutputRoot\SamplePolicyDefinitionFromExport.json" -Description $description
    $actual = Get-AzPolicyDefinition -Name test3
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # clean up
    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name 'test2' -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name 'test3' -Force
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
    $expected = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode All -Description $description
    $actual = Get-AzPolicyDefinition -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing a different mode, get it back and validate
    $actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Indexed' $actual.Properties.Mode
    Assert-AreEqual 'Indexed' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    # repeat the same four tests at management group
    # make a policy definition with non-default mode, get it back and validate
    $expected = New-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode All -Description $description
    $actual = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing a different mode, get it back and validate
    $actual = Set-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Indexed' $actual.Properties.Mode
    Assert-AreEqual 'Indexed' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzPolicyDefinition -ManagementGroupName $managementGroup -Name $policyName -Force
    Assert-AreEqual True $remove

    # repeat the same four tests at subscription id
    $subscriptionId = $subscriptionId = (Get-AzContext).Subscription.Id

    # make a policy definition with non-default mode, get it back and validate
    $expected = New-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode All -Description $description
    $actual = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Mode 'All' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'All' $actual.Properties.Mode
    Assert-AreEqual 'All' $expected.Properties.Mode

    # update the same policy definition explicitly providing a different mode, get it back and validate
    $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Mode 'Indexed' -Description $updatedDescription -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Indexed' $actual.Properties.Mode
    Assert-AreEqual 'Indexed' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -Force
    Assert-AreEqual True $remove

    # test policy with data plane mode
    # make a policy definition with data plane mode, get it back and validate
    $expected = New-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -Policy "$TestOutputRoot\SampleDataCatalogDataPolicyDefinition.json" -Mode 'Microsoft.DataCatalog.Data' -Description $description
    $actual = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual 'Microsoft.DataCatalog.Data' $actual.Properties.Mode
    Assert-AreEqual 'Microsoft.DataCatalog.Data' $expected.Properties.Mode

    # update the same policy definition without touching mode, get it back and validate
    $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Description $updatedDescription -Policy "$TestOutputRoot\SampleDataCatalogDataPolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Microsoft.DataCatalog.Data' $actual.Properties.Mode
    Assert-AreEqual 'Microsoft.DataCatalog.Data' $expected.Properties.Mode

    # update the same policy definition explicitly providing the same mode, get it back and validate
    $actual = Set-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -DisplayName testDisplay -Mode 'Microsoft.DataCatalog.Data' -Description $updatedDescription -Policy "$TestOutputRoot\SampleDataCatalogDataPolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-AreEqual 'Microsoft.DataCatalog.Data' $actual.Properties.Mode
    Assert-AreEqual 'Microsoft.DataCatalog.Data' $expected.Properties.Mode

    # clean up
    $remove = Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Name $policyName -Force
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
    $actual = New-AzPolicyDefinition -Name $policyName -Policy "https://raw.githubusercontent.com/vivsriaus/armtemplates/master/policyDef.json" -Mode All -Description $description
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # clean up
    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy definition with full policy definition object
#>
function Test-PolicyDefinitionWithFullObject
{
    # setup
    $policyName = Get-ResourceName

    # make a policy definition using the full policy object (from a file), get it back and validate
    $actual = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionObject.json"
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # delete it
    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    # verify that description, displayname, mode, metadata, and parameters correctly overload what's in the object
    $actual = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionObject.json" -DisplayName testDisplay -Description $description -Mode Indexed -Metadata $metadata -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.DisplayName testDisplay
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-AreEqual $expected.Properties.Description $description
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
    Assert-AreEqual $expected.Properties.Mode Indexed
    Assert-NotNull($actual.Properties.Metadata)
    Assert-NotNull($expected.Properties.Metadata)
    Assert-AreEqual $expected.Properties.Metadata.$metadataName $actual.Properties.Metadata.$metadataName
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName
    Assert-NotNull($actual.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters.listOfAllowedLocations)
    Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
    Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
    Assert-NotNull($expected.Properties.Parameters.effectParam)
    Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
    Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type

    # delete it
    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    # now create a basic policy, update with Set-AzPolicyDefinition using full object, and validate
    New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json"
    $actual = Set-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionObject.json"
    $expected = Get-AzPolicyDefinition -Name $policyName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.DisplayName 'Fake Test policy'
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-AreEqual $expected.Properties.Description 'Sample fake test policy for unit tests.'
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode
    Assert-AreEqual $expected.Properties.Mode All
    Assert-NotNull($actual.Properties.Metadata)
    Assert-NotNull($expected.Properties.Metadata)
    Assert-AreEqual $expected.Properties.Metadata.category $actual.Properties.Metadata.category
    Assert-AreEqual $expected.Properties.Metadata.category 'Unit Test'
    Assert-NotNull($actual.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters)
    Assert-NotNull($expected.Properties.Parameters.listOfAllowedLocations)
    Assert-AreEqual "array" $expected.Properties.Parameters.listOfAllowedLocations.type
    Assert-AreEqual "location" $expected.Properties.Parameters.listOfAllowedLocations.metadata.strongType
    Assert-NotNull($expected.Properties.Parameters.effectParam)
    Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.defaultValue
    Assert-AreEqual "string" $expected.Properties.Parameters.effectParam.type

    # clean up
    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
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
    $rg = New-AzResourceGroup -Name $rgname -Location "west us"
    $policy = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description

    # assign the policy definition to the resource group, get the assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description
    $expected = Get-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId

    # get it back by id and validate
    $actualId = Get-AzPolicyAssignment -Id $actual.ResourceId
    Assert-AreEqual $actual.ResourceId $actualId.ResourceId

    # update the policy assignment, validate the result
    $set = Set-AzPolicyAssignment -Id $actualId.ResourceId -DisplayName testDisplay
    Assert-AreEqual testDisplay $set.Properties.DisplayName

    # make another policy assignment, ensure both are present in resource group scope listing
    $expected = New-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description
    $list = Get-AzPolicyAssignment -Scope $rg.ResourceId | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 2 @($list).Count

    # ensure both are present in full listing
    $list = Get-AzPolicyAssignment -IncludeDescendent | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 2 @($list).Count

    # ensure neither are present in default listing (at subscription)
    $list = Get-AzPolicyAssignment | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 0 @($list).Count

    # clean up
    $remove = Remove-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzResourceGroup -Name $rgname -Force
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
    $rg = New-AzResourceGroup -Name $rgname -Location $location
    $policy = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description

    # assign the policy definition to the resource group, get the assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description -AssignIdentity -Location $location
    $expected = Get-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId
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
    $actualById = Get-AzPolicyAssignment -Id $actual.ResourceId
    Assert-AreEqual $actual.ResourceId $actualById.ResourceId
    Assert-AreEqual "SystemAssigned" $actualById.Identity.Type
    Assert-NotNull($actualById.Identity.PrincipalId)
    Assert-NotNull($actualById.Identity.TenantId)
    Assert-AreEqual $location $actualById.Location

    # update the policy assignment, validate it still has an identity
    $setResult = Set-AzPolicyAssignment -Id $actualById.ResourceId -DisplayName "testDisplay"
    Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
    Assert-AreEqual "SystemAssigned" $setResult.Identity.Type
    Assert-NotNull($setResult.Identity.PrincipalId)
    Assert-NotNull($setResult.Identity.TenantId)
    Assert-AreEqual $location $setResult.Location

    # make another policy assignment without an identity
    $withoutIdentityResult = New-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description
    Assert-Null($withoutIdentityResult.Identity)
    Assert-Null($withoutIdentityResult.Location)

    # add an identity to the new assignment using the SET cmdlet
    $setResult = Set-AzPolicyAssignment -Id $withoutIdentityResult.ResourceId -AssignIdentity -Location $location
    Assert-AreEqual "SystemAssigned" $setResult.Identity.Type
    Assert-NotNull($setResult.Identity.PrincipalId)
    Assert-NotNull($setResult.Identity.TenantId)
    Assert-AreEqual $location $setResult.Location

    # verify identity is returned in collection GET
    $list = Get-AzPolicyAssignment -Scope $rg.ResourceId | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual "SystemAssigned" ($list.Identity.Type | Select -Unique)
    Assert-AreEqual 2 @($list.Identity.PrincipalId | Select -Unique).Count
    Assert-AreEqual 1 @($list.Identity.TenantId | Select -Unique).Count
    Assert-NotNull($list.Identity.TenantId | Select -Unique)
    Assert-AreEqual $location ($list.Location | Select -Unique)

    # clean up
    $remove = Remove-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzResourceGroup -Name $rgname -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy assignment CRUD operations with an enforcement mode property
#>
function Test-PolicyAssignmentEnforcementMode
{
    # setup
    $rgname = Get-ResourceGroupName
    $policyName = Get-ResourceName
    $location = "westus"

    # make a new resource group and policy definition
    $rg = New-AzResourceGroup -Name $rgname -Location $location
    $policy = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description

    # assign the policy definition to the resource group, get the assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description -Location $location -EnforcementMode DoNotEnforce
    $expected = Get-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $expected.Properties.EnforcementMode $actual.Properties.EnforcementMode
	Assert-AreEqual $expected.Properties.EnforcementMode $enforcementModeDoNotEnforce
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual $expected.Location $actual.Location

    # get it back by id and validate
    $actualById = Get-AzPolicyAssignment -Id $actual.ResourceId
    Assert-AreEqual $actual.Properties.EnforcementMode $actualById.Properties.EnforcementMode

	# update the policy assignment, validate enforcement mode is updated correctly with Default enum value.
    $setResult = Set-AzPolicyAssignment -Id $actualById.ResourceId -DisplayName "testDisplay" -EnforcementMode Default
    Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
    Assert-AreEqual $enforcementModeDefault $setResult.Properties.EnforcementMode

    # update the policy assignment, validate enforcement mode is updated correctly with 'Default' enum as string value.
    $setResult = Set-AzPolicyAssignment -Id $actualById.ResourceId -DisplayName "testDisplay" -EnforcementMode $enforcementModeDefault
    Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
    Assert-AreEqual $enforcementModeDefault $setResult.Properties.EnforcementMode

    # make another policy assignment without an enforcementMode, validate default mode is set
    $withoutEnforcementMode = New-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description
    Assert-AreEqual $enforcementModeDefault $withoutEnforcementMode.Properties.EnforcementMode

    # set an enforcement mode to the new assignment using the SET cmdlet
    $setResult = Set-AzPolicyAssignment -Id $withoutEnforcementMode.ResourceId -Location $location -EnforcementMode $enforcementModeDoNotEnforce
    Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode

	# set an enforcement mode to the new assignment using the SET cmdlet enum value and validate
    $setResult = Set-AzPolicyAssignment -Id $withoutEnforcementMode.ResourceId -Location $location -EnforcementMode DoNotEnforce
    Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode

    # verify enforcement mode is returned in collection GET
    $list = Get-AzPolicyAssignment -Scope $rg.ResourceId | ?{ $_.Name -in @('testPA', 'test2') }
    Assert-AreEqual 2 @($list.Properties.EnforcementMode | Select -Unique).Count

    # clean up
    $remove = Remove-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzResourceGroup -Name $rgname -Force
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
    $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-NotNull($actual.Properties.Metadata)
	Assert-Null($actual.Properties.PolicyDefinitionGroups)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # update the policy set definition, get it back and validate
    $expected = Set-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
	Assert-Null($actual.Properties.PolicyDefinitionGroups)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # get it from full listing and validate
    $actual = Get-AzPolicySetDefinition | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
	Assert-Null($actual.Properties.PolicyDefinitionGroups)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # ensure that only custom set definitions are returned using the custom flag
    $list = Get-AzPolicySetDefinition -Custom
    Assert-True { $list.Count -gt 0 }
    $builtIns = $list | Where-Object { $_.Properties.policyType -ieq 'BuiltIn' }
    Assert-True { $builtIns.Count -eq 0 }

    # clean up
    $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyDefName -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy set definition CRUD operations on a policy set containing groups
#>
function Test-PolicySetDefinitionCRUDWithGroups
{
    # setup
    $policySetDefName = Get-ResourceName
    $policyDefName = Get-ResourceName

    # make a policy definition and policy set definition that references it, get the policy set definition back and validate
    $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """, 'groupNames': [ 'group2' ] }]"
    $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -GroupDefinition "[{ 'name': 'group1' }, { 'name': 'group2' }]"
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
	Assert-AreEqual "group2" $actual.Properties.PolicyDefinitions.GroupNames
    Assert-NotNull($actual.Properties.Metadata)
	Assert-AreEqual 2 @($expected.Properties.PolicyDefinitionGroups).Count
	Assert-AreEqual 2 @($actual.Properties.PolicyDefinitionGroups).Count
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # update the policy set definition, get it back and validate
    $expected = Set-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description $updatedDescription -GroupDefinition "[{ 'name': 'group2' }]"
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
	Assert-AreEqual "group2" $actual.Properties.PolicyDefinitions.GroupNames
	Assert-AreEqual 1 @($expected.Properties.PolicyDefinitionGroups).Count
	Assert-AreEqual 1 @($actual.Properties.PolicyDefinitionGroups).Count
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # get it from full listing and validate
    $actual = Get-AzPolicySetDefinition | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
	Assert-AreEqual "group2" $actual.Properties.PolicyDefinitions.GroupNames
	Assert-AreEqual 1 @($actual.Properties.PolicyDefinitionGroups).Count
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # clean up
    $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyDefName -Force
    Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy definition creation with parameters
#>
function Test-PolicyDefinitionWithParameters
{
    # make a policy definition with parameters from a file, get it back and validate
    $actual = New-AzPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json" -Description $description
    $expected = Get-AzPolicyDefinition -Name testPDWP
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
    $remove = Remove-AzPolicyDefinition -Name testPDWP -Force
    Assert-AreEqual True $remove

    # make a policy definition with parameters from the command line, get it back and validate
    $actual = New-AzPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter $fullParameterDefinition -Description $description
    $expected = Get-AzPolicyDefinition -Name testPDWP
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
    $remove = Remove-AzPolicyDefinition -Name testPDWP -Force
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
    $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Description $description -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"

    # make a new policy set definition with parameters using the policy definition
    $parameters = "{ 'listOfAllowedLocations': { 'value': ""[parameters('listOfAllowedLocations')]"" } }"
    $policySet = "[{'policyDefinitionId': '$($policyDefinition.PolicyDefinitionId)', 'parameters': $parameters}]"
    $expected = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $description -Metadata $metadata -Parameter $parameterDefinition
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $metadataValue $actual.Properties.metadata.testName
    Assert-AreEqual $parameterDescription $expected.Properties.Parameters.listOfAllowedLocations.metadata.description
    Assert-AreEqual $parameterDisplayName $expected.Properties.Parameters.listOfAllowedLocations.metadata.displayName

    # update the policy set definition to modify its parameter description and display name
    $updatedParameterDisplayName = 'Location Array'
    $updatedParameterDescription = 'Array of allowed resource locations.'
    $updatedParameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$updatedParameterDescription', 'strongType': 'location', 'displayName': '$updatedParameterDisplayName' } } }"
    $expected = Set-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet -Description $updatedDescription -Metadata $updatedMetadata -Parameter $updatedParameterDefinition
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $metadataValue $actual.Properties.metadata.testName
    Assert-AreEqual $updatedMetadataValue $actual.Properties.metadata.newTestName
    Assert-AreEqual $updatedParameterDescription $expected.Properties.Parameters.listOfAllowedLocations.metadata.description
    Assert-AreEqual $updatedParameterDisplayName $expected.Properties.Parameters.listOfAllowedLocations.metadata.displayName

    # clean up
    $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyDefName -Force
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
    $rg = New-AzResourceGroup -Name $rgname -Location "west us"
    $policy = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json" -Description $description
    $array = @("West US", "West US 2")
    $param = @{"listOfAllowedLocations"=$array}

    # assign the policy definition to the resource group supplying powershell object parameters, get the policy assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameterObject $param -Description $description
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # delete the policy assignment
    $remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying file parameters, get the policy assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter "$TestOutputRoot\SamplePolicyAssignmentParameters.json" -Description $description
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $array[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

	# update parameters
    # this is validation for https://github.com/Azure/azure-powershell/issues/6055
    $actual = Set-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "something", "something else" ] } }'
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual "something" $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual "something else" $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # delete the policy assignment
    $remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying command line literal parameters, get the policy assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }' -Description $description -Metadata $metadata
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
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
    $remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying Powershell parameters, get the policy assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -listOfAllowedLocations $array -Description $description -Metadata $metadata
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
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
    $remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    # assign the policy definition to the resource group supplying Powershell parameters (including overriding a default value), get the policy assignment back and validate
    $actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -listOfAllowedLocations $array -effectParam "Disabled" -Description $description -Metadata $metadata
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
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
    $actual = Set-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -Description $newDescription -Metadata $newMetadata
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
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

	# update parameters
	# this is validation for https://msazure.visualstudio.com/One/_workitems/edit/4421756
    $array2 = @("West2 US2", "West2 US22")
    $param2 = @{"listOfAllowedLocations"=$array2}
    $actual = Set-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyParameterObject $param2
    $expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $array2[0] $expected.Properties.Parameters.listOfAllowedLocations.Value[0]
    Assert-AreEqual $array2[1] $expected.Properties.Parameters.listOfAllowedLocations.Value[1]

    # clean up
    $remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyName -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzResourceGroup -Name $rgname -Force
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

    # make a policy definition, get it back and validate
    $expected = New-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed -Description $description
    $actual = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # update the same policy definition, get it back and validate the new properties
    $actual = Set-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription -Policy ".\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # make another policy definition, ensure both are present in listing
    New-AzPolicyDefinition -Name test2 -ManagementGroupName $managementGroup -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
    $list = Get-AzPolicyDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -in @($policyName, 'test2') }
    Assert-True { $list.Count -eq 2 }

    # clean up
    $remove = Remove-AzPolicyDefinition -Name $policyName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name 'test2' -ManagementGroupName $managementGroup -Force
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
    $subscriptionId = (Get-AzContext).Subscription.Id

    # make a policy definition, get it back and validate
    $expected = New-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed -Description $description
    $actual = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId
    Assert-NotNull $actual
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
    Assert-NotNull($actual.Properties.PolicyRule)
    Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

    # update the same policy definition, get it back and validate the new properties
    $actual = Set-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription -Policy ".\SamplePolicyDefinition.json" -Metadata $metadata
    $expected = Get-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
    Assert-NotNull($actual.Properties.Metadata)
    Assert-AreEqual $metadataValue $actual.Properties.Metadata.$metadataName

    # make another policy definition, ensure both are present in listing
    New-AzPolicyDefinition -Name test2 -SubscriptionId $subscriptionId -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}" -Description $description
    $list = Get-AzPolicyDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -in @($policyName, 'test2') }
    Assert-True { $list.Count -eq 2 }

    # clean up
    $remove = Remove-AzPolicyDefinition -Name $policyName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name 'test2' -SubscriptionId $subscriptionId -Force
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

    # make a policy definition and policy set definition that references it, get the policy set definition back and validate
    $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -PolicyDefinition $policySet -Description $description
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)

    # update the policy set definition, get it back and validate
    $expected = Set-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -DisplayName testDisplay -Description $updatedDescription
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # get it from full listing and validate
    $actual = Get-AzPolicySetDefinition -ManagementGroupName $managementGroup | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # clean up
    $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyDefName -ManagementGroupName $managementGroup -Force
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
    $subscriptionId = (Get-AzContext).Subscription.Id

    # make a policy definition and policy set definition that references it, get the policy set definition back and validate
    $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)

    # update the policy set definition, get it back and validate
    $expected = Set-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -DisplayName testDisplay -Description $updatedDescription
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # get it from full listing and validate
    $actual = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId | ?{ $_.Name -eq $policySetDefName }
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
    Assert-NotNull($actual.Properties.PolicyDefinitions)
    Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
    Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

    # clean up
    $remove = Remove-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove

    $remove = Remove-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $remove
}

function Test-GetCmdletFilterParameter
{
    # policy definitions
    $builtins = Get-AzureRmPolicyDefinition -Builtin
    $builtins | %{ Assert-AreEqual $_.Properties.PolicyType "Builtin" }

    $custom = Get-AzureRmPolicyDefinition -Custom
    $custom | %{ Assert-AreEqual $_.Properties.PolicyType "Custom" }

    # policy set definitions
    $builtins = Get-AzureRmPolicySetDefinition -Builtin
    $builtins | %{ Assert-AreEqual $_.Properties.PolicyType "Builtin" }

    $custom = Get-AzureRmPolicySetDefinition -Custom
    $custom | %{ Assert-AreEqual $_.Properties.PolicyType "Custom" }
}

function Test-GetBuiltinsByName
{
    # policy definitions
    $builtins = Get-AzureRmPolicyDefinition -Builtin | Select-Object -First 50
    foreach ($builtin in $builtins)
    {
        $definition = Get-AzureRmPolicyDefinition -Name $builtin.Name
        Assert-AreEqual $builtin.ResourceId $definition.ResourceId
    }

    # policy set definitions
    $builtins = Get-AzureRmPolicySetDefinition -Builtin | Select-Object -First 50
    foreach ($builtin in $builtins)
    {
        $setDefinition = Get-AzureRmPolicySetDefinition -Name $builtin.Name
        Assert-AreEqual $builtin.ResourceId $setDefinition.ResourceId
    }
}

<#
.SYNOPSIS
Tests Policy object piping 
#>
function Test-PolicyObjectPiping
{
    # setup
    $rgname = Get-ResourceGroupName
    $policySetDefName = Get-ResourceName
    $policyDefName = Get-ResourceName
    $policyAssName = Get-ResourceName
    $subscriptionId = (Get-AzContext).Subscription.Id
    $array = @("westus", "eastus")

    # make a policy definition and policy set definition that references it
    $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$TestOutputRoot\SamplePolicyDefinitionObject.json" -Description $description
    $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
    $expected = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description

    # make a policy assignment by piping the policy definition to New-AzPolicyAssignment
    $rg = New-AzResourceGroup -Name $rgname -Location "west us"

    # assign the policy definition to the resource group, get the assignment back and validate
    $actual = Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId | New-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -PolicyParameterObject @{'listOfAllowedLocations'=@('westus', 'eastus'); 'effectParam'='Deny'} -Description $description
    $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-NotNull $actual.Properties.PolicyDefinitionId
    Assert-NotNull $expected.Properties.PolicyDefinitionId
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations
    Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations.value
    Assert-NotNull $expected.Properties.Parameters.effectParam
    Assert-AreEqual 2 $expected.Properties.Parameters.listOfAllowedLocations.value.Length
    Assert-AreEqual "westus" $expected.Properties.Parameters.listOfAllowedLocations.value[0]
    Assert-AreEqual "eastus" $expected.Properties.Parameters.listOfAllowedLocations.value[1]
    Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.value

    # update some properties, including parameters
    $assignment = Get-AzPolicyAssignment -Id $actual.ResourceId
    $assignment.Properties.Parameters.effectParam.value = "Disabled"
    $assignment.Properties.Parameters.listOfAllowedLocations.value = @("eastus")
    $assignment.Properties.Description = $updatedDescription
    $assignment | Set-AzPolicyAssignment

    # get it back and validate the new values
    $assignment = Get-AzPolicyAssignment -Id $actual.ResourceId
    Assert-NotNull $assignment.Properties.Parameters.listOfAllowedLocations
    Assert-NotNull $assignment.Properties.Parameters.effectParam
    Assert-NotNull $assignment.Properties.Parameters.listOfAllowedLocations.value
    Assert-AreEqual 1 $assignment.Properties.Parameters.listOfAllowedLocations.value.Length
    Assert-AreEqual "eastus" $assignment.Properties.Parameters.listOfAllowedLocations.value[0]
    Assert-AreEqual "disabled" $assignment.Properties.Parameters.effectParam.value
    Assert-AreEqual $updatedDescription $assignment.Properties.Description

    # delete the policy assignment
    $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId | Remove-AzPolicyAssignment
    Assert-AreEqual True $remove

    # assign the policy set definition to the resource group, get the assignment back and validate
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId | New-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -Description $description
    $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-NotNull $actual.Properties.PolicyDefinitionId
    Assert-NotNull $expected.Properties.PolicyDefinitionId
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId

    # update the policy definition
    $actual = Get-AzPolicyDefinition -Name $policyDefName | Set-AzPolicyDefinition -Description $updatedDescription
    $expected = Get-AzPolicyDefinition -Name $policyDefName
    Assert-AreEqual $policyDefName $expected.Name
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.ResourceName $actual.ResourceName
    Assert-AreEqual Microsoft.Authorization/policyDefinitions $actual.ResourceType
    Assert-AreEqual $expected.ResourceType $actual.ResourceType
    Assert-NotNull $expected.ResourceId
    Assert-AreEqual $expected.ResourceId $actual.ResourceId
    Assert-AreEqual $updatedDescription $actual.Properties.Description
    Assert-AreEqual $updatedDescription $expected.Properties.Description

    # update the policy set definition
    $actual = Get-AzPolicySetDefinition -Name $policySetDefName | Set-AzPolicySetDefinition -Description $updatedDescription
    $expected = Get-AzPolicySetDefinition -Name $policySetDefName
    Assert-AreEqual $policySetDefName $expected.Name
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.ResourceName $actual.ResourceName
    Assert-AreEqual Microsoft.Authorization/policySetDefinitions $actual.ResourceType
    Assert-AreEqual $expected.ResourceType $actual.ResourceType
    Assert-NotNull $expected.ResourceId
    Assert-AreEqual $expected.ResourceId $actual.ResourceId
    Assert-AreEqual $updatedDescription $actual.Properties.Description
    Assert-AreEqual $updatedDescription $expected.Properties.Description

    # update the policy assignment
    $actual = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId | Set-AzPolicyAssignment -Description $updatedDescription
    $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
    Assert-AreEqual $expected.ResourceType $actual.ResourceType
    Assert-NotNull $actual.Properties.PolicyDefinitionId
    Assert-NotNull $expected.Properties.PolicyDefinitionId
    Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
    Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
    Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
    Assert-AreEqual $updatedDescription $actual.Properties.Description
    Assert-AreEqual $updatedDescription $expected.Properties.Description

    # clean up
    $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId | Remove-AzPolicyAssignment
    Assert-AreEqual True $remove

    $remove = Remove-AzResourceGroup -Name $rgname -Force
    Assert-AreEqual True $remove

    $remove = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId | Remove-AzPolicySetDefinition -Force
    Assert-AreEqual True $remove

    $remove = Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId | Remove-AzPolicyDefinition -Force
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
$someDisplayName = "Some display name"

# exception strings
$parameterSetError = 'Parameter set cannot be resolved using the specified named parameters.'
$missingParameters = 'Cannot process command because of one or more missing mandatory parameters:'
$onlyDefinitionOrSetDefinition = 'Only one of PolicyDefinition or PolicySetDefinition can be specified, not both.'
$policyAssignmentNotFound = 'PolicyAssignmentNotFound : '
$policySetDefinitionNotFound = 'PolicySetDefinitionNotFound : '
$policyDefinitionNotFound = 'PolicyDefinitionNotFound : '
$invalidRequestContent = 'InvalidRequestContent : The request content was invalid and could not be deserialized: '
$missingSubscription = 'MissingSubscription : The request did not have a subscription or a valid tenant level resource provider.'
$undefinedPolicyParameter = 'UndefinedPolicyParameter : The policy assignment'
$invalidPolicyRule = 'InvalidPolicyRule : Failed to parse policy rule: '
$authorizationFailed = 'AuthorizationFailed : '
$allSwitchNotSupported = 'The -IncludeDescendent switch is not supported for management group scopes.'
$httpMethodNotSupported = "HttpMethodNotSupported : The http method 'DELETE' is not supported for a resource collection."
$parameterNullOrEmpty = '. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again.'
<#
.SYNOPSIS
Tests Get-AzPolicyAssignment parameter combinations
#>
function Test-GetPolicyAssignmentParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $mgScope = "/providers/Microsoft.Management/managementGroups/$someManagementGroup"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"

    # validate with no parameters
    $ok = Get-AzPolicyAssignment

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $goodScope } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -PolicyDefinitionId $someId } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -IncludeDescendent } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinitionId $someId } $missingSubscription
    Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -Scope
    $ok = Get-AzPolicyAssignment -Scope $goodScope
    Assert-ThrowsContains { Get-AzPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError
    $ok = Get-AzPolicyAssignment -Scope $goodScope -PolicyDefinitionId $someId
    Assert-AreEqual 0 $ok.Count
    $ok = Get-AzPolicyAssignment -Scope $goodScope -IncludeDescendent
    Assert-ThrowsContains { Get-AzPolicyAssignment -Scope $mgScope -IncludeDescendent } $allSwitchNotSupported
    Assert-ThrowsContains { Get-AzPolicyAssignment -Scope $someScope -PolicyDefinitionId $someId -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    Assert-ThrowsContains { Get-AzPolicyAssignment -Id $goodId } $policyAssignmentNotFound
    Assert-ThrowsContains { Get-AzPolicyAssignment -Id $someId -PolicyDefinitionId $someId } $missingSubscription
    Assert-ThrowsContains { Get-AzPolicyAssignment -Id $someId -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -PolicyDefinitionId
    $ok = Get-AzPolicyAssignment -PolicyDefinitionId $someId
    Assert-AreEqual 0 $ok.Count
    Assert-ThrowsContains { Get-AzPolicyAssignment -PolicyDefinitionId $someId -IncludeDescendent } $parameterSetError

    # validate remaining parameter combinations starting with -IncludeDescendent
    $ok = Get-AzPolicyAssignment -IncludeDescendent
}

<#
.SYNOPSIS
Tests New-AzPolicyAssignment parameter combinations
#>
function Test-NewPolicyAssignmentParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodPolicyDefinition = Get-AzPolicyDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
    $goodPolicySetDefinition = Get-AzPolicySetDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
    $wrongParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'

    # validate with no parameters
    Assert-ThrowsContains { New-AzPolicyAssignment } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName } $invalidRequestContent
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $goodScope } $invalidRequestContent
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition } $missingSubscription
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicySetDefinition $goodPolicySetDefinition } $onlyDefinitionOrSetDefinition
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject } $undefinedPolicyParameter
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameter $wrongParameters } $undefinedPolicyParameter
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter } $parameterSetError
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter } $parameterSetError
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject } $parameterSetError
    Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $somePolicyParameter } $parameterSetError

    # validate parameter combinations starting with -Scope
    Assert-ThrowsContains { New-AzPolicyAssignment -Scope $someScope } $missingParameters
}

<#
.SYNOPSIS
Tests Remove-AzPolicyAssignment parameter combinations
#>
function Test-RemovePolicyAssignmentParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
    $goodObject = Get-AzPolicyAssignment | ?{ $_.Name -like '*test*' -or $_.Properties.Description -like '*test*' } | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Remove-AzPolicyAssignment } $missingParameters

    # validate parameter combinations starting with -Name
    $ok = Remove-AzPolicyAssignment -Name $someName
    Assert-AreEqual True $ok
    $ok = Remove-AzPolicyAssignment -Name $someName -Scope $goodScope
    Assert-AreEqual True $ok
    Assert-ThrowsContains { Remove-AzPolicyAssignment -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Remove-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError

    # validate remaining parameter combinations starting with -Scope
    Assert-ThrowsContains { Remove-AzPolicyAssignment -Scope $someScope } $missingParameters
    Assert-ThrowsContains { Remove-AzPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    $ok = Remove-AzPolicyAssignment -Id $goodId
    Assert-AreEqual True $ok
}

<#
.SYNOPSIS
Tests Set-AzPolicyAssignment parameter combinations
#>
function Test-SetPolicyAssignmentParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
    $someParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'
	$someLocation = 'west us'
	$someNotScope = 'not scope'

    # validate with no parameters
    Assert-ThrowsContains { Set-AzPolicyAssignment } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $goodScope } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -NotScope $someNotScope } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -DisplayName $someDisplayName } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Description $description } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Metadata $metadata } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -PolicyParameter $someParameters } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -AssignIdentity } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Location $someLocation } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -DisplayName $someDisplayName } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Description $description } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Description $description } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -PolicyParameter $someParameters } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -AssignIdentity -Location $someLocation } $missingSubscription

	#validation parameter combinations starting with -Id
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $goodId } $policyAssignmentNotFound
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -DisplayName $someDisplayName } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -Description $description } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Description $description } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameter $someParameters } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -PolicyParameter $someParameters } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -AssignIdentity } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -Location $someLocation } $missingSubscription
    Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -AssignIdentity -Location $someLocation } $missingSubscription
}

<#
.SYNOPSIS
Tests Get-AzPolicyDefinition parameter combinations
#>
function Test-GetPolicyDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"

    # validate with no parameters
    $ok = Get-AzPolicyDefinition

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId } $policyDefinitionNotFound
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Builtin } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Custom } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    $ok = Get-AzureRmPolicyDefinition -Id $goodId
    Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -ManagementGroup
    $ok = Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup
    Assert-ThrowsContains { Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
    $ok = Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn
    $ok = Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Custom
    Assert-ThrowsContains { Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -SubscriptionId
    $ok = Get-AzPolicyDefinition -SubscriptionId $subscriptionId
    $ok = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn
    $ok = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Custom
    Assert-ThrowsContains { Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -BuiltIn
    $ok = Get-AzPolicyDefinition -BuiltIn
    Assert-ThrowsContains { Get-AzPolicyDefinition -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Custom
    $ok = Get-AzPolicyDefinition -Custom
}

<#
.SYNOPSIS
Tests New-AzPolicyDefinition parameter combinations
#>
function Test-NewPolicyDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id

    # validate with no parameters
    Assert-ThrowsContains { New-AzPolicyDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName } $missingParameters
    Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet } $invalidPolicyRule
    Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup } $authorizationFailed
    Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId } $invalidPolicyRule
    Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate remaining parameter combinations starting with -Policy
    Assert-ThrowsContains { New-AzPolicyDefinition -Policy $someJsonSnippet } $missingParameters
}

<#
.SYNOPSIS
Tests Remove-AzPolicyDefinition parameter combinations
#>
function Test-RemovePolicyDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    $goodObject = Get-AzPolicyDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Remove-AzPolicyDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Remove-AzPolicyDefinition -Name $someName -Id $someId } $parameterSetError
    $ok = Remove-AzPolicyDefinition -Name $someName -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $ok

    # validate parameter combinations starting with -Id
    $ok = Remove-AzPolicyDefinition -Id $goodId -Force
    Assert-AreEqual True $ok
    Assert-ThrowsContains { Remove-AzPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Remove-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Force } $missingParameters
}

<#
.SYNOPSIS
Tests Set-AzPolicyDefinition parameter combinations
#>
function Test-SetPolicyDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    $goodObject = Get-AzPolicyDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Set-AzPolicyDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName } $policyDefinitionNotFound
    Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policyDefinitionNotFound
    Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId } $policyDefinitionNotFound

    # validate parameter combinations starting with -Id
    Assert-ThrowsContains { Set-AzPolicyDefinition -Id $goodId } $policyDefinitionNotFound
    Assert-ThrowsContains { Set-AzPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Set-AzPolicyDefinition -ManagementGroupName $someManagementGroup } $missingParameters
    Assert-ThrowsContains { Set-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Set-AzPolicyDefinition -SubscriptionId $subscriptionId } $missingParameters
}

<#
.SYNOPSIS
Tests Get-AzPolicySetDefinition parameter combinations
#>
function Test-GetPolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"

    # validate with no parameters
    $ok = Get-AzPolicySetDefinition

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId } $policySetDefinitionNotFound
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Builtin } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Custom } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Id
    $ok = Get-AzPolicySetDefinition -Id $goodId
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -SubscriptionId $subscriptionId } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -BuiltIn } $parameterSetError
    Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -ManagementGroup
    $ok = Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup
    Assert-ThrowsContains { Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
    $ok = Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn
    $ok = Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Custom
    Assert-ThrowsContains { Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -SubscriptionId
    $ok = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId
    $ok = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn
    $ok = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Custom
    Assert-ThrowsContains { Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -BuiltIn
    $ok = Get-AzPolicySetDefinition -BuiltIn
    Assert-ThrowsContains { Get-AzPolicySetDefinition -BuiltIn -Custom } $parameterSetError

    # validate remaining parameter combinations starting with -Custom
    $ok = Get-AzPolicySetDefinition -Custom
}

<#
.SYNOPSIS
Tests New-AzPolicySetDefinition parameter combinations
#>
function Test-NewPolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id

    # validate with no parameters
    Assert-ThrowsContains { New-AzPolicySetDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName } $missingParameters
    Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray } $invalidRequestContent
    Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup } $authorizationFailed
    Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId } $invalidRequestContent
    Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate remaining parameter combinations starting with -PolicyDefinition
    Assert-ThrowsContains { New-AzPolicySetDefinition -PolicyDefinition $someJsonArray } $missingParameters
}

<#
.SYNOPSIS
Tests Remove-AzPolicySetDefinition parameter combinations
#>
function Test-RemovePolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    $goodObject = Get-AzPolicySetDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Remove-AzPolicySetDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Remove-AzPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
    $ok = Remove-AzPolicySetDefinition -Name $someName -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzPolicySetDefinition -Name $someName -ManagementGroupName $managementGroup -Force
    Assert-AreEqual True $ok
    $ok = Remove-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -Force
    Assert-AreEqual True $ok

    # validate parameter combinations starting with -Id
    $ok = Remove-AzPolicySetDefinition -Id $goodId -Force
    Assert-AreEqual True $ok
    Assert-ThrowsContains { Remove-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Remove-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Force } $httpMethodNotSupported
}

<#
.SYNOPSIS
Tests Set-AzPolicySetDefinition parameter combinations
#>
function Test-SetPolicySetDefinitionParameters
{
    $subscriptionId = (Get-AzContext).Subscription.Id
    $goodScope = "/subscriptions/$subscriptionId"
    $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    $goodObject = Get-AzPolicySetDefinition -Builtin | select -First 1

    # validate with no parameters
    Assert-ThrowsContains { Set-AzPolicySetDefinition } $missingParameters

    # validate parameter combinations starting with -Name
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName } $policySetDefinitionNotFound
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policySetDefinitionNotFound
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId } $policySetDefinitionNotFound

    # validate parameter combinations starting with -Id
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Id $goodId } $policySetDefinitionNotFound
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
    Assert-ThrowsContains { Set-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -ManagementGroup
    Assert-ThrowsContains { Set-AzPolicySetDefinition -ManagementGroupName $someManagementGroup } $missingParameters
    Assert-ThrowsContains { Set-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError

    # validate parameter combinations starting with -SubscriptionId
    Assert-ThrowsContains { Set-AzPolicySetDefinition -SubscriptionId $subscriptionId } $missingParameters
}
