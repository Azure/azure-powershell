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
Test New-AzIntegrationAccountMap command
#>
function Test-CreateIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName1 = getAssetname
	$integrationAccountMapName2 = getAssetname
	$integrationAccountMapName3 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountMap1 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName1 -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName1 $integrationAccountMap1.Name

	$integrationAccountMap2 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName2 -MapFilePath $mapFilePath
	Assert-AreEqual $integrationAccountMapName2 $integrationAccountMap2.Name

	$integrationAccountMap3 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName3 -MapFilePath $mapFilePath -MapType "Xslt" -ContentType "application/xml"
	Assert-AreEqual $integrationAccountMapName3 $integrationAccountMap3.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountMap command
#>
function Test-GetIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountMap =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	$result =  Get-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName
	Assert-AreEqual $integrationAccountMapName $result.Name

	$result1 =  Get-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-AreEqual $integrationAccountMapName $result1.Name
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzIntegrationAccountMap command
#>
function Test-RemoveIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountMap =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	Remove-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -Force	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzIntegrationAccountMap command
#>
function Test-UpdateIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname
	
	$integrationAccountMapName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountMap =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	$integrationAccountMapUpdated =  Set-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent -Force
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name

	$integrationAccountMapUpdated =  Set-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent -Force
	Assert-AreEqual $integrationAccountMapName $integrationAccountMap.Name
	
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountMap command : Paging test
#>
function Test-ListIntegrationAccountMap
{
	$mapFilePath = Join-Path $TestOutputRoot "\Resources\SampleXsltMap.xsl"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)

	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$val=0
	while($val -ne 1)
	{
		$val++ ;
		$integrationAccountMapName = getAssetname
		New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	}

	$result =  Get-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 1 }

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}