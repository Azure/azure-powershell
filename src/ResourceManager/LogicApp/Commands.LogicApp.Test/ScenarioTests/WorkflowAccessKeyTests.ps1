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
Test Get-AzureLogicAppAccessKey for workflow
#>
function Test-GetAzureLogicAppAccessKey
{

	$resourceGroupName = getAssetname
	$workflowName = getAssetname
	$planName = "StandardServicePlan"	

	$workflow = TestSetup-CreateWorkflow $resourceGroupName $workflowName $planName	

	#Case1: Get access keys of the workflow
	$workflowAccessKeys = Get-AzureRmLogicAppAccessKey -ResourceGroupName $resourceGroupName -Name $workflowName
	Assert-NotNull $workflowAccessKeys
	
	#Case2: Get specific access key of the workflow
	$workflowAccessKeys = Get-AzureRmLogicAppAccessKey -ResourceGroupName $resourceGroupName -Name $workflowName -AccessKeyName "default"
	Assert-NotNull $workflowAccessKeys		
}

<#
.SYNOPSIS
Test Set-AzureLogicAppAccessKey for workflow
#>
function Test-SetAzureLogicAppAccessKey
{
	$resourceGroupName = getAssetname
	$workflowName = getAssetname
	$planName = "StandardServicePlan"		
	$workflow = TestSetup-CreateWorkflow $resourceGroupName $workflowName $planName	

	#Case1: Regenerate secret for the access key of the workflow
	$workflowAccessKeys = Get-AzureRmLogicAppAccessKey -ResourceGroupName $resourceGroupName -Name $workflowName
	$workflowAccessKey1 = Set-AzureRmLogicAppAccessKey -ResourceGroupName $resourceGroupName -Name $workflowName -AccessKeyName "default" -KeyType "Primary"
	$workflowAccessKey2 = Set-AzureRmLogicAppAccessKey -ResourceGroupName $resourceGroupName -Name $workflowName -AccessKeyName "default" -KeyType "Secondary"	
	
	Assert-AreNotEqual $workflowAccessKey1.PrimarySecretKey $workflowAccessKeys.PrimarySecretKey
	Assert-AreNotEqual $workflowAccessKey2.SecondarySecretKey $workflowAccessKeys.SecondarySecretKey	
}