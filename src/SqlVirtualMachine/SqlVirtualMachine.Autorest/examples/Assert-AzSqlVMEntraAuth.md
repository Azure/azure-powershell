### Example 1:
```powershell
Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'SystemAssigned'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

Validates system assigned managed identity for enabling Entra authentication on Sql VM

### Example 2:
```powershell
Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'UserAssigned' -ManagedIdentityClientId '11111111-2222-3333-4444-555555555555'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

validates user assigned managed identity for enabling Entra authentication on Sql VM

### Example 3:
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'SystemAssigned'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

Validates system assigned managed identity for enabling Entra authentication on Sql VM

### Example 4:
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'UserAssigned' -ManagedIdentityClientId '11111111-2222-3333-4444-555555555555'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

validates user assigned managed identity for enabling Entra authentication on Sql VM