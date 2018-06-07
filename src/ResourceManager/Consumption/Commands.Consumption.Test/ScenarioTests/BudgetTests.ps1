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
Get Budget name
#>
function Get-BudgetName
{
    return "Budget-" + (getAssetName)
}

<#
.SYNOPSIS
Get Notification key
#>
function Get-NotificationKey
{
    return "NotificationKey-" + (getAssetName)
}

<#
.SYNOPSIS
Test budget at subscription level
#>
function Test-BudgetAtSubscriptionLevel
{
	# Setup
	$budgetName = Get-BudgetName
	$notificationKey = Get-NotificationKey
	# This resource group is created at the scope of test subscription
	$resourceGroupName = "CriTest"

	Write-Debug "Create a new budget $budgetName at subscription level"
    $budgetNew = New-AzureRmConsumptionBudget -Amount 6000 -Name $budgetName -Category Cost -StartDate 2018-06-01 -EndDate 2018-11-01 -TimeGrain Monthly
	Assert-NotNull $budgetNew
	Assert-AreEqual 6000 $budgetNew.Amount
	Assert-AreEqual $budgetName $budgetNew.Name
	Assert-AreEqual Cost $budgetNew.Category
	Assert-AreEqual Monthly $budgetNew.TimeGrain

	Write-Debug "Get the budget $budgetName"
	$budgetGet = Get-AzureRmConsumptionBudget -Name $budgetName
	Assert-NotNull $budgetGet
	Assert-AreEqual 6000 $budgetGet.Amount
	Assert-AreEqual $budgetName $budgetGet.Name
	Assert-AreEqual Cost $budgetGet.Category
	Assert-AreEqual Monthly $budgetGet.TimeGrain

	Write-Debug "Update the budget $budgetName with amount change to 7500"
	$budgetSet1 = Set-AzureRmConsumptionBudget -Name $budgetName -Amount 7500
	Assert-NotNull $budgetSet1
	Assert-AreEqual 7500 $budgetSet1.Amount

	Write-Debug "Update the budget $budgetName with a notification $notificationKey when cost or usage reaches a threshold of 90 percent of amount"
	$budgetSet2 = Set-AzureRmConsumptionBudget -Name $budgetName -NotificationKey $notificationKey -NotificationEnabled -NotificationThreshold 90 -ContactEmail johndoe@contoso.com,janesmith@contoso.com -ContactRole Owner,Reader,Contributor
	Assert-NotNull $budgetSet2
	Assert-AreEqual $budgetName $budgetSet2.Name
	Assert-AreEqual 1 $budgetSet2.Notification.Count

	Write-Debug "Update the budget $budgetName to disable the notificaiton $notificationKey"
	$budgetSet3 = Set-AzureRmConsumptionBudget -Name $budgetName -NotificationKey $notificationKey -NotificationDisable
	Assert-NotNull $budgetSet3
	Assert-AreEqual $budgetName $budgetSet3.Name
	Assert-AreEqual 1 $budgetSet3.Notification.Count

	Write-Debug "Update the budget $budgetName with a resource group filter, so the budget only applies to the cost within the resource group"
	$budgetSet4 = Set-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupFilter $resourceGroupName
	Assert-NotNull $budgetSet4
	Assert-AreEqual $budgetName $budgetSet4.Name
	Assert-AreEqual 1 $budgetSet4.Filter.ResourceGroups.Count

	Write-Debug "Remove the budget $budgetName"
	$response = Remove-AzureRmConsumptionBudget -Name $budgetName -PassThru
	Assert-AreEqual True $response
}

<#
.SYNOPSIS
Test budget at resource group level
#>
function Test-BudgetAtResourceGroupLevel
{
	# Setup
	$budgetName = Get-BudgetName
	$notificationKey1 = Get-NotificationKey
	$notificationKey2 = Get-NotificationKey
	# This resource group is created at the scope of test subscription
	$resourceGroupName = "RGBudgets"

	Write-Debug "Create a new budget $budgetName at resource group level"
    $budgetNew = New-AzureRmConsumptionBudget -Amount 6000 -Name $budgetName -ResourceGroupName $resourceGroupName -Category Cost -StartDate 2018-06-01 -EndDate 2018-11-01 -TimeGrain Monthly
	Assert-NotNull $budgetNew
	Assert-AreEqual 6000 $budgetNew.Amount
	Assert-AreEqual $budgetName $budgetNew.Name
	Assert-AreEqual Cost $budgetNew.Category
	Assert-AreEqual Monthly $budgetNew.TimeGrain

	Write-Debug "Get the budget $budgetName"
	$budgetGet = Get-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName
	Assert-NotNull $budgetGet
	Assert-AreEqual 6000 $budgetGet.Amount
	Assert-AreEqual $budgetName $budgetGet.Name
	Assert-AreEqual Cost $budgetGet.Category
	Assert-AreEqual Monthly $budgetGet.TimeGrain

	Write-Debug "Update the budget $budgetName with a notification $notificationKey when cost reaches a threshold of 90 percent of amount"
	$budgetSet1 = Set-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName -NotificationKey $notificationKey1 -NotificationEnabled -NotificationThreshold 90 -ContactEmail johndoe@contoso.com,janesmith@contoso.com -ContactRole Owner,Reader,Contributor
	Assert-NotNull $budgetSet1
	Assert-AreEqual $budgetName $budgetSet1.Name
	Assert-AreEqual 1 $budgetSet1.Notification.Count

	Write-Debug "Update the budget $budgetName with a second notificaiton $notificationKey when cost reaches a threshold of 150 percent of amount"
	$budgetSet2 = Set-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName -NotificationKey $notificationKey2 -NotificationEnabled -NotificationThreshold 150 -ContactEmail johndoe@contoso.com,janesmith@contoso.com -ContactRole Owner,Reader,Contributor
	Assert-NotNull $budgetSet2
	Assert-AreEqual $budgetName $budgetSet2.Name
	Assert-AreEqual 2 $budgetSet2.Notification.Count

	Write-Debug "Remove the budget $budgetName"
	$response = Remove-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName -PassThru
	Assert-AreEqual True $response
}

<#
.SYNOPSIS
Get all budgets at subscription level
#>
function Test-GetBudgets
{
    $budgets = Get-AzureRmConsumptionBudget 
	Assert-NotNull $budgets
}