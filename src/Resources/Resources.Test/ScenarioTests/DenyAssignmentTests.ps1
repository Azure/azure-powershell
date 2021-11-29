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
Tests verifies getting DenyAssignments
Currently, deny assignments are read-only and can only be set by Azure.
As a result for testing purposes we are using some specific subscription, resource group, resource and principals.
#>

function Test-GetDa
{
    $assignments = Get-AzDenyAssignment
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaById
{
    # Random select a id from the result of listing deny assignments
    $id = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/managed-rg-feng-purview/providers/Microsoft.Authorization/denyAssignments/5184754b-6c52-436a-90a5-cae79bfbfea1"
    $assignments = Get-AzDenyAssignment -Id $id
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -eq 1 }
    Assert-AreEqual $assignments[0].Id $id
}

function Test-GetDaByIdAndSpecifiedScope
{
    $id = '5184754b-6c52-436a-90a5-cae79bfbfea1'
    $scope = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/managed-rg-feng-purview"
    $assignments = Get-AzDenyAssignment -Id $id -Scope $scope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -eq 1 }
    Assert-AreEqual $assignments[0].Id "$scope/providers/Microsoft.Authorization/denyAssignments/$id"
}

function Test-GetDaByName
{
    $daName = "StoragePool Resource Provider Management Lock for MSP_bez-rg_bez-diskpool_eastus"
    $assignments = Get-AzDenyAssignment -DenyAssignmentName $daName
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -eq 1 }
    Assert-AreEqual $assignments[0].DenyAssignmentName $daName
}

function Test-GetDaByNameAndSpecifiedScope
{
    $daName = "StoragePool Resource Provider Management Lock for MSP_bez-rg_bez-diskpool_eastus"
    $daScope = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/databricks-rg-demo001-h09oyaz47r6qb'
    $assignments = Get-AzDenyAssignment -DenyAssignmentName $daName -Scope $daScope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -eq 1 }
    Assert-AreEqual $assignments[0].DenyAssignmentName $daName
    Assert-AreEqual $assignments[0].Scope $daScope
}

function Test-GetDaByObjectId
{
    $objectId = '00000000-0000-0000-0000-000000000000'
    $assignments = Get-AzDenyAssignment -ObjectId $objectId
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByObjectIdAndGroupExpansion
{
    $objectId = '4d712a4e-1897-4dd0-845f-452a5b82844e'
    $assignments = Get-AzDenyAssignment -ObjectId $objectId -ExpandPrincipalGroups
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 2 }
}

function Test-GetDaByObjectIdAndRGName
{
    $objectId = '00000000-0000-0000-0000-000000000000'
    $resourceGroupName = 'managed-rg-fypurview'
    $assignments = Get-AzDenyAssignment -ObjectId $objectId -ResourceGroupName $resourceGroupName 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByObjectIdAndRGNameResourceNameResourceType
{
    $objectId = '00000000-0000-0000-0000-000000000000'
    $resourceGroupName = 'managed-rg-fypurview'
    $resourceName ='demo001'
    $resourceType = 'Microsoft.Databricks/workspaces'
    $assignments = Get-AzDenyAssignment -ObjectId $objectId -ResourceGroupName $resourceGroupName -ResourceName  $resourceName -ResourceType  $resourceType 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByObjectIdAndScope
{
    $objectId = '00000000-0000-0000-0000-000000000000'
    $scope = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/managed-rg-feng-purview"
    $assignments = Get-AzDenyAssignment -ObjectId $objectId -Scope $scope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaBySignInName
{
    $signInName = 'bez@azuresdkteam.onmicrosoft.com'
    $assignments = Get-AzDenyAssignment -SignInName $signInName
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaBySignInNameAndGroupExpansion
{
    $signInName = 'test2@rbacCliTest.onmicrosoft.com'
    $assignments = Get-AzDenyAssignment -SignInName $signInName -ExpandPrincipalGroups
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 2 }
}

function Test-GetDaBySignInNameAndRGName
{
    $signInName = 'test2@rbacCliTest.onmicrosoft.com'
    $resourceGroupName = 'AzureAuthzSDK'
    $assignments = Get-AzDenyAssignment -SignInName $signInName -ResourceGroupName $resourceGroupName 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaBySignInNameAndRGNameResourceNameResourceType
{
    $signInName = 'test2@rbacCliTest.onmicrosoft.com'
    $resourceGroupName = 'AzureAuthzSDK'
    $resourceName ='authzsdktestresource'
    $resourceType = 'Microsoft.Storage/storageAccounts'
    $assignments = Get-AzDenyAssignment -SignInName $signInName -ResourceGroupName $resourceGroupName -ResourceName  $resourceName -ResourceType  $resourceType 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaBySignInNameAndScope
{
    $signInName = 'test2@rbacCliTest.onmicrosoft.com'
    $scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/resourcegroups/AzureAuthzSDK'
    $assignments = Get-AzDenyAssignment -SignInName $signInName -Scope $scope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByServicePrincipalName
{
    $servicePrincipalName = 'https://rbacCliTest.onmicrosoft.com/722c28d1-3e5c-472a-ab3e-0ff6827aeedc'
    $assignments = Get-AzDenyAssignment -ServicePrincipalName $servicePrincipalName
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByServicePrincipalNameAndRGName
{
    $servicePrincipalName = 'https://rbacCliTest.onmicrosoft.com/722c28d1-3e5c-472a-ab3e-0ff6827aeedc'
    $resourceGroupName = 'AzureAuthzSDK'
    $assignments = Get-AzDenyAssignment -ServicePrincipalName $servicePrincipalName -ResourceGroupName $resourceGroupName 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByServicePrincipalNameAndRGNameResourceNameResourceType
{
    $servicePrincipalName = 'https://rbacCliTest.onmicrosoft.com/722c28d1-3e5c-472a-ab3e-0ff6827aeedc'
    $resourceGroupName = 'AzureAuthzSDK'
    $resourceName ='authzsdktestresource'
    $resourceType = 'Microsoft.Storage/storageAccounts'
    $assignments = Get-AzDenyAssignment -ServicePrincipalName $servicePrincipalName -ResourceGroupName $resourceGroupName -ResourceName  $resourceName -ResourceType  $resourceType 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByServicePrincipalNameAndScope
{
    $servicePrincipalName = 'https://rbacCliTest.onmicrosoft.com/722c28d1-3e5c-472a-ab3e-0ff6827aeedc'
    $scope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/resourcegroups/AzureAuthzSDK'
    $assignments = Get-AzDenyAssignment -ServicePrincipalName $servicePrincipalName -Scope $scope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByScope
{
    $scope = '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/managed-rg-feng-purview'
    $assignments = Get-AzDenyAssignment -Scope $scope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByRG
{
    $resourceGroupName = 'managed-rg-feng-purview'
    $assignments = Get-AzDenyAssignment -ResourceGroupName $resourceGroupName
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByRGNameResourceNameResourceType
{
    $resourceGroupName = 'AzureAuthzSDK'
    $resourceName ='authzsdktestresource'
    $resourceType = 'Microsoft.Storage/storageAccounts'
    $assignments = Get-AzDenyAssignment -ResourceGroupName $resourceGroupName -ResourceName  $resourceName -ResourceType  $resourceType 
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaByEveryoneObjectId
{
    $objectId = '00000000000000000000000000000000'
    $assignments = Get-AzDenyAssignment -ObjectId $objectId
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -ge 1 }
}

function Test-GetDaForEveryoneHasExpectedNameAndType
{
    $daName = 'AzureAuthzSDK_C807D002-6D77-452F-A837-4692929D12FD'
    $daScope = '/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/resourcegroups/AzureAuthzSDK'
    $assignments = Get-AzDenyAssignment -DenyAssignmentName $daName -Scope $daScope
    
    Assert-NotNull $assignments
    Assert-True { $assignments.Length -eq 1 }
    Assert-AreEqual $assignments[0].DenyAssignmentName $daName
    Assert-AreEqual $assignments[0].Scope $daScope
    Assert-AreEqual $assignments[0].Principals[0].DisplayName 'All Principals'
    Assert-AreEqual $assignments[0].Principals[0].ObjectType 'SystemDefined'
    Assert-AreEqual $assignments[0].Principals[0].ObjectId '00000000-0000-0000-0000-000000000000'
}