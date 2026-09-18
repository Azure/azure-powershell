### Example 1: Delete a dedicated hub
```powershell
Remove-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-dedicatedhub` dedicated hub from the `contoso-community` community. Use `-PassThru` to return `$true` on success.
