### Example 1: Create a Virtual Hard Disk
```powershell
New-AzStackHCIVMVirtualHardDisk -Name "testVhd" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -Location "eastus" -SizeGb 2
```
```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```
This command creates a virtual hard disk in the specified resource group. 


