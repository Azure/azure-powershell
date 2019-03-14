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
	$xslt1FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt1Map.xslt"
	$xslt2FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt2Map.xslt"
	$xslt3FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt3Map.xslt"
	$liquidFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleLiquidMap.liquid"
	$xslt1MapContent = [IO.File]::ReadAllText($xslt1FilePath)
	$xslt2MapContent = [IO.File]::ReadAllText($xslt2FilePath)
	$xslt3MapContent = [IO.File]::ReadAllText($xslt3FilePath)
	$liquidMapContent = [IO.File]::ReadAllText($liquidFilePath)
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountMapName1 = "XSLT-" + (getAssetname)
	$integrationAccountMapName2 = "XSLT-" + (getAssetname)
	$integrationAccountMapName3 = "XSLT-" + (getAssetname)
	$integrationAccountXslt2MapName = "XSLT2-" + (getAssetname)
	$integrationAccountXslt3MapName = "XSLT3-" + (getAssetname)
	$integrationAccountLiquidMapName = "Liquid-" + (getAssetname)
	$integrationAccountLiquidMapName2 = "Liquid2-" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountMap1 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName1 -MapDefinition $xslt1MapContent
	Assert-AreEqual $integrationAccountMapName1 $integrationAccountMap1.Name

	$integrationAccountMap2 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName2 -MapFilePath $xslt1FilePath
	Assert-AreEqual $integrationAccountMapName2 $integrationAccountMap2.Name

	$integrationAccountMap3 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName3 -MapFilePath $xslt1FilePath -MapType "Xslt" -ContentType "application/xml"
	Assert-AreEqual $integrationAccountMapName3 $integrationAccountMap3.Name
	
	$integrationAccountXslt2Map =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountXslt2MapName -MapDefinition $xslt2MapContent -MapType "Xslt20"
	Assert-AreEqual $integrationAccountXslt2MapName $integrationAccountXslt2Map.Name
 	$integrationAccountXslt3Map =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountXslt3MapName -MapDefinition $xslt3MapContent -MapType "Xslt30"
	Assert-AreEqual $integrationAccountXslt3MapName $integrationAccountXslt3Map.Name
 	$integrationAccountLiquidMap =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountLiquidMapName -MapDefinition $liquidMapContent -MapType "Liquid"
	Assert-AreEqual $integrationAccountLiquidMapName $integrationAccountLiquidMap.Name
 	$integrationAccountLiquidMap2 =  New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountLiquidMapName2 -MapDefinition $liquidMapContent -MapType "liquid"
	Assert-AreEqual $integrationAccountLiquidMapName2 $integrationAccountLiquidMap2.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountMap command
#>
function Test-GetIntegrationAccountMap
{
	$mapFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt1Map.xslt"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
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
	$mapFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt1Map.xslt"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
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
	$mapFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt1Map.xslt"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
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
	$mapFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "SampleXslt1Map.xslt"
	$mapContent = [IO.File]::ReadAllText($mapFilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$val=0
	while($val -ne 1)
	{
		$val++ ;
		$integrationAccountMapName = "XSLT-$val-" + (getAssetname)
		New-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -MapName $integrationAccountMapName -MapDefinition $mapContent
	}

	$result =  Get-AzIntegrationAccountMap -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 1 }

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}