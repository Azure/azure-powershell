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
Test New-AzureRmIntegrationAccountAssembly command
#>
function Test-CreateIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path $TestOutputRoot "\Resources\SampleAssembly.dll"
	$assemblyContent = [IO.File]::ReadAllBytes($localAssemblyFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssemblyName = "SampleAssemblyFilePath"
	$resultByFilePath = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyFilePathInputObject"
	$resultByFilePath = New-AzureRmIntegrationAccountAssembly -InputObject $resultByFilePath -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyFilePathId"
	$resultByFilePath = New-AzureRmIntegrationAccountAssembly -ResourceId $resultByFilePath.Id -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytes"
	$resultByBytes = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytesInputObject"
	$resultByBytes = New-AzureRmIntegrationAccountAssembly -InputObject $resultByFilePath -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytesId"
	$resultByBytes = New-AzureRmIntegrationAccountAssembly -ResourceId $resultByFilePath.Id -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLink"
	$resultByContentLink = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLinkInputObject"
	$resultByContentLink = New-AzureRmIntegrationAccountAssembly -InputObject $resultByFilePath -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLinkId"
	$resultByContentLink = New-AzureRmIntegrationAccountAssembly -ResourceId $resultByFilePath.Id -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$integrationAccountAssemblyName = "SampleAssemblyInputObject"
	$result = New-AzureRmIntegrationAccountAssembly -AssemblyName $integrationAccountAssemblyName -InputObject $resultByContentLink
	Assert-AreEqual $integrationAccountAssemblyName $result.Name

	$integrationAccountAssemblyName = "SampleAssemblyId"
	$result = New-AzureRmIntegrationAccountAssembly -AssemblyName $integrationAccountAssemblyName -ResourceId $resultByContentLink.Id
	Assert-AreEqual $integrationAccountAssemblyName $result.Name

	$integrationAccountAssemblyName = "SampleAssemblyNoData"
	Assert-ThrowsContains { New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName } "must have either 'content' or 'contentLink' property set."

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountAssembly command
#>
function Test-GetIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path $TestOutputRoot "\Resources\SampleAssembly.dll"
 	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
 	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssemblyName = "SampleAssembly"
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

 	$resultByName = Get-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssembly.Name
	Assert-AreEqual $integrationAccountAssemblyName $resultByName.Name

	$resultByResourceId = Get-AzureRmIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id
	Assert-AreEqual $integrationAccountAssemblyName $resultByResourceId.Name

	$resultByPipingResourceId = Get-AzureRmIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id | Get-AzureRmIntegrationAccountAssembly
	Assert-AreEqual $integrationAccountAssemblyName $resultByPipingResourceId.Name

	$resultByInputObject = Get-AzureRmIntegrationAccountAssembly -InputObject $integrationAccountAssembly
	Assert-AreEqual $integrationAccountAssemblyName $resultByInputObject.Name

	$resultByPipingInputObject = $integrationAccountAssembly | Get-AzureRmIntegrationAccountAssembly
	Assert-AreEqual $integrationAccountAssemblyName $resultByPipingInputObject.Name

 	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountAssembly command : List
#>
function Test-ListIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path $TestOutputRoot "\Resources\SampleAssembly.dll"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssemblyName = "SampleAssembly"
	
	$val=0
	while($val -ne 3)
	{
		$val++;
		$integrationAccountAssemblyName = "Assembly-$val-" + (getAssetname)
		$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	}

	$result =  Get-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 3 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountAssembly command
#>
function Test-RemoveIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path $TestOutputRoot "\Resources\SampleAssembly.dll"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssemblyName = "SampleAssembly"
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Remove-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName

	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Remove-AzureRmIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id

	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Remove-AzureRmIntegrationAccountAssembly -InputObject $integrationAccountAssembly

	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	$integrationAccountAssembly | Remove-AzureRmIntegrationAccountAssembly

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountAssembly command
#>
function Test-UpdateIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path $TestOutputRoot "\Resources\SampleAssembly.dll"
	$assemblyContent = [IO.File]::ReadAllBytes($localAssemblyFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssemblyName = "SampleAssemblyFilePath"
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name
	
	$resultByFilePath = Set-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$resultByFilePath = Set-AzureRmIntegrationAccountAssembly -InputObject $resultByFilePath -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$resultByFilePath = Set-AzureRmIntegrationAccountAssembly -ResourceId $resultByFilePath.Id -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytes"
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$resultByBytes = Set-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$resultByBytes = Set-AzureRmIntegrationAccountAssembly -InputObject $integrationAccountAssembly -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$resultByBytes = Set-AzureRmIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLink"
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$resultByContentLink = Set-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$resultByContentLink = Set-AzureRmIntegrationAccountAssembly -InputObject $integrationAccountAssembly -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$resultByContentLink = Set-AzureRmIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test end to end piping
#>
function Test-EndToEndAssemblyPiping
{
	$localAssemblyFilePath = Join-Path $TestOutputRoot "\Resources\SampleAssembly.dll"
 	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssemblyName = "SampleAssembly"
	New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath | Get-AzureRmIntegrationAccountAssembly | Set-AzureRmIntegrationAccountAssembly | Remove-AzureRmIntegrationAccountAssembly

 	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}