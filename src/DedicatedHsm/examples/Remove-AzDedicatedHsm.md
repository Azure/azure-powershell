### Example 1: Remove a Dedicated HSM by name
```powershell
PS C:\> Remove-AzDedicatedHsm -Name hsm-7t2xaf -ResourceGroupName lucas-manual-test

```

This commnad removes a hardware security module(HSM) by name.

### Example 2: Remove a Dedicated HSM  by object
```powershell
PS C:\> $hsm = Get-AzDedicatedHsm -Name hsm-7t2xaf -ResourceGroupName dedicatedhsm-rg-n359cz
PS C:\> Remove-AzDedicatedHsm -InputObject  $hsm

```

This commnad removes a Dedicated HSM by object.

