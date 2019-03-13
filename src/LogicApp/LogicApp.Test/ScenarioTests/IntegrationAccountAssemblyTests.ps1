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
Test New-AzIntegrationAccountAssembly command
#>
function Test-NewIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleAssembly.dll"
	$assemblyContent = [IO.File]::ReadAllBytes($localAssemblyFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	$sampleMetadata = (SampleMetadata)

	$integrationAccountAssemblyName = "SampleAssemblyFilePath"
	$resultByFilePath = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyFilePathParentObject"
	$resultByFilePath = New-AzIntegrationAccountAssembly -ParentObject $integrationAccount -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyFilePathId"
	$resultByFilePath = New-AzIntegrationAccountAssembly -ParentResourceId $resultByFilePath.Id -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytes"
	$resultByBytes = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytesParentObject"
	$resultByBytes = New-AzIntegrationAccountAssembly -ParentObject $integrationAccount -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytesId"
	$resultByBytes = New-AzIntegrationAccountAssembly -ParentResourceId $resultByFilePath.Id -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLink"
	$resultByContentLink = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLinkParentObject"
	$resultByContentLink = New-AzIntegrationAccountAssembly -ParentObject $integrationAccount -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLinkId"
	$resultByContentLink = New-AzIntegrationAccountAssembly -ParentResourceId $resultByFilePath.Id -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$integrationAccountAssemblyName = "SampleAssemblyMetadata"
	$resultMetadata = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath -Metadata $sampleMetadata
	Assert-AreEqual $integrationAccountAssemblyName $resultMetadata.Name
	Assert-AreEqual $sampleMetadata["key1"] $resultMetadata.Properties.Metadata["key1"].Value

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Get-AzIntegrationAccountAssembly command
#>
function Test-GetIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleAssembly.dll"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	$sampleMetadata = (SampleMetadata)

	$integrationAccountAssemblyName = "SampleAssembly"
	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath -Metadata $sampleMetadata
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name
	Assert-AreEqual $sampleMetadata["key1"] $integrationAccountAssembly.Properties.Metadata["key1"].Value

	$resultByName = Get-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssembly.Name
	Assert-AreEqual $integrationAccountAssemblyName $resultByName.Name

	$resultByResourceId = Get-AzIntegrationAccountAssembly -ParentResourceId $integrationAccount.Id -AssemblyName $integrationAccountAssemblyName
	Assert-AreEqual $integrationAccountAssemblyName $resultByResourceId.Name

	$resultByResourceId = Get-AzIntegrationAccountAssembly -ParentResourceId $integrationAccount.Id
	Assert-AreEqual 1 $resultByResourceId.Count

	$resultByInputObject = Get-AzIntegrationAccountAssembly -ParentObject $integrationAccount -AssemblyName $integrationAccountAssemblyName
	Assert-AreEqual $integrationAccountAssemblyName $resultByInputObject.Name

	$resultByPipingInputObject = $integrationAccount | Get-AzIntegrationAccountAssembly -AssemblyName $integrationAccountAssemblyName
	Assert-AreEqual $integrationAccountAssemblyName $resultByPipingInputObject.Name

	$resultByInputObject = Get-AzIntegrationAccountAssembly -ParentObject $integrationAccount
	Assert-AreEqual 1 $resultByInputObject.Count

	$resultByPipingInputObject = $integrationAccount | Get-AzIntegrationAccountAssembly
	Assert-AreEqual 1 $resultByPipingInputObject.Count

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Remove-AzIntegrationAccountAssembly command
#>
function Test-RemoveIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleAssembly.dll"
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountAssemblyName = "SampleAssembly"
	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Remove-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName

	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Remove-AzIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id

	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Remove-AzIntegrationAccountAssembly -InputObject $integrationAccountAssembly

	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	$integrationAccountAssembly | Remove-AzIntegrationAccountAssembly

	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Get-AzIntegrationAccountAssembly -ParentObject $integrationAccount -AssemblyName $integrationAccountAssemblyName | Remove-AzIntegrationAccountAssembly

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

 <#
.SYNOPSIS
Test Set-AzIntegrationAccountAssembly command
#>
function Test-SetIntegrationAccountAssembly
{
	$localAssemblyFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleAssembly.dll"
	$assemblyContent = [IO.File]::ReadAllBytes($localAssemblyFilePath)
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountAssemblyName = "SampleAssemblyFilePath"
	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$resultByFilePath = Set-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$resultByFilePath = Set-AzIntegrationAccountAssembly -InputObject $resultByFilePath -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$resultByFilePath = Set-AzIntegrationAccountAssembly -ResourceId $resultByFilePath.Id -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $resultByFilePath.Name

	$integrationAccountAssemblyName = "SampleAssemblyBytes"
	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$resultByBytes = Set-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$resultByBytes = Set-AzIntegrationAccountAssembly -InputObject $integrationAccountAssembly -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$resultByBytes = Set-AzIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id -AssemblyData $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $resultByBytes.Name

	$integrationAccountAssemblyName = "SampleAssemblyContentLink"
	$integrationAccountAssembly = New-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$resultByContentLink = Set-AzIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$resultByContentLink = Set-AzIntegrationAccountAssembly -InputObject $integrationAccountAssembly -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	$resultByContentLink = Set-AzIntegrationAccountAssembly -ResourceId $integrationAccountAssembly.Id -ContentLink $resultByBytes.Properties.ContentLink.Uri
	Assert-AreEqual $integrationAccountAssemblyName $resultByContentLink.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}