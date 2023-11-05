### Example 1: Create a Storage Path 
```powershell
PS C:\> New-AzStackHCIVmStoragePath  -Name "testStoragePath" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"-Location "eastus" -Path "C:\ClusterStorage\Volume1\testpath"
```
```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```
This command creates a storage path in the specified resource group. 


