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

function New-AzManagedServicesAssignmentWithDefinitionId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $Scope,
        [string] [Parameter()] $RegistrationDefinitionId,
        [string] [Parameter()] $Name
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands.NewAzureRmManagedServicesAssignment
    $cmdlet.DefaultProfile = $profile
    $cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($Scope)))
    {
        $cmdlet.Scope = $Scope
    }

    if (-not ([string]::IsNullOrEmpty($RegistrationDefinitionId)))
    {
        $cmdlet.RegistrationDefinitionId = $RegistrationDefinitionId
    }

    if ($Name -ne $null -and $Name -ne [System.Guid]::Empty)
    {
        $cmdlet.Name = $Name
    }

    $cmdlet.ExecuteCmdlet()
}

function New-AzManagedServicesDefinitionWithId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $DisplayName,
        [string] [Parameter()] $ManagedByTenantId,
        [string] [Parameter()] $PrincipalId,
        [string] [Parameter()] $RoleDefinitionId,
        [string] [Parameter()] $Description,
        [string] [Parameter()] $Name
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands.NewAzureRmManagedServicesDefinition
    $cmdlet.DefaultProfile = $profile
    $cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($Description)))
    {
        $cmdlet.Description = $Description
    }

    if (-not ([string]::IsNullOrEmpty($DisplayName)))
    {
        $cmdlet.DisplayName = $DisplayName
    }

    if (-not ([string]::IsNullOrEmpty($ManagedByTenantId)))
    {
        $cmdlet.ManagedByTenantId = $ManagedByTenantId
    }

    if (-not ([string]::IsNullOrEmpty($PrincipalId)))
    {
        $cmdlet.PrincipalId = $PrincipalId
    }

    if (-not ([string]::IsNullOrEmpty($RoleDefinitionId)))
    {
        $cmdlet.RoleDefinitionId = $RoleDefinitionId
    }

    if ($Name -ne $null -and $Name -ne [System.Guid]::Empty)
    {
        $cmdlet.Name = $Name
    }

    $cmdlet.ExecuteCmdlet()
}

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
    $definition = New-AzManagedServicesDefinitionWithId -ManagedByTenantId $managedByTenantId -RoleDefinitionId $roleDefinitionId -PrincipalId $principalId -DisplayName $displayName -Name $definitionId

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
    $assignment = New-AzManagedServicesAssignmentWithId `
        -RegistrationDefinitionId $definition.Id `
        -Name $assignmentId
    Assert-NotNull $assignment

    #get assignment
    $retrievedAssignment = Get-AzManagedServicesAssignment -Name $assignmentId -ExpandRegistrationDefinition
    Assert-NotNull $retrievedAssignment
    Assert-AreEqual $assignment.Id $retrievedAssignment.Id
    Assert-AreEqual $definition.Id $retrievedAssignment.Properties.RegistrationDefinitionId

    #list assignments
    $assignments = Get-AzManagedServicesAssignment
    Assert-AreEqual 1 $assignments.Count

    #list definitions
    $definitions = Get-AzManagedServicesDefinition
    Assert-AreEqual 1 $definitions.Count

    #remove assignment
    Remove-AzManagedServicesAssignment -Name $assignmentId
    
    #remove definition
    Remove-AzManagedServicesDefinition -Name $definitionId

    #list assignments
    $assignments = Get-AzManagedServicesAssignment
    Assert-AreEqual 0 $assignments.Count

    #list definitions
    $definitions = Get-AzManagedServicesDefinition
    Assert-AreEqual 0 $definitions.Count
}