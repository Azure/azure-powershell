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
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RoleDefinitionCreateTests
{
    # Basic positive case - read from file
    $rdName = 'CustomRole Test Role'
    New-AzureRoleDefinition -InputFile .\Resources\NewRoleDefinition.json
    $rd = Get-AzureRoleDefinition -Name $rdName
	Assert-NotNull $rd
	Assert-AreEqual "Test role" $rd.Description 
	Assert-AreEqual $true $rd.IsCustom
	Assert-NotNull $rd.Actions
	Assert-AreEqual "Microsoft.Authorization/*/read" $rd.Actions[0]
	Assert-AreEqual "Microsoft.Support/*" $rd.Actions[1]
	Assert-NotNull $rd.AssignableScopes
	# The below scopes may need to be changed to actual scope values like /subscriptions/.... to satisfy the ARM access checks for PUT requests
	Assert-AreEqual "Scope1" $rd.AssignableScopes[0]
	Assert-AreEqual "Scope2" $rd.AssignableScopes[1]

	# Basic positive case - read from object
	$roleDef = Get-AzureRoleDefinition -Name "Virtual Machine Contributor"
	$roleDef.Id = $null
	$roleDef.Name = "Virtual machine restarter"
	$roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
	$roleDef.Description = "Can monitor and restart virtual machines"
	
	New-AzureRoleDefinition -Role $roleDef
	$addedRoleDef = Get-AzureRoleDefinition -Name "Virtual machine restarter"

	Assert-AreEqual $roleDef.Actions $addedRoleDef.Actions
	Assert-AreEqual $roleDef.Description $addedRoleDef.Description
	Assert-AreEqual $roleDef.AssignableScopes $addedRoleDef.AssignableScopes
	Assert-AreEqual $true $roleDef.IsCustom
}
