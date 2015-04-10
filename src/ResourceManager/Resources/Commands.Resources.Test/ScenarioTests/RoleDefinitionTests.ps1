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
    # $rd = New-AzureRoleDefinition -InputFile .Resources\RoleDefinition.json

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
    # $rd = New-AzureRoleDefinition -InputFile .\Resources\RoleDefinition.json
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

    # $rdReCreated = New-AzureRoleDefinition -Role $rd
    $rdReDeleted = Get-AzureRoleDefinition -Name $rd.Name | Remove-AzureRoleDefinition -Force
}