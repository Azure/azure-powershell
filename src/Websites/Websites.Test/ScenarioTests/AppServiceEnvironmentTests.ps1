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
Tests Get App Service Environment
#>
function Test-GetAppServiceEnvironment
{
	# Setup
	$ResourceGroupName = Get-ResourceGroupName
	$WebName = Get-WebsiteName	
	$Location = Get-WebLocation
	$PlanName = Get-WebHostPlanName
	$AseName = "$ResourceGroupName-ase"
	$VNetName = "$ResourceGroupName-vnet"
	$SubnetName = "aseSubnet"
	$Tier = "I1"

	try
	{
		New-AzResourceGroup -Name $ResourceGroupName -Location $Location

		$aseSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix "10.0.0.0/24"
		$vNet = New-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName -Location $Location -AddressPrefix "10.0.0.0/16" -Subnet $aseSubnet
		Assert-AreEqual $VNetName $vNet.Name

		New-AzAppServiceEnvironment -ResourceGroupName $ResourceGroupName -Name $AseName -Location $Location -VirtualNetworkName $VNetName -SubnetName $SubnetName
		$actual = Get-AzAppServiceEnvironment -ResourceGroupName $ResourceGroupName -Name $AseName
		Assert-AreEqual $AseName $actual.Name
		Assert-AreEqual "ASEV2" $actual.Kind
		Assert-AreEqual "Ready" $actual.Status		
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $ResourceGroupName -Force
	}
}

<#
.SYNOPSIS
Tests Remove App Service Environment
#>
function Test-RemoveAppServiceEnvironment
{
	# Setup
	$ResourceGroupName = Get-ResourceGroupName
	$WebName = Get-WebsiteName	
	$Location = Get-WebLocation
	$PlanName = Get-WebHostPlanName
	$AseName = "$ResourceGroupName-ase"
	$VNetName = "$ResourceGroupName-vnet"
	$SubnetName = "aseSubnet"
	$Tier = "I1"

	try
	{
		New-AzResourceGroup -Name $ResourceGroupName -Location $Location

		$aseSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix "10.0.0.0/24"
		$vNet = New-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName -Location $Location -AddressPrefix "10.0.0.0/16" -Subnet $aseSubnet
		Assert-AreEqual $VNetName $vNet.Name

		New-AzAppServiceEnvironment -ResourceGroupName $ResourceGroupName -Name $AseName -Location $Location -VirtualNetworkName $VNetName -SubnetName $SubnetName
		Get-AzAppServiceEnvironment -ResourceGroupName $ResourceGroupName -Name $AseName | Remove-AzAppServiceEnvironment -Force
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $ResourceGroupName -Force
	}
}

<#
.SYNOPSIS
Tests E2E App Service Environment
#>
function Test-E2EAppServiceEnvironment
{
	# Setup
	$ResourceGroupName = Get-ResourceGroupName
	$WebName = Get-WebsiteName	
	$Location = Get-WebLocation
	$PlanName = Get-WebHostPlanName
	$AseName = "$ResourceGroupName-ase"
	$VNetName = "$ResourceGroupName-vnet"
	$SubnetName = "aseSubnet"
	$Tier = "I1"

	try
	{
		New-AzResourceGroup -Name $ResourceGroupName -Location $Location

		$aseSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix "10.0.0.0/24"
		$vNet = New-AzVirtualNetwork -Name $VNetName -ResourceGroupName $ResourceGroupName -Location $Location -AddressPrefix "10.0.0.0/16" -Subnet $aseSubnet
		Assert-AreEqual $VNetName $vNet.Name

		New-AzAppServiceEnvironment -ResourceGroupName $ResourceGroupName -Name $AseName -Location $Location -VirtualNetworkName $VNetName -SubnetName $SubnetName
		$actual = Get-AzAppServiceEnvironment -ResourceGroupName $ResourceGroupName -Name $AseName
		Assert-AreEqual $AseName $actual.Name
		Assert-AreEqual "ASEV2" $actual.Kind
		Assert-AreEqual "Ready" $actual.Status	
		
		$plan = New-AzAppServicePlan -ResourceGroupName $ResourceGroupName -Name $PlanName -AseName $AseName -Tier Isolated -Location $Location
		Assert-AreEqual "Isolated" $plan.Sku.Tier

		$webApp = New-AzWebApp -ResourceGroupName $ResourceGroupName -Name $WebName -AppServicePlan $PlanName

		Assert-AreEqual $WebName $webApp.Name
		Assert-AreEqual $plan.Id $webApp.ServerFarmId
	}
	finally
	{
		# Cleanup
		Remove-AzResourceGroup -Name $ResourceGroupName -Force
	}
}