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
Test Import-AzContainerRegistryImage.
#>
function Test-ImportImage
{
	# Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $RegistryName = Get-RandomRegistryName
    $location = Get-ProviderLocation "Microsoft.ContainerRegistry/registries"

	try
	{
		New-AzResourceGroup -Name $resourceGroupName -Location $location

		$registry = New-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $RegistryName -Sku "Basic" -Location $location

		$import = Import-AzContainerRegistryImage -SourceImage library/busybox:latest -ResourceGroupName $resourceGroupName -RegistryName $RegistryName -SourceRegistryUri docker.io -TargetTag busybox:latest

		Assert-AreEqual $true $import

		Remove-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $RegistryName
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}