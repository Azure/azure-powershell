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
	Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"
	$subscription = Get-AzureRMSubscription -Current

	# Test
	[Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("8D7DD69E-9AE2-44A1-94D8-F7BC8E12645E")
	$classic =  Get-AzureRMRoleAssignment -IncludeClassicAdministrators  | Where-Object { $_.Scope -ieq ('/subscriptions/' + $subscription.SubscriptionId) -and $_.RoleDefinitionName.ToLower().Contains('administrator')}	
	
	# Assert
	Assert-NotNull $classic
	Assert-True { $classic.Length -ge 1 }
}

<#
.SYNOPSIS
Tests verifies negative scenarios for RoleAssignments
#>
function Test-RaNegativeScenarios
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    $subscription = Get-AzureRMSubscription -Current

    # Bad OID does not throw when getting a non-existing role assignment
    $badOid = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $badOidResult = Get-AzureRMRoleAssignment -ObjectId $badOid
    Assert-Null $badOidResult

    # Bad UPN
    $badUpn = 'nonexistent@provider.com'
    $badUpnException = "The provided information does not map to an AD object id."
    Assert-Throws { Get-AzureRMRoleAssignment -UserPrincipalName $badUpn } $badUpnException
    
    # Bad SPN
    $badSpn = 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb'
    $badSpnException = "The provided information does not map to an AD object id."
    Assert-Throws { Get-AzureRMRoleAssignment -ServicePrincipalName $badSpn } $badSpnException
    
    # Bad Scope
    $badScope = '/subscriptions/'+ $subscription.SubscriptionId +'/providers/nonexistent'
    $badScopeException = "InvalidResourceNamespace: The resource namespace 'nonexistent' is invalid."
    Assert-Throws { Get-AzureRMRoleAssignment -Scope $badScope } $badScopeException
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Scope
#>
function Test-RaByScope
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    $definitionName = 'Reader'
    $users = Get-AzureRMADUser | Select-Object -First 1 -Wait
    $subscription = Get-AzureRMSubscription -Current
    $resourceGroups = Get-AzureRMResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription.SubscriptionId +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    
    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("fa1a4d3b-2cca-406b-8956-6b6b32377641")
    $newAssignment = New-AzureRMRoleAssignment `
                        -ObjectId $users[0].Id.Guid `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope 
    
    # cleanup 
    DeleteRoleAssignment $newAssignment

    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual	$definitionName $newAssignment.RoleDefinitionName 
    Assert-AreEqual	$scope $newAssignment.Scope 
    Assert-AreEqual	$users[0].DisplayName $newAssignment.DisplayName
    
    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Resource Group
#>
function Test-RaByResourceGroup
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    $definitionName = 'Contributor'
    $users = Get-AzureRMADUser | Select-Object -Last 1 -Wait
    $resourceGroups = Get-AzureRMResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("7a750d57-9d92-4be1-ad66-f099cecffc01")
    $newAssignment = New-AzureRMRoleAssignment `
                        -ObjectId $users[0].Id.Guid `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName
    
    # cleanup 
    DeleteRoleAssignment $newAssignment
    
    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual	$definitionName $newAssignment.RoleDefinitionName 
    Assert-AreEqual	$users[0].DisplayName $newAssignment.DisplayName
    
    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Resource 
#>
function Test-RaByResource
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    $definitionName = 'Owner'
    $groups = Get-AzureRMADGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $groups.Count "There should be at least one group to run the test."
	$resourceGroups = Get-AzureRMResourceGroup | Select-Object -Last 1 -Wait
	Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."
    $resource = Get-AzureRMResource -ResourceGroupName $resourceGroups[0].ResourceGroupName
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("78D6502F-74FC-4800-BB0A-0E1A7BEBECA4")
    $newAssignment = New-AzureRMRoleAssignment `
                        -ObjectId $groups[0].Id.Guid `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName `
                        -ResourceType $resource.ResourceType `
                        -ResourceName $resource.Name
    
    # cleanup 
    DeleteRoleAssignment $newAssignment
    
    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual	$definitionName $newAssignment.RoleDefinitionName 
    Assert-AreEqual	$groups[0].DisplayName $newAssignment.DisplayName
    
    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments for Service principal name 
#>
function Test-RaByServicePrincipal
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    $definitionName = 'Reader'
    $servicePrincipals = Get-AzureRMADServicePrincipal | Select-Object -Last 1 -Wait
    $subscription = Get-AzureRMSubscription -Current
    $resourceGroups = Get-AzureRMResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription.SubscriptionId +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $servicePrincipals.Count "No service principals found. Unable to run the test."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("a4b82891-ebee-4568-b606-632899bf9453")
    $newAssignment = New-AzureRMRoleAssignment `
                        -ServicePrincipalName $servicePrincipals[0].DisplayName `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope 
                        
    
    # cleanup 
    DeleteRoleAssignment $newAssignment
    
    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual	$definitionName $newAssignment.RoleDefinitionName 
    Assert-AreEqual	$scope $newAssignment.Scope 
    Assert-AreEqual	$servicePrincipals[0].DisplayName $newAssignment.DisplayName
    
    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments for User Principal Name
#>
function Test-RaByUpn
{
    # Setup
    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    $definitionName = 'Contributor'
    $users = Get-AzureRMADUser | Select-Object -Last 1 -Wait
    $resourceGroups = Get-AzureRMResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("8d7dd69e-9ae2-44a1-94d8-f7bc8e12645e")
    $newAssignment = New-AzureRMRoleAssignment `
                        -UPN $users[0].Mail `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName
    
    # cleanup 
    DeleteRoleAssignment $newAssignment
    
    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual	$definitionName $newAssignment.RoleDefinitionName 
    Assert-AreEqual	$users[0].DisplayName $newAssignment.DisplayName

    VerifyRoleAssignmentDeleted $newAssignment
}

<# .SYNOPSIS Tests validate correctness of returned permissions when logged in as the assigned user  #> 
function Test-RaUserPermissions 
{ 
    param([string]$rgName, [string]$action) 
    
    # Setup 
    
    # Test 
    $permissions = Get-AzureRMResourceGroup -Name $rgName 
        
    # Assert 
    Assert-AreEqual 1 $permissions.Permissions.Count "User should have only one permission." 
    Assert-AreEqual 1 $permissions.Permissions[0].Actions.Count "User should have only one action in the permission." 
    Assert-AreEqual	$action $permissions.Permissions[0].Actions[0] "Permission action mismatch." 
}

<#
.SYNOPSIS
Tests verifies Get-AzureRMAuthorizationChangeLog
#>
function Test-RaAuthorizationChangeLog
{
	$log1 = Get-AzureRMAuthorizationChangeLog -startTime 2015-08-27 -EndTime 2015-08-27T22:30:00Z

	# Assert
	Assert-True { $log1.Count -ge 1 } "At least one record should be returned for the user"
}



<#
.SYNOPSIS
Creates role assignment
#>
function CreateRoleAssignment
{
    param([string]$roleAssignmentId, [string]$userId, [string]$definitionName, [string]$resourceGroupName) 

    Add-Type -Path ".\\Microsoft.Azure.Commands.Resources.dll"

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue($roleAssignmentId)
    $newAssignment = New-AzureRMRoleAssignment `
                        -ObjectId $userId `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroupName

    return $newAssignment
}

<#
.SYNOPSIS
Delete role assignment
#>
function DeleteRoleAssignment
{
    param([Parameter(Mandatory=$true)] [object] $roleAssignment)
    
    Remove-AzureRMRoleAssignment -ObjectId $roleAssignment.ObjectId.Guid `
                               -Scope $roleAssignment.Scope `
                               -RoleDefinitionName $roleAssignment.RoleDefinitionName `
                               -Force
}

<#
.SYNOPSIS
Verifies that role assignment does not exist
#>
function VerifyRoleAssignmentDeleted
{
    param([Parameter(Mandatory=$true)] [object] $roleAssignment)
    
    $deletedRoleAssignment = Get-AzureRMRoleAssignment -ObjectId $roleAssignment.ObjectId.Guid `
                                                     -Scope $roleAssignment.Scope `
                                                     -RoleDefinitionName $roleAssignment.RoleDefinitionName 
    Assert-Null $deletedRoleAssignment
}