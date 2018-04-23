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
function Test-SimpleNewVmss
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        $x = New-AzureRmVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
		Assert-Null $x.Identity  
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

function Test-SimpleNewVmssWithSystemAssignedIdentity
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        $x = New-AzureRmVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -SystemAssignedIdentity

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
		Assert-AreEqual "SystemAssigned" $x.Identity.Type     
		Assert-NotNull  $x.Identity.PrincipalId
		Assert-NotNull  $x.Identity.TenantId
		Assert-Null $x.Identity.IdentityIds  
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

function Test-SimpleNewVmssWithsystemAssignedUserAssignedIdentity
{
    # Setup
    $vmssname = "UAITG123456"

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "$vmssname$vmssname".tolower();

       # To record this test run these commands first :
       # New-AzureRmResourceGroup -Name UAITG123456 -Location 'Central US'
       # New-AzureRmUserAssignedIdentity -ResourceGroupName  UAITG123456 -Name UAITG123456Identity
       # 
       # Now get the identity :
       # 
       # Get-AzureRmUserAssignedIdentity -ResourceGroupName UAITG123456 -Name UAITG123456Identity
        #Nore down the Id and use it in the PS code
		#$identityName = $vmname + "Identity1"
		#$newUserIdentity =  New-AzureRmUserAssignedIdentity -ResourceGroupName $vmname -Name $identityName

		#$newUserId = $newUserIdentity.Id
		
		$newUserId = "/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourcegroups/UAITG123456/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UAITG123456Identity"

        # Common
        $x = New-AzureRmVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -UserAssignedIdentity $newUserId -SystemAssignedIdentity

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
		Assert-AreEqual "UserAssigned" $x.Identity.Type     
		Assert-NotNull  $x.Identity.PrincipalId
		Assert-NotNull  $x.Identity.TenantId
		Assert-NotNull $x.Identity.IdentityIds
		Assert-AreEqual 1 $x.Identity.IdentityIds.Count
		Assert-AreEqual $newUserId  $x.Identity.IdentityIds[0]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmssImageName
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
		[string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        $x = New-AzureRmVmss `
			-Name $vmssname `
			-Credential $cred `
			-DomainNameLabel $domainNameLabel `
			-ImageName "MicrosoftWindowsServer:WindowsServer:2016-Datacenter:latest"

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

function Test-SimpleNewVmssWithoutDomainName
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password

        # Common
        $x = New-AzureRmVmss -Name $vmssname -Credential $cred

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}
