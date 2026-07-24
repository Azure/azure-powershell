### Example 1: Delete a transit hub
```powershell
Remove-AzMissionTransitHub -Name 'contoso-transithub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-transithub` transit hub from the `contoso-community` community. Use `-PassThru` to return `$true` on success.
