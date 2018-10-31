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
Test New-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-CreateIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = "$TestOutputRoot\Resources\SampleBatchConfiguration.json"
	$batchConfigurationContent = [IO.File]::ReadAllText($batchConfigurationFilePath)
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountBatchConfigurationName1 = "BC" + (getAssetname)
	$integrationAccountBatchConfigurationName2 = "BC" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountBatchConfiguration1 =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName1 -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $integrationAccountBatchConfigurationName1 $integrationAccountBatchConfiguration1.Name

	$integrationAccountBatchConfiguration2 =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName2 -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $integrationAccountBatchConfigurationName2 $integrationAccountBatchConfiguration2.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-GetIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = "$TestOutputRoot\Resources\SampleBatchConfiguration.json"
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountBatchConfigurationName = "BC" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $integrationAccountBatchConfigurationName $integrationAccountBatchConfiguration.Name

	$result = Get-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName
	Assert-AreEqual $integrationAccountBatchConfigurationName $result.Name

	$result1 = Get-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-AreEqual $integrationAccountBatchConfigurationName $result1.Name
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-RemoveIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = "$TestOutputRoot\Resources\SampleBatchConfiguration.json"
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountBatchConfigurationName = "BC" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $integrationAccountBatchConfigurationName $integrationAccountBatchConfiguration.Name

	Remove-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-UpdateIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = "$TestOutputRoot\Resources\SampleBatchConfiguration.json"
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountBatchConfigurationName = "BC" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $integrationAccountBatchConfigurationName $integrationAccountBatchConfiguration.Name

	$integrationAccountBatchConfigurationUpdated = Set-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath -Force
	Assert-AreEqual $integrationAccountBatchConfigurationName $integrationAccountBatchConfiguration.Name
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountBatchConfiguration command : Paging test
#>
function Test-ListIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = "$TestOutputRoot\Resources\SampleBatchConfiguration.json"
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$val=0
	while($val -ne 3)
	{
		$val++ ;
		$integrationAccountBatchConfigurationName = "BC$val" + (getAssetname)
		New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	}

	$result =  Get-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 3 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}