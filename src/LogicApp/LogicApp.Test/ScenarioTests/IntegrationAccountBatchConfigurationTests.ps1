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
Test New-AzIntegrationAccountBatchConfiguration command
#>
function Test-NewIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleBatchConfiguration.json"
	$batchConfigurationContent = [IO.File]::ReadAllText($batchConfigurationFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	$sampleMetadata = (SampleMetadata)

	$batchConfigurationName = "BCJson"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCJsonParObj"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ParentObject $integrationAccount -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCJsonId"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ParentResourceId $integrationAccount.Id -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCFilePath"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCFilePathParObj"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ParentObject $integrationAccount -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCFilePathId"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ParentResourceId $integrationAccount.Id -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$batchConfigurationName = "BCParameters"
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -MessageCount 199 -BatchSize 5 -ScheduleInterval 1 -ScheduleFrequency "Month"
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name
	Assert-AreEqual 199 $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.MessageCount
	Assert-AreEqual 5 $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.BatchSize
	Assert-AreEqual 1 $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Interval
	Assert-AreEqual "Month" $integrationAccountBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Frequency

	$batchConfigurationName = "BCMetadata"
	$batchConfigurationMetadata =  New-AzIntegrationAccountBatchConfiguration -ParentResourceId $integrationAccount.Id -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath -Metadata $sampleMetadata
	Assert-AreEqual $batchConfigurationName $batchConfigurationMetadata.Name
	Assert-AreEqual $sampleMetadata["key1"] $batchConfigurationMetadata.Properties.Metadata["key1"].Value

	$batchConfigurationName = "BCNoParameters"
	Assert-ThrowsContains { New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName } "At least one release criteria must be provided."

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountBatchConfiguration command
#>
function Test-GetIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleBatchConfiguration.json"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	$sampleMetadata = (SampleMetadata)

	$batchConfigurationName = "BC" + (getAssetname)
	$integrationAccountBatchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath -Metadata $sampleMetadata
	Assert-AreEqual $batchConfigurationName $integrationAccountBatchConfiguration.Name

	$resultByName = Get-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $integrationAccountBatchConfiguration.Name
	Assert-AreEqual $batchConfigurationName $resultByName.Name
	Assert-AreEqual $sampleMetadata["key1"] $resultByName.Properties.Metadata["key1"].Value

	$resultByResourceId = Get-AzIntegrationAccountBatchConfiguration -ParentResourceId $integrationAccount.Id -BatchConfigurationName $batchConfigurationName
	Assert-AreEqual $batchConfigurationName $resultByResourceId.Name

	$resultByResourceId = Get-AzIntegrationAccountBatchConfiguration -ParentResourceId $integrationAccount.Id
	Assert-AreEqual 1 $resultByResourceId.Count

	$resultByInputObject = Get-AzIntegrationAccountBatchConfiguration -ParentObject $integrationAccount -BatchConfigurationName $batchConfigurationName
	Assert-AreEqual $batchConfigurationName $resultByInputObject.Name

	$resultByPipingInputObject = $integrationAccount | Get-AzIntegrationAccountBatchConfiguration -BatchConfigurationName $batchConfigurationName
	Assert-AreEqual $batchConfigurationName $resultByPipingInputObject.Name

	$resultByInputObject = Get-AzIntegrationAccountBatchConfiguration -ParentObject $integrationAccount
	Assert-AreEqual 1 $resultByInputObject.Count

	$resultByPipingInputObject = $integrationAccount | Get-AzIntegrationAccountBatchConfiguration
	Assert-AreEqual 1 $resultByPipingInputObject.Count

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzIntegrationAccountBatchConfiguration command
#>
function Test-RemoveIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleBatchConfiguration.json"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$batchConfigurationName = "BC" + (getAssetname)	
	$batchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName

	$batchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzIntegrationAccountBatchConfiguration -ResourceId $batchConfiguration.Id

	$batchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzIntegrationAccountBatchConfiguration -InputObject $batchConfiguration

	$batchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Remove-AzIntegrationAccountBatchConfiguration  -InputObject $batchConfiguration

	$batchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	$batchConfiguration | Remove-AzIntegrationAccountBatchConfiguration

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzIntegrationAccountBatchConfiguration command
#>
function Test-SetIntegrationAccountBatchConfiguration
{
	$batchConfigurationFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleBatchConfiguration.json"
	$batchConfigurationContent = [IO.File]::ReadAllText($batchConfigurationFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$batchConfigurationName = "OriginalBC"
	$batchConfiguration =  New-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $batchConfiguration.Name

	$edittedBatchConfiguration =  Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationDefinition $batchConfigurationContent
	Assert-AreEqual $batchConfigurationName $edittedBatchConfiguration.Name

	$edittedBatchConfiguration =  Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -BatchConfigurationFilePath $batchConfigurationFilePath
	Assert-AreEqual $batchConfigurationName $edittedBatchConfiguration.Name

	$edittedBatchConfiguration =  Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName -MessageCount 199 -BatchSize 5 -ScheduleInterval 1 -ScheduleFrequency "Month"
	Assert-AreEqual $batchConfigurationName $edittedBatchConfiguration.Name
	Assert-AreEqual 199 $edittedBatchConfiguration.Properties.ReleaseCriteria.MessageCount
	Assert-AreEqual 5 $edittedBatchConfiguration.Properties.ReleaseCriteria.BatchSize
	Assert-AreEqual 1 $edittedBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Interval
	Assert-AreEqual "Month" $edittedBatchConfiguration.Properties.ReleaseCriteria.Recurrence.Frequency

	Assert-ThrowsContains { Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -BatchConfigurationName $batchConfigurationName } "At least one release criteria must be provided."

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
} 