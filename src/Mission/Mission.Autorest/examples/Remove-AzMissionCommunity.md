### Example 1: Delete a community
```powershell
Remove-AzMissionCommunity -Name 'contoso-community' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-community` community from the `mission-rg` resource group. Use `-PassThru` to return `$true` on success.
