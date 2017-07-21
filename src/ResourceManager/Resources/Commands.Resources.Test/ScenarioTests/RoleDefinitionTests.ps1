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
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    # Basic positive case - read from file
    $rdName = 'CustomRole Tests Role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("8D7DD69E-9AE2-44A1-94D8-F7BC8E12645E")
    New-AzureRmRoleDefinition -InputFile .\Resources\NewRoleDefinition.json

    $rd = Get-AzureRmRoleDefinition -Name $rdName
	Assert-AreEqual "Test role" $rd.Description 
	Assert-AreEqual $true $rd.IsCustom
	Assert-NotNull $rd.Actions
	Assert-AreEqual "Microsoft.Authorization/*/read" $rd.Actions[0]
	Assert-AreEqual "Microsoft.Support/*" $rd.Actions[1]
	Assert-NotNull $rd.AssignableScopes
	
	# Basic positive case - read from object
	$roleDef = Get-AzureRmRoleDefinition -Name "Reader"
	$roleDef.Id = $null
	$roleDef.Name = "Custom Reader"
	$roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
	$roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f"

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("032F61D2-ED09-40C9-8657-26A273DA7BAE")
	New-AzureRmRoleDefinition -Role $roleDef
	$addedRoleDef = Get-AzureRmRoleDefinition -Name "Custom Reader"

	Assert-NotNull $addedRoleDef.Actions
	Assert-AreEqual $roleDef.Description $addedRoleDef.Description
	Assert-AreEqual $roleDef.AssignableScopes $addedRoleDef.AssignableScopes
	Assert-AreEqual $true $addedRoleDef.IsCustom

    Remove-AzureRmRoleDefinition -Id $addedRoleDef.Id -Force
    Remove-AzureRmRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verify negative scenarios for RoleDefinitions
#>
function Test-RdNegativeScenarios
{
	# Setup
	Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    # Does not throw when getting a non-existing role assignment
    $rdName = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $rdNull = Get-AzureRmRoleDefinition -Name $rdName
    Assert-Null $rdNull

    $rdId = '85E460B3-89E9-48BA-9DCD-A8A99D64A674'
	
    $badIdException = "RoleDefinitionDoesNotExist: The specified role definition with ID '" + $rdId + "' does not exist."

    # Throws on trying to update the a role that does not exist
    Assert-Throws { Set-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json } $badIdException

    # Role Defintion not provided.
    $roleDefNotProvided = "Parameter set cannot be resolved using the specified named parameters."
    Assert-Throws { Set-AzureRmRoleDefinition } $roleDefNotProvided

    # Input file not provided.
    $roleDefNotProvided = "Cannot validate argument on parameter 'InputFile'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."
    Assert-Throws { Set-AzureRmRoleDefinition -InputFile "" } $roleDefNotProvided
    Assert-Throws { Set-AzureRmRoleDefinition -InputFile "" -Role $rdNull } $roleDefNotProvided

    # Role not provided.
    $roleDefNotProvided = "Cannot validate argument on parameter 'Role'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."
    Assert-Throws { Set-AzureRmRoleDefinition -Role $rdNull } $roleDefNotProvided
    Assert-Throws { Set-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json -Role $rd } $roleDefNotProvided

    #TODO add check for valid input file and valid role

    # Throws on trying to delete a role that does not exist
    $missingSubscription = "MissingSubscription: The request did not have a provided subscription. All requests must have an associated subscription Id."
    Assert-Throws { Remove-AzureRmRoleDefinition -Id $rdId -Force} $badIdException
}

<#
.SYNOPSIS
Tests verify positive scenarios for RoleDefinitions.
#>
function Test-RDPositiveScenarios
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    # Create a role definition with Name rdNamme.
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("032F61D2-ED09-40C9-8657-26A273DA7BAE")
    $rd = New-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json
    $rd = Get-AzureRmRoleDefinition -Name $rdName

    # Update the role definition with action that was created in the step above.
    $rd.Actions.Add('Microsoft.Authorization/*/read')
    $updatedRd = Set-AzureRmRoleDefinition -Role $rd
    Assert-NotNull $updatedRd

    # delete the role definition
    $deletedRd = Remove-AzureRmRoleDefinition -Id $rd.Id -Force -PassThru
    Assert-AreEqual $rd.Name $deletedRd.Name

    # try to read the deleted role definition
    $readRd = Get-AzureRmRoleDefinition -Name $rd.Name
    Assert-Null $readRd
}

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition remove.
#>
function Test-RDRemove
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    # Create a role definition at RG Scope.
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("65E1D983-ECF4-42D4-8C08-5B1FD6E86335")

	$subscription = Get-AzureRmSubscription
	$resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
	
	$scope = "/subscriptions/" + $subscription[0].SubscriptionId
	$rgScope = "/subscriptions/" + $subscription[0].SubscriptionId + "/resourceGroups/" + $resourceGroups[0].ResourceGroupName

	$roleDef = Get-AzureRmRoleDefinition -Name "Reader"
	$roleDef.Id = $null
	$roleDef.Name = "CustomRole123_65E1D983-ECF4-42D4-8C08-5B1FD6E86335"
	$roleDef.Description = "Test Remove RD"
    $roleDef.AssignableScopes[0] = $rgScope

    $Rd = New-AzureRmRoleDefinition -Role $roleDef
    Assert-NotNull $Rd


    # try to delete the role definition with subscription scope - should fail
	$badIdException = "RoleDefinitionDoesNotExist: The specified role definition with ID '" + $Rd.Id + "' does not exist."
	Assert-Throws { Remove-AzureRmRoleDefinition -Id $Rd.Id -Scope $scope -Force -PassThru} $badIdException

	# try to delete the role definition without specifying scope (default to subscription scope) - should fail
	$badIdException = "RoleDefinitionDoesNotExist: The specified role definition with ID '" + $Rd.Id + "' does not exist."
	Assert-Throws { Remove-AzureRmRoleDefinition -Id $Rd.Id -Scope $scope -Force -PassThru} $badIdException

	# try to delete the role definition with RG scope - should succeed
	$deletedRd = Remove-AzureRmRoleDefinition -Id $Rd.Id -Scope $rgScope -Force -PassThru
	Assert-AreEqual $Rd.Name $deletedRd.Name
}

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition Get.
#>
function Test-RDGet
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"
	
	$subscription = Get-AzureRmSubscription

	$resource = Get-AzureRmResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."
	
	$subScope = "/subscriptions/" + $subscription[0].SubscriptionId
	$rgScope = "/subscriptions/" + $subscription[0].SubscriptionId + "/resourceGroups/" + $resource.ResourceGroupName
	$resourceScope = $resource.ResourceId
	
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("99CC0F56-7395-4097-A31E-CC63874AC5EF")
	$roleDef1 = Get-AzureRmRoleDefinition -Name "Reader"
	$roleDef1.Id = $null
	$roleDef1.Name = "CustomRole_99CC0F56-7395-4097-A31E-CC63874AC5EF"
	$roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $subScope 

    $roleDefSubScope = New-AzureRmRoleDefinition -Role $roleDef1
    Assert-NotNull $roleDefSubScope

	[Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("E3CC9CD7-9D0A-47EC-8C75-07C544065220")
	$roleDef1.Id = $null
	$roleDef1.Name = "CustomRole_E3CC9CD7-9D0A-47EC-8C75-07C544065220"
	$roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $rgScope

    $roleDefRGScope = New-AzureRmRoleDefinition -Role $roleDef1
    Assert-NotNull $roleDefRGScope
	
	[Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("8D2E860C-5640-4B7C-BD3C-80940C715033")
	$roleDef1.Id = $null
	$roleDef1.Name = "CustomRole_8D2E860C-5640-4B7C-BD3C-80940C715033"
	$roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $resourceScope

    $roleDefResourceScope = New-AzureRmRoleDefinition -Role $roleDef1
    Assert-NotNull $roleDefResourceScope

    # try to get the role definition with subscription scope
	$roles1 = Get-AzureRmRoleDefinition -Scope $subScope	
	### TODO: Check for only sub scope role being present

	# try to get the role definition with subscription scope
	$roles2 = Get-AzureRmRoleDefinition -Scope $rgScope
	### TODO: Check for only sub and RG scope role being present

	# try to get the role definition with subscription scope
	$roles3 = Get-AzureRmRoleDefinition -Scope $resourceScope
	### TODO: Check for all sub, RG and resource scope role being present


	# delete roles
	$deletedRd = Remove-AzureRmRoleDefinition -Id $roleDefSubScope.Id -Scope $subScope -Force -PassThru
	Assert-AreEqual $roleDefSubScope.Name $deletedRd.Name

	# delete roles
	$deletedRd = Remove-AzureRmRoleDefinition -Id $roleDefRGScope.Id -Scope $rgScope -Force -PassThru
	Assert-AreEqual $roleDefRGScope.Name $deletedRd.Name

	# delete roles
	$deletedRd = Remove-AzureRmRoleDefinition -Id $roleDefResourceScope.Id -Scope $resourceScope -Force -PassThru
	Assert-AreEqual $roleDefResourceScope.Name $deletedRd.Name
}

<#
.SYNOPSIS
Tests validate input parameters 
#>
function Test-RdValidateInputParameters ($cmdName)
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    # Note: All below scenarios are invalid, we'll expect an exception during scope validation so the ID parameter doesn't need to be a valid one. 

    # Test
    # Check if Scope is valid.
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name' should begin with '/subscriptions/<subid>/resourceGroups'."
    Assert-Throws { invoke-expression ($cmdName + " -Scope `"" + $scope  + "`" -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25") } $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25} $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/' should not have any empty part."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25} $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name' should begin with '/subscriptions/<subid>/resourceGroups/<groupname>/providers'."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25} $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername' should have at least one pair of resource type and resource name. e.g. '/subscriptions/<subid>/resourceGroups/<groupname>/providers/<providername>/<resourcetype>/<resourcename>'."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25} $invalidScope
}


<#
.SYNOPSIS
Tests validate input parameters 
#>
function Test-RdValidateInputParameters2 ($cmdName)
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    # Note: All below scenarios are invalid, we'll expect an exception during scope validation so the ID parameter doesn't need to be a valid one. 

	$roleDef = Get-AzureRmRoleDefinition -Name "Reader"
	$roleDef.Name = "CustomRole_99CC0F56-7395-4097-A31E-CC63874AC5EF"
	$roleDef.Description = "Test Get RD"

    # Test
    # Check if Scope is valid.
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name' should begin with '/subscriptions/<subid>/resourceGroups'."
    $roleDef.AssignableScopes[0] = $scope;
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    $roleDef.AssignableScopes[0] = $scope;
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/' should not have any empty part."
    $roleDef.AssignableScopes[0] = $scope;
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name' should begin with '/subscriptions/<subid>/resourceGroups/<groupname>/providers'."
    $roleDef.AssignableScopes[0] = $scope;
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope
    
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername' should have at least one pair of resource type and resource name. e.g. '/subscriptions/<subid>/resourceGroups/<groupname>/providers/<providername>/<resourcetype>/<resourcename>'."
    $roleDef.AssignableScopes[0] = $scope;
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope
}