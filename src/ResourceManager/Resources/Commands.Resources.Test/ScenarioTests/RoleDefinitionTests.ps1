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

<#
.SYNOPSIS
Tests verify negative scenarios for RoleDefinitions
#>
function Test-RdNegativeScenarios
{
    # Does not throw when getting a non-existing role assignment
    $rdName = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $badRdNameResult = Get-AzureRoleDefinition -Name $rdName
    Assert-Null $badRdNameResult

    $rdId = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $badIdException = "Can not find role definition with id " + $rdId + "."

    # Throws on trying to update the a role that does not exist
    Assert-Throws { Set-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json } $badIdException

    # Get a null role definition
    $rdName = 'nonExisting role'
    $rdNull = Get-AzureRoleDefinition -Name $rdName

    # Create a role definition
    $rd = New-AzureRoleDefinition -InputFile .Resources\RoleDefinition.json

    # Role Defintion not provided.
    $roleDefNotProvided = "Role definition not provided."
    Assert-Throws { Set-AzureRoleDefinition } $roleDefNotProvided
    Assert-Throws { Set-AzureRoleDefinition -InputFile "" } $roleDefNotProvided
    Assert-Throws { Set-AzureRoleDefinition -Role $rdNull } $roleDefNotProvided
    Assert-Throws { Set-AzureRoleDefinition -InputFile "" -Role $rdNull } $roleDefNotProvided

    # Provide role definition using either InputFile or Role, not both.
    $doNotProvideBothParams = "Provide role definition using either InputFile or Role, not both."
    Assert-Throws { Set-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json -Role $rd } $doNotProvideBothParams

    # Throws on trying to delete a role that does not exist
    Assert-Throws { Remove-AzureRoleDefinition -Id $rdId -Force} $badIdException
}

<#
.SYNOPSIS
Tests verify positive scenarios for RoleDefinitions.
#>
function Test-RDPositiveScenarios
{
    # Create a role definition with Name rdNamme.
    $rdName = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $rd = New-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json
    $rd = Get-AzureRoleDefinition -Name $rdName

    # Update the role definition with name $rdName that was created in the step above.
    $newActions = {'Microsoft.Authorization/*/read'}
    $rd.Actions = $newActions
    $updatedRd = Set-AzureRoleDefinition -RoleDefinition $rd

    Assert-AreEqual $rd.Name $updatedRd.Name
    Assert-AreEqual $newActions $updatedRd.Actions

    # delete the role definition
    $deletedRd = Remove-AzureRoleDefinition -Id $rd.Id -Force
    Assert-AreEqual $rd.Name $deletedRd.Name

    # try to read the deleted role definition
    $readRd = Get-AzureRoleDefinition -Name $rd.Name
    Assert-Null $readRd

    $rdReCreated = New-AzureRoleDefinition -Role $rd
    $rdReDeleted = Get-AzureRoleDefinition -Name $rd.Name | Remove-AzureRoleDefinition -Force
}
