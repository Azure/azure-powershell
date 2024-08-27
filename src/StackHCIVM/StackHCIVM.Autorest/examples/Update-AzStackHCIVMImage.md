### Example 1: Update an Image.
```powershell
Update-AzStackHCIVMImage  -Name "abc" -ResourceGroupName "test-rg" -Tag @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
abc      test-rg
```

This command updates an exisiting image in the specified resource group.

