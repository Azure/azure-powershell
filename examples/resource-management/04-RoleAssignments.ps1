Param(
  [string]$groupName,
  [string]$location
)

Write-Host "=== Managing Role Assignments in Azure ==="

Write-Host "1. Create a new resource group"
New-AzureRmResourceGroup -Name $groupName -Location $location

Write-Host "2. Creating a new Role Assignment."
$userId = ((Get-AzureRmADUser)[0]).Id
$definitionId = ((Get-AzureRmRoleDefinition)[0]).Id
$subscriptionId = (Get-AzureRmSubscription).SubscriptionId
$scope="/subscriptions/" + $subscriptionId + "/resourceGroups/" + $groupName
$roleAssignment = New-AzureRmRoleAssignment -ObjectId $userId -RoleDefinitionId $definitionId -Scope $scope

Write-Host "3. Delete last created Role Assignment."
Remove-AzureRmRoleAssignment -ObjectId $roleAssignment.ObjectId -Scope $scope -RoleDefinitionId $definitionId -f
