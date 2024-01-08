### Example 1:
```powershell
Assert-AzSqlVMADAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AzureAdAuthenticationSettingClientId ''
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Validate Microsoft Entra authentication with a system-assigned managed identity

### Example 2:
```powershell
Assert-AzSqlVMADAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -AzureAdAuthenticationSettingClientId '11111111-2222-3333-4444-555555555555'
```

```output
Location	Name		ResourceGroupName
--------	----		-----------------
eastus		sqlvm1		ResourceGroup01	
```

Validate Microsoft Entra authentication with a user-assigned managed identity


