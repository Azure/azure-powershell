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
Test New-AzureRmIntegrationAccount command
#>
function Test-CreateIntegrationAccount
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	

	$location = Get-LocationName
	$integrationAccount = New-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard" 	
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccount command
#>
function Test-CreateAndGetIntegrationAccount
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$location = Get-LocationName

	$integrationAccount = New-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard" 	
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 
	
	$integrationAccount = Get-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 

	$integrationAccounts = Get-AzureRmIntegrationAccount
	Assert-True { $integrationAccounts.Count -gt 0 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force 	
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccount command
#>
function Test-RemoveIntegrationAccount
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$location = Get-LocationName

	$integrationAccount = New-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard" 	
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}


<#
.SYNOPSIS
Test Update-AzureRmIntegrationAccount command
#>
function Test-UpdateIntegrationAccount
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$location = Get-LocationName

	$integrationAccount = New-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard"  -Force	
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Sku "Standard" -Force	
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 

	$updatedIntegrationAccount = Set-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Force
	Assert-AreEqual $updatedIntegrationAccount.Name $integrationAccount.Name 
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountCallbackUrl command
#>
function Test-GetIntegrationAccountCallbackUrl
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$location = Get-LocationName

	$integrationAccount = New-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Location $location -Sku "Standard" 	
	Assert-AreEqual $integrationAccountName $integrationAccount.Name 

	[datetime]$date = Get-Date
	$date.AddDays(100)	

	$callbackUrl = Get-AzureRmIntegrationAccountCallbackUrl -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Notafter $date
	Assert-NotNull $callbackUrl 

	$callbackUrl1 = Get-AzureRmIntegrationAccountCallbackUrl -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-NotNull $callbackUrl1 
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force 	
}