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

<#
.SYNOPSIS
Tests Policy definition CRUD operations
#>
function Test-PolicyDefinitionCRUD
{
	# Setup
	$policyName = Get-ResourceName

	# Test
	$actual = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json"
	$expected = Get-AzureRMPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)

	$actual = Set-AzureRMPolicyDefinition -Name $policyName -DisplayName testDisplay -Description testDescription -Policy ".\SamplePolicyDefinition.json"
	$expected = Get-AzureRMPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
	Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

	New-AzureRMPolicyDefinition -Name test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}"
	$list = Get-AzureRMPolicyDefinition
	Assert-AreEqual 2 @($list).Count

	$remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
	Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy assignment CRUD operations
#>
function Test-PolicyAssignmentCRUD
{
	# Setup
	$rgname = Get-ResourceGroupName
	$policyName = Get-ResourceName

	# Test
	$rg = New-AzureRMResourceGroup -Name $rgname -Location "west us"
	$policy = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json"
	$actual = New-AzureRMPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId
	$expected = Get-AzureRMPolicyAssignment -Name testPA -Scope $rg.ResourceId

	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId

	$actualId = Get-AzureRMPolicyAssignment -Id $actual.ResourceId
	Assert-AreEqual $actual.ResourceId $actualId.ResourceId

	$set = Set-AzureRMPolicyAssignment -Id $actualId.ResourceId -DisplayName testDisplay
	Assert-AreEqual testDisplay $set.Properties.DisplayName

	New-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy
	$list = Get-AzureRMPolicyAssignment
	Assert-AreEqual 2 @($list).Count

	$remove = Remove-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId
	Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy definition creation with parameters
#>
function Test-PolicyDefinitionWithParameters
{
	# Test
	$actual = New-AzureRMPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"
	$expected = Get-AzureRMPolicyDefinition -Name testPDWP
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-NotNull($actual.Properties.Parameters)
	Assert-NotNull($expected.Properties.Parameters)
	$remove = Remove-AzureRMPolicyDefinition -Name testPDWP -Force
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter '{ "listOfAllowedLocations": { "type": "array", "metadata": { "description": "An array of permitted locations for resources.", "strongType": "location", "displayName": "List of locations" } } }'
	$expected = Get-AzureRMPolicyDefinition -Name testPDWP
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-NotNull($actual.Properties.Parameters)
	Assert-NotNull($expected.Properties.Parameters)
	$remove = Remove-AzureRMPolicyDefinition -Name testPDWP -Force
	Assert-AreEqual True $remove
}

<#
.SYNOPSIS
Tests Policy assignment creation with parameters
#>
function Test-PolicyAssignmentWithParameters
{
	# Setup
	$rgname = Get-ResourceGroupName
	$policyName = Get-ResourceName

	# Test
	$rg = New-AzureRMResourceGroup -Name $rgname -Location "west us"
	$policy = New-AzureRMPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"
	$array = @("West US", "West US 2")
	$param = @{"listOfAllowedLocations"=$array}

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameterObject $param
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter "$TestOutputRoot\SamplePolicyAssignmentParameters.json"
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }'
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -listOfAllowedLocations $array
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove
}
