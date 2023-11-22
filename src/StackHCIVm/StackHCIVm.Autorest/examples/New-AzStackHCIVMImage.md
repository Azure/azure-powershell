### Example 1: Create a  Gallery Image 
```powershell
New-AzStackHCIVMImage -Name "testImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -ImagePath "C:\ClusterStorage\Volume1\Ubunut.vhdx" -OSType "Linux" -Location "eastus" 
```
```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```
This command creates a gallery image from a local path. 

### Example 2:  Create a Marketplace Gallery Image 
```powershell
New-AzStackHCIVMImage -Name "testMarketplaceImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -Offer "windowsserver" -Publisher "MicrosoftWindowsServer" -Sku "2022-Datacenter" -Version "latest" -OSType "Windows"
```
```output
Name            ResourceGroupName
----            -----------------
testMarketplaceImage       test-rg
```
This command creates a marketplace gallery image using the specified offer , publisher, sku and version. 

### Example 3: {Create a  Marketplace Gallery Image From URN 
```powershell
New-AzStackHCIVMImage -Name "testMarketplaceImageURN" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}"  -Location "eastus" -URN  "microsoftwindowsserver:windowsserver:2022-datacenter:latest" -OSType "Windows"
```
```output
Name            ResourceGroupName
----            -----------------
testMarketplaceImageURN       test-rg
```
This command creates a marketplace gallery image using the specified urn. 

