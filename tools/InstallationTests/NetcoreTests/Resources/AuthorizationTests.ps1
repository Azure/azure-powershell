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
Tests these features in the authorization:
- Getting and lisiting role definitions.
- Creating role assignments on subscription and resource group level.
- Removing specific role assignment via piping.
- 
#>
function Test-AuthorizationEndToEnd
{
    <# Role Definitions #>

    # Can list role definitions
    $roleDefinitions = Get-AzureRmRoleDefinition
    Assert-True { $roleDefinitions.Count -gt 0 }

    # Can get one role definition
    $roleDefinition = Get-AzureRmRoleDefinition -Name $roleDefinitions[0].Name
    Assert-AreEqual $roleDefinitions[0].Name $roleDefinition.Name

    # Does not throw when getting a non-existing role definition
    $roleDefinition = Get-AzureRmRoleDefinition -Name "not-there"
    Assert-Null $roleDefinition

    <# Role Assignments #>
    $rg = Get-ResourceGroupName
    $defaultSubscription = Get-AzureRmContext
    $principal = $defaultSubscription.ActiveDirectoryUserId
    $roleDef = $(Get-AzureRmRoleDefinition)[0].Name
    $expectedScope = "/subscriptions/" + $defaultSubscription.Subscription.Id

    # List role assignments is piped to get remove role assignment
    Get-AzureRmRoleAssignment | Remove-AzureRmRoleAssignment
    $roleAssignments = Get-AzureRmRoleAssignment
    Assert-AreEqual 0 $roleAssignments.Count

    # Create role assignment with default scope
    $signInName = $defaultSubscription.Account.Id
    $roleAssignment = New-AzureRmRoleAssignment -SignInName $signInName -RoleDefinitionName $roleDef
    Assert-AreEqual $expectedScope $roleAssignment.Scope

    $roleAssignment | Remove-AzureRmRoleAssignment

    # Create role assignment with resource group scope
    New-AzureRmResourceGroup -Name $rg -Location "westus" -Force
    $expectedScope = $expectedScope + "/resourceGroups/$rg"
    $roleAssignment = New-AzureRmRoleAssignment -SignInName $signInName -RoleDefinitionName $roleDef -ResourceGroup $rg
    Assert-AreEqual $expectedScope $roleAssignment.Scope

    # Throws if trying to recreate an existing role assignment
    Assert-Throws { New-AzureRmRoleAssignment -SignInName $signInName -RoleDefinitionName $roleDef -ResourceGroup $rg }

    $roleAssignment | Remove-AzureRmRoleAssignment
    Remove-AzureRmResourceGroup -Name $rg -Force
}