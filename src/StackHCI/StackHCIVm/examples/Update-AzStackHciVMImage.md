### Example 1: Update an Image.
```powershell
Update-AzStackHCIVmVImage  -Name "testImage" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testImage      test-rg
```

This command updates an exisiting image in the specified resource group.

