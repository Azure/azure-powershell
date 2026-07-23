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
function Test-RDWithAbacConditionsGet {
    # Setup
    $subscription = $(Get-AzContext).Subscription

    $resource = Get-AzResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    $subScope = "/subscriptions/" + $subscription[0].SubscriptionId
    $rgScope = "/subscriptions/" + $subscription[0].SubscriptionId + "/resourceGroups/" + $resource.ResourceGroupName
    $resourceScope = $resource.ResourceId

    # Task 1: Get Reader role, verify permissions structure exists but no condition
    $roleDef1 = Get-AzRoleDefinition -Name "Reader"
    Assert-AreEqual $roleDef1.Name "Reader"
    Assert-AreEqual $false $roleDef1.IsCustom

    # Verify Permissions property exists and has content
    Assert-NotNull $roleDef1.Permissions
    Assert-True { $roleDef1.Permissions.Count -gt 0 }
    Assert-NotNull $roleDef1.Permissions[0].Actions
    Assert-True { $roleDef1.Permissions[0].Actions.Count -gt 0 }

    # Task 2: Get Key Vault Data Access Administrator role, verify condition exists in Permissions
    $roleDef2 = Get-AzRoleDefinition -Id 8b54135c-b56d-4d72-a534-26097cfdc8d8
    Assert-AreEqual $false $roleDef2.IsCustom

    # Verify Permissions structure with condition
    Assert-NotNull $roleDef2.Permissions
    Assert-True { $roleDef2.Permissions.Count -gt 0 }
    Assert-NotNull $roleDef2.Permissions[0].Actions
    
    # Find the permission entry with condition
    $conditionPermission = $roleDef2.Permissions | Where-Object { $_.Condition -ne $null } | Select-Object -First 1
    Assert-NotNull $conditionPermission "Expected at least one permission with a condition"
    Assert-NotNull $conditionPermission.Condition
    Assert-NotNull $conditionPermission.ConditionVersion
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RoleDefinitionCreateTests {
    # Setup
    # Basic positive case - read from file
    $rdName = 'CustomRole Tests Role'
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\NewRoleDefinition.json
    New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId ee78fa8a-3cdd-418e-a4d8-949b57a33dcd

    $rd = Get-AzRoleDefinition -Name $rdName
    Assert-AreEqual "Test role" $rd.Description
    Assert-AreEqual $true $rd.IsCustom
    Assert-NotNull $rd.Permissions
    Assert-NotNull $rd.Permissions[0].Actions
    Assert-AreEqual "Microsoft.Authorization/*/read" $rd.Permissions[0].Actions[0]
    Assert-AreEqual "Microsoft.Support/*" $rd.Permissions[0].Actions[1]
    Assert-NotNull $rd.AssignableScopes

    # Basic positive case - read from object
    $roleDef = Get-AzRoleDefinition -Name "Reader"
    $roleDef.Id = $null
    $roleDef.Name = "New Custom Reader"
    $roleDef.Permissions[0].Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
    $roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f"

    New-AzRoleDefinitionWithId -Role $roleDef -RoleDefinitionId 678c13e9-6637-4471-8414-e95f7a660b0b
    $addedRoleDef = Get-AzRoleDefinition -Name "New Custom Reader"

    Assert-NotNull $addedRoleDef.Permissions
    Assert-NotNull $addedRoleDef.Permissions[0].Actions
    Assert-AreEqual $roleDef.Description $addedRoleDef.Description
    Assert-AreEqual $roleDef.AssignableScopes $addedRoleDef.AssignableScopes
    Assert-AreEqual $true $addedRoleDef.IsCustom

    Remove-AzRoleDefinition -Id $addedRoleDef.Id -Force
    Remove-AzRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verify negative scenarios for RoleDefinitions
#>
function Test-RdNegativeScenarios {
    # Setup
    # Does not throw when getting a non-existing role assignment
    $rdName = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $rdNull = Get-AzRoleDefinition -Name $rdName
    Assert-Null $rdNull

    $rdId = '85E460B3-89E9-48BA-9DCD-A8A99D64A674'

    $badIdException = "Cannot find role definition with id '" + $rdId + "'."

    # Throws on trying to update the a role that does not exist
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\RoleDefinition.json
    Assert-Throws { Set-AzRoleDefinition -InputFile $inputFilePath } $badIdException

    # Role Defintion not provided.
    $roleDefNotProvided = "Parameter set cannot be resolved using the specified named parameters."
    Assert-Throws { Set-AzRoleDefinition } $roleDefNotProvided

    # Input file not provided.
    $roleDefNotProvided = "Cannot validate argument on parameter 'InputFile'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."
    Assert-Throws { Set-AzRoleDefinition -InputFile "" } $roleDefNotProvided
    Assert-Throws { Set-AzRoleDefinition -InputFile "" -Role $rdNull } $roleDefNotProvided

    # Role not provided.
    $roleDefNotProvided = "Cannot validate argument on parameter 'Role'. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again."
    Assert-Throws { Set-AzRoleDefinition -Role $rdNull } $roleDefNotProvided
    Assert-Throws { Set-AzRoleDefinition -InputFile $inputFilePath -Role $rd } $roleDefNotProvided

    #TODO add check for valid input file and valid role

    $removeRoleException = "The specified role definition with ID '" + $rdId + "' does not exist."
    # Throws on trying to delete a role that does not exist
    $missingSubscription = "MissingSubscription: The request did not have a provided subscription. All requests must have an associated subscription Id."
    Assert-Throws { Remove-AzRoleDefinition -Id $rdId -Force } $removeRoleException
}

<#
.SYNOPSIS
Tests verify positive scenarios for RoleDefinitions.
#>
function Test-RDPositiveScenarios {
    # Setup
    # Create a role definition with Name rdNamme.
    $rdName = 'Another tests role'
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\RoleDefinition.json
    $rd = New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId 0a0e83bc-50b9-4c4d-b2c2-3f41e1a8baf2
    $rd = Get-AzRoleDefinition -Name $rdName

    # Update the role definition with action that was created in the step above.
    $rd.Permissions[0].Actions.Add('Microsoft.Authorization/*/read')
    $updatedRd = Set-AzRoleDefinition -Role $rd
    Assert-NotNull $updatedRd

    # delete the role definition
    $deletedRd = Remove-AzRoleDefinition -Id $rd.Id -Force -PassThru
    Assert-AreEqual $rd.Name $deletedRd.Name

    # try to read the deleted role definition
    $readRd = Get-AzRoleDefinition -Name $rd.Name
    Assert-Null $readRd
}

<#
.SYNOPSIS
Tests verify roledefinition update with interchanged assignablescopes.
#>
function Test-RDUpdate {

    # Create a role definition with Name rdNamme.
    $rdName = 'Another tests role'
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\RoleDefinition.json
    $rd = New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId 3d95b97a-5745-4c39-950c-0b608dea635f
    $rd = Get-AzRoleDefinition -Name $rdName

    # Update the role definition with action that was created in the step above.
    $scopes = $rd.AssignableScopes | foreach { $_ }
    $rd.AssignableScopes.Clear()
    $rd.AssignableScopes.Add('/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/rbactest')
    for ($i = $scopes.Count - 1 ; $i -ge 0; $i--) {
        $rd.AssignableScopes.Add($scopes[$i])
    }
    $updatedRd = Set-AzRoleDefinition -Role $rd
    Assert-NotNull $updatedRd

    # Cleanup
    $deletedRd = Remove-AzRoleDefinition -Id $rd.Id -Force -PassThru
    Assert-AreEqual $rd.Name $deletedRd.Name
}

<#
.SYNOPSIS
Tests verify roledefinition create with invalid scope.
#>
function Test-RDCreateFromFile {
    # Setup
    # Create a role definition with invalid assignable scopes.
    $badScopeException = "Exception calling `"ExecuteCmdlet`" with `"0`" argument(s): `"Scope '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/ResourceGroups' should have even number of parts.`""
    try {
        $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\InvalidRoleDefinition.json
        $rd = New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId 4482e4d1-8757-4d67-b3c1-5c8ccee3fdcc
        Assert-AreEqual "This assertion shouldn't be hit'" "New-AzRoleDefinition should've thrown an exception"
    }
    catch {
        Assert-AreEqual $badScopeException $_
    }
}

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition remove.
#>
function Test-RDRemove {
    # Setup
    # Create a role definition at RG Scope.

    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait

    $scope = "/subscriptions/" + $subscription[0].SubscriptionId
    $rgScope = "/subscriptions/" + $subscription[0].SubscriptionId + "/resourceGroups/" + $resourceGroups[0].ResourceGroupName

    $roleDef = Get-AzRoleDefinition -Name "Reader"
    $roleDef.Id = $null
    $roleDef.Name = "CustomRole123_65E1D983-ECF4-42D4-8C08-5B1FD6E86335"
    $roleDef.Description = "Test Remove RD"
    $roleDef.AssignableScopes[0] = $rgScope

    $Rd = New-AzRoleDefinitionWithId -Role $roleDef -RoleDefinitionId ec2eda29-6d32-446b-9070-5054af630991
    Assert-NotNull $Rd

    # try to delete the role definition with subscription scope - should fail
    $badIdException = "RoleDefinitionDoesNotExist: The specified role definition with ID '" + $Rd.Id + "' does not exist."
    Assert-Throws { Remove-AzRoleDefinition -Id $Rd.Id -Scope $scope -Force -PassThru } $badIdException

    # try to delete the role definition without specifying scope (default to subscription scope) - should fail
    $badIdException = "RoleDefinitionDoesNotExist: The specified role definition with ID '" + $Rd.Id + "' does not exist."
    Assert-Throws { Remove-AzRoleDefinition -Id $Rd.Id -Scope $scope -Force -PassThru } $badIdException

    # try to delete the role definition with RG scope - should succeed
    $deletedRd = Remove-AzRoleDefinition -Id $Rd.Id -Scope $rgScope -Force -PassThru
    Assert-AreEqual $Rd.Name $deletedRd.Name
}

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition Get.
#>
function Test-RDGet {
    # Setup
    $subscription = $(Get-AzContext).Subscription

    $resource = Get-AzResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    $subScope = "/subscriptions/" + $subscription[0].SubscriptionId
    $rgScope = "/subscriptions/" + $subscription[0].SubscriptionId + "/resourceGroups/" + $resource.ResourceGroupName
    $resourceScope = $resource.ResourceId

    $roleDef1 = Get-AzRoleDefinition -Name "Reader"
    $roleDef1.Id = $null
    $roleDef1.Name = "CustomRole_99CC0F56-7395-4097-A31E-CC63874AC5EF"
    $roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $subScope

    $roleDefSubScope = New-AzRoleDefinitionWithId -Role $roleDef1 -RoleDefinitionId d4fc9f7d-2f66-49e9-ac32-d0586105c587
    Assert-NotNull $roleDefSubScope

    $roleDef1.Id = $null
    $roleDef1.Name = "CustomRole_E3CC9CD7-9D0A-47EC-8C75-07C544065220"
    $roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $rgScope

    $roleDefRGScope = New-AzRoleDefinitionWithId -Role $roleDef1 -RoleDefinitionId 6f699c1d-055a-4b2b-93ff-51e4be914a67
    Assert-NotNull $roleDefRGScope

    $roleDef1.Id = $null
    $roleDef1.Name = "CustomRole_8D2E860C-5640-4B7C-BD3C-80940C715033"
    $roleDef1.Description = "Test Get RD"
    $roleDef1.AssignableScopes[0] = $resourceScope

    $roleDefResourceScope = New-AzRoleDefinitionWithId -Role $roleDef1 -RoleDefinitionId ede64d68-3f7d-4495-acc7-5fc2afdfe0ea
    Assert-NotNull $roleDefResourceScope

    # try to get the role definition with subscription scope
    $roles1 = Get-AzRoleDefinition -Scope $subScope
    ### TODO: Check for only sub scope role being present

    # try to get the role definition with subscription scope
    $roles2 = Get-AzRoleDefinition -Scope $rgScope
    ### TODO: Check for only sub and RG scope role being present

    # try to get the role definition with subscription scope
    $roles3 = Get-AzRoleDefinition -Scope $resourceScope
    ### TODO: Check for all sub, RG and resource scope role being present


    # delete roles
    $deletedRd = Remove-AzRoleDefinition -Id $roleDefSubScope.Id -Scope $subScope -Force -PassThru
    Assert-AreEqual $roleDefSubScope.Name $deletedRd.Name

    # delete roles
    $deletedRd = Remove-AzRoleDefinition -Id $roleDefRGScope.Id -Scope $rgScope -Force -PassThru
    Assert-AreEqual $roleDefRGScope.Name $deletedRd.Name

    # delete roles
    $deletedRd = Remove-AzRoleDefinition -Id $roleDefResourceScope.Id -Scope $resourceScope -Force -PassThru
    Assert-AreEqual $roleDefResourceScope.Name $deletedRd.Name
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RoleDefinitionDataActionsCreateTests {
    # Setup
    # Basic positive case - read from file
    $rdName = 'CustomRole Tests Role New'
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\DataActionsRoleDefinition.json
    New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId e3efe8c9-d9ae-4f0e-838d-57ce43068a13

    $rd = Get-AzRoleDefinition -Name $rdName
    Assert-AreEqual "Test role" $rd.Description
    Assert-AreEqual $true $rd.IsCustom
    Assert-NotNull $rd.Permissions
    Assert-NotNull $rd.Permissions[0].DataActions
    Assert-AreEqual "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*" $rd.Permissions[0].DataActions[0]
    Assert-NotNull $rd.Permissions[0].NotDataActions
    Assert-AreEqual "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write" $rd.Permissions[0].NotDataActions[0]
    Assert-NotNull $rd.AssignableScopes
    Assert-True { $rd.Permissions[0].Actions.Count -eq 0 }
    Assert-True { $rd.Permissions[0].NotActions.Count -eq 0 }

    # Basic positive case - read from object
    $roleDef = Get-AzRoleDefinition -Name "Reader"
    $roleDef.Id = $null
    $roleDef.Name = "New Custom Reader"
    $roleDef.Permissions[0].DataActions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write")
    $roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590"

    New-AzRoleDefinitionWithId -Role $roleDef -RoleDefinitionId 3be51641-acdb-4f4a-801f-a93da8c5762d
    $addedRoleDef = Get-AzRoleDefinition -Name "New Custom Reader"

    Assert-NotNull $addedRoleDef.Permissions
    Assert-NotNull $addedRoleDef.Permissions[0].Actions
    Assert-AreEqual $roleDef.Description $addedRoleDef.Description
    Assert-AreEqual $roleDef.AssignableScopes $addedRoleDef.AssignableScopes
    Assert-AreEqual $true $addedRoleDef.IsCustom

    Remove-AzRoleDefinition -Id $addedRoleDef.Id -Force
    Remove-AzRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RDGetCustomRoles {
    # Setup
    # Basic positive case - read from file
    $rdName = 'Another tests role'
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\RoleDefinition.json
    $rd = New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId 3d95b97a-5745-4c39-950c-0b608dea635f
    $rd = Get-AzRoleDefinition -Name $rdName

    $roles = Get-AzRoleDefinition -Custom
    Assert-NotNull $roles
    foreach ($roleDefinition in $roles) {
        Assert-AreEqual $roleDefinition.IsCustom $true
    }

    # Basic positive case - read from object
    Remove-AzRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests validate input parameters
#>
function Test-RdValidateInputParameters ($cmdName) {
    # Setup
    # Note: All below scenarios are invalid, we'll expect an exception during scope validation so the ID parameter doesn't need to be a valid one.

    # Test
    # Check if Scope is valid.
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name' should begin with '/subscriptions/<subid>/resourceGroups'."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25 } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25 } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25 } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name' should begin with '/subscriptions/<subid>/resourceGroups/<groupname>/providers'."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25 } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername' should have at least one pair of resource type and resource name. e.g. '/subscriptions/<subid>/resourceGroups/<groupname>/providers/<providername>/<resourcetype>/<resourcename>'."
    Assert-Throws { &$cmdName -Scope $scope -Id D46245F8-7E18-4499-8E1F-784A6DA5BE25 } $invalidScope
}


<#
.SYNOPSIS
Tests validate input parameters
#>
function Test-RdValidateInputParameters2 ($cmdName) {
    # Setup
    # Note: All below scenarios are invalid, we'll expect an exception during scope validation so the ID parameter doesn't need to be a valid one.

    $roleDef = Get-AzRoleDefinition -Name "Reader"
    $roleDef.Name = "CustomRole_99CC0F56-7395-4097-A31E-CC63874AC5EF"
    $roleDef.Description = "Test Get RD"

    # Test
    # Check if Scope is valid.
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name' should begin with '/subscriptions/<subid>/resourceGroups'."
    $roleDef.AssignableScopes[0] = $scope
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    $roleDef.AssignableScopes[0] = $scope
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    $roleDef.AssignableScopes[0] = $scope
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name' should begin with '/subscriptions/<subid>/resourceGroups/<groupname>/providers'."
    $roleDef.AssignableScopes[0] = $scope
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername' should have at least one pair of resource type and resource name. e.g. '/subscriptions/<subid>/resourceGroups/<groupname>/providers/<providername>/<resourcetype>/<resourcename>'."
    $roleDef.AssignableScopes[0] = $scope
    Assert-Throws { &$cmdName -Role $roleDef } $invalidScope
}

<#
.SYNOPSIS
Verify positive and negative scenarios for RoleDefinition Get with filters.
#>
function Test-RDFilter {
    # Setup
    $readerRole = Get-AzRoleDefinition -Name "Reader"
    Assert-NotNull $readerRole
    Assert-AreEqual $readerRole.Name "Reader"

    $customRoles = Get-AzRoleDefinition -Custom
    Assert-NotNull $customRoles
    foreach ($role in $customRoles) {
        Assert-NotNull $role
        Assert-AreEqual $role.IsCustom $true
    }
}

<#
.SYNOPSIS
Tests verify scenarios for RoleDefinitions creation.
#>
function Test-RDDataActionsNegativeTestCases {
    # Setup
    # Basic positive case - read from file
    $rdName = 'Another tests role'
    $inputFilePath = Join-Path -Path $TestOutputRoot -ChildPath Resources\RoleDefinition.json
    $rd = New-AzRoleDefinitionWithId -InputFile $inputFilePath -RoleDefinitionId 3d95b97a-5745-4c39-950c-0b608dea635f
    $rd = Get-AzRoleDefinition -Name $rdName

    $createdRole = Get-AzRoleDefinition -Name $rdName
    Assert-NotNull $createdRole

    $expectedExceptionForActions = "'Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*' does not match any of the actions supported by the providers."
    $createdRole.Permissions[0].Actions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*")
    Assert-Throws { New-AzRoleDefinitionWithId -Role $createdRole -RoleDefinitionId 0309cc23-a0be-471f-abeb-dd411a8422c7 } $expectedExceptionForActions
    $createdRole.Permissions[0].Actions.Clear()

    $createdRole.Permissions[0].DataActions.Add("Microsoft.Authorization/*/read")
    $expectedExceptionForDataActions = "The resource provider referenced in the action has not published any data operations."
    Assert-Throws { New-AzRoleDefinitionWithId -Role $createdRole -RoleDefinitionId 06801870-23ba-41ee-8bda-b0e2360164a8 } $expectedExceptionForDataActions
    $createdRole.Permissions[0].DataActions.Clear()

    $createdRole.Permissions[0].DataActions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*")
    $createdRole.Permissions[0].NotActions.Add("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*")
    Assert-Throws { New-AzRoleDefinitionWithId -Role $createdRole -RoleDefinitionId e4c2893e-f945-4831-8b9f-3568eff03170 } $expectedExceptionForActions
    $createdRole.Permissions[0].NotActions.Clear()

    $createdRole.Permissions[0].NotDataActions.Add("Microsoft.Authorization/*/read")
    Assert-Throws { New-AzRoleDefinitionWithId -Role $createdRole -RoleDefinitionId a8ac9ed7-0ce6-4425-a221-c3d4c3063dc2 } $expectedExceptionForDataActions
    $createdRole.Permissions[0].NotDataActions.Clear()

    # Basic positive case - read from object
    Remove-AzRoleDefinition -Id $createdRole.Id -Force
}

<#
.SYNOPSIS
Tests creating a custom role definition using the new Permissions array format.
#>
function Test-RDNewPermissionsFormatCreate
{
    # Create a custom role using the new Permissions array format from PSObject
    $rdName = 'CustomRole Permissions Format Test'
    $subscription = (Get-AzContext).Subscription.Id
    
    $rd = Get-AzRoleDefinition -Name "Reader"
    $rd.Id = $null
    $rd.Name = $rdName
    $rd.Description = "Test role for new Permissions array format"
    $rd.Permissions[0].Actions.Clear()
    $rd.Permissions[0].Actions.Add("Microsoft.Resources/subscriptions/resourceGroups/read")
    $rd.Permissions[0].Actions.Add("Microsoft.Resources/deployments/*")
    $rd.AssignableScopes.Clear()
    $rd.AssignableScopes.Add("/subscriptions/$subscription")
    
    $createdRd = New-AzRoleDefinitionWithId -Role $rd -RoleDefinitionId a1b2c3d4-e5f6-7890-abcd-ef1234567890

    # Verify the role was created correctly
    Assert-NotNull $createdRd
    Assert-AreEqual $rdName $createdRd.Name
    Assert-AreEqual "Test role for new Permissions array format" $createdRd.Description
    Assert-AreEqual $true $createdRd.IsCustom

    # Verify Permissions structure
    Assert-NotNull $createdRd.Permissions
    Assert-True { $createdRd.Permissions.Count -eq 1 }
    Assert-NotNull $createdRd.Permissions[0].Actions
    Assert-AreEqual "Microsoft.Resources/subscriptions/resourceGroups/read" $createdRd.Permissions[0].Actions[0]
    Assert-AreEqual "Microsoft.Resources/deployments/*" $createdRd.Permissions[0].Actions[1]
    Assert-NotNull $createdRd.Permissions[0].NotActions
    Assert-True { $createdRd.Permissions[0].NotActions.Count -eq 0 }
    Assert-NotNull $createdRd.AssignableScopes

    # Cleanup
    Remove-AzRoleDefinition -Id $createdRd.Id -Force
}

<#
.SYNOPSIS
Tests updating a custom role definition using the new Permissions array format.
#>
function Test-RDNewPermissionsFormatUpdate
{
    # Create a custom role first
    $rdName = 'CustomRole Update Test'
    $subscription = (Get-AzContext).Subscription.Id
    
    $rd = Get-AzRoleDefinition -Name "Reader"
    $rd.Id = $null
    $rd.Name = $rdName
    $rd.Description = "Test role for new Permissions array format"
    $rd.Permissions[0].Actions.Clear()
    $rd.Permissions[0].Actions.Add("Microsoft.Resources/subscriptions/resourceGroups/read")
    $rd.Permissions[0].Actions.Add("Microsoft.Resources/deployments/*")
    $rd.AssignableScopes.Clear()
    $rd.AssignableScopes.Add("/subscriptions/$subscription")
    
    $createdRd = New-AzRoleDefinitionWithId -Role $rd -RoleDefinitionId b2c3d4e5-f6a7-8901-bcde-f23456789012
    Assert-NotNull $createdRd "Role creation with New-AzRoleDefinitionWithId should succeed"
    
    $rd = Get-AzRoleDefinition -Id $createdRd.Id
    Assert-NotNull $rd "Role should be retrievable by Id after creation"
    Assert-NotNull $rd.Permissions "Role should have Permissions array"
    $originalActionCount = $rd.Permissions[0].Actions.Count

    # Update the role by adding an action using new Permissions format
    $rd.Permissions[0].Actions.Add("Microsoft.Support/*")
    $updatedRd = Set-AzRoleDefinition -Role $rd

    Assert-NotNull $updatedRd
    Assert-NotNull $updatedRd.Permissions
    Assert-True { $updatedRd.Permissions[0].Actions.Count -eq ($originalActionCount + 1) }
    
    # Verify the new action is present
    $hasNewAction = $updatedRd.Permissions[0].Actions | Where-Object { $_ -eq "Microsoft.Support/*" }
    Assert-NotNull $hasNewAction "Updated role should have the new action"

    # Cleanup
    Remove-AzRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests deleting a custom role definition and verifying the returned Permissions array format.
#>
function Test-RDNewPermissionsFormatDelete
{
    # Create a custom role to delete
    $rdName = 'CustomRole Delete Test'
    $subscription = (Get-AzContext).Subscription.Id
    
    $rd = Get-AzRoleDefinition -Name "Reader"
    $rd.Id = $null
    $rd.Name = $rdName
    $rd.Description = "Test role for new Permissions array format"
    $rd.Permissions[0].Actions.Clear()
    $rd.Permissions[0].Actions.Add("Microsoft.Resources/subscriptions/resourceGroups/read")
    $rd.Permissions[0].Actions.Add("Microsoft.Resources/deployments/*")
    $rd.AssignableScopes.Clear()
    $rd.AssignableScopes.Add("/subscriptions/$subscription")
    
    $rd = New-AzRoleDefinitionWithId -Role $rd -RoleDefinitionId c3d4e5f6-a7b8-9012-cdef-345678901234
    $rd = Get-AzRoleDefinition -Name $rdName
    
    Assert-NotNull $rd
    Assert-NotNull $rd.Permissions

    # Delete the role and verify the returned object has Permissions structure
    $deletedRd = Remove-AzRoleDefinition -Id $rd.Id -Force -PassThru
    
    Assert-NotNull $deletedRd
    Assert-AreEqual $rd.Name $deletedRd.Name
    Assert-NotNull $deletedRd.Permissions
    Assert-True { $deletedRd.Permissions.Count -gt 0 }
    Assert-NotNull $deletedRd.Permissions[0].Actions

    # Verify the role no longer exists
    $readRd = Get-AzRoleDefinition -Name $rd.Name
    Assert-Null $readRd
}
