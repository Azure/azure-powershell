### Example 1: Create a Network Interface
```powershell
New-AzStackHCIVMNetworkInterface  -Name "testNic" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -Location "eastus" -SubnetName "testLnet" 
```
```output
Name            ResourceGroupName
----            -----------------
testNic      test-rg
```
This command creates a network interface in the specified resource group. 

