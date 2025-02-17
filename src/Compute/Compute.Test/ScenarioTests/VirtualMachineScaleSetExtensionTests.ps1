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
https://github.com/Azure/azure-powershell/blob/master/src/Compute/Compute/Extension/AzureDiskEncryption/Scripts/AzureDiskEncryptionPreRequisiteSetup.ps1

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
        (see https://learn.microsoft.com/en-us/azure/virtual-machines/linux/troubleshoot-device-names-problems)
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
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');
    $rgname = 'adetstrg';
    $vmssName = 'vmssadetst';
    $keyVaultResourceId = '/subscriptions/5393f919-a68a-43d0-9063-4b2bda6bffdf/resourceGroups/suredd-rg/providers/Microsoft.KeyVault/vaults/sureddeuvault';
    $diskEncryptionKeyVaultUrl = 'https://sureddeuvault.vault.azure.net';

    $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

    # Get Instance View
    $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;

    # Enable
    Set-AzVmssDiskEncryptionExtension -ResourceGroupName $rgname -VMScaleSetName $vmssName `
        -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -Force

    # Check Vmss
    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;
         
    # Check VmssVm
    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
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
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');
    $rgname = 'adetstrg';
    $vmssName = 'vmssadetst';

    $result = Get-AzVmssDiskEncryption;
    $result_string = $result | Out-String;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname;
    $result_string = $result | Out-String;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 4;
    $result_string = $result | Out-String;

    $result = Disable-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
    $result_string = $result | Out-String;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname;
    $result_string = $result | Out-String;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $result_string = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 4;
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
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');
    $rgname = 'adetst2rg';
    $vmssName = 'vmssadetst2';

    $result = Disable-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
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
    [string]$loc = Get-ComputeVMLocation;
    $loc = $loc.Replace(' ', '');
    $rgname = 'adetst3rg';
    $vmssName = 'vmssadetst3';

    $vmssResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

    $vmssInstanceViewResult = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
    $output = $vmssInstanceViewResult | Out-String;

    $result = Get-AzVmssDiskEncryptionStatus -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzVmssDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "7";
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

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $job = Disable-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force -AsJob;
    $result = $job | Wait-Job;
    Assert-AreEqual "Completed" $result.State;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    Assert-AreEqual "NotEncrypted" (($result[0].DataVolumesEncryptionStatus | ConvertFrom-Json -AsHashtable).Values[0] | Out-String ).Trim();
    $output = $result | Out-String;

    $result = Get-AzVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "4";
    Assert-AreEqual "NotEncrypted" (($result.DataVolumesEncryptionStatus | ConvertFrom-Json -AsHashtable).Values[0] | Out-String ).Trim();
    $output = $result | Out-String;
}

<#
.SYNOPSIS
Test the Set-AzVMDiskEncryptionExtension with EncryptionIdentity Added in vmss security profile
#>
function Test-AzureDiskEncryptionWithEncryptionIdentityAddedInAzVmssConfig{
    $rgName = Get-ComputeTestResourceName;
    try {
        # create virtual machine Scale Set
        $loc = "centraluseuap";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # VM Profile & Hardware
        $vmssName = "vmss" + $rgname;
        $imagePublisher = "RedHat";
        $imageOffer = "RHEL";
        $imageSku = "92-gen2";         
        $osVersion = "latest"
        $vmssSize = 'Standard_D4s_v3'; 
        $encIdentity = "/subscriptions/759532d8-9991-4d04-878f-49f0f4804906/resourceGroups/anshademsitest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/anshjainmsitestuserassignedmanagedidentity"
        $instances = 2
        $vmssConfig = New-AzVmssConfig -Location $loc -SkuCapacity $instances -SkuName $vmssSize -UpgradePolicyMode Automatic -IdentityType UserAssigned -IdentityId $encIdentity -EncryptionIdentity $encIdentity -OrchestrationMode Uniform

        Set-AzVmssStorageProfile $vmssConfig -ImageReferencePublisher $imagePublisher -ImageReferenceOffer $imageOffer -ImageReferenceSku $imageSku -ImageReferenceVersion $osVersion -OsDiskCreateOption "FromImage" -OsDiskCaching ReadWrite
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        Set-AzVmssOsProfile $vmssConfig -ComputerNamePrefix "adetest" -AdminUsername $adminUserName -AdminPassword $adminPassword

        $subnetName = 'default'
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnetName = ('{0}-vnet' -f $vmSSName)
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $loc -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        $subnetId = $vnet.Subnets[0].Id
        $vmssConfigPublicIpName = ('{0}ip' -f $vmSSName)

        $IPCfg = New-AzVmssIPConfig -Name $vmssConfigPublicIpName -SubnetId $subnetId
        $vmssNetworkConfigName = ('{0}netconfig' -f $vmSSName)

        Add-AzVmssNetworkInterfaceConfiguration -VirtualMachineScaleSet $vmssConfig -Name $vmssNetworkConfigName -Primary $True -IPConfiguration $IPCfg

        New-AzVmss -ResourceGroupName $rgName -Name $vmssName -VirtualMachineScaleSet $vmssConfig

        $vmssStatus = Get-AzVmss -VMScaleSetName $vmSSName -ResourceGroupName $rgName
        
        $vaultName = $rgname + '-kv';
        $principalId = "7089a49e-00be-4313-b644-46a6294d0a91";
        
        $keyVault = create-KeyVaultWithAclEncryptionIdentity $rgName $loc $vaultName $principalId;

        Set-AzVmssDiskEncryptionExtension `
            -ResourceGroupName $rgName `
            -VMScaleSetName $vmssName `
            -DiskEncryptionKeyVaultUrl $keyVault.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $keyVault.DiskEncryptionKeyVaultId `
            -VolumeType "All" `
            -Force;

        $status = Get-AzVmssDiskEncryptionStatus -ResourceGroupName $rgName -VMScaleSetName $vmssName;
        Assert-NotNull $status;
        Assert-NotNull $status.EncryptionSummary
        Assert-NotNull $status.EncryptionSummary[0]
        Assert-AreEqual "ProvisioningState/succeeded" $status.EncryptionSummary[0].Code
        Assert-AreEqual $True $status.EncryptionEnabled
    }
    finally {
        clean-ResourceGroup $rgName;
    }
}

<#
.SYNOPSIS
Test the Set-AzVMssDiskEncryptionExtension with EncryptionIdentity Added in vm security profile during Set ADE Cmdlet
#>
function Test-AzureDiskEncryptionWithEncryptionIdentityAddedInSetADEVMssCmdlet{
    $rgName = Get-ComputeTestResourceName;
    try {
        # create virtual machine Scale Set
        $loc = "centraluseuap";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # VM Profile & Hardware
        $vmssName = "vmss" + $rgname;
        $imagePublisher = "RedHat";
        $imageOffer = "RHEL";
        $imageSku = "92-gen2";         
        $osVersion = "latest"
        $vmssSize = 'Standard_D4s_v3'; 
        $encIdentity = "/subscriptions/759532d8-9991-4d04-878f-49f0f4804906/resourceGroups/anshademsitest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/anshjainmsitestuserassignedmanagedidentity"
        $instances = 2
        $vmssConfig = New-AzVmssConfig -Location $loc -SkuCapacity $instances -SkuName $vmssSize -UpgradePolicyMode Automatic -IdentityType UserAssigned -IdentityId $encIdentity -OrchestrationMode Uniform

        Set-AzVmssStorageProfile $vmssConfig -ImageReferencePublisher $imagePublisher -ImageReferenceOffer $imageOffer -ImageReferenceSku $imageSku -ImageReferenceVersion $osVersion -OsDiskCreateOption "FromImage" -OsDiskCaching ReadWrite
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        Set-AzVmssOsProfile $vmssConfig -ComputerNamePrefix "adetest" -AdminUsername $adminUserName -AdminPassword $adminPassword

        $subnetName = 'default'
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnetName = ('{0}-vnet' -f $vmSSName)
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $loc -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        $subnetId = $vnet.Subnets[0].Id
        $vmssConfigPublicIpName = ('{0}ip' -f $vmSSName)

        $IPCfg = New-AzVmssIPConfig -Name $vmssConfigPublicIpName -SubnetId $subnetId
        $vmssNetworkConfigName = ('{0}netconfig' -f $vmSSName)

        Add-AzVmssNetworkInterfaceConfiguration -VirtualMachineScaleSet $vmssConfig -Name $vmssNetworkConfigName -Primary $True -IPConfiguration $IPCfg

        New-AzVmss -ResourceGroupName $rgName -Name $vmssName -VirtualMachineScaleSet $vmssConfig

        $vmssStatus = Get-AzVmss -VMScaleSetName $vmSSName -ResourceGroupName $rgName
        
        $vaultName = $rgname + '-kv';
        $principalId = "7089a49e-00be-4313-b644-46a6294d0a91";
        
        $keyVault = create-KeyVaultWithAclEncryptionIdentity $rgName $loc $vaultName $principalId;

        Set-AzVmssDiskEncryptionExtension `
            -ResourceGroupName $rgName `
            -VMScaleSetName $vmssName `
            -DiskEncryptionKeyVaultUrl $keyVault.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $keyVault.DiskEncryptionKeyVaultId `
            -EncryptionId $encIdentity -VolumeType "All" `
            -Force;

        $status = Get-AzVmssDiskEncryptionStatus -ResourceGroupName $rgName -VMScaleSetName $vmssName;
        Assert-NotNull $status;
        Assert-NotNull $status.EncryptionSummary
        Assert-NotNull $status.EncryptionSummary[0]
        Assert-AreEqual "ProvisioningState/succeeded" $status.EncryptionSummary[0].Code
        Assert-AreEqual $True $status.EncryptionEnabled

    }
    finally {
      clean-ResourceGroup $rgName;
    }
}

<#
.SYNOPSIS
Test the Set-AzVMssDiskEncryptionExtension with EncryptionIdentity not added in vm security profile
Throw Exception with message:Encryption Identity should be an ARM Resource ID of one of the 
user assigned identities associated to the resource
#>
function Test-AzureDiskEncryptionWithIdentityNotSetInVirtualMachineScaleSet {
    
    # Setup
    $rgname = Get-ComputeTestResourceName
    try
    {
        # create virtual machine Scale Set
        $loc = "centraluseuap";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # VM Profile & Hardware
        $vmssName = "vmss" + $rgname;
        $imagePublisher = "RedHat";
        $imageOffer = "RHEL";
        $imageSku = "92-gen2";         
        $osVersion = "latest"
        $vmssSize = 'Standard_D4s_v3'; 
        $encIdentity = "/subscriptions/759532d8-9991-4d04-878f-49f0f4804906/resourceGroups/anshademsitest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/anshjainmsitestuserassignedmanagedidentity"
        $instances = 2
        $vmssConfig = New-AzVmssConfig -Location $loc -SkuCapacity $instances -SkuName $vmssSize -UpgradePolicyMode Automatic -IdentityType SystemAssigned -OrchestrationMode Uniform

        Set-AzVmssStorageProfile $vmssConfig -ImageReferencePublisher $imagePublisher -ImageReferenceOffer $imageOffer -ImageReferenceSku $imageSku -ImageReferenceVersion $osVersion -OsDiskCreateOption "FromImage" -OsDiskCaching ReadWrite
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        Set-AzVmssOsProfile $vmssConfig -ComputerNamePrefix "adetest" -AdminUsername $adminUserName -AdminPassword $adminPassword

        $subnetName = 'default'
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnetName = ('{0}-vnet' -f $vmSSName)
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $loc -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        $subnetId = $vnet.Subnets[0].Id
        $vmssConfigPublicIpName = ('{0}ip' -f $vmSSName)

        $IPCfg = New-AzVmssIPConfig -Name $vmssConfigPublicIpName -SubnetId $subnetId
        $vmssNetworkConfigName = ('{0}netconfig' -f $vmSSName)

        Add-AzVmssNetworkInterfaceConfiguration -VirtualMachineScaleSet $vmssConfig -Name $vmssNetworkConfigName -Primary $True -IPConfiguration $IPCfg

        New-AzVmss -ResourceGroupName $rgName -Name $vmssName -VirtualMachineScaleSet $vmssConfig

        $vmssStatus = Get-AzVmss -VMScaleSetName $vmSSName -ResourceGroupName $rgName
        
        $vaultName = $rgname + '-kv';
        $principalId = "7089a49e-00be-4313-b644-46a6294d0a91";
        
        $keyVault = create-KeyVaultWithAclEncryptionIdentity $rgName $loc $vaultName $principalId;

        Assert-ThrowsContains {Set-AzVmssDiskEncryptionExtension `
            -ResourceGroupName $rgName `
            -VMScaleSetName $vmssName `
            -DiskEncryptionKeyVaultUrl $keyVault.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $keyVault.DiskEncryptionKeyVaultId `
            -EncryptionId $encIdentity -VolumeType "All" `
            -Force;} `
        "Encryption Identity should be an ARM Resource ID of one of the user assigned identities associated to the resource";

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test the Set-AzVMssDiskEncryptionExtension with EncryptionIdentity added in vm security profile
Encryption Identity not acled in the KeyVault
Throw Exception with message:RUNTIME_E_KEYVAULT_SET_SECRET_FAILED  Failed to set secret to KeyVault
#>
function Test-AzureVmssDiskEncryptionWithIdentityNotAckledInKeyVault {
    
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # create virtual machine Scale Set
        $loc = "centraluseuap";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;
        # VM Profile & Hardware
        $vmssName = "vmss" + $rgname;
        $imagePublisher = "RedHat";
        $imageOffer = "RHEL";
        $imageSku = "92-gen2";         
        $osVersion = "latest"
        $vmssSize = 'Standard_D4s_v3'; 
        $encIdentity = "/subscriptions/759532d8-9991-4d04-878f-49f0f4804906/resourceGroups/anshademsitest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/anshjainmsitestuserassignedmanagedidentity"
        $instances = 2
        $vmssConfig = New-AzVmssConfig -Location $loc -SkuCapacity $instances -SkuName $vmssSize -UpgradePolicyMode Automatic -IdentityType UserAssigned -IdentityId $encIdentity -OrchestrationMode Uniform

        Set-AzVmssStorageProfile $vmssConfig -ImageReferencePublisher $imagePublisher -ImageReferenceOffer $imageOffer -ImageReferenceSku $imageSku -ImageReferenceVersion $osVersion -OsDiskCreateOption "FromImage" -OsDiskCaching ReadWrite
        $adminUsername = Get-ComputeTestResourceName;
        $password = Get-PasswordForVM;
        $adminPassword = $password | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($adminUsername, $adminPassword);

        Set-AzVmssOsProfile $vmssConfig -ComputerNamePrefix "adetest" -AdminUsername $adminUserName -AdminPassword $adminPassword

        $subnetName = 'default'
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnetName = ('{0}-vnet' -f $vmSSName)
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgName -Location $loc -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        $subnetId = $vnet.Subnets[0].Id
        $vmssConfigPublicIpName = ('{0}ip' -f $vmSSName)

        $IPCfg = New-AzVmssIPConfig -Name $vmssConfigPublicIpName -SubnetId $subnetId
        $vmssNetworkConfigName = ('{0}netconfig' -f $vmSSName)

        Add-AzVmssNetworkInterfaceConfiguration -VirtualMachineScaleSet $vmssConfig -Name $vmssNetworkConfigName -Primary $True -IPConfiguration $IPCfg

        New-AzVmss -ResourceGroupName $rgName -Name $vmssName -VirtualMachineScaleSet $vmssConfig

        $vmssStatus = Get-AzVmss -VMScaleSetName $vmSSName -ResourceGroupName $rgName

        $vaultName = $rgname + '-kv';
        
        $keyVault = create-KeyVaultWithAclEncryptionIdentity $rgName $loc $vaultName

        Assert-ThrowsContains {Set-AzVMssDiskEncryptionExtension `
            -ResourceGroupName $rgName `
            -VMScaleSetName $vmssName `
            -DiskEncryptionKeyVaultUrl $keyVault.DiskEncryptionKeyVaultUrl `
            -DiskEncryptionKeyVaultId $keyVault.DiskEncryptionKeyVaultId `
            -EncryptionId $encIdentity -VolumeType "All" `
            -Force; } `
            "RUNTIME_E_KEYVAULT_SET_SECRET_FAILED  Failed to set secret to KeyVault"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}