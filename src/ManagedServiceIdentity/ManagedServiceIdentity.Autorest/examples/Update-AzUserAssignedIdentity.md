### Example 1: Updates an user assigned identity
```powershell
Update-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01 -Tag @{'key01'='value01'; 'key02'='value02'}
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command updates an user assigned identity.

### Example 2: Updates an user assigned identity by pipeline
```powershell
Get-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01 | Update-AzUserAssignedIdentity -Tag @{'key01'='value01'; 'key02'='value02'}
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command updates an user assigned identity by pipeline.
