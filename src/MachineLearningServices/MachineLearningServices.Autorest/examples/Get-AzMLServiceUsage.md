### Example 1: Gets the current usage information as well as limits for AML resources for given subscription and location
```powershell
Get-AzMLServiceUsage -Location eastus
```

```output
AmlWorkspaceLocation CurrentValue Limit Unit
-------------------- ------------ ----- ----
                     9            200   Count
                     8            100   Count
                     0            100   Count
```

Gets the current usage information as well as limits for AML resources for given subscription and location.
