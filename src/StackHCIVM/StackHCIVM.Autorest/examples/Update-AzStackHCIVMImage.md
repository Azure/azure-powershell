### Example 1: Update an Image.
```powershell
Update-AzStackHCIVMImage  -Name "testImage" -ResourceGroupName "test-rg" -Tag @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
testImage      test-rg
```

This command updates an exisiting image in the specified resource group.

