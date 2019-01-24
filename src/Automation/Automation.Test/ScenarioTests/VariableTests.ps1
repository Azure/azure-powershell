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
function Test-E2EVariableAsset
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "CreateNewVariableWithValue"
    $variableValue = "StringValue"
    $variableValueUpdated = "StringValueChanged"

    $variableCreated = New-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName `
                                                     -name $variableName `
                                                     -value $variableValue `
                                                     -Encrypted:$false `
                                                     -Description "Hello"

    $getVariable = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -name $variableName

    Assert-AreEqual "Hello"  $getVariable.Description

    Set-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $variableName `
                                  -Encrypted:$false `
                                  -value $variableValueUpdated

    $getVariable = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -name $variableName

    Assert-AreEqual $variableValueUpdated  $getVariable.value

    Remove-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $variableName 

    $output = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName `
                                            -name $variableName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
 }