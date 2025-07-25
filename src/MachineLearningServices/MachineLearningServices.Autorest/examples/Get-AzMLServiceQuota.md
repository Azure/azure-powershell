### Example 1: Gets the currently assigned Workspace Quotas based on VMFamily
```powershell
Get-AzMLServiceQuota -Location eastus
```

```output
AmlWorkspaceLocation Limit Unit
-------------------- ----- ----
                     100   Count
                     100   Count
                     100   Count
                     100   Count
                     100   Count
```

Gets the currently assigned Workspace Quotas based on VMFamily.

