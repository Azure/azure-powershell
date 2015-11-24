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
    $defaultSubscription = Get-AzureRmSubscription -Default
    $principal = $defaultSubscription.ActiveDirectoryUserId
    $roleDef = $(Get-AzureRmRoleDefinition)[0].Name
    $expectedScope = "/subscriptions/" + $defaultSubscription.SubscriptionId

    # List role assignments is piped to get remove role assignment
    Get-AzureRmRoleAssignment | Remove-AzureRmRoleAssignment -Force
    $roleAssignments = Get-AzureRmRoleAssignment
    Assert-AreEqual 0 $roleAssignments.Count

    # Create role assignment with default scope
    [Microsoft.Azure.Commands.Resources.Models.Authorization.PoliciesClient]::RoleAssignmentNames.Enqueue("C6408EC2-C27D-49C3-87ED-F49AC8354B76")
    $roleAssignment = New-AzureRmRoleAssignment -Principal $principal -RoleDefinitionName $roleDef
    Assert-AreEqual $principal $roleAssignment.Principal
    Assert-AreEqual $expectedScope $roleAssignment.Scope

    $roleAssignment | Remove-AzureRmRoleAssignment -Force

    # Create role assignment with resource group scope
    $expectedScope = $expectedScope + "/resourceGroups/$rg"
    [Microsoft.Azure.Commands.Resources.Models.Authorization.PoliciesClient]::RoleAssignmentNames.Enqueue("6CAFE07B-DEA4-4097-A0DB-50E844D70615")
    $roleAssignment = New-AzureRmRoleAssignment -Principal $principal -RoleDefinitionName $roleDef -ResourceGroup $rg
    Assert-AreEqual $principal $roleAssignment.Principal
    Assert-AreEqual $expectedScope $roleAssignment.Scope

    # Throws if trying to recreate an existing role assignment
    [Microsoft.Azure.Commands.Resources.Models.Authorization.PoliciesClient]::RoleAssignmentNames.Enqueue("0BD5EC77-F955-4470-83B9-582CED1EA177")
    Assert-Throws { New-AzureRmRoleAssignment -Principal $principal -RoleDefinitionName $roleDef -ResourceGroup $rg }

    $roleAssignment | Remove-AzureRmRoleAssignment -Force
}