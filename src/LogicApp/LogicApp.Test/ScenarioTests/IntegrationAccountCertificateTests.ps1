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
Test New-AzIntegrationAccountCertificate command
#>
function Test-CreateIntegrationAccountCertificate
{
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname		
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountCertificate.cer"

	$integrationAccountCertificate =  New-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "b8f8974776c7430b9f9f33ddc031b7e4" -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4" -PublicCertificateFilePath $certFilePath
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificate.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test New-AzIntegrationAccountCertificate command
#>
function Test-CreateIntegrationAccountCertificatePrivateKey
{
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname
	$integrationAccountCertificateName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$integrationAccountCertificate =  New-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "b8f8974776c7430b9f9f33ddc031b7e4" -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4"
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificate.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test New-AzIntegrationAccountCertificate command
#>
function Test-CreateIntegrationAccountCertificatePublicKey
{
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname
	$integrationAccountCertificateName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountCertificate.cer"

	$integrationAccountCertificate =  New-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -PublicCertificateFilePath $certFilePath
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificate.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzIntegrationAccountCertificate command
#>
function Test-UpdateIntegrationAccountCertificate
{
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname	
	
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountCertificate.cer"

	$integrationAccountCertificate =  New-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "b8f8974776c7430b9f9f33ddc031b7e4" -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4" -PublicCertificateFilePath $certFilePath
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificate.Name

	$integrationAccountCertificateUpdated = Set-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -Force
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificateUpdated.Name
	Assert-AreEqual "PRIVATEKEY" $integrationAccountCertificateUpdated.Key.KeyName

	$integrationAccountCertificateUpdated = Set-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyVersion "b8f8974776c7430b9f9f33ddc031b7e4" -Force
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificateUpdated.Name
	Assert-AreEqual "b8f8974776c7430b9f9f33ddc031b7e4" $integrationAccountCertificateUpdated.Key.KeyVersion

	$integrationAccountCertificateUpdated = Set-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4" -Force
	Assert-AreEqual $integrationAccountCertificateName $integrationAccountCertificateUpdated.Name
	Assert-AreEqual "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4" $integrationAccountCertificateUpdated.Key.KeyVault.Id
	
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountCertificate command
#>
function Test-GetIntegrationAccountCertificate
{
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname	
	
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountCertificate.cer"

	New-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "b8f8974776c7430b9f9f33ddc031b7e4" -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4" -PublicCertificateFilePath $certFilePath

	$result =  Get-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName
	Assert-AreEqual $integrationAccountCertificateName $result.Name

	$result1 =  Get-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName	
	Assert-True { $result1.Count -gt 0 }	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzIntegrationAccountCertificate command
#>
function Test-RemoveIntegrationAccountCertificate
{
	$resourceGroupName = getAssetname
	$resourceGroup = TestSetup-CreateNamedResourceGroup $resourceGroupName
	$integrationAccountName = getAssetname	
	
	$integrationAccountCertificateName = getAssetname	

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$certFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountCertificate.cer"

	New-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -KeyName "PRIVATEKEY" -KeyVersion "b8f8974776c7430b9f9f33ddc031b7e4" -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/maddie1/providers/Microsoft.KeyVault/vaults/mvault4" -PublicCertificateFilePath $certFilePath

	Remove-AzIntegrationAccountCertificate -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -CertificateName $integrationAccountCertificateName -Force	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

