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
Test New-AzureRmIntegrationAccountPartner command
#>
function Test-CreateIntegrationAccountPartner
{
	#Create App resource group

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName 

	$integrationAccountPartnerName = getAssetname	
	$integrationAccountPartnerName1 = getAssetname	

	$businessIdentities = @{"ZZ" = "AA"; "XX" = "GG" }
	$businessIdentities1 = @{"CC" = "FF"}

	$integrationAccountPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	$integrationAccountPartner1 =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName1 -BusinessIdentities $businessIdentities1
	Assert-AreEqual $integrationAccountPartnerName1 $integrationAccountPartner1.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountPartner command
#>
function Test-GetIntegrationAccountPartner
{
	#Create App resource group

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName 

	$integrationAccountPartnerName = getAssetname	
	$businessIdentities = @{"ZZ" = "AA"; "XX" = "GG" }

	$integrationAccountPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	$result =  Get-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName
	Assert-AreEqual $integrationAccountPartnerName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountPartner command
#>
function Test-RemoveIntegrationAccountPartner
{
	#Create App resource group

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountPartnerName = getAssetname	
	$businessIdentities = @{"ZZ" = "AA"; "XX" = "GG" }

	$integrationAccountPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName -PartnerType "B2B" -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	Remove-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountPartner command
#>
function Test-UpdateIntegrationAccountPartner
{
	#Create App resource group

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountPartnerName = getAssetname	
	$businessIdentities = @{"ZZ" = "AA"; "XX" = "GG" }
	$businessIdentities1 = @{"CC" = "VV"}

	$integrationAccountPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName -BusinessIdentities $businessIdentities
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartner.Name

	$integrationAccountPartnerUpdated = Set-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $integrationAccountPartnerName -BusinessIdentities $businessIdentities1	-Force
	Assert-AreEqual $integrationAccountPartnerName $integrationAccountPartnerUpdated.Name
	#Assert-AreEqual $businessIdentities1 $integrationAccountPartnerUpdated.businessIdentities
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}