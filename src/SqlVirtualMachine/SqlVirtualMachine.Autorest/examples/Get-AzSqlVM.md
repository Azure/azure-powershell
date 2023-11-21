### Example 1: List all SQL Virtual Machines in a Resource Group
```powershell
Get-AzSqlVM -ResourceGroupName 'ResourceGroup01'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
eastus		sqlvm2		ResourceGroup01	
eastus		sqlvm3		ResourceGroup02	
```

### Example 2: Get a SQL Virtual Machine
```powershell
Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

### Example 3: List all SQL Virtual Machines in a SQL Virtual Machine Group
```powershell
Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -GroupName 'sqlvmgroup01'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
eastus		sqlvm2		ResourceGroup01	
```

