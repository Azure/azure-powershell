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
	$subscription = Get-AzureRmSubscription

	# Test
	$classic =  Get-AzureRmRoleAssignment -IncludeClassicAdministrators  | Where-Object { $_.Scope -ieq ('/subscriptions/' + $subscription[0].Id) -and $_.RoleDefinitionName.ToLower().Contains('administrator')}	
	
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
    $subscription = Get-AzureRmSubscription

    # Bad OID returns zero role assignments
    $badOid = 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa'
    $badObjectResult = "Cannot find principal using the specified options"
	$assignments = Get-AzureRmRoleAssignment -ObjectId $badOid
    Assert-AreEqual 0 $assignments.Count

	# Bad OID throws if Expand Principal Groups included
	Assert-Throws { Get-AzureRmRoleAssignment -ObjectId $badOid -ExpandPrincipalGroups } $badObjectResult

    # Bad UPN
    $badUpn = 'nonexistent@provider.com'
    Assert-Throws { Get-AzureRmRoleAssignment -UserPrincipalName $badUpn } $badObjectResult
    
    # Bad SPN
    $badSpn = 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb'
    Assert-Throws { Get-AzureRmRoleAssignment -ServicePrincipalName $badSpn } $badObjectResult
}

<#
.SYNOPSIS
Tests verifies delete scenario for RoleAssignments by using PSRoleAssignment Object
#>
function Test-RaDeleteByPSRoleAssignment
{
    # Setup
    $definitionName = 'Reader'
    $users = Get-AzureRmADUser | Select-Object -First 1 -Wait
    $subscription = Get-AzureRmSubscription
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    
    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("f747531e-da33-43b9-b726-04675abf1939")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope 

    Remove-AzureRmRoleAssignment $newAssignment

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
    $definitionName = 'Reader'
    $users = Get-AzureRmADUser | Select-Object -First 1 -Wait
    $subscription = Get-AzureRmSubscription
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    $assignmentScope = $scope +"/"
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    
    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("f747531e-da33-43b9-b726-04675abf1939")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $assignmentScope 
    
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
    $definitionName = 'Contributor'
    $users = Get-AzureRmADUser | Select-Object -Last 1 -Wait
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("8748e3e7-2cc7-41a9-81ed-b704b6d328a5")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resourceGroups[0].ResourceGroupName
    
    Write-Debug $newAssignment
	Write-Verbose $newAssignment.ObjectId
	#Write-Verbose $newAssignment.ObjectID

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
    $definitionName = 'Owner'
    $groups = Get-AzureRmADGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $groups.Count "There should be at least one group to run the test."
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."
    $resource = Get-AzureRmResource | Select-Object -Last 1 -Wait
    Assert-NotNull $resource "Cannot find any resource to continue test execution."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("db6e0231-1be9-4bcd-bf16-79de537439fe")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $groups[0].Id `
                        -RoleDefinitionName $definitionName `
                        -ResourceGroupName $resource.ResourceGroupName `
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
Tests validate input parameters 
#>
function Test-RaValidateInputParameters ($cmdName)
{
    # Setup
    $definitionName = 'Owner'
    $groups = Get-AzureRmADGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $groups.Count "There should be at least one group to run the test."
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."
    $resource = Get-AzureRmResource | Select-Object -Last 1 -Wait
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
    $subscription = Get-AzureRmSubscription | Select-Object -Last 1 -Wait
    # Below invalid resource type should not return 'Not supported api version'.
    $resource.ResourceType = "Microsoft.KeyVault/"
    $invalidResourceType = "Scope '/subscriptions/"+$subscription.Id+"/resourceGroups/"+$resource.ResourceGroupName+"/providers/Microsoft.KeyVault/"+$resource.ResourceGroupName+"' should have even number of parts."
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
    $definitionName = 'Contributor'
    $servicePrincipals = Get-AzureRmADServicePrincipal | Select-Object -Last 1 -Wait
    $subscription = Get-AzureRmSubscription
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $servicePrincipals.Count "No service principals found. Unable to run the test."

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("0b018870-59ba-49ca-9405-9ba5dce77311")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ServicePrincipalName $servicePrincipals[0].ServicePrincipalNames[0] `
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
    $definitionName = 'Contributor'
    $users = Get-AzureRmADUser | Select-Object -Last 1 -Wait
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    Assert-AreEqual 1 $resourceGroups.Count "No resource group found. Unable to run the test."

    # Test
	[Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("f8dac632-b879-42f9-b4ab-df2aab22a149")
    $newAssignment = New-AzureRmRoleAssignment `
                        -SignInName $users[0].UserPrincipalName `
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
    # Test 
    $rg = Get-AzureRmResourceGroup
	$errorMsg = "User should have access to only 1 RG. Found: {0}" -f $rg.Count
	Assert-AreEqual 1 $rg.Count $errorMsg

	# User should not be able to create another RG as he doesnt have access to the subscription.
	Assert-Throws{ New-AzureRmResourceGroup -Name 'NewGroupFromTest' -Location 'WestUS'}        
}

<#
.SYNOPSIS
Tests verifies creation and deletion of a RoleAssignments by Scope irrespective of the case
#>
function Test-RaDeletionByScope
{
    # Setup
    $definitionName = 'Reader'
    $users = Get-AzureRmADUser | Select-Object -First 1 -Wait
    $subscription = Get-AzureRmSubscription
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/subscriptions/'+ $subscription[0].Id +'/resourceGroups/' + $resourceGroups[0].ResourceGroupName
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    
    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("f747531e-da33-43b9-b726-04675abf1939")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope 
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
    $definitionName = 'Reader'
    $users = Get-AzureRmADUser | Select-Object -First 1 -Wait
    $subscription = Get-AzureRmSubscription
    $resourceGroups = Get-AzureRmResourceGroup | Select-Object -Last 1 -Wait
    $scope = '/'
    Assert-AreEqual 1 $users.Count "There should be at least one user to run the test."
    
    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("f747531e-da33-43b9-b726-04675abf1939")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $definitionName `
                        -Scope $scope 
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
    $users = Get-AzureRmADUser | Select-Object -First 1 -Wait
    $subscription = Get-AzureRmSubscription
    $scope = '/subscriptions/'+$subscription[0].Id
    $roleDef = Get-AzureRmRoleDefinition -Name "Reader"
    $roleDef.Id = $null
    $roleDef.Name = "Custom Reader Test"
    $roleDef.Actions.Add("Microsoft.ClassicCompute/virtualMachines/restart/action")
    $roleDef.Description = "Read, monitor and restart virtual machines"
    $roleDef.AssignableScopes[0] = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f"

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleDefinitionNames.Enqueue("032F61D2-ED09-40C9-8657-26A273DA7BAE")
    New-AzureRmRoleDefinition -Role $roleDef
    $rd = Get-AzureRmRoleDefinition -Name "Custom Reader Test"

    # Test
    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue("fa1a4d3b-2cca-406b-8956-6b6b32377641")
    $newAssignment = New-AzureRmRoleAssignment `
                        -ObjectId $users[0].Id `
                        -RoleDefinitionName $roleDef.Name `
                        -Scope $scope 
    $newAssignment.Scope = $scope.toUpper()
    
    $assignments = Get-AzureRmRoleAssignment
    Assert-NotNull $assignments
    foreach ($assignment in $assignments){
        Assert-NotNull $assignment
        Assert-NotNull $assignment.RoleDefinitionName
        Assert-AreNotEqual $assignment.RoleDefinitionName ""
    }

    # cleanup 
    DeleteRoleAssignment $newAssignment
    Remove-AzureRmRoleDefinition -Id $rd.Id -Force
    
    # Assert
    Assert-NotNull $newAssignment
    Assert-AreEqual $roleDef.Name $newAssignment.RoleDefinitionName 
    Assert-AreEqual $scope $newAssignment.Scope 
    Assert-AreEqual $users[0].DisplayName $newAssignment.DisplayName
    
    VerifyRoleAssignmentDeleted $newAssignment
}

<#
.SYNOPSIS
Creates role assignment
#>
function CreateRoleAssignment
{
    param([string]$roleAssignmentId, [string]$userId, [string]$definitionName, [string]$resourceGroupName) 

    [Microsoft.Azure.Commands.Resources.Models.Authorization.AuthorizationClient]::RoleAssignmentNames.Enqueue($roleAssignmentId)
    $newAssignment = New-AzureRmRoleAssignment `
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
    
    Remove-AzureRmRoleAssignment -ObjectId $roleAssignment.ObjectId `
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
    
    $deletedRoleAssignment = Get-AzureRmRoleAssignment -ObjectId $roleAssignment.ObjectId `
                                                     -Scope $roleAssignment.Scope `
                                                     -RoleDefinitionName $roleAssignment.RoleDefinitionName  | where {$_.roleAssignmentId -eq $roleAssignment.roleAssignmentId}
    Assert-Null $deletedRoleAssignment
}