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

# Instructions of recording tests
# Recording of budget tests requires a subscription and user Id. Service principal
# can support recording but a request to create, set, or remove through service 
# principal will be prevented by API. StartDate should be no later than the 1st 
# date of the current month for monthly grain. For any recording question, 
# please contact Prem.Prakash@microsoft.com

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
	$startDate = Get-Date -Day 1
	$endDate = ($startDate).AddMonths(3).AddDays(-1)

	Write-Debug "Create a new budget $budgetName at subscription level"
    $budgetNew = New-AzureRmConsumptionBudget -Amount 6000 -Name $budgetName -Category Cost -StartDate $startDate -EndDate $endDate -TimeGrain Monthly
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
	$budgetSet1 = Get-AzureRmConsumptionBudget -Name $budgetName | Set-AzureRmConsumptionBudget -Amount 7500
	Assert-NotNull $budgetSet1
	Assert-AreEqual 7500 $budgetSet1.Amount

	Write-Debug "Update the budget $budgetName with a notification $notificationKey when cost or usage reaches a threshold of 90 percent of amount"
	$budgetSet2 = Set-AzureRmConsumptionBudget -Name $budgetName -NotificationKey $notificationKey -NotificationEnabled -NotificationThreshold 90 -ContactEmail johndoe@contoso.com,janesmith@contoso.com -ContactRole Owner,Reader,Contributor
	Assert-NotNull $budgetSet2
	Assert-AreEqual $budgetName $budgetSet2.Name
	Assert-AreEqual 1 $budgetSet2.Notification.Count

	Write-Debug "Remove the budget $budgetName"
	$response = Remove-AzureRmConsumptionBudget -Name $budgetName -PassThru
	Assert-AreEqual True $response

	Assert-Throws {Get-AzureRmConsumptionBudget -Name $budgetName}
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
	$resourceGroupName = 'RGBudgets'
	$startDate = Get-Date -Day 1
	$endDate = ($startDate).AddMonths(3).AddDays(-1)

	# Create budget
	Write-Debug "Create a new budget $budgetName at resource group level"
    $budgetNew = New-AzureRmConsumptionBudget -Amount 6000 -Name $budgetName -ResourceGroupName $resourceGroupName -Category Cost -StartDate $startDate -EndDate $endDate -TimeGrain Monthly
	Assert-NotNull $budgetNew
	Assert-AreEqual 6000 $budgetNew.Amount
	Assert-AreEqual $budgetName $budgetNew.Name
	Assert-AreEqual Cost $budgetNew.Category
	Assert-AreEqual Monthly $budgetNew.TimeGrain

	# Get budget
	Write-Debug "Get the budget $budgetName"
	$budgetGet = Get-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName
	Assert-NotNull $budgetGet
	Assert-AreEqual 6000 $budgetGet.Amount
	Assert-AreEqual $budgetName $budgetGet.Name
	Assert-AreEqual Cost $budgetGet.Category
	Assert-AreEqual Monthly $budgetGet.TimeGrain

	# Set budget
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

	# Remove budget
	Write-Debug "Remove the budget $budgetName"
	$response = Remove-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName -PassThru
	Assert-AreEqual True $response

	Assert-Throws {Get-AzureRmConsumptionBudget -Name $budgetName -ResourceGroupName $resourceGroupName}
}

<#
.SYNOPSIS
Get all budgets at subscription level
#>
function Test-GetBudgets
{
	# Setup
	$startDate = Get-Date -Day 1
	$endDate = ($startDate).AddMonths(3).AddDays(-1)
	$budgetName = Get-BudgetName
	$budgetNew = New-AzureRmConsumptionBudget -Amount 6000 -Name $budgetName -Category Cost -StartDate $startDate -EndDate $endDate -TimeGrain Monthly
	Assert-NotNull $budgetNew

	# Validate get all budgets
    $budgets = Get-AzureRmConsumptionBudget 
	Assert-NotNull $budgets

	# Clean up through piping
	$response = Get-AzureRmConsumptionBudget -Name $budgetName | Remove-AzureRmConsumptionBudget -PassThru
	Assert-AreEqual True $response

	Assert-Throws {Get-AzureRmConsumptionBudget -Name $budgetName}
}