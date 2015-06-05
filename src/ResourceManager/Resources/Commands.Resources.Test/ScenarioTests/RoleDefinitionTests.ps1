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
    $rdName = 'CustomRole Tests Role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("8D7DD69E-9AE2-44A1-94D8-F7BC8E12645E")
    New-AzureRoleDefinition -InputFile .\Resources\NewRoleDefinition.json

    $rd = Get-AzureRoleDefinition -Name $rdName
	Assert-AreEqual "Test role" $rd.Description 
	Assert-AreEqual $true $rd.IsCustom
	Assert-NotNull $rd.Actions
	Assert-AreEqual "Microsoft.Authorization/*/read" $rd.Actions[0]
	Assert-AreEqual "Microsoft.Support/*" $rd.Actions[1]
	Assert-NotNull $rd.AssignableScopes
	Assert-AreEqual "/subscriptions/0f3992f2-ec70-4614-bdb3-70addf19069d" $rd.AssignableScopes[0]

	# Basic positive case - read from object
	$roleDef = Get-AzureRoleDefinition -Name "Virtual Machine Contributor"
	$roleDef.Id = $null
	$roleDef.Name = "Virtual machine admins"
	$roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
	$roleDef.Description = "Can monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/0f3992f2-ec70-4614-bdb3-70addf19069d"

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("032F61D2-ED09-40C9-8657-26A273DA7BAE")
	New-AzureRoleDefinition -Role $roleDef
	$addedRoleDef = Get-AzureRoleDefinition -Name "Virtual machine admins"

	Assert-NotNull $addedRoleDef.Actions
	Assert-AreEqual $roleDef.Description $addedRoleDef.Description
	Assert-AreEqual $roleDef.AssignableScopes $addedRoleDef.AssignableScopes
	Assert-AreEqual $true $addedRoleDef.IsCustom

    Remove-AzureRoleDefinition -Id $addedRoleDef.Id -Force
    Remove-AzureRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verify negative scenarios for RoleDefinitions
#>
function Test-RdNegativeScenarios
{
    # Does not throw when getting a non-existing role assignment
    $rdName = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $rdNull = Get-AzureRoleDefinition -Name $rdName
    Assert-Null $rdNull

    $rdId = '85E460B3-89E9-48BA-9DCD-A8A99D64A674'
    $badIdException = "RoleDefinitionNotFound: The role definition '" + $rdId + "' could not be found."

    # Throws on trying to update the a role that does not exist
    Assert-Throws { Set-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json } $badIdException

    # Role Defintion not provided.
    $roleDefNotProvided = "Parameter set cannot be resolved using the specified named parameters."
    Assert-Throws { Set-AzureRoleDefinition } $roleDefNotProvided

    # Input file not provided.
    $roleDefNotProvided = "Cannot validate argument on parameter 'InputFile'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."
    Assert-Throws { Set-AzureRoleDefinition -InputFile "" } $roleDefNotProvided
    Assert-Throws { Set-AzureRoleDefinition -InputFile "" -Role $rdNull } $roleDefNotProvided

    # Role not provided.
    $roleDefNotProvided = "Cannot validate argument on parameter 'Role'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."
    Assert-Throws { Set-AzureRoleDefinition -Role $rdNull } $roleDefNotProvided
    Assert-Throws { Set-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json -Role $rd } $roleDefNotProvided

    #TODO add check for valid input file and valid role

    # Throws on trying to delete a role that does not exist
    $missingSubscription = "MissingSubscription: The request did not have a provided subscription. All requests must have an associated subscription Id."
    Assert-Throws { Remove-AzureRoleDefinition -Id $rdId -Force} $missingSubscription
}

<#
.SYNOPSIS
Tests verify positive scenarios for RoleDefinitions.
#>
function Test-RDPositiveScenarios
{
    # Create a role definition with Name rdNamme.
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("032F61D2-ED09-40C9-8657-26A273DA7BAE")
    $rd = New-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json
    $rd = Get-AzureRoleDefinition -Name $rdName

    # Update the role definition with action that was created in the step above.
    $rd.Actions.Add('Microsoft.Authorization/*/read')
    $updatedRd = Set-AzureRoleDefinition -Role $rd
    Assert-NotNull $updatedRd

    # delete the role definition
    $deletedRd = Remove-AzureRoleDefinition -Id $rd.Id -Force -PassThru
    Assert-AreEqual $rd.Name $deletedRd.Name

    # try to read the deleted role definition
    $readRd = Get-AzureRoleDefinition -Name $rd.Name
    Assert-Null $readRd
}
