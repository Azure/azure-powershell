### Example 1: Update a Network Interface.
```powershell
Update-AzStackHCIVMNetworkInterface  -Name "testNic" -ResourceGroupName "test-rg" -Tag @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command updates an exisiting network interface in the specified resource group.