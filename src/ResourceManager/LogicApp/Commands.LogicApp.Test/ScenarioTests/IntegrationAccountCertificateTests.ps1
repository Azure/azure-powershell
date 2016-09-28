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
Test New-AzureRmIntegrationAccountCertificate command
#>
function Test-CreateIntegrationAccountCertificate
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname		
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = "$TestOutputRoot\Resources\IntegrationAccountCertificate.cer"

	$integrationAccountCertificate =  New-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "faaa9c58967640c5af20fad4d273906e" -KeyVaultId "/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountPsCmdletTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault1" -PublicCertificateFilePath $certFilePath
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificate.Name

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountCertificate command
#>
function Test-UpdateIntegrationAccountCertificate
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = "$TestOutputRoot\Resources\IntegrationAccountCertificate.cer"

	$integrationAccountCertificate =  New-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "faaa9c58967640c5af20fad4d273906e" -KeyVaultId "/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountPsCmdletTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault1" -PublicCertificateFilePath $certFilePath
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificate.Name

	$integrationAccountCertificateUpdated = Set-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -Force
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificateUpdated.Name
	Assert-AreEqual "PRIVATEKEY" $integrationAccountCertificateUpdated.Key.KeyName

	$integrationAccountCertificateUpdated = Set-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyVersion "faaa9c58967640c5af20fad4d273906e" -Force
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificateUpdated.Name
	Assert-AreEqual "faaa9c58967640c5af20fad4d273906e" $integrationAccountCertificateUpdated.Key.KeyVersion

	$integrationAccountCertificateUpdated = Set-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyVaultId "/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountPsCmdletTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault1" -Force
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificateUpdated.Name
	Assert-AreEqual "/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountPsCmdletTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault1" $integrationAccountCertificateUpdated.Key.KeyVault.Id
	
	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountCertificate command
#>
function Test-GetIntegrationAccountCertificate
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = "$TestOutputRoot\Resources\IntegrationAccountCertificate.cer"

	New-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "faaa9c58967640c5af20fad4d273906e" -KeyVaultId "/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountPsCmdletTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault1" -PublicCertificateFilePath $certFilePath

	$result =  Get-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName
	Assert-AreEqual $integrationAccountCertificateName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName	
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountCertificate command
#>
function Test-RemoveIntegrationAccountCertificate
{
	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname	
	
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = "$TestOutputRoot\Resources\IntegrationAccountCertificate.cer"

	New-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "faaa9c58967640c5af20fad4d273906e" -KeyVaultId "/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourcegroups/IntegrationAccountPsCmdletTest/providers/microsoft.keyvault/vaults/IntegrationAccountVault1" -PublicCertificateFilePath $certFilePath

	Remove-AzureRmIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -CertificateName $integrationAccountCertificateName -Force	

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

