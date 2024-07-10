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
Tests retrieval of classic administrators
#>
function Test-RaClassicAdmins
{
    # Test
    $classic =  Get-AzRoleAssignment -IncludeClassicAdministrators

    # Assert
    Assert-NotNull $classic
    Assert-True { $classic.Length -ge 1 }
}

<#
.SYNOPSIS
Tests retrieval of classic administrators with subscription scope
#>
function Test-RaClassicAdminsWithScope
{
    # Setup
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'

    # Test
    $classic = Get-AzRoleAssignment -Scope $Scope -IncludeClassicAdministrators

    # Assert
    Assert-NotNull $classic
    Assert-True { $classic.Length -ge 1 }
}

<#
.SYNOPSIS
Tests retrieval of assignments to unknown principals/Users/Groups
This test will fail if the objectId is changed, the role assignment deleted or user is unable to know the type of
#>
function Test-UnknowndPrincipals
{
    # $objectId = "6f58a770-c06e-4012-b9f9-e5479c03d43f"
    # deleted PrincipalId
    $objectId = "aa77a68b-9acc-4b24-9e93-6e54f79f1820"
    $assignment = Get-AzRoleAssignment -ObjectId $objectId
    Assert-NotNull $assignment
    Assert-NotNull $assignment.ObjectType
    Assert-AreEqual $assignment.ObjectType "Unknown"
    Assert-NotNull $assignment.ObjectId
    Assert-AreEqual $assignment.ObjectId $objectId
}

<#
.SYNOPSIS
Tests verifies negative scenarios for RoleAssignments
#>
function Test-RaNegativeScenarios
{
    # Setup
    # Bad OID returns zero role assignments
    $badOid = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $badObjectResult = "Cannot find principal using the specified options"
    $assignments = Get-AzRoleAssignment -ObjectId $badOid
    Assert-AreEqual 0 $assignments.Count

    # Bad OID throws if Expand Principal Groups included
    Assert-Throws { Get-AzRoleAssignment -ObjectId $badOid -ExpandPrincipalGroups } $badObjectResult

    # Bad UPN
    $badUpn = 'nonexistent@provider.com'
    Assert-Throws { Get-AzRoleAssignment -UserPrincipalName $badUpn } $badObjectResult

    # Bad SPN
    $badSpn = 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb'
    Assert-Throws { Get-AzRoleAssignment -ServicePrincipalName $badSpn } $badObjectResult
}

<#
.SYNOPSIS
Tests verifies delete scenario for RoleAssignments by using PSRoleAssignment Object
#>
function Test-RaDeleteByPSRoleAssignment
{
    # Setup
    $definitionName = 'Reader'
    $principalId = "e9da4467-12ff-4334-8179-c99abf0ffd5a" # Change this if testing in another tenant
    $subscription = $(Get-AzContext).Subscription
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/PowershellTest'

    $expectedMessage = "Successfully removed role assignment for AD object 'e9da4467-12ff-4334-8179-c99abf0ffd5a' on scope '/subscriptions/" + $subscription[0].Id + "/resourceGroups/PowershellTest' with role definition 'Reader'"

    # Test
    $newAssignment = New-AzRoleAssignmentWithId -ObjectId $principalId -RoleDefinitionName $definitionName -Scope $scope -RoleAssignmentId 50fd727d-d1af-44ef-9a32-2431b835605e

    $result = Remove-AzRoleAssignment $newAssignment

    # Assert
    VerifyRoleAssignmentDeleted $newAssignment
    Assert-AreEqual $result $expectedMessage
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Scope
#>
function Test-RaByScope
{
    # Setup
    $definitionName = 'Automation Job Operator'
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a" # powershell-testmember
    $subscription = $(Get-AzContext).Subscription
    $resourceGroupName = "PowershellTest"
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroupName
    $assignmentScope = $scope +"/"
    # Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId -ObjectId $userId -RoleDefinitionName $definitionName -Scope $assignmentScope -RoleAssignmentId df9cf7c5-4985-46c8-add2-537cef460c2f

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope
    # Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

    # Start-TestSleep -Seconds 300

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Id
#>
function Test-RaById
{
    # Setup
    $definitionName = 'Reader'
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $subscription = $(Get-AzContext).Subscription
    $resourceGroupName = "PowershellTest"
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroupName
    $assignmentScope = $scope +"/"

    # Test
    $newAssignment = New-AzRoleAssignmentWithId -ObjectId $userId -RoleDefinitionName $definitionName -Scope $assignmentScope -RoleAssignmentId e4bdcb2a-ee09-41d8-b113-1dddc2fdb495

    $assignments = Get-AzRoleAssignment -RoleDefinitionId "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 0 }

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope
    # Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Resource Group
#>
function Test-RaByResourceGroup
{
    # Setup
    $definitionName = 'Contributor'
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    # powershell-testmember for testing
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $subscription = $(Get-AzContext).Subscription
    $resourceGroupName = "PowershellTest"

    # Test
    $newAssignment = New-AzRoleAssignmentWithId -ObjectId $userId -RoleDefinitionName $definitionName -ResourceGroupName $resourceGroupName -RoleAssignmentId 7b30dd13-c4fd-4083-b1e3-5ab3ae0ae574

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    # Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

    # Start-TestSleep -Seconds 300

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Resource
#>
function Test-RaByResource
{
    # Setup
    $definitionName = 'Virtual Machine User Login'
    # powershellgroup for test
    $groupId = "f9e08843-d2b7-4dbc-a584-5e88a7e229a6"
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."
    $resource = Get-AzResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId -ObjectId $groupId -RoleDefinitionName $definitionName -ResourceGroupName $resource.ResourceGroupName -ResourceType $resource.ResourceType -ResourceName $resource.Name -RoleAssignmentId db6e0231-1be9-4bcd-bf16-79de537439fe

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    # Assert-AreEqual $groups[0].DisplayName $newAssignment.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments for Service principal name
#>
function Test-RaByServicePrincipal
{
    # Setup
    $servicePrincipals = "3d9979c5-7de9-4cc5-bc9c-d63d365c5b5c"

    $definitionName = 'Reader'
    $Scope = '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590'

    # Test
    $newAssignment1 = New-AzRoleAssignmentWithId -ObjectId $servicePrincipals -RoleDefinitionName $definitionName -Scope $scope -RoleAssignmentId 238799bf-1a93-45d7-120d-f3edbaeb3bc7

    $definitionName = 'Contributor'
    # Test
    $appId = "2076eb2d-7a68-41f8-9645-4a77d9057d94"
    $newAssignment2 = New-AzRoleAssignmentWithId -ApplicationId $appId -RoleDefinitionName $definitionName -Scope $scope -RoleAssignmentId 238799bf-1593-45d7-120d-f3edbceb3bc7

    $assignments = Get-AzRoleAssignment -ObjectId $newAssignment2.ObjectId
    Assert-NotNull $assignments

    # cleanup
    DeleteRoleAssignment $newAssignment1

    # cleanup
    DeleteRoleAssignment $newAssignment2

    # Assert
    Assert-NotNull $newAssignment2
    Assert-AreEqual $definitionName $newAssignment2.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment2.Scope

    #Start-TestSleep -Seconds 300

    VerifyRoleAssignmentDeleted $newAssignment1
    VerifyRoleAssignmentDeleted $newAssignment2
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments for User Principal Name
#>
function Test-RaByUpn
{
    # Setup
    $definitionName = 'Virtual Machine Contributor'
    $users = Get-AzADUser | Select-Object -Last 1 -Wait
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
    $newAssignment = New-AzRoleAssignment -SignInName $users.UserPrincipalName `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups.ResourceGroupName

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments for User Principal Name with expand principal groups
#>
function Test-RaGetByUPNWithExpandPrincipalGroups
{
    # Setup
    $definitionName = 'Contributor'
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
    $newAssignment = New-AzRoleAssignment -SignInName $users[0].UserPrincipalName `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName

    $assignments = Get-AzRoleAssignment -SignInName $users[0].UserPrincipalName -ExpandPrincipalGroups

    Assert-NotNull $assignments
    foreach ($assignment in $assignments){
        Assert-NotNull $assignment
        if(!($assignment.ObjectType -eq "User" -or $assignment.ObjectType -eq "Group")){
            Assert-Throws "Invalid object type received."
        }
    }
    # cleanup
    DeleteRoleAssignment $newAssignment

    # Start-TestSleep -Seconds 300

    VerifyRoleAssignmentDeleted $newAssignment
}

<# .SYNOPSIS Tests validate correctness of returned permissions when logged in as the assigned user  #>
function Test-RaUserPermissions
{
    param([string]$rgName, [string]$action)
    # Test
    $rg = Get-AzResourceGroup
    $errorMsg = "User should have access to only 1 RG. Found: {0}" -f $rg.Count
    Assert-AreEqual 1 $rg.Count $errorMsg

    # User should not be able to create another RG as he doesnt have access to the subscription.
    Assert-Throws{ New-AzResourceGroup -Name 'NewGroupFromTest' -Location 'WestUS'}
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Scope irrespective of the case
#>
function Test-RaDeletionByScope
{
    # Setup
    $definitionName = 'Backup Operator'
    # $users = Get-AzADUser | Select-Object -First 1 -Wait
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    # Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $userId `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope `
                        -RoleAssignmentId 238799bf-1593-45d7-a90d-f3edbceb3bc7
    $newAssignment.Scope = $scope.toUpper()

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope
    # Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

    # Start-TestSleep -Seconds 300

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Scope irrespective of the case
#>
function Test-RaDeletionByScopeAtRootScope
{
    # Setup
    $definitionName = 'Billing Reader'
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/'
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users.Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope `
                        -RoleAssignmentId f3c560f8-afaa-4263-b1d7-e34e0ab49fc7
    $newAssignment.Scope = $scope.toUpper()

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope
    Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and validation of RoleAssignment properties for not null
#>
function Test-RaPropertiesValidation
{
    # Setup
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $subscription = $(Get-AzContext).Subscription
    $scope = '/subscriptions/'+$subscription[0].Id
    $roleDef = Get-AzRoleDefinition -Name "Reader"
    $roleDef.Id = "ff9cd1ab-d763-486f-b253-51a816c92aaf"
    $roleDef.Name = "Reader vm For Test"
    $roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
    $roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = '/subscriptions/'+$subscription[0].Id

    New-AzRoleDefinitionWithId -Role $roleDef -RoleDefinitionId 14347f95-76d9-48f6-932e-7997d99a45b2
    $rd = Get-AzRoleDefinition -Name "Reader vm For Test"

    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $userId `
                        -RoleDefinitionName "Reader vm For Test" `
                        -Scope $scope `
                        -RoleAssignmentId 584d33a3-b14d-4eb4-863e-0df67b178389

    $assignments = Get-AzRoleAssignment -ObjectId $userId
    Assert-NotNull $assignments

    foreach ($assignment in $assignments){
        Assert-NotNull $assignment
        Assert-NotNull $assignment.RoleDefinitionName
        Assert-AreNotEqual $assignment.RoleDefinitionName ""
    }

    DeleteRoleAssignment $newAssignment

    Assert-NotNull $newAssignment
    # Assert-AreEqual $roleDef.Name $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope

    VerifyRoleAssignmentDeleted $newAssignment
    # cleanup
    Remove-AzRoleDefinition -Id 14347f95-76d9-48f6-932e-7997d99a45b2 -Force
}

<#
.SYNOPSIS
Tests verifies creation and retrieval of a RoleAssignments using delegation flag
#>
function Test-RaDelegation
{
    # Setup
    $definitionName = 'Automation Runbook Operator'
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a" # powershell-testmember
    $subscription = $(Get-AzContext).Subscription
    $resourceGroupName = "PowershellTest"
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroupName
    $assignmentScope = $scope +"/"

    # Test
    $newAssignment = New-AzRoleAssignmentWithId -ObjectId $userId `
                        -RoleDefinitionName $definitionName `
                        -Scope $assignmentScope `
                        -RoleAssignmentId 84dbc1be-f2d3-4ad4-88e3-4a7b7de1a0fb `
                        -AllowDelegation

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope

    # cleanup
    DeleteRoleAssignment $newAssignment

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies get of RoleAssignment by Scope
#>
function Test-RaGetByScope
{
    # Setup
    $definitionName = 'Automation Operator'
    # $users = Get-AzADUser | Select-Object -First 1 -Wait
    $userId = "e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 2 -Wait
    $scope1 = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    $scope2 = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[1].ResourceGroupName
    # Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment1 = New-AzRoleAssignmentWithId `
                        -ObjectId $userId `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope1 `
                        -RoleAssignmentId 08fe91d5-b917-4d76-81d7-581ff5a99cab

    $newAssignment2 = New-AzRoleAssignmentWithId `
                        -ObjectId $userId `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope2 `
                        -RoleAssignmentId fa1a4d3b-2cca-406b-8956-6b6b32377641

    $ras = Get-AzRoleAssignment -ObjectId $userId `
            -RoleDefinitionName $definitionName `
            -Scope $scope1

    foreach ($assignment in $ras){
        Assert-NotNull $assignment
        Assert-NotNull $assignment.Scope
        Assert-AreNotEqual $assignment.Scope $scope2
    }
    # cleanup
    DeleteRoleAssignment $newAssignment1
    DeleteRoleAssignment $newAssignment2

    # Assert
    Assert-NotNull $newAssignment1
    Assert-AreEqual $definitionName $newAssignment1.RoleDefinitionName
    Assert-AreEqual $scope1 $newAssignment1.Scope
    # Assert-AreEqual $users[0].DisplayName $newAssignment1.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment1
}

<#
.SYNOPSIS
Tests verifies get of RoleAssignment using only the role definition name
#>
function Test-RaGetOnlyByRoleDefinitionName
{
    # Setup
    $definitionName = 'Owner'

    $ras = Get-AzRoleAssignment -RoleDefinitionName $definitionName

    Assert-NotNull $ras
    Assert-AreEqual $definitionName $ras[0].RoleDefinitionName
}

<#
.SYNOPSIS
Creates role assignment
#>
function CreateRoleAssignment
{
    param([string]$roleAssignmentId, [string]$userId, [string]$definitionName, [string]$resourceGroupName)

    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $userId `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroupName `
                        -RoleAssignmentId $roleAssignmentId

    return $newAssignment
}

<#
.SYNOPSIS
Delete role assignment
#>
function DeleteRoleAssignment
{
    param([Parameter(Mandatory=$true)] [object] $roleAssignment)

    Remove-AzRoleAssignment -ObjectId $roleAssignment.ObjectId `
                               -Scope $roleAssignment.Scope `
                               -RoleDefinitionName $roleAssignment.RoleDefinitionName
}

<#
.SYNOPSIS
Verifies that role assignment does not exist
#>
function VerifyRoleAssignmentDeleted
{
    param([Parameter(Mandatory=$true)] [object] $roleAssignment)

    # Start-TestSleep -Seconds 600

    $deletedRoleAssignment = Get-AzRoleAssignment -ObjectId $roleAssignment.ObjectId `
                                                     -Scope $roleAssignment.Scope `
                                                     -RoleDefinitionName $roleAssignment.RoleDefinitionName  | where {$_.roleAssignmentId -eq $roleAssignment.roleAssignmentId}
    Assert-Null $deletedRoleAssignment
}

<#
.SYNOPSIS
Verifies that creating an ra with an SP displays correct error message
#>
function Test-RaCreatedBySP
{
    # Prerequisite: Conect to azure with SP
    # Create role assignment
    # powershell-testmember's PrincipalId
    $testUser = "3d9979c5-7de9-4cc5-bc9c-d63d365c5b5c"
    $Scope = '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590'

    $assignment = New-AzRoleAssignmentWithId -ObjectId $testUser -RoleDefinitionName 'Reader' -Scope $Scope -RoleAssignmentId 3d9979c5-7de9-4cc5-bc9c-d63d365c5b44

    Assert-NotNull $assignment
}

<#
.SYNOPSIS
Create role assignment with v1 conditions
#>
function Test-RaWithV1Conditions{

    #Given
    # Built-in role "Storage Blob Data Reader"'s Id
    $RoleDefinitionId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1"
    # powershell-testmember's PrincipalId
    $PrincipalId ="e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'
    $Description = "This test should not fail"
    $StorageAccount = 'storagecontainer4test'
    $Condition = "@Resource[Microsoft.Storage/storageAccounts:name] StringEquals '$StorageAccount'"
    $ConditionVersion = "1.0"

    Assert-Throws {New-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -Description $Description -Condition $Condition -ConditionVersion $ConditionVersion} "Argument -ConditionVersion must be greater or equal than 2.0"
}

<#
.SYNOPSIS
Create role assignment with v2 conditions
#>
function Test-RaWithV2Conditions{
    #Given
    # Built-in role "Storage Blob Data Reader"'s Id
    $RoleDefinitionId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1"
    # powershellgroup's PrincipalId
    $PrincipalId ="f9e08843-d2b7-4dbc-a584-5e88a7e229a6"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'
    $Description = "This test should not fail"
    $StorageAccount = 'storagecontainer4test'
    $Condition = "@Resource[Microsoft.Storage/storageAccounts:name] StringEquals '$StorageAccount'"
    $ConditionVersion = "2.0"

    #When
    $data = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId 734de5f5-c680-41c0-8beb-67b98c3539d2 `
    -Description $Description -Condition $Condition -ConditionVersion $ConditionVersion

    #Then
    Assert-NotNull $data "The role assignment was not created succesfully"
    Assert-AreEqual $RoleDefinitionId $data.RoleDefinitionId "Assertion failed because expected RoleDefinitionId '$RoleDefinitionId' does not match actual '$data.RoleDefinitionId'"
    Assert-AreEqual $PrincipalId $data.ObjectId "Assertion failed because expected PrincipalId '$PrincipalId' does not match actual '$data.ObjectId'"
    Assert-AreEqual $Scope $data.Scope "Assertion failed because expected Scope '$Scope' does not match actual '$data.Scope'"
    Assert-AreEqual $Description $data.Description "Assertion failed because expected Description '$Description' does not match actual '$data.Description'"
    Assert-AreEqual $Condition $data.Condition "Assertion failed because expected Condition '$Condition' does not match actual '$data.Condition'"
    Assert-AreEqual $ConditionVersion $data.ConditionVersion "Assertion failed because expected ConditionVersion '$ConditionVersion' does not match actual '$data.ConditionVersion'"

    #Cleanup
    Remove-AzRoleAssignment -InputObject $data
}

<#
.SYNOPSIS
Create role assignment with v2 conditions
#>
function Test-RaWithV2ConditionsOnly{
    #Given
    # Built-in role "Storage Blob Data Reader"'s Id
    $RoleDefinitionId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1"
    # powershellgroup's PrincipalId
    $PrincipalId ="f9e08843-d2b7-4dbc-a584-5e88a7e229a6"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'
    $Description = "This test should not fail"
    $StorageAccount = 'storagecontainer4test'
    $Condition = "@Resource[Microsoft.Storage/storageAccounts:name] StringEquals '$StorageAccount'"

    #When
    $assignment = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -Description $Description -Condition $Condition -roleAssignmentId 734de5f5-c680-41c0-8beb-67b98c3539d2

    #Then
    Assert-NotNull $assignment "The role assignment was not created succesfully"
    Assert-AreEqual $RoleDefinitionId $assignment.RoleDefinitionId "Assertion failed because expected RoleDefinitionId '$RoleDefinitionId' does not match actual '$data.RoleDefinitionId'"
    Assert-AreEqual $PrincipalId $assignment.ObjectId "Assertion failed because expected PrincipalId '$PrincipalId' does not match actual '$data.ObjectId'"
    Assert-AreEqual $Scope $assignment.Scope "Assertion failed because expected Scope '$Scope' does not match actual '$data.Scope'"
    Assert-AreEqual $Description $assignment.Description "Assertion failed because expected Description '$Description' does not match actual '$data.Description'"
    Assert-AreEqual $Condition $assignment.Condition "Assertion failed because expected Condition '$Condition' does not match actual '$data.Condition'"
    Assert-AreEqual "2.0" $assignment.ConditionVersion "Assertion failed because expected ConditionVersion '$ConditionVersion' does not match actual '$data.ConditionVersion'"

    #Cleanup
    Remove-AzRoleAssignment -InputObject $assignment
}

<#
.SYNOPSIS
Create role assignment with v2 conditions
#>
function Test-RaWithV2ConditionVersionOnly{
    #Given
    # Built-in role "Storage Blob Data Reader"'s Id
    $RoleDefinitionId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1"
    # powershell-testmember's PrincipalId
    $PrincipalId ="e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'
    $Description = "This test should not fail"
    $ConditionVersion = "2.0"

    Assert-Throws {New-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -Description $Description -ConditionVersion $ConditionVersion} "If -ConditionVersion is set -Condition can not be empty."
}

<#
.SYNOPSIS
update role assignment with v2 conditions
#>
function Test-UpdateRa{
    # Not activated: "RoleAssignmentUpdateNotPermitted"
    # Given
    # Built-in role "Storage Blob Data Reader"'s Id
    $RoleDefinitionId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1"
    # powershellgroup's PrincipalId
    $PrincipalId = "f9e08843-d2b7-4dbc-a584-5e88a7e229a6"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'
    $Description1 = "This test should not fail"
    $StorageAccount = 'storagecontainer4test'
    $Condition1 = "@Resource[Microsoft.Storage/storageAccounts:name] StringEquals '$StorageAccount'"
    $ConditionVersion = "2.0"

    # When
    $assignment = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -Description $Description1 `
    -Condition $Condition1 -ConditionVersion $ConditionVersion -RoleAssignmentId 734de5f5-c680-41c0-8beb-67b98c3539d2

    $Description2 = "This test should have completed"
    $Condition2 = "true"

    $assignment.Description = $Description2
    $assignment.Condition = $Condition2

    $updatedAssignment = Set-AzRoleAssignment -InputObject $assignment -PassThru

    # Then
    # Assert intended target changed
    Assert-AreNotEqual $Description1 $updatedAssignment.Description "Test failed: description didn't change after update call"
    Assert-AreNotEqual $Condition1 $updatedAssignment.Condition "Test failed: condition didn't change after update call"
    Assert-AreEqual $Description2 $updatedAssignment.Description "Test failed: description didn't change as demand"
    Assert-AreEqual $Condition2 $updatedAssignment.Condition "Test failed: condition didn't change as demand"

    # Assert there where no unintended changes
    Assert-AreEqual $PrincipalId $updatedAssignment.ObjectId "Test failed: ObjectId shouldn't have changed after update call"
    Assert-AreEqual $Scope $updatedAssignment.Scope "Test failed: Scope shouldn't have changed after update call"
    Assert-AreEqual $RoleDefinitionId $updatedAssignment.RoleDefinitionId "Test failed: RoleDefinitionId shouldn't have changed after update call"

    # Consider deleting  bellow assert for certain tests as we might overwrite condition version behind the seams
    Assert-AreEqual $ConditionVersion $updatedAssignment.ConditionVersion "Test failed: ConditionVersion shouldn't have changed after update call"
    Assert-AreEqual $assignment.RoleAssignmentId $updatedAssignment.RoleAssignmentId "Test failed: RoleAssignmentId shouldn't have changed after update call"

    #Cleanup
    Remove-AzRoleAssignment -InputObject $updatedAssignment
}

<#
.SYNOPSIS
Verifies that role assignment maps to a group
#>
function Test-CreateRAForGroup
{
    #Given
    $RoleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    $PrincipalId ="f9e08843-d2b7-4dbc-a584-5e88a7e229a6"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'

    #When
    $data = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId 238799bf-1593-45d7-a90d-f3edbceb3b77

    Assert-True {$data.ObjectType -eq "Group"}

    #cleanup
    Remove-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId
}

<#
.SYNOPSIS
Verifies that role assignment maps to a user (not "Guest")
#>
function Test-CreateRAForGuest
{
    #Given
    $RoleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    $PrincipalId ="6a8f900b-a032-4f5e-b8e8-89e0f57e8e0d"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'

    #When
    $data = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId 238799bf-1593-45d7-a90d-f3edbceb3b79

    Assert-True {$data.ObjectType -eq "User"}

    #cleanup
    Remove-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId
}

<#
.SYNOPSIS
Verifies that role assignment maps to a user (not "Member")
#>
function Test-CreateRAForMember
{
    #Given
    $RoleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    $PrincipalId ="e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'

    #When
    $data = New-AzRoleAssignmentWithId -ObjectId $PrincipalId  -Scope $Scope  -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId 238799bf-1593-45d7-a90d-f3edbceb3b79

    Assert-True {$data.ObjectType -eq "User"}

    #cleanup
    Remove-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId
}

<#
.SYNOPSIS
Verifies that role assignment maps to a ServicePrincipal
#>
function Test-CreateRAForServicePrincipal
{
    #Given
    # Built-in role "Storage Blob Data Reader"'s Id
    $RoleDefinitionId = "2a2b9908-6ea1-4ae2-8e65-a410df84e7d1"
    $PrincipalId ="f2dc21ac-702a-4bde-a4ce-146edf751d81"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'

    #When
    $data = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId 238799bf-1593-45d7-a90d-f30dbceb3b79

    Assert-True {$data.ObjectType -eq "ServicePrincipal"}

    #cleanup
    Remove-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId
}

<#
.SYNOPSIS
Verifies that role assignment gets created properly when using objectype
#>
function Test-CreateRAWithObjectType
{
    #Given
    $RoleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    # powershell-testmember's PrincipalId
    $PrincipalId ="e9da4467-12ff-4334-8179-c99abf0ffd5a"
    $subscription =  (Get-AzContext).Subscription.Id
    $Scope = "/subscriptions/$subscription"
    $ObjectType = "User"

    #When
    $data = New-AzRoleAssignmentWithId -ObjectId $PrincipalId -ObjectType $ObjectType -Scope $Scope -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId "2f153333-5be9-4f43-abd2-04561777c8b0"
    $data
    Assert-True {$data.ObjectType -eq "User"}

    #cleanup
    Remove-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId
}

<#
.SYNOPSIS
Verifies that role assignment does not get created for a principal ID that doesn't exist'
#>
function Test-CreateRAWhenIdNotExist
{
    #Given
    $RoleDefinitionId = "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    $PrincipalId ="6d764d35-6b3b-49ea-83f8-5c223b56eac5"
    $Scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f'
    $ExpectedError = 'Exception calling "ExecuteCmdlet" with "0" argument(s): "Operation returned an invalid status code ''BadRequest''"'

    #When
    $function = { New-AzRoleAssignmentWithId -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionId $RoleDefinitionId -RoleAssignmentId 0f7b6fb6-a5f4-4046-83eb-dfd93c5e4b72 }

    Assert-Throws $function $ExpectedError
}
