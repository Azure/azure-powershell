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
Precondition: The given VMSS has been created, but not set 
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
Precondition: The given VMSS already exists 
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
