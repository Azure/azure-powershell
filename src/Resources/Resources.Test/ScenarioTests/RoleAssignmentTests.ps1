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
    # Setup
    $subscription = $(Get-AzContext).Subscription

    # Test
    $classic =  Get-AzRoleAssignment -IncludeClassicAdministrators  | Where-Object { $_.Scope -ieq ('/subscriptions/' + $subscription[0].Id) -and $_.RoleDefinitionName -ieq 'ServiceAdministrator;AccountAdministrator' }

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
    $subscription = Get-AzSubscription

    # Test
    $classic = Get-AzRoleAssignment -Scope ("/subscriptions/" + $subscription[0].Id) -IncludeClassicAdministrators | Where-Object { $_.Scope.ToLower().Contains("/subscriptions/" + $subscription[0].Id) -and $_.RoleDefinitionName -ieq 'ServiceAdministrator;AccountAdministrator' }

    # Assert
    Assert-NotNull $classic
    Assert-True { $classic.Length -ge 1 }

    # Test
    $classic = Get-AzRoleAssignment -Scope ("/subscriptions/" + $subscription[1].Id) -IncludeClassicAdministrators | Where-Object { $_.Scope.ToLower().Contains("/subscriptions/" + $subscription[1].Id) -and $_.RoleDefinitionName -ieq 'ServiceAdministrator;AccountAdministrator' }

    # Assert
    Assert-NotNull $classic
    Assert-True { $classic.Length -ge 1 }
}

<#
.SYNOPSIS
Tests retrieval of assignments to deleted principals/Users/Groups
This test will fail if the objectId is changed or the role assignment deleted
#>
function Test-RaDeletedPrincipals
{
    $objectId = "6f58a770-c06e-4012-b9f9-e5479c03d43f"
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
    $subscription = $(Get-AzContext).Subscription

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
    $definitionName = 'Backup Contributor'
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope `
                        -RoleAssignmentId c7acc224-7df3-461a-8640-85d7bd15b5da

    Remove-AzRoleAssignment $newAssignment

    # Assert
    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Scope
#>
function Test-RaByScope
{
    # Setup
    $definitionName = 'Automation Job Operator'
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    $assignmentScope = $scope +"/"
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $assignmentScope `
                        -RoleAssignmentId 54e1188f-65ba-4b58-9bc3-a252adedcc7b

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
Tests verifies creation and deletion of a RoleAssignments by Id
#>
function Test-RaById
{
    # Setup
    $definitionName = 'Reader'
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -First 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    $assignmentScope = $scope +"/"
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $assignmentScope `
                        -RoleAssignmentId 93cb604e-14dc-426b-834e-bf7bb3826cbc

    $assignments = Get-AzRoleAssignment -RoleDefinitionId "acdd72a7-3385-48ef-bd42-f606fba81ae7"
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 0 }

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
Tests verifies creation and deletion of a RoleAssignments by Resource Group
#>
function Test-RaByResourceGroup
{
    # Setup
    $definitionName = 'Contributor'
    $users = Get-AzADUser | Select-Object -Last 1 -Wait
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName `
                        -RoleAssignmentId 8748e3e7-2cc7-41a9-81ed-b704b6d328a5

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
Tests verifies creation and deletion of a RoleAssignments by Resource
#>
function Test-RaByResource
{
    # Setup
    $definitionName = 'Virtual Machine User Login'
    $groups = Get-AzADGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $groups.Count "There should be at least one group to run the test."
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."
    $resource = Get-AzResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $groups[0].Id `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resource.ResourceGroupName `
                        -ResourceType $resource.ResourceType `
                        -ResourceName $resource.Name `
                        -RoleAssignmentId db6e0231-1be9-4bcd-bf16-79de537439fe

    # cleanup
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $groups[0].DisplayName $newAssignment.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests validate input parameters
#>
function Test-RaValidateInputParameters ($cmdName)
{
    # Setup
    $definitionName = 'Owner'
    $groups = Get-AzADGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $groups.Count "There should be at least one group to run the test."
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."
    $resource = Get-AzResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    # Test
    # Check if Scope is valid.
    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/Should be 'ResourceGroups'/any group name' should begin with '/subscriptions/<subid>/resourceGroups'."
    Assert-Throws { invoke-expression ($cmdName + " -Scope `"" + $scope  + "`" -ObjectId " + $groups[0].Id + " -RoleDefinitionName " + $definitionName) } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    Assert-Throws { &$cmdName -Scope $scope -ObjectId $groups[0].Id -RoleDefinitionName $definitionName } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups' should have even number of parts."
    Assert-Throws { &$cmdName -Scope $scope -ObjectId $groups[0].Id -RoleDefinitionName $definitionName } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Should be 'Providers'/any provider name' should begin with '/subscriptions/<subid>/resourceGroups/<groupname>/providers'."
    Assert-Throws { &$cmdName -Scope $scope -ObjectId $groups[0].Id -RoleDefinitionName $definitionName } $invalidScope

    $scope = "/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername"
    $invalidScope = "Scope '/subscriptions/e9ee799d-6ab2-4084-b952-e7c86344bbab/ResourceGroups/groupname/Providers/providername' should have at least one pair of resource type and resource name. e.g. '/subscriptions/<subid>/resourceGroups/<groupname>/providers/<providername>/<resourcetype>/<resourcename>'."
    Assert-Throws { &$cmdName -Scope $scope -ObjectId $groups[0].Id -RoleDefinitionName $definitionName } $invalidScope

    # Check if ResourceType is valid
    Assert-AreEqual $resource.ResourceType "Microsoft.Web/sites"
    $subscription = $(Get-AzContext).Subscription
    # Below invalid resource type should not return 'Not supported api version'.
    $resource.ResourceType = "Microsoft.KeyVault/"
    $invalidResourceType = "Scope '/subscriptions/"+$subscription.Id+"/resourceGroups/"+$resource.ResourceGroupName+"/providers/Microsoft.KeyVault/"+$resource.Name+"' should have even number of parts."
    Assert-Throws { &$cmdName `
                        -ObjectId $groups[0].Id `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resource.ResourceGroupName `
                        -ResourceType $resource.ResourceType `
                        -ResourceName $resource.Name } $invalidResourceType
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments for Service principal name
#>
function Test-RaByServicePrincipal
{
    # Setup
    $definitionName = 'Web Plan Contributor'
    $servicePrincipals = Get-AzADServicePrincipal | Select-Object -Last 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id
    Assert-AreEqual 1 $servicePrincipals.Count "No service principals found. Unable to run the test."

    # Test
    $newAssignment1 = New-AzRoleAssignmentWithId `
                        -ServicePrincipalName $servicePrincipals[0].ServicePrincipalNames[0] `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope `
                        -RoleAssignmentId 0272ecd2-580e-4560-a59e-fd9ed330ee31

    $definitionName = 'Contributor'
    # Test
    $newAssignment2 = New-AzRoleAssignmentWithId `
                        -ApplicationId $servicePrincipals[0].ServicePrincipalNames[0] `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope `
                        -RoleAssignmentId d953d793-bc25-49e9-818b-5ce68f3ff5ed

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
    Assert-AreEqual $servicePrincipals[0].DisplayName $newAssignment2.DisplayName

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
    $newAssignment = New-AzRoleAssignmentWithId `
                        -SignInName $users[0].UserPrincipalName `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName `
                        -RoleAssignmentId f8dac632-b879-42f9-b4ab-df2aab22a149

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
    $newAssignment = New-AzRoleAssignmentWithId `
                        -SignInName $users[0].UserPrincipalName `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName `
                        -RoleAssignmentId 355f2d24-c0e6-43d2-89a7-027e51161d0b

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
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
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
    Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName

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
                        -ObjectId $users[0].Id `
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
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $scope = '/subscriptions/'+$subscription[0].Id
    $roleDef = Get-AzRoleDefinition -Name "User Access Administrator"
    $roleDef.Id = $null
    $roleDef.Name = "Custom Reader Properties Test"
    $roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
    $roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f"

    New-AzRoleDefinitionWithId -Role $roleDef -RoleDefinitionId ff9cd1ab-d763-486f-b253-51a816c92bbf
    $rd = Get-AzRoleDefinition -Name "Custom Reader Properties Test"

    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $roleDef.Name `
                        -Scope $scope `
                        -RoleAssignmentId 584d33a3-b14d-4eb4-863e-0df67b178389

    $assignments = Get-AzRoleAssignment -ObjectId $users[0].Id
    Assert-NotNull $assignments

    foreach ($assignment in $assignments){
        Assert-NotNull $assignment
        Assert-NotNull $assignment.RoleDefinitionName
        Assert-AreNotEqual $assignment.RoleDefinitionName ""
    }

    DeleteRoleAssignment $newAssignment

    Assert-NotNull $newAssignment
    Assert-AreEqual $roleDef.Name $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope

    VerifyRoleAssignmentDeleted $newAssignment
    # cleanup
    Remove-AzRoleDefinition -Id $rd.Id -Force
}

<#
.SYNOPSIS
Tests verifies creation and retrieval of a RoleAssignments using delegation flag
#>
function Test-RaDelegation
{
    # Setup
    $definitionName = 'Automation Runbook Operator'
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    $assignmentScope = $scope +"/"
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $assignmentScope `
                        -AllowDelegation `
                        -RoleAssignmentId 4dae20f3-6f62-442f-ab84-3b5a6f89e51f

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $definitionName $newAssignment.RoleDefinitionName
    Assert-AreEqual $scope $newAssignment.Scope
    Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName
    Assert-AreEqual $true $newAssignment.CanDelegate

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
    $users = Get-AzADUser | Select-Object -First 1 -Wait
    $subscription = $(Get-AzContext).Subscription
    $resourceGroups = Get-AzResourceGroup | Select-Object -Last 2 -Wait
    $scope1 = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    $scope2 = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[1].ResourceGroupName
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."

    # Test
    $newAssignment1 = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope1 `
                        -RoleAssignmentId 08fe91d5-b917-4d76-81d7-581ff5a99cab

    $newAssignment2 = New-AzRoleAssignmentWithId `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope2 `
                        -RoleAssignmentId fa1a4d3b-2cca-406b-8956-6b6b32377641

    $ras = Get-AzRoleAssignment -ObjectId $users[0].Id `
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
    Assert-AreEqual $users[0].DisplayName $newAssignment1.DisplayName

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

    $deletedRoleAssignment = Get-AzRoleAssignment -ObjectId $roleAssignment.ObjectId `
                                                     -Scope $roleAssignment.Scope `
                                                     -RoleDefinitionName $roleAssignment.RoleDefinitionName  | where {$_.roleAssignmentId -eq $roleAssignment.roleAssignmentId}
    Assert-Null $deletedRoleAssignment
}