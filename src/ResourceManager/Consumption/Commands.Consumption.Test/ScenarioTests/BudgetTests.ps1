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
New budget
#>
function Test-NewBudget
{
    $budget = New-AzureRmConsumptionBudget -Amount 60 -Name PSBudget -Category Cost -StartDate 2018-05-01 -EndDate 2018-11-01 -TimeGrain Monthly
	Assert-NotNull $budget
	Assert-AreEqual 60 $budget.Amount
	Assert-AreEqual PSBudget $budget.Name
	Assert-AreEqual Cost $budget.Category
	Assert-AreEqual Monthly $budget.TimeGrain
}

<#
.SYNOPSIS
New budget at resource group level
#>
function Test-NewBudgetAtResourceGroupLevel
{
    $budget = New-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -Amount 60 -Name PSBudgetRG -Category Cost -StartDate 2018-05-01 -EndDate 2018-11-01 -TimeGrain Monthly 
	Assert-NotNull $budget
	Assert-AreEqual 60 $budget.Amount
	Assert-AreEqual PSBudgetRG $budget.Name
	Assert-AreEqual Cost $budget.Category
	Assert-AreEqual Monthly $budget.TimeGrain
}

<#
.SYNOPSIS
Get budgets
#>
function Test-GetBudgets
{
    $budgets = Get-AzureRmConsumptionBudget 
	Assert-NotNull $budgets
}

<#
.SYNOPSIS
Get budgets at resource group level
#>
function Test-GetBudgetsAtResourceGroupLevel
{
    $budgets = Get-AzureRmConsumptionBudget -ResourceGroupName RGBudgets
	Assert-NotNull $budgets
}

<#
.SYNOPSIS
Get budget by name
#>
function Test-GetBudgetByName
{
    $budget = Get-AzureRmConsumptionBudget -Name PSBudget
	Assert-NotNull $budget
	Assert-AreEqual PSBudget $budget.Name
	Assert-NotNull $budget.Amount
	Assert-NotNull $budget.Category
	Assert-NotNull $budget.TimeGrain
}

<#
.SYNOPSIS
Get budget by name at resource group level
#>
function Test-GetBudgetByNameAtResourceGroupLevel
{
    $budget = Get-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -Name PSBudgetRG 
	Assert-NotNull $budget
	Assert-AreEqual PSBudgetRG $budget.Name
	Assert-NotNull $budget.Amount
	Assert-NotNull $budget.Category
	Assert-NotNull $budget.TimeGrain
}

<#
.SYNOPSIS
Set budget
#>
function Test-SetBudget
{
    $budget = Set-AzureRmConsumptionBudget -Name PSBudget -Amount 75
	Assert-NotNull $budget
	Assert-AreEqual PSBudget $budget.Name
	Assert-AreEqual 75 $budget.Amount
	Assert-NotNull $budget.Category
	Assert-NotNull $budget.TimeGrain
}

<#
.SYNOPSIS
Set budget at resource group level
#>
function Test-SetBudgetAtResourceGroupLevel
{
    $budget = Set-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -Name PSBudgetRG -Amount 75
	Assert-NotNull $budget
	Assert-AreEqual PSBudgetRG $budget.Name
	Assert-AreEqual 75 $budget.Amount
	Assert-NotNull $budget.Category
	Assert-NotNull $budget.TimeGrain
}

<#
.SYNOPSIS
Remove budget
#>
function Test-RemoveBudget
{
	Remove-AzureRmConsumptionBudget -Name PSBudget
}

<#
.SYNOPSIS
Remove budget at resource group level
#>
function Test-RemoveBudgetAtResourceGroupLevel
{
	Remove-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -Name PSBudgetRG
}

<#
.SYNOPSIS
New budget with resource group filter
#>
function Test-NewBudgetWithResourceGroupFilter
{
    $budget = New-AzureRmConsumptionBudget -Amount 60 -Name PSBudgetRGF -ResourceGroupFilter CriTest -Category Cost -StartDate 2018-05-01 -EndDate 2018-11-01 -TimeGrain Monthly
	Assert-NotNull $budget
	Assert-AreEqual 60 $budget.Amount
	Assert-AreEqual PSBudgetRGF $budget.Name
	Assert-AreEqual Cost $budget.Category
	Assert-AreEqual Monthly $budget.TimeGrain
	Assert-AreEqual 1 $budget.Filter.ResourceGroups.Count
}

<#
.SYNOPSIS
New budget with resource filter
#>
function Test-NewBudgetWithResourceFilter
{
    $budget = New-AzureRmConsumptionBudget -Amount 60 -Name PSBudgetRF -ResourceFilter /subscriptions/1caaa5a3-2b66-438e-8ab4-bce37d518c5d/resourceGroups/CriTest/providers/Microsoft.Compute/virtualMachines/MSAWSIFT2 -Category Cost -StartDate 2018-05-01 -EndDate 2018-11-01 -TimeGrain Monthly
	Assert-NotNull $budget
	Assert-AreEqual 60 $budget.Amount
	Assert-AreEqual PSBudgetRF $budget.Name
	Assert-AreEqual Cost $budget.Category
	Assert-AreEqual Monthly $budget.TimeGrain
	Assert-AreEqual 1 $budget.Filter.Resources.Count
}

<#
.SYNOPSIS
New budget with meter filter
#>
function Test-NewBudgetWithMeterFilter
{
    $budget = New-AzureRmConsumptionBudget -Amount 60 -Name PSBudgetMF -MeterFilter fe167397-a38d-43c3-9bb3-8e2907e56a41 -Category Usage -StartDate 2018-05-01 -EndDate 2018-11-01 -TimeGrain Monthly
	Assert-NotNull $budget
	Assert-AreEqual 60 $budget.Amount
	Assert-AreEqual PSBudgetMF $budget.Name
	Assert-AreEqual Usage $budget.Category
	Assert-AreEqual Monthly $budget.TimeGrain
	Assert-AreEqual 1 $budget.Filter.Meters.Count
}