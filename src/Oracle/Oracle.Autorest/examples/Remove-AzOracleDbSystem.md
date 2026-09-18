### Example 1: Delete a DbSystem
```powershell
Remove-AzOracleDbSystem -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestDbSystem -PassThru
```

```output
True
```

Deletes a DbSystem by name and resource group. For more information, execute `Get-Help Remove-AzOracleDbSystem`.

### Example 2: Delete a DbSystem by piping from Get
```powershell
Get-AzOracleDbSystem -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestDbSystem | Remove-AzOracleDbSystem -PassThru
```

```output
True
```

Gets a DbSystem and deletes it by piping the object to `Remove-AzOracleDbSystem`. For more information, execute `Get-Help Remove-AzOracleDbSystem`.
