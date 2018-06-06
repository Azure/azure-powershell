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

function Get-ResourceGroupLocation
{
    $namespace = "Microsoft.RecoveryServices"
    $type = "vaults"
    $resourceProvider = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}
  
    if ($resourceProvider -eq $null)
    {
        return "westus";
    }
	else
    {
		return $resourceProvider.Locations[0]
    }
}

function Get-RandomSuffix(
	[int] $size = 8)
{
	$variableName = "NamingSuffix"
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName))
		{
			$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
		}
		else
		{
			$suffix = @((New-Guid).Guid)

			[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $suffix
		}
	}
	else
	{
		$suffix = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
	}

	return $suffix.Substring(0, $size)
}

function Create-ResourceGroup(
	[string] $location)
{
	$name = "PSTestRG" + @(Get-RandomSuffix)

	$resourceGroup = Get-AzureRmResourceGroup -Name $name -ErrorAction Ignore
	
	if ($resourceGroup -eq $null)
	{
		New-AzureRmResourceGroup -Name $name -Location $location | Out-Null
	}

	return $name
}

function Create-RecoveryServicesVault(
	[string] $resourceGroupName, 
	[string] $location)
{
	$name = "PSTestRSV" + @(Get-RandomSuffix)

	$vault = Get-AzureRmRecoveryServicesVault `
		-ResourceGroupName $resourceGroupName `
		-Name $name -ErrorAction Ignore

	if ($vault -eq $null)
	{
		$vault = New-AzureRmRecoveryServicesVault `
			-Name $name `
			-ResourceGroupName $resourceGroupName `
			-Location $location;
	}

	return $vault
}

function Cleanup-ResourceGroup(
	[string] $resourceGroupName)
{
	$resourceGroup = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction Ignore

	if ($resourceGroup -ne $null)
	{
		# Cleanup Vaults
		$vaults = Get-AzureRmRecoveryServicesVault -ResourceGroupName $resourceGroupName
		foreach ($vault in $vaults)
		{
			Set-AzureRmRecoveryServicesVaultContext -Vault $vault
			$containers = Get-AzureRmRecoveryServicesBackupContainer -ContainerType AzureVM
			foreach ($container in $containers)
			{
				$items = Get-AzureRmRecoveryServicesBackupItem -Container $container -WorkloadType AzureVM
				foreach ($item in $items)
				{
					Disable-AzureRmRecoveryServicesBackupProtection -Item $item -RemoveRecoveryPoints -Force
				}
			}

			Remove-AzureRmRecoveryServicesVault -Vault $vault
		}
	
		# Cleanup RG. This cleans up all VMs and Storage Accounts.
		Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
	}
}

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

function Create-SA(
	[string] $resourceGroupName, 
	[string] $location)
{
	$name = "PSTestSA" + @(Get-RandomSuffix)
	$name = $name.ToLower()

	$sa = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $name -ErrorAction Ignore

	if ($sa -eq $null)
	{
		$sa = New-AzureRmStorageAccount `
			-ResourceGroupName $resourceGroupName `
			-Name $name `
			-Location $location `
			-Type "Standard_LRS"
	}

	return $name
}

function Enable-Protection(
	$vault, 
	$vm)
{
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault | Out-Null

	$container = Get-AzureRmRecoveryServicesBackupContainer `
		-ContainerType AzureVM `
		-Name $vm.Name;

	if ($container -eq $null)
	{
		$policy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "DefaultPolicy";
	
		Enable-AzureRmRecoveryServicesBackupProtection `
			-Policy $policy -Name $vm.Name -ResourceGroupName $vm.ResourceGroupName | Out-Null

		$container = Get-AzureRmRecoveryServicesBackupContainer `
			-ContainerType AzureVM `
			-Name $vm.Name;
	}
	
	$item = Get-AzureRmRecoveryServicesBackupItem `
		-Container $container `
		-WorkloadType AzureVM `
		-Name $vm.Name

	return $item
}

function Backup-Item(
	$vault,
	$item)
{
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault | Out-Null

	return Backup-AzureRmRecoveryServicesBackupItem -Item $item | Wait-AzureRmRecoveryServicesBackupJob
}

function Get-RecoveryPoint(
	$vault,
	$item,
	$backupJob)
{
	Set-AzureRmRecoveryServicesVaultContext -Vault $vault | Out-Null

	$backupStartTime = $backupJob.StartTime.AddMinutes(-1);
	$backupEndTime = $backupJob.EndTime.AddMinutes(1);

	$rps = Get-AzureRmRecoveryServicesBackupRecoveryPoint -Item $item -StartDate $backupStartTime -EndDate $backupEndTime
	
	return $rps[0]
}

function Get-QueryDateInUtc(
	$date, 
	[string] $variableName)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		$queryDate = $date.ToUniversalTime()
		$queryDateString = $queryDate.ToString("u")
		
		[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $queryDateString
	}
	else
	{
		$queryDateString = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]

		$queryDate = (Get-Date $queryDateString).ToUniversalTime()
	}

	return $queryDate
}

function Get-QueryDateLocal(
	$date, 
	[string] $variableName)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Record)
	{
		$queryDate = $date
		
		[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName] = $date
	}
	else
	{
		$queryDateString = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]

		$queryDate = Get-Date $queryDateString
	}

	return $queryDate
}