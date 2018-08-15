# Upcoming Breaking Changes

## Release X.0.0 - May 2018

The following cmdlets were affected this release:

**New-AzureRmAvailabilitySet**
- Switch parameter, Managed, will be replaced with Sku parameter.
In order to set a managed availability set, a user should give Sku parameter with 'Aligned' value.

```powershell
# Old
New-AzureRmAvailabilitySet -Managed

# New
New-AzureRmAvailabilitySet -Sku 'Aligned'
```

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

**New-AzureRmDiskConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmDiskUpdateConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmSnapshotConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**New-AzureRmSnapshotUpdateConfig**
- The accepted values for parameter SkuName will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmImageOsDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmVMDataDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmVMOSDisk**
- The accepted values for parameter StorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Set-AzureRmVmssStorageProfile**
- The accepted values for parameter ManagedDisk will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively

**Update-AzureRmVmss**
- The accepted values for parameter ManagedDiskStorageAccountType will change from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively