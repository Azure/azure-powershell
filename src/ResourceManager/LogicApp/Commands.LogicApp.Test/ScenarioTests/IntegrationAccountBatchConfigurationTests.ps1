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
	$batchConfigurationFilePath = Join-Path $TestOutputRoot "\Resources\SampleBatchConfiguration.json"
	$batchConfigurationContent = [IO.File]::ReadAllText($batchConfigurationFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$batchConfigurationName = "BCJson"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCJsonInOb"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -InputObject $integrationAccountBatchConfiguration -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCJsonId"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceId $integrationAccountBatchConfiguration.Id -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCFilePath"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCFilePathInOb"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -InputObject $integrationAccountBatchConfiguration -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCFilePathId"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceId $integrationAccountBatchConfiguration.Id -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCParameters"
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -MessageCount 199 -BatchSize 5 -ScheduleInterval 1 -ScheduleFrequency "Month"
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name
	Assert-AreEqual 199 $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.MessageCount
	Assert-AreEqual 5 $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.BatchSize
	Assert-AreEqual 1 $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Interval
	Assert-AreEqual "Month" $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Frequency

	$batchConfigurationName = "BCNoParameters"
	Assert-ThrowsContains { New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName } "At least one release criteria must be provided."

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-GetIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path $TestOutputRoot "\Resources\SampleBatchConfiguration.json"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$batchConfigurationName = "BC" + (getAssetname)
	$integrationAccountBatchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$resultByName = Get-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfiguration.Name
	Assert-AreEqual $batchConfigurationName $resultByName.Name

	$resultByResourceId = Get-AzureRmIntegrationAccountBatchConfiguration -ResourceId $resultByName.Id
	Assert-AreEqual $batchConfigurationName $resultByResourceId.Name

	$resultByPipingResourceId = Get-AzureRmIntegrationAccountBatchConfiguration -ResourceId $resultByName.Id | Get-AzureRmIntegrationAccountBatchConfiguration
	Assert-AreEqual $batchConfigurationName $resultByPipingResourceId.Name

	$resultByInputObject = Get-AzureRmIntegrationAccountBatchConfiguration -InputObject $resultByName
	Assert-AreEqual $batchConfigurationName $resultByInputObject.Name

	$resultByPipingInputObject = $resultByName | Get-AzureRmIntegrationAccountBatchConfiguration
	Assert-AreEqual $batchConfigurationName $resultByPipingInputObject.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-RemoveIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path $TestOutputRoot "\Resources\SampleBatchConfiguration.json"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$batchConfigurationName = "BC" + (getAssetname)	
	$batchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName

	$batchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzureRmIntegrationAccountBatchConfiguration -ResourceId $batchConfiguration.Id

	$batchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzureRmIntegrationAccountBatchConfiguration -InputObject $batchConfiguration

	$batchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzureRmIntegrationAccountBatchConfiguration  -InputObject $batchConfiguration

	$batchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	$batchConfiguration | Remove-AzureRmIntegrationAccountBatchConfiguration

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountBatchConfiguration command
#>
function Test-UpdateIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path $TestOutputRoot "\Resources\SampleBatchConfiguration.json"
	$batchConfigurationContent = [IO.File]::ReadAllText($batchConfigurationFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$batchConfigurationName = "OriginalBC"
	$batchConfiguration =  New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $batchConfiguration.Name

	$edittedBatchConfiguration =  Set-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $edittedBatchConfiguration.Name

	$edittedBatchConfiguration =  Set-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $edittedBatchConfiguration.Name

	$edittedBatchConfiguration =  Set-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -MessageCount 199 -BatchSize 5 -ScheduleInterval 1 -ScheduleFrequency "Month"
	Assert-AreEqual $batchConfigurationName $edittedBatchConfiguration.Name
	Assert-AreEqual 199 $edittedBatchConfiguration.Properties.ReleaseCriteria.MessageCount
	Assert-AreEqual 5 $edittedBatchConfiguration.Properties.ReleaseCriteria.BatchSize
	Assert-AreEqual 1 $edittedBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Interval
	Assert-AreEqual "Month" $edittedBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Frequency

	Assert-ThrowsContains { Set-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName } "At least one release criteria must be provided."

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountBatchConfiguration command : Paging test
#>
function Test-ListIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path $TestOutputRoot "\Resources\SampleBatchConfiguration.json"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$val=0
	while($val -ne 3)
	{
		$val++;
		$batchConfigurationName = "BC$val" + (getAssetname)
		New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	}

	$result =  Get-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 3 }

 	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test end to end piping
#>
function Test-EndToEndBatchConfigurationPiping
{
	$batchConfigurationFilePath = Join-Path $TestOutputRoot "\Resources\SampleBatchConfiguration.json"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$batchConfigurationName = "BC" + (getAssetname)
	New-AzureRmIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Name $batchConfigurationName  -BatchConfigurationFilePath $batchConfigurationFilePath | Get-AzureRmIntegrationAccountBatchConfiguration | Set-AzureRmIntegrationAccountBatchConfiguration | Remove-AzureRmIntegrationAccountBatchConfiguration

 	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}