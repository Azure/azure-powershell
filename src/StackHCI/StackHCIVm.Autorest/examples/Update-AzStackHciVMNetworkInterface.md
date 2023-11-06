### Example 1: Update a Network Interface.
```powershell
PS C:\> Update-AzStackHCIVmNetworkInterface  -Name "testNic" -ResourceGroupName "test-rg" -Tag "@{TagName = TagValue }"
```

```output
Name            ResourceGroupName
----            -----------------
testNic       test-rg
```

This command updates an exisiting network interface in the specified resource group.
