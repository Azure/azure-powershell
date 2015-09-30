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
	$rgname = Get-ResourceGroupName
	$policyName = Get-ResourceName

	# Test
	$actual = New-AzureRMPolicyDefinition -Name $policyName -Policy SamplePolicyDefinition.json
	$expected = Get-AzureRMPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.PolicyDefinitionId $actual.PolicyDefinitionId
	Assert-NotNull($actual.Properties.PolicyRule)

	$actual = Set-AzureRMPolicyDefinition -Name $policyName -DisplayName testDisplay -Description testDescription
	$expected = Get-AzureRMPolicyDefinition -Name $policyName
	Assert-AreEqual $expected.Properties.DisplayName $actual.Properties.DisplayName
	Assert-AreEqual $expected.Properties.Description $actual.Properties.Description

	New-AzureRMPolicyDefinition -Name test2 -Policy "{""if"":{""source"":""action"",""equals"":""blah""},""then"":{""effect"":""deny""}}"
	$list = Get-AzureRMPolicyDefinition
	Assert-AreEqual 2 @($list).Count

	$remove = Remove-AzureRMPolicyDefinition -Name $policyName -Force
	Assert-AreEqual True $remove

}
