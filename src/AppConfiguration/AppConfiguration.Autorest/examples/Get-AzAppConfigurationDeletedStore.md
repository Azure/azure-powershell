### Example 1: Gets a deleted Azure app configuration store.
```powershell
Remove-AzAppConfigurationStore -Name azpstestappstore -ResourceGroupName azpstest-gp
Get-AzAppConfigurationDeletedStore
```

```output
Name             ResourceGroupName
----             -----------------
azpstestappstore
```

Gets a deleted Azure app configuration store.

### Example 2: Gets a deleted Azure app configuration store.
```powershell
Remove-AzAppConfigurationStore -Name azpstestappstore -ResourceGroupName azpstest-gp
Get-AzAppConfigurationDeletedStore -Location eastus -Name azpstestappstore
```

```output
Name             ResourceGroupName
----             -----------------
azpstestappstore
```

Gets a deleted Azure app configuration store.