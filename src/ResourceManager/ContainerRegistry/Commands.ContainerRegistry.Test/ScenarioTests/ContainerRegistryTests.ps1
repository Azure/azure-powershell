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
Test New-AzureRmContainerRegistry, Get-AzureRmContainerRegistry, Update-AzureRmContainerRegistry, and Remove-AzureRmContainerRegistry.
#>
function Test-AzureContainerRegistry
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $registryName = Get-RandomRegistryName
    $location = Get-ProviderLocation "Microsoft.ContainerRegistry/registries"
    $sku = "Basic"

    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating a container registry with a default new storage account
    $registry = New-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName -Sku $sku
    Assert-AreEqual $registry.ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry.Name $registryName
    Assert-AreEqual $registry.Type "Microsoft.ContainerRegistry/registries"
    Assert-AreEqual $registry.SkuName $sku
    Assert-AreEqual $registry.SkuTier $sku
    Assert-AreEqual $registry.LoginServer "$($registryName.ToLower()).azurecr.io"
    Assert-AreEqual $registry.ProvisioningState "Succeeded"
    Assert-AreEqual $registry.AdminUserEnabled $false
    Assert-NotNull $registry.StorageAccountName

    # Check if the registry name already exists
    $nameStatus = Test-AzureRmContainerRegistryNameAvailability -Name $registryName
    Assert-AreEqual $nameStatus.nameAvailable $false
    Assert-AreEqual $nameStatus.Reason "AlreadyExists"
    Assert-AreEqual $nameStatus.Message "The registry $($registryName) is already in use."

    $storageAccountName = $registry.StorageAccountName

    $registry = Get-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName
    Assert-AreEqual $registry.ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry.Name $registryName
    Assert-AreEqual $registry.Type "Microsoft.ContainerRegistry/registries"
    Assert-AreEqual $registry.SkuName $sku
    Assert-AreEqual $registry.SkuTier $sku
    Assert-AreEqual $registry.LoginServer "$($registryName.ToLower()).azurecr.io"
    Assert-AreEqual $registry.ProvisioningState "Succeeded"
    Assert-AreEqual $registry.AdminUserEnabled $false
    Assert-AreEqual $registry.StorageAccountName $storageAccountName

    $registry = Get-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry[0].ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry[0].Name $registryName
    Assert-AreEqual $registry[0].Type "Microsoft.ContainerRegistry/registries"
    Assert-AreEqual $registry[0].SkuName $sku
    Assert-AreEqual $registry[0].SkuTier $sku
    Assert-AreEqual $registry[0].LoginServer "$($registryName.ToLower()).azurecr.io"
    Assert-AreEqual $registry[0].ProvisioningState "Succeeded"
    Assert-AreEqual $registry[0].AdminUserEnabled $false
    Assert-AreEqual $registry[0].StorageAccountName $storageAccountName

    Remove-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName
    $registryName = Get-RandomRegistryName

    # Creating a container registry with an existing storage account
    $registry = New-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName -Sku $sku -StorageAccountName $storageAccountName
    Assert-AreEqual $registry.ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry.Name $registryName
    Assert-AreEqual $registry.Type "Microsoft.ContainerRegistry/registries"
    Assert-AreEqual $registry.SkuName $sku
    Assert-AreEqual $registry.SkuTier $sku
    Assert-AreEqual $registry.LoginServer "$($registryName.ToLower()).azurecr.io"
    Assert-AreEqual $registry.ProvisioningState "Succeeded"
    Assert-AreEqual $registry.AdminUserEnabled $false
    Assert-AreEqual $registry.StorageAccountName $storageAccountName

    $registry = Update-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName -EnableAdminUser -StorageAccountName $registry.StorageAccountName
    Assert-AreEqual $registry.ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry.Name $registryName
    Assert-AreEqual $registry.Type "Microsoft.ContainerRegistry/registries"
    Assert-AreEqual $registry.SkuName $sku
    Assert-AreEqual $registry.SkuTier $sku
    Assert-AreEqual $registry.LoginServer "$($registryName.ToLower()).azurecr.io"
    Assert-AreEqual $registry.ProvisioningState "Succeeded"
    Assert-AreEqual $registry.AdminUserEnabled $true
    Assert-AreEqual $registry.StorageAccountName $storageAccountName

    Remove-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmContainerRegistryCredential and Update-AzureRmContainerRegistryCredential.
#>
function Test-AzureContainerRegistryCredential
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $registryName = Get-RandomRegistryName
    $location = Get-ProviderLocation "Microsoft.ContainerRegistry/registries"
    $sku = "Basic"

    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

    # Creating a container registry with a default new storage account
    $registry = New-AzureRmContainerRegistry -ResourceGroupName $resourceGroupName -Name $registryName -Sku $sku -EnableAdminUser
    Assert-AreEqual $registry.ResourceGroupName $resourceGroupName
    Assert-AreEqual $registry.Name $registryName
    Assert-AreEqual $registry.Type "Microsoft.ContainerRegistry/registries"
    Assert-AreEqual $registry.SkuName $sku
    Assert-AreEqual $registry.SkuTier $sku
    Assert-AreEqual $registry.LoginServer "$($registryName.ToLower()).azurecr.io"
    Assert-AreEqual $registry.ProvisioningState "Succeeded"
    Assert-AreEqual $registry.AdminUserEnabled $true
    Assert-NotNull $registry.StorageAccountName

    $credential = Get-AzureRmContainerRegistryCredential -ResourceGroupName $resourceGroupName -Name $registryName
    Assert-AreEqual $credential.Username $registryName
    Assert-NotNull $credential.Password
    Assert-NotNull $credential.Password2

    $newCredential1 = Update-AzureRmContainerRegistryCredential -ResourceGroupName $resourceGroupName -Name $registryName -PasswordName Password
    Assert-AreEqual $newCredential1.Username $registryName
    Assert-AreNotEqual $newCredential1.Password $credential.Password
    Assert-AreEqual $newCredential1.Password2 $credential.Password2

    $newCredential2 = Update-AzureRmContainerRegistryCredential -ResourceGroupName $resourceGroupName -Name $registryName -PasswordName Password2
    Assert-AreEqual $newCredential2.Username $registryName
    Assert-AreEqual $newCredential2.Password $newCredential1.Password
    Assert-NotNull $newCredential2.Password2 $newCredential1.Password2

    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Test Test-AzureRmContainerRegistryNameAvailability
#>
function Test-AzureContainerRegistryNameAvailability
{
    # The chance of this randomly generated name has a duplication is rare
    $nameStatus = Test-AzureRmContainerRegistryNameAvailability -Name $(Get-RandomRegistryName)
    Assert-AreEqual $nameStatus.nameAvailable $true
    Assert-Null $nameStatus.Reason
    Assert-Null $nameStatus.Message

    $nameStatus = Test-AzureRmContainerRegistryNameAvailability -Name "Microsoft"
    Assert-AreEqual $nameStatus.nameAvailable $false
    Assert-AreEqual $nameStatus.Reason "Invalid"
    Assert-AreEqual $nameStatus.Message "The specified registry name is disallowed"
}
