### Example 1: Update a Network Interface.
```powershell
Update-AzStackHCIVmVNetworkInterface  -Name "testNic" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command updates an exisiting network interface in the specified resource group.
