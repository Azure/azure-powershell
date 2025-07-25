### Example 1: List all SQL Virtual Machine Groups
```powershell
Get-AzSqlVMGroup
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
eastus   sqlvmgroup02	ResourceGroup01
eastus   sqlvmgroup03	ResourceGroup02
```

### Example 2: List all SQL Virtual Machine Groups in a Resource Group
```powershell
Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01'
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
eastus   sqlvmgroup02	ResourceGroup01
```

### Example 3: Get a SQL Virtual Machine Group
```powershell
Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
```

