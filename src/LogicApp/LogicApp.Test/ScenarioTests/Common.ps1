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

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function CurrentApiVersion 
{
	return "2018-07-01-preview"
}

function SampleMetadata
{
	return @{ "key1" = "value1"; "key2" = "value2"; "key3" = "value3"; }
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = "RG-" + (getAssetname)
	$location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $location

	return $resourceGroup
}

<#
.SYNOPSIS
Creates a new Integration account
#>
function TestSetup-CreateIntegrationAccount ([string]$resourceGroupName, [string]$integrationAccountName)
{
	$location = Get-Location "Microsoft.Logic" "integrationAccounts" "West US"
	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"
	return $integrationAccount
}

<#
.SYNOPSIS
Creates a new workflow
#>
function TestSetup-CreateWorkflow ([string]$resourceGroupName, [string]$workflowName, [string]$AppServicePlan)
{
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $rglocation -Force

	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowDefinition.json"
	$parameterFilePath = Join-Path "Resources" "TestSimpleWorkflowParameter.json"
	$workflow = $resourceGroup | New-AzLogicApp -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
    return $workflow
}

<#
.SYNOPSIS
Sleep in record mode only
#>
function SleepInRecordMode ([int]$SleepIntervalInMillisec)
{
	$mode = $env:AZURE_TEST_MODE
	if ( $mode -ne $null -and $mode.ToUpperInvariant() -eq "RECORD")
	{
		Sleep -Milliseconds $SleepIntervalInMillisec 
	}
}