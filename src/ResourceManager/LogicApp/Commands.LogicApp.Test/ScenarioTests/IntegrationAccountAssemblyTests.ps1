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
	$localAssemblyFilePath = "$TestOutputRoot\Resources\SampleAssembly.dll"

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAssemblyName = "SampleAssembly"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$integrationAccountAssemblyName = "SampleAssembly2"
	$assemblyContent = [IO.File]::ReadAllBytes($localAssemblyFilePath)	

	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyDefinition $assemblyContent
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountAssembly command
#>
function Test-GetIntegrationAccountAssembly
{
	$localAssemblyFilePath = "$TestOutputRoot\Resources\SampleAssembly.dll"

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAssemblyName = "SampleAssembly"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$result = Get-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-AreEqual $integrationAccountAssemblyName $result.Name
	Assert-True { $result.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountAssembly command
#>
function Test-RemoveIntegrationAccountAssembly
{
	$localAssemblyFilePath = "$TestOutputRoot\Resources\SampleAssembly.dll"

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAssemblyName = "SampleAssembly"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	Remove-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountAssembly command
#>
function Test-UpdateIntegrationAccountAssembly
{
	$localAssemblyFilePath = "$TestOutputRoot\Resources\SampleAssembly.dll"

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAssemblyName = "SampleAssembly"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name

	$integrationAccountAssemblyUpdated =  Set-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath -Force
	Assert-AreEqual $integrationAccountAssemblyName $integrationAccountAssembly.Name
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountAssembly command : Paging test
#>
function Test-ListIntegrationAccountAssembly
{
	$localAssemblyFilePath = "$TestOutputRoot\Resources\SampleAssembly.dll"

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAssemblyName = "SampleAssembly"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$val=0
	while($val -ne 3)
	{
		$val++ ;
		$integrationAccountAssemblyName = "Assembly-$val-" + (getAssetname)
	$integrationAccountAssembly = New-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AssemblyName $integrationAccountAssemblyName -AssemblyFilePath $localAssemblyFilePath
	}

	$result =  Get-AzureRmIntegrationAccountAssembly -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 3 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}