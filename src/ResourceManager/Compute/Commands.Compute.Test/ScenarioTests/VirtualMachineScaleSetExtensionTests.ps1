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
Test Virtual Machine Scale Set Disk Encryption Extension
Precondition: The given VMSS has been created, but not set. 

The following is a description of the steps required to create a proper test environment.
These steps are being provided here in advance of being fully automated.  

[SETUP]
From the list of regions available in your subscription, select a region and pin it for 
use in the following operations. 

In chosen region, create key vault prerequisites from an account with the proper permissions 
https://github.com/Azure/azure-powershell/blob/master/src/ResourceManager/Compute/Commands.Compute/Extension/AzureDiskEncryption/Scripts/AzureDiskEncryptionPreRequisiteSetup.ps1

Note, the above steps will not work by default for service principal accounts.  
For an example of steps required for service principals, refer to the "Assigning Permissions" 
section of the following article: 
https://dscottraynsford.wordpress.com/2017/04/17/using-azure-key-vault-with-powershell-part-1/

In the chosen region, create a VMSS scale selecting a sepcific image type (Windows or Linux), eg:
    Canonical:UbuntuServer:16.04-DAILY-LTS:latest
    MicrosoftWindowsServer:WindowsServer:2016-Datacenter:latest

Add a data disk to the virtual machine scale set 
Update the virtual machine scale set to include the data disk 
Enumerate virtual machine scale set instances and retrieve id of a valid instance
The instance ID number varies each time a new scale set is created, and as some 
tests accept the instance ID as a parameter this instance ID must be known in advance. 

Mount the attached data disk to the virtual machine in each instance using the following manual steps:
	retrieve the connection info for vm scale set instances (the IP address and port # for SSH or RDP) 
	Windows Manual Steps
		- open a remote desktop connection to the instance  (mstsc.exe [ip]:[port])
		- run diskmgmt.msc within the VM and select the attached data disk 
		- format the disk and make sure it is assigned a new drive letter
		- logout
	Linux Manual Steps
		- open an ssh connection into the Linux VM (ssh username@[ip] -p [port])
		- sudo to format the drive, add it to /etc/fstab using a persistent device name
        (see https://docs.microsoft.com/en-us/azure/virtual-machines/linux/troubleshoot-device-names-problems)
		- run 'mount -a' and then test with lsblk to ensure it is mounted
		- logout
These steps can be automated as follows:
	Create a custom script to do the above steps and apply to all instances using Custom Script Extension
	Update the VMSS scale set
	Confirm that the update was successful. 

[TEST EXECUTION]
Enable encryption - use a vmss scale set that did not yet have encryption on it. 
Disable encryption - use a vmss scale set that had successfully had encryption enabled on it.  
Get status - use a vmss scale set that had successfully had encryption enabled on it. 

[TEARDOWN]
Delete the resource group and all of its contents (including key vault resources and virtual machine scale set) 

#>
function Test-VirtualMachineScaleSetDiskEncryptionExtension
{
	# Common
	$loc = 'eastus2euap';
	$rgname = 'adetstrg';
	$vmssName = 'vmssadetst';
	$keyVaultResourceId = '/subscriptions/5393f919-a68a-43d0-9063-4b2bda6bffdf/resourceGroups/suredd-rg/providers/Microsoft.KeyVault/vaults/sureddeuvault';
	$diskEncryptionKeyVaultUrl = 'https://sureddeuvault.vault.azure.net';

	$vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

	# Get Instance View
	$vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;

	# Enable
	Set-AzureRmVmssDiskEncryptionExtension -ResourceGroupName $rgname -VMScaleSetName $vmssName `
		-DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -Force

	# Check Vmss
	$result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
	$result_string = $result | Out-String;
		 
	# Check VmssVm
	$result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
	$result_string = $result | Out-String;
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Disk Encryption Extension
Precondition: The given VMSS has an encrypted data disk.
For notes on test environment setup, please refer to the 
Test-VirtualMachineScaleSetDiskEncryptionExtension synopsis.
#>
function Test-DisableVirtualMachineScaleSetDiskEncryption
{
 	# Common
	$loc = 'eastus2euap';
	$rgname = 'adetstrg';
	$vmssName = 'vmssadetst';

    $result = Get-AzureRmVmssDiskEncryption;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 4;
    $result_string = $result | Out-String;

    $result = Disable-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 4;
    $result_string = $result | Out-String;
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Disk Encryption Extension
Precondition: The given VMSS has an encrypted data disk.
For notes on test environment setup, please refer to the 
Test-VirtualMachineScaleSetDiskEncryptionExtension synopsis.
#>
function Test-DisableVirtualMachineScaleSetDiskEncryption2
{
    # Common
    $loc = 'eastus2euap';
    $rgname = 'adetst2rg';
    $vmssName = 'vmssadetst2';

    $result = Disable-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
    $result_string = $result | Out-String;
}

<#
.SYNOPSIS
Test Get Virtual Machine Scale Set Disk Encryption Status for VMSS without encryption
Precondition: The given VMSS already exists but has not been encrypted.
For notes on test environment setup, please refer to the 
Test-VirtualMachineScaleSetDiskEncryptionExtension synopsis.
#>
function Test-GetVirtualMachineScaleSetDiskEncryptionStatus
{
	# Common
	$loc = 'eastus2euap';
	$rgname = 'adetst3rg';
	$vmssName = 'vmssadetst3';

    $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

    $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
    $output = $vmssInstanceViewResult | Out-String;

    $result = Get-AzureRmVmssDiskEncryptionStatus -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "7";
    $output = $result | Out-String;
}

<#
.SYNOPSIS
Test Get Virtual Machine Scale Set Disk Encryption for VMSS with a data disk.
Precondition: The given VMSS has an encrypted data disk to disable
For creation steps, refer to notes in Test-VirtualMachineScaleSetDiskEncryptionExtension.  
#>
function Test-GetVirtualMachineScaleSetDiskEncryptionDataDisk
{
	$rgname = 'adetst4rg';
	$vmssName = 'vmssadetst4';

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $job = Disable-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force -AsJob;
    $result = $job | Wait-Job;
    Assert-AreEqual "Completed" $result.State;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    Assert-AreEqual "NotEncrypted" $result[0].DataVolumesEncrypted;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "4";
    Assert-AreEqual "NotEncrypted" $result.DataVolumesEncrypted;
    $output = $result | Out-String;
}
