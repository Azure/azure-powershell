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
Test New-AzIntegrationAccount command
#>
function Test-CreateIntegrationAccount
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$location = Get-Location "Microsoft.Logic" "integrationAccounts"

	$integrationAccountNameBasic = "IA-Basic-" + (getAssetname)
	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountNameBasic -Location $location -Sku "Basic"
	Assert-AreEqual $integrationAccountNameBasic $integrationAccount.Name 
 
	$integrationAccountNameStandard = "IA-Standard-" + (getAssetname)
	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountNameStandard -Location $location -Sku "Standard"
	Assert-AreEqual $integrationAccountNameStandard $integrationAccount.Name 

	$integrationAccountNameStandard2 = "IA-Standard2-" + (getAssetname)
	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountNameStandard2 -Location $location -Sku "standard"
	Assert-AreEqual $integrationAccountNameStandard2 $integrationAccount.Name 
 
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountNameBasic -Force
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountNameStandard -Force
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountNameStandard2 -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccount command
#>
function Test-GetIntegrationAccount
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$location = Get-Location "Microsoft.Logic" "integrationAccounts"

	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 
	
	$integrationAccount = Get-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 

	$integrationAccounts = Get-AzIntegrationAccount
	Assert-True { $integrationAccounts.Count -gt 0 }

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzIntegrationAccount command
#>
function Test-RemoveIntegrationAccount
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$location = Get-Location "Microsoft.Logic" "integrationAccounts"

	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}


<#
.SYNOPSIS
Test Update-AzIntegrationAccount command
#>
function Test-UpdateIntegrationAccount
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$location = Get-Location "Microsoft.Logic" "integrationAccounts"

	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"  -Force
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Sku "Standard" -Force
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Force
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountCallbackUrl command
#>
function Test-GetIntegrationAccountCallbackUrl
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	$location = Get-Location "Microsoft.Logic" "integrationAccounts"

	$integrationAccount = New-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"
	Assert-AreEqual $integrationAccountName $integrationAccount.Name

	[datetime]$date = Get-Date
	$date.AddDays(100)

	$callbackUrl = Get-AzIntegrationAccountCallbackUrl -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Notafter $date
	Assert-NotNull $callbackUrl 

	$callbackUrl1 = Get-AzIntegrationAccountCallbackUrl -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-NotNull $callbackUrl1 

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}