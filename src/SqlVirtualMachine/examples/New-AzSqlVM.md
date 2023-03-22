### Example 1
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

### Example 2
```powershell
New-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -Location 'eastus' -Sku 'Developer' -LicenseType 'PAYG'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

