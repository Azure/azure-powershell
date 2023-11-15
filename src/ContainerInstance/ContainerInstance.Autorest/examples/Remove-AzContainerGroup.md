### Example 1: Remove a container group
```powershell
Remove-AzContainerGroup -Name test-cg -ResourceGroupName test-rg
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This command removes the specified container group.

### Example 2: Removes a container group by piping
```powershell
Get-AzContainerGroup -Name test-cg -ResourceGroupName bez-rg | Remove-AzContainerGroup
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This command removes a container group by piping.