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
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVm
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
		$x = New-AzureRmVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel

        Assert-AreEqual $vmname $x.Name;        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithAvailabilitySet
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$vmname = $rgname
		[string]$asname = $rgname
		[string]$domainNameLabel = "$vmname-$rgname".tolower();

        # Common
		$r = New-AzureRmResourceGroup -Name $rgname -Location "eastus"
		$a = New-AzureRmAvailabilitySet `
			-ResourceGroupName $rgname `
			-Name $asname `
			-Location "eastus" `
			-Sku "Aligned" `
			-PlatformUpdateDomainCount 2 `
			-PlatformFaultDomainCount 2

		$x = New-AzureRmVM `
			-ResourceGroupName $rgname `
			-Name $vmname `
			-Credential $cred `
			-DomainNameLabel $domainNameLabel `
			-AvailabilitySetName $asname

		Assert-AreEqual $vmname $x.Name;		
		Assert-AreEqual $a.Id $x.AvailabilitySetReference.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithDefaultDomainName
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string] $vmname = "ps9301"

        # Common
		$r = New-AzureRmResourceGroup -Name $rgname -Location "eastus"
		$x = New-AzureRmVM -ResourceGroupName $rgname -Name $vmname -Credential $cred

		Assert-AreEqual $vmname $x.Name
		$fqdn = $x.FullyQualifiedDomainName
		$split = $fqdn.Split(".")
		Assert-AreEqual "eastus" $split[1] 
		Assert-AreEqual "cloudapp" $split[2]
		Assert-AreEqual "azure" $split[3]
		Assert-AreEqual "com" $split[4]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithDefaultDomainName2
{
    # Setup
    $rgname = Get-ResourceName
	$rgname2 = Get-ResourceName

    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string] $vmname = "vm"

        # Common
		$x = New-AzureRmVM `
			-ResourceGroupName $rgname `
			-Name $vmname `
			-Credential $cred `
			-ImageName "ubuntults"

		# second VM
		$x2 = New-AzureRmVM `
			-ResourceGroupName $rgname2 `
			-Name $vmname `
			-Credential $cred `
			-ImageName "ubuntults"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
		Clean-ResourceGroup $rgname2
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithAvailabilitySet2
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$vmname = "myVM"
		[string]$asname = "myAvailabilitySet"

        # Common
		$r = New-AzureRmResourceGroup -Name $rgname -Location "eastus"
		$a = New-AzureRmAvailabilitySet `
			-ResourceGroupName $rgname `
			-Name $asname `
			-Location "eastus" `
			-Sku "Aligned" `
			-PlatformUpdateDomainCount 2 `
			-PlatformFaultDomainCount 2

		$x = New-AzureRmVM `
			-ResourceGroupName $rgname `
			-Name $vmname `
			-Credential $cred `
		    -VirtualNetworkName "myVnet" `
			-SubnetName "mySubnet" `
		    -OpenPorts 80,3389 `
			-PublicIpAddressName "myPublicIpAddress" `
			-SecurityGroupName "myNetworkSecurityGroup" `
			-AvailabilitySetName $asname `
			-DomainNameLabel "myvm-ad9300"

		Assert-AreEqual $vmname $x.Name;		
		Assert-AreEqual $a.Id $x.AvailabilitySetReference.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmImageName
{
    # Setup
    $rgname = Get-ResourceName
	[string]$vmname = "myvm"
    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "$vmname-$vmname".tolower()

        # Common
		$r = New-AzureRmResourceGroup -Name $rgname -Location "eastus"
		$x = New-AzureRmVM `
			-Name $vmname `
			-ResourceGroupName $rgname `
			-Credential $cred `
			-DomainNameLabel $domainNameLabel `
			-ImageName "MicrosoftWindowsServer:WindowsServer:2016-Datacenter:latest"

		Assert-AreEqual $vmname $x.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmImageNameMicrosoftSqlUbuntu
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "xsd3490285".tolower()

        # Common
		$x = New-AzureRmVM `
			-Name $vmname `
			-Credential $cred `
			-DomainNameLabel $domainNameLabel `
			-ImageName "MicrosoftSQLServer:SQL2017-Ubuntu1604:Enterprise:latest"

		Assert-AreEqual $vmname $x.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}