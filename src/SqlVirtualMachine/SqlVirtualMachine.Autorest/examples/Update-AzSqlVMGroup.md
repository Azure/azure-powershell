### Example 1
```powershell
Update-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01' -ClusterBootstrapAccount 'newbootstrapuser@yourdomain.com' -ClusterOperatorAccount 'newoperatoruser@yourdomain.com' -Tag @{'newkey'='newvalue'}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
```

### Example 2
```powershell
$group = Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
$group | Update-AzSqlVMGroup -ClusterBootstrapAccount 'newbootstrapuser@yourdomain.com' -ClusterOperatorAccount 'newoperatoruser@yourdomain.com' -Tag @{'newkey'='newvalue'}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
```

