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

$newAccountName='account-powershell-test'
$existingResourceGroup='PowerShellTest'
$location = "West Central US"

########################################################################### Automation Scenario Tests ###########################################################################

######### $accountName and $subscriptionName should be provided in variables.yml in order to run the following Test Cases #######################

<#
.SYNOPSIS
Check if test account exists and remove it
#>
function CleanupExistingTestAccount
{
	$check = Get-AzAutomationAccount -ResourceGroupName $existingResourceGroup -Name $newAccountName -ErrorAction SilentlyContinue
	if ($null -ne $check)
	{
		Remove-AzAutomationAccount -ResourceGroupName $existingResourceGroup -Name $newAccountName -Force
	}
}

function CreateResourceGroup
{
	$check = Get-AzResourceGroup -Name $existingResourceGroup -Location $location -ErrorAction SilentlyContinue
	if ($null -eq $check)
	{
		New-AzResourceGroup -Name $existingResourceGroup -Location $location -Force
	}
}
<#
.SYNOPSIS
Create Test Automation Account
#>
function CreateTestAccount
{
	return New-AzAutomationAccount -ResourceGroupName $existingResourceGroup -Name $newAccountName -Location $location
}

<#
.SYNOPSIS
Tests Runbook with Parameters
#>
function Test-GetAutomationAccounts
{
	# setup
	CreateResourceGroup
	CleanupExistingTestAccount

	# get all accounts
    $automationAccounts = Get-AzAutomationAccount
    Assert-NotNull $automationAccounts "Get All automation accounts return null."

	$existingAccountCount = $automationAccounts.Count
    
    $newAutomationAccount = CreateTestAccount
    Assert-NotNull $newAutomationAccount "Create Account Failed."

    #Test
    $automationAccounts = Get-AzAutomationAccount
    
	$newAccountCount = $automationAccounts.Count
	Assert-AreEqual ($existingAccountCount+1) $newAccountCount "There should have only 1 more account"

	CleanupExistingTestAccount
}

<#
.SYNOPSIS
Tests of Start and Stop RunBook
#>
function Test-AutomationAccountTags
{
    # setup
	CreateResourceGroup
	CleanupExistingTestAccount
	$newAutomationAccount = CreateTestAccount
	Assert-AreEqual $newAutomationAccount.Tags.Count 0 "Unexpected Tag Counts"

	# re-put using new
	$newAutomationAccount = New-AzAutomationAccount -ResourceGroupName $existingResourceGroup -Name $newAccountName -Location $location -Tags @{"abc"="def"; "gg"="hh"}
	Assert-AreEqual $newAutomationAccount.Tags.Count 2 "Unexpected Tag Counts from new"
	Assert-AreEqual $newAutomationAccount.Tags["gg"] "hh" "Unexpected Tag Content from new"

	# use Set
	$newAutomationAccount = Set-AzAutomationAccount -ResourceGroupName $existingResourceGroup -Name $newAccountName -Tags @{"lm"="jk"}
	Assert-AreEqual $newAutomationAccount.Tags.Count 1 "Unexpected Tag Counts from set"
	Assert-AreEqual $newAutomationAccount.Tags["lm"] "jk" "Unexpected Tag Content from set"

	# test tag from accounts 
	$newAutomationAccount = Get-AzAutomationAccount | Where-Object {$_.AutomationAccountName -eq $newAccountName }
	Assert-AreEqual $newAutomationAccount.Tags.Count 1 "Unexpected Tag Counts from get all"
	Assert-AreEqual $newAutomationAccount.Tags["lm"] "jk" "Unexpected Tag Content from get all"

	CleanupExistingTestAccount
}