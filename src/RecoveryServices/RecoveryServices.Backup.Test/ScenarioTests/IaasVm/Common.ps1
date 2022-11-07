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

function Create-VM(
	[string] $resourceGroupName, 
	[string] $location, 
	[int] $nick = 0)
{
	$suffix = $(Get-RandomSuffix 5) + $nick
	$vmName = "PSTestVM" + $suffix

	$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName -ErrorAction Ignore

	if ($vm -eq $null)
	{
		$subnetConfigName = "PSTestSNC" + $suffix
		$subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $subnetConfigName -AddressPrefix 192.168.1.0/24

		$vnetName = "PSTestVNET" + $suffix
		$vnet = New-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Location $location `
			-Name $vnetName -AddressPrefix 192.168.0.0/16 -Subnet $subnetConfig -Force

		$pipName = "pstestpublicdns" + $suffix
		$pip = New-AzPublicIpAddress -ResourceGroupName $resourceGroupName -Location $location `
			-AllocationMethod Static -IdleTimeoutInMinutes 4 -Name $pipName -Force

		$nsgRuleRDPName = "PSTestNSGRuleRDP" + $suffix
		$nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name $nsgRuleRDPName  -Protocol Tcp `
			-Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
			-DestinationPortRange 3389 -Access Allow

		$nsgRuleWebName = "PSTestNSGRuleWeb" + $suffix
		$nsgRuleWeb = New-AzNetworkSecurityRuleConfig -Name $nsgRuleWebName  -Protocol Tcp `
			-Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
			-DestinationPortRange 80 -Access Allow

		$nsgName = "PSTestNSG" + $suffix
		$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $resourceGroupName -Location $location `
			-Name $nsgName -SecurityRules $nsgRuleRDP,$nsgRuleWeb -Force

		$nicName = "PSTestNIC" + $suffix
		$nic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $resourceGroupName -Location $location `
			-SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id -Force

		$UserName='demouser'
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString + "Aa." | ConvertTo-SecureString -Force -AsPlainText
		$Credential=New-Object PSCredential($UserName,$Password)

		$tags = @{"MabUsed"="Yes"}
		$tags += @{"Owner"="sarath"}
		$tags += @{"Purpose"="PSTest"}
		$tags += @{"AutoShutDown"="No"}
		$tags += @{"DeleteBy"="06-2022"}

		$vmConfig = New-AzVMConfig -VMName $vmName -VMSize Standard_D1_v2 | `
			Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $Credential | `
			Set-AzVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
			-Skus 2016-Datacenter -Version latest | Add-AzVMNetworkInterface -Id $nic.Id

		New-AzVM -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig -Tag $tags | Out-Null
		$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName
	}

	return $vm
}


function Create-UnmanagedVM(
	[string] $resourceGroupName,
	[string] $location,
	[string] $saname,
	[int] $nick = 0)
{
	$suffix = $(Get-RandomSuffix 5) + $nick
	$vmName = "PSTestVM" + $suffix

	$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName -ErrorAction Ignore

	if ($vm -eq $null)
	{
		$subnetConfigName = "PSTestSNC" + $suffix
		$subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $subnetConfigName -AddressPrefix 192.168.1.0/24


		$vnetName = "PSTestVNET" + $suffix
		$vnet = New-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Location $location `
			-Name $vnetName -AddressPrefix 192.168.0.0/16 -Subnet $subnetConfig -Force

		$pipName = "pstestpublicdns" + $suffix
		$pip = New-AzPublicIpAddress -ResourceGroupName $resourceGroupName -Location $location `
			-AllocationMethod Static -IdleTimeoutInMinutes 4 -Name $pipName -Force


		$nsgRuleRDPName = "PSTestNSGRuleRDP" + $suffix
		$nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name $nsgRuleRDPName  -Protocol Tcp `
			-Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
			-DestinationPortRange 3389 -Access Allow

		$nsgRuleWebName = "PSTestNSGRuleWeb" + $suffix
		$nsgRuleWeb = New-AzNetworkSecurityRuleConfig -Name $nsgRuleWebName  -Protocol Tcp `
			-Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
			-DestinationPortRange 80 -Access Allow

		$nsgName = "PSTestNSG" + $suffix
		$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $resourceGroupName -Location $location `
			-Name $nsgName -SecurityRules $nsgRuleRDP,$nsgRuleWeb -Force


		$nicName = "PSTestNIC" + $suffix
		$nic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $resourceGroupName -Location $location `
			-SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id -Force

		$UserName='demouser'
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString| ConvertTo-SecureString -Force -AsPlainText
		$Credential=New-Object PSCredential($UserName,$Password)


		$vmsize = "Standard_D1"
		$vm = New-AzVMConfig -VMName $vmName -VMSize $vmSize
		$pubName = "MicrosoftWindowsServer"
		$offerName = "WindowsServer"
		$skuName = "2016-Datacenter"
		$vm = Set-AzVMOperatingSystem -VM $vm -Windows -ComputerName $vmName -Credential $Credential
		$vm = Set-AzVMSourceImage -VM $vm -PublisherName $pubName -Offer $offerName -Skus $skuName -Version "latest" 
		$vm = Add-AzVMNetworkInterface -VM $vm -Id $NIC.Id 

		$tags = @{"MabUsed"="Yes"}
		$tags += @{"Owner"="sarath"}
		$tags += @{"Purpose"="PSTest"}
		$tags += @{"AutoShutDown"="No"}
		$tags += @{"DeleteBy"="06-2022"}

		$sa = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $saname
		$diskName = "mydisk"
		$OSDiskUri = $sa.PrimaryEndpoints.Blob.ToString() + "vhds/" + $diskName? + ".vhd"

		$vm = Set-AzVMOSDisk -VM $vm -Name $diskName -VhdUri $OSDiskUri -CreateOption fromImage

		New-AzVM -ResourceGroupName $resourceGroupName -Location $location -VM $vm -Tag $tags | Out-Null
	}

	return $vm
}

function Create-GalleryVM(
	[string] $resourceGroupName, 
	[string] $location, 
	[int] $nick = 0)
{
	$suffix = $(Get-RandomSuffix 5) + $nick
	$vmName = "PSTestGVM" + $suffix

	$vm = Get-AzVM -ResourceGroupName $resourceGroupName -Name $vmName -ErrorAction Ignore

	if ($vm -eq $null)
	{
		$subnetConfigName = "PSTestSNC" + $suffix
		$vnetName = "PSTestVNET" + $suffix
		$pipName = "pstestpublicdns" + $suffix
		$nsgName = "PSTestNSG" + $suffix
		$dnsLabel = "pstestdnslabel" + "-" + $suffix

		$UserName='demouser'
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString| ConvertTo-SecureString -Force -AsPlainText
		$Credential=New-Object PSCredential($UserName,$Password)

		$vm = New-AzVm `
			-ResourceGroupName $resourceGroupName `
			-Name $vmName `
			-Location $location `
			-SubnetName $subnetConfigName `
			-SecurityGroupName $nsgName `
			-PublicIpAddressName $pipName `
			-ImageName "MicrosoftWindowsServer:WindowsServer:2012-R2-Datacenter:latest" `
			-Credential $Credential `
			-DomainNameLabel $dnsLabel
	}

	return $vm
}

 function Cleanup-ResourceGroup(
	[string] $resourceGroupName)
{
	$resourceGroup = Get-AzResourceGroup -Name $resourceGroupName -ErrorAction Ignore
 	if ($resourceGroup -ne $null)
	{
		# Cleanup Vaults
		$vaults = Get-AzRecoveryServicesVault -ResourceGroupName $resourceGroupName
		foreach ($vault in $vaults)
		{
			Delete-Vault $vault
		}
	
		# Cleanup RG. This cleans up all VMs and Storage Accounts.
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}

function Delete-Vault($vault)
{
	$containers = Get-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureVM
	foreach ($container in $containers)
	{
		$items = Get-AzRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM
		foreach ($item in $items)
		{
			Disable-AzRecoveryServicesBackupProtection `
				-VaultId $vault.ID `
				-Item $item `
				-RemoveRecoveryPoints -Force
		}
	}

	Remove-AzRecoveryServicesVault -Vault $vault
}

function Delete-VM(
	[string] $rgName,
	[string] $vmName)
{
	Remove-AzVM -ResourceGroupName $rgName -Name $vmName -Force
}

function Enable-Protection(
	$vault, 
	$vm,
	[string] $resourceGroupName = "")
{
    # Sleep to give the service time to add the default policy to the vault
    Start-TestSleep -Seconds 5
	$container = Get-AzRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureVM `
		-FriendlyName $vm.Name;

	if($resourceGroupName -eq "")
	{
		$resourceGroupName = $vm.ResourceGroupName
	}

	if ($container -eq $null -or $container.Status -ne "Registered")
	{
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";
	
		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $resourceGroupName | Out-Null

		$container = Get-AzRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-FriendlyName $vm.Name;
	}
	
	$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureVM `
		-Name $vm.Name

	if ($item -eq $null)
	{
		$policy = Get-AzRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";

		Enable-AzRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $resourceGroupName | Out-Null

		$item = Get-AzRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureVM `
		-Name $vm.Name
	}

	return $item
}