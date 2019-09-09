# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the 'License');
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an 'AS IS' BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
	.SYNOPSIS
	Creates a resource group for tests
#>
function Create-ResourceGroupForTest ($location = 'westus')
{
	$rgName = Get-ResourceGroupNameForTest
	$rg = New-AzResourceGroup -Name $rgName -Location $location -Force
	return $rg
}

<#
	.SYNOPSIS
	Removes the resource group that was used for testing
#>
function Remove-ResourceGroupForTest ($rg)
{
	Remove-AzResourceGroup -Name $rg.ResourceGroupName -Force
}

<#
	.SYNOPSIS
	Creates a virtual machine
#>
function Create-VM(
	[string] $resourceGroupName, 
	[string] $vmName,
	[string] $location)
{
	$subnetName = $vmName + "subnet"
	$vnetName= $vmName + "vnet"
	$pipName = $vmName + "pip"
	# Create a subnet configuration
	$subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 192.168.1.0/24

	# Create a virtual network
	$vnet = New-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Location $location `
	   -Name $vnetName -AddressPrefix 192.168.0.0/16 -Subnet $subnetConfig

	# Create a public IP address and specify a DNS name
	$pip = New-AzPublicIpAddress -ResourceGroupName $resourceGroupName -Location $location `
	   -AllocationMethod Static -IdleTimeoutInMinutes 4 -Name $pipName

	# Rule to allow remote desktop (RDP)
	$nsgRuleRDP = New-AzNetworkSecurityRuleConfig -Name 'RDPRule' -Protocol Tcp `
	   -Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * `
	   -DestinationAddressPrefix * -DestinationPortRange 3389 -Access Allow

	# Rule to allow SQL Server connections on port 1433
	$nsgRuleSQL = New-AzNetworkSecurityRuleConfig -Name 'MSSQLRule'  -Protocol Tcp `
	   -Direction Inbound -Priority 1001 -SourceAddressPrefix * -SourcePortRange * `
	   -DestinationAddressPrefix * -DestinationPortRange 1433 -Access Allow

	# Create the network security group
	$nsgName = $vmName + 'nsg'
	$nsg = New-AzNetworkSecurityGroup -ResourceGroupName $resourceGroupName `
	   -Location $location -Name $nsgName `
	   -SecurityRules $nsgRuleRDP,$nsgRuleSQL

	$interfaceName = $vmName + 'int'
	$interface = New-AzNetworkInterface -Name $interfaceName `
	   -ResourceGroupName $resourceGroupName -Location $location `
	   -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $pip.Id `
	   -NetworkSecurityGroupId $nsg.Id
	
	$cred = Get-DefaultCredentialForTest
	
	# Create a virtual machine configuration
	$vmConfig = New-AzVMConfig -VMName $vmName -VMSize Standard_DS13_V2 |
	   Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $cred -ProvisionVMAgent -EnableAutoUpdate |
	   Set-AzVMSourceImage -PublisherName 'MicrosoftSQLServer' -Offer 'SQL2017-WS2016' -Skus 'SQLDEV' -Version 'latest' |
	   Add-AzVMNetworkInterface -Id $interface.Id
	
	return New-AzVM -ResourceGroupName $resourceGroupName -Location $location -VM $vmConfig
}

<#
	.SYNOPSIS
	Creates default credentials for testing
#>
function Get-DefaultCredentialForTest()
{
	$user = Get-DefaultUser
	$pswd = Get-DefaultPassword
	$securePswd = ConvertTo-SecureString -String $pswd -AsPlainText -Force
	return New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $securePswd
}

function Get-LocationForTest()
{
	return 'eastus'
}

function Get-ResourceGroupNameForTest()
{
	$nr = Get-Random -Minimum 1000 -Maximum 5000
	return "sqlvmcrudtest-" + $nr
}

function Get-SqlVirtualMachineGroupName()
{
	return "test-group"
}

function Get-DefaultUser()
{
	return 'myvmadmin'
}

function Get-DefaultSqlService()
{
	return 'sqlservice'
}

function Get-DefaultPassword()
{
	return 'Sql@zure123!'
}

function Get-DomainForTest()
{
	return 'Domain'
}

function Get-StorageaccountNameForTest()
{
	return 'sqlvmpowershelltest'
}

<#
	.SYNOPSIS
	Checks that the sql virtual machines provided are equal
#>
function Validate-SqlVirtualMachine($sqlvm1, $sqlvm2)
{
	Assert-NotNull $sqlvm1
	Assert-NotNull $sqlvm2

	Assert-AreEqual $sqlvm1.ResourceId $sqlvm2.ResourceId
	Assert-AreEqual $sqlvm1.Name $sqlvm2.Name
	Assert-AreEqual $sqlvm1.ResourceGroupName $sqlvm2.ResourceGroupName
	Assert-AreEqual $sqlvm1.SqlManagementType $sqlvm2.SqlManagementType
	Assert-AreEqual $sqlvm1.LicenseType $sqlvm2.LicenseType	
	Assert-AreEqual $sqlvm1.Offer $sqlvm2.Offer	
	Assert-AreEqual $sqlvm1.Sku $sqlvm2.Sku	
}

<#
	.SYNOPSIS
	Checks that the sql virtual machine groups provided are equal
#>
function Validate-SqlVirtualMachineGroup($group1, $group2)
{
	Assert-NotNull $group1
	Assert-NotNull $group2

	Assert-AreEqual $group1.ResourceId $group2.ResourceId
	Assert-AreEqual $group1.Name $group2.Name
	Assert-AreEqual $group1.ResourceGroupName $group2.ResourceGroupName
	Assert-AreEqual $group1.Offer $group2.Offer	
	Assert-AreEqual $group1.Sku $group2.Sku	
}

<#
	.SYNOPSIS
	Gets a default WsfcDomainProfile for testing
#>
function Get-WsfcDomainProfileForTest(
	[string] $resourceGroupName, 
	[string] $location,
	[string] $user,
	[string] $sqllogin,
	[string] $domainName,
	[string] $blobAccount,
	[string] $storageAccountKey
)
{
	$props = @{
		DomainFqdn = $domainName + '.com'
		ClusterOperatorAccount = $user + '@' + $domainName + '.com'
		ClusterBootstrapAccount = $user + '@' + $domainName + '.com'
		
		SqlServiceAccount = $sqllogin + '@' + $domainName + '.com'
		StorageAccountUrl = $blobAccount
		StorageAccountPrimaryKey = $storageAccountKey
	}
	return new-object Microsoft.Azure.Management.SqlVirtualMachine.Models.WsfcDomainProfile -Property $props
}

<#
	.SYNOPSIS
	Creates a sql virtual machine
#>
function Create-SqlVM (
	[string] $resourceGroupName, 
	[string] $vmName,
	[string] $location
)
{
	Create-VM $resourceGroupName $vmName $location	
	$sqlvm = New-AzSqlVM -ResourceGroupName $resourceGroupName -Name $vmName -LicenseType 'PAYG' -Sku Enterprise
	return $sqlvm
}

<#
	.SYNOPSIS
	Creates a sql virtual machine group
#>
function Create-SqlVMGroup(
	[string] $resourceGroupName, 
	[string] $groupName,
	[string] $location
)
{
	$storageAccountName = Get-StorageaccountNameForTest
	$storageAccount = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -Location $location -Type Standard_LRS -Kind StorageV2
	
	$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName).Value[0]
	$blobAccount = $storageAccount.PrimaryEndpoints.Blob
	
	$user = Get-DefaultUser
	$domain = Get-DomainForTest
	$sqllogin = Get-DefaultSqlService
	$profile = Get-WsfcDomainProfileForTest $resourceGroupName $location $user $sqllogin $domain $blobAccount $storageAccountKey
	
	$secureKey = ConvertTo-SecureString $profile.StorageAccountPrimaryKey -AsPlainText -Force
	
	$group = New-AzSqlVMGroup $resourceGroupName $groupName $location -ClusterOperatorAccount $profile.ClusterOperatorAccount `
		-ClusterBootstrapAccount $profile.ClusterBootstrapAccount `
		-SqlServiceAccount $profile.SqlServiceAccount -StorageAccountUrl $profile.StorageAccountUrl `
		-StorageAccountPrimaryKey $secureKey -DomainFqdn $profile.DomainFqdn `
		-Offer 'SQL2017-WS2016' -Sku 'Enterprise'
	return $group
}
