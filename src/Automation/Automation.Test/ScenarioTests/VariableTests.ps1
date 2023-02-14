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
function Test-StringVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "StringValue"
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
 
<#
.SYNOPSIS
Tests create new automation variable with string value.
#>
function Test-IntVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "CreateNewVariableWithValue"
    $variableValue = 1
    $variableValueUpdated = 2

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
 
<#
.SYNOPSIS
Tests create new automation variable with string value.
#>
function Test-FloatVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "NewFloatVariable"
    $variableValue = 1.1
    $variableValueUpdated = 2.2

    $variableCreated = New-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName `
                                                     -name $variableName `
                                                     -value $variableValue `
                                                     -Encrypted:$false `
                                                     -Description "float"
    Assert-AreEqual ($variableValue | ConvertTo-Json) $variableCreated.value.toString()

    $getVariable = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -name $variableName

    Set-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $variableName `
                                  -Encrypted:$false `
                                  -value $variableValueUpdated

    $getVariable = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                 -AutomationAccountName $automationAccountName `
                                                 -name $variableName
                                                 
    Assert-AreEqual ($variableValueUpdated | ConvertTo-Json) $getVariable.value.toString()

    Remove-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $variableName 

    $output = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName `
                                            -name $variableName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
 }

<#
.SYNOPSIS
Tests create new automation variable with array.
#>
function Test-ArrayVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "NewArrayVariable"
    $variableValue = @(@{"key1" = "value1"}, @{"key2" = "value2"}, @{"key3" = "value3"})
    $variableValueUpdated = @(@{"key1" = "value1"}, @{"key2" = "value2"})

    $variableCreated = New-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName `
                                                     -name $variableName `
                                                     -value $variableValue `
                                                     -Encrypted:$false `
                                                     -Description "array"
    Assert-AreEqual ($variableValue | ConvertTo-Json -Compress -Depth 2) ($variableCreated.value | ConvertTo-Json -Compress -Depth 2)

    $updateVariable = Set-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $variableName `
                                  -Encrypted:$false `
                                  -value $variableValueUpdated
                                                 
    Assert-AreEqual ($variableValueUpdated | ConvertTo-Json -Compress -Depth 2) ($updateVariable.value | ConvertTo-Json -Compress -Depth 2)

    Remove-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $variableName 

    $output = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName `
                                            -name $variableName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
 }

<#
.SYNOPSIS
Tests create new automation variable with simple hashtable.
#>
function Test-NormalHashTableVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "NormalHashTable"
    $variableValue = @{"key0" = "value0"}
    $variableValueUpdated = @{"key1" = "value1"}

    $variableCreated = New-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName `
                                                     -name $variableName `
                                                     -value $variableValue `
                                                     -Encrypted:$false `
                                                     -Description "NormalHashTableVariable"
    Assert-AreEqual ($variableValue | ConvertTo-Json -Compress -Depth 2) ($variableCreated.value | ConvertTo-Json -Compress -Depth 2)

    $updateVariable = Set-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $variableName `
                                  -Encrypted:$false `
                                  -value $variableValueUpdated
                                                 
    Assert-AreEqual ($variableValueUpdated | ConvertTo-Json -Compress -Depth 2) ($updateVariable.value | ConvertTo-Json -Compress -Depth 2)

    Remove-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $variableName 

    $output = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName `
                                            -name $variableName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
 }

<#
.SYNOPSIS
Tests create new automation variable with multi level dict.
#>
function Test-MultiLevelDictVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "MultiLevelDict"
    $variableValue = @{"key0" = @{"subkey" = "subvalue"}}
    $variableValueUpdated = @{"key0" = @{"subkey" = @{"3rdkey" = "3rd-value"}}}

    $variableCreated = New-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName `
                                                     -name $variableName `
                                                     -value $variableValue `
                                                     -Encrypted:$false `
                                                     -Description "MultiLevelDict"
    Assert-AreEqual ($variableValue | ConvertTo-Json -Compress -Depth 2) ($variableCreated.value | ConvertTo-Json -Compress -Depth 2)

    $updateVariable = Set-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $variableName `
                                  -Encrypted:$false `
                                  -value $variableValueUpdated
                                                 
    Assert-AreEqual ($variableValueUpdated | ConvertTo-Json -Compress -Depth 2) ($updateVariable.value | ConvertTo-Json -Compress -Depth 2)

    Remove-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $variableName 

    $output = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName `
                                            -name $variableName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
 }

<#
.SYNOPSIS
Tests create new automation variable with multi level dict.
#>
function Test-JsonInDictValueVariable
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $variableName = "JsonInDictValue"
    $variableValue = @{"key0" = "{`"subkey`" = `"sub-value`"}"}
    $variableValueUpdated = @{"key0" = "{`"subkey`" = `"0`"}"}

    $variableCreated = New-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                                     -AutomationAccountName $automationAccountName `
                                                     -name $variableName `
                                                     -value $variableValue `
                                                     -Encrypted:$false `
                                                     -Description "JsonInDictValue"
    Assert-AreEqual ($variableValue | ConvertTo-Json -Compress -Depth 2) ($variableCreated.value | ConvertTo-Json -Compress -Depth 2)

    $updateVariable = Set-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                  -AutomationAccountName $automationAccountName `
                                  -Name $variableName `
                                  -Encrypted:$false `
                                  -value $variableValueUpdated
                                                 
    Assert-AreEqual ($variableValueUpdated | ConvertTo-Json -Compress -Depth 2) ($updateVariable.value | ConvertTo-Json -Compress -Depth 2)

    Remove-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                     -AutomationAccountName $automationAccountName `
                                     -Name $variableName 

    $output = Get-AzAutomationVariable -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName `
                                            -name $variableName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
 }