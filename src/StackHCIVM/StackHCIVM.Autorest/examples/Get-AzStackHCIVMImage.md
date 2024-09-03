### Example 1:  Get an Image 
```powershell
Get-AzStackHCIVMImage -Name "testimage" -ResourceGroupName "test-rg" 
```
```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```

This command gets a specific image in the specified resource group. 

### Example 2: List all Images in a Resource Group  
```powershell
Get-AzStackHCIVMImage -ResourceGroupName 'test-rg'
```
```output
Name            ResourceGroupName
----            -----------------
testImage       test-rg
```
This command lists all images in the specified resource group. 

