### Example 1: Delete a community endpoint
```powershell
Remove-AzMissionCommunityEndpoint -Name 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

Deletes the `contoso-endpoint` community endpoint from the `contoso-community` community. Use `-PassThru` to return `$true` on success.
