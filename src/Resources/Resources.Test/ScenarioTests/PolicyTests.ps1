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
	$actual = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json" -Mode Indexed
	$expected = Get-AzPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

	$actual = Set-AzPolicyDefinition -Name $policyName -DisplayName testDisplay -Description testDescription -Policy ".\SamplePolicyDefinition.json" -Metadata "{""test"":""test""}"
	$expected = Get-AzPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
	Assert-AreEqual $expected.Properties.Description $actual.Properties.Description
	Assert-NotNull($actual.Properties.Metadata)

	New-AzPolicyDefinition -Name test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}"
	$list = Get-AzPolicyDefinition
	Assert-True { $list.Count -ge 2}

	$remove = Remove-AzPolicyDefinition -Name $policyName -Force
	Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy definition with uri
#>
function Test-PolicyDefinitionWithUri
{
	# Setup
	$policyName = Get-ResourceName

	# Test
	$actual = New-AzPolicyDefinition -Name $policyName -Policy "https://raw.githubusercontent.com/vivsriaus/armtemplates/master/policyDef.json" -Mode All
	$expected = Get-AzPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-AreEqual $expected.Properties.Mode $actual.Properties.Mode

	$remove = Remove-AzPolicyDefinition -Name $policyName -Force
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
	$rg = New-AzResourceGroup -Name $rgname -Location "west us"
	$policy = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinition.json"
	$actual = New-AzPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId
	$expected = Get-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId

	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId

	$actualId = Get-AzPolicyAssignment -Id $actual.ResourceId
	Assert-AreEqual $actual.ResourceId $actualId.ResourceId

	$set = Set-AzPolicyAssignment -Id $actualId.ResourceId -DisplayName testDisplay
	Assert-AreEqual testDisplay $set.Properties.DisplayName

	New-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy
	$list = Get-AzPolicyAssignment
	Assert-AreEqual 2 @($list).Count

	$remove = Remove-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId
	Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy set definition CRUD operations
#>
function Test-PolicySetDefinitionCRUD
{
	# Setup
	$policySetDefName = Get-ResourceName
	$policyDefName = Get-ResourceName

	# Test
	$policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$TestOutputRoot\SamplePolicyDefinition.json"
	$policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
	$actual = New-AzPolicySetDefinition -Name $policySetDefName -PolicyDefinition $policySet
	$expected = Get-AzPolicySetDefinition -Name $policySetDefName
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicySetDefinitionId $actual.PolicySetDefinitionId
	Assert-NotNull($actual.Properties.PolicyDefinitions)

	$actual = Set-AzPolicySetDefinition -Name $policySetDefName -DisplayName testDisplay -Description testDescription
	$expected = Get-AzPolicySetDefinition -Name $policySetDefName
	Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
	Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

	$list = Get-AzPolicySetDefinition
	Assert-True { $list.Count -ge 1}

	$remove = Remove-AzPolicySetDefinition -Name $policySetDefName -Force
	Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy definition creation with parameters
#>
function Test-PolicyDefinitionWithParameters
{
	# Test
	$actual = New-AzPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"
	$expected = Get-AzPolicyDefinition -Name testPDWP
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-NotNull($actual.Properties.Parameters)
	Assert-NotNull($expected.Properties.Parameters)
	$remove = Remove-AzPolicyDefinition -Name testPDWP -Force
	Assert-AreEqual True $remove

	$actual = New-AzPolicyDefinition -Name testPDWP -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter '{ "listOfAllowedLocations": { "type": "array", "metadata": { "description": "An array of permitted locations for resources.", "strongType": "location", "displayName": "List of locations" } } }'
	$expected = Get-AzPolicyDefinition -Name testPDWP
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-NotNull($actual.Properties.Parameters)
	Assert-NotNull($expected.Properties.Parameters)
	$remove = Remove-AzPolicyDefinition -Name testPDWP -Force
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
	$rg = New-AzResourceGroup -Name $rgname -Location "west us"
	$policy = New-AzPolicyDefinition -Name $policyName -Policy "$TestOutputRoot\SamplePolicyDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SamplePolicyDefinitionParameters.json"
	$array = @("West US", "West US 2")
	$param = @{"listOfAllowedLocations"=$array}

	$actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameterObject $param
	$expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter "$TestOutputRoot\SamplePolicyAssignmentParameters.json"
	$expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }'
	$expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -PolicyDefinition $policy -listOfAllowedLocations $array
	$expected = Get-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove
}
