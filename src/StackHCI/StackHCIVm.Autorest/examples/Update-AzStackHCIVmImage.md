### Example 1: Update an Image.
```powershell
PS C:\> Update-AzStackHCIVmImage  -Name "testImage" -ResourceGroupName "test-rg" -Tag @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testImage      test-rg
```

This command updates an exisiting image in the specified resource group.

