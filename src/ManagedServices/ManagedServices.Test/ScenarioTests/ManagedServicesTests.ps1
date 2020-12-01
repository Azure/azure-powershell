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
Create, update, and delete registration assignments and registration definitions
#>

function Test-ManagedServices_CRUD
{
    $roleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    $managedByTenantId = "bab3375b-6197-4a15-a44b-16c41faa91d7"
    $principalId = "d6f6c88a-5b7a-455e-ba40-ce146d4d3671"
    $subscriptionId = "002b3477-bfbf-4402-b377-6003168b75d3"
    $displayName = "Resource display name"
    $assignmentId = "8af8768c-73c2-4993-86ae-7a45c9b232c6"
    $definitionId = "1ccdb215-959a-48b9-bd7c-0584d461ea6c"

    #put definition
    $definition = New-AzManagedServicesDefinition -ManagedByTenantId $managedByTenantId -RoleDefinitionId $roleDefinitionId -PrincipalId $principalId -DisplayName $displayName -Name $definitionId

    Assert-AreEqual $definitionId $definition.Name
    Assert-AreEqual $displayName $definition.Properties.DisplayName
    Assert-AreEqual $managedByTenantId $definition.Properties.ManagedByTenantId
    Assert-AreEqual $roleDefinitionId $definition.Properties.Authorization[0].RoleDefinitionId
    Assert-AreEqual $principalId $definition.Properties.Authorization[0].PrincipalId

    # get definition
    $retrievedDefinition = Get-AzManagedServicesDefinition -Name $definitionId
    Assert-NotNull $retrievedDefinition
    Assert-AreEqual $definition.Id $retrievedDefinition.Id

    #put assignment
    $assignment = New-AzManagedServicesAssignment `
        -RegistrationDefinitionId $definition.Id `
        -Name $assignmentId
    Assert-NotNull $assignment

    #get assignment
    $retrievedAssignment = Get-AzManagedServicesAssignment -Name $assignmentId -ExpandRegistrationDefinition
    Assert-NotNull $retrievedAssignment
    Assert-AreEqual $assignment.Id $retrievedAssignment.Id
    Assert-AreEqual $definition.Id $retrievedAssignment.Properties.RegistrationDefinitionId

    #remove assignment
    Remove-AzManagedServicesAssignment -Name $assignmentId
    
    #remove definition
    Remove-AzManagedServicesDefinition -Name $definitionId

    #list assignments
    $assignments = Get-AzManagedServicesAssignment
    Foreach($assignment in $assignments)
    {
        Assert-AreNotEqual($assignmentId, $assignment.Name)
    }

    #list definitions
    $definitions = Get-AzManagedServicesDefinition
    Foreach($definition in $definitions)
    {
        Assert-AreNotEqual($assignmentId, $assignment.Name)
    }
}