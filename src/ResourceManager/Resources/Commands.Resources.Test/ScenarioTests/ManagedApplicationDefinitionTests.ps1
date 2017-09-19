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
Tests Managed Application definition CRUD operations
#>
function Test-ManagedApplicationDefinitionCRUD
{
	# Setup
	$rgname = Get-ResourceGroupName
	$appDefName = Get-ResourceName
	$rglocation = "EastUS2EUAP"
	$display = "myAppDefPoSH"

	# Test
	New-AzureRmResourceGroup -Name $rgname -Location $rglocation

	$actual = New-AzureRMManagedApplicationDefinition -Name $appDefName -ResourceGroupName $rgname -DisplayName $display -Description "Test" -Location $rglocation -LockLevel ReadOnly -PackageFileUri https://testclinew.blob.core.windows.net/files/vivekMAD.zip -Authorization 5e91139a-c94b-462e-a6ff-1ee95e8aac07:8e3af657-a8ff-443c-a75c-2fe8c4bcb635
	$expected = Get-AzureRMManagedApplicationDefinition -Name $appDefName -ResourceGroupName $rgname
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.ManagedApplicationDefinitionId $actual.ManagedApplicationDefinitionId
	Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
	Assert-NotNull($actual.Properties.Authorizations)

	$actual = Set-AzureRMManagedApplicationDefinition -ResourceId $expected.ManagedApplicationDefinitionId -PackageFileUri https://testclinew.blob.core.windows.net/files/vivekMAD.zip -Description "updated"
	$expected = Get-AzureRMManagedApplicationDefinition -Name $appDefName -ResourceGroupName $rgname
	Assert-AreEqual $expected.Properties.description $actual.Properties.Description

	$list = Get-AzureRMManagedApplicationDefinition -ResourceGroupName $rgname
	Assert-AreEqual 1 @($list).Count

	$remove = Remove-AzureRMManagedApplicationDefinition -Name $appDefName -ResourceGroupName $rgname -Force
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
	$appDefName = Get-ResourceName

	# Test
	$rg = New-AzureRMResourceGroup -Name $rgname -Location "west us"
	$policy = New-AzureRMManagedApplicationDefinition -Name $appDefName -Policy "$TestOutputRoot\SampleManagedApplicationDefinition.json"
	$actual = New-AzureRMPolicyAssignment -Name testPA -ManagedApplicationDefinition $policy -Scope $rg.ResourceId
	$expected = Get-AzureRMPolicyAssignment -Name testPA -Scope $rg.ResourceId

	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.ManagedApplicationDefinitionId $policy.ManagedApplicationDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId

	$actualId = Get-AzureRMPolicyAssignment -Id $actual.ResourceId
	Assert-AreEqual $actual.ResourceId $actualId.ResourceId

	$set = Set-AzureRMPolicyAssignment -Id $actualId.ResourceId -DisplayName testDisplay
	Assert-AreEqual testDisplay $set.Properties.DisplayName

	New-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId -ManagedApplicationDefinition $policy
	$list = Get-AzureRMPolicyAssignment
	Assert-AreEqual 2 @($list).Count

	$remove = Remove-AzureRMPolicyAssignment -Name test2 -Scope $rg.ResourceId
	Assert-AreEqual True $remove

}

<#
.SYNOPSIS
Tests Policy definition creation with parameters
#>
function Test-ManagedApplicationDefinitionWithParameters
{
	# Test
	$actual = New-AzureRMManagedApplicationDefinition -Name testPDWP -Policy "$TestOutputRoot\SampleManagedApplicationDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SampleManagedApplicationDefinitionParameters.json"
	$expected = Get-AzureRMManagedApplicationDefinition -Name testPDWP
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.ManagedApplicationDefinitionId $actual.ManagedApplicationDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-NotNull($actual.Properties.Parameters)
	Assert-NotNull($expected.Properties.Parameters)
	$remove = Remove-AzureRMManagedApplicationDefinition -Name testPDWP -Force
	Assert-AreEqual True $remove

	$actual = New-AzureRMManagedApplicationDefinition -Name testPDWP -Policy "$TestOutputRoot\SampleManagedApplicationDefinitionWithParameters.json" -Parameter '{ "listOfAllowedLocations": { "type": "array", "metadata": { "description": "An array of permitted locations for resources.", "strongType": "location", "displayName": "List of locations" } } }'
	$expected = Get-AzureRMManagedApplicationDefinition -Name testPDWP
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.ManagedApplicationDefinitionId $actual.ManagedApplicationDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)
	Assert-NotNull($actual.Properties.Parameters)
	Assert-NotNull($expected.Properties.Parameters)
	$remove = Remove-AzureRMManagedApplicationDefinition -Name testPDWP -Force
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
	$appDefName = Get-ResourceName

	# Test
	$rg = New-AzureRMResourceGroup -Name $rgname -Location "west us"
	$policy = New-AzureRMManagedApplicationDefinition -Name $appDefName -Policy "$TestOutputRoot\SampleManagedApplicationDefinitionWithParameters.json" -Parameter "$TestOutputRoot\SampleManagedApplicationDefinitionParameters.json"
	$array = @("West US", "West US 2")
	$param = @{"listOfAllowedLocations"=$array}

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -ManagedApplicationDefinition $policy -PolicyParameterObject $param
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.ManagedApplicationDefinitionId $policy.ManagedApplicationDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -ManagedApplicationDefinition $policy -PolicyParameter "$TestOutputRoot\SamplePolicyAssignmentParameters.json"
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.ManagedApplicationDefinitionId $policy.ManagedApplicationDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -ManagedApplicationDefinition $policy -PolicyParameter '{ "listOfAllowedLocations": { "value": [ "West US", "West US 2" ] } }'
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.ManagedApplicationDefinitionId $policy.ManagedApplicationDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove

	$actual = New-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId -ManagedApplicationDefinition $policy -listOfAllowedLocations $array
	$expected = Get-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
	Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
	Assert-AreEqual $expected.Properties.ManagedApplicationDefinitionId $policy.ManagedApplicationDefinitionId
	Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
	$remove = Remove-AzureRMPolicyAssignment -Name testPAWP -Scope $rg.ResourceId
	Assert-AreEqual True $remove
}
