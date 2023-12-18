### Example 1: Updates a Maps Account
```powershell
Update-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount03 -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount03 Microsoft.Maps/accounts Gen1
```

This command updates a Maps Account.
Only a subset of the parameters may be updated after creation, such as Sku, Tags, Properties.

### Example 2: Updates a Maps Account by pipeline
```powershell
Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount03 | Update-AzMapsAccount -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount03 Microsoft.Maps/accounts Gen1
```

This command updates a Maps Account by pipeline.
Only a subset of the parameters may be updated after creation, such as Sku, Tags, Properties.

