### Example 1: Create a Logical Network 
```powershell
 New-AzStackHCIVmLogicalNetwork  -Name "testLnet" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -VmSwitchName "testswitch"
```
```output
Name            ResourceGroupName
----            -----------------
testLnet       test-rg
```
This command creates a logical network in the specified resource group. 


