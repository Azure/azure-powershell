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
#>
function Test-VirtualMachineScaleSetDiskEncryptionExtension
{
    try
    {
        # Common
        $loc = 'westcentralus';
        $rgname = "hyleevmssdetest2";
        $vmssName = 'vmss' + $rgname;
        $aadClientSecret = $PLACEHOLDER
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        $aadAppName = "detestaadapp";

        # KeyVault config variables
        $vaultName = "detestvault";
        $kekName = "dstestkek";

        # Check if AAD app was already created
        $SvcPrincipals = (Get-AzureRmADServicePrincipal -SearchString $aadAppName);
        if(-not $SvcPrincipals)
        {
             # Create a new AD application if not created before
             $identifierUri = [string]::Format("http://localhost:8080/{0}", $rgname);
             $defaultHomePage = 'http://contoso.com';
             $now = [System.DateTime]::Now;
             $oneYearFromNow = $now.AddYears(1);
             $ADApp = New-AzureRmADApplication -DisplayName $aadAppName -HomePage $defaultHomePage -IdentifierUris $identifierUri  -StartDate $now -EndDate $oneYearFromNow -Password $aadClientSecret;
             Assert-NotNull $ADApp;
             $servicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $ADApp.ApplicationId;
             $SvcPrincipals = (Get-AzureRmADServicePrincipal -SearchString $aadAppName);
             # Was AAD app created?
             Assert-NotNull $SvcPrincipals;
             $aadClientID = $servicePrincipal.ApplicationId;
        }
        else
        {
            # Was AAD app already created?
            Assert-NotNull $aadClientSecret;
            $aadClientID = $SvcPrincipals[0].ApplicationId;
        }

        # Create new KeyVault
        $keyVault = New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $loc -Sku standard;
        $keyVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $rgname

        # Set enabledForDiskEncryption
        Set-AzureRmKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $rgname -EnabledForDiskEncryption;
        # Set permissions to AAD app to write secrets and keys
        Set-AzureRmKeyVaultAccessPolicy -VaultName $vaultName -ServicePrincipalName $aadClientID -PermissionsToKeys all -PermissionsToSecrets all 
        # Create a key in KeyVault to use as Kek
        $kek = Add-AzureKeyVaultKey -VaultName $vaultName -Name $kekName -Destination "Software"

        $diskEncryptionKeyVaultUrl = $keyVault.VaultUri;
        $keyVaultResourceId = $keyVault.ResourceId;
        $keyEncryptionKeyUrl = $kek.Key.kid;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A1' -UpgradePolicyMode 'automatic' `
         | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
         | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
         | Set-AzureRmVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
         -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
         -ImageReferencePublisher $imgRef.PublisherName;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        # Get
        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        # Get Instance View
        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;

        Set-AzureRmVmssDiskEncryptionExtension -ResourceGroupName $rgname -VMScaleSetName $vmssName `
                                            -AadClientID $aadClientID -AadClientSecret $aadClientSecret `
                                            -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId `
                                            -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -Force;

        $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $result_string = $result | Out-String;

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Virtual Machine Scale Set Disk Encryption Extension
#>
function Test-DisableVirtualMachineScaleSetDiskEncryption
{
    try
    {
        # Common
        $loc = 'westcentralus';
        $rgname = "hyleevmssdetest2"
        $vmssName = 'vmss' + $rgname;

        $result = Get-AzureRmVmssDiskEncryption;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 2;
        $result_string = $result | Out-String;

        $result = Disable-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $result_string = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId 2;
        $result_string = $result | Out-String;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get Virtual Machine Scale Set Disk Encryption Status for VMSS without encryption
#>
function Test-GetVirtualMachineScaleSetDiskEncryptionStatus
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        # SRP
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        New-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
        $stoaccount = Get-AzureRMStorageAccount -ResourceGroupName $rgname -Name $stoname;

        # NRP
        $subnet = New-AzureRMVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
        $vnet = New-AzureRMVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
        $vnet = Get-AzureRMVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
        $subnetId = $vnet.Subnets[0].Id;

        # New VMSS Parameters
        $vmssName = 'vmss' + $rgname;
        $vmssType = 'Microsoft.Compute/virtualMachineScaleSets';

        $adminUsername = 'Foo12';
        $adminPassword = $PLACEHOLDER;

        $imgRef = Get-DefaultCRPImage -loc $loc;
        $storageUri = "https://" + $stoname + ".blob.core.windows.net/"
        $vhdContainer = "https://" + $stoname + ".blob.core.windows.net/" + $vmssName;

        $extname = 'csetest';
        $publisher = 'Microsoft.Compute';
        $exttype = 'BGInfo';
        $extver = '2.1';

        $extname2 = 'csetest2';

        $ipCfg = New-AzureRmVmssIPConfig -Name 'test' -SubnetId $subnetId;
        $vmss = New-AzureRmVmssConfig -Location $loc -SkuCapacity 2 -SkuName 'Standard_A0' -UpgradePolicyMode 'Manual' `
            | Add-AzureRmVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzureRmVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzureRmVmssStorageProfile -Name 'test' -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
            -ImageReferenceOffer $imgRef.Offer -ImageReferenceSku $imgRef.Skus -ImageReferenceVersion $imgRef.Version `
            -ImageReferencePublisher $imgRef.PublisherName -VhdContainer $vhdContainer `
            | Add-AzureRmVmssExtension -Name $extname -Publisher $publisher -Type $exttype -TypeHandlerVersion $extver -AutoUpgradeMinorVersion $true;

        $result = New-AzureRmVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss;

        Assert-AreEqual $loc.Replace(" ", "") $result.Location;
        Assert-AreEqual 2 $result.sku.capacity;
        Assert-AreEqual 'standard_a0' $result.sku.name;
        Assert-AreEqual 'manual' $result.upgradepolicy.mode;

        $vmssResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName;

        $vmssInstanceViewResult = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceView;
        $output = $vmssInstanceViewResult | Out-String;

        $result = Get-AzureRmVmssDiskEncryptionStatus -ResourceGroupName $rgname;
        $output = $result | Out-String;

        $result = Get-AzureRmVmssDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $output = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName;
        $output = $result | Out-String;

        $result = Get-AzureRmVmssVMDiskEncryptionStatus -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "1";
        $output = $result | Out-String;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get Virtual Machine Scale Set Disk Encryption for VMSS with a data disk.
Precondition: The given VMSS has an encrypted data disk.
#>
function Test-GetVirtualMachineScaleSetDiskEncryptionDataDisk
{
    $rgname = "hyleevmssdetest2";
    $vmssName = "vmsshyleevmssdetest3";
    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    Assert-AreEqual "Encrypted" $result[0].DataVolumesEncrypted;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "1";
    Assert-AreEqual "Encrypted" $result.DataVolumesEncrypted;
    $output = $result | Out-String;

    Disable-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -Force;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName;
    Assert-AreEqual "NotEncrypted" $result[0].DataVolumesEncrypted;
    $output = $result | Out-String;

    $result = Get-AzureRmVmssVMDiskEncryption -ResourceGroupName $rgname -VMScaleSetName $vmssName -InstanceId "1";
    Assert-AreEqual "NotEncrypted" $result.DataVolumesEncrypted;
    $output = $result | Out-String;
}
