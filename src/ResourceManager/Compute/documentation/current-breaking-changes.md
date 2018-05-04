<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes

## Release 5.0.0 - May 2018

The following cmdlets were affected this release:

**Miscellaneous**
- The sku name property nested in types `PSDisk` and `PSSnapshot` will be changed from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

```powershell
# This will now return Standard_LRS or Premium_LRS
$disk = Get-AzureRmDisk -ResourceGroupName "MyResourceGroup" -DiskName "MyDiskName"
$disk.Sku.Name

$snapshot = Get-AzureRmSnapshot -ResourceGroupName "MyResourceGroup" -SnapshotName "MySnapshotName"
$snapshot.Sku.Name
```

- The storage account type property nested in types `PSVirtualMachine`, `PSVirtualMachineScaleSet` and `PSImage` will be changed from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

```powershell
# This will now return Standard_LRS or Premium_LRS
$vm = Get-AzureRmVM -ResourceGroupName "MyResourceGroup" -Name "MyVM"
$vm.StorageProfile.DataDisks[0].ManagedDisk.StorageAccountType
```

**Add-AzureRmImageDataDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Add-AzureRmVMDataDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Add-AzureRmVmssDataDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmAvailabilitySet**
- The parameter `Managed` is being deprecated in favor of `Sku`

```powershell
# Old
New-AzureRmAvailabilitySet -ResourceGroupName "MyRG" -Name "MyAvailabilitySet" -Location "West US" -Managed

# New
New-AzureRmAvailabilitySet -ResourceGroupName "MyRG" -Name "MyAvailabilitySet" -Location "West US" -Sku "Aligned"
```

**New-AzureRmDiskConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmDiskUpdateConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmSnapshotConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmSnapshotUpdateConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmVM**
- The parameter alias `Tags` is being removed

**Set-AzureRmImageOsDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmVMAEMExtension**
- The parameter `DisableWAD` is being deprecated
    -  Windows Azure Diagnostics is disabled by default

**Set-AzureRmVMDataDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmVMOSDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmVmssStorageProfile**
- The accepted values for parameter ManagedDisk will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Update-AzureRmVM**
- The parameter alias `Tags` is being removed

**Update-AzureRmVmss**
- The accepted values for parameter ManagedDiskStorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

## Release 4.0.0 - November 2017

The following cmdlets were affected this release:

**Set-AzureRmVMAccessExtension**
- Parameters "UserName" and "Password" are being replaced in favor of a PSCredential

```powershell
# Old
Set-AzureRmVMAccessExtension [other required parameters] -UserName "plain-text string" -Password "plain-text string"

# New
Set-AzureRmVMAccessExtension [other required parameters] -Credential $PSCredential
```