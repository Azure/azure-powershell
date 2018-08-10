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

	$vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName -Name $vmName -ErrorAction Ignore

	if ($vm -eq $null)
	{
		$subnetConfigName = "PSTestSNC" + $suffix
		$subnetConfig = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetConfigName -AddressPrefix 192.168.1.0/24

		$vnetName = "PSTestVNET" + $suffix
		$vnet = New-AzureRmVirtualNetwork -ResourceGroupName $resourceGroupName -Location $location `
			-Name $vnetName -AddressPrefix 192.168.0.0/16 -Subnet $subnetConfig -Force

		$pipName = "pstestpublicdns" + $suffix
		$pip = New-AzureRmPublicIpAddress -ResourceGroupName $resourceGroupName -Location $location `
			-AllocationMethod Static -IdleTimeoutInMinutes 4 -Name $pipName -Force

		$nsgRuleRDPName = "PSTestNSGRuleRDP" + $suffix
		$nsgRuleRDP = New-AzureRmNetworkSecurityRuleConfig -Name $nsgRuleRDPName  -Protocol Tcp `
			-Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
			-DestinationPortRange 3389 -Access Allow

		$nsgRuleWebName = "PSTestNSGRuleWeb" + $suffix
		$nsgRuleWeb = New-AzureRmNetworkSecurityRuleConfig -Name $nsgRuleWebName  -Protocol Tcp `
			-Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
			-DestinationPortRange 80 -Access Allow

		$nsgName = "PSTestNSG" + $suffix
		$nsg = New-AzureRmNetworkSecurityGroup -ResourceGroupName $resourceGroupName -Location $location `
			-Name $nsgName -SecurityRules $nsgRuleRDP,$nsgRuleWeb -Force

		$nicName = "PSTestNIC" + $suffix
		$nic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $resourceGroupName -Location $location `
			-SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id -NetworkSecurityGroupId $nsg.Id -Force

		$UserName='demouser'
		$PasswordString = $(Get-RandomSuffix 12)
		$Password=$PasswordString| ConvertTo-SecureString -Force -AsPlainText
		$Credential=New-Object PSCredential($UserName,$Password)

		$vmConfig = New-AzureRmVMConfig -VMName $vmName -VMSize Standard_D1 | `
			Set-AzureRmVMOperatingSystem -Windows -ComputerName $vmName -Credential $Credential | `
			Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
			-Skus 2016-Datacenter -Version latest | Add-AzureRmVMNetworkInterface -Id $nic.Id

		New-AzureRmVM -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig | Out-Null
		$vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName -Name $vmName
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

	$vm = Get-AzureRmVM -ResourceGroupName $resourceGroupName -Name $vmName -ErrorAction Ignore

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

		$vm = New-AzureRmVm `
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

function Delete-Vault($vault)
{
	$containers = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureVM
	foreach ($container in $containers)
	{
		$items = Get-AzureRmRecoveryServicesBackupItem `
			-VaultId $vault.ID `
			-Container $container `
			-WorkloadType AzureVM
		foreach ($item in $items)
		{
			Disable-AzureRmRecoveryServicesBackupProtection `
				-VaultId $vault.ID `
				-Item $item `
				-RemoveRecoveryPoints -Force
		}
	}

	Remove-AzureRmRecoveryServicesVault -Vault $vault
}

<# 
.SYNOPSIS
Sleeps but only during recording.
#>
 
function Start-TestSleep($milliseconds)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        Start-Sleep -Milliseconds $milliseconds
    }
}

function Enable-Protection(
	$vault, 
	$vm)
{
    # Sleep to give the service time to add the default policy to the vault
    Start-TestSleep 5000
	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-VaultId $vault.ID `
		-ContainerType AzureVM `
		-Name $vm.Name;

	if ($container -eq $null)
	{
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy `
			-VaultId $vault.ID `
			-Name "DefaultPolicy";
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-VaultId $vault.ID `
			-Policy $policy `
			-Name $vm.Name `
			-ResourceGroupName $vm.ResourceGroupName | Out-Null

		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-VaultId $vault.ID `
			-ContainerType AzureVM `
			-Name $vm.Name;
	}
	
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-VaultId $vault.ID `
		-Container $container `
		-WorkloadType AzureVM `
		-Name $vm.Name

	return $item
}