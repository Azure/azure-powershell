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
Test New-AzureRmIntegrationAccountMap command
#>
function Test-CreateIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName1 = getAssetname
	$integrationAccountMapName2 = getAssetname
	$integrationAccountMapName3 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountMap1 =  New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName1 -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName1 $integrationAccountMap1.Name

	$integrationAccountMap2 =  New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName2 -MapFilePath $mapFilePath
	Assert-AreEqual $integrationAccountMapName2 $integrationAccountMap2.Name

	$integrationAccountMap3 =  New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName3 -MapFilePath $mapFilePath -MapType "Xslt" -ContentType "application/xml"
	Assert-AreEqual $integrationAccountMapName3 $integrationAccountMap3.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountMap command
#>
function Test-GetIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountMap =  New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	$result =  Get-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName
	Assert-AreEqual $integrationAccountMapName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-AreEqual $integrationAccountMapName $result1.Name
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountMap command
#>
function Test-RemoveIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountMap =  New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	Remove-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountMap command
#>
function Test-UpdateIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountMap =  New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	$integrationAccountMapUpdated =  Set-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent -Force
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	$integrationAccountMapUpdated =  Set-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent -Force
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountMap command : Paging test
#>
function Test-ListIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$val=0
	while($val -ne 1)
	{
		$val++ ;
		$integrationAccountMapName = getAssetname
		New-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	}

	$result =  Get-AzureRmIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 1 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}