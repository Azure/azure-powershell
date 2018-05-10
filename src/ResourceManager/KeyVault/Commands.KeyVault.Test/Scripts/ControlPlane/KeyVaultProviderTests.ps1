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
Tests cmdlets surrounding KeyVault provider cmdlets
#>

function Test-GetItem
{
	$resourceGroupName = getAssetName
	$vaultName = getAssetName
	$vaultName1 = getAssetName
	$resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroup" "westus"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "westus"
    $resourceGroup = New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation

	$vault = New-AzureRmKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName -Location $vaultLocation
	$vault = New-AzureRmKeyVault -ResourceGroupName $resourceGroupName -Name $vaultName1 -Location $vaultLocation
	New-PSDrive -Name "mykv" -PSProvider "KeyVault" -Root "C:"

	$outputDrive = Get-Item -Path mykv:
	Assert-AreEqual $outputDrive.Provider.Name "KeyVault"
	Assert-AreEqual $outputDrive.Root "C:"
	Assert-AreEqual $outputDrive.Name "mykv"
	$outputDrive = Get-Item -Path mykv:/
	Assert-AreEqual $outputDrive.Provider.Name "KeyVault"
	Assert-AreEqual $outputDrive.Root "C:"
	Assert-AreEqual $outputDrive.Name "mykv"
	Assert-True $outputDrive.PSIsContainer

	$outputVault = Get-Item -Path mykv:/$vaultName
	Assert-AreEqual $outputVault.VaultName $vaultName
	Assert-AreEqual $outputVault.Location $vaultLocation
	Assert-True $outputVault.PSIsContainer
	$outputVault = Get-Item -Path mykv:/$vaultName/
	Assert-AreEqual $outputVault.VaultName $vaultName
	Assert-AreEqual $outputVault.Location $vaultLocation
	Assert-True $outputVault.PSIsContainer

	$outputFolder = Get-Item -Path mykv:/$vaultName/Secrets
	Assert-AreEqual $outputFolder.Parent.Name $vaultName
	Assert-AreEqual $outputFolder.Name "Secrets"
	Assert-True $outputVault.PSIsContainer
	$outputFolder = Get-Item -Path mykv:/$vaultName/Secrets/
	Assert-AreEqual $outputFolder.Parent.Name $vaultName
	Assert-AreEqual $outputFolder.Name "Secrets"
	Assert-True $outputVault.PSIsContainer
	$outputFolder = Get-Item -Path mykv:/$vaultName/Certificates
	Assert-AreEqual $outputFolder.Parent.Name $vaultName
	Assert-AreEqual $outputFolder.Name "Certificates"
	Assert-True $outputVault.PSIsContainer
	$outputFolder = Get-Item -Path mykv:/$vaultName/Certificates/
	Assert-AreEqual $outputFolder.Parent.Name $vaultName
	Assert-AreEqual $outputFolder.Name "Certificates"
	Assert-True $outputVault.PSIsContainer
	$outputFolder = Get-Item -Path mykv:/$vaultName/Keys
	Assert-AreEqual $outputFolder.Parent.Name $vaultName
	Assert-AreEqual $outputFolder.Name "Keys"
	Assert-True $outputVault.PSIsContainer
	$outputFolder = Get-Item -Path mykv:/$vaultName/Keys/
	Assert-AreEqual $outputFolder.Parent.Name $vaultName
	Assert-AreEqual $outputFolder.Name "Keys"
	Assert-True $outputVault.PSIsContainer

	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}