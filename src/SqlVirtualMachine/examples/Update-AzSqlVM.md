### Example 1
```powershell
Update-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -SqlManagementType 'Full' -Sku 'Standard' -LicenseType 'AHUB' -Tag @{'newkey'='newvalue'}
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

### Example 2
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Update-AzSqlVM -SqlManagementType 'Full' -Sku 'Standard' -LicenseType 'AHUB' -Tag @{'newkey'='newvalue'}
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

