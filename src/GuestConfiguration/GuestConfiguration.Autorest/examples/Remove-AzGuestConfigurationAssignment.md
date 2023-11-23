### Example 1: Delete a guest configuration assignment
```powershell
Remove-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VMName test-vm -Name test-assignment -PassThru
```

```output
True
```

Delete a guest configuration assignment named test-assignment

### Example 2: Delete a guest configuration assignment by piping
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VMName test-vm -Name test-assignment | Remove-AzGuestConfigurationAssignment -PassThru
```

```output
True
```

Delete a guest configuration assignment named test-assignment by piping
