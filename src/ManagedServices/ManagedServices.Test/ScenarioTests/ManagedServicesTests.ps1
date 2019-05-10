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

function New-AzManagedServicesAssignmentWithId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $Scope,
        [string] [Parameter()] $RegistrationDefinitionResourceId,
        [Guid]   [Parameter()] $RegistrationAssignmentId
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands.NewAzureRmManagedServicesAssignment
    $cmdlet.DefaultProfile = $profile
	$cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($Scope)))
    {
        $cmdlet.Scope = $Scope
    }

    if (-not ([string]::IsNullOrEmpty($RegistrationDefinitionResourceId)))
    {	
        $cmdlet.RegistrationDefinitionResourceId = $RegistrationDefinitionResourceId
    }

    if ($RegistrationAssignmentId -ne $null -and $RegistrationAssignmentId -ne [System.Guid]::Empty)
    {
		$cmdlet.RegistrationAssignmentId = $RegistrationAssignmentId
    }

    $cmdlet.ExecuteCmdlet()
}

function New-AzManagedServicesDefinitionWithId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $Name,
        [string] [Parameter()] $ManagedByTenantId,
        [string] [Parameter()] $PrincipalId,
        [string] [Parameter()] $RoleDefinitionId,
		[string] [Parameter()] $Description,
        [Guid]   [Parameter()] $RegistrationDefinitionId
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands.NewAzureRmManagedServicesDefinition
    $cmdlet.DefaultProfile = $profile
	$cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($Description)))
    {
        $cmdlet.Description = $Description
    }

    if (-not ([string]::IsNullOrEmpty($Name)))
    {
        $cmdlet.Name = $Name
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

    if ($RegistrationDefinitionId -ne $null -and $RegistrationDefinitionId -ne [System.Guid]::Empty)
    {
        $cmdlet.RegistrationDefinitionId = $RegistrationDefinitionId
    }

    $cmdlet.ExecuteCmdlet()
}

function Test-ManagedServices_CRUD
{
    $roleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7";
	$managedByTenantId = "bab3375b-6197-4a15-a44b-16c41faa91d7";
	$principalId = "d6f6c88a-5b7a-455e-ba40-ce146d4d3671";
	$subscriptionId = "38bd4bef-41ff-45b5-b3af-d03e55a4ca15"
	$name = getAssetName
	$assignmentId = "846b8de3-400b-4e89-b1f4-5bb7b73f12be";
	$definitionId = "e7d4730c-b52a-42b4-b974-6772d88cf7c6"

	#put def
	$definition = New-AzManagedServicesDefinitionWithId -ManagedByTenantId $managedByTenantId -RoleDefinitionId $roleDefinitionId -PrincipalId $principalId -Name $name -RegistrationDefinitionId e7d4730c-b52a-42b4-b974-6772d88cf7c6

	Assert-AreEqual $name $definition.Properties.Name
	Assert-AreEqual $managedByTenantId $definition.Properties.ManagedByTenantId 
	Assert-AreEqual $roleDefinitionId $definition.Properties.Authorization[0].RoleDefinitionId 
	Assert-AreEqual $principalId $definition.Properties.Authorization[0].PrincipalId

	# get def
	$getDef = Get-AzManagedServicesDefinition -Name $definitionId
	Assert-NotNull $getDef
	Assert-AreEqual $definition.Id $getDef.Id

	#put assignment
	$assignment = New-AzManagedServicesAssignmentWithId `
					-RegistrationDefinitionResourceId $definition.Id `
					-RegistrationAssignmentId 846b8de3-400b-4e89-b1f4-5bb7b73f12be
	
	Assert-NotNull $assignment

	#get assignment
	$getAssignment = Get-AzManagedServicesAssignment -Id $assignmentId -ExpandRegistrationDefinition
	Assert-NotNull $getAssignment
	Assert-AreEqual $assignment.Id $getAssignment.Id
	Assert-AreEqual $definition.Id $getAssignment.Properties.RegistrationDefinitionId

	#remove assignment
	$removeAssignment = Remove-AzManagedServicesAssignment -Id $assignmentId
	Assert-NotNull	$removeAssignment
	
	#remove definition
	$removeDef = Remove-AzManagedServicesDefinition -Id $definitionId
	Assert-NotNull	$removeDef
}