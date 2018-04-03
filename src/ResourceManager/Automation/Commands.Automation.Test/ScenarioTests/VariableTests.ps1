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
Tests create new automation variable with string value.
#>
function Test-CreateNewVariableWithStringValue
{
	$automationAccount = CreateAutomationAccount
	$resourceGroupName = $automationAccount.ResourceGroupName
	$automationAccountName = $automationAccount.AutomationAccountName
    
	$variableName = "CreateNewVariableWithValue"
	$variableValue = "StringValue"

	$variableCreated = New-AzureRmAutomationVariable -ResourceGroupName $resourceGroupName `
	                                                 -AutomationAccountName $automationAccountName `
													 -name $variableName `
													 -value $variableValue `
													 -Encrypted:$false
	$getVariable = Get-AzureRmAutomationVariable -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -name $variableName

	Assert-AreEqual $variableName  $getVariable.Name	
	Assert-AreEqual $variableValue $getVariable.Value	
 }

<#
.SYNOPSIS
Tests create new automation variable with Get-Content.
Test case for issue https://github.com/Azure/azure-powershell/issues/5607
#>
function Test-CreateNewVariableWithGetContent
{
	$automationAccount = CreateAutomationAccount
	$resourceGroupName = $automationAccount.ResourceGroupName
	$automationAccountName = $automationAccount.AutomationAccountName
    
	$variableName = "GetContentVariable"

	$fileName = "$env:temp\CreateNewVariableWithGetContent.txt"
	
	echo "testline1" > $fileName
    echo "testline2" >> $fileName

	$variableValue = Get-Content $fileName

	$variableCreated = New-AzureRmAutomationVariable -ResourceGroupName $resourceGroupName `
	                                                 -AutomationAccountName $automationAccountName `
													 -name $variableName `
													 -value $variableValue `
													 -Encrypted:$false
	$getVariable = Get-AzureRmAutomationVariable -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -name $variableName

	Assert-AreEqual $variableName $getVariable.Name
		
	Remove-Item $fileName
 }

<#
.SYNOPSIS
Tests create new automation variable with lage data throws time out.
Test case for issue https://github.com/Azure/azure-powershell/issues/5607
#>
function Test-CreateNewVariableWithLargeDataThrowsTimeOut
{
	$automationAccount = CreateAutomationAccount
	$resourceGroupName = $automationAccount.ResourceGroupName
	$automationAccountName = $automationAccount.AutomationAccountName

	$variableName = "GetContentVariableWithLargeData"

	$fileName = "$env:temp\CreateNewVariableWithLargeDataThrowsTimeOut.txt"
	
	echo "testlines" > $fileName
    for($i = 0; $i -lt 1000; $i++)
    {
      echo "testline$i" >> $fileName
    }
	
	$variableValue = Get-Content $fileName

	New-AzureRmAutomationVariable -ResourceGroupName $resourceGroupName `
	                              -AutomationAccountName $automationAccountName `
								  -name $variableName `
								  -value $variableValue `
								  -Encrypted:$false `
								  -ErrorAction SilentlyContinue

	Assert-True { $Error[0] -like "Input value could not be serialized to json. Operation had timed out in*" }
	$Error.Clear()
	
	Remove-Item $fileName
}