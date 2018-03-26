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
    # Basic positive case - read from file
    $rdName = 'CustomRole Tests Role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("ee78fa8a-3cdd-418e-a4d8-949b57a33dcd")
    New-AzureRmRoleDefinition -InputFile .\Resources\NewRoleDefinition.json
    
    $rd = Get-AzureRmRoleDefinition -Name $rdName
	Assert-AreEqual "Test role" $rd.Description 
	Assert-AreEqual $true $rd.IsCustom
	Assert-NotNull $rd.Actions
	Assert-AreEqual "Microsoft.Authorization/*/read" $rd.Actions[0]
	Assert-AreEqual "Microsoft.Support/*" $rd.Actions[1]
	Assert-NotNull $rd.AssignableScopes
    Assert-Null $rd.DataActions
    Assert-Null $rd.NotDataActions
	
	# Basic positive case - read from object
	$roleDef = Get-AzureRmRoleDefinition -Name "Reader"
	$roleDef.Id = $null
	$roleDef.Name = "New Custom Reader"
	$roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
	$roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f"

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("678c13e9-6637-4471-8414-e95f7a660b0b")
	New-AzureRmRoleDefinition -Role $roleDef
	$addedRoleDef = Get-AzureRmRoleDefinition -Name "New Custom Reader"

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
    # Does not throw when getting a non-existing role assignment
    $rdName = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $rdNull = Get-AzureRmRoleDefinition -Name $rdName
    Assert-Null $rdNull

    $rdId = '85E460B3-89E9-48BA-9DCD-A8A99D64A674'
    
    $badIdException = "Cannot find role definition with id '" + $rdId + "'."

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

    $removeRoleException = "The specified role definition with ID '" + $rdId + "' does not exist."
    # Throws on trying to delete a role that does not exist
    $missingSubscription = "MissingSubscription: The request did not have a provided subscription. All requests must have an associated subscription Id."
    Assert-Throws { Remove-AzureRmRoleDefinition -Id $rdId -Force} $removeRoleException
}

<#
.SYNOPSIS
Tests verify positive scenarios for RoleDefinitions.
#>
function Test-RDPositiveScenarios
{
    # Setup
    # Create a role definition with Name rdNamme.
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("0a0e83bc-50b9-4c4d-b2c2-3f41e1a8baf2")
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
Tests verify roledefinition update with interchanged assignablescopes.
#>
function Test-RDUpdate
{

    # Create a role definition with Name rdNamme.
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("3d95b97a-5745-4c39-950c-0b608dea635f")
    $rd = New-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json
    $rd = Get-AzureRmRoleDefinition -Name $rdName

    # Update the role definition with action that was created in the step above.
    $scopes = $rd.AssignableScopes | foreach { $_ }
    $rd.AssignableScopes.Clear()
    $rd.AssignableScopes.Add('/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/resourcegroups/AzureStackSDK')
    for($i = $scopes.Count - 1 ; $i -ge 0; $i--){
        $rd.AssignableScopes.Add($scopes[$i])
    }
    $updatedRd = Set-AzureRmRoleDefinition -Role $rd
    Assert-NotNull $updatedRd

    # Cleanup
    $deletedRd = Remove-AzureRmRoleDefinition -Id $rd.Id -Force -PassThru
    Assert-AreEqual $rd.Name $deletedRd.Name
}

<#
.SYNOPSIS
Tests verify roledefinition create with invalid scope.
#>
function Test-RDCreateFromFile
{
    # Setup
    # Create a role definition with invalid assignable scopes.
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("4482e4d1-8757-4d67-b3c1-5c8ccee3fdcc")
    $badScopeException = "Scope '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/ResourceGroups' should have even number of parts."
    Assert-Throws { $rd = New-AzureRmRoleDefinition -InputFile .\Resources\InvalidRoleDefinition.json } $badScopeException
}

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition remove.
#>
function Test-RDRemove
{
    # Setup
    # Create a role definition at RG Scope.
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("ec2eda29-6d32-446b-9070-5054af630991")

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
    $subscription = Get-AzureRmSubscription

    $resource = Get-AzureRmResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."
    
    $subScope = "/subscriptions/" + $subscription[0].SubscriptionId
    $rgScope = "/subscriptions/" + $subscription[0].SubscriptionId + "/resourceGroups/" + $resource.ResourceGroupName
    $resourceScope = $resource.ResourceId
    
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("d4fc9f7d-2f66-49e9-ac32-d0586105c587")
    $roleDef1 = Get-AzureRmRoleDefinition -Name "Reader"
    $roleDef1.Id = $null
    $roleDef1.Name = "CustomRole_99CC0F56-7395-4097-A31E-CC63874AC5EF"
    $roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $subScope 

    $roleDefSubScope = New-AzureRmRoleDefinition -Role $roleDef1
    Assert-NotNull $roleDefSubScope

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("6f699c1d-055a-4b2b-93ff-51e4be914a67")
    $roleDef1.Id = $null
    $roleDef1.Name = "CustomRole_E3CC9CD7-9D0A-47EC-8C75-07C544065220"
    $roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $rgScope

    $roleDefRGScope = New-AzureRmRoleDefinition -Role $roleDef1
    Assert-NotNull $roleDefRGScope
    
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("ede64d68-3f7d-4495-acc7-5fc2afdfe0ea")
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
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RoleDefinitionDataActionsCreateTests
{
    # Setup
    # Basic positive case - read from file
    $rdName = 'CustomRole Tests Role New'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("e3efe8c9-d9ae-4f0e-838d-57ce43068a13")
    New-AzureRmRoleDefinition -InputFile .\Resources\DataActionsRoleDefinition.json
    
    $rd = Get-AzureRmRoleDefinition -Name $rdName
    Assert-AreEqual "Test role" $rd.Description 
    Assert-AreEqual $true $rd.IsCustom
    Assert-NotNull $rd.DataActions
    Assert-AreEqual "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*" $rd.DataActions[0]
    Assert-NotNull $rd.NotDataActions
    Assert-AreEqual "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write" $rd.NotDataActions[0]
    Assert-NotNull $rd.AssignableScopes
    Assert-Null $rd.Actions
    Assert-Null $rd.NotActions
    
    # Basic positive case - read from object
    $roleDef = Get-AzureRmRoleDefinition -Name "Reader"
    $roleDef.Id = $null
    $roleDef.Name = "New Custom Reader"
    $roleDef.DataActions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write")
    $roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f"

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("3be51641-acdb-4f4a-801f-a93da8c5762d")
    New-AzureRmRoleDefinition -Role $roleDef
    $addedRoleDef = Get-AzureRmRoleDefinition -Name "New Custom Reader"

    Assert-NotNull $addedRoleDef.Actions
    Assert-AreEqual $roleDef.Description $addedRoleDef.Description
    Assert-AreEqual $roleDef.AssignableScopes $addedRoleDef.AssignableScopes
    Assert-AreEqual $true $addedRoleDef.IsCustom

    Remove-AzureRmRoleDefinition -Id $addedRoleDef.Id -Force
    Remove-AzureRmRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RDGetCustomRoles
{
    # Setup
    # Basic positive case - read from file
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("3d95b97a-5745-4c39-950c-0b608dea635f")
    $rd = New-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json
    $rd = Get-AzureRmRoleDefinition -Name $rdName

    $roles = Get-AzureRmRoleDefinition -Custom 
    Assert-NotNull $roles
    foreach($roleDefinition in $roles){
        Assert-AreEqual $roleDefinition.IsCustom $true
    }
    
    # Basic positive case - read from object
    Remove-AzureRmRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RDGetAtScopeFilterRoles
{
    # Setup
    # Basic positive case - read from file
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("3d95b97a-5745-4c39-950c-0b608dea635f")
    $rd = New-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json
    
    $rd = Get-AzureRmRoleDefinition -Name $rdName -AtScopeAndBelow
    Assert-AreEqual "Test role" $rd.Description 
    Assert-AreEqual $true $rd.IsCustom
    Assert-NotNull $rd.AssignableScopes
    Assert-NotNull $rd.Actions
    Assert-NotNull $rd.NotActions
    
    # Basic positive case - read from object
    Remove-AzureRmRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests validate input parameters 
#>
function Test-RdValidateInputParameters ($cmdName)
{
    # Setup
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
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
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
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
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

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition Get with filters.
#>
function Test-RDFilter
{
    # Setup 
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("5282481f-37e6-40d3-bec0-b797e0496d3c")
    $readerRole = Get-AzureRmRoleDefinition -Name "Reader"
    Assert-NotNull $readerRole
    Assert-AreEqual $readerRole.Name "Reader"

    $customRoles = Get-AzureRmRoleDefinition -Custom
    Assert-NotNull $customRoles
    foreach($role in $customRoles){
        Assert-NotNull $role
        Assert-AreEqual $role.IsCustom $true
    }
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RDDataActionsNegativeTestCases
{
    # Setup
    # Basic positive case - read from file
    $rdName = 'Another tests role'
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("3d95b97a-5745-4c39-950c-0b608dea635f")
    $rd = New-AzureRmRoleDefinition -InputFile .\Resources\RoleDefinition.json
    $rd = Get-AzureRmRoleDefinition -Name $rdName

    $createdRole = Get-AzureRmRoleDefinition -Name $rdName
    Assert-NotNull $createdRole

    $expectedExceptionForActions = "'Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*' does not match any of the actions supported by the providers."
    $createdRole.Actions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*")
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("0309cc23-a0be-471f-abeb-dd411a8422c7")
    Assert-Throws { New-AzureRmRoleDefinition -Role $createdRole } $expectedExceptionForActions
    $createdRole.Actions.Clear()

    $createdRole.DataActions.Add("Microsoft.Authorization/*/read")
    $expectedExceptionForDataActions = "The resouce provider referenced in the action has not published its operations."
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("06801870-23ba-41ee-8bda-b0e2360164a8")
    Assert-Throws { New-AzureRmRoleDefinition -Role $createdRole} $expectedExceptionForDataActions
    $createdRole.DataActions.Clear()

    $createdRole.DataActions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*")
    $createdRole.NotActions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*")
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("e4c2893e-f945-4831-8b9f-3568eff03170")
    Assert-Throws { New-AzureRmRoleDefinition -Role $createdRole } $expectedExceptionForActions
    $createdRole.NotActions.Clear()

    $createdRole.NotDataActions.Add("Microsoft.Authorization/*/read")
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("a8ac9ed7-0ce6-4425-a221-c3d4c3063dc2")
    Assert-Throws { New-AzureRmRoleDefinition -Role $createdRole } $expectedExceptionForDataActions
    $createdRole.NotDataActions.Clear()

    # Basic positive case - read from object
    Remove-AzureRmRoleDefinition -Id $createdRole.Id -Force
}